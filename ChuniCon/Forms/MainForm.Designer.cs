namespace ChuniCon.Forms
{
    partial class MainForm
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.NewPresetBtn = new System.Windows.Forms.Button();
            this.SavePresetBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.SensitivityLab = new System.Windows.Forms.Label();
            this.SensitivityBar = new System.Windows.Forms.TrackBar();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PresetList = new System.Windows.Forms.ListBox();
            this.PresetMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ModifyPresetMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.DeletePresetMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.KeyPairMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ModifyKeyMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.RGBPairMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ModifyColor = new System.Windows.Forms.ToolStripMenuItem();
            this.ModifyPressColor = new System.Windows.Forms.ToolStripMenuItem();
            this.NormalBox = new System.Windows.Forms.RadioButton();
            this.DriverBox = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.KeyPairList = new ChuniCon.Components.DoubleBufferListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RGBPairList = new ChuniCon.Components.DoubleBufferListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SensitivityBar)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.PresetMenu.SuspendLayout();
            this.KeyPairMenu.SuspendLayout();
            this.RGBPairMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // NewPresetBtn
            // 
            this.NewPresetBtn.Location = new System.Drawing.Point(19, 12);
            this.NewPresetBtn.Name = "NewPresetBtn";
            this.NewPresetBtn.Size = new System.Drawing.Size(84, 29);
            this.NewPresetBtn.TabIndex = 0;
            this.NewPresetBtn.Text = "新建预设";
            this.NewPresetBtn.UseVisualStyleBackColor = true;
            this.NewPresetBtn.Click += new System.EventHandler(this.NewPresetBtn_Click);
            // 
            // SavePresetBtn
            // 
            this.SavePresetBtn.Location = new System.Drawing.Point(109, 12);
            this.SavePresetBtn.Name = "SavePresetBtn";
            this.SavePresetBtn.Size = new System.Drawing.Size(84, 29);
            this.SavePresetBtn.TabIndex = 1;
            this.SavePresetBtn.Text = "保存预设";
            this.SavePresetBtn.UseVisualStyleBackColor = true;
            this.SavePresetBtn.Click += new System.EventHandler(this.SavePresetBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Location = new System.Drawing.Point(192, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 426);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(6, 20);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(331, 400);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.SensitivityLab);
            this.tabPage1.Controls.Add(this.KeyPairList);
            this.tabPage1.Controls.Add(this.SensitivityBar);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(323, 374);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "触摸";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // SensitivityLab
            // 
            this.SensitivityLab.Location = new System.Drawing.Point(236, 17);
            this.SensitivityLab.Name = "SensitivityLab";
            this.SensitivityLab.Size = new System.Drawing.Size(71, 23);
            this.SensitivityLab.TabIndex = 2;
            this.SensitivityLab.Text = "灵敏度: 0";
            this.SensitivityLab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SensitivityBar
            // 
            this.SensitivityBar.AutoSize = false;
            this.SensitivityBar.Location = new System.Drawing.Point(17, 17);
            this.SensitivityBar.Maximum = 100;
            this.SensitivityBar.Name = "SensitivityBar";
            this.SensitivityBar.Size = new System.Drawing.Size(213, 23);
            this.SensitivityBar.TabIndex = 1;
            this.SensitivityBar.TickFrequency = 0;
            this.SensitivityBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.SensitivityBar.Value = 1;
            this.SensitivityBar.Scroll += new System.EventHandler(this.SensitivityBar_Scroll);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.RGBPairList);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(323, 374);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "灯光";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(323, 374);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Air";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "还没想好Air能用来干啥";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PresetList);
            this.groupBox2.Location = new System.Drawing.Point(19, 47);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(167, 426);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "预设";
            // 
            // PresetList
            // 
            this.PresetList.FormattingEnabled = true;
            this.PresetList.ItemHeight = 12;
            this.PresetList.Location = new System.Drawing.Point(6, 20);
            this.PresetList.Name = "PresetList";
            this.PresetList.Size = new System.Drawing.Size(155, 400);
            this.PresetList.TabIndex = 0;
            this.PresetList.SelectedIndexChanged += new System.EventHandler(this.PresetList_SelectedIndexChanged);
            this.PresetList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PresetList_MouseDown);
            // 
            // PresetMenu
            // 
            this.PresetMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ModifyPresetMenu,
            this.DeletePresetMenu});
            this.PresetMenu.Name = "PresetMenu";
            this.PresetMenu.Size = new System.Drawing.Size(125, 48);
            // 
            // ModifyPresetMenu
            // 
            this.ModifyPresetMenu.Name = "ModifyPresetMenu";
            this.ModifyPresetMenu.Size = new System.Drawing.Size(124, 22);
            this.ModifyPresetMenu.Text = "修改名称";
            this.ModifyPresetMenu.Click += new System.EventHandler(this.ModifyPresetMenu_Click);
            // 
            // DeletePresetMenu
            // 
            this.DeletePresetMenu.Name = "DeletePresetMenu";
            this.DeletePresetMenu.Size = new System.Drawing.Size(124, 22);
            this.DeletePresetMenu.Text = "删除预设";
            this.DeletePresetMenu.Click += new System.EventHandler(this.DeletePresetMenu_Click);
            // 
            // KeyPairMenu
            // 
            this.KeyPairMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ModifyKeyMenu});
            this.KeyPairMenu.Name = "KeyPairMenu";
            this.KeyPairMenu.Size = new System.Drawing.Size(125, 26);
            // 
            // ModifyKeyMenu
            // 
            this.ModifyKeyMenu.Name = "ModifyKeyMenu";
            this.ModifyKeyMenu.Size = new System.Drawing.Size(124, 22);
            this.ModifyKeyMenu.Text = "修改按键";
            this.ModifyKeyMenu.Click += new System.EventHandler(this.ModifyKeyMenu_Click);
            // 
            // RGBPairMenu
            // 
            this.RGBPairMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ModifyColor,
            this.ModifyPressColor});
            this.RGBPairMenu.Name = "RGBPairMenu";
            this.RGBPairMenu.Size = new System.Drawing.Size(149, 48);
            // 
            // ModifyColor
            // 
            this.ModifyColor.Name = "ModifyColor";
            this.ModifyColor.Size = new System.Drawing.Size(148, 22);
            this.ModifyColor.Text = "更改颜色";
            this.ModifyColor.Click += new System.EventHandler(this.ModifyColor_Click);
            // 
            // ModifyPressColor
            // 
            this.ModifyPressColor.Name = "ModifyPressColor";
            this.ModifyPressColor.Size = new System.Drawing.Size(148, 22);
            this.ModifyPressColor.Text = "修改触摸颜色";
            this.ModifyPressColor.Click += new System.EventHandler(this.ModifyPressColor_Click);
            // 
            // NormalBox
            // 
            this.NormalBox.AutoSize = true;
            this.NormalBox.Checked = true;
            this.NormalBox.Location = new System.Drawing.Point(428, 18);
            this.NormalBox.Name = "NormalBox";
            this.NormalBox.Size = new System.Drawing.Size(47, 16);
            this.NormalBox.TabIndex = 4;
            this.NormalBox.TabStop = true;
            this.NormalBox.Text = "普通";
            this.NormalBox.UseVisualStyleBackColor = true;
            // 
            // DriverBox
            // 
            this.DriverBox.AutoSize = true;
            this.DriverBox.Location = new System.Drawing.Point(481, 18);
            this.DriverBox.Name = "DriverBox";
            this.DriverBox.Size = new System.Drawing.Size(47, 16);
            this.DriverBox.TabIndex = 5;
            this.DriverBox.Text = "驱动";
            this.DriverBox.UseVisualStyleBackColor = true;
            this.DriverBox.CheckedChanged += new System.EventHandler(this.DriverBox_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(333, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "键盘模拟类型: ";
            // 
            // KeyPairList
            // 
            this.KeyPairList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.KeyPairList.FullRowSelect = true;
            this.KeyPairList.GridLines = true;
            this.KeyPairList.HideSelection = false;
            this.KeyPairList.Location = new System.Drawing.Point(17, 47);
            this.KeyPairList.Name = "KeyPairList";
            this.KeyPairList.Size = new System.Drawing.Size(290, 307);
            this.KeyPairList.TabIndex = 0;
            this.KeyPairList.UseCompatibleStateImageBehavior = false;
            this.KeyPairList.View = System.Windows.Forms.View.Details;
            this.KeyPairList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.KeyPairList_MouseDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "触摸区";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "按键码";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "状态";
            // 
            // RGBPairList
            // 
            this.RGBPairList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.RGBPairList.FullRowSelect = true;
            this.RGBPairList.GridLines = true;
            this.RGBPairList.HideSelection = false;
            this.RGBPairList.Location = new System.Drawing.Point(17, 18);
            this.RGBPairList.Name = "RGBPairList";
            this.RGBPairList.Size = new System.Drawing.Size(290, 338);
            this.RGBPairList.TabIndex = 1;
            this.RGBPairList.UseCompatibleStateImageBehavior = false;
            this.RGBPairList.View = System.Windows.Forms.View.Details;
            this.RGBPairList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RGBPairList_MouseDown);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "灯";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "颜色";
            this.columnHeader5.Width = 90;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "触摸颜色";
            this.columnHeader6.Width = 90;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 489);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DriverBox);
            this.Controls.Add(this.NormalBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.NewPresetBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SavePresetBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChuniCon";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SensitivityBar)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.PresetMenu.ResumeLayout(false);
            this.KeyPairMenu.ResumeLayout(false);
            this.RGBPairMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button NewPresetBtn;
        private System.Windows.Forms.Button SavePresetBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox PresetList;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ContextMenuStrip PresetMenu;
        private Components.DoubleBufferListView KeyPairList;
        private System.Windows.Forms.ToolStripMenuItem ModifyPresetMenu;
        private System.Windows.Forms.ToolStripMenuItem DeletePresetMenu;
        private System.Windows.Forms.ContextMenuStrip KeyPairMenu;
        private System.Windows.Forms.ToolStripMenuItem ModifyKeyMenu;
        private Components.DoubleBufferListView RGBPairList;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ContextMenuStrip RGBPairMenu;
        private System.Windows.Forms.ToolStripMenuItem ModifyColor;
        private System.Windows.Forms.TrackBar SensitivityBar;
        private System.Windows.Forms.Label SensitivityLab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton NormalBox;
        private System.Windows.Forms.RadioButton DriverBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ToolStripMenuItem ModifyPressColor;
    }
}

