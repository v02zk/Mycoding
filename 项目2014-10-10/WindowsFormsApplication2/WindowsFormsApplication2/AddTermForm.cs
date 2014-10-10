using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication2
{
    public partial class AddTermForm : Form
    {
        public AddTermForm(TextBox tb)
        {
            InitializeComponent();
            this.txb = tb;
        }

        private TextBox txb;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == null)
            {
                MessageBox.Show("请填写关键字");
            }
            else
            {
                string value = textBox1.Text;

                StringBuilder temp = new StringBuilder(2000);
                int re = GetPrivateProfileString("customize", "keyword", "", temp, 2000, filePath.TERMFILEPATH);
                string t = temp.ToString();
                t +=  value + "," ;             
                WritePrivateProfileString("customize", "keyword", t, filePath.TERMFILEPATH);               
                txb.Text = value;

                this.Close();
            }
        }

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filepath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filepath);


    }
}
