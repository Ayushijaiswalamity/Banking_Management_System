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
    public partial class Withdrawal : Form
    {
        public string Date { get; private set; }
        public string AccountNo { get; private set; }
        public decimal OldBalance { get; private set; }
        public string Mode { get; private set; }
        public decimal WithdrawAmount { get; private set; }

        public Withdrawal()
        {
            InitializeComponent();
            loadmode();
        }

        private void loadmode()
        {
            //throw new NotImplementedException();
                comboBox1.Items.Add("Cash");
                comboBox1.Items.Add("Cheque");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            BankDataEntities dbe = new BankDataEntities();
            decimal b = Convert.ToDecimal(txtAccountNo.Text);
            var item = (from u in dbe.user_Accounts where u.AccountNo == b select u).FirstOrDefault();

            txtName.Text = item.Name;
            txtOldBalance.Text = Convert.ToString(item.Balance);

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            BankDataEntities dbe = new BankDataEntities();
            formNewAccount nacc = new formNewAccount();
            Debit wd = new Debit();
            wd.Date = lblDate.Text;
            wd.AccountNo = Convert.ToInt32(txtAccountNo.Text);
            wd.Name = txtName.Text;
            wd.OldBalance = Convert.ToDecimal(txtOldBalance.Text);
            wd.Mode = comboBox1.SelectedItem.ToString();
            wd.DebitAmount = Convert.ToDecimal(txtAmount.Text);
            dbe.Debits.Add(wd);

            dbe.SaveChanges();
            decimal b = Convert.ToDecimal(txtAccountNo.Text);
            var item = (from u in dbe.user_Accounts where u.AccountNo == b select u).FirstOrDefault();
            item.Balance = item.Balance - NewMethod();
            dbe.SaveChanges();
            MessageBox.Show("Debit Money");

        }

        private decimal NewMethod()
        {
            return Convert.ToDecimal(txtAmount.Text);
        }
    }
}
