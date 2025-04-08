using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagement
{
    public partial class EmployeeRecord : Form
    {
        int thisEmployeeID;
        public EmployeeRecord(int NewEmployeeID)
        {
            InitializeComponent();
            thisEmployeeID = NewEmployeeID;
        }

        public bool IsNewEmployee { get; set; }


        // data connection to the SSMS
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HEN5LI1\SQLEXPRESS01;Initial Catalog=Employee.db;Integrated Security=True");


        private void EmployeeRecord_Load(object sender, EventArgs e)
        {
            //If new employee add then perform differet action 
            // if looking at employee record then get info from table and display.


            if (IsNewEmployee)
            {
                txtID.Text = thisEmployeeID.ToString();
            }
            else
            { FillForm(); }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if form is open//close it // reopen later
            foreach (Form form in Application.OpenForms)
            {
                if (form is Attendance && !form.Visible) // Replace "Form2" with your form's actual name
                {
                    form.Show();
                }
            }
        }

        private void btnSaveRecord_Click(object sender, EventArgs e)
        {
            // Step1: Check if all the records are correct.
            // Step2: Ask for confirmation from User.
            // Step3: Update the table.

            //Step1
            if (CheckAllTheUserInput())
            {
                //Step2: User Confirmation
                DialogResult dialogResult = MessageBox.Show("Is it Okay to update the Employee Record ? ", "Update Employee Records.", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //Update the table.

                    //IF update is succesful 
                    //Update message and close form.

                     this.Close();


                }
            }
        }

        // Check if all the entries are made and nothing is null or empty.
        bool CheckAllTheUserInput()
        {
            bool thisresult = true;

            while (true)
            {
                //Check EmployeeID
                if (String.IsNullOrEmpty(txtID.Text)) { thisresult = false; break; }
                //Check FirstName
                if (String.IsNullOrEmpty(txtFirstName.Text)) { thisresult = false; break; }
                //Check LastName
                if (String.IsNullOrEmpty(txtLastName.Text)) { thisresult = false; break; }
                //Check ContactNumber
                if (String.IsNullOrEmpty(txtContactNumber.Text)) { thisresult = false; break; }
                //Check Email
                if (String.IsNullOrEmpty(txtEmail.Text)) { thisresult = false; break; }
                //Check addressline1
                if (String.IsNullOrEmpty(txtAddress1.Text)) { thisresult = false; break; }
                //Check Suburb
                if (String.IsNullOrEmpty(txtSuburb.Text)) { thisresult = false; break; }
                //Check PostCode
                if (String.IsNullOrEmpty(txtPostCode.Text)) { thisresult = false; break; }
                //Check State
                if (String.IsNullOrEmpty(txtState.Text)) { thisresult = false; break; }
                //Check Name of emergency contact
                if (String.IsNullOrEmpty(txtEmergencyContactName.Text)) { thisresult = false; break; }
                //Check State
                if (String.IsNullOrEmpty(txtEmergencyContactRelation.Text)) { thisresult = false; break; }
                //Check State
                if (String.IsNullOrEmpty(txtEmergencyContactNumber.Text)) { thisresult = false; break; }
                //Check State
                if (String.IsNullOrEmpty(txtEmergencyContactAddress.Text)) { thisresult = false; break; }
                //Check State
                //if (String.IsNullOrEmpty(txtDepartment.Text)) { thisresult = false; break; }
                //Check State
                //if (String.IsNullOrEmpty(txtEmployeePosition.Text)) { thisresult = false; break; }
                //Check State
               // if (String.IsNullOrEmpty(txtStartDate.Text)) { thisresult = false; break; }

            }

            //return result
            return thisresult;
        }

        // fill the employee form
        void FillForm()
        {
            // get data using employeeID and fill the form. 
            try
            {
                con.Open();

                string query = "SELECT * From tblEmployeeRecords where EmployeeID = " + thisEmployeeID + " ";

                using (SqlCommand cmd = new SqlCommand(query, con))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        txtFirstName.Text = reader[2].ToString();
                        txtLastName.Text = reader[3].ToString();
                        txtContactNumber.Text = reader[5].ToString();
                        txtEmail.Text = reader[6].ToString();
                        txtAddress1.Text = reader[7].ToString(); 
                        txtAddress2.Text = reader[8].ToString();   
                        txtSuburb.Text = reader[9].ToString();
                        txtPostCode.Text = reader[10].ToString();
                        txtState.Text = reader[11].ToString();
                        txtEmergencyContactName.Text = reader[12].ToString();  
                        txtEmergencyContactNumber.Text = reader[13].ToString();
                        txtEmergencyContactAddress.Text = reader[14].ToString();
                        txtEmergencyContactRelation.Text = reader[15].ToString();
                        //txtDepartment.Text = reader[19].ToString();
                    }
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); con.Close();
            }


        }
    }
}
