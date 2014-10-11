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
    public partial class CustomizeForm : Form
    {
        private TextBox txb;
        public CustomizeForm(TextBox txb)
        {
            InitializeComponent();
            this.txb = txb;
        }

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filepath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filepath);

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string s = txbKey.Text;

            if (s.Trim() != "")
            {
                StringBuilder temp = new StringBuilder(KeyWordCache.KEYWORDLENGTH);
                int re = GetPrivateProfileString(KeyWordCache.CUSTOMIZE, "history", "", temp, KeyWordCache.KEYWORDLENGTH, filePath.TERMFILEPATH);
                string t = temp.ToString();
                t = t + s + ",";

                WritePrivateProfileString(KeyWordCache.CUSTOMIZE, "history", t, filePath.TERMFILEPATH);
                this.txb.Text = s;
                this.Close();
            }
            else
            {
                MessageBox.Show("请输入至少一个字符");
                txbKey.Clear();
            }
        }


    }
}
