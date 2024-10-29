using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class DepartmentDAO : EmployeeContext
    {
        public static void AddDepartment(DEPARTMENTS department)
        {
            try
            {
                db.DEPARTMENTS.InsertOnSubmit(department);
                db.SubmitChanges();
            }
            catch (Exception ex) 
            {

                throw ex;
            }
            
        }

        public static List<DEPARTMENTS> GetDepartments()
        {
            return db.DEPARTMENTS.ToList();
        }
    }
}
