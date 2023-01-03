using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAddressService
    {
        void addressInsert(Address address);
        void addressDelete(Address address);
        void addressUpdate(Address address);
        List<Address> addresslist();
        Address AddressGetById(int id);

    }
}
