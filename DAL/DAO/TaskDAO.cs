using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class TaskDAO : EmployeeContext
    {
        public static void AddTask(TASK task)
        {
            try
            {
                db.TASK.InsertOnSubmit(task);
                db.SubmitChanges();
            }
            catch (Exception ex) 
            {

                throw ex;
            }
        }

        public static List<TASKSTATE> GetTaskStates()
        {
            return db.TASKSTATE.ToList();
        }
    }
}
