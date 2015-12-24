using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
namespace KeyWizTools
{
    public static  class staticmethods
    {
      public static void AddEmployee(this SqlCommand cmdIns, List<Employee> temp, string commandtext)
      {
          
          cmdIns.CommandType = CommandType.Text;
         
          int i = 0;//increments the sql variable to keep them unique.
          int j = 0; //causes sql command to fire at 2000 employees.
          if (temp.Count > 0)
          {
             
              foreach (var emp in temp)
              {
                  if (j * 18 > 2000)
                  {
                      cmdIns.ExecuteNonQuery();
                      cmdIns.Parameters.Clear();
                      cmdIns.CommandText = string.Empty;
                      j = 0;
                  }
                  cmdIns.CommandText += string.Format(commandtext, i);

                  cmdIns.Parameters.AddWithValue("@personal_num" + i, emp.EmployeeNumber);
                  cmdIns.Parameters.AddWithValue("@first_name" + i, emp.FirstName);
                  cmdIns.Parameters.AddWithValue("@middle_initial" + i, emp.MiddleInitial);
                  cmdIns.Parameters.AddWithValue("@last_name" + i, emp.LastName);
                  cmdIns.Parameters.AddWithValue("@addresss" + i, emp.Address);
                  cmdIns.Parameters.AddWithValue("@address2" + i, emp.Address2);
                  cmdIns.Parameters.AddWithValue("@city" + i, emp.City);
                  cmdIns.Parameters.AddWithValue("@state" + i, emp.State);
                  cmdIns.Parameters.AddWithValue("@zip" + i, emp.Zip);
                  cmdIns.Parameters.AddWithValue("@home_phone" + i, emp.Home_Phone);
                  cmdIns.Parameters.AddWithValue("@office_phone" + i, emp.Office_Phone);
                  cmdIns.Parameters.AddWithValue("@fax_num" + i, emp.Fax_Num);
                  cmdIns.Parameters.AddWithValue("@pager_num" + i, emp.Pager_Num);
                  cmdIns.Parameters.AddWithValue("@mobile_phone" + i, emp.Mobile_Phone);
                  cmdIns.Parameters.AddWithValue("@email_address" + i, emp.Email);
                  cmdIns.Parameters.AddWithValue("@dept" + i, emp.Dept);
                  cmdIns.Parameters.AddWithValue("@salutation" + i, emp.Salutation);
                  cmdIns.Parameters.AddWithValue("@title" + i, emp.Title);
                  i++;
                  j++;
              }
             
              cmdIns.ExecuteNonQuery();
            
              cmdIns.Parameters.Clear();
              cmdIns.CommandText = string.Empty;
              
          }
      }
    
    }
}
