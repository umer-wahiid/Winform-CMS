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
    public partial class EditBill : Form
    {
        Class1 c = new Class1();

        public void getitems()
        {
            SqlCommand cmd = new SqlCommand("select RawName from tblRawMaterial", c.con);
            c.con.Open();
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string items = dr.GetString(0);
                coll.Add(items);
                txtItem.Items.Add(items);
            }
            txtItem.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtItem.AutoCompleteMode = AutoCompleteMode.Append;
            txtItem.AutoCompleteCustomSource = coll;
            c.con.Close();
        }
        public void gettrans()
        {
            SqlCommand cmd = new SqlCommand("select Transport from tblTransport", c.con);
            c.con.Open();
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string items = dr.GetString(0);
                coll.Add(items);
                txtTransport.Items.Add(items);
            }
            txtTransport.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtTransport.AutoCompleteMode = AutoCompleteMode.Append;
            txtTransport.AutoCompleteCustomSource = coll;
            c.con.Close();
        }
        public void clr()
        {
            txtDate.Text = "";
            txtItem.Text = "";
            txtNag.Text = "0";
            txtQty.Text = "0";
            txtRate.Text = "0";
            txtBilty.Text = "";
            txtTransport.Text = "";
            txtLabour.Text = "0";
            txtBardan.Text = "0";
            txtTotal.Text = "0";
        }

        public void showgrid()
        {
            dataGridView1.DataSource = c.GetData("select tblTransDetails.ID as 'ID',tblTransDetails.DDate as 'Date',tblRawMaterial.RawName as 'آٰیٹم کانام', tblTransDetails.Nag, tblRawMaterial.Packing as 'پیکنگ', tblTransDetails.Qty as 'مقدار', tblTransDetails.Rate as 'ریٹ', tblTransDetails.Bilty, tblTransDetails.Transport as 'ٹرانسپورٹ', tblTransDetails.Labour as 'مزدوری', tblTransDetails.Bardan as 'باردان', tblTransDetails.Total as 'رقم' from tblTransDetails INNER JOIN tblRawMaterial ON tblTransDetails.RawMaterial = tblRawMaterial.Id where tblTransDetails.TID = " + DataTransfer.BillId + " ");
        }

        public EditBill()
        {
            InitializeComponent();
        }

        private void EditBill_Load(object sender, EventArgs e)
        {
            txtID.Text = DataTransfer.BillId;
            showgrid();
            getitems();
            gettrans();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDate.Text != "" && txtItem.Text != "")
            {
                SqlCommand cmd = new SqlCommand("insert into tblTransDetails(TID,DDate,DTime,RawMaterial,Qty,Rate,Nag,Bilty,Transport,Labour,Bardan,[User],Total)values(@tid,@d,@t,@rm,@q,@r,@n,@b,@tr,@l,@br,@u,@tt)", c.con);
                SqlCommand cm = new SqlCommand("select Id from tblRawMaterial where RawName = '" + txtItem.Text + "'", c.con);
                c.con.Open();
                SqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    int ids = dr.GetInt32(0);

                    cmd.Parameters.AddWithValue("@rm", ids);
                    c.con.Close();
                    cmd.Parameters.AddWithValue("@tid", txtID.Text);
                    cmd.Parameters.AddWithValue("@d", Convert.ToDateTime(txtDate.Text));
                    cmd.Parameters.AddWithValue("@t", DateTime.Now.ToString("H:mm tt"));
                    cmd.Parameters.AddWithValue("@q", txtQty.Text);
                    cmd.Parameters.AddWithValue("@r", txtRate.Text);
                    cmd.Parameters.AddWithValue("@n", txtNag.Text);
                    cmd.Parameters.AddWithValue("@b", txtBilty.Text);
                    cmd.Parameters.AddWithValue("@tr", txtTransport.Text);
                    cmd.Parameters.AddWithValue("@l", txtLabour.Text);
                    cmd.Parameters.AddWithValue("@br", txtBardan.Text);
                    cmd.Parameters.AddWithValue("@u", DataTransfer.user);
                    cmd.Parameters.AddWithValue("@tt", txtTotal.Text);
                
                    c.IUD(cmd);
                    showgrid();
                    getitems();
                    gettrans();
                    clr();
                    txtDate.Focus();
                }
                else
                {
                    c.con.Close();
                    MessageBox.Show("Please Select Product !!");
                    showgrid();
                    getitems();
                    gettrans();
                    txtDate.Focus();
                }
            }
            else
            {
                MessageBox.Show("Please Insert Data to Save !!");
            }
        }

       
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtDate.Text != "" && txtItem.Text != "")
            {
                SqlCommand cmd = new SqlCommand("update into tblTransDetails SET DDate=@d,DTime=@t,RawMaterial=@rm,Qty=@q,Rate=@r,Nag=@n,Bilty=@b,Transport=@tr,Labour=@l,Bardan=@br,[User]=@u,Total=@tt where ID=@i", c.con);
                SqlCommand cm = new SqlCommand("select Id from tblRawMaterial where RawName = '" + txtItem.Text + "'", c.con);
                c.con.Open();
                SqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    int ids = dr.GetInt32(0);

                    cmd.Parameters.AddWithValue("@rm", ids);
                    c.con.Close();
                    cmd.Parameters.AddWithValue("@i", txtTID.Text);
                    cmd.Parameters.AddWithValue("@d", Convert.ToDateTime(txtDate.Text));
                    cmd.Parameters.AddWithValue("@t", DateTime.Now.ToString("H:mm tt"));
                    cmd.Parameters.AddWithValue("@q", txtQty.Text);
                    cmd.Parameters.AddWithValue("@r", txtRate.Text);
                    cmd.Parameters.AddWithValue("@n", txtNag.Text);
                    cmd.Parameters.AddWithValue("@b", txtBilty.Text);
                    cmd.Parameters.AddWithValue("@tr", txtTransport.Text);
                    cmd.Parameters.AddWithValue("@l", txtLabour.Text);
                    cmd.Parameters.AddWithValue("@br", txtBardan.Text);
                    cmd.Parameters.AddWithValue("@u", DataTransfer.user);
                    cmd.Parameters.AddWithValue("@tt", txtTotal.Text);
                
                    c.IUD(cmd);
                    showgrid();
                    getitems();
                    gettrans();
                    clr();
                    txtDate.Focus();
                }
                else
                {
                    c.con.Close();
                    MessageBox.Show("Please Select Product !!");
                    showgrid();
                    getitems();
                    gettrans();
                    txtDate.Focus();
                }
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

            txtTID.Text = DataTransfer.id;
            txtDate.Text = DataTransfer.d;
        }
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        private void txtNag_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(txtBardan.Text) + Convert.ToInt32(txtLabour.Text) + (Convert.ToInt32(txtQty.Text) * Convert.ToInt32(txtRate.Text));
                txtTotal.Text = x.ToString();
            }
            catch(System.FormatException ex)
            {
                //MessageBox.Show("مقدار can't be empty!");
                txtQty.Text = "0";
            }
        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {
            try 
            { 
                int x = Convert.ToInt32(txtBardan.Text) + Convert.ToInt32(txtLabour.Text) + (Convert.ToInt32(txtQty.Text) * Convert.ToInt32(txtRate.Text));
                txtTotal.Text = x.ToString();
            }
            catch(System.FormatException ex)
            {
                //MessageBox.Show("ریٹ can't be empty!");
                txtRate.Text = "0";
            }
        }

        private void txtLabour_TextChanged(object sender, EventArgs e)
        {
            try 
            { 
                int x = Convert.ToInt32(txtBardan.Text) + Convert.ToInt32(txtLabour.Text) + (Convert.ToInt32(txtQty.Text) * Convert.ToInt32(txtRate.Text));
                txtTotal.Text = x.ToString(); ;
            }
            catch(System.FormatException ex)
            {
                //MessageBox.Show("مزدوری can't be empty!");
                txtLabour.Text = "0";
            }
        }

        private void txtBardan_TextChanged(object sender, EventArgs e)
        {
            try 
            { 
                int x = Convert.ToInt32(txtBardan.Text) + Convert.ToInt32(txtLabour.Text) + (Convert.ToInt32(txtQty.Text) * Convert.ToInt32(txtRate.Text));
                txtTotal.Text = x.ToString();
            }
            catch(System.FormatException ex)
            {
                //MessageBox.Show("باردان can't be empty!");
                txtBardan.Text = "0";
            }
        }

    }
}
