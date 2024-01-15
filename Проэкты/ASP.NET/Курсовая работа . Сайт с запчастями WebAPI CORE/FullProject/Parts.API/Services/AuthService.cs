using System;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using Shop.API.Helpers;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Shop.API.Extensions;
using Parts.API.Domain.Services;
using Parts.API.Domain.Repositories;
using Parts.API.Domain.Models;
using Parts.API.Extensions;
using System.Security.Cryptography;

namespace Parts.API.Services
{
    public class AuthService : IAuthService
    {

        private readonly AppSettings appSettings;
        private readonly IClientRepository clientRepository;
        public AuthService(IOptions<AppSettings> appSettings, IClientRepository clientRepository)
        {
            this.appSettings = appSettings.Value;
            this.clientRepository = clientRepository;
        }
        public async Task<Client> Authenticate(string login, string password)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                Client client = (await clientRepository.ListAsync())
                                .SingleOrDefault(usr => usr.Login == login &&
                                                        usr.Password == MD5Hashing.GetMd5Hash(md5Hash, password));  
                if (client == null)
                    return null;

                client.GenerateToken(await clientRepository.GetRole(client.Id), appSettings.Secret, appSettings.ExpiresMinutes);

                return client;
            }
        }
    }
}