namespace WindowsFormsApplication1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dgvGrade = new System.Windows.Forms.DataGridView();
            this.序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.企业名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.企业法人 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.联系方式 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.地址 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.注册资本 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.注册日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.营业状态 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.品牌产品 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.商标 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.登陆ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出ExeclToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.注册ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.联系我们ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.searchmsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(476, 302);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(203, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(235, 21);
            this.textBox1.TabIndex = 1;
            // 
            // dgvGrade
            // 
            this.dgvGrade.AutoGenerateColumns = false;
            this.dgvGrade.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGrade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrade.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.序号,
            this.企业名称,
            this.企业法人,
            this.联系方式,
            this.地址,
            this.注册资本,
            this.注册日期,
            this.营业状态,
            this.品牌产品,
            this.商标});
            this.dgvGrade.DataSource = this.bindingSource1;
            this.dgvGrade.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrade.Location = new System.Drawing.Point(3, 3);
            this.dgvGrade.Name = "dgvGrade";
            this.dgvGrade.ReadOnly = true;
            this.dgvGrade.RowTemplate.Height = 23;
            this.dgvGrade.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvGrade.Size = new System.Drawing.Size(1291, 453);
            this.dgvGrade.TabIndex = 6;
            // 
            // 序号
            // 
            this.序号.DataPropertyName = "序号";
            this.序号.FillWeight = 43.80237F;
            this.序号.HeaderText = "序号";
            this.序号.Name = "序号";
            this.序号.ReadOnly = true;
            // 
            // 企业名称
            // 
            this.企业名称.DataPropertyName = "企业名称";
            this.企业名称.FillWeight = 117.0149F;
            this.企业名称.HeaderText = "企业名称";
            this.企业名称.Name = "企业名称";
            this.企业名称.ReadOnly = true;
            // 
            // 企业法人
            // 
            this.企业法人.DataPropertyName = "企业法人";
            this.企业法人.FillWeight = 117.0149F;
            this.企业法人.HeaderText = "企业法人";
            this.企业法人.Name = "企业法人";
            this.企业法人.ReadOnly = true;
            // 
            // 联系方式
            // 
            this.联系方式.DataPropertyName = "联系方式";
            this.联系方式.FillWeight = 117.0149F;
            this.联系方式.HeaderText = "联系方式";
            this.联系方式.Name = "联系方式";
            this.联系方式.ReadOnly = true;
            // 
            // 地址
            // 
            this.地址.DataPropertyName = "地址";
            this.地址.FillWeight = 117.0149F;
            this.地址.HeaderText = "地址";
            this.地址.Name = "地址";
            this.地址.ReadOnly = true;
            // 
            // 注册资本
            // 
            this.注册资本.DataPropertyName = "注册资本";
            this.注册资本.FillWeight = 76.14214F;
            this.注册资本.HeaderText = "注册资本";
            this.注册资本.Name = "注册资本";
            this.注册资本.ReadOnly = true;
            // 
            // 注册日期
            // 
            this.注册日期.DataPropertyName = "注册日期";
            this.注册日期.FillWeight = 79.25426F;
            this.注册日期.HeaderText = "注册日期";
            this.注册日期.Name = "注册日期";
            this.注册日期.ReadOnly = true;
            // 
            // 营业状态
            // 
            this.营业状态.DataPropertyName = "营业状态";
            this.营业状态.FillWeight = 117.0149F;
            this.营业状态.HeaderText = "营业状态";
            this.营业状态.Name = "营业状态";
            this.营业状态.ReadOnly = true;
            // 
            // 品牌产品
            // 
            this.品牌产品.DataPropertyName = "品牌产品";
            this.品牌产品.FillWeight = 107.8633F;
            this.品牌产品.HeaderText = "品牌产品";
            this.品牌产品.Name = "品牌产品";
            this.品牌产品.ReadOnly = true;
            // 
            // 商标
            // 
            this.商标.DataPropertyName = "商标";
            this.商标.FillWeight = 107.8633F;
            this.商标.HeaderText = "商标";
            this.商标.Name = "商标";
            this.商标.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "输入关键字";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(567, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 12);
            this.label2.TabIndex = 8;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1305, 485);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.DarkGray;
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.radioButton2);
            this.tabPage2.Controls.Add(this.radioButton1);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1297, 459);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "查询条件";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(120, 191);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(317, 61);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(77, 16);
            this.radioButton2.TabIndex = 10;
            this.radioButton2.Text = "产品/品牌";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(203, 61);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(71, 16);
            this.radioButton1.TabIndex = 10;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "企业名称";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvGrade);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1297, 459);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "查询结果";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.登陆ToolStripMenuItem,
            this.联系我们ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1305, 25);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 登陆ToolStripMenuItem
            // 
            this.登陆ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导出ExeclToolStripMenuItem,
            this.注册ToolStripMenuItem});
            this.登陆ToolStripMenuItem.Name = "登陆ToolStripMenuItem";
            this.登陆ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.登陆ToolStripMenuItem.Text = "操作";
            // 
            // 导出ExeclToolStripMenuItem
            // 
            this.导出ExeclToolStripMenuItem.Name = "导出ExeclToolStripMenuItem";
            this.导出ExeclToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.导出ExeclToolStripMenuItem.Text = "导出Execl";
            this.导出ExeclToolStripMenuItem.Click += new System.EventHandler(this.导出ExeclToolStripMenuItem_Click);
            // 
            // 注册ToolStripMenuItem
            // 
            this.注册ToolStripMenuItem.Name = "注册ToolStripMenuItem";
            this.注册ToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.注册ToolStripMenuItem.Text = "注册";
            this.注册ToolStripMenuItem.Click += new System.EventHandler(this.注册ToolStripMenuItem_Click);
            // 
            // 联系我们ToolStripMenuItem
            // 
            this.联系我们ToolStripMenuItem.Name = "联系我们ToolStripMenuItem";
            this.联系我们ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.联系我们ToolStripMenuItem.Text = "捐助助手";
            this.联系我们ToolStripMenuItem.Click += new System.EventHandler(this.联系我们ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.searchmsg});
            this.statusStrip1.Location = new System.Drawing.Point(0, 488);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1305, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1148, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(142, 17);
            this.toolStripStatusLabel2.Text = "联系方式:QQ453433374";
            // 
            // searchmsg
            // 
            this.searchmsg.Name = "searchmsg";
            this.searchmsg.Size = new System.Drawing.Size(0, 17);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(374, 224);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1305, 510);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "查询界面";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dgvGrade;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 登陆ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 联系我们ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel searchmsg;
        private System.Windows.Forms.ToolStripMenuItem 导出ExeclToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 序号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 企业名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 企业法人;
        private System.Windows.Forms.DataGridViewTextBoxColumn 联系方式;
        private System.Windows.Forms.DataGridViewTextBoxColumn 地址;
        private System.Windows.Forms.DataGridViewTextBoxColumn 注册资本;
        private System.Windows.Forms.DataGridViewTextBoxColumn 注册日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 营业状态;
        private System.Windows.Forms.DataGridViewTextBoxColumn 品牌产品;
        private System.Windows.Forms.DataGridViewTextBoxColumn 商标;
        private System.Windows.Forms.ToolStripMenuItem 注册ToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

