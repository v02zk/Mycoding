namespace WindowsFormsApplication2
{
    partial class TermSelectedForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabTownCountrtLand = new System.Windows.Forms.TabPage();
            this.tvTownAndCountryLand = new System.Windows.Forms.TreeView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tvUrbanDevelopLand = new System.Windows.Forms.TreeView();
            this.tabPageCust = new System.Windows.Forms.TabPage();
            this.tvCustomize = new System.Windows.Forms.TreeView();
            this.txbKeyword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCommit = new System.Windows.Forms.Button();
            this.btnAddCustomize = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabTownCountrtLand.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPageCust.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabTownCountrtLand);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPageCust);
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.tabControl1.Location = new System.Drawing.Point(27, 95);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(436, 382);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabTownCountrtLand
            // 
            this.tabTownCountrtLand.Controls.Add(this.tvTownAndCountryLand);
            this.tabTownCountrtLand.Location = new System.Drawing.Point(4, 28);
            this.tabTownCountrtLand.Name = "tabTownCountrtLand";
            this.tabTownCountrtLand.Padding = new System.Windows.Forms.Padding(3);
            this.tabTownCountrtLand.Size = new System.Drawing.Size(428, 350);
            this.tabTownCountrtLand.TabIndex = 0;
            this.tabTownCountrtLand.Text = "城乡用地分类";
            this.tabTownCountrtLand.UseVisualStyleBackColor = true;
            // 
            // tvTownAndCountryLand
            // 
            this.tvTownAndCountryLand.Location = new System.Drawing.Point(3, 3);
            this.tvTownAndCountryLand.Name = "tvTownAndCountryLand";
            this.tvTownAndCountryLand.Size = new System.Drawing.Size(422, 349);
            this.tvTownAndCountryLand.TabIndex = 1;
            this.tvTownAndCountryLand.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvTownAndCountryLand_AfterSelect);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tvUrbanDevelopLand);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(428, 350);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "城市建设用地分类";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tvUrbanDevelopLand
            // 
            this.tvUrbanDevelopLand.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvUrbanDevelopLand.Location = new System.Drawing.Point(3, 3);
            this.tvUrbanDevelopLand.Name = "tvUrbanDevelopLand";
            this.tvUrbanDevelopLand.Size = new System.Drawing.Size(422, 349);
            this.tvUrbanDevelopLand.TabIndex = 2;
            this.tvUrbanDevelopLand.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvUrbanDevelopLand_AfterSelect);
            // 
            // tabPageCust
            // 
            this.tabPageCust.Controls.Add(this.tvCustomize);
            this.tabPageCust.Location = new System.Drawing.Point(4, 30);
            this.tabPageCust.Name = "tabPageCust";
            this.tabPageCust.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCust.Size = new System.Drawing.Size(428, 348);
            this.tabPageCust.TabIndex = 2;
            this.tabPageCust.Text = "自定义";
            this.tabPageCust.UseVisualStyleBackColor = true;
            // 
            // tvCustomize
            // 
            this.tvCustomize.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvCustomize.Location = new System.Drawing.Point(3, 2);
            this.tvCustomize.Name = "tvCustomize";
            this.tvCustomize.Size = new System.Drawing.Size(422, 349);
            this.tvCustomize.TabIndex = 3;
            this.tvCustomize.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvCustomize_AfterSelect);
            // 
            // txbKeyword
            // 
            this.txbKeyword.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txbKeyword.Location = new System.Drawing.Point(103, 19);
            this.txbKeyword.Name = "txbKeyword";
            this.txbKeyword.Size = new System.Drawing.Size(169, 23);
            this.txbKeyword.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(24, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "关键字";
            // 
            // btnCommit
            // 
            this.btnCommit.BackColor = System.Drawing.SystemColors.Window;
            this.btnCommit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCommit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCommit.Location = new System.Drawing.Point(345, 15);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(94, 26);
            this.btnCommit.TabIndex = 3;
            this.btnCommit.Text = "确定";
            this.btnCommit.UseVisualStyleBackColor = false;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // btnAddCustomize
            // 
            this.btnAddCustomize.BackColor = System.Drawing.SystemColors.Window;
            this.btnAddCustomize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCustomize.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddCustomize.Location = new System.Drawing.Point(345, 58);
            this.btnAddCustomize.Name = "btnAddCustomize";
            this.btnAddCustomize.Size = new System.Drawing.Size(94, 26);
            this.btnAddCustomize.TabIndex = 4;
            this.btnAddCustomize.Text = "添加自定义";
            this.btnAddCustomize.UseVisualStyleBackColor = false;
            this.btnAddCustomize.Click += new System.EventHandler(this.btnAddCustomize_Click);
            // 
            // TermSelectedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 490);
            this.Controls.Add(this.btnAddCustomize);
            this.Controls.Add(this.btnCommit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbKeyword);
            this.Controls.Add(this.tabControl1);
            this.Name = "TermSelectedForm";
            this.Text = "关键字选择窗口";
            this.TopMost = true;
            this.tabControl1.ResumeLayout(false);
            this.tabTownCountrtLand.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPageCust.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabTownCountrtLand;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txbKeyword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.TreeView tvTownAndCountryLand;
        private System.Windows.Forms.TreeView tvUrbanDevelopLand;
        private System.Windows.Forms.TabPage tabPageCust;
        private System.Windows.Forms.TreeView tvCustomize;
        private System.Windows.Forms.Button btnAddCustomize;
    }
}