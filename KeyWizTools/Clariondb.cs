using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Odbc;
using System.Windows.Forms;


namespace KeyWizTools
{
    public class Clariondb : EmployeeDataBases, IDisposable
    {
        Employees dbemployee = new Employees();
        OdbcConnection connection;
        public Clariondb(string Connection)
        {
            connection = new OdbcConnection(Connection);
        }

        public void Dispose()
        {
            dbemployee = null;

            connection.Dispose();

        }

        public void ReadData()
        {
            connection.Open();
            try
            {

                try
                {
                    string sqlcommand = "Select PERSONAL_NUM, FIRST_NAME, MIDDLE_INITIAL, LAST_NAME, ADDRESS, ADDRESS2, CITY, STATE, ZIP, HOME_PHONE, OFFICE_PHONE, FAX_NUM, PAGER_NUM, MOBILE_PHONE, EMAIL_ADDRESS, DEPT, SALUTATION, TITLE from PERSONAL";

                    using (OdbcCommand cmd = new OdbcCommand(sqlcommand, connection))
                    {
                        using (OdbcDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dbemployee.AddEmployee(new Employee(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), reader[8].ToString(), reader[9].ToString(), reader[10].ToString(), reader[11].ToString(), reader[12].ToString(), reader[13].ToString(), reader[14].ToString(), reader[15].ToString(), reader[16].ToString(), reader[17].ToString()));
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                connection.Close();

            }

        }

        public List<Employee> GetList()
        {
            return dbemployee.GetEmployeeList();
        }
        public void WriteKeys(List<Employee> x)
        {
            MessageBox.Show("Keys are added in Key Wizard");
        }
        public void WriteData(List<Employee> x)
        {
            int updated = 0;
            Employees tobeupdated = new Employees();
            foreach (Employee temp in x)
            {

                if (!dbemployee.EmployeeCompare(temp))
                {
                    tobeupdated.AddEmployee(temp);
                    updated++;
                }
            }

            MessageBox.Show(updated + " Records to be updated");
            if (tobeupdated.Count() > 0)
            {
                MessageBox.Show("Updating records in the key wizard database");
                List<Employee> sqlupdated = tobeupdated.GetEmployeeList();
                try
                {
                    connection.Open();
                    using (OdbcCommand cmdIns = new OdbcCommand("UPDATE PERSONAL SET FIRST_NAME =  ? , MIDDLE_INITIAL=  ?  , LAST_NAME = ?, ADDRESS = ?, ADDRESS2 = ?, CITY = ?, STATE = ?, ZIP = ?, HOME_PHONE = ?, OFFICE_PHONE = ?, FAX_NUM = ?, PAGER_NUM = ?, MOBILE_PHONE = ?, EMAIL_ADDRESS = ?, DEPT = ?, SALUTATION = ?, TITLE = ? WHERE PERSONAL_NUM = ?", connection))
                    {
                        foreach (var z in sqlupdated)
                        {
                            try
                            {
                                cmdIns.Parameters.AddWithValue("FIRST_NAME", z.FirstName);
                                cmdIns.Parameters.AddWithValue("MIDDLE_INITIAL", z.MiddleInitial);
                                cmdIns.Parameters.AddWithValue("LAST_NAME", z.LastName);
                                cmdIns.Parameters.AddWithValue("ADDRESS", z.Address);
                                cmdIns.Parameters.AddWithValue("ADDRESS2", z.Address2);
                                cmdIns.Parameters.AddWithValue("CITY", z.City);
                                cmdIns.Parameters.AddWithValue("STATE", z.State);
                                cmdIns.Parameters.AddWithValue("ZIP", z.Zip);
                                cmdIns.Parameters.AddWithValue("HOME_PHONE", z.Home_Phone);
                                cmdIns.Parameters.AddWithValue("OFFICE_PHONE", z.Office_Phone);
                                cmdIns.Parameters.AddWithValue("FAX_NUM", z.Fax_Num);
                                cmdIns.Parameters.AddWithValue("PAGER_NUM", z.Pager_Num);
                                cmdIns.Parameters.AddWithValue("MOBILE_PHONE", z.Mobile_Phone);
                                cmdIns.Parameters.AddWithValue("EMAIL_ADDRESS", z.Email);
                                cmdIns.Parameters.AddWithValue("DEPT", z.Dept);
                                cmdIns.Parameters.AddWithValue("SALUTATION", z.Salutation);
                                cmdIns.Parameters.AddWithValue("TITLE", z.Title);
                                cmdIns.Parameters.AddWithValue("PERSONAL_NUM", z.EmployeeNumber);
                                cmdIns.ExecuteNonQuery();
                                cmdIns.Parameters.Clear();
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.Message);
                            }
                        }
                    }
                }

                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            MessageBox.Show("Done updating " + updated + " records in Key Wizard database");
        }

        public void AddKeysToEmployee(Employee x)
        {
        }
        public void AddKeysToEmployees(List<Employee> employeelist)
        {
            List<Key> IssuedKeys = new List<Key>();
            try
            {
                connection.Open();

                try
                {

                    string odbccommand = "Select KEY_STAMP_NUM, KEY_DEPOSIT, MK_SYS_NAME, LABEL_ID, PERSONAL_NUM  from Keys_Issued WHERE QTY_ISSUE = 1";

                    using (OdbcCommand cmd = new OdbcCommand(odbccommand, connection))
                    {

                        using (OdbcDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if ((reader[0]) != null)
                                {
                                    IssuedKeys.Add(new Key(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString()));

                                }
                            }
                        }

                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                connection.Close();
            }

            foreach (var key in IssuedKeys)
            {
                var employee = employeelist.FirstOrDefault(s => s.EmployeeNumber == key.Employeeid);
                if (employee != null)
                {
                    employee.AddKey(key);
                    employee.Keys = true;
                }
            }
        }
        public List<Employee> GetEmployeeByID(List<string> ID)
        {
            try
            {
                connection.Open();
                try
                {
                    string odbccommand = "Select PERSONAL_NUM, FIRST_NAME, MIDDLE_INITIAL, LAST_NAME, ADDRESS, ADDRESS2, CITY, STATE, ZIP, HOME_PHONE, OFFICE_PHONE, FAX_NUM, PAGER_NUM, MOBILE_PHONE, EMAIL_ADDRESS, DEPT, SALUTATION, TITLE from PERSONAL WHERE PERSONAL_NUM = ? ";

                    using (OdbcCommand cmd = new OdbcCommand(odbccommand, connection))
                    {
                        foreach (var x in ID)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("PERSONAL_NUM", x);
                            using (OdbcDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    if ((reader[0]) != null)
                                    {
                                        dbemployee.AddEmployee(new Employee(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), reader[8].ToString(), reader[9].ToString(), reader[10].ToString(), reader[11].ToString(), reader[12].ToString(), reader[13].ToString(), reader[14].ToString(), reader[15].ToString(), reader[16].ToString(), reader[17].ToString()));
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return dbemployee.GetEmployeeList();
        }
    }
}
