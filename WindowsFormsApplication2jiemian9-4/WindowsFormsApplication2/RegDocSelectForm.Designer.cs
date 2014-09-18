namespace WindowsFormsApplication2
{
    partial class regDocSelectForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txbDocName = new System.Windows.Forms.TextBox();
            this.tvRegDoc = new System.Windows.Forms.TreeView();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnAddNewDoc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabReg = new System.Windows.Forms.TabControl();
            this.tabTextTV = new System.Windows.Forms.TabPage();
            this.tabSpecTV = new System.Windows.Forms.TabPage();
            this.tvSpecificationDoc = new System.Windows.Forms.TreeView();
            this.rbText = new System.Windows.Forms.RadioButton();
            this.rbSpecification = new System.Windows.Forms.RadioButton();
            this.btnDelDoc = new System.Windows.Forms.Button();
            this.tabReg.SuspendLayout();
            this.tabTextTV.SuspendLayout();
            this.tabSpecTV.SuspendLayout();
            this.SuspendLayout();
            // 
            // txbDocName
            // 
            this.txbDocName.Location = new System.Drawing.Point(103, 24);
            this.txbDocName.Name = "txbDocName";
            this.txbDocName.Size = new System.Drawing.Size(229, 21);
            this.txbDocName.TabIndex = 0;
            // 
            // tvRegDoc
            // 
            this.tvRegDoc.Location = new System.Drawing.Point(6, 6);
            this.tvRegDoc.Name = "tvRegDoc";
            this.tvRegDoc.Size = new System.Drawing.Size(235, 343);
            this.tvRegDoc.TabIndex = 1;
            this.tvRegDoc.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvRegDoc_AfterSelect);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.SystemColors.Window;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.btnSubmit.Location = new System.Drawing.Point(405, 20);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 26);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "确定";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnAddNewDoc
            // 
            this.btnAddNewDoc.BackColor = System.Drawing.SystemColors.Window;
            this.btnAddNewDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewDoc.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddNewDoc.Location = new System.Drawing.Point(406, 138);
            this.btnAddNewDoc.Name = "btnAddNewDoc";
            this.btnAddNewDoc.Size = new System.Drawing.Size(75, 26);
            this.btnAddNewDoc.TabIndex = 3;
            this.btnAddNewDoc.Text = "添加规程";
            this.btnAddNewDoc.UseVisualStyleBackColor = false;
            this.btnAddNewDoc.Click += new System.EventHandler(this.btnAddNewDoc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "规程名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "现有规程";
            // 
            // tabReg
            // 
            this.tabReg.Controls.Add(this.tabTextTV);
            this.tabReg.Controls.Add(this.tabSpecTV);
            this.tabReg.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabReg.Location = new System.Drawing.Point(93, 65);
            this.tabReg.Name = "tabReg";
            this.tabReg.SelectedIndex = 0;
            this.tabReg.Size = new System.Drawing.Size(255, 381);
            this.tabReg.TabIndex = 6;
            // 
            // tabTextTV
            // 
            this.tabTextTV.Controls.Add(this.tvRegDoc);
            this.tabTextTV.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabTextTV.Location = new System.Drawing.Point(4, 26);
            this.tabTextTV.Name = "tabTextTV";
            this.tabTextTV.Padding = new System.Windows.Forms.Padding(3);
            this.tabTextTV.Size = new System.Drawing.Size(247, 351);
            this.tabTextTV.TabIndex = 0;
            this.tabTextTV.Text = "文本规程";
            this.tabTextTV.UseVisualStyleBackColor = true;
            // 
            // tabSpecTV
            // 
            this.tabSpecTV.Controls.Add(this.tvSpecificationDoc);
            this.tabSpecTV.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabSpecTV.Location = new System.Drawing.Point(4, 26);
            this.tabSpecTV.Name = "tabSpecTV";
            this.tabSpecTV.Padding = new System.Windows.Forms.Padding(3);
            this.tabSpecTV.Size = new System.Drawing.Size(247, 351);
            this.tabSpecTV.TabIndex = 1;
            this.tabSpecTV.Text = "说明书规程";
            this.tabSpecTV.UseVisualStyleBackColor = true;
            // 
            // tvSpecificationDoc
            // 
            this.tvSpecificationDoc.Location = new System.Drawing.Point(6, 6);
            this.tvSpecificationDoc.Name = "tvSpecificationDoc";
            this.tvSpecificationDoc.Size = new System.Drawing.Size(235, 343);
            this.tvSpecificationDoc.TabIndex = 2;
            this.tvSpecificationDoc.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvSpecificationDoc_AfterSelect);
            // 
            // rbText
            // 
            this.rbText.AutoSize = true;
            this.rbText.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbText.Location = new System.Drawing.Point(406, 78);
            this.rbText.Name = "rbText";
            this.rbText.Size = new System.Drawing.Size(74, 21);
            this.rbText.TabIndex = 7;
            this.rbText.TabStop = true;
            this.rbText.Text = "文本规程";
            this.rbText.UseVisualStyleBackColor = true;
            // 
            // rbSpecification
            // 
            this.rbSpecification.AutoSize = true;
            this.rbSpecification.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbSpecification.Location = new System.Drawing.Point(406, 97);
            this.rbSpecification.Name = "rbSpecification";
            this.rbSpecification.Size = new System.Drawing.Size(86, 21);
            this.rbSpecification.TabIndex = 8;
            this.rbSpecification.TabStop = true;
            this.rbSpecification.Text = "说明书规程";
            this.rbSpecification.UseVisualStyleBackColor = true;
            // 
            // btnDelDoc
            // 
            this.btnDelDoc.BackColor = System.Drawing.SystemColors.Window;
            this.btnDelDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelDoc.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelDoc.Location = new System.Drawing.Point(405, 189);
            this.btnDelDoc.Name = "btnDelDoc";
            this.btnDelDoc.Size = new System.Drawing.Size(75, 26);
            this.btnDelDoc.TabIndex = 9;
            this.btnDelDoc.Text = "删除规程";
            this.btnDelDoc.UseVisualStyleBackColor = false;
            this.btnDelDoc.Click += new System.EventHandler(this.btnDelDoc_Click);
            // 
            // regDocSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 458);
            this.Controls.Add(this.btnDelDoc);
            this.Controls.Add(this.rbSpecification);
            this.Controls.Add(this.rbText);
            this.Controls.Add(this.tabReg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddNewDoc);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txbDocName);
            this.Name = "规程文档选择窗口";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "规程文档选择窗口";
            this.tabReg.ResumeLayout(false);
            this.tabTextTV.ResumeLayout(false);
            this.tabSpecTV.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbDocName;
        private System.Windows.Forms.TreeView tvRegDoc;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnAddNewDoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabReg;
        private System.Windows.Forms.TabPage tabTextTV;
        private System.Windows.Forms.TabPage tabSpecTV;
        private System.Windows.Forms.TreeView tvSpecificationDoc;
        private System.Windows.Forms.RadioButton rbText;
        private System.Windows.Forms.RadioButton rbSpecification;
        private System.Windows.Forms.Button btnDelDoc;
    }
}