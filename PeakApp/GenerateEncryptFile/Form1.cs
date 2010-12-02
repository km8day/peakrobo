using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EncryptFile;

namespace GenerateEncryptFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strUser = this.mNameText.Text.Trim();
            if(string.IsNullOrEmpty(strUser))
            {
                MessageBox.Show("用户名不能为空！");
                return;
            }

            string strCompany = this.mCompanyText.Text.Trim();
            if (string.IsNullOrEmpty(strCompany))
            {
                MessageBox.Show("公司名不能为空！");
                return;
            }

            try
            {
                int iDays = int.Parse(this.mDaysText.Text.Trim());
                if (iDays < 1)
                {
                    MessageBox.Show("期限应该大于1！");
                    return;
                }
            }
            catch (System.FormatException)
            {
                MessageBox.Show("期限应该为数字！");
                return;
            }
            string strdays = this.mDaysText.Text.Trim();

            string struserpass = "stokerobotuser@nanjing.com";
            string strcomppass = "stokerobotcompany@nanjing.com";
            string strdayspass = "stokerobotdays@nanjing.com";
            string[] contents = new string[3];
            contents[0] = EncryptUtil.Encrypt(strUser, struserpass);
            contents[1] = EncryptUtil.Encrypt(strCompany, strcomppass);
            contents[2] = EncryptUtil.Encrypt(strdays, strdayspass);

            SaveFileDialog savedlg = new SaveFileDialog();
            savedlg.Filter = "Stoke files(*.stk)|*.stk";
            savedlg.OverwritePrompt = true;
            savedlg.ValidateNames = true;
            if(savedlg.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(savedlg.FileName))
            {
                System.IO.File.WriteAllLines(savedlg.FileName, contents);
            }
        }
    }
}
