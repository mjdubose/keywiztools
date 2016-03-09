using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyWizTools
{
    public class Employees
    {
        private List<Employee> EmployeePool = new List<Employee>();
        public Employees()
        { }

        public Employees(List<Employee> test)
        {
            EmployeePool = test;
        }

        public void AddEmployee(string pernum, string fname, string mi, string lname, string address, string address2, string city, string state, string zip, string hphone, string ophone, string fnum, string pnum, string mphone, string email, string dept, string salutation, string title)
        {
            EmployeePool.Add(new Employee(pernum, fname, mi, lname, address, address2, city, state, zip, hphone, ophone, fnum, pnum, mphone, email, dept, salutation, title));
        }
        public void AddEmployee(Employee temp)
        {
            EmployeePool.Add(temp);
        }
        public void RemoveEmployee(Employee temp)
        {
            EmployeePool.Remove(temp);
        }
        public void RemoveEmployee(string empnum)
        {
            Employee x = EmployeePool.FirstOrDefault(item => item.EmployeeNumber == empnum);
            EmployeePool.Remove(x);
        }

        public void UpdateEmployee(Employee y)
        {
            Employee x = EmployeePool.FirstOrDefault(item => item.EmployeeNumber == y.EmployeeNumber);
            if (x != null)
            {
                EmployeePool.Remove(x);
            }
            EmployeePool.Add(y);
        }

        public Employee ReturnEmployeeByID(string ID)
        {
            return EmployeePool.Find(item => item.EmployeeNumber == ID.Trim());

        }
        public bool EmployeeExists(string ID)
        {
            return EmployeePool.Exists(item => item.EmployeeNumber == ID.Trim());
        }
        public bool EmployeeCompare(Employee x)
        {
            Employee y = ReturnEmployeeByID(x.EmployeeNumber);
            return y != null && IsEqual(y.ToString(), x.ToString());
        }
        private bool IsEqual(string y, string x)
        {
            bool stringcompare = y == x;
            if (!stringcompare)
            {
                return (string.IsNullOrWhiteSpace(y) && string.IsNullOrWhiteSpace(x));
            }
            return stringcompare;
        }

        public List<Employee> GetEmployeeList()
        {
            return EmployeePool;
        }

        public int Count()
        {
            return EmployeePool.Count;
        }

    }
}
