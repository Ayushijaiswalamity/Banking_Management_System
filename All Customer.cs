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
    public partial class All_Customer : Form
    {
        public All_Customer()
        {
            InitializeComponent();
            bindgrid();
        }
        private void bindgrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            BankDataEntities bs = new BankDataEntities();
            var item = bs.user_Accounts.ToList();
            dataGridView1.DataSource = item;


            //throw new NotImplementedException();
        }

      
    }
}
