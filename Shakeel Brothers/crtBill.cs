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

namespace Shakeel_Brothers
{
    public partial class crtBill : Form
    {
        Class1 c = new Class1();


        public void getitems()
        {
            SqlCommand cmd = new SqlCommand("select Supplier from tblSupplier", c.con);
            c.con.Open();
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string customer = dr.GetString(0);
                coll.Add(customer);
                txtCustomer.Items.Add(customer);
            }
            txtCustomer.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtCustomer.AutoCompleteMode = AutoCompleteMode.Append;
            txtCustomer.AutoCompleteCustomSource = coll;
            c.con.Close();
        }

        public void getAcc()
        {
            SqlCommand cmd = new SqlCommand("select Description from tblTransactions", c.con);
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

        public void clr()
        {
            txtTid.Text = "";
            txtOrder.Text = "0";
            txtCustomer.Text = "";
            txtDate.Text = "";
            txtAcc.Text = "";
            txtAmount.Text = "";
        }
        
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
                txtTid.Text += ids + 1;
            }
            else
            {
                int ids = 0;
                c.con.Close();
                txtTid.Text += ids + 1;
            }
        }








        public crtBill()
        {
            InitializeComponent();
        }

        private void crtBill_Load(object sender, EventArgs e)
        {
            txtid();
            getitems();
            getAcc();

            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCustomer.Text != "" && txtDate.Text != "" && txtAmount.Text == "")
            {
                SqlCommand cmd = new SqlCommand("insert into tblTransactions(TID,TDate,TTime,BillNum,Supplier,Description)values(@tid,@d,@t,@b,@s,@ds)", c.con);
                SqlCommand cm = new SqlCommand("select Id from tblSupplier where Supplier = '" + txtCustomer.Text + "'", c.con);
                c.con.Open();
                SqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    int ids = dr.GetInt32(0);

                    cmd.Parameters.AddWithValue("@s", ids);
                    c.con.Close();
                    cmd.Parameters.AddWithValue("@tid", txtTid.Text);
                    cmd.Parameters.AddWithValue("@d", txtDate.Value);
                    cmd.Parameters.AddWithValue("@t", DateTime.Now.ToString("H:mm tt"));
                    cmd.Parameters.AddWithValue("@b", txtOrder.Text);
                    cmd.Parameters.AddWithValue("@ds", txtAcc.Text);
                    c.IUD(cmd);
                    clr();
                    txtOrder.Focus();
                    getAcc();
                    getitems();
                    txtid();
                }
                else
                {
                    c.con.Close();
                    MessageBox.Show("Please Select Customer !!");
                    txtOrder.Focus();
                    getAcc();
                    txtid();
                    getitems();
                }
            }

            else if (txtCustomer.Text != "" && txtDate.Text != "" && txtAmount.Text != "")
            {
                SqlCommand cmd = new SqlCommand("insert into tblTransactions(TID,TDate,TTime,BillNum,Supplier,Description)values(@tid,@d,@t,@b,@s,@ds)", c.con);
                SqlCommand cmdd = new SqlCommand("insert into tblTransDetails(TID,DDate,DTime,RawMaterial,[User],Total)values(@tid,@d,@t,1,@user,@tt)", c.con);
                SqlCommand cm = new SqlCommand("select Id from tblSupplier where Supplier = '" + txtCustomer.Text + "'", c.con);
                c.con.Open();
                SqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    int ids = dr.GetInt32(0);

                    cmd.Parameters.AddWithValue("@s", ids);
                    c.con.Close();
                    cmd.Parameters.AddWithValue("@d", txtDate.Value);
                    cmd.Parameters.AddWithValue("@t", DateTime.Now.ToString("H:mm tt"));
                    cmd.Parameters.AddWithValue("@b", txtOrder.Text);
                    cmd.Parameters.AddWithValue("@ds", txtAcc.Text);
                    cmd.Parameters.AddWithValue("@tid", txtTid.Text);
                    cmdd.Parameters.AddWithValue("@d", txtDate.Value);
                    cmdd.Parameters.AddWithValue("@t", DateTime.Now.ToString("H:mm tt"));
                    cmdd.Parameters.AddWithValue("@b", txtOrder.Text);
                    cmdd.Parameters.AddWithValue("@ds", txtAcc.Text);
                    cmdd.Parameters.AddWithValue("@tid", txtTid.Text);
                    cmdd.Parameters.AddWithValue("@tt", txtAmount.Text);
                    cmdd.Parameters.AddWithValue("@user", DataTransfer.user);
                    c.IUD(cmd);
                    c.IUD(cmdd);
                    clr();
                    txtOrder.Focus();
                    txtid();
                    getAcc();
                    getitems();
                }
                else
                {
                    c.con.Close();
                    MessageBox.Show("Please Select Customer !!");
                    txtOrder.Focus();
                    txtid();
                    getAcc();
                    getitems();
                }
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

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {

            
        }
    }
}
