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

namespace studentInfoManagement
{
    public partial class CreateUser : Form
    {
        string ConStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentInfo;Integrated Security=True";

        public CreateUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection(ConStr);
            string query = @"INSERT INTO [dbo].[StudentInfo]
           ([userName]
           ,[password]
           ,[firstName]
           ,[lastName]
           ,[contact]
           ,[gender]
           ,[addresss]
           ,[lstUpdtDt]
           ,[activeFlag])
     VALUES
           ('"+textBox3.Text+"' , '"+textBox4.Text+"' , '"+textBox1.Text+"' , '"+textBox2.Text+"' , '"+textBox5.Text+"' , '"+textBox6.Text+"' , '"+textBox7.Text+ "' , GETDATE(),1)";

            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Student Registered Successfully!");
            con.Close();

            FormSignUp formSignUp = new FormSignUp();
            formSignUp.ShowDialog();


        }
    }
}
