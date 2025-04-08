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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EmployeeManagement
{
    public partial class LogOut : Form
    {
        int thisEmployeeID;

        public LogOut(int passedonuserid)
        {
            InitializeComponent();
            thisEmployeeID = passedonuserid;

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
                MessageBox.Show("No LogIn Records found. Only LoggedIn Staff can LogOut.");

                this.Close();
            }
        }

        private void LogOut_FormClosing(object sender, FormClosingEventArgs e)
        {
            var mainform = Application.OpenForms.Cast<Form>().FirstOrDefault(f => f is Attendance);
            if (mainform != null)
            {
                mainform.Show();
                mainform.Refresh();
            }
        }

        private void btnClockOut_Click(object sender, EventArgs e)
        {
            // Update the table record. AFTER USER selects the clockin btn push the update.
            // After update refresh the main page.         
            // Assign time from date & time from clock, Also, in correct format.

            if (CheckAllTheUserInput())
            {
                try
                {

                    //Push Update
                    con.Open();

                    // Assign time from date & time from clock, Also, in correct format. 

                    //string thisDateFormat = String.Format("YYYY-MM-dd", txtLogInDate);
                    string thisdate = DateTime.Now.ToString("yyyy-MM-dd");
                    string thistime = DateTime.Now.ToString("HH:mm:ss");
                    int thisEmployeeID = int.Parse(txtID.Text);
                    double thisOverTime = 0;
                    int ApprovedBy = 0;
                    bool OverTimeBool = chkOverTime.Checked;

                    //Although the user may have overtime && approved by record it will check against chkbox.
                    if (OverTimeBool)
                    {
                        thisOverTime = Convert.ToDouble(txtOverTime);
                        ApprovedBy = int.Parse(cbApprovedBy.Text);
                    }

                    string sqlText = "Update tblAttendance Set TimeOut = @TimeOut, Comment = @Comment, Overtime = @OverTime , OverTimeHours = @OverTimeHours, ApprovedBY = @ApprovedBY where (tblAttendance.EmployeeID = " + thisEmployeeID + ") AND (tblAttendance.AttendanceDate = '" + thisdate + "' ) ";
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
                    this.Close();
                }
                catch (Exception ae) { MessageBox.Show("No LogIn Records found. Only LoggedIn Staff can LogOut." + ae.Message); con.Close(); }

            }
        }


        void LogOut_Close(object sender, EventArgs e)
        {
            // refresh and close the form.
            Attendance attendance = new Attendance();
            attendance.Show();

            this.Close();
        }


        void FillForm()
        {
            try
            {
                // Get DATE & TIME TO DISPLAY IN FORM.
                string thisdate = DateTime.Now.ToString("yyyy-MM-dd");


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

                        //DateTime.TryParse(thisTimeIn, out DateTime dateTime);
                        //DateTime onlytime = dateTime.Date;
                        txtTimeIn.Text = thisTimeIn.ToString();

                    }

                    txtTimeOut.Text = DateTime.Now.ToString("HH:mm:ss");
                    txtLogInDate.Text = String.Format("dd-MM-yyyy", thisdate);

                }
                else { ErrorFound = true; }


                //Console.WriteLine(txtTimeIn);
                con.Close();

            } catch { con.Close(); ErrorFound = true; }
        }

        void LoadAdminUser()
        {
            try
            {
                con.Open();

                string query = "SELECT FullName, EmployeeID From tblEmployeeRecords where AdminUser = 1 ";
                using (SqlCommand cmd = new SqlCommand(query, con))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cbApprovedBy.Items.Add(reader["FullName"].ToString());
                    }
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); con.Close();
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

                break;
            }

            //return result
            return thisresult;
        }

        private void chkOverTime_CheckedChanged(object sender, EventArgs e)
        {
            bool thisovertime = chkOverTime.Checked;
            if (thisovertime)
            {
                txtOverTime.ReadOnly = false;
                cbApprovedBy.Enabled = true;

                //Load Admin USer for selection
                LoadAdminUser();
            }
            else
            {
                txtOverTime.ReadOnly = true;
                cbApprovedBy.Enabled = false;
            }
        }
    }
}
    
