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
    public class CargoProccessManager : ICargoProccessService
    {
        ICargoProccessDal cargoProccessDal;
        public CargoProccessManager(ICargoProccessDal cargoProccessDal)
        {
            this.cargoProccessDal = cargoProccessDal;
        }
        public void cargoProccessDelete(CargoProcess cargoProcess)
        {
           cargoProccessDal.delete(cargoProcess);
        }

        public CargoProcess CargoProccessGetById(int id)
        {
            return cargoProccessDal.get(x => x.cargoId == id);
        }

        public void cargoProccessInsert(CargoProcess cargoProcess)
        {
            cargoProccessDal.insert(cargoProcess);
        }

        public List<CargoProcess> cargoProccessList()
        {
            return cargoProccessDal.list();
        }

        public void cargoProccessUpdate(CargoProcess cargoProcess)
        {
            cargoProccessDal.update(cargoProcess);
        }
    }
}
