using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms.VisualStyles;
using System.Management.Instrumentation;
using System.Security.Cryptography;
using Microsoft.VisualBasic;


namespace EmployeeManagement
{

    public partial class Attendance : Form
    {
        //store the exact name of form that is selected by user to open.
        String FormNameToOpen;

        public Attendance()
        {
            InitializeComponent(); 
            //this.VisibleChanged += Attendance_VisibleChanged; // everytime the visibility  is changed, the data record is requeried
        }

        // data connection to the SSMS
        readonly SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HEN5LI1\SQLEXPRESS01;Initial Catalog=Employee.db;Integrated Security=True");


        private void Attendance_Load(object sender, EventArgs e)
        {
            //LoadAttendanceData();
        }


        //Login portal selection
        private void btnLogIn1_Click(object sender, EventArgs e)
        { 
            //Set form name && open form
            FormNameToOpen = "LogIn";

            OpenNameSelectionForm();
        }

        //Logout portal selection
        private void btnLogOut1_Click(object sender, EventArgs e)
        {
            //Set form name && open form
            FormNameToOpen = "LogOut";

            OpenNameSelectionForm();
        }

        //EmployeeRecord portal
        private void btnEmployeeRecord1_Click(object sender, EventArgs e)
        {
            //Set form name && open form
            FormNameToOpen = "EmployeeRecord";

            OpenNameSelectionForm();
        }


        // till here
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            FormNameToOpen = "EmployeeRecord";
            int NewEmployeeID = 0;

            //STEP1: this is new employee. Get next available EmployeeID 
            // Use that as employeeID when opening the form.

            try
            {
                con.Open();

                string query = "SELECT Max(EmployeeID) From tblEmployeeRecords ";

                using (SqlCommand cmd = new SqlCommand(query, con))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        NewEmployeeID = reader.GetInt32(0);
                        NewEmployeeID = NewEmployeeID + 1; //increase the employeeid by 1. 
                    }
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); con.Close();
            }

            //if found new id then procedd. 
            if (NewEmployeeID != 0)
            {
                //open form
                EmployeeRecord thisform = new EmployeeRecord(NewEmployeeID);
                thisform.IsNewEmployee = true;
                thisform.Show();

                this.Hide();
            }
        }

        private void OpenNameSelectionForm()
        {
            NameSelection thisform = new NameSelection(FormNameToOpen);
            thisform.Show();

            this.Hide();
        }

        private void btnChangeEmployeeStatus_Click(object sender, EventArgs e)
        {

        }

        
        private void Attendance_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                LoadAttendanceData();
            }
        }

        //Get current employee login records
        private void LoadAttendanceData()
        {
            con.Open();

            dataGridView1.DataSource = null;
            SqlCommand conn = new SqlCommand("SELECT er.EmployeeID AS EID, er.FullName, a.ID AS AID, a.AttendanceDate, a.TimeIn, a.TimeOut FROM tblEmployeeRecords er LEFT JOIN(SELECT EmployeeID, MAX(ID) AS MaxAID FROM tblAttendance GROUP BY EmployeeID) AS latest ON er.EmployeeID = latest.EmployeeID LEFT JOIN tblAttendance a ON a.ID = latest.MaxAID WHERE er.CurrentEmployee = 1", con);

            SqlDataAdapter da = new SqlDataAdapter(conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();

        }
    }
}
