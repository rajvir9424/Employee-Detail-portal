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
using System.IO;
using System.Globalization;

namespace Details1
{
    public partial class Enter_Details : Form
    {
        public Enter_Details()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rajvi\source\repos\ATM\ATM\db\LoginDB.mdf;Integrated Security=True;Connect Timeout=30");


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btninset_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText=  "Insert into employeedetail_Table values ('"+txtid.Text+"','"+txtname.Text+"','"+txtsurname.Text+"','"+txtdob.Text+"','"+txtaddress.Text+"')";
            cmd.ExecuteNonQuery();
            con.Close();
            display_data();

            MessageBox.Show("Data inserted successfully");

            txtname.Clear();
            txtsurname.Clear();
            txtid.Clear();
            txtaddress.Clear();
            txtdob.Clear();



        }

        private void display_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from employeedetail_Table";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            dataGridView1.DataSource = dt;

            

            con.Close();
        }

        private void Enter_Details_Load(object sender, EventArgs e)
        {
            display_data();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from employeedetail_Table where id= '" + this.txtid.Text+ "'";
            cmd.ExecuteNonQuery();
            con.Close();
            display_data();

            MessageBox.Show("Record deleted successfully");

            txtid.Clear();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {

            con.Open();
            string Query = "update employeedetail_Table set name= '" + txtname.Text + "',surname= '" + txtsurname.Text + "',dob='" + txtdob.Text + "',address='" + txtaddress.Text + "' where id= '" + txtid.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            sda.SelectCommand.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Record Updated Successfully");

            txtname.Clear();
            txtsurname.Clear();
            txtid.Clear();
            txtdob.Clear();
            txtaddress.Clear();

            display_data();

           










        }

        private void btndisplay_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from employeedetail_Table";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            dataGridView1.DataSource = dt;



            con.Close();

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from employeedetail_Table where name = '"+txtsearch.Text+"'";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            dataGridView1.DataSource = dt;
            con.Close();

            txtsearch.Clear();

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            TextWriter writer = new StreamWriter(@"C:\Users\rajvi\Desktop\Text.txt");

            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                writer.WriteLine("ID                Name                   Surname                      DOB                      Address");
                for (int j = 0; j <dataGridView1.Columns.Count; j++)
                {
                   
                    writer.Write("\t" + dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t" + "|");
                }

                writer.WriteLine("");
                writer.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------");


            }
            writer.Close();
            MessageBox.Show("Data saved successfully");

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
