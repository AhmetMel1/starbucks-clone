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
   public class WorkTimeManager : IWorkTimeService
    {
        IWorkTimeDal workTimeDal;
        public WorkTimeManager(IWorkTimeDal workTimeDal)
        {
            this.workTimeDal = workTimeDal;
        }
        public void WorkTimeDelete(WorkTime workTime)
        {
            workTimeDal.delete(workTime);
        }

        public WorkTime WorkTimeGetById(int id)
        {
            return workTimeDal.get(x => x.workTimeId == id);
        }

        public void WorkTimeInsert(WorkTime workTime)
        {
           workTimeDal.insert(workTime);
        }

        public List<WorkTime> WorkTimeList()
        {
            return workTimeDal.list();
        }

        public void WorkTimeUpdate(WorkTime workTime)
        {
            return workTimeDal.update(workTime);
        }
    }
}
