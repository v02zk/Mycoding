
using System.IO;
using System.Text;

namespace WindowsFormsApplication2
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.新建ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlFunction = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label16 = new System.Windows.Forms.Label();
            this.comboBoxLevel3 = new System.Windows.Forms.ComboBox();
            this.comboBoxLevel2 = new System.Windows.Forms.ComboBox();
            this.comboBoxLevel1 = new System.Windows.Forms.ComboBox();
            this.btnTestTOC = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnCalTable = new System.Windows.Forms.Button();
            this.cbxTableList = new System.Windows.Forms.ComboBox();
            this.btnTestTable = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lookUpFullText = new System.Windows.Forms.Button();
            this.btnKeyWordSelect = new System.Windows.Forms.Button();
            this.cbxKeyWord = new System.Windows.Forms.ComboBox();
            this.btnFindKeyWord = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnTestValue = new System.Windows.Forms.Button();
            this.cbxRegDoc = new System.Windows.Forms.ComboBox();
            this.btnRegSelect = new System.Windows.Forms.Button();
            this.btnTestFileSelect = new System.Windows.Forms.Button();
            this.testDocLabel = new System.Windows.Forms.TextBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPageTest = new System.Windows.Forms.TabPage();
            this.panelTest = new System.Windows.Forms.Panel();
            this.tvRegTable = new System.Windows.Forms.TreeView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.testTreeView = new System.Windows.Forms.TreeView();
            this.regTreeView = new System.Windows.Forms.TreeView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tvTestTable = new System.Windows.Forms.TreeView();
            this.tabPageFind = new System.Windows.Forms.TabPage();
            this.panelFind = new System.Windows.Forms.Panel();
            this.richTxbRegDoc = new System.Windows.Forms.RichTextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelRegDoc = new System.Windows.Forms.Label();
            this.richTxbTestDoc = new System.Windows.Forms.RichTextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.labelTestDoc = new System.Windows.Forms.Label();
            this.tabCalculateTable = new System.Windows.Forms.TabPage();
            this.keyTableItemList = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.rbTableTest = new System.Windows.Forms.RichTextBox();
            this.dataView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMultipleDocCompare = new System.Windows.Forms.Button();
            this.btnTwoDocCompare = new System.Windows.Forms.Button();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.plKeyWord = new System.Windows.Forms.Panel();
            this.lbKeyWordValueSingle = new System.Windows.Forms.Label();
            this.lbKeyWordSingle = new System.Windows.Forms.Label();
            this.lbValueLabelSingle = new System.Windows.Forms.Label();
            this.lbkwLabelSingle = new System.Windows.Forms.Label();
            this.lbCountItems = new System.Windows.Forms.Label();
            this.rtbKeyWord = new System.Windows.Forms.RichTextBox();
            this.plInfo = new System.Windows.Forms.Panel();
            this.lbInfo = new System.Windows.Forms.Label();
            this.plTOC = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.rtbTestDocContent = new System.Windows.Forms.RichTextBox();
            this.lbMissText = new System.Windows.Forms.Label();
            this.lbSpareText = new System.Windows.Forms.Label();
            this.lbErrorText = new System.Windows.Forms.Label();
            this.lbMiss = new System.Windows.Forms.Label();
            this.lbSpare = new System.Windows.Forms.Label();
            this.lbError = new System.Windows.Forms.Label();
            this.rtbMSG = new System.Windows.Forms.RichTextBox();
            this.plTOCTip = new System.Windows.Forms.Panel();
            this.lbTermTitle = new System.Windows.Forms.Label();
            this.lbTOCTip = new System.Windows.Forms.Label();
            this.plTableTest = new System.Windows.Forms.Panel();
            this.rtbStandard = new System.Windows.Forms.RichTextBox();
            this.panel16 = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.showItemInfo = new System.Windows.Forms.RichTextBox();
            this.tabControlMulti = new System.Windows.Forms.TabControl();
            this.tabPageMultiDoc = new System.Windows.Forms.TabPage();
            this.panel8 = new System.Windows.Forms.Panel();
            this.rtbSpecificationDoc = new System.Windows.Forms.RichTextBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.btnDelMuti3 = new System.Windows.Forms.Button();
            this.btnMultiSelectSpecDoc = new System.Windows.Forms.Button();
            this.txbMultiSpecification = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.rtbRegDoc = new System.Windows.Forms.RichTextBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btnDelMuti2 = new System.Windows.Forms.Button();
            this.btnMultiSelectRegDoc = new System.Windows.Forms.Button();
            this.txbMultiReg = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rtbTestDoc = new System.Windows.Forms.RichTextBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnDelMuti1 = new System.Windows.Forms.Button();
            this.btnMultiSelectTestDoc = new System.Windows.Forms.Button();
            this.txbMultiTest = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.plMultiInfo = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.lbkwLabel = new System.Windows.Forms.Label();
            this.lbKeyWordValue = new System.Windows.Forms.Label();
            this.lbKeyWord = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.rtbMultiSpecDoc = new System.Windows.Forms.RichTextBox();
            this.rtbMultiRegDoc = new System.Windows.Forms.RichTextBox();
            this.rtxMultiTestDoc = new System.Windows.Forms.RichTextBox();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.多文档查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControlFunction.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPageTest.SuspendLayout();
            this.panelTest.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPageFind.SuspendLayout();
            this.panelFind.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tabCalculateTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
            this.panel1.SuspendLayout();
            this.plKeyWord.SuspendLayout();
            this.plInfo.SuspendLayout();
            this.plTOC.SuspendLayout();
            this.panel2.SuspendLayout();
            this.plTOCTip.SuspendLayout();
            this.plTableTest.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tabControlMulti.SuspendLayout();
            this.tabPageMultiDoc.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.plMultiInfo.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel12.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // 新建ToolStripMenuItem1
            // 
            this.新建ToolStripMenuItem1.Name = "新建ToolStripMenuItem1";
            this.新建ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.新建ToolStripMenuItem1.Text = "新建";
            // 
            // tabControlFunction
            // 
            this.tabControlFunction.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tabControlFunction.Controls.Add(this.tabPage1);
            this.tabControlFunction.Controls.Add(this.tabPage2);
            this.tabControlFunction.Controls.Add(this.tabPage3);
            this.tabControlFunction.Controls.Add(this.tabPage4);
            this.tabControlFunction.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tabControlFunction.Location = new System.Drawing.Point(358, 29);
            this.tabControlFunction.Name = "tabControlFunction";
            this.tabControlFunction.SelectedIndex = 0;
            this.tabControlFunction.Size = new System.Drawing.Size(415, 124);
            this.tabControlFunction.TabIndex = 6;
            this.tabControlFunction.SelectedIndexChanged += new System.EventHandler(this.tabControlFunction_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.comboBoxLevel3);
            this.tabPage1.Controls.Add(this.comboBoxLevel2);
            this.tabPage1.Controls.Add(this.comboBoxLevel1);
            this.tabPage1.Controls.Add(this.btnTestTOC);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(407, 90);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "目录检测";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(16, 12);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(68, 17);
            this.label16.TabIndex = 19;
            this.label16.Text = "请选择规范";
            // 
            // comboBoxLevel3
            // 
            this.comboBoxLevel3.FormattingEnabled = true;
            this.comboBoxLevel3.Location = new System.Drawing.Point(183, 39);
            this.comboBoxLevel3.Name = "comboBoxLevel3";
            this.comboBoxLevel3.Size = new System.Drawing.Size(86, 29);
            this.comboBoxLevel3.TabIndex = 18;
            this.comboBoxLevel3.SelectedIndexChanged += new System.EventHandler(this.comboBoxLevel3_SelectedIndexChanged);
            // 
            // comboBoxLevel2
            // 
            this.comboBoxLevel2.FormattingEnabled = true;
            this.comboBoxLevel2.Location = new System.Drawing.Point(107, 39);
            this.comboBoxLevel2.Name = "comboBoxLevel2";
            this.comboBoxLevel2.Size = new System.Drawing.Size(77, 29);
            this.comboBoxLevel2.TabIndex = 17;
            this.comboBoxLevel2.SelectedIndexChanged += new System.EventHandler(this.comboBoxLevel2_SelectedIndexChanged);
            // 
            // comboBoxLevel1
            // 
            this.comboBoxLevel1.FormattingEnabled = true;
            this.comboBoxLevel1.Location = new System.Drawing.Point(13, 39);
            this.comboBoxLevel1.Name = "comboBoxLevel1";
            this.comboBoxLevel1.Size = new System.Drawing.Size(95, 29);
            this.comboBoxLevel1.TabIndex = 16;
            this.comboBoxLevel1.SelectedIndexChanged += new System.EventHandler(this.comboBoxLevel1_SelectedIndexChanged);
            // 
            // btnTestTOC
            // 
            this.btnTestTOC.BackColor = System.Drawing.SystemColors.Window;
            this.btnTestTOC.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTestTOC.BackgroundImage")));
            this.btnTestTOC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestTOC.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnTestTOC.Location = new System.Drawing.Point(288, 37);
            this.btnTestTOC.Name = "btnTestTOC";
            this.btnTestTOC.Size = new System.Drawing.Size(107, 32);
            this.btnTestTOC.TabIndex = 13;
            this.btnTestTOC.Text = "执行检测";
            this.btnTestTOC.UseVisualStyleBackColor = false;
            this.btnTestTOC.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.btnCalTable);
            this.tabPage2.Controls.Add(this.cbxTableList);
            this.tabPage2.Controls.Add(this.btnTestTable);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(407, 90);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "表格检测";
            // 
            // btnCalTable
            // 
            this.btnCalTable.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCalTable.BackgroundImage")));
            this.btnCalTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalTable.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnCalTable.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCalTable.Location = new System.Drawing.Point(252, 11);
            this.btnCalTable.Name = "btnCalTable";
            this.btnCalTable.Size = new System.Drawing.Size(124, 29);
            this.btnCalTable.TabIndex = 16;
            this.btnCalTable.Text = "查找表格";
            this.btnCalTable.UseVisualStyleBackColor = true;
            this.btnCalTable.Click += new System.EventHandler(this.btnFindTable_Click);
            // 
            // cbxTableList
            // 
            this.cbxTableList.FormattingEnabled = true;
            this.cbxTableList.Location = new System.Drawing.Point(26, 11);
            this.cbxTableList.Name = "cbxTableList";
            this.cbxTableList.Size = new System.Drawing.Size(199, 29);
            this.cbxTableList.TabIndex = 15;
            this.cbxTableList.TextChanged += new System.EventHandler(this.cbxTableList_TextChanged);
            // 
            // btnTestTable
            // 
            this.btnTestTable.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTestTable.BackgroundImage")));
            this.btnTestTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestTable.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnTestTable.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnTestTable.Location = new System.Drawing.Point(253, 52);
            this.btnTestTable.Name = "btnTestTable";
            this.btnTestTable.Size = new System.Drawing.Size(124, 29);
            this.btnTestTable.TabIndex = 14;
            this.btnTestTable.Text = "执行检测";
            this.btnTestTable.UseVisualStyleBackColor = true;
            this.btnTestTable.Click += new System.EventHandler(this.btnTestTable_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(862, 95);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(87, 23);
            this.button4.TabIndex = 13;
            this.button4.Text = "查找";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(862, 55);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "匹配";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage3.Controls.Add(this.lookUpFullText);
            this.tabPage3.Controls.Add(this.btnKeyWordSelect);
            this.tabPage3.Controls.Add(this.cbxKeyWord);
            this.tabPage3.Controls.Add(this.btnFindKeyWord);
            this.tabPage3.Location = new System.Drawing.Point(4, 30);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(407, 90);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "关键字查询";
            // 
            // lookUpFullText
            // 
            this.lookUpFullText.Location = new System.Drawing.Point(243, 57);
            this.lookUpFullText.Name = "lookUpFullText";
            this.lookUpFullText.Size = new System.Drawing.Size(135, 31);
            this.lookUpFullText.TabIndex = 20;
            this.lookUpFullText.Text = "全文查找";
            this.lookUpFullText.UseVisualStyleBackColor = true;
            this.lookUpFullText.Click += new System.EventHandler(this.lookUpFullText_Click);
            // 
            // btnKeyWordSelect
            // 
            this.btnKeyWordSelect.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnKeyWordSelect.BackgroundImage")));
            this.btnKeyWordSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeyWordSelect.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnKeyWordSelect.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnKeyWordSelect.Location = new System.Drawing.Point(278, 19);
            this.btnKeyWordSelect.Name = "btnKeyWordSelect";
            this.btnKeyWordSelect.Size = new System.Drawing.Size(87, 28);
            this.btnKeyWordSelect.TabIndex = 18;
            this.btnKeyWordSelect.Text = "选择";
            this.btnKeyWordSelect.UseVisualStyleBackColor = true;
            this.btnKeyWordSelect.Click += new System.EventHandler(this.btnKeyWordSelect_Click);
            // 
            // cbxKeyWord
            // 
            this.cbxKeyWord.FormattingEnabled = true;
            this.cbxKeyWord.ItemHeight = 21;
            this.cbxKeyWord.Location = new System.Drawing.Point(55, 19);
            this.cbxKeyWord.Name = "cbxKeyWord";
            this.cbxKeyWord.Size = new System.Drawing.Size(217, 29);
            this.cbxKeyWord.TabIndex = 19;
            this.cbxKeyWord.SelectedIndexChanged += new System.EventHandler(this.cbxKeyWord_SelectedIndexChanged);
            this.cbxKeyWord.TextChanged += new System.EventHandler(this.cbxKeyWord_TextChanged);
            // 
            // btnFindKeyWord
            // 
            this.btnFindKeyWord.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFindKeyWord.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFindKeyWord.BackgroundImage")));
            this.btnFindKeyWord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindKeyWord.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnFindKeyWord.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnFindKeyWord.Location = new System.Drawing.Point(55, 57);
            this.btnFindKeyWord.Name = "btnFindKeyWord";
            this.btnFindKeyWord.Size = new System.Drawing.Size(135, 31);
            this.btnFindKeyWord.TabIndex = 14;
            this.btnFindKeyWord.Text = "查找";
            this.btnFindKeyWord.UseVisualStyleBackColor = false;
            this.btnFindKeyWord.Click += new System.EventHandler(this.btnFindKeyWord_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage4.Controls.Add(this.button1);
            this.tabPage4.Controls.Add(this.comboBox1);
            this.tabPage4.Controls.Add(this.btnTestValue);
            this.tabPage4.Location = new System.Drawing.Point(4, 30);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(407, 90);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "规范检测";
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.button1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Location = new System.Drawing.Point(278, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 28);
            this.button1.TabIndex = 21;
            this.button1.Text = "选择";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ItemHeight = 21;
            this.comboBox1.Location = new System.Drawing.Point(55, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(217, 29);
            this.comboBox1.TabIndex = 22;
            // 
            // btnTestValue
            // 
            this.btnTestValue.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTestValue.BackgroundImage")));
            this.btnTestValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestValue.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnTestValue.Location = new System.Drawing.Point(55, 57);
            this.btnTestValue.Name = "btnTestValue";
            this.btnTestValue.Size = new System.Drawing.Size(310, 31);
            this.btnTestValue.TabIndex = 20;
            this.btnTestValue.Text = "查找";
            this.btnTestValue.UseVisualStyleBackColor = true;
            this.btnTestValue.Click += new System.EventHandler(this.btnTestValue_Click);
            // 
            // cbxRegDoc
            // 
            this.cbxRegDoc.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxRegDoc.FormattingEnabled = true;
            this.cbxRegDoc.Location = new System.Drawing.Point(88, 3);
            this.cbxRegDoc.Name = "cbxRegDoc";
            this.cbxRegDoc.Size = new System.Drawing.Size(202, 29);
            this.cbxRegDoc.TabIndex = 20;
            this.cbxRegDoc.Click += new System.EventHandler(this.cbxRegDoc_Click);
            // 
            // btnRegSelect
            // 
            this.btnRegSelect.BackColor = System.Drawing.Color.White;
            this.btnRegSelect.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRegSelect.BackgroundImage")));
            this.btnRegSelect.FlatAppearance.BorderSize = 0;
            this.btnRegSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegSelect.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRegSelect.Location = new System.Drawing.Point(309, 6);
            this.btnRegSelect.Name = "btnRegSelect";
            this.btnRegSelect.Size = new System.Drawing.Size(75, 23);
            this.btnRegSelect.TabIndex = 17;
            this.btnRegSelect.UseVisualStyleBackColor = false;
            this.btnRegSelect.Click += new System.EventHandler(this.btnRegSelect_Click);
            // 
            // btnTestFileSelect
            // 
            this.btnTestFileSelect.AutoSize = true;
            this.btnTestFileSelect.BackColor = System.Drawing.Color.White;
            this.btnTestFileSelect.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTestFileSelect.BackgroundImage")));
            this.btnTestFileSelect.FlatAppearance.BorderSize = 0;
            this.btnTestFileSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestFileSelect.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTestFileSelect.Location = new System.Drawing.Point(309, 6);
            this.btnTestFileSelect.Name = "btnTestFileSelect";
            this.btnTestFileSelect.Size = new System.Drawing.Size(75, 23);
            this.btnTestFileSelect.TabIndex = 11;
            this.btnTestFileSelect.UseVisualStyleBackColor = false;
            this.btnTestFileSelect.Click += new System.EventHandler(this.btnTestFileSelect_Click);
            // 
            // testDocLabel
            // 
            this.testDocLabel.BackColor = System.Drawing.SystemColors.Window;
            this.testDocLabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.testDocLabel.Location = new System.Drawing.Point(88, 3);
            this.testDocLabel.Name = "testDocLabel";
            this.testDocLabel.ReadOnly = true;
            this.testDocLabel.Size = new System.Drawing.Size(190, 29);
            this.testDocLabel.TabIndex = 8;
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tabControl2.Controls.Add(this.tabPageTest);
            this.tabControl2.Controls.Add(this.tabPageFind);
            this.tabControl2.Controls.Add(this.tabCalculateTable);
            this.tabControl2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tabControl2.Location = new System.Drawing.Point(11, 156);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(827, 770);
            this.tabControl2.TabIndex = 7;
            // 
            // tabPageTest
            // 
            this.tabPageTest.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPageTest.Controls.Add(this.panelTest);
            this.tabPageTest.Location = new System.Drawing.Point(4, 30);
            this.tabPageTest.Name = "tabPageTest";
            this.tabPageTest.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTest.Size = new System.Drawing.Size(819, 736);
            this.tabPageTest.TabIndex = 0;
            this.tabPageTest.Text = "匹配";
            // 
            // panelTest
            // 
            this.panelTest.Controls.Add(this.tvRegTable);
            this.panelTest.Controls.Add(this.panel6);
            this.panelTest.Controls.Add(this.testTreeView);
            this.panelTest.Controls.Add(this.regTreeView);
            this.panelTest.Controls.Add(this.panel3);
            this.panelTest.Controls.Add(this.tvTestTable);
            this.panelTest.Location = new System.Drawing.Point(6, 8);
            this.panelTest.Name = "panelTest";
            this.panelTest.Size = new System.Drawing.Size(810, 735);
            this.panelTest.TabIndex = 11;
            // 
            // tvRegTable
            // 
            this.tvRegTable.Location = new System.Drawing.Point(9, 43);
            this.tvRegTable.Name = "tvRegTable";
            this.tvRegTable.Size = new System.Drawing.Size(390, 685);
            this.tvRegTable.TabIndex = 12;
            this.tvRegTable.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.regTreeView_AfterSelect);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.testDocLabel);
            this.panel6.Controls.Add(this.btnTestFileSelect);
            this.panel6.Location = new System.Drawing.Point(410, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(390, 34);
            this.panel6.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DarkGray;
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "目标文件";
            // 
            // testTreeView
            // 
            this.testTreeView.BackColor = System.Drawing.Color.White;
            this.testTreeView.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.testTreeView.ItemHeight = 30;
            this.testTreeView.Location = new System.Drawing.Point(410, 43);
            this.testTreeView.Name = "testTreeView";
            this.testTreeView.ShowRootLines = false;
            this.testTreeView.Size = new System.Drawing.Size(390, 685);
            this.testTreeView.TabIndex = 0;
            this.testTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.testTreeView_AfterSelect);
            // 
            // regTreeView
            // 
            this.regTreeView.BackColor = System.Drawing.Color.White;
            this.regTreeView.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.regTreeView.ItemHeight = 30;
            this.regTreeView.Location = new System.Drawing.Point(9, 43);
            this.regTreeView.Name = "regTreeView";
            this.regTreeView.Size = new System.Drawing.Size(390, 685);
            this.regTreeView.TabIndex = 8;
            this.regTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.regTreeView_AfterSelect);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel3.Controls.Add(this.btnRegSelect);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.cbxRegDoc);
            this.panel3.Location = new System.Drawing.Point(9, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(390, 34);
            this.panel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkGray;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "规程文件";
            // 
            // tvTestTable
            // 
            this.tvTestTable.Location = new System.Drawing.Point(410, 43);
            this.tvTestTable.Name = "tvTestTable";
            this.tvTestTable.Size = new System.Drawing.Size(390, 685);
            this.tvTestTable.TabIndex = 12;
            // 
            // tabPageFind
            // 
            this.tabPageFind.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPageFind.Controls.Add(this.panelFind);
            this.tabPageFind.Location = new System.Drawing.Point(4, 30);
            this.tabPageFind.Name = "tabPageFind";
            this.tabPageFind.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFind.Size = new System.Drawing.Size(819, 736);
            this.tabPageFind.TabIndex = 1;
            this.tabPageFind.Text = "查找";
            // 
            // panelFind
            // 
            this.panelFind.Controls.Add(this.richTxbRegDoc);
            this.panelFind.Controls.Add(this.panel4);
            this.panelFind.Controls.Add(this.richTxbTestDoc);
            this.panelFind.Controls.Add(this.panel5);
            this.panelFind.Location = new System.Drawing.Point(6, 8);
            this.panelFind.Name = "panelFind";
            this.panelFind.Size = new System.Drawing.Size(810, 725);
            this.panelFind.TabIndex = 10;
            // 
            // richTxbRegDoc
            // 
            this.richTxbRegDoc.Location = new System.Drawing.Point(7, 408);
            this.richTxbRegDoc.Name = "richTxbRegDoc";
            this.richTxbRegDoc.ReadOnly = true;
            this.richTxbRegDoc.Size = new System.Drawing.Size(784, 303);
            this.richTxbRegDoc.TabIndex = 7;
            this.richTxbRegDoc.Text = "";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel4.Controls.Add(this.labelRegDoc);
            this.panel4.Location = new System.Drawing.Point(7, 361);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(784, 34);
            this.panel4.TabIndex = 6;
            // 
            // labelRegDoc
            // 
            this.labelRegDoc.AutoSize = true;
            this.labelRegDoc.ForeColor = System.Drawing.Color.DarkGray;
            this.labelRegDoc.Location = new System.Drawing.Point(20, 8);
            this.labelRegDoc.Name = "labelRegDoc";
            this.labelRegDoc.Size = new System.Drawing.Size(106, 21);
            this.labelRegDoc.TabIndex = 0;
            this.labelRegDoc.Text = "成果规程文档";
            // 
            // richTxbTestDoc
            // 
            this.richTxbTestDoc.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTxbTestDoc.Location = new System.Drawing.Point(7, 46);
            this.richTxbTestDoc.Name = "richTxbTestDoc";
            this.richTxbTestDoc.ReadOnly = true;
            this.richTxbTestDoc.Size = new System.Drawing.Size(784, 303);
            this.richTxbTestDoc.TabIndex = 5;
            this.richTxbTestDoc.Text = "";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel5.Controls.Add(this.labelTestDoc);
            this.panel5.Location = new System.Drawing.Point(7, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(784, 34);
            this.panel5.TabIndex = 0;
            // 
            // labelTestDoc
            // 
            this.labelTestDoc.AutoSize = true;
            this.labelTestDoc.ForeColor = System.Drawing.Color.DarkGray;
            this.labelTestDoc.Location = new System.Drawing.Point(20, 8);
            this.labelTestDoc.Name = "labelTestDoc";
            this.labelTestDoc.Size = new System.Drawing.Size(74, 21);
            this.labelTestDoc.TabIndex = 0;
            this.labelTestDoc.Text = "目标文档";
            // 
            // tabCalculateTable
            // 
            this.tabCalculateTable.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabCalculateTable.Controls.Add(this.keyTableItemList);
            this.tabCalculateTable.Controls.Add(this.label21);
            this.tabCalculateTable.Controls.Add(this.label20);
            this.tabCalculateTable.Controls.Add(this.label19);
            this.tabCalculateTable.Controls.Add(this.label18);
            this.tabCalculateTable.Controls.Add(this.label17);
            this.tabCalculateTable.Controls.Add(this.rbTableTest);
            this.tabCalculateTable.Controls.Add(this.dataView);
            this.tabCalculateTable.Location = new System.Drawing.Point(4, 30);
            this.tabCalculateTable.Name = "tabCalculateTable";
            this.tabCalculateTable.Padding = new System.Windows.Forms.Padding(3);
            this.tabCalculateTable.Size = new System.Drawing.Size(819, 736);
            this.tabCalculateTable.TabIndex = 2;
            this.tabCalculateTable.Text = "表格计算";
            // 
            // keyTableItemList
            // 
            this.keyTableItemList.FormattingEnabled = true;
            this.keyTableItemList.Location = new System.Drawing.Point(113, 331);
            this.keyTableItemList.Name = "keyTableItemList";
            this.keyTableItemList.Size = new System.Drawing.Size(121, 29);
            this.keyTableItemList.TabIndex = 7;
            this.keyTableItemList.SelectedIndexChanged += new System.EventHandler(this.keyTableItemList_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label21.Location = new System.Drawing.Point(15, 8);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(92, 17);
            this.label21.TabIndex = 6;
            this.label21.Text = "表格计算结果：";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("微软雅黑", 7F);
            this.label20.Location = new System.Drawing.Point(645, 698);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(108, 16);
            this.label20.TabIndex = 5;
            this.label20.Text = "红色表示计算有误数据";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("微软雅黑", 7F);
            this.label19.Location = new System.Drawing.Point(639, 681);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(128, 16);
            this.label19.TabIndex = 4;
            this.label19.Text = "（计）表示计算之后的数值";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("微软雅黑", 7F);
            this.label18.Location = new System.Drawing.Point(619, 665);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(138, 16);
            this.label18.TabIndex = 3;
            this.label18.Text = "注：（原）表示文档原始数值";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label17.Location = new System.Drawing.Point(12, 337);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(104, 17);
            this.label17.TabIndex = 2;
            this.label17.Text = "关键字搜索结果：";
            // 
            // rbTableTest
            // 
            this.rbTableTest.BackColor = System.Drawing.SystemColors.Control;
            this.rbTableTest.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbTableTest.Location = new System.Drawing.Point(13, 367);
            this.rbTableTest.Name = "rbTableTest";
            this.rbTableTest.Size = new System.Drawing.Size(795, 248);
            this.rbTableTest.TabIndex = 1;
            this.rbTableTest.Text = "";
            // 
            // dataView
            // 
            this.dataView.AllowUserToAddRows = false;
            this.dataView.AllowUserToDeleteRows = false;
            this.dataView.AllowUserToResizeColumns = false;
            this.dataView.AllowUserToResizeRows = false;
            this.dataView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dataView.BackgroundColor = System.Drawing.Color.White;
            this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataView.Location = new System.Drawing.Point(12, 28);
            this.dataView.Name = "dataView";
            this.dataView.ReadOnly = true;
            this.dataView.RowTemplate.Height = 23;
            this.dataView.Size = new System.Drawing.Size(795, 300);
            this.dataView.TabIndex = 0;
            this.dataView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataView_CellPainting);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.btnMultipleDocCompare);
            this.panel1.Controls.Add(this.btnTwoDocCompare);
            this.panel1.Location = new System.Drawing.Point(12, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(293, 107);
            this.panel1.TabIndex = 8;
            // 
            // btnMultipleDocCompare
            // 
            this.btnMultipleDocCompare.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMultipleDocCompare.BackgroundImage")));
            this.btnMultipleDocCompare.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnMultipleDocCompare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMultipleDocCompare.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnMultipleDocCompare.Location = new System.Drawing.Point(173, 19);
            this.btnMultipleDocCompare.Name = "btnMultipleDocCompare";
            this.btnMultipleDocCompare.Size = new System.Drawing.Size(77, 71);
            this.btnMultipleDocCompare.TabIndex = 1;
            this.btnMultipleDocCompare.UseVisualStyleBackColor = true;
            this.btnMultipleDocCompare.Click += new System.EventHandler(this.btnMultipleDocCompare_Click);
            // 
            // btnTwoDocCompare
            // 
            this.btnTwoDocCompare.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTwoDocCompare.BackgroundImage")));
            this.btnTwoDocCompare.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnTwoDocCompare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTwoDocCompare.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnTwoDocCompare.Location = new System.Drawing.Point(36, 19);
            this.btnTwoDocCompare.Name = "btnTwoDocCompare";
            this.btnTwoDocCompare.Size = new System.Drawing.Size(77, 71);
            this.btnTwoDocCompare.TabIndex = 0;
            this.btnTwoDocCompare.UseVisualStyleBackColor = true;
            this.btnTwoDocCompare.Click += new System.EventHandler(this.btnTwoDocCompare_Click);
            // 
            // listBox3
            // 
            this.listBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBox3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 21;
            this.listBox3.Location = new System.Drawing.Point(854, 182);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(392, 718);
            this.listBox3.TabIndex = 3;
            // 
            // listBox2
            // 
            this.listBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 16;
            this.listBox2.Location = new System.Drawing.Point(854, 115);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(392, 68);
            this.listBox2.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(880, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 30);
            this.label3.TabIndex = 11;
            this.label3.Text = "统计信息";
            // 
            // plKeyWord
            // 
            this.plKeyWord.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.plKeyWord.BackColor = System.Drawing.SystemColors.Window;
            this.plKeyWord.Controls.Add(this.lbKeyWordValueSingle);
            this.plKeyWord.Controls.Add(this.lbKeyWordSingle);
            this.plKeyWord.Controls.Add(this.lbValueLabelSingle);
            this.plKeyWord.Controls.Add(this.lbkwLabelSingle);
            this.plKeyWord.Controls.Add(this.lbCountItems);
            this.plKeyWord.Controls.Add(this.rtbKeyWord);
            this.plKeyWord.Controls.Add(this.plInfo);
            this.plKeyWord.Location = new System.Drawing.Point(855, 200);
            this.plKeyWord.Name = "plKeyWord";
            this.plKeyWord.Size = new System.Drawing.Size(390, 587);
            this.plKeyWord.TabIndex = 20;
            // 
            // lbKeyWordValueSingle
            // 
            this.lbKeyWordValueSingle.AutoSize = true;
            this.lbKeyWordValueSingle.Location = new System.Drawing.Point(125, 121);
            this.lbKeyWordValueSingle.Name = "lbKeyWordValueSingle";
            this.lbKeyWordValueSingle.Size = new System.Drawing.Size(0, 16);
            this.lbKeyWordValueSingle.TabIndex = 6;
            // 
            // lbKeyWordSingle
            // 
            this.lbKeyWordSingle.AutoSize = true;
            this.lbKeyWordSingle.Location = new System.Drawing.Point(125, 71);
            this.lbKeyWordSingle.Name = "lbKeyWordSingle";
            this.lbKeyWordSingle.Size = new System.Drawing.Size(0, 16);
            this.lbKeyWordSingle.TabIndex = 5;
            // 
            // lbValueLabelSingle
            // 
            this.lbValueLabelSingle.AutoSize = true;
            this.lbValueLabelSingle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbValueLabelSingle.Location = new System.Drawing.Point(18, 121);
            this.lbValueLabelSingle.Name = "lbValueLabelSingle";
            this.lbValueLabelSingle.Size = new System.Drawing.Size(74, 21);
            this.lbValueLabelSingle.TabIndex = 4;
            this.lbValueLabelSingle.Text = "标准规范";
            // 
            // lbkwLabelSingle
            // 
            this.lbkwLabelSingle.AutoSize = true;
            this.lbkwLabelSingle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbkwLabelSingle.Location = new System.Drawing.Point(18, 71);
            this.lbkwLabelSingle.Name = "lbkwLabelSingle";
            this.lbkwLabelSingle.Size = new System.Drawing.Size(58, 21);
            this.lbkwLabelSingle.TabIndex = 3;
            this.lbkwLabelSingle.Text = "关键字";
            // 
            // lbCountItems
            // 
            this.lbCountItems.AutoSize = true;
            this.lbCountItems.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbCountItems.Location = new System.Drawing.Point(20, 26);
            this.lbCountItems.Name = "lbCountItems";
            this.lbCountItems.Size = new System.Drawing.Size(0, 16);
            this.lbCountItems.TabIndex = 2;
            // 
            // rtbKeyWord
            // 
            this.rtbKeyWord.Location = new System.Drawing.Point(7, 247);
            this.rtbKeyWord.Name = "rtbKeyWord";
            this.rtbKeyWord.ReadOnly = true;
            this.rtbKeyWord.Size = new System.Drawing.Size(380, 330);
            this.rtbKeyWord.TabIndex = 1;
            this.rtbKeyWord.Text = "";
            // 
            // plInfo
            // 
            this.plInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.plInfo.Controls.Add(this.lbInfo);
            this.plInfo.Location = new System.Drawing.Point(7, 197);
            this.plInfo.Name = "plInfo";
            this.plInfo.Size = new System.Drawing.Size(377, 32);
            this.plInfo.TabIndex = 0;
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbInfo.Location = new System.Drawing.Point(7, 6);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(78, 21);
            this.lbInfo.TabIndex = 0;
            this.lbInfo.Text = "统计信息:";
            // 
            // plTOC
            // 
            this.plTOC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.plTOC.BackColor = System.Drawing.SystemColors.Window;
            this.plTOC.Controls.Add(this.panel2);
            this.plTOC.Controls.Add(this.rtbTestDocContent);
            this.plTOC.Controls.Add(this.lbMissText);
            this.plTOC.Controls.Add(this.lbSpareText);
            this.plTOC.Controls.Add(this.lbErrorText);
            this.plTOC.Controls.Add(this.lbMiss);
            this.plTOC.Controls.Add(this.lbSpare);
            this.plTOC.Controls.Add(this.lbError);
            this.plTOC.Controls.Add(this.rtbMSG);
            this.plTOC.Controls.Add(this.plTOCTip);
            this.plTOC.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.plTOC.Location = new System.Drawing.Point(855, 200);
            this.plTOC.Name = "plTOC";
            this.plTOC.Size = new System.Drawing.Size(390, 698);
            this.plTOC.TabIndex = 21;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel2.Location = new System.Drawing.Point(5, 85);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(380, 32);
            this.panel2.TabIndex = 30;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(93, 5);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 21);
            this.label12.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 5);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 21);
            this.label13.TabIndex = 0;
            this.label13.Text = "文档内容: ";
            // 
            // rtbTestDocContent
            // 
            this.rtbTestDocContent.BackColor = System.Drawing.SystemColors.Control;
            this.rtbTestDocContent.Location = new System.Drawing.Point(5, 123);
            this.rtbTestDocContent.Name = "rtbTestDocContent";
            this.rtbTestDocContent.Size = new System.Drawing.Size(380, 241);
            this.rtbTestDocContent.TabIndex = 29;
            this.rtbTestDocContent.Text = "";
            // 
            // lbMissText
            // 
            this.lbMissText.AutoSize = true;
            this.lbMissText.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbMissText.Font = new System.Drawing.Font("宋体", 8F);
            this.lbMissText.Location = new System.Drawing.Point(72, 57);
            this.lbMissText.Name = "lbMissText";
            this.lbMissText.Size = new System.Drawing.Size(0, 11);
            this.lbMissText.TabIndex = 28;
            // 
            // lbSpareText
            // 
            this.lbSpareText.AutoSize = true;
            this.lbSpareText.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbSpareText.Font = new System.Drawing.Font("宋体", 8F);
            this.lbSpareText.Location = new System.Drawing.Point(72, 34);
            this.lbSpareText.Name = "lbSpareText";
            this.lbSpareText.Size = new System.Drawing.Size(0, 11);
            this.lbSpareText.TabIndex = 27;
            // 
            // lbErrorText
            // 
            this.lbErrorText.AutoSize = true;
            this.lbErrorText.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbErrorText.Font = new System.Drawing.Font("宋体", 8F);
            this.lbErrorText.Location = new System.Drawing.Point(71, 10);
            this.lbErrorText.Name = "lbErrorText";
            this.lbErrorText.Size = new System.Drawing.Size(0, 11);
            this.lbErrorText.TabIndex = 26;
            // 
            // lbMiss
            // 
            this.lbMiss.AutoSize = true;
            this.lbMiss.BackColor = System.Drawing.Color.SteelBlue;
            this.lbMiss.Font = new System.Drawing.Font("宋体", 8F);
            this.lbMiss.Location = new System.Drawing.Point(25, 58);
            this.lbMiss.Name = "lbMiss";
            this.lbMiss.Size = new System.Drawing.Size(11, 11);
            this.lbMiss.TabIndex = 25;
            this.lbMiss.Text = " ";
            // 
            // lbSpare
            // 
            this.lbSpare.AutoSize = true;
            this.lbSpare.BackColor = System.Drawing.Color.Cyan;
            this.lbSpare.Font = new System.Drawing.Font("宋体", 8F);
            this.lbSpare.Location = new System.Drawing.Point(25, 36);
            this.lbSpare.Name = "lbSpare";
            this.lbSpare.Size = new System.Drawing.Size(11, 11);
            this.lbSpare.TabIndex = 23;
            this.lbSpare.Text = " ";
            // 
            // lbError
            // 
            this.lbError.AutoSize = true;
            this.lbError.BackColor = System.Drawing.Color.Pink;
            this.lbError.Font = new System.Drawing.Font("宋体", 8F);
            this.lbError.Location = new System.Drawing.Point(25, 13);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(11, 11);
            this.lbError.TabIndex = 22;
            this.lbError.Text = " ";
            // 
            // rtbMSG
            // 
            this.rtbMSG.Location = new System.Drawing.Point(5, 413);
            this.rtbMSG.Name = "rtbMSG";
            this.rtbMSG.ReadOnly = true;
            this.rtbMSG.ShowSelectionMargin = true;
            this.rtbMSG.Size = new System.Drawing.Size(380, 282);
            this.rtbMSG.TabIndex = 21;
            this.rtbMSG.Text = "";
            // 
            // plTOCTip
            // 
            this.plTOCTip.BackColor = System.Drawing.Color.WhiteSmoke;
            this.plTOCTip.Controls.Add(this.lbTermTitle);
            this.plTOCTip.Controls.Add(this.lbTOCTip);
            this.plTOCTip.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plTOCTip.Location = new System.Drawing.Point(7, 375);
            this.plTOCTip.Name = "plTOCTip";
            this.plTOCTip.Size = new System.Drawing.Size(380, 32);
            this.plTOCTip.TabIndex = 20;
            // 
            // lbTermTitle
            // 
            this.lbTermTitle.AutoSize = true;
            this.lbTermTitle.Location = new System.Drawing.Point(93, 5);
            this.lbTermTitle.Name = "lbTermTitle";
            this.lbTermTitle.Size = new System.Drawing.Size(0, 21);
            this.lbTermTitle.TabIndex = 1;
            // 
            // lbTOCTip
            // 
            this.lbTOCTip.AutoSize = true;
            this.lbTOCTip.Location = new System.Drawing.Point(7, 5);
            this.lbTOCTip.Name = "lbTOCTip";
            this.lbTOCTip.Size = new System.Drawing.Size(83, 21);
            this.lbTOCTip.TabIndex = 0;
            this.lbTOCTip.Text = "目录解释: ";
            // 
            // plTableTest
            // 
            this.plTableTest.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.plTableTest.BackColor = System.Drawing.SystemColors.Window;
            this.plTableTest.Controls.Add(this.button2);
            this.plTableTest.Controls.Add(this.rtbStandard);
            this.plTableTest.Controls.Add(this.panel16);
            this.plTableTest.Controls.Add(this.panel7);
            this.plTableTest.Controls.Add(this.showItemInfo);
            this.plTableTest.Location = new System.Drawing.Point(855, 200);
            this.plTableTest.Name = "plTableTest";
            this.plTableTest.Size = new System.Drawing.Size(390, 700);
            this.plTableTest.TabIndex = 22;
            // 
            // rtbStandard
            // 
            this.rtbStandard.Location = new System.Drawing.Point(7, 70);
            this.rtbStandard.Name = "rtbStandard";
            this.rtbStandard.ReadOnly = true;
            this.rtbStandard.Size = new System.Drawing.Size(380, 238);
            this.rtbStandard.TabIndex = 38;
            this.rtbStandard.Text = "";
            // 
            // panel16
            // 
            this.panel16.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel16.Controls.Add(this.label22);
            this.panel16.Controls.Add(this.label23);
            this.panel16.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel16.Location = new System.Drawing.Point(7, 334);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(380, 32);
            this.panel16.TabIndex = 37;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(93, 5);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(0, 21);
            this.label22.TabIndex = 1;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(4, 5);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(83, 21);
            this.label23.TabIndex = 0;
            this.label23.Text = "错误信息: ";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel7.Controls.Add(this.label4);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel7.Location = new System.Drawing.Point(7, 26);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(380, 32);
            this.panel7.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 21);
            this.label4.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "标准规范: ";
            // 
            // showItemInfo
            // 
            this.showItemInfo.Location = new System.Drawing.Point(5, 372);
            this.showItemInfo.Name = "showItemInfo";
            this.showItemInfo.ReadOnly = true;
            this.showItemInfo.Size = new System.Drawing.Size(380, 289);
            this.showItemInfo.TabIndex = 0;
            this.showItemInfo.Text = "";
            // 
            // tabControlMulti
            // 
            this.tabControlMulti.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tabControlMulti.Controls.Add(this.tabPageMultiDoc);
            this.tabControlMulti.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControlMulti.Location = new System.Drawing.Point(11, 156);
            this.tabControlMulti.Name = "tabControlMulti";
            this.tabControlMulti.SelectedIndex = 0;
            this.tabControlMulti.Size = new System.Drawing.Size(827, 770);
            this.tabControlMulti.TabIndex = 11;
            // 
            // tabPageMultiDoc
            // 
            this.tabPageMultiDoc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPageMultiDoc.Controls.Add(this.panel8);
            this.tabPageMultiDoc.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPageMultiDoc.Location = new System.Drawing.Point(4, 30);
            this.tabPageMultiDoc.Name = "tabPageMultiDoc";
            this.tabPageMultiDoc.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMultiDoc.Size = new System.Drawing.Size(819, 736);
            this.tabPageMultiDoc.TabIndex = 1;
            this.tabPageMultiDoc.Text = "多文档";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel8.Controls.Add(this.rtbSpecificationDoc);
            this.panel8.Controls.Add(this.panel11);
            this.panel8.Controls.Add(this.rtbRegDoc);
            this.panel8.Controls.Add(this.panel10);
            this.panel8.Controls.Add(this.rtbTestDoc);
            this.panel8.Controls.Add(this.panel9);
            this.panel8.Location = new System.Drawing.Point(6, 8);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(3);
            this.panel8.Size = new System.Drawing.Size(810, 720);
            this.panel8.TabIndex = 0;
            // 
            // rtbSpecificationDoc
            // 
            this.rtbSpecificationDoc.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtbSpecificationDoc.Location = new System.Drawing.Point(6, 524);
            this.rtbSpecificationDoc.Name = "rtbSpecificationDoc";
            this.rtbSpecificationDoc.ReadOnly = true;
            this.rtbSpecificationDoc.Size = new System.Drawing.Size(784, 185);
            this.rtbSpecificationDoc.TabIndex = 10;
            this.rtbSpecificationDoc.Text = "";
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel11.Controls.Add(this.btnDelMuti3);
            this.panel11.Controls.Add(this.btnMultiSelectSpecDoc);
            this.panel11.Controls.Add(this.txbMultiSpecification);
            this.panel11.Controls.Add(this.label8);
            this.panel11.Location = new System.Drawing.Point(6, 485);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(784, 34);
            this.panel11.TabIndex = 9;
            // 
            // btnDelMuti3
            // 
            this.btnDelMuti3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelMuti3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnDelMuti3.Location = new System.Drawing.Point(380, 5);
            this.btnDelMuti3.Name = "btnDelMuti3";
            this.btnDelMuti3.Size = new System.Drawing.Size(25, 25);
            this.btnDelMuti3.TabIndex = 4;
            this.btnDelMuti3.Text = "X";
            this.btnDelMuti3.UseVisualStyleBackColor = true;
            // 
            // btnMultiSelectSpecDoc
            // 
            this.btnMultiSelectSpecDoc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMultiSelectSpecDoc.BackgroundImage")));
            this.btnMultiSelectSpecDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMultiSelectSpecDoc.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnMultiSelectSpecDoc.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnMultiSelectSpecDoc.Location = new System.Drawing.Point(447, 4);
            this.btnMultiSelectSpecDoc.Name = "btnMultiSelectSpecDoc";
            this.btnMultiSelectSpecDoc.Size = new System.Drawing.Size(75, 25);
            this.btnMultiSelectSpecDoc.TabIndex = 2;
            this.btnMultiSelectSpecDoc.Text = "选择";
            this.btnMultiSelectSpecDoc.UseVisualStyleBackColor = true;
            this.btnMultiSelectSpecDoc.Click += new System.EventHandler(this.btnMultiSelectSpecDoc_Click);
            // 
            // txbMultiSpecification
            // 
            this.txbMultiSpecification.BackColor = System.Drawing.SystemColors.Window;
            this.txbMultiSpecification.Location = new System.Drawing.Point(124, 3);
            this.txbMultiSpecification.Name = "txbMultiSpecification";
            this.txbMultiSpecification.ReadOnly = true;
            this.txbMultiSpecification.Size = new System.Drawing.Size(244, 29);
            this.txbMultiSpecification.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(20, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 21);
            this.label8.TabIndex = 0;
            this.label8.Text = "说明书";
            // 
            // rtbRegDoc
            // 
            this.rtbRegDoc.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtbRegDoc.Location = new System.Drawing.Point(7, 284);
            this.rtbRegDoc.Name = "rtbRegDoc";
            this.rtbRegDoc.ReadOnly = true;
            this.rtbRegDoc.Size = new System.Drawing.Size(784, 185);
            this.rtbRegDoc.TabIndex = 8;
            this.rtbRegDoc.Text = "";
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel10.Controls.Add(this.btnDelMuti2);
            this.panel10.Controls.Add(this.btnMultiSelectRegDoc);
            this.panel10.Controls.Add(this.txbMultiReg);
            this.panel10.Controls.Add(this.label7);
            this.panel10.Location = new System.Drawing.Point(7, 245);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(784, 34);
            this.panel10.TabIndex = 7;
            // 
            // btnDelMuti2
            // 
            this.btnDelMuti2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelMuti2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnDelMuti2.Location = new System.Drawing.Point(380, 5);
            this.btnDelMuti2.Name = "btnDelMuti2";
            this.btnDelMuti2.Size = new System.Drawing.Size(25, 25);
            this.btnDelMuti2.TabIndex = 4;
            this.btnDelMuti2.Text = "X";
            this.btnDelMuti2.UseVisualStyleBackColor = true;
            // 
            // btnMultiSelectRegDoc
            // 
            this.btnMultiSelectRegDoc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMultiSelectRegDoc.BackgroundImage")));
            this.btnMultiSelectRegDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMultiSelectRegDoc.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnMultiSelectRegDoc.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnMultiSelectRegDoc.Location = new System.Drawing.Point(447, 5);
            this.btnMultiSelectRegDoc.Name = "btnMultiSelectRegDoc";
            this.btnMultiSelectRegDoc.Size = new System.Drawing.Size(75, 25);
            this.btnMultiSelectRegDoc.TabIndex = 2;
            this.btnMultiSelectRegDoc.Text = "选择";
            this.btnMultiSelectRegDoc.UseVisualStyleBackColor = true;
            this.btnMultiSelectRegDoc.Click += new System.EventHandler(this.btnMultiSelectRegDoc_Click);
            // 
            // txbMultiReg
            // 
            this.txbMultiReg.BackColor = System.Drawing.SystemColors.Window;
            this.txbMultiReg.Location = new System.Drawing.Point(124, 3);
            this.txbMultiReg.Name = "txbMultiReg";
            this.txbMultiReg.ReadOnly = true;
            this.txbMultiReg.Size = new System.Drawing.Size(244, 29);
            this.txbMultiReg.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(20, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 21);
            this.label7.TabIndex = 0;
            this.label7.Text = "成果规程";
            // 
            // rtbTestDoc
            // 
            this.rtbTestDoc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rtbTestDoc.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtbTestDoc.Location = new System.Drawing.Point(7, 42);
            this.rtbTestDoc.Name = "rtbTestDoc";
            this.rtbTestDoc.ReadOnly = true;
            this.rtbTestDoc.Size = new System.Drawing.Size(784, 185);
            this.rtbTestDoc.TabIndex = 6;
            this.rtbTestDoc.Text = "";
            // 
            // panel9
            // 
            this.panel9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel9.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel9.Controls.Add(this.btnDelMuti1);
            this.panel9.Controls.Add(this.btnMultiSelectTestDoc);
            this.panel9.Controls.Add(this.txbMultiTest);
            this.panel9.Controls.Add(this.label6);
            this.panel9.Location = new System.Drawing.Point(7, 3);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(784, 34);
            this.panel9.TabIndex = 1;
            // 
            // btnDelMuti1
            // 
            this.btnDelMuti1.BackColor = System.Drawing.Color.White;
            this.btnDelMuti1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelMuti1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnDelMuti1.Location = new System.Drawing.Point(378, 5);
            this.btnDelMuti1.Name = "btnDelMuti1";
            this.btnDelMuti1.Size = new System.Drawing.Size(25, 25);
            this.btnDelMuti1.TabIndex = 3;
            this.btnDelMuti1.Text = "X";
            this.btnDelMuti1.UseVisualStyleBackColor = false;
            // 
            // btnMultiSelectTestDoc
            // 
            this.btnMultiSelectTestDoc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMultiSelectTestDoc.BackgroundImage")));
            this.btnMultiSelectTestDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMultiSelectTestDoc.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnMultiSelectTestDoc.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnMultiSelectTestDoc.Location = new System.Drawing.Point(447, 5);
            this.btnMultiSelectTestDoc.Name = "btnMultiSelectTestDoc";
            this.btnMultiSelectTestDoc.Size = new System.Drawing.Size(75, 25);
            this.btnMultiSelectTestDoc.TabIndex = 2;
            this.btnMultiSelectTestDoc.Text = "选择";
            this.btnMultiSelectTestDoc.UseVisualStyleBackColor = true;
            this.btnMultiSelectTestDoc.Click += new System.EventHandler(this.btnMultiSelectTestDoc_Click);
            // 
            // txbMultiTest
            // 
            this.txbMultiTest.BackColor = System.Drawing.SystemColors.Window;
            this.txbMultiTest.Location = new System.Drawing.Point(124, 3);
            this.txbMultiTest.Name = "txbMultiTest";
            this.txbMultiTest.ReadOnly = true;
            this.txbMultiTest.Size = new System.Drawing.Size(244, 29);
            this.txbMultiTest.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(20, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 21);
            this.label6.TabIndex = 0;
            this.label6.Text = "目标文档";
            // 
            // plMultiInfo
            // 
            this.plMultiInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.plMultiInfo.BackColor = System.Drawing.SystemColors.Window;
            this.plMultiInfo.Controls.Add(this.label15);
            this.plMultiInfo.Controls.Add(this.lbkwLabel);
            this.plMultiInfo.Controls.Add(this.lbKeyWordValue);
            this.plMultiInfo.Controls.Add(this.lbKeyWord);
            this.plMultiInfo.Controls.Add(this.panel15);
            this.plMultiInfo.Controls.Add(this.panel14);
            this.plMultiInfo.Controls.Add(this.panel13);
            this.plMultiInfo.Controls.Add(this.rtbMultiSpecDoc);
            this.plMultiInfo.Controls.Add(this.rtbMultiRegDoc);
            this.plMultiInfo.Controls.Add(this.rtxMultiTestDoc);
            this.plMultiInfo.Controls.Add(this.panel12);
            this.plMultiInfo.Location = new System.Drawing.Point(855, 200);
            this.plMultiInfo.Name = "plMultiInfo";
            this.plMultiInfo.Size = new System.Drawing.Size(390, 698);
            this.plMultiInfo.TabIndex = 23;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(37, 97);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 21);
            this.label15.TabIndex = 9;
            this.label15.Text = "标准规范";
            // 
            // lbkwLabel
            // 
            this.lbkwLabel.AutoSize = true;
            this.lbkwLabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbkwLabel.Location = new System.Drawing.Point(37, 56);
            this.lbkwLabel.Name = "lbkwLabel";
            this.lbkwLabel.Size = new System.Drawing.Size(58, 21);
            this.lbkwLabel.TabIndex = 8;
            this.lbkwLabel.Text = "关键字";
            // 
            // lbKeyWordValue
            // 
            this.lbKeyWordValue.AutoSize = true;
            this.lbKeyWordValue.Location = new System.Drawing.Point(151, 97);
            this.lbKeyWordValue.Name = "lbKeyWordValue";
            this.lbKeyWordValue.Size = new System.Drawing.Size(0, 16);
            this.lbKeyWordValue.TabIndex = 7;
            // 
            // lbKeyWord
            // 
            this.lbKeyWord.AutoSize = true;
            this.lbKeyWord.Location = new System.Drawing.Point(151, 56);
            this.lbKeyWord.Name = "lbKeyWord";
            this.lbKeyWord.Size = new System.Drawing.Size(0, 16);
            this.lbKeyWord.TabIndex = 6;
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel15.Controls.Add(this.label14);
            this.panel15.Location = new System.Drawing.Point(7, 10);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(380, 24);
            this.panel15.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label14.Location = new System.Drawing.Point(10, 4);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 17);
            this.label14.TabIndex = 1;
            this.label14.Text = "规范标准信息: ";
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel14.Controls.Add(this.label11);
            this.panel14.Location = new System.Drawing.Point(7, 512);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(380, 24);
            this.panel14.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label11.Location = new System.Drawing.Point(10, 4);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 17);
            this.label11.TabIndex = 1;
            this.label11.Text = "说明书查询信息: ";
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel13.Controls.Add(this.label10);
            this.panel13.Location = new System.Drawing.Point(7, 326);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(380, 24);
            this.panel13.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label10.Location = new System.Drawing.Point(10, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 17);
            this.label10.TabIndex = 1;
            this.label10.Text = "成果规程查询信息: ";
            // 
            // rtbMultiSpecDoc
            // 
            this.rtbMultiSpecDoc.Location = new System.Drawing.Point(7, 543);
            this.rtbMultiSpecDoc.Name = "rtbMultiSpecDoc";
            this.rtbMultiSpecDoc.ReadOnly = true;
            this.rtbMultiSpecDoc.Size = new System.Drawing.Size(380, 140);
            this.rtbMultiSpecDoc.TabIndex = 3;
            this.rtbMultiSpecDoc.Text = "";
            // 
            // rtbMultiRegDoc
            // 
            this.rtbMultiRegDoc.Location = new System.Drawing.Point(7, 359);
            this.rtbMultiRegDoc.Name = "rtbMultiRegDoc";
            this.rtbMultiRegDoc.ReadOnly = true;
            this.rtbMultiRegDoc.Size = new System.Drawing.Size(380, 140);
            this.rtbMultiRegDoc.TabIndex = 2;
            this.rtbMultiRegDoc.Text = "";
            // 
            // rtxMultiTestDoc
            // 
            this.rtxMultiTestDoc.Location = new System.Drawing.Point(7, 171);
            this.rtxMultiTestDoc.Name = "rtxMultiTestDoc";
            this.rtxMultiTestDoc.ReadOnly = true;
            this.rtxMultiTestDoc.Size = new System.Drawing.Size(380, 140);
            this.rtxMultiTestDoc.TabIndex = 1;
            this.rtxMultiTestDoc.Text = "";
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel12.Controls.Add(this.label9);
            this.panel12.Location = new System.Drawing.Point(7, 137);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(380, 24);
            this.panel12.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label9.Location = new System.Drawing.Point(10, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 17);
            this.label9.TabIndex = 1;
            this.label9.Text = "目标文档查询信息: ";
            // 
            // 多文档查询ToolStripMenuItem
            // 
            this.多文档查询ToolStripMenuItem.Name = "多文档查询ToolStripMenuItem";
            this.多文档查询ToolStripMenuItem.Size = new System.Drawing.Size(12, 18);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.多文档查询ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1255, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(250, 667);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 39;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1255, 935);
            this.Controls.Add(this.plTableTest);
            this.Controls.Add(this.plTOC);
            this.Controls.Add(this.plKeyWord);
            this.Controls.Add(this.plMultiInfo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControlFunction);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControlMulti);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " 规划设计文档比较系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabControlFunction.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPageTest.ResumeLayout(false);
            this.panelTest.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabPageFind.ResumeLayout(false);
            this.panelFind.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tabCalculateTable.ResumeLayout(false);
            this.tabCalculateTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.plKeyWord.ResumeLayout(false);
            this.plKeyWord.PerformLayout();
            this.plInfo.ResumeLayout(false);
            this.plInfo.PerformLayout();
            this.plTOC.ResumeLayout(false);
            this.plTOC.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.plTOCTip.ResumeLayout(false);
            this.plTOCTip.PerformLayout();
            this.plTableTest.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.tabControlMulti.ResumeLayout(false);
            this.tabPageMultiDoc.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.plMultiInfo.ResumeLayout(false);
            this.plMultiInfo.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }      

        #endregion

        private System.Windows.Forms.TabControl tabControlFunction;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPageTest;
        private System.Windows.Forms.TabPage tabPageFind;
        private System.Windows.Forms.Button btnRegSelect;
        private System.Windows.Forms.Button btnFindKeyWord;
        private System.Windows.Forms.Button btnTestTOC;
        private System.Windows.Forms.Button btnTestFileSelect;
        private System.Windows.Forms.TextBox testDocLabel;
        private System.Windows.Forms.ToolStripMenuItem 新建ToolStripMenuItem1;
        private System.Windows.Forms.Button btnKeyWordSelect;
        private System.Windows.Forms.TreeView testTreeView;
        private System.Windows.Forms.ComboBox cbxKeyWord;
        private System.Windows.Forms.TreeView regTreeView;
        private System.Windows.Forms.ComboBox cbxRegDoc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMultipleDocCompare;
        private System.Windows.Forms.Button btnTwoDocCompare;
        private System.Windows.Forms.Button btnTestTable;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Panel panelFind;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label labelTestDoc;
        private System.Windows.Forms.Panel panelTest;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTxbTestDoc;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label labelRegDoc;
        private System.Windows.Forms.RichTextBox richTxbRegDoc;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnTestValue;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel plKeyWord;
        private System.Windows.Forms.RichTextBox rtbKeyWord;
        private System.Windows.Forms.Panel plInfo;
        private System.Windows.Forms.Panel plTOC;
        private System.Windows.Forms.RichTextBox rtbMSG;
        private System.Windows.Forms.Panel plTOCTip;
        private System.Windows.Forms.Label lbTermTitle;
        private System.Windows.Forms.Label lbTOCTip;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.Label lbMiss;
        private System.Windows.Forms.Label lbSpare;
        private System.Windows.Forms.Label lbError;
        private System.Windows.Forms.Label lbMissText;
        private System.Windows.Forms.Label lbSpareText;
        private System.Windows.Forms.Label lbErrorText;
        private System.Windows.Forms.Label lbCountItems;
        private System.Windows.Forms.Panel plTableTest;
        private System.Windows.Forms.RichTextBox showItemInfo;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TreeView tvRegTable;
        private System.Windows.Forms.TreeView tvTestTable;
        private System.Windows.Forms.TabControl tabControlMulti;
        private System.Windows.Forms.TabPage tabPageMultiDoc;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox rtbTestDoc;
        private System.Windows.Forms.Button btnMultiSelectTestDoc;
        private System.Windows.Forms.TextBox txbMultiTest;
        private System.Windows.Forms.RichTextBox rtbSpecificationDoc;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button btnMultiSelectSpecDoc;
        private System.Windows.Forms.TextBox txbMultiSpecification;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox rtbRegDoc;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button btnMultiSelectRegDoc;
        private System.Windows.Forms.TextBox txbMultiReg;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel plMultiInfo;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox rtbMultiSpecDoc;
        private System.Windows.Forms.RichTextBox rtbMultiRegDoc;
        private System.Windows.Forms.RichTextBox rtxMultiTestDoc;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnCalTable;
        private System.Windows.Forms.ComboBox cbxTableList;
        private System.Windows.Forms.ToolStripMenuItem 多文档查询ToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button btnDelMuti1;
        private System.Windows.Forms.Button btnDelMuti3;
        private System.Windows.Forms.Button btnDelMuti2;
        private System.Windows.Forms.ComboBox comboBoxLevel2;
        private System.Windows.Forms.ComboBox comboBoxLevel1;
        private System.Windows.Forms.ComboBox comboBoxLevel3;
        private System.Windows.Forms.RichTextBox rtbTestDocContent;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TabPage tabCalculateTable;
        private System.Windows.Forms.RichTextBox rbTableTest;
        private System.Windows.Forms.DataGridView dataView;
        private System.Windows.Forms.Button lookUpFullText;
        private System.Windows.Forms.Label lbKeyWordValue;
        private System.Windows.Forms.Label lbKeyWord;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lbkwLabel;
        private System.Windows.Forms.Label lbKeyWordValueSingle;
        private System.Windows.Forms.Label lbKeyWordSingle;
        private System.Windows.Forms.Label lbValueLabelSingle;
        private System.Windows.Forms.Label lbkwLabelSingle;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.RichTextBox rtbStandard;
        private System.Windows.Forms.ComboBox keyTableItemList;
        private System.Windows.Forms.Button button2;
    }
}

