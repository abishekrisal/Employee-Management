using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace EmployeeManagement
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HEN5LI1\SQLEXPRESS01;Initial Catalog=Employee.db;Integrated Security=True");
        //bool ErrorFound;

        private void LogIn_Load(object sender, EventArgs e)
        {
            FillForm();
        }

        void LogIn_Close(object sender, EventArgs e)
        {
            // refresh and close the form.
            Attendance attendance = new Attendance();
            attendance.RefreshMainPageData();

            this.Close();
        }
        //Refresh function 


        void FillForm()
        {
            // Get DATE & TIME TO DISPLAY IN FORM.
            string thistime = DateTime.Now.ToString("HH:mm:ss");
            string thisdate = DateTime.Now.ToString("dd-MM-yyyy");

            // Get Employee details using employeeid 
            string thisID = "";
            int i = 0;
            string thisselectedvalue = Attendance.thisSelectedValue;

            while ((thisselectedvalue[i]) != ',')
            {
                thisID = thisID + thisselectedvalue[i].ToString();
                i = i + 1;
            }

            //After getting ID change to int EMployeeID
            int thisEmployeeID = int.Parse(thisID);

            //Get information of employee.
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT tblEmployeeRecords.EmployeeID as ID, FullName, MAX(AttendanceDate) AS AttendanceDate FROM tblEmployeeRecords LEFT OUTER JOIN tblAttendance ON tblEmployeeRecords.EmployeeID = tblAttendance.EmployeeID WHERE(tblEmployeeRecords.EmployeeID = "+ thisEmployeeID +" ) Group by tblEmployeeRecords.EmployeeID, FullName", con);
            SqlDataReader myReader;

            myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    txtID.Text = myReader[0].ToString();
                    txtName.Text = myReader[1].ToString();
                
                    //Get date from date and time.
                    string thisLastLogIndate = myReader[2].ToString();
                    if (!(thisLastLogIndate == "" || thisLastLogIndate == null))
                    {
                        DateTime.TryParse(thisLastLogIndate, out DateTime dateTime);
                        DateTime onlyDate = dateTime.Date;
                        txtLastLogIn.Text = onlyDate.ToString("dd-MM-yyyy");
                     }

                }

            //Console.WriteLine(txtLastLogIn);
            con.Close();

            txtDate.Text = thisdate;
            txtTimeIn.Text = thistime;
        }

        private void btnClockIn_Click(object sender, EventArgs e)
        {
            // Update the table record. AFTER USER selects the clockin btn push the update.
            // After update refresh the main page.         

            if (CheckAllTheUserInput())
            {
                
                //Push Update
                con.Open();

                try
                {
                    // Assign time from date & time from clock, Also, in correct format. 
                    string thisAttendanceDate = DateTime.Now.ToString("yyyy-MM-dd");
                    int EmployeeID = int.Parse(txtID.Text);
                    string thistime = DateTime.Now.ToString("HH:mm:ss");

                    string sqlText = "Insert into tblAttendance (EmployeeID, AttendanceDate , TimeIn, TimeOut, Comment, Overtime, OverTimeHours, ApprovedBY) Values (@EmployeeID, @AttendanceDate, @TimeIn, null , null , 0 , null , null) ";
                    SqlCommand cmd = new SqlCommand(sqlText, con);

                        cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                        cmd.Parameters.AddWithValue("@AttendanceDate", thisAttendanceDate);
                        cmd.Parameters.AddWithValue("@TimeIn", thistime);
                        
                        // Execute Query
                        cmd.ExecuteNonQuery();

                    con.Close();

                    // Close this form.
;                    LogIn_Close("LogIn",e);
                }
                catch (Exception) { con.Close(); }
            }
        }

        bool CheckAllTheUserInput()
        {
            bool thisresult = true;

            while (true)
            {
                //Check EmployeeID
                if (String.IsNullOrEmpty(txtID.Text)) { thisresult = false; break; }
                //Check Date
                if (String.IsNullOrEmpty(txtDate.Text)) { thisresult = false; break; }
                //Check State
                if (String.IsNullOrEmpty(txtTimeIn.Text)) { thisresult = false; break; }
                break;
            }

            //return result
            return thisresult;
        }
    }
}
