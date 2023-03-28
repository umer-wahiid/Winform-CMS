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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Shakeel_Brothers
{

    public partial class Cashier : Form
    {
        //SqlDataAdapter adap;
        //DataTable dt;
        Class1 c = new Class1();
        public void showgrid()
        {
            dataGridView1.DataSource = c.GetData("select * from tblCashier");
        }
        public void clr()
        {
            txtId.Text = "";
            txtCashier.Text = "";
            txtPassword.Text = "";
            txtRole.Text = "";
        }

        public Cashier()
        {
            InitializeComponent();
        }

        private void Cashier_Load(object sender, EventArgs e)
        {
            txtCashier.Focus();
            showgrid();
        }

        private void update_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            if (txtCashier.Text != "" && txtPassword.Text != "" && txtRole.Text!="")
            {
                SqlCommand cmd = new SqlCommand("insert into tblCashier(Cashier,Password,Role)values(@c,@p,@r)", c.con);
                cmd.Parameters.AddWithValue("@c", txtCashier.Text);
                cmd.Parameters.AddWithValue("@p", txtPassword.Text);
                cmd.Parameters.AddWithValue("@r", txtRole.Text);
                c.IUD(cmd);
                clr();
                showgrid();
                txtCashier.Focus();
            }
            else
            {
                MessageBox.Show("Please Insert Data to Save !!");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (txtCashier.Text != "" && txtPassword.Text != "" && txtRole.Text != "" && txtId.Text != "")
            {
                SqlCommand cmd = new SqlCommand("update tblCashier set Cashier=@c ,Password=@p,Role=@r where ID=@i", c.con);
                cmd.Parameters.AddWithValue("@i", txtId.Text);
                cmd.Parameters.AddWithValue("@c", txtCashier.Text);
                cmd.Parameters.AddWithValue("@p", txtPassword.Text);
                cmd.Parameters.AddWithValue("@r", txtRole.Text);
                c.IUD(cmd);
                clr();
                showgrid();
                txtCashier.Focus();
            }
            else
            {
                MessageBox.Show("Please Insert Data to Update !!");
            }
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTransfer.i = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            DataTransfer.c = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            DataTransfer.p = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            DataTransfer.r = dataGridView1.CurrentRow.Cells[3].Value.ToString();

            txtId.Text = DataTransfer.i;
            txtCashier.Text = DataTransfer.c;
            txtPassword.Text = DataTransfer.p;
            txtRole.Text = DataTransfer.r;
        }



        private void btnDel_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                SqlCommand cmd = new SqlCommand("Delete from tblCashier where ID=@i", c.con);
                cmd.Parameters.AddWithValue("@i", txtId.Text);
                c.IUD(cmd);
                clr();
                showgrid();
            }
            else
            {
                MessageBox.Show("Select Data Before Delete !!");
            }
        }



        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = c.GetData("select * from tblCashier Where Cashier like '" + txtSearch.Text + "'+'%'");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void txtSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
        }

    }
}
