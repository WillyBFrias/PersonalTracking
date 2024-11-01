﻿using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class EmployeeDAO : EmployeeContext
    {
        public static void AddEmployee(EMPLOYEE employee)
        {
            try
            {
                db.EMPLOYEE.InsertOnSubmit(employee);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw(ex);
            }
        }

        public static List<EmployeeDetailDTO> GetEmployees()
        {
            List<EmployeeDetailDTO> employeeList = new List<EmployeeDetailDTO>();
            var list=(from e in db.EMPLOYEE
                      join d in db.DEPARTMENTS on e.DepartmentID equals d.ID
                      join p in db.POSITION on e.PositionID equals p.ID
                      select new
                      {
                          EmployeeID = e.ID,
                          UserNo = e.UserNo,
                          Name= e.Name,
                          SurName= e.SurName,                                                    
                          DepartmentName=d.DepartmentName,
                          PositionName=p.PositionName,
                          DepartmentID=e.DepartmentID,
                          PositionId=e.PositionID,
                          Salary = e.Salary,
                          isAdmin =e.isAdmin,
                          Password = e.Password,                          
                          ImagePath=e.ImagePath,                          
                          Adress=e.Adress,
                          BirthDay = e.BirthDay,
                      }).OrderBy(x=>x.UserNo).ToList();
            foreach (var item in list)
            {
                EmployeeDetailDTO dto = new EmployeeDetailDTO();
                dto.EmployeeID = item.EmployeeID;
                dto.UserNo = item.UserNo;
                dto.Name = item.Name;                
                dto.SurName = item.SurName;                 
                dto.Password = item.Password;
                dto.DepartmentID = item.DepartmentID;
                dto.DepartmentName = item.DepartmentName;
                dto.PositionID = item.PositionId;
                dto.PositionName = item.PositionName;                                                   
                dto.Salary = item.Salary;
                dto.IsAdmin = item.isAdmin;                                                
                dto.Adress = item.Adress;
                dto.Birthday = item.BirthDay;
                employeeList.Add(dto);

            }

            return employeeList;
        }

        public static List<EMPLOYEE> GetUsers(int v)
        {
            return db.EMPLOYEE.Where(x=>x.UserNo == v).ToList();
        }
    }
}
