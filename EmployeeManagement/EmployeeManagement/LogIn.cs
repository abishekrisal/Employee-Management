using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Management.Instrumentation;
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
        int thisEmployeeID;

        public LogIn(int passedonuserid)
        {
            InitializeComponent();
            thisEmployeeID = passedonuserid;
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HEN5LI1\SQLEXPRESS01;Initial Catalog=Employee.db;Integrated Security=True");
        //bool ErrorFound;


        private void LogIn_Load(object sender, EventArgs e)
        {
            // Check if user is loggedIn or not for today.
            //Only one login per user

            if (UserAlreadyLoggedIn())
            {
                this.Close();
            }
            // If no login for user then show login form.
            else
            { FillForm(); }
        }


        private void LogIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            var mainform = Application.OpenForms.Cast<Form>().FirstOrDefault(f => f is Attendance);
            if (mainform != null)
            {
                mainform.Show();
                mainform.Refresh();
            }
        }

        bool UserAlreadyLoggedIn()
        {
            bool returnvalue = true;

            try
            {
                //SQL check
                con.Open();

                string thisdate = DateTime.Now.ToString("yyyy-MM-dd");
                string Query = "select count(ID) from tblAttendance where (EmployeeID = @userid) AND (AttendanceDate = @Date)";
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@userid", thisEmployeeID);
                    cmd.Parameters.AddWithValue("@Date", thisdate);

                    int recordcount = (int)cmd.ExecuteScalar();

                    // combination of the username && password found.
                    if (recordcount == 0) { returnvalue = false; }
                    else { MessageBox.Show("User already loggedIn for today."); } // show error as id && pass combo was incorrect
                }
                con.Close();
            }
            catch (Exception){ MessageBox.Show("Error Try Again"); con.Close(); }

            //return result
            return returnvalue;
        }

        void FillForm()
        {
            try
            {
                // Get DATE & TIME TO DISPLAY IN FORM.
                string thistime = DateTime.Now.ToString("HH:mm:ss");
                string thisdate = DateTime.Now.ToString("dd-MM-yyyy");


                //After getting ID change to int EMployeeID
                //int thisEmployeeID = NameSelection.UserID;

                //Get information of employee.
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT tblEmployeeRecords.EmployeeID as ID, FullName, MAX(AttendanceDate) AS AttendanceDate FROM tblEmployeeRecords LEFT OUTER JOIN tblAttendance ON tblEmployeeRecords.EmployeeID = tblAttendance.EmployeeID WHERE(tblEmployeeRecords.EmployeeID = " + thisEmployeeID + " ) Group by tblEmployeeRecords.EmployeeID, FullName", con);
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
            // show error message and close the form.
            catch { MessageBox.Show("Error Try Again"); con.Close(); this.Close(); }
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
;                   this.Close();
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
