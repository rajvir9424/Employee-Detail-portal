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

namespace Details1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rajvi\source\repos\ATM\ATM\db\LoginDB.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "Select * from LogincredTable Where username= '"+ txtuser.Text.Trim()+"' and password= '"+txtpass.Text.Trim()+"' ";

            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);

            DataTable dtbl = new DataTable();

            sda.Fill(dtbl);

            if(dtbl.Rows.Count == 1)
            {
                Enter_Details entd = new Enter_Details();
                this.Hide();

                entd.Show();

            }
            else
            {
                MessageBox.Show("Incorrect Login Details, please try again");
                txtuser.Clear();
                txtpass.Clear();

               
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {

        }
    }
}
