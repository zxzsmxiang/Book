namespace CrawlerWin
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQDUrl = new System.Windows.Forms.TextBox();
            this.btnQDRead = new System.Windows.Forms.Button();
            this.picImg = new System.Windows.Forms.PictureBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblBookName = new System.Windows.Forms.Label();
            this.txtSummary = new System.Windows.Forms.TextBox();
            this.timerBrower = new System.Windows.Forms.Timer(this.components);
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnBQG = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.lstBookItems = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.picImg)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "起点地址:";
            // 
            // txtQDUrl
            // 
            this.txtQDUrl.Location = new System.Drawing.Point(104, 39);
            this.txtQDUrl.Name = "txtQDUrl";
            this.txtQDUrl.Size = new System.Drawing.Size(388, 21);
            this.txtQDUrl.TabIndex = 1;
            // 
            // btnQDRead
            // 
            this.btnQDRead.Location = new System.Drawing.Point(522, 37);
            this.btnQDRead.Name = "btnQDRead";
            this.btnQDRead.Size = new System.Drawing.Size(75, 23);
            this.btnQDRead.TabIndex = 2;
            this.btnQDRead.Text = "读取";
            this.btnQDRead.UseVisualStyleBackColor = true;
            this.btnQDRead.Click += new System.EventHandler(this.btnQDRead_Click);
            // 
            // picImg
            // 
            this.picImg.Location = new System.Drawing.Point(12, 106);
            this.picImg.Name = "picImg";
            this.picImg.Size = new System.Drawing.Size(198, 273);
            this.picImg.TabIndex = 3;
            this.picImg.TabStop = false;
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Font = new System.Drawing.Font("宋体", 12F);
            this.lblAuthor.Location = new System.Drawing.Point(216, 160);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(40, 16);
            this.lblAuthor.TabIndex = 5;
            this.lblAuthor.Text = "作者";
            // 
            // lblBookName
            // 
            this.lblBookName.AutoSize = true;
            this.lblBookName.Font = new System.Drawing.Font("宋体", 12F);
            this.lblBookName.Location = new System.Drawing.Point(216, 106);
            this.lblBookName.Name = "lblBookName";
            this.lblBookName.Size = new System.Drawing.Size(40, 16);
            this.lblBookName.TabIndex = 4;
            this.lblBookName.Text = "书名";
            // 
            // txtSummary
            // 
            this.txtSummary.Location = new System.Drawing.Point(219, 201);
            this.txtSummary.Multiline = true;
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.Size = new System.Drawing.Size(354, 114);
            this.txtSummary.TabIndex = 6;
            // 
            // timerBrower
            // 
            this.timerBrower.Tick += new System.EventHandler(this.timerBrower_Tick);
            // 
            // webBrowser
            // 
            this.webBrowser.Location = new System.Drawing.Point(615, 116);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(705, 357);
            this.webBrowser.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(93, 468);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "插入主表";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(219, 468);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "插入目录";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnBQG
            // 
            this.btnBQG.Location = new System.Drawing.Point(648, 37);
            this.btnBQG.Name = "btnBQG";
            this.btnBQG.Size = new System.Drawing.Size(75, 23);
            this.btnBQG.TabIndex = 10;
            this.btnBQG.Text = "笔趣阁抓取";
            this.btnBQG.UseVisualStyleBackColor = true;
            this.btnBQG.Click += new System.EventHandler(this.btnBQG_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(359, 468);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "导出EXCEL";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lstBookItems
            // 
            this.lstBookItems.Location = new System.Drawing.Point(219, 336);
            this.lstBookItems.Name = "lstBookItems";
            this.lstBookItems.Size = new System.Drawing.Size(354, 102);
            this.lstBookItems.TabIndex = 11;
            this.lstBookItems.UseCompatibleStateImageBehavior = false;
            this.lstBookItems.View = System.Windows.Forms.View.List;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 507);
            this.Controls.Add(this.lstBookItems);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnBQG);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.txtSummary);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblBookName);
            this.Controls.Add(this.picImg);
            this.Controls.Add(this.btnQDRead);
            this.Controls.Add(this.txtQDUrl);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQDUrl;
        private System.Windows.Forms.Button btnQDRead;
        private System.Windows.Forms.PictureBox picImg;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblBookName;
        private System.Windows.Forms.TextBox txtSummary;
        private System.Windows.Forms.Timer timerBrower;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnBQG;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListView lstBookItems;
    }
}

