using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Data;
namespace KeyWizTools
{
    public class SQLDataBase : EmployeeDataBases, IDisposable
    {
        Employees SQLemployees = new Employees();
        SqlConnection connection;

        public SQLDataBase()
        {

        }

        public SQLDataBase(string Connection)
        {
            connection = new SqlConnection(Connection);
        }
        public void Dispose()
        {
            connection.Dispose();
            SQLemployees = null;
        }


        public void ReadData()
        {

            try
            {

                try
                {
                    SQLemployees = new Employees();
                    connection.Open();
                    using (SqlCommand myCommand = new SqlCommand("select * from KEYWIZ", connection))
                    {
                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {
                            while (myReader.Read())
                            {
                                SQLemployees.AddEmployee(new Employee(myReader[0].ToString(), myReader[1].ToString(), myReader[2].ToString(), myReader[3].ToString(), myReader[4].ToString(), myReader[5].ToString(), myReader[6].ToString(), myReader[7].ToString(), myReader[8].ToString(), myReader[9].ToString(), myReader[10].ToString(), myReader[11].ToString(), myReader[12].ToString(), myReader[13].ToString(), myReader[14].ToString(), myReader[15].ToString(), myReader[16].ToString(), myReader[17].ToString()));
                            }
                        }


                    }
                }

                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());

                }
                finally
                {
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());

            }

        }
        public List<Employee> GetList()
        {
            return SQLemployees.GetEmployeeList();
        }
        private void InsertEmployeeInDatabase(List<Employee> emp)
        {
            connection.Open();
            try
            {
                var dt = new DataTable();
                dt.Columns.Add("PERSONAL_NUM");
                dt.Columns.Add("FIRST_NAME");
                dt.Columns.Add("MIDDLE_INITIAL");
                dt.Columns.Add("LAST_NAME");
                dt.Columns.Add("ADDRESS");
                dt.Columns.Add("ADDRESS2");
                dt.Columns.Add("CITY");
                dt.Columns.Add("STATE");
                dt.Columns.Add("ZIP");
                dt.Columns.Add("HOME_PHONE");
                dt.Columns.Add("OFFICE_PHONE");
                dt.Columns.Add("FAX_NUM");
                dt.Columns.Add("PAGER_NUM");
                dt.Columns.Add("MOBILE_PHONE");
                dt.Columns.Add("EMAIL_ADDRESS");
                dt.Columns.Add("DEPT");
                dt.Columns.Add("SALUTATION");
                dt.Columns.Add("TITLE");

                foreach (var employee in emp)
                {
                    dt.Rows.Add(employee.EmployeeNumber, employee.FirstName, employee.MiddleInitial, employee.LastName, employee.Address, employee.Address2, employee.City, employee.State, employee.Zip, employee.Home_Phone, employee.Office_Phone, employee.Fax_Num, employee.Pager_Num, employee.Mobile_Phone, employee.Email, employee.Dept, employee.Salutation, employee.Title);
                }
                var transaction = connection.BeginTransaction();
                using (var sqlBulk = new SqlBulkCopy(connection, SqlBulkCopyOptions.KeepIdentity, transaction))
                {
                    sqlBulk.DestinationTableName = "KEYWIZ";

                    try
                    {
                        sqlBulk.WriteToServer(dt);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                transaction.Commit();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }


        }
        private void UpdateEmployeeinDatabase(List<Employee> emp)
        {
            connection.Open();
            using (SqlCommand cmdIns = new SqlCommand())
            {
                cmdIns.CommandText = "";
                cmdIns.Connection = connection;
                cmdIns.AddEmployee(emp, "UPDATE KEYWIZ SET FIRST_NAME = @first_name{0}, MIDDLE_INITIAL= @middle_initial{0}, LAST_NAME = @last_name{0}, ADDRESS = @addresss{0}, ADDRESS2 = @address2{0}, CITY = @city{0}, STATE = @state{0}, ZIP = @zip{0}, HOME_PHONE = @home_phone{0}, OFFICE_PHONE = @office_phone{0}, FAX_NUM = @fax_num{0}, PAGER_NUM = @pager_num{0}, MOBILE_PHONE = @mobile_phone{0}, EMAIL_ADDRESS = @email_address{0}, DEPT =@dept{0}, SALUTATION = @salutation{0}, TITLE = @title{0} WHERE PERSONAL_NUM = @personal_num{0} ;");
            }
            connection.Close();
        }

        public void WriteData(List<Employee> EmployeeListFromKeyWizardDatabase)
        {
            int added = 0;
            int updated = 0;
            List<Employee> add = new List<Employee>();
            List<Employee> update = new List<Employee>();
            foreach (Employee employeetobechecked in EmployeeListFromKeyWizardDatabase)
            {
                //check to see if employee number exists within the employee list
                //if not.  add them to the list to be inserted.
                if (!SQLemployees.EmployeeExists(employeetobechecked.EmployeeNumber))
                {
                    add.Add(employeetobechecked);

                    added++;
                }
                else
                {// if the employee number exists
                    //add them to the list to be updated.
                    if (!SQLemployees.EmployeeCompare(employeetobechecked))
                    {
                        update.Add(employeetobechecked);

                        updated++;
                    }
                }
            }
            InsertEmployeeInDatabase(add);
            UpdateEmployeeinDatabase(update);

            MessageBox.Show(added + " Records added" + Environment.NewLine + updated + " Records updated");
        }
        public void AddKeysToEmployees(List<Employee> Employeelist)
        {
            try
            {
                connection.Open();

                using (SqlCommand mycommand = new SqlCommand("select * from KEYS", connection))
                {
                    using (SqlDataReader myReader = mycommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            Key temp = new Key(myReader[2].ToString(), myReader[4].ToString(), myReader[5].ToString(), myReader[3].ToString(), myReader[1].ToString());
                            var x = Employeelist.SingleOrDefault(s => s.EmployeeNumber == temp.Employeeid);
                            if (x == null)
                            {
                                //  MessageBox.Show(temp.Employeeid + " " + temp.Keysymbol + " " + temp.Keyserial);

                            }
                            else
                            {
                                x.AddKey(temp);
                                x.Keys = true;
                                //   MessageBox.Show(x.EmployeeNumber + " " + " " + temp.Employeeid + " " + temp.Keysymbol);
                            }
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

        public void WriteKeys(List<Employee> temp)
        {
            connection.Open();
            try
            {

                using (SqlCommand cmdIns = new SqlCommand("TRUNCATE TABLE [KEYS]", connection))
                {

                    cmdIns.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            List<Key> show = new List<Key>();
            foreach (Employee zx in temp)
            {
                if (zx.Keys)
                {
                    show.AddRange(zx.Getkeys());
                }
            }

            string sqlIns = "INSERT INTO KEYS (PERSONAL_NUM,KEY_SYMBOL,KEY_SERIAL,KEY_DEPOSIT,MASTER_SYSTEM_NAME) VALUES (@personal_num,@keysymbol,@keyserial,@keydeposit,@mastersystemname)";
            using (SqlCommand cmdIns = new SqlCommand(sqlIns, connection))
            {
                try
                {
                    foreach (var z in show)
                    {
                        cmdIns.Parameters.Clear();
                        cmdIns.Parameters.AddWithValue("@personal_num", z.Employeeid);
                        cmdIns.Parameters.AddWithValue("@keysymbol", z.Keysymbol);
                        cmdIns.Parameters.AddWithValue("@keyserial", z.Keyserial);
                        cmdIns.Parameters.AddWithValue("@keydeposit", z.Keydeposit);
                        cmdIns.Parameters.AddWithValue("@mastersystemname", z.Mastersystemname);
                        cmdIns.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }

            }
            connection.Close();
        }

        public List<Employee> GetEmployeeByID(List<string> ID)
        {
            SQLemployees = new Employees();
            connection.Open();
            using (SqlCommand myCommand = new SqlCommand("select * from KEYWIZ WHERE PERSONAL_NUM = @en", connection))
            {
                foreach (var x in ID)
                {
                    myCommand.Parameters.Clear();
                    myCommand.Parameters.AddWithValue("@en", x);
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            if (myReader[0] != null)
                            {
                                SQLemployees.AddEmployee(new Employee(myReader[0].ToString(), myReader[1].ToString(), myReader[2].ToString(), myReader[3].ToString(), myReader[4].ToString(), myReader[5].ToString(), myReader[6].ToString(), myReader[7].ToString(), myReader[8].ToString(), myReader[9].ToString(), myReader[10].ToString(), myReader[11].ToString(), myReader[12].ToString(), myReader[13].ToString(), myReader[14].ToString(), myReader[15].ToString(), myReader[16].ToString(), myReader[17].ToString()));
                            }

                        }
                    }
                }

            }
            connection.Close();
            return SQLemployees.GetEmployeeList();
        }
    }
}
