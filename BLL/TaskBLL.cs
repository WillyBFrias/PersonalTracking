using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DAO;
using DAL;

namespace BLL
{
    public class TaskBLL
    {
        public static void AddTask(TASK task)
        {
            TaskDAO.AddTask(task);
        }

        public static TaskDTO GetAll()
        {
            TaskDTO taskdto = new TaskDTO();
            taskdto.Employees= EmployeeDAO.GetEmployees();
            taskdto.Departments= DepartmentDAO.GetDepartments();
            taskdto.Positions= PositionDAO.GetPositions();
            taskdto.TaskStates = TaskDAO.GetTaskStates();
            return taskdto;
        }
    }
}
