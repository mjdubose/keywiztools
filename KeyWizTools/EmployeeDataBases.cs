﻿using System.Collections.Generic;

namespace KeyWizTools
{
    public interface EmployeeDataBases
    {
        void ReadData();
        void WriteData(List<Employee> temp);
        void AddKeysToEmployees(List<Employee> temp);
        void WriteKeys(List<Employee> temp);
        List<Employee> GetEmployeeByID(List<string> ID);
        List<Employee> GetList();
    }
}
