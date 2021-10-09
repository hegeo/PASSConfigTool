namespace PASS3ConfigTool
{
    partial class PASS3ConfigTool
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
            this.bfindproc = new System.Windows.Forms.Button();
            this.bfinddata = new System.Windows.Forms.Button();
            this.iprocurl = new System.Windows.Forms.TextBox();
            this.idataurl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ihostip = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.isqlhost = new System.Windows.Forms.TextBox();
            this.isqluser = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ihostuser = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ihostcode = new System.Windows.Forms.TextBox();
            this.isqlcode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.bupdate = new System.Windows.Forms.Button();
            this.logbox = new System.Windows.Forms.RichTextBox();
            this.bservice = new System.Windows.Forms.Button();
            this.bweb = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.outputclient = new System.Windows.Forms.LinkLabel();
            this.tbar = new System.Windows.Forms.Panel();
            this.close = new System.Windows.Forms.PictureBox();
            this.t3 = new System.Windows.Forms.Label();
            this.t2 = new System.Windows.Forms.Label();
            this.t1 = new System.Windows.Forms.Label();
            this.logborder = new System.Windows.Forms.Panel();
            this.bdcom = new System.Windows.Forms.Button();
            this.bdatabase = new System.Windows.Forms.Button();
            this.tbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.close)).BeginInit();
            this.logborder.SuspendLayout();
            this.SuspendLayout();
            // 
            // bfindproc
            // 
            this.bfindproc.BackColor = System.Drawing.Color.White;
            this.bfindproc.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.bfindproc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bfindproc.Font = new System.Drawing.Font("黑体", 9F);
            this.bfindproc.ForeColor = System.Drawing.Color.Black;
            this.bfindproc.Location = new System.Drawing.Point(580, 100);
            this.bfindproc.Name = "bfindproc";
            this.bfindproc.Size = new System.Drawing.Size(80, 25);
            this.bfindproc.TabIndex = 1;
            this.bfindproc.Text = "选 择";
            this.bfindproc.UseVisualStyleBackColor = false;
            this.bfindproc.Click += new System.EventHandler(this.bfindproc_Click);
            // 
            // bfinddata
            // 
            this.bfinddata.BackColor = System.Drawing.Color.White;
            this.bfinddata.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.bfinddata.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bfinddata.Font = new System.Drawing.Font("黑体", 9F);
            this.bfinddata.ForeColor = System.Drawing.Color.Black;
            this.bfinddata.Location = new System.Drawing.Point(580, 132);
            this.bfinddata.Name = "bfinddata";
            this.bfinddata.Size = new System.Drawing.Size(80, 25);
            this.bfinddata.TabIndex = 3;
            this.bfinddata.Text = "选 择";
            this.bfinddata.UseVisualStyleBackColor = false;
            this.bfinddata.Click += new System.EventHandler(this.bfinddata_Click);
            // 
            // iprocurl
            // 
            this.iprocurl.BackColor = System.Drawing.SystemColors.Window;
            this.iprocurl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.iprocurl.Location = new System.Drawing.Point(100, 100);
            this.iprocurl.Name = "iprocurl";
            this.iprocurl.Size = new System.Drawing.Size(470, 25);
            this.iprocurl.TabIndex = 0;
            // 
            // idataurl
            // 
            this.idataurl.BackColor = System.Drawing.Color.White;
            this.idataurl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.idataurl.Location = new System.Drawing.Point(100, 132);
            this.idataurl.Name = "idataurl";
            this.idataurl.Size = new System.Drawing.Size(470, 25);
            this.idataurl.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 9F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(27, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "程序路径";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("黑体", 9F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(28, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "数据路径";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(16, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "服务配置";
            // 
            // ihostip
            // 
            this.ihostip.BackColor = System.Drawing.SystemColors.Window;
            this.ihostip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ihostip.Location = new System.Drawing.Point(99, 198);
            this.ihostip.Name = "ihostip";
            this.ihostip.Size = new System.Drawing.Size(139, 25);
            this.ihostip.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("黑体", 9F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(31, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "服务器";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("黑体", 9F);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(32, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "数据库";
            // 
            // isqlhost
            // 
            this.isqlhost.BackColor = System.Drawing.SystemColors.Window;
            this.isqlhost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.isqlhost.Location = new System.Drawing.Point(99, 232);
            this.isqlhost.Name = "isqlhost";
            this.isqlhost.Size = new System.Drawing.Size(139, 25);
            this.isqlhost.TabIndex = 7;
            // 
            // isqluser
            // 
            this.isqluser.BackColor = System.Drawing.SystemColors.Window;
            this.isqluser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.isqluser.Location = new System.Drawing.Point(323, 235);
            this.isqluser.Name = "isqluser";
            this.isqluser.Size = new System.Drawing.Size(139, 25);
            this.isqluser.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("黑体", 9F);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(253, 238);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "SA 用户";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("黑体", 9F);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(252, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "系统用户";
            // 
            // ihostuser
            // 
            this.ihostuser.BackColor = System.Drawing.SystemColors.Window;
            this.ihostuser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ihostuser.Location = new System.Drawing.Point(323, 198);
            this.ihostuser.Name = "ihostuser";
            this.ihostuser.Size = new System.Drawing.Size(139, 25);
            this.ihostuser.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("黑体", 9F);
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(478, 201);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 15);
            this.label8.TabIndex = 16;
            this.label8.Text = "密码";
            // 
            // ihostcode
            // 
            this.ihostcode.BackColor = System.Drawing.SystemColors.Window;
            this.ihostcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ihostcode.Location = new System.Drawing.Point(521, 198);
            this.ihostcode.Name = "ihostcode";
            this.ihostcode.Size = new System.Drawing.Size(139, 25);
            this.ihostcode.TabIndex = 6;
            // 
            // isqlcode
            // 
            this.isqlcode.BackColor = System.Drawing.SystemColors.Window;
            this.isqlcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.isqlcode.Location = new System.Drawing.Point(521, 232);
            this.isqlcode.Name = "isqlcode";
            this.isqlcode.Size = new System.Drawing.Size(137, 25);
            this.isqlcode.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("黑体", 9F);
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(477, 238);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 15);
            this.label9.TabIndex = 17;
            this.label9.Text = "密码";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(15, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 15);
            this.label10.TabIndex = 19;
            this.label10.Text = "安装配置";
            // 
            // bupdate
            // 
            this.bupdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(154)))), ((int)(((byte)(240)))));
            this.bupdate.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.bupdate.FlatAppearance.BorderSize = 0;
            this.bupdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bupdate.Font = new System.Drawing.Font("黑体", 9F);
            this.bupdate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bupdate.Location = new System.Drawing.Point(18, 490);
            this.bupdate.Name = "bupdate";
            this.bupdate.Size = new System.Drawing.Size(80, 25);
            this.bupdate.TabIndex = 11;
            this.bupdate.Text = "保存配置";
            this.bupdate.UseVisualStyleBackColor = false;
            this.bupdate.Click += new System.EventHandler(this.bupdate_Click);
            // 
            // logbox
            // 
            this.logbox.BackColor = System.Drawing.SystemColors.Window;
            this.logbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logbox.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.logbox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.logbox.Location = new System.Drawing.Point(4, 3);
            this.logbox.Name = "logbox";
            this.logbox.Size = new System.Drawing.Size(625, 175);
            this.logbox.TabIndex = 10;
            this.logbox.Text = "欢迎使用，以下是使用说明：\n①调整配置，仅需选择程序路径，调整配置后点击更新配置即可\n②迁移或重装服务，还需选择数据库路径，请按右下角顺序进行";
            // 
            // bservice
            // 
            this.bservice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(154)))), ((int)(((byte)(240)))));
            this.bservice.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.bservice.FlatAppearance.BorderSize = 0;
            this.bservice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bservice.Font = new System.Drawing.Font("黑体", 9F);
            this.bservice.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bservice.Location = new System.Drawing.Point(425, 490);
            this.bservice.Name = "bservice";
            this.bservice.Size = new System.Drawing.Size(80, 25);
            this.bservice.TabIndex = 14;
            this.bservice.Text = "创建服务";
            this.bservice.UseVisualStyleBackColor = false;
            this.bservice.Click += new System.EventHandler(this.bservice_Click);
            // 
            // bweb
            // 
            this.bweb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(154)))), ((int)(((byte)(240)))));
            this.bweb.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.bweb.FlatAppearance.BorderSize = 0;
            this.bweb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bweb.Font = new System.Drawing.Font("黑体", 9F);
            this.bweb.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bweb.Location = new System.Drawing.Point(587, 490);
            this.bweb.Name = "bweb";
            this.bweb.Size = new System.Drawing.Size(80, 25);
            this.bweb.TabIndex = 16;
            this.bweb.Text = "配置Web";
            this.bweb.UseVisualStyleBackColor = false;
            this.bweb.Click += new System.EventHandler(this.bweb_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(13, 269);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 15);
            this.label11.TabIndex = 25;
            this.label11.Text = "日志记录";
            // 
            // outputclient
            // 
            this.outputclient.ActiveLinkColor = System.Drawing.Color.LightGray;
            this.outputclient.AutoSize = true;
            this.outputclient.Font = new System.Drawing.Font("黑体", 9F);
            this.outputclient.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.outputclient.Location = new System.Drawing.Point(104, 494);
            this.outputclient.Name = "outputclient";
            this.outputclient.Size = new System.Drawing.Size(87, 15);
            this.outputclient.TabIndex = 12;
            this.outputclient.TabStop = true;
            this.outputclient.Text = "导出客户端";
            this.outputclient.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.outputclient_LinkClicked);
            // 
            // tbar
            // 
            this.tbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(114)))), ((int)(((byte)(240)))));
            this.tbar.Controls.Add(this.close);
            this.tbar.Controls.Add(this.t3);
            this.tbar.Controls.Add(this.t2);
            this.tbar.Controls.Add(this.t1);
            this.tbar.Location = new System.Drawing.Point(-2, 0);
            this.tbar.Name = "tbar";
            this.tbar.Size = new System.Drawing.Size(690, 65);
            this.tbar.TabIndex = 29;
            this.tbar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbar_MouseDown);
            this.tbar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tbar_MouseMove);
            // 
            // close
            // 
            this.close.BackgroundImage = global::PASS3ConfigTool.Properties.Resources.exit;
            this.close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.close.Location = new System.Drawing.Point(645, 21);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(30, 25);
            this.close.TabIndex = 3;
            this.close.TabStop = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // t3
            // 
            this.t3.AutoSize = true;
            this.t3.Font = new System.Drawing.Font("黑体", 9F);
            this.t3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.t3.Location = new System.Drawing.Point(128, 37);
            this.t3.Name = "t3";
            this.t3.Size = new System.Drawing.Size(63, 15);
            this.t3.TabIndex = 2;
            this.t3.Text = "Ver 1.0";
            // 
            // t2
            // 
            this.t2.AutoSize = true;
            this.t2.Font = new System.Drawing.Font("黑体", 9F);
            this.t2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.t2.Location = new System.Drawing.Point(127, 21);
            this.t2.Name = "t2";
            this.t2.Size = new System.Drawing.Size(103, 15);
            this.t2.TabIndex = 1;
            this.t2.Text = "服务配置工具";
            // 
            // t1
            // 
            this.t1.AutoSize = true;
            this.t1.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.t1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.t1.Location = new System.Drawing.Point(14, 16);
            this.t1.Name = "t1";
            this.t1.Size = new System.Drawing.Size(122, 40);
            this.t1.TabIndex = 0;
            this.t1.Text = "PASS3";
            // 
            // logborder
            // 
            this.logborder.BackColor = System.Drawing.Color.White;
            this.logborder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logborder.Controls.Add(this.logbox);
            this.logborder.Location = new System.Drawing.Point(30, 290);
            this.logborder.Name = "logborder";
            this.logborder.Size = new System.Drawing.Size(630, 183);
            this.logborder.TabIndex = 30;
            // 
            // bdcom
            // 
            this.bdcom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(154)))), ((int)(((byte)(240)))));
            this.bdcom.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.bdcom.FlatAppearance.BorderSize = 0;
            this.bdcom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bdcom.Font = new System.Drawing.Font("黑体", 9F);
            this.bdcom.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bdcom.Location = new System.Drawing.Point(506, 490);
            this.bdcom.Name = "bdcom";
            this.bdcom.Size = new System.Drawing.Size(80, 25);
            this.bdcom.TabIndex = 15;
            this.bdcom.Text = "更新权限";
            this.bdcom.UseVisualStyleBackColor = false;
            this.bdcom.Click += new System.EventHandler(this.bdcom_Click);
            // 
            // bdatabase
            // 
            this.bdatabase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(154)))), ((int)(((byte)(240)))));
            this.bdatabase.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.bdatabase.FlatAppearance.BorderSize = 0;
            this.bdatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bdatabase.Font = new System.Drawing.Font("黑体", 9F);
            this.bdatabase.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bdatabase.Location = new System.Drawing.Point(344, 490);
            this.bdatabase.Name = "bdatabase";
            this.bdatabase.Size = new System.Drawing.Size(80, 25);
            this.bdatabase.TabIndex = 13;
            this.bdatabase.Text = "挂载数据";
            this.bdatabase.UseVisualStyleBackColor = false;
            this.bdatabase.Click += new System.EventHandler(this.bdatabase_Click);
            // 
            // PASS3ConfigTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(685, 535);
            this.Controls.Add(this.logborder);
            this.Controls.Add(this.tbar);
            this.Controls.Add(this.outputclient);
            this.Controls.Add(this.bdatabase);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.bweb);
            this.Controls.Add(this.bdcom);
            this.Controls.Add(this.bservice);
            this.Controls.Add(this.bupdate);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.isqlcode);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ihostcode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ihostuser);
            this.Controls.Add(this.isqluser);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.isqlhost);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ihostip);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.idataurl);
            this.Controls.Add(this.iprocurl);
            this.Controls.Add(this.bfinddata);
            this.Controls.Add(this.bfindproc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PASS3ConfigTool";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.tbar.ResumeLayout(false);
            this.tbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.close)).EndInit();
            this.logborder.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bfindproc;
        private System.Windows.Forms.Button bfinddata;
        private System.Windows.Forms.TextBox iprocurl;
        private System.Windows.Forms.TextBox idataurl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ihostip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox isqlhost;
        private System.Windows.Forms.TextBox isqluser;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ihostuser;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox ihostcode;
        private System.Windows.Forms.TextBox isqlcode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button bupdate;
        private System.Windows.Forms.RichTextBox logbox;
        private System.Windows.Forms.Button bservice;
        private System.Windows.Forms.Button bweb;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.LinkLabel outputclient;
        private System.Windows.Forms.Panel tbar;
        private System.Windows.Forms.Panel logborder;
        private System.Windows.Forms.Label t2;
        private System.Windows.Forms.Label t1;
        private System.Windows.Forms.Label t3;
        private System.Windows.Forms.PictureBox close;
        private System.Windows.Forms.Button bdcom;
        private System.Windows.Forms.Button bdatabase;
    }
}

