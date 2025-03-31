using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace EmployeeManagement
{
    public partial class NameSelection : Form
    {
        public NameSelection()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HEN5LI1\SQLEXPRESS01;Initial Catalog=Employee.db;Integrated Security=True");

        private void NameSelection_Load(object sender, EventArgs e)
        {
            FillComboBox();
        }

        void FillComboBox()
        {
            cbName.Items.Clear();
            con.Open();
            string Query = "select EmployeeID as ID, CONCAT(EmployeeID, ', ' , FullName) AS ComboBoxDisplay from tblEmployeeRecords where CurrentEmployee = 1";
            SqlCommand cmd = new SqlCommand(Query, con);
            SqlDataReader myReader;

            myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                string thisrow = myReader.GetString(1);
                cbName.Items.Add(thisrow);
            }
            con.Close();
        }


        private void cbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Upon selection of the combobox,
            // we will get ID & Name of the selected user
            // Could have function to ask for password after this but not implemented yet.

            // First, Pass on the selection to the main form and close this form.
            OpenSelectedForm();
            this.Close();
        }


        void OpenSelectedForm()
        {
            char thisformname = Attendance.thisSelectedForm;
            Attendance.thisSelectedValue = cbName.SelectedItem.ToString();

            // Open form and close this form.
            switch (thisformname)
            {
                case 'I':

                    //STEP1: OPEN LOGIN PAGE
                    // Make sure the the employee is selected before opening the form
                    if ((Attendance.thisSelectedValue) != "")
                    { 

                        LogIn logIn = new LogIn();
                        logIn.Show();
                    }
                    else { Console.WriteLine("Try Again. Error while loading page."); }
                    break;

                case 'O':

                    //STEP1: OPEN LOGOUT PAGE
                    // Make sure the the employee is selected before opening the form
                    if ((Attendance.thisSelectedValue) != "")
                    {
                        LogOut logOut = new LogOut();
                        logOut.Show();
                    }
                    else { Console.WriteLine("Try Again. Error while loading page."); }

                    break;
            }
        }
    }
}
