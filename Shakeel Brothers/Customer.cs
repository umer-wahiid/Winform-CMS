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
using static System.Windows.Forms.MonthCalendar;

namespace Shakeel_Brothers
{
    public partial class Customer : Form
    {
        Class1 c = new Class1();

        public void showgrid()
        {
            dataGridView2.DataSource = c.GetData("select tblSupplier.Id as 'ID', tblSupplier.Supplier as 'Name', tblSupplier.USupplier as 'نام', tblCity.City, tblSupplier.ContactPerson as 'Contact', tblSupplier.Address, tblSupplier.Ph as 'Phone', tblSupplier.Fax, tblSupplier.Email, tblSupplier.Limit from tblSupplier INNER JOIN tblCity ON tblSupplier.City = tblCity.ID");
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
            txtName.Text = "";
            txtUname.Text = "";
            txtCity.Text = "";
            txtAddress.Text = "";
            txtContact.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtLimit.Text = "";
            txtFax.Text = "";
        }

        public Customer()
        {
            InitializeComponent();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            showgrid();
            getitems();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try { 
                if (txtName.Text != "" && txtUname.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("insert into tblSupplier(Supplier,Usupplier,ContactPerson,Address,Ph,Fax,Email,City,Limit)values(@n,@un,@cp,@a,@p,@f,@e,@c,@l)", c.con);
                    SqlCommand cm = new SqlCommand("select ID from tblCity where City = '" + txtCity.Text + "'", c.con);
                    c.con.Open();
                    SqlDataReader dr = cm.ExecuteReader();
                    //dr.Read();
                    if (dr.Read())
                    {
                        int ids = dr.GetInt32(0);
                        cmd.Parameters.AddWithValue("@c", ids);
                        c.con.Close();
                        cmd.Parameters.AddWithValue("@n", txtName.Text);
                        cmd.Parameters.AddWithValue("@un", txtUname.Text);
                        cmd.Parameters.AddWithValue("@cp", txtContact.Text);
                        cmd.Parameters.AddWithValue("@a", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@p", txtPhone.Text);
                        cmd.Parameters.AddWithValue("@f", txtFax.Text);
                        cmd.Parameters.AddWithValue("@e", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@l", txtLimit.Text);
                        c.IUD(cmd);
                        clr();
                        showgrid();
                        txtName.Focus();
                    }
                    else
                    {
                        c.con.Close();
                        MessageBox.Show("Please Select City !!");
                    }
                }
                else
                {
                    MessageBox.Show("Please Insert Data to Save !!");
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                    clr();
                    txtName.Focus();
                    MessageBox.Show("Name Should Be Unique !!");
            }
        }

        //System.Data.SqlClient.SqlException
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTransfer.i = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            DataTransfer.n = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            DataTransfer.un = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            DataTransfer.c = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            DataTransfer.cp = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            DataTransfer.a = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            DataTransfer.p = dataGridView2.CurrentRow.Cells[6].Value.ToString();
            DataTransfer.f = dataGridView2.CurrentRow.Cells[7].Value.ToString();
            DataTransfer.e = dataGridView2.CurrentRow.Cells[8].Value.ToString();
            DataTransfer.l = dataGridView2.CurrentRow.Cells[9].Value.ToString();

            txtId.Text = DataTransfer.i;
            txtName.Text = DataTransfer.n;
            txtUname.Text = DataTransfer.un;
            txtCity.Text = DataTransfer.c;
            txtContact.Text = DataTransfer.cp;
            txtAddress.Text = DataTransfer.a;
            txtPhone.Text = DataTransfer.p;
            txtFax.Text = DataTransfer.f;
            txtEmail.Text = DataTransfer.e;
            txtLimit.Text = DataTransfer.l;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtUname.Text != "" && txtId.Text != "")
            {
                SqlCommand cmd = new SqlCommand("update tblSupplier set Supplier=@n,Usupplier=@un,ContactPerson=@cp,Address=@a,Ph=@p,Fax=@f,Email=@e,City=@c,Limit=@l where ID=@i", c.con);
                SqlCommand cm = new SqlCommand("select ID from tblCity where City = '" + txtCity.Text + "'", c.con);
                c.con.Open();
                SqlDataReader dr = cm.ExecuteReader();
                dr.Read();
                int ids = dr.GetInt32(0);
                cmd.Parameters.AddWithValue("@c", ids);
                c.con.Close();
                cmd.Parameters.AddWithValue("@i", txtId.Text);
                cmd.Parameters.AddWithValue("@n", txtName.Text);
                cmd.Parameters.AddWithValue("@un", txtUname.Text);
                cmd.Parameters.AddWithValue("@cp", txtContact.Text);
                cmd.Parameters.AddWithValue("@a", txtAddress.Text);
                cmd.Parameters.AddWithValue("@p", txtPhone.Text);
                cmd.Parameters.AddWithValue("@f", txtFax.Text);
                cmd.Parameters.AddWithValue("@e", txtEmail.Text);
                cmd.Parameters.AddWithValue("@l", txtLimit.Text);
                c.IUD(cmd);
                clr();
                showgrid();
                txtName.Focus();
            }
            else
            {
                MessageBox.Show("Please Insert Data to Update !!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                SqlCommand cmd = new SqlCommand("Delete from tblSupplier where ID=@i", c.con);
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

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            dataGridView2.DataSource = c.GetData("select tblSupplier.Id as 'ID', tblSupplier.Supplier as 'Name', tblSupplier.USupplier as 'نام', tblCity.City, tblSupplier.ContactPerson as 'Contact', tblSupplier.Address, tblSupplier.Ph as 'Phone', tblSupplier.Fax, tblSupplier.Email, tblSupplier.Limit from tblSupplier INNER JOIN tblCity ON tblSupplier.City = tblCity.ID Where tblSupplier.Supplier like '" + txtSearch.Text + "'+'%'");
        }

    }
}
