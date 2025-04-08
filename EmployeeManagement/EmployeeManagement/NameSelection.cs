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

        int thisUserID;
        String thisPassword;
        bool IsAdminUser;
        bool OpenedUserSelectedForm;
        string UserSelectedForm;

        //selected form by user to open

        public NameSelection(String thisUserSelectedForm)
        {
            InitializeComponent();
            UserSelectedForm = thisUserSelectedForm;
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HEN5LI1\SQLEXPRESS01;Initial Catalog=Employee.db;Integrated Security=True");

        private void NameSelection_Load(object sender, EventArgs e)
        {
            
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            // check if userid and password entered is not empty.
            // if record found then open whatever form the user wants and close this form.
            
            if (CheckUserIDPassword())
            {
                OpenedUserSelectedForm = false;

                //Open selected form  
                OpenSelectedForm();  
                
                if (OpenedUserSelectedForm)
                {   // close this form.
                    this.Close();
                }
            }            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // close this form.
            this.Close();
        }

        //if forms closes then open main page
        private void NameSelection_FormClosing(object sender, FormClosingEventArgs e)
        {

            //if openeing form was successful just close the form else. open main form
            if (!OpenedUserSelectedForm)
            {
                var mainform = Application.OpenForms.Cast<Form>().FirstOrDefault(f => f is Attendance);
                if (mainform != null)
                {
                    mainform.Show();
                    mainform.Refresh();
                }
            }
        }

        void OpenSelectedForm()
        {
            
            //procedd only if user & password are selected
            if ((thisUserID) != 0 && ((UserSelectedForm) != "" || (UserSelectedForm) != ""))
            {
                if (!CheckForAdminAccess()) { Console.WriteLine("Logged In User doesn't have Admin Credentials."); }
                else
                {
                    try
                    {
                        Type formType = Type.GetType($"EmployeeManagement.{UserSelectedForm}");

                        //proceed if only formname is found.
                        if (formType != null)
                        {
                            int PassUserID = thisUserID;

                            // Create an instance of the form && pass on the userid as well. 
                            Form formInstance = (Form)Activator.CreateInstance(formType, PassUserID);

                            // Show the form
                            formInstance.Show();

                            //form opened succesfully 
                            OpenedUserSelectedForm = true;

                        }
                        else { Console.WriteLine("Try Again. Error while loading page."); }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Try Again. Error while loading page." + e.Message);
                    }
                }
            }
            else { Console.WriteLine("User Id and User Password Error."); }
        }

        bool CheckForAdminAccess()
        {
            // if a form requires admin accesss. check the user login and set the bool to true if okay to open

            bool returnvalue = true;

            if (UserSelectedForm == "ChangeEmployeeStatus") //if other form reuqires admin access add here
            {
                if (!IsAdminUser) { returnvalue = false;}
            }

            return returnvalue;
        }

        bool CheckUserIDPassword()
        {
            bool returnvalue = false;
            int rowcount = 0;
            string checkuserid = txtUserID.Text;
            thisUserID = 0;
            string checkpassword = txtPassword.Text;
            thisPassword = "";

            while (true)
            {
                
                // first check for username 
                if (checkuserid != null)
                {
                    try
                    {
                        thisUserID = Convert.ToInt32(checkuserid);
                    }
                    catch { MessageBox.Show("Try Again. Enter correct UserName."); txtUserID.Focus(); break; }
                }
                else { MessageBox.Show("Try Again. Enter correct UserName."); txtUserID.Focus(); break; }


                // second check for password
                if ((checkpassword) == "" || (checkpassword) == null)
                {
                    MessageBox.Show("Try Again. password can't be empty.");
                    break;
                }
                else { thisPassword = txtPassword.Text;}


                // now check the combination in the table.
                // now check the combination in the table.
                try
                {
                    //SQL check
                    con.Open();

                    string Query = "select EmployeeID, AdminUser  from tblEmployeeRecords where (EmployeeID = @userid) AND (Password = @password) AND (CurrentEmployee = @currentemp)";
                    using (SqlCommand cmd = new SqlCommand(Query, con))
                    {
                        cmd.Parameters.AddWithValue("@userid", thisUserID);
                        cmd.Parameters.AddWithValue("@password", thisPassword);
                        cmd.Parameters.AddWithValue("@currentemp", 1);
                        
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // get adminuser record && check against null records in table
                                bool isokay = reader[1] != DBNull.Value && (bool)reader[1];
                                IsAdminUser = isokay;
                                returnvalue = true;
                                rowcount++;
                            }
                        }

                        //Now check if there was only one user
                        //if more than one there is error set to default
                        if (rowcount != 1)
                        {
                            returnvalue = false;
                            IsAdminUser = false; 
                            MessageBox.Show("Incorrect Username and password. Try Again"); 
                        } // show error as id && pass combo was incorrect

                    }
                    con.Close();
                }
                catch (Exception e) { MessageBox.Show(e.Message); con.Close(); }
                break;
            }

            return returnvalue;
        }
    }
}
