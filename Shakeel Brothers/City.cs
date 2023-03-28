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
    public partial class City : Form
    {
        SqlDataAdapter adap;
        DataTable dt;

        Class1 c = new Class1();
        public City()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlCommandBuilder cmbdl = new SqlCommandBuilder(adap);
            adap.Update(dt);
            this.Close();
        }

        private void City_Load_1(object sender, EventArgs e)
        {
            adap = new SqlDataAdapter("select Id , City , Ucity as 'شہر' from tblcity", c.con);
            dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            adap = new SqlDataAdapter("select Id , City , Ucity as 'شہر' from tblCity Where City like '" + txtSearch.Text + "'+'%'", c.con);
            dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void City_FormClosing(object sender, FormClosingEventArgs e)
        {
            SqlCommandBuilder cmbdl = new SqlCommandBuilder(adap);
            adap.Update(dt);
        }
    }
}
