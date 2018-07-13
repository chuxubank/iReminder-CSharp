namespace iReminder
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_newdeck = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_deletdeck = new System.Windows.Forms.Button();
            this.btn_learndeck = new System.Windows.Forms.Button();
            this.btn_editdeck = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.用户手册ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.重建数据库RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清除空卡片CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出所有生卡片到ExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.压缩数据库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重记选择卡组ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.添加卡组AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重命名卡组RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除卡组DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.创建筛选卡组ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsb_newcard = new System.Windows.Forms.ToolStripButton();
            this.tsb_browse = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.btn_newdeck, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_deletdeck, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btn_learndeck, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.btn_editdeck, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 51);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(532, 280);
            this.tableLayoutPanel1.TabIndex = 13;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // btn_newdeck
            // 
            this.btn_newdeck.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_newdeck.Image = global::iReminder.Properties.Resources.plus;
            this.btn_newdeck.Location = new System.Drawing.Point(44, 232);
            this.btn_newdeck.Name = "btn_newdeck";
            this.btn_newdeck.Size = new System.Drawing.Size(45, 45);
            this.btn_newdeck.TabIndex = 14;
            this.btn_newdeck.UseVisualStyleBackColor = true;
            this.btn_newdeck.Click += new System.EventHandler(this.btn_newdeck_Click);
            this.btn_newdeck.MouseEnter += new System.EventHandler(this.btn_newdeck_MouseEnter);
            this.btn_newdeck.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btn_newdeck.MouseHover += new System.EventHandler(this.btn_MouseHover);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 4);
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 22);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(526, 204);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // btn_deletdeck
            // 
            this.btn_deletdeck.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_deletdeck.Image = global::iReminder.Properties.Resources.minus;
            this.btn_deletdeck.Location = new System.Drawing.Point(310, 232);
            this.btn_deletdeck.Name = "btn_deletdeck";
            this.btn_deletdeck.Size = new System.Drawing.Size(45, 45);
            this.btn_deletdeck.TabIndex = 14;
            this.btn_deletdeck.UseVisualStyleBackColor = true;
            this.btn_deletdeck.Click += new System.EventHandler(this.btn_deletdeck_Click);
            this.btn_deletdeck.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btn_deletdeck.MouseHover += new System.EventHandler(this.btn_MouseHover);
            // 
            // btn_learndeck
            // 
            this.btn_learndeck.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_learndeck.Image = global::iReminder.Properties.Resources.play;
            this.btn_learndeck.Location = new System.Drawing.Point(443, 232);
            this.btn_learndeck.Name = "btn_learndeck";
            this.btn_learndeck.Size = new System.Drawing.Size(45, 45);
            this.btn_learndeck.TabIndex = 15;
            this.btn_learndeck.UseVisualStyleBackColor = true;
            this.btn_learndeck.Click += new System.EventHandler(this.btn_learndeck_Click);
            this.btn_learndeck.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btn_learndeck.MouseHover += new System.EventHandler(this.btn_MouseHover);
            // 
            // btn_editdeck
            // 
            this.btn_editdeck.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_editdeck.Image = global::iReminder.Properties.Resources.edit;
            this.btn_editdeck.Location = new System.Drawing.Point(177, 232);
            this.btn_editdeck.Name = "btn_editdeck";
            this.btn_editdeck.Size = new System.Drawing.Size(45, 45);
            this.btn_editdeck.TabIndex = 13;
            this.btn_editdeck.UseVisualStyleBackColor = true;
            this.btn_editdeck.Click += new System.EventHandler(this.btn_editdeck_Click);
            this.btn_editdeck.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btn_editdeck.MouseHover += new System.EventHandler(this.btn_MouseHover);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 4);
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(233, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 19);
            this.label1.TabIndex = 16;
            this.label1.Text = "卡组列表";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.关于ToolStripMenuItem.Text = "关于(&A)";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // 用户手册ToolStripMenuItem
            // 
            this.用户手册ToolStripMenuItem.Name = "用户手册ToolStripMenuItem";
            this.用户手册ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.用户手册ToolStripMenuItem.Text = "用户手册(&G) F1";
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.用户手册ToolStripMenuItem,
            this.toolStripSeparator2,
            this.关于ToolStripMenuItem});
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.帮助HToolStripMenuItem.Text = "帮助(&H)";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(155, 6);
            // 
            // 重建数据库RToolStripMenuItem
            // 
            this.重建数据库RToolStripMenuItem.Name = "重建数据库RToolStripMenuItem";
            this.重建数据库RToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.重建数据库RToolStripMenuItem.Text = "清空数据库";
            this.重建数据库RToolStripMenuItem.Click += new System.EventHandler(this.重建数据库RToolStripMenuItem_Click);
            // 
            // 清除空卡片CToolStripMenuItem
            // 
            this.清除空卡片CToolStripMenuItem.Name = "清除空卡片CToolStripMenuItem";
            this.清除空卡片CToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.清除空卡片CToolStripMenuItem.Text = "清除空卡片(&C)";
            this.清除空卡片CToolStripMenuItem.Click += new System.EventHandler(this.清除空卡片CToolStripMenuItem_Click);
            // 
            // 工具TToolStripMenuItem
            // 
            this.工具TToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清除空卡片CToolStripMenuItem,
            this.导出所有生卡片到ExcelToolStripMenuItem,
            this.压缩数据库ToolStripMenuItem,
            this.重建数据库RToolStripMenuItem});
            this.工具TToolStripMenuItem.Name = "工具TToolStripMenuItem";
            this.工具TToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.工具TToolStripMenuItem.Text = "工具(&T)";
            // 
            // 导出所有生卡片到ExcelToolStripMenuItem
            // 
            this.导出所有生卡片到ExcelToolStripMenuItem.Name = "导出所有生卡片到ExcelToolStripMenuItem";
            this.导出所有生卡片到ExcelToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.导出所有生卡片到ExcelToolStripMenuItem.Text = "导出所有生卡片到Excel(&E)";
            this.导出所有生卡片到ExcelToolStripMenuItem.Click += new System.EventHandler(this.导出所有生卡片到ExcelEToolStripMenuItem_Click);
            // 
            // 压缩数据库ToolStripMenuItem
            // 
            this.压缩数据库ToolStripMenuItem.Name = "压缩数据库ToolStripMenuItem";
            this.压缩数据库ToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.压缩数据库ToolStripMenuItem.Text = "压缩数据库(&R)";
            this.压缩数据库ToolStripMenuItem.Click += new System.EventHandler(this.压缩数据库ToolStripMenuItem_Click);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.重记选择卡组ToolStripMenuItem,
            this.toolStripSeparator1,
            this.添加卡组AToolStripMenuItem,
            this.重命名卡组RToolStripMenuItem,
            this.删除卡组DToolStripMenuItem,
            this.创建筛选卡组ToolStripMenuItem});
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.编辑ToolStripMenuItem.Text = "编辑(&E)";
            // 
            // 重记选择卡组ToolStripMenuItem
            // 
            this.重记选择卡组ToolStripMenuItem.Name = "重记选择卡组ToolStripMenuItem";
            this.重记选择卡组ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.重记选择卡组ToolStripMenuItem.Text = "重记所选卡组";
            this.重记选择卡组ToolStripMenuItem.Click += new System.EventHandler(this.重记选择卡组ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // 添加卡组AToolStripMenuItem
            // 
            this.添加卡组AToolStripMenuItem.Name = "添加卡组AToolStripMenuItem";
            this.添加卡组AToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.添加卡组AToolStripMenuItem.Text = "添加卡组(&A)";
            this.添加卡组AToolStripMenuItem.Click += new System.EventHandler(this.btn_newdeck_Click);
            // 
            // 重命名卡组RToolStripMenuItem
            // 
            this.重命名卡组RToolStripMenuItem.Name = "重命名卡组RToolStripMenuItem";
            this.重命名卡组RToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.重命名卡组RToolStripMenuItem.Text = "重命名卡组(&R)";
            this.重命名卡组RToolStripMenuItem.Click += new System.EventHandler(this.btn_editdeck_Click);
            // 
            // 删除卡组DToolStripMenuItem
            // 
            this.删除卡组DToolStripMenuItem.Name = "删除卡组DToolStripMenuItem";
            this.删除卡组DToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.删除卡组DToolStripMenuItem.Text = "删除卡组(&D)";
            this.删除卡组DToolStripMenuItem.Click += new System.EventHandler(this.btn_deletdeck_Click);
            // 
            // 创建筛选卡组ToolStripMenuItem
            // 
            this.创建筛选卡组ToolStripMenuItem.Name = "创建筛选卡组ToolStripMenuItem";
            this.创建筛选卡组ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.创建筛选卡组ToolStripMenuItem.Text = "创建筛选卡组";
            this.创建筛选卡组ToolStripMenuItem.Click += new System.EventHandler(this.创建筛选卡组ToolStripMenuItem_Click);
            // 
            // 退出EToolStripMenuItem
            // 
            this.退出EToolStripMenuItem.Name = "退出EToolStripMenuItem";
            this.退出EToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.退出EToolStripMenuItem.Text = "退出(&E)";
            this.退出EToolStripMenuItem.Click += new System.EventHandler(this.退出EToolStripMenuItem_Click);
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出EToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.文件ToolStripMenuItem.Text = "文件(&F)";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.编辑ToolStripMenuItem,
            this.工具TToolStripMenuItem,
            this.帮助HToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(532, 25);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_newcard,
            this.tsb_browse});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(532, 26);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsb_newcard
            // 
            this.tsb_newcard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsb_newcard.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsb_newcard.Image = ((System.Drawing.Image)(resources.GetObject("tsb_newcard.Image")));
            this.tsb_newcard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_newcard.Name = "tsb_newcard";
            this.tsb_newcard.Size = new System.Drawing.Size(41, 23);
            this.tsb_newcard.Text = "新卡";
            this.tsb_newcard.Click += new System.EventHandler(this.tsb_newcard_Click);
            // 
            // tsb_browse
            // 
            this.tsb_browse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsb_browse.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsb_browse.Image = ((System.Drawing.Image)(resources.GetObject("tsb_browse.Image")));
            this.tsb_browse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_browse.Name = "tsb_browse";
            this.tsb_browse.Size = new System.Drawing.Size(41, 23);
            this.tsb_browse.Text = "浏览";
            this.tsb_browse.Click += new System.EventHandler(this.tsb_browse_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 331);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iReminder";
            this.Activated += new System.EventHandler(this.Main_Activated);
            this.Load += new System.EventHandler(this.Main_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_editdeck;
        private System.Windows.Forms.Button btn_learndeck;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_deletdeck;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 用户手册ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 重建数据库RToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清除空卡片CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripButton tsb_newcard;
        private System.Windows.Forms.ToolStripButton tsb_browse;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_newdeck;
        private System.Windows.Forms.ToolStripMenuItem 重记选择卡组ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重命名卡组RToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加卡组AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除卡组DToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem 压缩数据库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 创建筛选卡组ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出所有生卡片到ExcelToolStripMenuItem;
    }
}

