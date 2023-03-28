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

namespace Shakeel_Brothers
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1 c = new Class1();
            SqlCommand cmd = new SqlCommand("Select * from tblCashier where Cashier=@c and Password=@p",c.con);
            cmd.Parameters.AddWithValue("@c",textBox1.Text);
            cmd.Parameters.AddWithValue("@p", textBox2.Text);
            SqlCommand cmdd = new SqlCommand("select Role from tblCashier where Cashier = '" + textBox1.Text + "'", c.con);
            c.con.Open();
            SqlDataReader drr = cmd.ExecuteReader();
            drr.Read();
            try
            {
                string ids = drr.GetString(3);
            c.con.Close();
            c.con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                        DataTransfer.role = ids;
                        DataTransfer.user = textBox1.Text;

                        Startup s = new Startup();
                        s.Show();
                        this.Hide();


                    //(dr["Role"].ToString() == "admin")
                    //{
                        //DataTransfer.role = ids;
                        //DataTransfer.user = textBox1.Text;


                        //Startup s = new Startup();
                        //s.Show();
                        //this.Hide();
                    //}
                    //else
                    //{
                    //    this.Close();
                    //}
                }
            }
            else
            {
                MessageBox.Show("Wrong Password");
            }
            c.con.Close();
            }
            catch(System.InvalidOperationException ex)
            {
                MessageBox.Show("Please Write Password !!");
            }
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            bool check = checkBox1.Checked;

            switch (check)
            {
                case true:
                    textBox2.UseSystemPasswordChar = false;
                    break;
                default:
                    textBox2.UseSystemPasswordChar = true;
                    break;
            }
        }
    }
}
