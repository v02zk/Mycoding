using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication2
{
    public partial class regDocSelectForm : Form
    {
        private ComboBox cbx;
        private string regFileName;
        private TableOfContents toc = new TableOfContents();
        private List<string> textResults;
        private List<string> specificationResults;
        private Dictionary<string, List<TermContainer>> regTOCContents = null;
        private Dictionary<string, List<string>> specificationTOCContents = null;
        private bool addNewRegDoc;
        private WaitingForm waitForm;

        public regDocSelectForm(ComboBox regDoc)
        {
            InitializeComponent();
            cbx = regDoc;
            textResults = new List<string>();
            specificationResults = new List<string>();
            addNewRegDoc = false;
            initRegListInTreeView();
            initRegSpecificationListTreeView();
        }

        private void initRegSpecificationListTreeView()
        {
            tvSpecificationDoc.Nodes.Clear();
            specificationResults = toc.getAllSpecificationContents();
            foreach (string name in specificationResults)
            {
                tvSpecificationDoc.Nodes.Add(name);
            }
            tvSpecificationDoc.Update();
        }

        private void initRegListInTreeView()
        {
            tvRegDoc.Nodes.Clear();
            textResults = toc.getAllRegContents();
            foreach (string name in textResults)
            {
                tvRegDoc.Nodes.Add(name);
            }
            tvRegDoc.Update();
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (textResults.Contains(txbDocName.Text) || specificationResults.Contains(txbDocName.Text))
            {
                cbx.Text = txbDocName.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("不存在所选择的成果规程");
            }
        }

        private void btnAddNewDoc_Click(object sender, EventArgs e)
        {
            if (rbText.Checked || rbSpecification.Checked)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Word文件|*.doc";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    regFileName = openFileDialog.FileName;
                    string filename = regFileName.Substring(regFileName.LastIndexOf("\\") + 1, regFileName.LastIndexOf(".") - regFileName.LastIndexOf("\\") - 1);
                    if (rbText.Checked)
                    {
                        if (!textResults.Contains(filename))
                        {
                            waitForm = new WaitingForm();
                            HandleWaitingForm.startWaitingForm(waitForm);

                            regTOCContents = toc.AddRegToSysResource(regFileName);
                            addNewRegDoc = true;
                            textResults.Add(filename);
                            txbDocName.Text = filename;
                            tvRegDoc.Nodes.Add(filename);
                            tvRegDoc.Update();

                            HandleWaitingForm.closeWaitingForm(waitForm);
                        }
                        else
                        {
                            if (MessageBox.Show("已存在！是否替换", "提示框", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {

                                waitForm = new WaitingForm();
                                HandleWaitingForm.startWaitingForm(waitForm);

                                regTOCContents = toc.AddRegToSysResource(regFileName);
                                addNewRegDoc = true;
                                txbDocName.Text = filename;

                                HandleWaitingForm.closeWaitingForm(waitForm);
                            }
                            else
                            {
                                //
                            }
                        }
                    }
                    else
                    {
                        if (!specificationResults.Contains(filename))
                        {
                            waitForm = new WaitingForm();
                            HandleWaitingForm.startWaitingForm(waitForm);

                            HandleDocument handleDocument = new HandleDocument();
                            ////获得说明书规程文档目录
                            ////将说明书目录存入系统
                            specificationTOCContents = toc.AddSpecificationToSysResource(regFileName);
                            
                            addNewRegDoc = true;
                            specificationResults.Add(filename);
                            txbDocName.Text = filename;
                            tvSpecificationDoc.Nodes.Add(filename);
                            tvSpecificationDoc.Update();
                            
                            HandleWaitingForm.closeWaitingForm(waitForm);
                        }
                        else
                        {
                            if(MessageBox.Show("已存在！是否替换", "提示框", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                waitForm = new WaitingForm();
                                HandleWaitingForm.startWaitingForm(waitForm);

                                HandleDocument handleDocument = new HandleDocument();
                                ////获得说明书规程文档目录
                                ////将说明书目录存入系统
                                specificationTOCContents = toc.AddSpecificationToSysResource(regFileName);
                                addNewRegDoc = true;
                                txbDocName.Text = filename;

                                HandleWaitingForm.closeWaitingForm(waitForm);
                            } 
                            else
                            {
                                //
                            }
                        }
                        
                    }
                    toc.update(cbx);
                }               
            }
            else
            {
                MessageBox.Show("请选择一种规程类型");
            }
        }

        public Dictionary<string, List<TermContainer>>  getRegTOCContents()
        {
            return regTOCContents;         
        }

        public Dictionary<string, List<string>> getSpecificationTOCContents()
        {
            return specificationTOCContents;
        }

        public bool isAddNewRegDoc()
        {
            return addNewRegDoc;
        }

        private void tvRegDoc_AfterSelect(object sender, TreeViewEventArgs e)
        {
            txbDocName.Text = e.Node.Text;
        }

        private void tvSpecificationDoc_AfterSelect(object sender, TreeViewEventArgs e)
        {
            txbDocName.Text = e.Node.Text;
        }

        private void btnDelDoc_Click(object sender, EventArgs e)
        {             
            string name = txbDocName.Text;
            if (textResults.Contains(name) || specificationResults.Contains(name))
            {
                string tabName = tabReg.SelectedTab.Text;
                if (tabName == "文本规程")
                {
                    if (MessageBox.Show("确认删除删除规程文件" + name+" ?", "提示框", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        toc.deleteTextContent(name);
                        initRegListInTreeView();
                    }
                }
                else if(tabName == "说明书规程")
                {
                    if (MessageBox.Show("确认删除删除规程文件："+name+" ?" , "提示框", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        toc.deleteSpecificationContent(name);
                        initRegSpecificationListTreeView();
                    }
                }
                txbDocName.Text = "";
            }
            else
            {
                MessageBox.Show("请选择一个文件");
            }

        }
    }
}
