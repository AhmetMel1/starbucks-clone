using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AddressManager : IAddressService
    {
        IAddressDal addressDal;
        public AddressManager(IAddressDal addressDal)
        {
            this.addressDal = addressDal;
        }
        public void addressDelete(Address address)
        {
            addressDal.delete(address);
        }

        public Address AddressGetById(int id)
        {
            return addressDal.get(x => x.addressId == id);
        }

        public void addressInsert(Address address)
        {
            addressDal.insert(address);
        }

        public List<Address> addresslist()
        {
            return addressDal.list();
        }

        public void addressUpdate(Address address)
        {
            addressDal.update(address);
        }
    }
}

