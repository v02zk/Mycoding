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
    public partial class TermSelectedForm : Form
    {

        private ComboBox cbx;
        private TreeNode tn;
 
        public TermSelectedForm(ComboBox cbx)
        {
            InitializeComponent();
            this.cbx = cbx;
            initTownaAndCountryLandTerm();
            initDevelopLandTerm();
            initCustomizeTerm();
        }

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filepath);

        private void initTownaAndCountryLandTerm()
        {
            StringBuilder temp = new StringBuilder(500);
            GetPrivateProfileString("section", "城乡用地分类", "", temp, 500, filePath.TERMFILEPATH);

            string[] Levels = convertToStrings(temp);

            writeContentsToTreeView(Levels, tvTownAndCountryLand);
            tvTownAndCountryLand.ExpandAll();
        }

        private void initDevelopLandTerm()
        {
            StringBuilder temp = new StringBuilder(1500);
            GetPrivateProfileString("section", "城市建设用地", "", temp, 1500, filePath.TERMFILEPATH);

            string[] levels = convertToStrings(temp);

            writeContentsToTreeView(levels, tvUrbanDevelopLand);
            //tvUrbanDevelopLand.ExpandAll();
        }

        private void initCustomizeTerm()
        {
            StringBuilder temp = new StringBuilder(KeyWordCache.KEYWORDLENGTH);
            GetPrivateProfileString(KeyWordCache.CUSTOMIZE, "history", "", temp, KeyWordCache.KEYWORDLENGTH, filePath.TERMFILEPATH);

            string[] levels = convertToStrings(temp);
            writeContentsToCustomizeTreeView(levels, tvCustomize);
        }

        private void writeContentsToCustomizeTreeView(string[] levels, TreeView tv)
        {
            foreach (string level in levels)
            {
                if (level != "")
                {
                    tv.Nodes.Add(level);
                }
            }
            tv.Update();
        }

        private void writeContentsToTreeView(string[] levels,TreeView tv)
        {

            foreach (string level in levels)
            {
                TreeNode first = tv.Nodes.Add(level);

                StringBuilder temp = new StringBuilder(500);
                GetPrivateProfileString("section", level, "", temp, 500, filePath.TERMFILEPATH);
                
                string[] terms = convertToStrings(temp);
                foreach (string term in terms)
                {

                    TreeNode tn = first.Nodes.Add(term);
                    temp = new StringBuilder(200);
                    GetPrivateProfileString("section", term, "", temp, 500, filePath.TERMFILEPATH);
                    
                    terms = convertToStrings(temp);
                    foreach (string s in terms)
                    {
                        if (s == "")
                            tn.Nodes.Add("无下层分类");
                        else
                            tn.Nodes.Add(s);
                    }

                }
                tv.Update();
            }
        }

        private string[] convertToStrings(StringBuilder sb)
        {
            string t = sb.ToString();

            char[] chSplit = ",".ToCharArray();
            string[] key = t.Split(chSplit);

            return key;
        }
        private void btnCommit_Click(object sender, EventArgs e)
        {
            if (txbKeyword.Text != "")
            {
                cbx.Text = txbKeyword.Text;
                this.Close();

            }
            else
            {
                MessageBox.Show("请选择一个关键字");
            }
        }

        private void tvTownAndCountryLand_AfterSelect(object sender, TreeViewEventArgs e)
        {
            tn = e.Node;
            if (tn.Text != "无下层分类")
                txbKeyword.Text = tn.Text;
        }

        private void tvUrbanDevelopLand_AfterSelect(object sender, TreeViewEventArgs e)
        {
            tn = e.Node;
            if (tn.Text != "无下层分类")
                txbKeyword.Text = tn.Text;
        }

        private void tvCustomize_AfterSelect(object sender, TreeViewEventArgs e)
        {
            txbKeyword.Text = e.Node.Text;
        }

        private void updateCutomizeTreeView()
        {
            tvCustomize.Nodes.Clear();
            initCustomizeTerm();
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = tabControl1.SelectedTab.Text;
            if (s == "自定义")
            {
                updateCutomizeTreeView();
            }
        }

        private void btnAddCustomize_Click(object sender, EventArgs e)
        {
            CustomizeForm customizeform = new CustomizeForm(txbKeyword);
            customizeform.ShowDialog();

            updateCutomizeTreeView();
        }
    }
}
