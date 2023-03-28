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
    public partial class Item : Form
    {
        //select ID, RawName as 'Items', Packing, URawName as 'آئٹم کا نام', UPacking as 'پیکنگ', PQty as 'پیک مقدار', Measure as 'پیمانہ', PRate as 'پیک ریٹ'  from tblRawMaterial


        Class1 c = new Class1();

        public void showgrid()
        {
            dataGridView1.DataSource = c.GetData("select ID, RawName as 'Items', Packing, URawName as 'آئٹم کا نام', UPacking as 'پیکنگ', PQty as 'پیک مقدار', Measure as 'پیمانہ', PRate as 'پیک ریٹ'  from tblRawMaterial");
        }
        public void clr()
        {
            txtItem.Text = "";
            txtId.Text = "";
            txtPacking.Text = "";
            txtQty.Text = "";
            txtRate.Text = "";
            txtUitem.Text = "";
            txtUpacking.Text = "";
            txtUqty.Text = "";
        }
        private void Item_Load(object sender, EventArgs e)
        {
            showgrid();
        }

        public Item()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (txtItem.Text != "" && txtPacking.Text != "" && txtUitem.Text != "" && txtUpacking.Text != ""&& txtId.Text == "")
            {
                SqlCommand cmd = new SqlCommand("insert into tblRawMaterial(RawName,URawName,Packing,UPacking,PQty,Measure,PRate)values(@n,@un,@p,@up,@c,@m,@r)", c.con);
                cmd.Parameters.AddWithValue("@n", txtItem.Text);
                cmd.Parameters.AddWithValue("@un", txtUitem.Text);
                cmd.Parameters.AddWithValue("@p", txtPacking.Text);
                cmd.Parameters.AddWithValue("@up", txtUpacking.Text);
                cmd.Parameters.AddWithValue("@c", txtQty.Text);
                cmd.Parameters.AddWithValue("@m", txtUqty.Text);
                cmd.Parameters.AddWithValue("@r", txtRate.Text);
                c.IUD(cmd);
                clr();
                showgrid();
                txtItem.Focus();
            }
            else
            {
                MessageBox.Show("Please Insert Data to Save !!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtItem.Text != "" && txtPacking.Text != "" && txtUitem.Text != "" && txtUpacking.Text != "" && txtRate.Text != "" && txtId.Text != "")
            {
                SqlCommand cmd = new SqlCommand("update tblRawMaterial set RawName=@n,URawName=@un,Packing=@p,UPacking=@up,PQty=@c,Measure=@m,PRate=@r  where ID=@i", c.con);
                cmd.Parameters.AddWithValue("@i", txtId.Text);
                cmd.Parameters.AddWithValue("@n", txtItem.Text);
                cmd.Parameters.AddWithValue("@un", txtUitem.Text);
                cmd.Parameters.AddWithValue("@p", txtPacking.Text);
                cmd.Parameters.AddWithValue("@up", txtUpacking.Text);
                cmd.Parameters.AddWithValue("@c", txtQty.Text);
                cmd.Parameters.AddWithValue("@m", txtUqty.Text);
                cmd.Parameters.AddWithValue("@r", txtRate.Text);
                c.IUD(cmd);
                clr();
                showgrid();
                txtItem.Focus();
            }
            else
            {
                MessageBox.Show("Please Insert Data to Update !!");
            }
        }


        private void btnDel_Click(object sender, EventArgs e)
        {
            if (txtRate.Text != "")
            {
                SqlCommand cmd = new SqlCommand("Delete from tblRawMaterial where ID=@i", c.con);
                cmd.Parameters.AddWithValue("@i", txtRate.Text);
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
            dataGridView1.DataSource = c.GetData("select ID, RawName as 'Items', Packing, URawName as 'آئٹم کا نام', UPacking as 'پیکنگ', PQty as 'پیک مقدار', Measure as 'پیمانہ', PRate as 'پیک ریٹ'  from tblRawMaterial Where RawName like '" + txtSearch.Text + "'+'%'");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTransfer.i = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            DataTransfer.n = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            DataTransfer.p = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            DataTransfer.un = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            DataTransfer.up = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            DataTransfer.c = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            DataTransfer.m = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            DataTransfer.r = dataGridView1.CurrentRow.Cells[7].Value.ToString();

            txtId.Text = DataTransfer.i;
            txtItem.Text = DataTransfer.n;
            txtUitem.Text = DataTransfer.un;
            txtPacking.Text = DataTransfer.p;
            txtUpacking.Text = DataTransfer.up;
            txtQty.Text = DataTransfer.c;
            txtUqty.Text = DataTransfer.m;
            txtRate.Text = DataTransfer.r;
        }



















        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
        }
        private void Item_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
        }
        private void label6_Click(object sender, EventArgs e)
        {
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }

    }
}
