using System.Collections.Generic;
using Parts.API.Domain.Models;

namespace Parts.API.Resources.Resource
{
    public class ClientResource
    {
        public int Id{get;set;}
        public string Name{get;set;}
        public string SurName{get;set;}
        public string Description{get;set;}
        public float PriceDelivery{get;set;}
        public string Login{get;set;}
        public string Token{get;set;}
        public int IdRole{get;set;}
    }
}