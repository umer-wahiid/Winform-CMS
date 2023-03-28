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

namespace Shakeel_Brothers
{
    public partial class Transport : Form
    {
        Class1 c = new Class1();

        public void showgrid()
        {
            dataGridView1.DataSource = c.GetData("select ID ,Transport,UTransport as 'ٹرانسپورٹ',[Tport Ph] as 'Phone No.'  from tblTransport");
        }
        public void clr()
        {
            txtId.Text = "";
            txtTransport.Text = "";
            txtUtransport.Text = "";
            txtPhone.Text = "";
        }


        public Transport()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Transport_Load(object sender, EventArgs e)
        {
            showgrid();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();

        }



        private void button1_Click_2(object sender, EventArgs e)
        {
            if (txtTransport.Text != "" && txtUtransport.Text != "")
            {
                SqlCommand cmd = new SqlCommand("insert into tblTransport(Transport,UTransport,[Tport Ph])values(@c,@p,@r)", c.con);
                cmd.Parameters.AddWithValue("@c", txtTransport.Text);
                cmd.Parameters.AddWithValue("@p", txtUtransport.Text);
                cmd.Parameters.AddWithValue("@r", txtPhone.Text);
                c.IUD(cmd);
                clr();
                showgrid();
                txtTransport.Focus();
            }
            else
            {
                MessageBox.Show("Please Insert Data to Save !!");
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtTransport.Text != "" && txtUtransport.Text != "" && txtId.Text != "")
            {
                SqlCommand cmd = new SqlCommand("update tblTransport set Transport=@c ,UTransport=@p,[Tport Ph]=@r where ID=@i", c.con);
                cmd.Parameters.AddWithValue("@i", txtId.Text);
                cmd.Parameters.AddWithValue("@c", txtTransport.Text);
                cmd.Parameters.AddWithValue("@p", txtUtransport.Text);
                cmd.Parameters.AddWithValue("@r", txtPhone.Text);
                c.IUD(cmd);
                clr();
                showgrid();
                txtTransport.Focus();
            }
            else
            {
                MessageBox.Show("Please Insert Data to Update !!");
            }
        }



        private void btnDel_Click_1(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                SqlCommand cmd = new SqlCommand("Delete from tblTransport where ID=@i", c.con);
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



        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = c.GetData("select ID ,Transport,UTransport as 'ٹرانسپورٹ',[Tport Ph] as 'Phone No.'  from tblTransport Where Transport like '" + txtSearch.Text + "'+'%'");
        }



        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataTransfer.i = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            DataTransfer.c = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            DataTransfer.p = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            DataTransfer.r = dataGridView1.CurrentRow.Cells[3].Value.ToString();

            txtId.Text = DataTransfer.i;
            txtTransport.Text = DataTransfer.c;
            txtUtransport.Text = DataTransfer.p;
            txtPhone.Text = DataTransfer.r;
        }















        private void update_Click(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
        }
        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
        }


        private void button1_Click_1(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {

        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }



        private void btnDel_Click(object sender, EventArgs e)
        {

        }

    }
}
