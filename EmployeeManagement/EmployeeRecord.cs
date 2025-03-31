using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagement
{
    public partial class EmployeeRecord : Form
    {
        public EmployeeRecord()
        {
            InitializeComponent();
        }

        private void EmployeeRecord_Load(object sender, EventArgs e)
        {
            //If new employee add then perform differet action 
            // if looking at employee record then get info from table and display.


        }

        private void btnExit_Click(object sender, EventArgs e)
        { 
            //Close the form.
            EmployeeRecord thisform = new EmployeeRecord();
            thisform.Close();
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
                if (String.IsNullOrEmpty(txtDepartment.Text)) { thisresult = false; break; }
                //Check State
                if (String.IsNullOrEmpty(txtEmployeePosition.Text)) { thisresult = false; break; }
                //Check State
                if (String.IsNullOrEmpty(txtStartDate.Text)) { thisresult = false; break; }

            }

            //return result
            return thisresult;
        }

    }
}
