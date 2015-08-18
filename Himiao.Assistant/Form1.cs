using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Himiao.Assistant
{
  public partial class Form1 : Form
  {
    /// <summary>标识是否已显示过“在系统托盘找到秒小秘”的提醒</summary>
    bool notificationTipShown = false;

    public Form1()
    {
      InitializeComponent();

      Location = new Point(0, (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
    }

    /// <summary>
    /// 应用程序启动时执行（仅一次）
    /// </summary>
    private void timer_Application_Start_Tick(object sender, EventArgs e)
    {
      (sender as Timer).Enabled = false;

      zTime.SetTime();
      zTimes.SetTimes();
    }

    private void timer_setTime_Tick(object sender, EventArgs e)
    {
      zTime.SetTime();
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      DateTime t = zTime.Now;
      DateTime? next = zTimes.ComingTime;
      label1.Text = t.ToString("H:mm:ss")
        + (next.HasValue ? " → " + (next - t).ToString().Substring(0, 10) + " → " + next.Value.ToString("H:mm:ss") : "");

    }

    /// <summary>
    /// 1 秒钟执行一次（内部对“秒”作判断，实现 1 分钟执行一次）
    /// </summary>
    private void timer_1s_Tick(object sender, EventArgs e)
    {
      // 气球提醒（若本分钟有秒杀，为了不影响用户抢购，第 10 秒之后提醒）
      if (zTimes.HaveOnInMinute ? zTime.Now.Second > 10 : true)
      {
        KeyValuePair<DateTime, int>? item = zTimes.GetTipTimeInMinute();

        if (item != null)
        {
          // notifyIcon1.ShowBalloonTip(10000, "离 " + item.Value.Key.ToString("HH:mm") + " 还有 " + item.Value.Value + " 分钟", "点击查看", ToolTipIcon.None);
          notifyIcon1.BalloonTipTitle = "离 " + item.Value.Key.ToString("HH:mm") + " 还有 " + item.Value.Value + " 分钟";
          notifyIcon1.BalloonTipText = "点击查看";
          notifyIcon1.ShowBalloonTip(10000);
        }
      }

      // 秒杀结束自动隐藏主窗口
      if (zTimes.HaveOnInMinute && zTime.Now.Second == 15)
      {
        Hide();
      }

      // 更改系统托盘的 tooltip
      if (zTime.Now.Second == 0)
      {
        DateTime? next = zTimes.ComingTime;
        if (next.HasValue)
        {
          notifyIcon1.Text = "秒小秘\r\n下次秒杀时间：" + next.Value.ToString("HH:mm");
        }
        else
        {
          notifyIcon1.Text = "秒小秘";
        }
      }
    }

    private void timer_coming_times_get_Tick(object sender, EventArgs e)
    {
      zTimes.SetTimes();
    }

    private void GoToSite()
    {
      DateTime? comingTime = zTimes.ComingTime;

      xRender(true);

      if (comingTime != null && comingTime < zTime.Now.AddMinutes(10)) // 若十分钟内有秒杀，则转到该时刻秒杀列表
      {
        System.Diagnostics.Process.Start("http://www.himiao.com/" + comingTime.Value.ToString("yyyyMMdd/HHmm/"));
      }
      else // 否则转到首页
      {
        System.Diagnostics.Process.Start("http://www.himiao.com/");
      }
    }

    private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
    {
      GoToSite();
    }

    private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
    {
      switch (e.Button)
      {
        case MouseButtons.Left:
          xRender(!Visible);
          break;
      }
    }

    private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      GoToSite();
    }

    private void xRender(bool show)
    {
      if (show) { Show(); mi_main.Text = "隐藏主界面"; }
      else { Hide(); mi_main.Text = "显示主界面"; }
    }

    private void mi_main_Click(object sender, EventArgs e)
    {
      xRender(!Visible);
    }

    private void mi_exit_Click(object sender, EventArgs e)
    {
      xExit();
    }
    private void xExit()
    {
      Close();
      Dispose();
      Application.Exit();
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (e.CloseReason == CloseReason.UserClosing)
      {
        if (!notificationTipShown)
        {
          notificationTipShown = true;
          // notifyIcon1.ShowBalloonTip(5000, "秒小秘会在下次秒杀之前通知您哦~", "您可以在系统托盘找到秒小秘，双击图标直达嗨秒网。", ToolTipIcon.None);
          notifyIcon1.BalloonTipTitle = "秒小秘会在下次秒杀之前通知您哦~";
          notifyIcon1.BalloonTipText = "您可以在系统托盘找到秒小秘，双击图标直达嗨秒网。";
          notifyIcon1.ShowBalloonTip(5000);
        }
        e.Cancel = true;
        xRender(false);
      }
    }
  }
}
