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
using System.Xml.Linq;

namespace Shakeel_Brothers
{
    public partial class Payments : Form
    {

        Class1 c = new Class1();

        public void txtid()
        {
            SqlCommand cmd = new SqlCommand("select Top 1 TID from tblTransactions ORDER BY TID DESC", c.con);
            c.con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                int ids = dr.GetInt32(0);
                c.con.Close();
                txtID.Text += ids + 1;
            }
            else
            {
                int ids = 0;
                c.con.Close();
                txtID.Text += ids + 1;
            }
        }

        public void clr()
        {
            txtID.Text = "";
            txtid();
            txtDate.Text = "";
            txtAmount.Text = "";
            txtAcc.Text = "";
        }


        public void getAcc()
        {
            SqlCommand cmd = new SqlCommand("select DISTINCT Description from tblTransactions", c.con);
            c.con.Open();
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string acc = dr.GetString(0);
                coll.Add(acc);
                txtAcc.Items.Add(acc);
            }
            txtAcc.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtAcc.AutoCompleteMode = AutoCompleteMode.Append;
            txtAcc.AutoCompleteCustomSource = coll;
            c.con.Close();
        }


        public void showgrid()
        {
            dataGridView1.DataSource = c.GetData("select tblTransactions.TID as 'ID',tblTransactions.TDate as 'Date',tblSupplier.Supplier as 'Customer',tblTransactions.Debit,tblTransactions.Description as 'تفصیل' from tblTransactions  INNER JOIN tblSupplier ON tblTransactions.Supplier = tblSupplier.Id where tblTransactions.Supplier = " + DataTransfer.cusId + "  AND tblTransactions.Debit != '' ");
        }















        public Payments()
        {
            InitializeComponent();
        }

        private void Payments_Load(object sender, EventArgs e)
        {
            showgrid();
            txtid();
            getAcc();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDate.Text != "" && txtAmount.Text != "" && txtAcc.Text != "")
            {
                SqlCommand cmd = new SqlCommand("insert into tblTransactions(TID,TDate,Supplier,Debit,Description)values(@tid,@d," + DataTransfer.cusId + ",@db,@ds)", c.con);
                cmd.Parameters.AddWithValue("@tid", txtID.Text);
                cmd.Parameters.AddWithValue("@d", Convert.ToDateTime(txtDate.Text));
                cmd.Parameters.AddWithValue("@db", txtAmount.Text);
                cmd.Parameters.AddWithValue("@ds", txtAcc.Text);
                c.IUD(cmd);
                clr();
                showgrid();
                getAcc();
                txtDate.Focus();
            }
            else
            {
                MessageBox.Show("Please Insert Data to Save !!");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtDate.Text != "" && txtAmount.Text != "" && txtAcc.Text != "")
            {
                SqlCommand cmd = new SqlCommand("Update tblTransactions Set TDate=@d,Debit=@db,Description=@ds where TID = @id", c.con);
                cmd.Parameters.AddWithValue("@id", txtTID.Text);
                cmd.Parameters.AddWithValue("@d", Convert.ToDateTime(txtDate.Text));
                cmd.Parameters.AddWithValue("@db", txtAmount.Text);
                cmd.Parameters.AddWithValue("@ds", txtAcc.Text);
                c.IUD(cmd);
                clr();
                showgrid();
                getAcc();
                txtDate.Focus();
            }
            else
            {
                MessageBox.Show("Please Insert Data to Save !!");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTransfer.id = dataGridView1.CurrentRow.Cells[0].Value.ToString();   
            DataTransfer.d = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            DataTransfer.db = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            DataTransfer.ds = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            txtTID.Text = DataTransfer.id;
            txtDate.Text = DataTransfer.d;
            txtAmount.Text = DataTransfer.db;
            txtAcc.Text = DataTransfer.ds;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtTID.Text != "")
            {
                SqlCommand cmd = new SqlCommand("Delete from tblTransactions where TID=@id", c.con);
                cmd.Parameters.AddWithValue("@id", txtTID.Text);
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
            dataGridView1.DataSource = c.GetData("select tblTransactions.TID as 'ID',tblTransactions.TDate as 'Date',tblSupplier.Supplier as 'Customer',tblTransactions.Debit,tblTransactions.Description as 'تفصیل' from tblTransactions  INNER JOIN tblSupplier ON tblTransactions.Supplier = tblSupplier.Id where tblTransactions.Supplier = " + DataTransfer.cusId + "  AND tblTransactions.Debit != '' AND  tblTransactions.Description like '" + txtSearch.Text + "'+'%'");        }
    }
}
