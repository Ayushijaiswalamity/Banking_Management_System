using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_Project
{
    public partial class UpdateSearch : Form
    {
        BankDataEntities dbe;
        MemoryStream ms;
        BindingList<user_Accounts> bi;

        public UpdateSearch()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            bi = new BindingList<user_Accounts>();
            dbe = new BankDataEntities();
            int acc = Convert.ToInt32(txtAccountNo.Text);
            var item = dbe.user_Accounts.Where(a => a.AccountNo == acc);
            foreach (var item1 in item)
            {
                bi.Add(item1);

            }
            dataGridView1.DataSource = bi;

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            bi = new BindingList<user_Accounts>();
            dbe = new BankDataEntities();
            var item = dbe.user_Accounts.Where(a => a.Name == txtName.Text);
            foreach (var item1 in item)
            {
                bi.Add(item1);
            }
            dataGridView1.DataSource = bi;

        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dbe = new BankDataEntities();
            int acc = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            var item = dbe.user_Accounts.Where(a => a.AccountNo == acc).FirstOrDefault();
            txtAccountNo.Text = item.AccountNo.ToString();
            txtName.Text = item.Name;
            txtMN.Text = item.Mother_name;
            txtFN.Text = item.Father_name;
            txtPN.Text = item.PhoneNo;
            txtA.Text = item.Address;
            byte[] img = item.Picture;
            //MemoryStream ms = new MemoryStream(img);
            //pictureBox1.Image = Image.FromStream(ms);
            txtFN.Text = item.District;
            txtState.Text = item.State;
            if (item.Gender == "Male")
            {
                btnRmale.Checked = true;
            }
            else if (item.Gender == "Female")
            {
                btnRFemale.Checked = true;
            }
            else if (item.Gender == "Others")
            {
                btnROthers.Checked = true;
            }
            if (item.marital_status == "Married")
            {
                btnRMarried.Checked = true;
            }
            else if (item.marital_status == "UnMarried")
            {
                btnRUnMarried.Checked = true;
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendlg = new OpenFileDialog();
            if (opendlg.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(opendlg.FileName);
                pictureBox1.Image = img;
                ms = new MemoryStream();
                img.Save(ms, img.RawFormat);
            }

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            bi.RemoveAt(dataGridView1.SelectedRows[0].Index);
            dbe = new BankDataEntities();
            int acc = Convert.ToInt32(txtAccountNo.Text);
            user_Accounts a = dbe.user_Accounts.First(s => s.AccountNo.Equals(acc));
            dbe.user_Accounts.Remove(a);
            dbe.SaveChanges();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            dbe = new BankDataEntities();
            decimal accno = Convert.ToInt32(txtAccountNo.Text);
            user_Accounts ua = new user_Accounts();
           // user_Accounts a = dbe.user_Accounts.First(s => s.AccountNo.Equals(ua));



            ua.AccountNo = Convert.ToInt32(txtAccountNo.Text);
            ua.Name = txtName.Text;
            ua.DOB = dateTimePicker1.ToString();
            ua.Mother_name = txtMN.Text;
            ua.Father_name = txtFN.Text;
            ua.PhoneNo = txtPN.Text;
            if (btnRmale.Checked == true)
            {
                ua.Gender = "male";
            }
            else
            {
                if (btnRFemale.Checked == true)
                    ua.Gender = "female";
            }
            if (btnRMarried.Checked == true)
            {
                ua.marital_status = "married";
            }
            else
            {
                if (btnRUnMarried.Checked == true)
                    ua.marital_status = "Un-married";
            }
            //Image img = pictureBox1.Image;
           // if (img.RawFormat != null)
            
                ///if (ms != null)
               // {
                  //  img.Save(ms, img.RawFormat);
                  //  ua.Picture = ms.ToArray();
                //}
                ua.Address = txtA.Text;
                ua.District = txtDistrict.Text;
                ua.State = txtState.Text;
                dbe.SaveChanges();
                MessageBox.Show("Record Updated");
        }
    }

}