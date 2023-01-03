using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICargoProccessService
    {
        void cargoProccessInsert(CargoProcess cargoProcess);
        void cargoProccessUpdate(CargoProcess cargoProcess);
        void cargoProccessDelete(CargoProcess cargoProcess);
        List<CargoProcess> cargoProccessList();
        CargoProcess CargoProccessGetById(int id);

    }
}
