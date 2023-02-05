using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISliderService
    {
        void sliderInsert(Slider slider);
        void sliderDelete(Slider slider);
        void sliderUpdate(Slider slider);
        List<Slider> sliderlist();
        Slider SliderGetById(int id);
    }
}
