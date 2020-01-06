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
    public partial class CreditForm : Form
    {
        public CreditForm()
        {
            InitializeComponent();
            loaddate();
            loadmode();

        }

        private void loadmode()
        {
            //throw new NotImplementedException(); 
            comboBox1.Items.Add("Cash");
            comboBox1.Items.Add("Cheque");
        }

        private void loaddate()
        {
            //throw new NotImplementedException();//Utc is related to server (loaddate)
            lblDate.Text = DateTime.UtcNow.ToString("MM/dd/yyyy");
        }

        private void Button1_Click(object sender, EventArgs e) //details
        {
            //hre we have EDMX file, model1.edmx
            BankDataEntities context = new BankDataEntities();
            formNewAccount acc = new formNewAccount();
            Deposit dp = new Deposit();
            int b = Convert.ToInt32(txtAccountNo.Text);
            var item = (from u in context.user_Accounts where u.AccountNo == b select u).FirstOrDefault();
            txtName.Text = item.Name.ToString();
            txtOldBalance.Text = item.Balance.ToString();
            dp.Date = lblDate.Text;
            dp.AccountNo = Convert.ToInt32(txtAccountNo.Text);
            dp.Name = txtName.Text;
            //dp.OldBalance = Convert.ToDecimal(txtOB.Text);
           // dp.Mode = comboBox1.SelectedItem.ToString();
            ///dp.DipAmount = Convert.ToDecimal(txtDepositAmt.Text);
            context.Deposits.Add(dp);
            //context.SaveChanges();
            //to check old balance
            //item.Balance = item.Balance + Convert.ToDecimal(txtDepositAmt.Text);
        }
        private void Button2_Click(object sender, EventArgs e)//update
        {
            BankDataEntities context = new BankDataEntities();
            decimal b = Convert.ToDecimal(txtAccountNo.Text);
            var item = (from u in context.user_Accounts
                        where u.AccountNo == b
                        select u).FirstOrDefault();
            //txtName.Text = item.Name;
            //txtOB.Text = Convert.ToString(item.Balance);
            item.Balance = item.Balance + Convert.ToDecimal(txtDepositAmt.Text);
           // context.Deposits.Add()
            context.SaveChanges();
            MessageBox.Show("Deposit Money Successfully");


        }
    }
}
