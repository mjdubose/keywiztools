using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using KeyWizTools;

namespace KeyWizardDataBaseTools
{
    public partial class KWTools : Form
    {
        private delegate void ObjectDelegate(object obj);
        List<Employee> CSVEMP;
        List<Employee> KEYWIZEMP;
        string SQLCONNECTION = ConfigurationManager.ConnectionStrings["KeyWizardDataBaseTools.Properties.Settings.SampleDataBaseConnectionString"].ConnectionString;
        string KEYWIZCONNECTION = ConfigurationManager.ConnectionStrings["KeyWizardDataBaseTools.Properties.Settings.KeyWizConnectionString"].ConnectionString;

        SQLDataBase SQL;
        Clariondb keywiz;
        public KWTools()
        {
            InitializeComponent();
            SQL = new SQLDataBase(SQLCONNECTION);
            keywiz = new Clariondb(KEYWIZCONNECTION);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(openFileDialog1.FileName))
                {
                    try
                    {
                        if (openFileDialog1.FileName.Length != 0)
                        {
                            if (File.Exists(openFileDialog1.FileName))
                            {
                                ObjectDelegate del = new ObjectDelegate(SetText);

                                backgroundWorker1.RunWorkerAsync(openFileDialog1.FileName);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        private void DoSQLUpdateFromKeyWiz()
        {
            SetText("Reading in Employees from Keywizard" + Environment.NewLine);

            keywiz.ReadData();
            KEYWIZEMP = keywiz.GetList();
            SetText("Adding keys to Employees" + Environment.NewLine);

            keywiz.AddKeysToEmployees(KEYWIZEMP);

            SetText("Reading in existing SQL Server Employees" + Environment.NewLine);
            SQL.ReadData();
            SetText("Writing updates to SQL Server Employees." + Environment.NewLine);
            SQL.WriteData(KEYWIZEMP);
            SetText("Writing updates to SQL Server Keys." + Environment.NewLine);
            SQL.WriteKeys(KEYWIZEMP);
            SetText("Done." + Environment.NewLine);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ObjectDelegate del = new ObjectDelegate(SetText);
            backgroundWorker4.RunWorkerAsync();
        }

        private void btnDoTermedEmployeeKeyList_Click(object sender, EventArgs e)
        {

            openFileDialog1.InitialDirectory = "G:\\mtgasec\\LOCKSMITHS (ONLY)\\Employee Data\\";
            openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (openFileDialog1.FileName.Length != 0)
                    {
                        if (File.Exists(openFileDialog1.FileName))
                        {
                            ObjectDelegate del = new ObjectDelegate(SetText);
                            backgroundWorker2.RunWorkerAsync(openFileDialog1.FileName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void doTermedEmployeeKeySearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "G:\\mtgasec\\LOCKSMITHS (ONLY)\\Employee Data\\";
            openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (openFileDialog1.FileName.Length != 0)
                    {
                        if (File.Exists(openFileDialog1.FileName))
                        {
                            ObjectDelegate del = new ObjectDelegate(SetText);
                            backgroundWorker2.RunWorkerAsync(openFileDialog1.FileName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    txtDisplay.Text += "Done." + Environment.NewLine;
                }
            }
        }

        private void updateKeyWizardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (openFileDialog1.FileName.Length != 0)
                    {
                        if (File.Exists(openFileDialog1.FileName))
                        {
                            ObjectDelegate del = new ObjectDelegate(SetText);
                            backgroundWorker1.RunWorkerAsync(openFileDialog1.FileName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnKeysToFile_Click(object sender, EventArgs e)
        {
            CSVEMP = new List<Employee>();
            KEYWIZEMP = new List<Employee>();
            SQL = new SQLDataBase(SQLCONNECTION);
            keywiz = new Clariondb(KEYWIZCONNECTION);
            openFileDialog1.InitialDirectory = "G:\\mtgasec\\LOCKSMITHS (ONLY)\\Employee Data\\";
            openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (openFileDialog1.FileName.Length != 0)
                    {
                        if (File.Exists(openFileDialog1.FileName))
                        {
                            ObjectDelegate del = new ObjectDelegate(SetText);
                            backgroundWorker3.RunWorkerAsync(openFileDialog1.FileName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void SetText(object text)
        {
            if (this.txtDisplay.InvokeRequired)
            {
                ObjectDelegate d = new ObjectDelegate(SetText);
                Invoke(d, text);
            }
            else
            {
                this.txtDisplay.Text += (string)text;
            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string FileName = (string)e.Argument;
            CSVKW csvfile = new CSVKW(FileName, @"c:\test.csv");
            SetText(FileName + " is being read" + Environment.NewLine);
            csvfile.ReadData();
            CSVEMP = csvfile.GetList();
            SetText("Reading in existing SQL Records" + Environment.NewLine);
            SQL = new SQLDataBase(SQLCONNECTION);

            SQL.ReadData();
            SetText("Inserting employees into and updating employees in the SQL DATABASE" + Environment.NewLine);
            SQL.WriteData(CSVEMP);

            keywiz = new Clariondb(KEYWIZCONNECTION);

            SetText("Reading in data from KEY WIZARD" + Environment.NewLine);
            keywiz.ReadData();
            SetText("Writing Updated data to KEY WIZARD from the CSV File." + Environment.NewLine);
            keywiz.WriteData(CSVEMP);
            SetText("Done updating data in KEY WIZARD" + Environment.NewLine);

        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            string FileName = (string)e.Argument;
            string TermedTransferFile = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = '" + FileName + "';Extended Properties=\"Excel 12.0 Xml;HDR=YES\"";
            SetText("Loading Employees" + Environment.NewLine);
            SetText("Loading Termed or Transferred Employees" + Environment.NewLine);
            TermedTransferKeyList test = new TermedTransferKeyList(TermedTransferFile);
            SetText("Linking keys to Employees" + Environment.NewLine);
            SetText(test.ReadDataGenerateReport(SQL));
            SetText("Done." + Environment.NewLine);
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            string FileName = (string)e.Argument;
            string TermedTransferFile = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = '" + FileName + "';Extended Properties=\"Excel 12.0 Xml;HDR=YES\"";
            SetText("Loading Employees" + Environment.NewLine);
            SetText("Loading Termed or Transferred Employees" + Environment.NewLine);
            TermedTransferKeyList test = new TermedTransferKeyList(TermedTransferFile);
            SetText("Linking keys to Employees" + Environment.NewLine);
            string temp = test.ReadDataGenerateReport(SQL);
            SetText(temp);

            using (var sw = new StreamWriter(@"c:\termkeys.txt", false))
            {
                sw.Write(temp);
            }
            SetText(@"Done. File is at c:\termkeys.txt");
        }

        private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        {
            DoSQLUpdateFromKeyWiz();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void KWTools_FormClosing(object sender, FormClosingEventArgs e)
        {
            SQL.Dispose();
            keywiz.Dispose();
        }
    }
}
