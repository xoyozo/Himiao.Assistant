namespace Himiao.Assistant
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.label1 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.timer_setTime = new System.Windows.Forms.Timer(this.components);
      this.timer_Application_Start = new System.Windows.Forms.Timer(this.components);
      this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
      this.timer_1s = new System.Windows.Forms.Timer(this.components);
      this.timer_coming_times_get = new System.Windows.Forms.Timer(this.components);
      this.label2 = new System.Windows.Forms.Label();
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.mi_main = new System.Windows.Forms.ToolStripMenuItem();
      this.mi_exit = new System.Windows.Forms.ToolStripMenuItem();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(24, 23);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(41, 12);
      this.label1.TabIndex = 0;
      this.label1.Text = "label1";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(24, 92);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(185, 12);
      this.label3.TabIndex = 2;
      this.label3.Text = "托盘左键访问网站，右键弹出菜单";
      // 
      // timer1
      // 
      this.timer1.Enabled = true;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // timer_setTime
      // 
      this.timer_setTime.Enabled = true;
      this.timer_setTime.Interval = 600000;
      this.timer_setTime.Tick += new System.EventHandler(this.timer_setTime_Tick);
      // 
      // timer_Application_Start
      // 
      this.timer_Application_Start.Enabled = true;
      this.timer_Application_Start.Tick += new System.EventHandler(this.timer_Application_Start_Tick);
      // 
      // notifyIcon1
      // 
      this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
      this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
      this.notifyIcon1.Text = "秒小秘";
      this.notifyIcon1.Visible = true;
      this.notifyIcon1.BalloonTipClicked += new System.EventHandler(this.notifyIcon1_BalloonTipClicked);
      this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
      this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
      // 
      // timer_1s
      // 
      this.timer_1s.Enabled = true;
      this.timer_1s.Interval = 1000;
      this.timer_1s.Tick += new System.EventHandler(this.timer_1s_Tick);
      // 
      // timer_coming_times_get
      // 
      this.timer_coming_times_get.Enabled = true;
      this.timer_coming_times_get.Interval = 600000;
      this.timer_coming_times_get.Tick += new System.EventHandler(this.timer_coming_times_get_Tick);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(23, 159);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(41, 12);
      this.label2.TabIndex = 3;
      this.label2.Text = "不多开";
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_main,
            this.mi_exit});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(137, 48);
      // 
      // mi_main
      // 
      this.mi_main.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold);
      this.mi_main.Name = "mi_main";
      this.mi_main.Size = new System.Drawing.Size(136, 22);
      this.mi_main.Text = "隐藏主界面";
      this.mi_main.Click += new System.EventHandler(this.mi_main_Click);
      // 
      // mi_exit
      // 
      this.mi_exit.Name = "mi_exit";
      this.mi_exit.Size = new System.Drawing.Size(136, 22);
      this.mi_exit.Text = "退出";
      this.mi_exit.Click += new System.EventHandler(this.mi_exit_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 261);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "秒小秘";
      this.TopMost = true;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.Timer timer_setTime;
    private System.Windows.Forms.Timer timer_Application_Start;
    private System.Windows.Forms.NotifyIcon notifyIcon1;
    private System.Windows.Forms.Timer timer_1s;
    private System.Windows.Forms.Timer timer_coming_times_get;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem mi_main;
    private System.Windows.Forms.ToolStripMenuItem mi_exit;
  }
}

