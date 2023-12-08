using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Shakeel_Brothers
{
    internal class Class1
    {
        public SqlConnection con;

        public Class1()
        {
            //con = new SqlConnection("Data Source=DESKTOP-R6JGHLF\\MSSQLSERVER01;Integrated Security=true;Initial Catalog=shakeel_brother");
            con = new SqlConnection("Data Source=DESKTOP-V05SP4H;Integrated Security=true;Initial Catalog=shakeel_brothers");
            //con = new SqlConnection("Data Source=DESKTOP-I6OQBMN;Integrated Security=true;Initial Catalog=shakeel_brothers");
            //con = new SqlConnection("Data Source=DESKTOP-76GEPIK; user id=sa;password=a123456;Initial Catalog=shakeel_brother");
            //con = new SqlConnection("Data Source=IMRAN; user id=sa;password=a123456;Initial Catalog=shakeel_brothers");
        }

        public void IUD(SqlCommand c)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            c.ExecuteNonQuery();
            con.Close();
        }

        public DataTable GetData(string q)
        {
            SqlDataAdapter da=new SqlDataAdapter(q,con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public void Update(string q)
        {
            SqlDataAdapter da = new SqlDataAdapter(q, con);
            SqlCommandBuilder cmbdl = new SqlCommandBuilder(da);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Update(dt);
            return;
        }


        //public void check()
        //{
        //    SqlCommand cmd = new SqlCommand("Select * from tblCashier where Cashier=@c and Password=@p", c.con);
        //    cmd.Parameters.AddWithValue("@c", textBox1.Text);
        //    cmd.Parameters.AddWithValue("@p", textBox2.Text);
        //    c.con.Open();
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    if (dr.HasRows)
        //    {
        //        while (dr.Read())
        //        {
        //            if (dr["Role"].ToString() == "admin")
        //            {
        //                Startup s = new Startup();
        //                s.Show();
        //                this.Hide();
        //            }
        //            else
        //            {
        //                this.Close();
        //            }
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Wrong Password");
        //    }
        //    c.con.Close();
        //}
    }
}
