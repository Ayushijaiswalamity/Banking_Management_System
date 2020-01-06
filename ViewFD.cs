using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_Project
{
    public partial class ViewFD : Form
    {
        BindingList<FD> bl; //to show value in dATAGRID
        BankDataEntities dbe;

        public ViewFD()
        {
            InitializeComponent();
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            bl = new BindingList<FD>();
            dbe = new BankDataEntities();
            string date = dateTimePicker1.Value.ToString("MM/dd/yyyy");
            MessageBox.Show(date);
            var item = dbe.FDs.Where(a => a.StartDate.Equals(date));
            dataGridView1.DataSource = item.ToList();
        }

       
    }
}
