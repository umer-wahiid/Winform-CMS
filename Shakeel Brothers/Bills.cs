using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shakeel_Brothers
{
    public partial class Bills : Form
    {

        Class1 c = new Class1();

        public Bills()
        {
            InitializeComponent();
        }

        private void Bills_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = c.GetData("select tblTransactions.TID as 'ID', tblTransactions.TDate as 'Date', tblTransactions.BillNum as 'Order No.', tblSupplier.Supplier, tblTransactions.Description as 'تفصیل' from tblTransactions INNER JOIN tblSupplier ON tblTransactions.Supplier = tblSupplier.Id where tblTransactions.Supplier = " + DataTransfer.cusId + " AND tblTransactions.BillNum != '' ");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTransfer.BillId = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            EditBill eb = new EditBill();
            eb.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
