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
    public partial class Area : Form
    {
        SqlDataAdapter adap;
        DataTable dt;
        DataSet rd;

        Class1 c = new Class1();

        public void showgrid()
        {
            dataGridView2.DataSource = c.GetData("select tblArea.ID, tblArea.Area ,tblArea.UArea as 'علاقہ' ,tblCity.City,tblCity.UCity as 'شہر' from tblArea INNER JOIN tblCity ON tblArea.CityId = tblCity.ID");
            //dataGridView1.DataSource = c.GetData("select tblArea.ID, tblArea.Area ,tblArea.UArea as 'علاقہ' ,tblCity.City,tblCity.UCity as 'شہر' from tblArea INNER JOIN tblCity ON tblArea.City = tblCity.ID");
        }

        public void getitems()
        {
            SqlCommand cmd = new SqlCommand("select City from tblCity", c.con);
            c.con.Open();
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string cities = dr.GetString(0);
                coll.Add(cities);
                txtCity.Items.Add(cities);
            }
            txtCity.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtCity.AutoCompleteMode = AutoCompleteMode.Append;
            txtCity.AutoCompleteCustomSource = coll;
            c.con.Close();
        }

        public void clr()
        {
            txtId.Text = "";
            txtArea.Text = "";
            txtUarea.Text = "";
            txtCity.Text = "";
        }

        public Area()
        {
            InitializeComponent();
        }

        private void Area_Load_1(object sender, EventArgs e)
        {
            showgrid();
            getitems();
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtArea.Text != "" && txtUarea.Text != "" && txtCity.Text != "")
            {
                SqlCommand cmd = new SqlCommand("insert into tblArea(Area,UArea,CityId)values(@r,@p,@c)", c.con);
                SqlCommand cm = new SqlCommand("select ID from tblCity where City = '" + txtCity.Text + "'", c.con);
                c.con.Open();
                SqlDataReader dr = cm.ExecuteReader();
                dr.Read();
                int ids = dr.GetInt32(0);
                cmd.Parameters.AddWithValue("@c", ids);
                c.con.Close();
                cmd.Parameters.AddWithValue("@r", txtArea.Text);
                cmd.Parameters.AddWithValue("@p", txtUarea.Text);
                c.IUD(cmd);
                clr();
                showgrid();
                txtArea.Focus();
            }
            else
            {
                MessageBox.Show("Please Insert Data to Save !!");
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (txtArea.Text != "" && txtUarea.Text != "" && txtCity.Text != "" && txtId.Text != "")
            {
                SqlCommand cmd = new SqlCommand("update tblArea set Area=@r ,UArea=@p,CityId=@c where ID=@i", c.con);
                SqlCommand cm = new SqlCommand("select ID from tblCity where City = '" + txtCity.Text + "'", c.con);
                c.con.Open();
                SqlDataReader dr = cm.ExecuteReader();
                dr.Read();
                int ids = dr.GetInt32(0);
                cmd.Parameters.AddWithValue("@c", ids);
                c.con.Close();
                cmd.Parameters.AddWithValue("@i", txtId.Text);
                cmd.Parameters.AddWithValue("@r", txtArea.Text);
                cmd.Parameters.AddWithValue("@p", txtUarea.Text);
                c.IUD(cmd);
                clr();
                showgrid();
                txtArea.Focus();
            }
            else
            {
                MessageBox.Show("Please Insert Data to Update !!");
            }
        }
        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            dataGridView2.DataSource = c.GetData("select tblArea.ID, tblArea.Area ,tblArea.UArea as 'علاقہ' ,tblCity.City,tblCity.UCity as 'شہر' from tblArea INNER JOIN tblCity ON tblArea.CityId = tblCity.ID Where tblArea.Area like '" + txtSearch.Text + "'+'%'");
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTransfer.i = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            DataTransfer.r = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            DataTransfer.p = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            DataTransfer.c = dataGridView2.CurrentRow.Cells[3].Value.ToString();

            txtId.Text = DataTransfer.i;
            txtArea.Text = DataTransfer.r;
            txtUarea.Text = DataTransfer.p;
            txtCity.Text = DataTransfer.c;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                SqlCommand cmd = new SqlCommand("Delete from tblArea where ID=@i", c.con);
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

























        private void Area_Load(object sender, EventArgs e)
        {
            //adap = new SqlDataAdapter("select ID ,Area ,UArea as 'علاقہ' ,City , UCity as 'شہر' from tblArea", c.con);
            //adap = new SqlDataAdapter("select tblArea.ID, tblArea.Area ,tblArea.UArea,tblArea.CityId,tblCity.City from tblArea INNER JOIN tblCity ON tblArea.CityId = tblCity.ID", c.con);
            //dt = new DataTable();
            //adap.Fill(dt);
            //dataGridView1.DataSource = dt;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cm = new SqlCommand("select ID from tblCity where City = '" + txtCity + "'", c.con);
            DataTransfer.c = cm.ToString();
        }

        private void Area_FormClosing(object sender, FormClosingEventArgs e)
        {
            //SqlCommandBuilder cmbdl = new SqlCommandBuilder(adap);
            //adap.Update(dt);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SqlCommandBuilder cmbdl = new SqlCommandBuilder(adap);
            //adap.Update(dt);
            //this.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
