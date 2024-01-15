using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Parts.API.Domain.Models;
using Parts.API.Domain.Repositories;
using Parts.API.Persistence.Contexts;

namespace Parts.API.Persistence.Repositories
{
    public class ClientRepository : BaseRepository, IClientRepository
    {
        public ClientRepository(PartsDBContext context) : base(context)
        {
        }

        public async Task AddAsync(Client client)
        {
            await context.Client.AddAsync(client);
        }
        public async Task AddAddressAsync(int id, Address address)
        {
            await context.Address.AddAsync(address);
            context.SaveChanges();
            var last = context.Address.ToList().LastOrDefault();
            await context.ClientAddress.AddAsync(new ClientAddress(){ IdClient=id, IdAddress=last.Id });
        }
        public async Task<Client> FindByIdAsync(int id)
        {
            return await context.Client.FindAsync(id);
        }

        public async Task<Address> FindAddressByIdAsync(int id)
        {
            return await context.Address.FindAsync(id);
        }

        public async Task<IEnumerable<Client>> ListAsync()
        {
            return await context.Client.ToListAsync();
        }

        public void Remove(Client client)
        {
            context.Client.Remove(client);
        }

        public void UpdateAddress(Address address)
        {
            context.Address.Update(address);
            context.SaveChanges();
        }

        public void Update(Client client)
        {
            context.Client.Update(client);
        }
        public async Task<Role> GetRole(int clientId)
        {
            return await context.Role.FindAsync((await context.Client.FindAsync(clientId)).IdRole);
        }
        public async Task<IEnumerable<Address>> GetAddressAsync(int clientId)
        {
            var table = (await context.ClientAddress.ToListAsync())
                .Where(x => x.IdClient==clientId);
            var table2 = (await context.Address.ToListAsync());
            return (from t1 in table
            join t2 in table2 on t1.IdAddress equals t2.Id
            select t2);
        }

        public void RemoveAddress(int clientID, Address address)
        {
            context.ClientAddress.Remove(context.ClientAddress
                    .Where(x=>x.IdAddress==address.Id&&x.IdClient==clientID)
                    .FirstOrDefault());
            context.Address.Remove(address);
        }




        
        public async Task AddAddressPhoneAsync(int addressId, AddressPhoneNumber address)
        {
            await context.AddressPhoneNumber.AddAsync(new AddressPhoneNumber(){ IdAddress=addressId, PhoneNumber=address.PhoneNumber});
        }

        public async Task<AddressPhoneNumber> FindAddressPhoneByIdAsync(int id)
        {
            return await context.AddressPhoneNumber.FindAsync(id);
        }

        public void UpdateAddressPhone(AddressPhoneNumber address)
        {
            context.AddressPhoneNumber.Update(address);
            context.SaveChanges();
        }
        public async Task<IEnumerable<AddressPhoneNumber>> GetAddressPhoneAsync(int clientId, int addressId)
        {
            var table = (await context.ClientAddress.ToListAsync())
                .Where(x => x.IdClient==clientId);
            var table2 = (await context.Address.ToListAsync());
            var table3 = (await context.AddressPhoneNumber.ToListAsync());
            return (from t1 in table
            join t2 in table2 on t1.IdAddress equals t2.Id
            join t3 in table3 on t2.Id equals t3.IdAddress
            select t3);
        }

        public void RemoveAddressPhone(int addressId, int phoneId, AddressPhoneNumber address)
        {
            context.AddressPhoneNumber.Remove(context.AddressPhoneNumber
                    .Where(x=>x.IdAddress==addressId&&x.Id==phoneId)
                    .FirstOrDefault());
            context.AddressPhoneNumber.Remove(address);
        }




        
        public async Task AddAddressMailAsync(int addressId, AddressMail address)
        {
            await context.AddressMail.AddAsync(new AddressMail(){ IdAddress=addressId, Mail=address.Mail});
        }

        public async Task<AddressMail> FindAddressMailByIdAsync(int id)
        {
            return await context.AddressMail.FindAsync(id);
        }

        public void UpdateAddressMail(AddressMail address)
        {
            context.AddressMail.Update(address);
            context.SaveChanges();
        }
        public async Task<IEnumerable<AddressMail>> GetAddressMailAsync(int clientId, int addressId)
        {
            var table = (await context.ClientAddress.ToListAsync())
                .Where(x => x.IdClient==clientId);
            var table2 = (await context.Address.ToListAsync());
            var table3 = (await context.AddressMail.ToListAsync());
            return (from t1 in table
            join t2 in table2 on t1.IdAddress equals t2.Id
            join t3 in table3 on t2.Id equals t3.IdAddress
            select t3);
        }

        public void RemoveAddressMail(int addressId, int mailId, AddressMail address)
        {
            context.AddressMail.Remove(context.AddressMail
                    .Where(x=>x.IdAddress==addressId&&x.Id==mailId)
                    .FirstOrDefault());
            context.AddressMail.Remove(address);
        }
    }
}