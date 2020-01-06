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
    public partial class TransferMoney : Form
    {
        public TransferMoney()
        {
            InitializeComponent();
            loaddate();
        }

        private void loaddate()
        {
            //throw new NotImplementedException();
            lblDate.Text = DateTime.UtcNow.ToString("MM/dd/yyyy");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            BankDataEntities dbe = new BankDataEntities();
            decimal b = Convert.ToDecimal(txtFromAN.Text);
            var item = (from u in dbe.user_Accounts where u.AccountNo == b select u).FirstOrDefault();
            txtName.Text = item.Name;
            txtAmount.Text = Convert.ToString(item.Balance);

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            BankDataEntities dbe = new BankDataEntities();
            decimal b = Convert.ToDecimal(txtFromAN.Text);
            var item = (from u in dbe.user_Accounts where u.AccountNo == b select u).FirstOrDefault();
            decimal b1 = Convert.ToDecimal(item.Balance);
            decimal totalbal = Convert.ToDecimal(txtCurrentAmount.Text);////////check check//////
            decimal transferacc = Convert.ToDecimal(txtDestAmt.Text);
            if(b1>totalbal)
            {
                user_Accounts item2=(from u in dbe.user_Accounts where u.AccountNo == transferacc select u).FirstOrDefault();
                item2.Balance = item2.Balance + totalbal;
                item2.Balance = item2.Balance - totalbal;
                Transfer transfer = new Transfer();
                transfer.AccountNo = Convert.ToInt32(txtFromAN.Text);
                transfer.ToTransfer = Convert.ToDecimal(txtDestAmt.Text);
                transfer.Date = DateTime.UtcNow.ToString();
                transfer.Name = txtName.Text;
                transfer.Balance = Convert.ToDecimal(txtAmount.Text);
                dbe.Transfers.Add(transfer);
                dbe.SaveChanges();
                MessageBox.Show("Transfer successful");



            }
        }

      
    }
}
