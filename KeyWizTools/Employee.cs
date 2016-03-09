using System.Collections.Generic;

namespace KeyWizTools
{
    public class Employee
    {
        public Employee()
        {
        }

        private string m_EmployeeNumber;
        private string m_FirstName;
        private string m_MiddleInitial;
        private string m_LastName;
        private string m_Address;
        private string m_Address2;
        private string m_City;
        private string m_State;
        private string m_Zip;
        private string m_Home_Phone;
        private string m_Office_Phone;
        private string m_Fax_Num;
        private string m_Pager_Num;
        private string m_Mobile_Phone;
        private string m_Email;
        private string m_Dept;
        private string m_Salutation;
        private string m_Title;
        private List<Key> keys = new List<Key>();

        public string EmployeeNumber { get { return m_EmployeeNumber; } set { m_EmployeeNumber = ((value.Length > 12) ? value.Remove(12) : value).Trim(); } }
        public string FirstName { get { return m_FirstName; } set { m_FirstName = (value.Length > 20) ? value.Remove(20) : value; } }
        public string MiddleInitial { get { return m_MiddleInitial; } set { m_MiddleInitial = (value.Length > 1) ? value.Remove(1) : value; } }
        public string LastName { get { return m_LastName; } set { m_LastName = (value.Length > 20) ? value.Remove(20) : value; } }
        public string Address { get { return m_Address; } set { m_Address = (value.Length > 30) ? value.Remove(30) : value; } }
        public string Address2 { get { return m_Address2; } set { m_Address2 = (value.Length > 30) ? value.Remove(30) : value; } }
        public string City { get { return m_City; } set { m_City = (value.Length > 20) ? value.Remove(20) : value; } }
        public string State { get { return m_State; } set { m_State = (value.Length > 3) ? value.Remove(3) : value; } }
        public string Zip { get { return m_Zip; } set { m_Zip = (value.Length > 11) ? value.Remove(11) : value; } }
        public string Home_Phone { get { return m_Home_Phone; } set { m_Home_Phone = (value.Length > 25) ? value.Remove(25) : value; } }
        public string Office_Phone { get { return m_Office_Phone; } set { m_Office_Phone = (value.Length > 25) ? value.Remove(25) : value; } }
        public string Fax_Num { get { return m_Fax_Num; } set { m_Fax_Num = (value.Length > 25) ? value.Remove(25) : value; } }
        public string Pager_Num { get { return m_Pager_Num; } set { m_Pager_Num = (value.Length > 25) ? value.Remove(25) : value; } }
        public string Mobile_Phone { get { return m_Mobile_Phone; } set { m_Mobile_Phone = (value.Length > 25) ? value.Remove(25) : value; } }
        public string Email { get { return m_Email; } set { m_Email = (value.Length > 60) ? value.Remove(60) : value; } }
        public string Dept { get { return m_Dept; } set { m_Dept = (value.Length > 30) ? value.Remove(30) : value; } }
        public string Salutation { get { return m_Salutation; } set { m_Salutation = (value.Length > 8) ? value.Remove(8) : value; } }
        public string Title { get { return m_Title; } set { m_Title = (value.Length > 35) ? value.Remove(35) : value; } }
        public bool Keys;

        public void AddKey(Key x)
        {
            keys.Add(x);
        }

        public List<Key> Getkeys()
        {
            return keys;
        }
        public Employee(string empnum, string fname, string mi, string lname, string add, string add2, string city, string state, string zip, string home, string office, string fax, string pager, string mobile, string email, string dept, string salutation, string title)
        {
            EmployeeNumber = empnum.Trim();
            FirstName = fname;
            MiddleInitial = mi;
            LastName = lname;
            Address = add;
            Address2 = add2;
            City = city;
            State = state;
            Zip = zip;
            Home_Phone = home;
            Office_Phone = office;
            Fax_Num = fax;
            Pager_Num = pager;
            Mobile_Phone = mobile;
            Email = email;
            Dept = dept;
            Salutation = salutation;
            Title = title;
        }
        public override string ToString()
        {
            return EmployeeNumber + "," + FirstName + "," + MiddleInitial + "," + LastName + "," + Address + "," + Address2 + "," + City + "," + State + "," + Zip + "," + Home_Phone + "," + Office_Phone + "," + Fax_Num + "," + Pager_Num + "," + Mobile_Phone + "," + Email + "," + Dept + "," + Salutation + "," + Title;
        }
    }
}
