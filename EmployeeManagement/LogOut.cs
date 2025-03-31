using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagement
{
    public partial class LogOut : Form
    {
        public LogOut()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HEN5LI1\SQLEXPRESS01;Initial Catalog=Employee.db;Integrated Security=True");
        bool ErrorFound;

        private void LogOut_Load(object sender, EventArgs e)
        {
            FillForm();

            //No record found. 
            // Show message and Exit the form.            
            if (ErrorFound)
            {
                btnClockOut.Visible = false;    
                MessageBox.Show("No LogIn Records found. Only LoggedIn Staff can LogOut.");
                this.Close();
            }
        }

        void LogOut_Close(object sender, EventArgs e)
        {
            // refresh and close the form.
            Attendance attendance = new Attendance();
            attendance.RefreshMainPageData();

            this.Close();
        }


        void FillForm()
        {
            // Get DATE & TIME TO DISPLAY IN FORM.
            string thistime = DateTime.Now.ToString("HH:mm:ss");
            string thisdate = DateTime.Now.ToString("yyyy-MM-dd");

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

            SqlCommand cmd = new SqlCommand("SELECT tblEmployeeRecords.EmployeeID AS ID, FullName, AttendanceDate, TimeIn, TimeOut FROM tblEmployeeRecords LEFT OUTER JOIN tblAttendance ON tblEmployeeRecords.EmployeeID = tblAttendance.EmployeeID WHERE(tblEmployeeRecords.EmployeeID = " + thisEmployeeID + ") AND (tblAttendance.AttendanceDate = '" + thisdate + "' ) GROUP BY tblEmployeeRecords.EmployeeID, TimeIn, TimeOut, FullName, AttendanceDate ", con);
            SqlDataReader myReader;

            myReader = cmd.ExecuteReader();

            // If recordset count is zero exit and show error message. 
            if (!(myReader.FieldCount == 0 || myReader == null))
            {
                while (myReader.Read())
                {
                    txtID.Text = myReader[0].ToString();
                    txtName.Text = myReader[1].ToString();

                    //Get date from date and time.
                    string thisTimeIn = myReader[3].ToString();
                    DateTime.TryParse(thisTimeIn, out DateTime dateTime);
                    DateTime onlytime = dateTime.Date;
                    txtTimeIn.Text = onlytime.ToString("HH:mm:ss");

                }

                txtTimeOut.Text = thistime;
                txtLogInDate.Text = String.Format("dd-MM-yyyy", thisdate);

            }
            else { ErrorFound = true; }


            //Console.WriteLine(txtTimeIn);
            con.Close();
        }

        private void btnClockOut_Click(object sender, EventArgs e)
        {
            // Update the table record. AFTER USER selects the clockin btn push the update.
            // After update refresh the main page.         
            // Assign time from date & time from clock, Also, in correct format.

            if (CheckAllTheUserInput())
            {

                //Push Update
                con.Open();

                try
                {   
                    // Assign time from date & time from clock, Also, in correct format. 

                    //string thisDateFormat = String.Format("YYYY-MM-dd", txtLogInDate);
                    string thisdate = DateTime.Now.ToString("yyyy-MM-dd");
                    string thistime = DateTime.Now.ToString("HH:mm:ss");
                    int thisEmployeeID = int.Parse(txtID.Text);

                    double thisOverTime = Convert.ToDouble(txtOverTime);
                    int ApprovedBy = int.Parse(cbApprovedBy.Text);
                    bool OverTimeBool = false;
                    if (thisOverTime > 0) { OverTimeBool = true; }

                    string sqlText = "Update tblAttendance Set TimeOut = @TimeOut, Comment = @Comment, Overtime = @OverTime , OverTimeHours = @OverTimeHours, ApprovedBY = @ApprovedBY where (tblEmployeeRecords.EmployeeID = " + thisEmployeeID + ") AND (tblAttendance.AttendanceDate = '" + thisdate + "' )) ";
                    SqlCommand cmd = new SqlCommand(sqlText, con);

                    cmd.Parameters.AddWithValue("@TimeOut", thistime);
                    cmd.Parameters.AddWithValue("@Comment", txtComment.Text);
                    cmd.Parameters.AddWithValue("@OverTime", OverTimeBool);
                    cmd.Parameters.AddWithValue("@OverTimeHours", thisOverTime);
                    cmd.Parameters.AddWithValue("@ApprovedBY", ApprovedBy);
                    

                    // Execute Query
                    cmd.ExecuteNonQuery();

                    con.Close();

                    // Close this form.
                    LogOut_Close("LogIn", e);
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
                //Check State
                if (String.IsNullOrEmpty(txtTimeOut.Text)) { thisresult = false; break; }

            }

            //return result
            return thisresult;
        }

        private void cbOverTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtOverTime.Text = cbApprovedBy.SelectedItem.ToString();
        }
    }
     
}
