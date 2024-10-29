using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DAO;

namespace BLL
{
    public class DepartmentBLL
    {
        public static void AddDepartment(DEPARTMENTS department)
        {
            DepartmentDAO.AddDepartment(department);
        }

        public static List<DEPARTMENTS> GetDepartments()
        {
            return DepartmentDAO.GetDepartments();
        }
    }
}
