using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using System.Runtime.InteropServices;
using System.IO;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            initKeyWordList();
            initRegDocList();
            initMenu();
            hideMSGArea();
            initTableList();
            //cbxTableList.DropDownStyle = ComboBoxStyle.DropDownList;
            //cbxRegDoc.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        //初始化现有表格记录
        private void initTableList()
        {
            cbxTableList.Items.Add("城市建设用地平衡表");
            cbxTableList.Items.Add("城市现状用地平衡表");
            cbxTableList.Items.Add("城市建设用地平衡表－近期");
            cbxTableList.Items.Add("城市建设用地平衡表－现状");
            //to be veified
            cbxTableList.Items.Add("城市建设用地平衡表－现状＋规划");

        }
        //初始化现有目录
        private void initMenu()
        {
            comboBoxLevel1.Items.Add("规程");
            comboBoxLevel1.Items.Add("成果文件");
        }

        //初级目录项目变化
        private void comboBoxLevel1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedReg = comboBoxLevel1.Text;

            comboBoxLevel2.Text = "";
            comboBoxLevel2.Items.Clear();
            comboBoxLevel3.Text = "";
            comboBoxLevel3.Items.Clear();

            if (selectedReg == "规程")
            {
                comboBoxLevel2.Items.Add("总规");
                comboBoxLevel2.Items.Add("控规");
                comboBoxLevel2.Items.Add("修规");
            }
            else
            {

            }
        }

        //二级目录项目变化
        private void comboBoxLevel2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxLevel3.Items.Clear();

            string selectLevel2Menu = comboBoxLevel2.Text;
            if (selectLevel2Menu == "总规" || selectLevel2Menu == "修规")
            {
                comboBoxLevel3.Items.Add("文本");
                comboBoxLevel3.Items.Add("说明书");
            }
            else
            {

            }
        }

        private void initKeyWordList()
        {
            List<string> result = KeyWordCache.getAllKeyWordCache();
            foreach (string s in result)
            {
                cbxKeyWord.Items.Add(s);
            }
            cbxKeyWord.Update();
        }

        private void initRegDocList()
        {
            List<string> result1 = tableOfContents.getAllRegContents();
            List<string> result2 = tableOfContents.getAllSpecificationContents();
            List<string> result = new List<string>();
            result.AddRange(result1);
            result.AddRange(result2);
            foreach (string s in result)
            {
                cbxRegDoc.Items.Add(s);
            }
            cbxRegDoc.Update();
        }

        private string testFileName = "";
        private void btnTestFileSelect_Click(object sender, EventArgs e)
        {
            string temp = testFileName;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Word文件|*.doc";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                testFileName = openFileDialog.FileName;
                if (testFileName != temp && temp != "")
                {
                    testDocLabel.Text = testFileName;
                    if (testDocIsOpen)
                        closeTestDoc();
                }
                else
                {
                    testDocLabel.Text = testFileName;
                }
            }
            else
            {
                testFileName = openFileDialog.FileName;
                testDocLabel.Text = testFileName;
            }
        }


        private regDocSelectForm regDocSForm = null;
        private void btnRegSelect_Click(object sender, EventArgs e)
        {
            if (regDocSForm == null)
            {
                regDocSForm = new regDocSelectForm(cbxRegDoc);
            }
            regDocSForm.ShowDialog();
        }

        private void closeTestDoc()
        {
            Object saveChanges = false;
            object unknow = Type.Missing;
            testDocIsOpen = false;

            testDoc.Close(ref saveChanges, ref unknow, ref unknow);
        }

        private ApplicationClass testWord = new ApplicationClass();
        private Document testDoc = new Document();
        private bool testDocIsOpen = false;

        private HandleDocument handleDocument = new HandleDocument();
        private TableOfContents tableOfContents = new TableOfContents();

        private Dictionary<string, List<TermContainer>> regTOCContents = null;
        private Dictionary<string, List<TermContainer>> testTOCContents = null;
        private string preRegFileName = null;
        private string preTestFileName = null;
        private void btnTest_Click(object sender, EventArgs e)
        {
            string regFileName = cbxRegDoc.Text;
            if (testFileName == null || testFileName.Trim() == "")
            {
                MessageBox.Show("请选择一个目标文档");
            }
            else if (regFileName == null || regFileName.Trim() == "")
            {
                MessageBox.Show("请选择一个规程文档");
            }
            else
            {
                ////改为察看系统中所有规程，现在为察看是否在列表中。当前列表显示所有规程，以后改为显示前n项
                if (cbxRegDoc.Items.Contains(regFileName))
                {
                    if (isTextMode())
                    {
                        WaitingForm wf = new WaitingForm();
                        HandleWaitingForm.startWaitingForm(wf);
                        if (!testDocIsOpen)
                        {
                            testDocIsOpen = true;
                            testDoc = handleDocument.openDocument(testFileName, testWord);
                        }

                        //////获得规程文档目录内容  
                        //////如果规程文档与上次相同则不重新载入
                        //if (preRegFileName != regFileName)
                        //{
                            if (regDocSForm != null && regDocSForm.isAddNewRegDoc())
                                regTOCContents = regDocSForm.getRegTOCContents();
                            else
                            {
                                regTOCContents = tableOfContents.getTOCContentsByName(regFileName);
                            }
                            writeRegToListBox(regTOCContents, regTreeView);
                       // }

                        
                        //////获得测试文档目录内容
                        //////如果测试文档与上次相同则不重新载入
                        if ((preTestFileName != testFileName) || !tocTestStarted)
                        {
                            testTOCContents = handleDocument.getTestTextDocTOC(testDoc, testWord);
                        }

                        Dictionary<string, List<string>> msgContentList = new Dictionary<string, List<string>>();
                        msgContentList.Add("error", new List<string>());
                        msgContentList.Add("spare", new List<string>());
                        msgContentList.Add("missing", new List<string>());

                        writeTocTOListBox(testTOCContents, testTreeView, regTreeView, msgContentList);

                        tableOfContents.update(cbxRegDoc);
                        tabControl2.SelectTab("tabPageTest");

                        ////记录本次操作的规程文档和测试文档文件名
                        preRegFileName = regFileName;
                        preTestFileName = testFileName;
                        HandleWaitingForm.closeWaitingForm(wf);

                        ////显示错误报告项目
                        List<string> list = msgContentList["error"];
                        int c = list.Count;
                        MessageBox.Show(c.ToString());
                        list = msgContentList["spare"];
                        c = list.Count;
                        MessageBox.Show(c.ToString());
                        list = msgContentList["missing"];
                        c = list.Count;
                        MessageBox.Show(c.ToString());



                        if(!reportMSG.Contains(textTOCMSG))
                            reportMSG += textTOCMSG;

                    }
                    else if (isSpecificationMode())
                    {
                        WaitingForm wf = new WaitingForm();
                        HandleWaitingForm.startWaitingForm(wf);

                        if (!testDocIsOpen)
                        {
                            testDocIsOpen = true;
                            testDoc = handleDocument.openDocument(testFileName, testWord);
                        }

                        //////获得规程文档目录内容  
                        //////如果规程文档与上次相同则不重新载入
                        if (preRegFileName != regFileName)
                        {
                            Dictionary<string, List<string>> specificationDict = null;
                            if (regDocSForm != null && regDocSForm.isAddNewRegDoc())
                                specificationDict = regDocSForm.getSpecificationTOCContents();
                            else
                            {
                                specificationDict = tableOfContents.getSpecificationTOCContentsByName(regFileName);
                            }
                            writeRegSpecipicationToListBox(specificationDict, regTreeView);
                        }


                        //////获得测试文档目录内容
                        //////如果测试文档与上次相同则不重新载入
                        if (preTestFileName != testFileName)
                        {
                            testTOCContents = handleDocument.getTestSpecificationDocTOC(testDoc, testWord);
                            writeSpecificationTocTOListBox(testTOCContents, testTreeView, regTreeView);
                        }
                        tableOfContents.update(cbxRegDoc);
                        tabControl2.SelectTab("tabPageTest");

                        ////记录本次操作的规程文档和测试文档文件名
                        preRegFileName = regFileName;
                        preTestFileName = testFileName;

                        HandleWaitingForm.closeWaitingForm(wf);

                        if(!reportMSG.Contains(specifiTOCMSG))
                        reportMSG += specifiTOCMSG;
                    }
                    else
                    {
                        MessageBox.Show("请选择一种比较方法");
                    }

                    plKeyWord.Hide();
                    plTableTest.Hide();

                    hideTableTreeView();
                    hideTableTreeView();
                    tabControlMulti.Hide();

                    tabControl2.Show();
                    showTOCTreeView();
                    plTOC.Show();

                    if(testDocIsOpen)
                        closeTestDoc();

                }
                else
                {
                    MessageBox.Show("选择的规程文档不存在");
                }
                //closeTestDoc();
            }
        }


        private void writeRegToListBox(Dictionary<string, List<TermContainer>> result, TreeView tv)
        {
            tv.Nodes.Clear();
            tableOfContents.generateRegTreeView(result, tv);
        }

        private void writeRegSpecipicationToListBox(Dictionary<string, List<string>> result, TreeView tv)
        {
            tv.Nodes.Clear();
            foreach (KeyValuePair<string, List<string>> kvp in result)
            {
                TreeNode ChapterNode = tv.Nodes.Add(kvp.Key);
                List<string> list = kvp.Value;
                foreach (string s in list)
                {
                    ChapterNode.Nodes.Add(s);
                }
            }
            tv.Update();
            tv.ExpandAll();
            tv.Nodes[0].EnsureVisible();
        }

        private void writeSpecificationTocTOListBox(Dictionary<string, List<TermContainer>> result, TreeView tv, TreeView regTreeView)
        {
            tv.Nodes.Clear();
            int error = 0;
            int spare = 0;
            int miss = 0;

            Dictionary<string, int> dict =
            tableOfContents.generateTestSpecificationTreeView(result, tv, regTreeView);

            foreach (KeyValuePair<string, int> kvp in dict)
            {
                if (kvp.Key == "error")
                    error = kvp.Value;
                if (kvp.Key == "spare")
                    spare = kvp.Value;
                if (kvp.Key == "miss")
                    miss = kvp.Value;
            }
            if(!specifiTOCMSG.Contains("说明书文档"))
                specifiTOCMSG += "说明书文档：\r错误：" + error + "    缺失：" + miss + "    多余：" + spare + "\r\r";
            showMSGArea(error, spare, miss);
        }

        private void writeTocTOListBox(Dictionary<string, List<TermContainer>> result, TreeView tv, TreeView regTreeView, Dictionary<string,List<string>> msgContentList)
        {
            tv.Nodes.Clear();
            int error = 0;
            int spare = 0;
            int miss = 0;

            Dictionary<string, int> dict = tableOfContents.generateTestTextTreeView(result, tv, regTreeView,msgContentList);

            foreach (KeyValuePair<string, int> kvp in dict)
            {
                if (kvp.Key == "error")
                    error = kvp.Value;
                if (kvp.Key == "spare")
                    spare = kvp.Value;
                if (kvp.Key == "miss")
                    miss = kvp.Value;
            }
            if(!textTOCMSG.Contains("文本文档"))
                textTOCMSG += "文本文档：\r错误：" + error + "    缺失：" + miss + "    多余：" + spare + "\r\r"; 
            showMSGArea(error, spare, miss);

        }

        private void showMSGArea(int error, int spare, int miss)
        {
            plTOC.Show();
            lbErrorText.Text = "有误：" + error;
            lbSpareText.Text = "多余：" + spare;
            lbMissText.Text = "缺失：" + miss;
        }

        private void hideMSGArea()
        {
            plTOC.Hide();
            plKeyWord.Hide();
            plTableTest.Hide();
            plMultiInfo.Hide();
            tabControlMulti.Hide();
        }

        private void btnKeyWordSelect_Click(object sender, EventArgs e)
        {
            TermSelectedForm form = new TermSelectedForm(cbxKeyWord);
            form.Show();
        }

        private void cbxKeyWord_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = cbxKeyWord.SelectedItem.ToString();
            if (selectedItem == "显示全部")
            {
                TermSelectedForm form = new TermSelectedForm(cbxKeyWord);
                form.ShowDialog();
            }
            else
            {

            }
        }

        private Boolean ifExecuted = false;//判断单文档关键字查询是否执行了

        private void btnFindKeyWord_Click(object sender, EventArgs e)
        {
            string keyword = cbxKeyWord.Text;
            if (keyword.Trim() != "")
            {
                KeyWordCache.putKeyWordInCache(keyword, KeyWordCache.KEYWORD);
                KeyWordCache.update(cbxKeyWord, KeyWordCache.KEYWORD);

                tabControl2.SelectTab("tabPageFind");

                if (checkKeyWordInput(testFileName, multiTestFilePath, multiRegFilePath, multiSpecFilePath) == true)//检查输入不为空
                {
                    KeyWord keyWord = new KeyWord();
                    if (!isMultiple)//danwendang
                    {
                        if (testDoc != null)
                        {
                            if (!testFileName.Equals(preTestFileName) || keywordChanged)//如果路径改变或者关键字改变则认为关键字查询没有执行
                            {
                                ifExecuted = false;
                            }
                            if (!testFileName.Equals(preTestFileName) || keywordChanged || !ifExecuted)
                            {
                                WaitingForm wf = new WaitingForm();
                                HandleWaitingForm.startWaitingForm(wf);
                                if (!testDocIsOpen)
                                {
                                    testDocIsOpen = true;
                                    testDoc = handleDocument.openDocument(testFileName, testWord);
                                }

                                keyWord.highLightKeyWords(cbxKeyWord.Text, testWord, testDoc, richTxbTestDoc, lbCountItems, rtbKeyWord);

                                HandleWaitingForm.closeWaitingForm(wf);
                                ifExecuted = true;

                                preTestFileName = testFileName;

                                /////查询关键字对应的标准规范值
                                string value = keyWord.getExistStandard(keyword);
                                lbKeyWordSingle.Text = keyword;
                                if (value != null)
                                    lbKeyWordValueSingle.Text = value;
                                else
                                    lbKeyWordValueSingle.Text = "";
                            }
                        }
                    }
                    else
                    {
                        keyWord.multiHightLigthKeyWord(preMultiTestFilePath, preMultiRegFilePath, preMultiSpecFilePath, multiTestFilePath, multiRegFilePath, multiSpecFilePath, keyword, testWord, rtbTestDoc, rtbRegDoc,
                            rtbSpecificationDoc, null, null, null, rtxMultiTestDoc, rtbMultiRegDoc, rtbMultiSpecDoc, handleDocument, keywordChanged);
                        updatePreFilePath();

                        /////查询关键字对应的标准规范值
                        string value = keyWord.getExistStandard(keyword);
                        lbKeyWord.Text = keyword;
                        if (value != null)
                            lbKeyWordValue.Text = value;
                        else
                            lbKeyWordValue.Text = "无标准数值信息";
                    }

                }

                plTableTest.Hide();
                plTOC.Hide();
                if (!isMultiple)
                {
                    plMultiInfo.Hide();
                    plKeyWord.Show();
                }
                else
                {
                    plKeyWord.Hide();
                    plMultiInfo.Show();
                }
                keywordChanged = false;
            }
            else
            {
                MessageBox.Show("请输入关键字");
            }
        }
        private Boolean checkKeyWordInput(string testFileName, string multiTestFilePath, string multiRegFilePath, String multiSpecFilePath)
        {
            if (testFileName == "" && multiTestFilePath == ""
                && multiRegFilePath == "" && multiSpecFilePath == "")
            {
                MessageBox.Show("请选择一个关键字查询文档");
                tabControl2.SelectTab("tabPageTest");
                return false;
            }
            return true;
        }
        private void updatePreFilePath()
        {
            preMultiTestFilePath = multiTestFilePath;
            preMultiRegFilePath = multiRegFilePath;
            preMultiSpecFilePath = multiSpecFilePath;
        }

        private void btnTestTable_Click(object sender, EventArgs e)
        {
            tabControl2.SelectTab("tabPageTest");

            string regFileName = cbxRegDoc.Text;
            if (testFileName == null || testFileName.Trim() == "")
            {
                MessageBox.Show("请选择一个目标文档");
            }
            else if (regFileName == null || regFileName.Trim() == "")
            {
                MessageBox.Show("请选择一个规程文档");
            }
            else if (!isTextMode())
            {
                MessageBox.Show("非文本文档检测模式不支持表格匹配,请在目录检测中选择文本模式");
            }
            else
            {
                HandleTable handleTable = new HandleTable(testWord);

                string path = System.Environment.CurrentDirectory;
                string name = regFileName;
                name = path + "\\resources\\" + name + ".doc";

                Document regDoc = new Document();
                HandleDocument handleDocument = new HandleDocument();

                WaitingForm wf = new WaitingForm();
                HandleWaitingForm.startWaitingForm(wf);

                if (!testDocIsOpen)
                {
                    testDocIsOpen = true;
                    testDoc = handleDocument.openDocument(testFileName, testWord);
                }

                regDoc = handleDocument.openDocument(name, testWord);

                handleTable.contrastTablesOfDocs(regDoc, testDoc, showItemInfo, tvRegTable
                    , tvTestTable, null, null, null);

                Object saveChanges = false;
                object unknow = Type.Missing;

                regDoc.Close(ref saveChanges, ref unknow, ref unknow);

                HandleWaitingForm.closeWaitingForm(wf);

                plTOC.Hide();
                plKeyWord.Hide();
                plMultiInfo.Hide();

                plTableTest.Show();
                showTableTreeView();
                hideTOCTreeView();

                isMultiple = false;
                tabCalculateTable.Show();
                tabControlMulti.Hide();
            }
        }

        private void btnTestValue_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 显示规程文档中目录的备注
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void regTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (isTextMode())
            {
                string tip = "";
                string title = e.Node.Text;

                if (!title.Contains("第") && !title.Contains("节"))
                {
                    ////当前选中节点的父节点 
                    TreeNode pTV = e.Node.Parent;
                    if (pTV != null)
                    {
                        ////如果父节点是“章”
                        if (pTV.Text.Contains("第") && pTV.Text.Contains("章"))
                        {
                            string index = pTV.Text;
                            TermContainer tcc = regTOCContents[index].Find(delegate(TermContainer tc)
                            {
                                if (tc.TermName.Contains(title))
                                    return true;
                                return false;
                            });
                            tip = tcc.TermTip;
                        }
                        ////如果父节点是“节”
                        else
                        {
                            string index = pTV.Parent.Text;
                            TermContainer tcc = regTOCContents[index].Find(delegate(TermContainer tc)
                            {
                                if (tc.TermName.Contains(title))
                                    return true;
                                return false;
                            });
                            tip = tcc.TermTip;
                        }

                        lbTermTitle.Text = title;
                        rtbMSG.Clear();
                        rtbMSG.Text = tip;
                    }
                }
            }
            else
            {

            }
        }

        private void hideTableTreeView()
        {
            tvTestTable.Hide();
            tvRegTable.Hide();
        }
        private void showTableTreeView()
        {
            tvTestTable.Show();
            tvRegTable.Show();
        }
        private void hideTOCTreeView()
        {
            testTreeView.Hide();
            regTreeView.Hide();
        }
        private void showTOCTreeView()
        {
            testTreeView.Show();
            regTreeView.Show();
        }

        private void tabControlFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = tabControlFunction.SelectedTab.Text;

            if (s == "目录检测")
            {
                plKeyWord.Hide();
                plTableTest.Hide();
                plTOC.Show();
                showTOCTreeView();
                hideTableTreeView();
                plMultiInfo.Hide();
                tabControl2.SelectTab("tabPageTest");

            }
            else if (s == "表格检测")
            {
                plKeyWord.Hide();
                plTableTest.Show();
                plTOC.Hide();
                showTableTreeView();
                hideTOCTreeView();
                tabControl2.SelectTab("tabCalculateTable");
                /////////待处理
                plMultiInfo.Hide();

            }
            else if (s == "关键字查询")
            {
                plTOC.Hide();
                plTableTest.Hide();
                plKeyWord.Show();
                tabControl2.SelectTab("tabPageFind");
                if (isMultiple)
                    plMultiInfo.Show();
                else
                    plMultiInfo.Hide();
            }
            else if (s == "规范检测")
            {
                plKeyWord.Hide();
                plTableTest.Hide();
                plTOC.Hide();
                plMultiInfo.Hide();
            }
        }

        /// <summary>
        /// mode 用来判断当前模式：单文档还是多文档,默认是单文档
        /// </summary>
        private bool isMultiple = false;
        private void btnMultipleDocCompare_Click(object sender, EventArgs e)
        {
            if (testDocIsOpen)
            {
                closeTestDoc();
            }

            isMultiple = true;
            tabControl2.Hide();
            tabControlMulti.Show();
            plMultiInfo.Show();

            plTOC.Hide();
            plKeyWord.Hide();
            plTableTest.Hide();
        }

        private void btnTwoDocCompare_Click(object sender, EventArgs e)
        {
            isMultiple = false;
            tabControl2.Show();
            tabControlMulti.Hide();
            plMultiInfo.Hide();
            string s = tabControlFunction.SelectedTab.Text;
            if (s == "目录检测")
            {
                plKeyWord.Hide();
                plTableTest.Hide();
                plTOC.Show();
                showTOCTreeView();
                hideTableTreeView();
                plMultiInfo.Hide();
                tabControl2.SelectTab("tabPageTest");

            }
            else if (s == "表格检测")
            {
                plKeyWord.Hide();
                plTableTest.Show();
                plTOC.Hide();
                showTableTreeView();
                hideTOCTreeView();
                //tabControl2.SelectTab("tabPageFind");
            }
            else if (s == "关键字查询")
            {
                plTOC.Hide();
                plTableTest.Hide();
                plKeyWord.Show();
                tabControl2.SelectTab("tabPageFind");
                if (isMultiple)
                    plMultiInfo.Show();
                else
                    plMultiInfo.Hide();
            }
            else if (s == "规范检测")
            {
                plKeyWord.Hide();
                plTableTest.Hide();
                plTOC.Hide();
                plMultiInfo.Hide();
            }
        }


        private string preMultiTestFilePath = "";
        private string multiTestFilePath = "";
        private void btnMultiSelectTestDoc_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Word文件|*.doc";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                multiTestFilePath = openFileDialog.FileName;
                if (multiTestFilePath != "")
                {
                    txbMultiTest.Text = multiTestFilePath;
                }
            }
            else
            {
                multiTestFilePath = openFileDialog.FileName;
                txbMultiTest.Text = multiTestFilePath;
            }
        }
        private string preMultiRegFilePath = "";
        private string multiRegFilePath = "";
        private void btnMultiSelectRegDoc_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Word文件|*.doc";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                multiRegFilePath = openFileDialog.FileName;
                if (multiRegFilePath != "")
                {
                    txbMultiReg.Text = multiRegFilePath;
                }
            }
            else
            {
                multiRegFilePath = openFileDialog.FileName;
                txbMultiReg.Text = multiRegFilePath;
            }
        }
        private string preMultiSpecFilePath = "";
        private string multiSpecFilePath = "";
        private void btnMultiSelectSpecDoc_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Word文件|*.doc";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                multiSpecFilePath = openFileDialog.FileName;
                txbMultiSpecification.Text = multiSpecFilePath;
            }
            else
            {
                multiSpecFilePath = openFileDialog.FileName;
                txbMultiSpecification.Text = multiSpecFilePath;
            }
        }

        private string[] tableName = { "城市建设用地平衡表", "城市现状用地平衡表", "城市建设用地平衡表－近期", "城市建设用地平衡表－现状", "城市建设用地平衡表－现状＋规划" };
        private void btnFindTable_Click(object sender, EventArgs e)
        {
            tabControl2.SelectTab("tabCalculateTable");

            string regFileName = cbxRegDoc.Text;
            string tablename = cbxTableList.Text;

            if (testFileName == null || testFileName.Trim() == "")
            {
                MessageBox.Show("请选择一个目标文档");
            }
            else if (regFileName == null || regFileName.Trim() == "")
            {
                MessageBox.Show("请选择一个规程文档");
            }
            else
            {
                if ((!regFileName.Equals(preRegFileName) || !testFileName.Equals(preTestFileName)
                    || cbxTableListChanged == true))
                {
                    dataView.Rows.Clear();
                    rbTableTest.Clear();

                    WaitingForm wf = new WaitingForm();
                    HandleWaitingForm.startWaitingForm(wf);

                    string path = System.Environment.CurrentDirectory;
                    string name = regFileName;
                    name = path + "\\resources\\" + name + ".doc";

                    Document regDoc = new Document();
                    HandleDocument handleDocument = new HandleDocument();


                    if (!testDocIsOpen)
                    {
                        testDocIsOpen = true;
                        testDoc = handleDocument.openDocument(testFileName, testWord);
                    }

                    regDoc = handleDocument.openDocument(name, testWord);
                    showItemInfo.Clear();
                    flagList.Clear();//清空标记合并单元格的标志
                    if (tablename != "")
                    {
                        calTables(1, regDoc, wf, tablename);
                    }
                    else
                    {
                        calTables(tableName.Length, regDoc, wf, "");
                    }
                    rbTableTest.Text = "请选择关键字";
                    KeyWord keyWord = new KeyWord();
                    //keyWord.highLightRichString(rbTableTest, testWord, testDoc, keyItemList);
                    rtbStandard.Text = keyWord.getStandardList();
                    generatekeyItemCombox();
                    
                    Object saveChanges = false;
                    object unknow = Type.Missing;

                    regDoc.Close(ref saveChanges, ref unknow, ref unknow);

                    HandleWaitingForm.closeWaitingForm(wf);

                    plTOC.Hide();
                    plKeyWord.Hide();
                    plMultiInfo.Hide();

                    plTableTest.Show();
                    showTableTreeView();
                    hideTOCTreeView();

                    cbxTableListChanged = false;
                    preRegFileName = regFileName;
                    preTestFileName = testFileName;

                    isMultiple = false;
                    tabControl2.Show();
                    tabControlMulti.Hide();
                }
            }

        }
        /***
         *   error message report content variable
         * **/
        private string reportMSG = "";
        private string textTOCMSG = "";
        private string specifiTOCMSG = "";
        private string tableMSG = "";

        private List<string> keyItemList = new List<string>();
        private void calTables(int number, Document regDoc, WaitingForm wf, string tName)
        {
            string errormsg = "";
            for (int i = 0; i < number; i++)
            {
                string title = tableName[i];
                if (number == 1)
                {
                    title = tName;
                }
                CalculateTable calTable = new CalculateTable();

                Table normalTable = calTable.getTableByName(regDoc, title, testWord);

                Table comTable = calTable.getTableByName(testDoc, title, testWord);

                if (normalTable == null)
                {
                    errormsg += regDoc.Name + "文档不存在该表格:\r" + title+"\r\r";
                    //MessageBox.Show(regDoc.Name + "文档不存在该表格:\r\r" + title);
                    continue;
                }
                if (!calTable.isNormalTable(normalTable))
                {
                    errormsg += regDoc.Name + "中:\r" + title + "不符合标准格式，无法计算\r\r";
                    //MessageBox.Show(regDoc.Name + "中:\r\r" + title + "不符合标准格式，无法计算");
                    continue;
                }
                if (comTable == null)
                {
                    errormsg += testDoc.Name + "文档不存在该表格:\r" + title + "\r\r";
                    //MessageBox.Show(testDoc.Name + "文档不存在该表格:\r\r" + title);
                    continue;
                }
                if (!calTable.isNormalTable(comTable))
                {
                    errormsg += testDoc.Name + "中:\r" + title + "不符合标准格式，无法计算\r\r";
                    //MessageBox.Show(testDoc.Name + "中:\r\r" + title + "不符合标准格式，无法计算");
                    continue;
                }

                List<string> keyList=calTable.calTableShowMssing(comTable, normalTable, dataView, showItemInfo, title,flagList);
                generateKeyItemList(keyList);
                
            }
            errormsg += showItemInfo.Text;

            if (!tableMSG.Contains(errormsg))
                tableMSG += errormsg;
        }

        private void generatekeyItemCombox()
        {
            foreach (string s in keyItemList)
            {
                keyTableItemList.Items.Add(s);
            }
        }
        private void generateKeyItemList(List<string> keyList)
        {
            if (keyList.Count != 0)
            {
                foreach (string s in keyList)
                {
                    if (!keyItemList.Contains(s))
                    {
                        keyItemList.Add(s);
                    }
                }
            }           
        }

        private bool keywordChanged = false;
        private void cbxKeyWord_TextChanged(object sender, EventArgs e)
        {
            keywordChanged = true;
        }

        private bool tocTestStarted = false;

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Object saveChanges = false;
            object unknow = Type.Missing;

            if (!isMultiple && testDocIsOpen)
            {
                testDoc.Close(ref saveChanges, ref unknow, ref unknow);
            }
            testWord.Quit(ref saveChanges, ref unknow, ref unknow);
            word.Quit(ref saveChanges, ref unknow, ref unknow);
        }

        private void cbxRegDoc_Click(object sender, EventArgs e)
        {
            cbxRegDoc.Items.Clear();
            initRegDocList();
        }

        private void testTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string currentLine = e.Node.Text;

            string nextLine = e.Node.NextVisibleNode.Text;

            string firstPage = "";
            for (int i = 0; i < currentLine.Length; i++)
            {
                if (char.IsDigit(currentLine, i) && currentLine.Length - i < 4)
                {
                    firstPage += currentLine[i];
                }
            }

            string secondPage = "";
            for (int i = 0; i < nextLine.Length; i++)
            {
                if (char.IsDigit(nextLine, i) && nextLine.Length - i < 4)
                {
                    secondPage += nextLine[i];
                }
            }
            if (firstPage == secondPage)
            {
                int a = int.Parse(secondPage) + 1;
                secondPage = a.ToString();
            }

            object What = WdGoToItem.wdGoToPage;
            object Which = WdGoToDirection.wdGoToNext;
            object Name = firstPage; // 页数
            object Name2 = secondPage;
            object Nothing = Type.Missing;

            Document doc = handleDocument.openDocument(testFileName, testWord);

            Range range1 = doc.GoTo(ref What, ref Which, ref Name, ref Nothing);
            Range range2 = doc.GoTo(ref What, ref Which, ref Name2, ref Nothing);

            object objstart = range1.Start;
            object objend = range2.End;
            string s = doc.Range(ref objstart, ref objend).Text;

            rtbTestDocContent.Text = "";
            rtbTestDocContent.Text = s;
            //MessageBox.Show( s);

            Object saveChanges = false;
            object unknow = Type.Missing;
            testDocIsOpen = false;

            doc.Close(ref saveChanges, ref unknow, ref unknow);
        }

        private string testMode = "";
        private void comboBoxLevel3_SelectedIndexChanged(object sender, EventArgs e)
        {
            testMode = comboBoxLevel3.Text;
        }

        private bool isTextMode()
        {
            return testMode == "文本";
        }

        private bool isSpecificationMode()
        {
            return testMode == "说明书";
        }

        Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
        string oldKeyWord = "";
        private void lookUpFullText_Click(object sender, EventArgs e)
        {
            string keyword = cbxKeyWord.Text;
            Boolean isPathChanged = false;
            if (preTestFileName != testFileName)
            {
                isPathChanged = true;
                preTestFileName = testFileName;
            }
            if (keyword.Trim() != "")
            {
                KeyWordCache.putKeyWordInCache(keyword, KeyWordCache.KEYWORD);
                KeyWordCache.update(cbxKeyWord, KeyWordCache.KEYWORD);

                if (testFileName != "")//检查输入不为空
                {
                    FullTextLookUp fullTextLookUp = new FullTextLookUp();
                    word = fullTextLookUp.fullTextCheck(testFileName, isPathChanged, keyword, oldKeyWord, keywordChanged, word);
                    oldKeyWord = keyword;
                    keywordChanged = false;
                }
                else
                {
                    MessageBox.Show("输入路径不能为空");
                    tabControl2.SelectTab("tabPageTest");
                }

            }
            else
            {
                MessageBox.Show("请输入关键字");
            }
        }
        bool cbxTableListChanged = false;
        private void cbxTableList_TextChanged(object sender, EventArgs e)
        {
            cbxTableListChanged = true;
        }

        #region 统计行单元格绘制
        private List<int> flagList = new List<int>();
        private void dataView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            
             if (e.ColumnIndex != -1 && isInList(e.RowIndex))
             {
                 using
                     (
                     Brush gridBrush = new SolidBrush(this.dataView.GridColor),
                     backColorBrush = new SolidBrush(e.CellStyle.BackColor)
                     )
                 {
                     using (Pen gridLinePen = new Pen(gridBrush))
                     {
                         try
                         {
                             // 清除单元格
                             if (e.Value != null)
                             {
                                 e.CellStyle.Font = new System.Drawing.Font(dataView.DefaultCellStyle.Font, FontStyle.Regular);
                                 e.CellStyle.WrapMode = DataGridViewTriState.True;
                                 e.Graphics.FillRectangle(backColorBrush, e.CellBounds);

                                 e.Handled = true;

                                 // 画 Grid 边线（仅画单元格的底边线和右边线）
                                 //   如果下一列和当前列的数据不同，则在当前的单元格画一条右边线
                                 if (e.ColumnIndex < dataView.Columns.Count - 1 &&
                                 (dataView.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value == null || dataView.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value.ToString() !=
                                 e.Value.ToString()  ))
                                     e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1,
                                     e.CellBounds.Top - 1, e.CellBounds.Right - 1,
                                     e.CellBounds.Bottom - 1);
                                 //画最后一条记录的右边线 
                                 if (e.ColumnIndex == dataView.Columns.Count - 1)
                                     e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                                 //画底边线
                                 e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left - 1,
                                 e.CellBounds.Bottom - 1, e.CellBounds.Right - 1,
                                 e.CellBounds.Bottom - 1);
                             }


                             // 画（填写）单元格内容，相同的内容的单元格只填写第一个
                             if (e.Value != null)
                             {
                                 if (e.ColumnIndex == dataView.Columns.Count - 1
                                      && dataView.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString() !=e.Value.ToString())
                                 {
                                     e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font,
                                         Brushes.Black, e.CellBounds.Left ,
                                         e.CellBounds.Top+4 , StringFormat.GenericDefault);
                                 }
                                 if (e.ColumnIndex > 0 &&
                                 dataView.Rows[e.RowIndex].Cells[e.ColumnIndex +1].Value.ToString() ==
                                 e.Value.ToString())
                                 {
                                     e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font,
                                           Brushes.Black, e.CellBounds.Left ,
                                           e.CellBounds.Top+4, StringFormat.GenericDefault);
                                 }
                                 if (e.ColumnIndex > 0 &&
                                 dataView.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value.ToString() !=
                                 e.Value.ToString() && dataView.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString() !=
                                 e.Value.ToString())
                                 {
                                     e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font,
                                           Brushes.Black, e.CellBounds.Left,
                                           e.CellBounds.Top+4, StringFormat.GenericDefault);
                                 }

                             }
                             //e.Handled = true;
                         }
                         catch
                         {
                         }
                     }
                 }


             }
             if (e.ColumnIndex == 0 && (isInList(e.RowIndex)||isInList(e.RowIndex-1)) && e.Value != null)
             {
                 if (isInList(e.RowIndex))
                 {
                     e.CellStyle.Font = new System.Drawing.Font(dataView.DefaultCellStyle.Font, FontStyle.Bold);
                     e.CellStyle.WrapMode = DataGridViewTriState.True;
                 }
                 using (
                     Brush gridBrush = new SolidBrush(this.dataView.GridColor),
                     backColorBrush = new SolidBrush(e.CellStyle.BackColor))
                 {
                     using (Pen gridLinePen = new Pen(gridBrush))
                     {
                         // 擦除原单元格背景
                         e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
                         ////绘制线条,这些线条是单元格相互间隔的区分线条,
                         ////因为我们只对列name做处理,所以datagridview自己会处理左侧和上边缘的线条
                         if (e.RowIndex != 0 && this.dataView.Rows[e.RowIndex - 1].Cells[e.ColumnIndex].Value!=null)
                         {
                             if (e.Value.ToString() != this.dataView.Rows[e.RowIndex - 1].Cells[e.ColumnIndex].Value.ToString())
                             {
                                 e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Top - 1,
                                 e.CellBounds.Right - 1, e.CellBounds.Top - 1);//上边缘的线
                                 e.Handled = true;
                                 //绘制值
                                 if (e.Value != null)
                                 {
                                     e.Graphics.DrawString((String)e.Value, e.CellStyle.Font,
                                         Brushes.Black, e.CellBounds.Left,
                                         e.CellBounds.Top + 4, StringFormat.GenericDefault);
                                 }
                             }
                         }
                         else
                         {
                             //e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1,
                             //e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);//下边缘的线
                             //绘制值
                             if (e.Value != null)
                             {
                                 e.Graphics.DrawString((String)e.Value, e.CellStyle.Font,
                                     Brushes.Black, e.CellBounds.Left,
                                     e.CellBounds.Top + 4, StringFormat.GenericDefault);
                             }
                         }
                         if (isInList(e.RowIndex - 1))
                         {
                             e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1,
                             e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);//下边缘的线
                         }
                         //右侧的线
                         e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1,
                             e.CellBounds.Top, e.CellBounds.Right - 1,
                             e.CellBounds.Bottom - 1);
                         e.Handled = true;
                     }
                 }
             }
        }
        #endregion
        private Boolean isInList(int index)
        {

            if(flagList.Contains(index))
            {
                return true;
            }
            return false;
        }

        private void keyTableItemList_SelectedIndexChanged(object sender, EventArgs e)
        {
            WaitingForm wf = new WaitingForm();
            HandleWaitingForm.startWaitingForm(wf);
            List<string> list = new List<string>();
            if (!testDocIsOpen)
            {
                testDocIsOpen = true;
                testDoc = handleDocument.openDocument(testFileName, testWord);
            }
            list.Add((string)keyTableItemList.SelectedItem);
            KeyWord keyWord = new KeyWord();
            keyWord.highLightRichString(rbTableTest, testWord, testDoc,list);

            HandleWaitingForm.closeWaitingForm(wf);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reportMSG += tableMSG;
            MessageBox.Show(reportMSG);
        }
    }
}
