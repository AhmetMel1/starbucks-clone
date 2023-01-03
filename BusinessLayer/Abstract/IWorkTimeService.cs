using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IWorkTimeService
    {
        void WorkTimeInsert(WorkTime workTime);
        void WorkTimeUpdate(WorkTime workTime);
        void WorkTimeDelete(WorkTime workTime);
        List<WorkTime> WorkTimeList();
        WorkTime WorkTimeGetById(int id);
    }
}
