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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
      
        
       

        private void NewAccountToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            formNewAccount newAcc = new formNewAccount();
            //newAcc.MdiParent = this;
            newAcc.Show();
        }

        private void UpdateToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            UpdateSearch up = new UpdateSearch();
           // up.MdiParent = this;
            up.Show();

        }

        private void AllCustomerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            All_Customer ac = new All_Customer();
            //ac.MdiParent = this;
            ac.Show();
        }

        private void DepositToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            CreditForm d = new CreditForm();
            //d.MdiParent = this;
            d.Show();
        }

        private void WithdrawlToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Withdrawal wd = new Withdrawal();
            // wd.MdiParent = this;
            wd.Show();
        }

        private void TransferToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            TransferMoney tr = new TransferMoney();
            // tr.MdiParent = this;
            tr.Show();
        }

        ////private void FDFormsToolStripMenuItem_Click_1(object sender, EventArgs e)
        ////{
        ////    FDForm fd = new FDForm();
        ////    //fd.MdiParent = this;
        ////    fd.Show();
        ////}

        //private void BalanceSheetToolStripMenuItem_Click_1(object sender, EventArgs e)
        //{
        //    BalanceSheet bs = new BalanceSheet();
        //    //bs.MdiParent = this;
        //    bs.Show();
        //}

        private void FDToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FD fdd = new FD();
            //fdd.MdiParent = this;
            fdd.Show();
        }

        private void ChangePasswordToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ChangePassword cp = new ChangePassword();
            //cp.MdiParent = this;
            cp.Show();
        }
        //private void ViewToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    View ve = new View();
        //    //fd.MdiParent = this;
        //    ve.Show();
        //}
        private void LogoutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    
    }
}
