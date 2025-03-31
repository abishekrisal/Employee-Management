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

namespace EmployeeManagement
{

    public partial class Attendance : Form
    {
        public static String thisSelectedValue;
        public static Char thisSelectedForm;

        public Attendance()
        {
            InitializeComponent();
        }

        //Function to refresh after the data is updatted.
        //Refresh the main attendance page. 
        public void RefreshMainPageData()
        {
            LoadAttendanceData();
            this.Refresh();
        }
        // refresh the form function till here.


        // data connection to the SSMS
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HEN5LI1\SQLEXPRESS01;Initial Catalog=Employee.db;Integrated Security=True");
        

        private void Attendance_Load(object sender, EventArgs e)
        {
            LoadAttendanceData();
        }

        void LoadAttendanceData()
        {
            con.Open();

            dataGridView1.DataSource = null;
            SqlCommand conn = new SqlCommand("SELECT tblEmployeeRecords.EmployeeID as ID, FullName, MAX(AttendanceDate) AS LatestAttendanceDate, TimeIn, [Timeout] FROM   tblEmployeeRecords LEFT OUTER JOIN tblAttendance ON tblEmployeeRecords.EmployeeID = tblAttendance.EmployeeID WHERE (tblEmployeeRecords.CurrentEmployee = 1) Group by tblEmployeeRecords.EmployeeID, FullName , TimeIn, [Timeout] order by FullName", con);
            SqlDataAdapter da = new SqlDataAdapter(conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();

        }

        private void btnLogIn1_Click(object sender, EventArgs e)
        {
            thisSelectedValue = "";
            thisSelectedForm = 'I';

            //STEP1: Open Selection Page
            NameSelection thisform = new NameSelection();
            thisform.Show();

        }

        private void btnLogOut1_Click(object sender, EventArgs e)
        {
            thisSelectedValue = "";
            thisSelectedForm = 'O';

            //STEP2: Open selection page
            NameSelection thisform = new NameSelection();
            thisform.Show();

        }

        private void pbRefresh_Click(object sender, EventArgs e)
        {
            LoadAttendanceData();
        }
    }
}
