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
using System.Diagnostics;

namespace studentInfoManagement
{
    public partial class FormSignUp : Form
    {
        string ConStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentInfo;Integrated Security=True";
        SqlConnection con;
        public static string username = "";
        public static string password = "";
        public FormSignUp()
        {
            InitializeComponent();
            con = new SqlConnection(ConStr);
        }



        private void button2_Click(object sender, EventArgs e)
        {
            CreateUser createUser = new CreateUser();
            
            createUser.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please enter User Name and Password ");
                return;
            }
            else
            {
              

                SqlConnection con = new SqlConnection(ConStr);
                SqlDataAdapter cmd = new SqlDataAdapter("select firstName , lastName , contact , gender , addresss from [dbo].[StudentInfo] where userName = @username and password = @password", con);
                cmd.SelectCommand.Parameters.AddWithValue("@username", textBox1.Text);
                cmd.SelectCommand.Parameters.AddWithValue("@password", textBox2.Text);

                DataTable student = new DataTable();

                cmd.Fill(student);
                studentInfo.DataSource = student;




               /* con.Open();
                     SqlDataAdapter adapter = new SqlDataAdapter();
                     
                     adapter.Fill(ds);
                     username = textBox1.Text;
                     password = textBox2.Text;
                     con.Close();

                     int count = ds.Tables[0].Rows.Count;

                     if (count == 1)
                     {
                         MessageBox.Show("Login Successful");
                         this.Hide();

                         UserDetails userDetails = new UserDetails();
                         userDetails.ShowDialog();*/

                     }


            }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConStr);
            SqlDataAdapter cmd = new SqlDataAdapter("select firstName , lastName , contact , gender , addresss from [dbo].[StudentInfo] where activeFlag = 1", con);

            DataTable student = new DataTable();

            cmd.Fill(student);
            studentInfo.DataSource = student;
        }
    }
    }


