using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
namespace KeyWizTools
{
    public class CSVKW : EmployeeDataBases
    {
        string fileName;
        string CSVFILENAME;
        List<Employee> temp;
        public CSVKW(string sourcefilename, string csvfilename)
        {
            fileName = sourcefilename;
            CSVFILENAME = csvfilename;
           
        }
        public void ReadData()
        {
            var pathname = Path.GetDirectoryName(fileName);
            var file = Path.GetFileName(fileName);
            var conn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source =" + pathname + @"; Extended Properties = ""Text;HDR=True;FMT=Delimited""";

            try
            {
                using (var connection = new OleDbConnection(conn))
                {
                    using (var command = new OleDbCommand(@"SELECT * FROM " + file, connection))
                    {
                        using (var adapter = new OleDbDataAdapter(command))
                        {
                            connection.Open();
                            using (var dt = new DataTable())
                            {
                                adapter.Fill(dt);
                                connection.Close();
                                CreateSchema(fileName, dt);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
             temp = new List<Employee>();
            try
            {
                using (var connection = new OleDbConnection(conn))
                {
                    using (var command = new OleDbCommand(@"SELECT * FROM " + file, connection))
                    {
                        using (var adapter = new OleDbDataAdapter(command))
                        {
                            connection.Open();
                            using (var dt = new DataTable())
                            {
                                adapter.Fill(dt);
                                connection.Close();
                                foreach (DataRow row in dt.Rows)
                                {
                                    Employee add = new Employee(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString(), row[9].ToString(), row[10].ToString(), row[11].ToString(), row[12].ToString(), row[13].ToString(), row[14].ToString(), row[15].ToString(), row[16].ToString(), row[17].ToString());
                                    temp.Add(add);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        public List<Employee> GetList()
        {
            return temp;
        }
        public static void CreateSchema(string fileName, DataTable dt)
        {
            var FileName = Path.GetFileName(fileName);
            var PathName = Path.GetDirectoryName(fileName);
            if (FileName == null) return;
            try
            {
                using (var sw = new StreamWriter(PathName + @"\schema.ini", false))
                {
                    sw.WriteLine(@"[" + FileName + "]");
                    sw.WriteLine(@"Format=CSVDelimited");
                    sw.WriteLine(@"ColNameHeader=True");
                    sw.WriteLine(@"MaxScanRows=0");
                    var iColCount = dt.Columns.Count;
                    for (var i = 0; i < iColCount; i++)
                    {
                        sw.WriteLine(@"Col" + (i + 1) + @"=" + dt.Columns[i].ColumnName + @" Text");
                    }
                    sw.WriteLine(@"CharacterSet=ANSI");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        public void WriteKeys(List<Employee> x)
        {
            var FileName = Path.GetFileName(CSVFILENAME);
            var PathName = Path.GetDirectoryName(CSVFILENAME);
            if (FileName == null) return;          

            try
            {
                using (var sw = new StreamWriter(PathName + FileName, false))
                {
                    sw.WriteLine("PERSONAL_NUM,FIRST_NAME,MIDDLE_INITIAL,LAST_NAME,KEYSYMBOL, SERIAL_NUMBER,MASTERKEY_SYSTEM, DEPOSIT");
      
                    // for each employee with keys
                    foreach (var emp in x.Where(y=>y.Keys))
                    {
                       //list the employee information and key information
                        
                            foreach (Key keys in emp.Getkeys())
                                sw.WriteLine("\"" + emp.EmployeeNumber + "\",\"" + emp.FirstName + "\",\"" + emp.MiddleInitial + "\",\"" + emp.LastName + "\",\"" + keys.Keysymbol + "\",\"" + keys.Keyserial + "\",\"" + keys.Mastersystemname + "\",\"" + keys.Keydeposit + "\"");
                        
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
     
        public void WriteData(List<Employee> x)
        {
            var FileName = Path.GetFileName(CSVFILENAME);
            var PathName = Path.GetDirectoryName(CSVFILENAME);
            if (FileName == null) return;
            try
            {
                int count = 0;
                using (var sw = new StreamWriter(PathName + FileName, false))
                {
                    sw.WriteLine("PERSONAL_NUM,FIRST_NAME,MIDDLE_INITIAL,LAST_NAME,ADDRESS,ADDRESS2,CITY,STATE,ZIP,HOME_PHONE,OFFICE_PHONE,FAX_NUM,PAGER_NUM,MOBILE_PHONE,EMAIL_ADDRESS,DEPT,SALUTATION,TITLE");
                    foreach (Employee emp in x)
                    {
                        sw.WriteLine("\"" + emp.EmployeeNumber + "\",\"" + emp.FirstName + "\",\"" + emp.MiddleInitial + "\",\"" + emp.LastName + "\",\"" + emp.Address + "\",\"" + emp.Address2 + "\",\"" + emp.City + "\",\"" + emp.State + "\",\"" + emp.Zip + "\",\"" + emp.Home_Phone + "\",\"" + emp.Office_Phone + "\",\"" + emp.Fax_Num + "\",\"" + emp.Pager_Num + "\",\"" + emp.Mobile_Phone + "\",\"" + emp.Email + "\",\"" + emp.Dept + "\",\"" + emp.Salutation + "\",\"" + emp.Title + "\"");
                        count++;
                    }
                    MessageBox.Show(count + " Records Written to file.");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
        public void AddKeysToEmployees(List<Employee> x)
        {
            return;
        }
        public List<Employee> GetEmployeeByID(List<string> ID)
        {
            List<Employee> temp = new List<Employee>();            
            return temp;
        }

    }
}
