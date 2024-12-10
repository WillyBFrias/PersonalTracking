using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class PermissionDAO : EmployeeContext
    {
        public static void AddPermission(PERMISSION permission)
        {
            try
            {
                db.PERMISSION.InsertOnSubmit(permission);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void DeletePermission(int permissionID)
        {
            try
            {
                PERMISSION pr= db.PERMISSION.First(x => x.ID == permissionID);
                db.PERMISSION.DeleteOnSubmit(pr);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<PermissionDetailDTO> GetPermissions()
        {
            List<PermissionDetailDTO > permissions = new List<PermissionDetailDTO>();

            var list=(from ps in db.PERMISSION
                      join s in db.PERMISSIONSTATE on ps.PermissionState equals s.ID
                      join e in db.EMPLOYEE on ps.EmployeeID equals e.ID
                      join d in db.DEPARTMENTS on e.DepartmentID equals d.ID
                      join p in db.POSITION on e.PositionID equals p.ID
                      select new
                      {
                          UserNo= e.UserNo,
                          Name= e.Name,
                          Surname= e.SurName,
                          Statename = s.StateName,
                          StateID = ps.PermissionState,
                          Startdate= ps.PermissionStartDate,
                          EndDate= ps.PermissionEndDate,
                          EmployeeID= ps.EmployeeID,
                          PermissionID= p.ID,
                          Explanation= ps.PermissionExplanation,
                          Dayamount= ps.PermissionDay,
                          DepartmentID= e.DepartmentID,
                          PositionID= e.PositionID,
                          DepartmentName= d.DepartmentName,
                          PositionName= p.PositionName,


                      }).OrderBy(x=>x.Startdate).ToList();
            foreach (var item in list)
            {
                PermissionDetailDTO dto = new PermissionDetailDTO();
                dto.UserNo = item.UserNo;
                dto.Name = item.Name;
                dto.SurName = item.Surname;
                dto.EmployeeID = item.EmployeeID;
                dto.PermissionDayAmount = item.Dayamount;
                dto.StartDate = item.Startdate;
                dto.EndDate = item.EndDate;
                dto.DepartmentID = item.DepartmentID;
                dto.PositionID = item.PositionID; 
                dto.State= item.StateID;
                dto.StateName = item.Statename;
                dto.Explanation = item.Explanation;
                dto.PermissionID = item.PermissionID;
                dto.DepartmentName = item.DepartmentName;
                dto.PositionName = item.PositionName;
                permissions.Add(dto);
                
            }
            return permissions;
        }

        public static List<PERMISSIONSTATE> GetStates()
        {
            return db.PERMISSIONSTATE.ToList();
        }

        public static void UpdatePermission(PERMISSION permission)
        {
            try
            {
                PERMISSION pr= db.PERMISSION.First(x=>x.ID==permission.ID);
                pr.PermissionStartDate= permission.PermissionStartDate;
                pr.PermissionEndDate= permission.PermissionEndDate;
                pr.PermissionExplanation= permission.PermissionExplanation;
                pr.PermissionDay= permission.PermissionDay;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {


                throw ex;
            }
        }

        public static void UpdatePermission(int permissionID, int approved)
        {
            try
            {
                PERMISSION pr = db.PERMISSION.First(x => x.ID==permissionID);
                pr.PermissionState= approved;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
