using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SliderManager : ISliderService
    {
         ISliderDal sliderDal;
        public SliderManager(ISliderDal sliderDal)
        {
            this.sliderDal = sliderDal;
        }
        public void sliderDelete(Slider slider)
        {
            sliderDal.delete(slider);

        }

        public Slider SliderGetById(int id)
        {
            return sliderDal.get(x => x.sliderId == id);
        }

        public void sliderInsert(Slider slider)
        {
            sliderDal.insert(slider);
        }

        public List<Slider> sliderlist()
        {
            return sliderDal.list();
        }

        public void sliderUpdate(Slider slider)
        {
            sliderDal.update(slider);
        }
    }
}
