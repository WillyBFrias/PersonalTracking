﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class SalaryDTO
    {
        public List<SalaryDetailDTO> Salaries { get; set; }
        public List<EmployeeDetailDTO> Employees { get; set; }
        public List<MONTHS> Months { get; set; }
        public List<DEPARTMENTS> Departments { get; set; }
        public List<PositionDTO> Positions { get; set; }
    }
}
