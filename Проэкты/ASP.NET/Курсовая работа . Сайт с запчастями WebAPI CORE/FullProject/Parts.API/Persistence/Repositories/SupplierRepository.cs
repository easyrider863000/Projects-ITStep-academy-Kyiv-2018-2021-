using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Parts.API.Domain.Models;
using Parts.API.Domain.Repositories;
using Parts.API.Persistence.Contexts;

namespace Parts.API.Persistence.Repositories
{
    public class SupplierRepository : BaseRepository, ISupplierRepository
    {
        public SupplierRepository(PartsDBContext context) : base(context)
        {
        }

        public async Task AddAsync(Supplier supplier)
        {
            await context.Supplier.AddAsync(supplier);
        }

        public async Task<Supplier> FindByIdAsync(int id)
        {
            return await context.Supplier.FindAsync(id);
        }

        public async Task<IEnumerable<Supplier>> ListAsync()
        {
            return await context.Supplier.ToListAsync();
        }

        public void Remove(Supplier supplier)
        {
            context.Supplier.Remove(supplier);
        }

        public void Update(Supplier supplier)
        {
            context.Supplier.Update(supplier);
        }


        public async Task<IEnumerable<Address>> GetAddressAsync(int supplierId)
        {
            var table = (await context.SupplierAddress.ToListAsync())
                .Where(x => x.IdSupplier==supplierId);
            var table2 = (await context.Address.ToListAsync());
            return (from t1 in table
            join t2 in table2 on t1.IdAddress equals t2.Id
            select t2);
        }

        public void UpdateAddress(Address address)
        {
            context.Address.Update(address);
            context.SaveChanges();
        }

        public void RemoveAddress(int supplierID, Address address)
        {
            context.SupplierAddress.Remove(context.SupplierAddress
                    .Where(x=>x.IdAddress==address.Id&&x.IdSupplier==supplierID)
                    .FirstOrDefault());
            context.Address.Remove(address);
        }

        public async Task<Address> FindAddressByIdAsync(int id)
        {
            return await context.Address.FindAsync(id);
        }
        public async Task AddAddressAsync(int id, Address address)
        {
            await context.Address.AddAsync(address);
            context.SaveChanges();
            var last = context.Address.ToList().LastOrDefault();
            await context.SupplierAddress.AddAsync(new SupplierAddress(){ IdSupplier=id, IdAddress=last.Id });
        }





        public async Task<IEnumerable<AddressMail>> GetAddressMailAsync(int supplierId, int addressId)
        {
            var table = (await context.SupplierAddress.ToListAsync())
                .Where(x => x.IdSupplier==supplierId);
            var table2 = (await context.Address.ToListAsync());
            var table3 = (await context.AddressMail.ToListAsync());
            return (from t1 in table
            join t2 in table2 on t1.IdAddress equals t2.Id
            join t3 in table3 on t2.Id equals t3.IdAddress
            select t3);
        }

        public void UpdateAddressMail(AddressMail address)
        {
            context.AddressMail.Update(address);
            context.SaveChanges();
        }

        public void RemoveAddressMail(int addressId, int mailId, AddressMail address)
        {
            context.AddressMail.Remove(address);
        }

        public async Task<AddressMail> FindAddressMailByIdAsync(int id)
        {
            return await context.AddressMail.FindAsync(id);
        }
        public async Task AddAddressMailAsync(int addressId, AddressMail address)
        {
            await context.AddressMail.AddAsync(new AddressMail(){ IdAddress=addressId, Mail=address.Mail});
        }





        public async Task<IEnumerable<AddressPhoneNumber>> GetAddressPhoneAsync(int supplierId, int addressId)
        {
            var table = (await context.SupplierAddress.ToListAsync())
                .Where(x => x.IdSupplier==supplierId);
            var table2 = (await context.Address.ToListAsync());
            var table3 = (await context.AddressPhoneNumber.ToListAsync());
            return (from t1 in table
            join t2 in table2 on t1.IdAddress equals t2.Id
            join t3 in table3 on t2.Id equals t3.IdAddress
            select t3);
        }

        public void UpdateAddressPhone(AddressPhoneNumber address)
        {
            context.AddressPhoneNumber.Update(address);
            context.SaveChanges();
        }

        public void RemoveAddressPhone(int addressId, int phoneId, AddressPhoneNumber address)
        {
            context.AddressPhoneNumber.Remove(address);
        }

        public async Task<AddressPhoneNumber> FindAddressPhoneByIdAsync(int id)
        {
            return await context.AddressPhoneNumber.FindAsync(id);
        }
        public async Task AddAddressPhoneAsync(int addressId, AddressPhoneNumber address)
        {
            await context.AddressPhoneNumber.AddAsync(new AddressPhoneNumber(){ IdAddress=addressId, PhoneNumber=address.PhoneNumber});
        }
    }
}