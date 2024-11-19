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

        public static void DeleteDepartment(int iD)
        {
            try
            {
                DEPARTMENTS department= db.DEPARTMENTS.First(x => x.ID == iD);
                db.DEPARTMENTS.DeleteOnSubmit(department);
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

        public static void UpdateDepartment(DEPARTMENTS department)
        {
            try
            {
                DEPARTMENTS dpt= db.DEPARTMENTS.First(x =>x.ID==department.ID);
                dpt.DepartmentName= department.DepartmentName;
                db.SubmitChanges();

            }
            catch (Exception ex)

            {
                throw ex;
            }
        }
    }
}
