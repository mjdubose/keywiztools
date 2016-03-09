using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace KeyWizTools
{
    public class TermedTransferKeyList : IDisposable
    {
        string fileName;
        string CSVFILENAME;
        DataTable DTable;
        List<Employee> TermedEmployees;
        public TermedTransferKeyList(string sourcefilename, string csvfilename)
        {
            fileName = sourcefilename;
            CSVFILENAME = csvfilename;
            TermedEmployees = new List<Employee>();
        }

        public TermedTransferKeyList(string sourcefilename)
        {
            fileName = sourcefilename;
            TermedEmployees = new List<Employee>();
        }


        static List<string> getSheetNames(string excelFile)
        {
            List<string> tableList = new List<string>();

            using (OleDbConnection connection = new OleDbConnection(excelFile))
            {
                connection.Open();
                DataTable tableInfo = connection.GetSchema("Tables");
                foreach (DataRow row in tableInfo.Rows)
                {
                    tableList.Add(row["TABLE_NAME"].ToString());
                }
                connection.Close();
            }
            return tableList;
        }

        public string ReadDataGenerateReport(EmployeeDataBases databasetobequeried)
        {
            try
            {
                List<string> tablelist = getSheetNames(fileName);
                using (OleDbConnection MyConnection = new OleDbConnection(fileName))
                {
                    string query = "select * from [" + tablelist[0] + "]";

                    using (OleDbDataAdapter MyCommand = new OleDbDataAdapter(query, MyConnection))
                    {

                        MyCommand.TableMappings.Add("Table", "TestTable");
                        DTable = new DataTable();
                        MyCommand.Fill(DTable);
                        MyConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            var ListOfEmployeesForWhomWeAreLookingForKeys = (from DataRow row in DTable.Rows where (row[0].ToString() != string.Empty) select row[0].ToString().Trim()).ToList();
            TermedEmployees = databasetobequeried.GetEmployeeByID(ListOfEmployeesForWhomWeAreLookingForKeys);

            databasetobequeried.AddKeysToEmployees(TermedEmployees);

            StringBuilder sb = new StringBuilder();

            foreach (Employee x in TermedEmployees.Where(x => x.Keys == true))
            {

                List<Key> KeysThatTheEmployeeHas = x.Getkeys();

                foreach (Key onekey in KeysThatTheEmployeeHas)
                {
                    sb.AppendLine(x.FirstName + " " + x.LastName + " " + onekey.ToString() + " " + x.Dept);

                }
            }
            return sb.ToString();
        }

        public void Dispose()
        {
            DTable.Dispose();
        }
    }
}
