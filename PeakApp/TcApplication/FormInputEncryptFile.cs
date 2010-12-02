using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TcApplication
{
    public partial class FormInputEncryptFile : Form
    {
        public FormInputEncryptFile()
        {
            InitializeComponent();
        }

        private void buttonbrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendlg = new OpenFileDialog();
            opendlg.Filter = "Stoke files(*.stk)|*.stk";
            opendlg.Multiselect = false;
            opendlg.CheckPathExists = true;
            opendlg.CheckFileExists = true;
            opendlg.ValidateNames = true;
            if (opendlg.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(opendlg.FileName))
            {
                this.textBox1.Text = opendlg.FileName;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(this.textBox1.Text.Trim()))
            {
                MessageBox.Show("文件路径为空！");
                this.DialogResult =  DialogResult.None;
                return;
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
