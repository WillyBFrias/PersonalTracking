using DAL.DTO;
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

        public static List<TaskDetailDTO> GetTasks()
        {
            List<TaskDetailDTO> tasklist= new List<TaskDetailDTO>();

            var list= (from t in db.TASK
                       join s in db.TASKSTATE on t.TaskState equals s.ID
                       join e in db.EMPLOYEE on t.EmployeeID equals e.ID
                       join d in db.DEPARTMENTS on e.DepartmentID equals d.ID
                       join p in db.POSITION on e.PositionID equals p.ID
                       select new
                       {
                           TaskID = t.ID,
                           Title= t.TaskTitle,
                           Content = t.TaskContent,
                           Startdate = t.TaskStartDate,
                           Deliverydate= t.TaskDeliveryDate,
                           TaskStateName= s.StateName,
                           TaskStateID=t.TaskState,
                           UserNo=e.UserNo,
                           Name=e.Name,
                           EmployeeID=t.EmployeeID,
                           Surname= e.SurName,
                           PositionName= p.PositionName,
                           DepartmentName= d.DepartmentName,
                           PositionID= e.PositionID,
                           DepartmentID= e.DepartmentID,


                       }).OrderBy(x=>x.Startdate).ToList();
            foreach ( var item in list )
            {
                TaskDetailDTO dto = new TaskDetailDTO();
                dto.TaskID=item.TaskID;
                dto.Title= item.Title;
                dto.Content= item.Content;
                dto.TaskStartDate = item.Startdate;
                dto.TaskDeliveryDate = item.Deliverydate;
                dto.TaskStateName = item.TaskStateName;
                dto.TaskStateID=item.TaskStateID;
                dto.UserNo= item.UserNo;
                dto.Name= item.Name;
                dto.SurName= item.Surname;               
                dto.DepartmentName= item.DepartmentName;
                dto.PositionID= item.PositionID;
                dto.PositionName= item.PositionName;
                dto.EmployeeID= item.EmployeeID;
                dto.DepartmentID = item.DepartmentID;
                tasklist.Add(dto);

            }
            return tasklist;
        }

        public static List<TASKSTATE> GetTaskStates()
        {
            return db.TASKSTATE.ToList();
        }

        public static void UpdateTask(TASK task)
        {
            try
            {
               TASK ts= db.TASK.First(x => x.ID==task.ID);
                ts.TaskTitle = task.TaskTitle;
                ts.TaskContent = task.TaskContent;
                ts.TaskState = task.TaskState;
                ts.EmployeeID = task.EmployeeID;
                db.SubmitChanges();
            }
            catch (Exception ex) 
            {

                throw ex;
            }
        }
    }
}
