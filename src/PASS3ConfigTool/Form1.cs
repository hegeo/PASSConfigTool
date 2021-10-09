using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Management;
using System.Text;
using System.Windows.Forms;

namespace PASS3ConfigTool
{
    public partial class PASS3ConfigTool : Form
    {
        private Point mousePoint = new Point();

        public PASS3ConfigTool()
        {
          
            InitializeComponent();
        }

        private void bfindproc_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.Description = "请选择PASS3的程序所在文件夹，\r\n一般为\"medicomsoftware\"";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    MessageBox.Show(this, "文件夹路径不能为空", "提示");
                    return;
                }
                this.iprocurl.Text = dialog.SelectedPath.ToString();
               
            }
        }
            private void bfinddata_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.Description = "请选择PASS3的数据库文件夹，\r\n一般为\"medicomdata\"";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    MessageBox.Show(this, "文件夹路径不能为空", "提示");
                    return;
                }
                this.idataurl.Text = dialog.SelectedPath.ToString();
            }
        }

        private void bupdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定保存配置?", "操作确认",
              MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

            }
           
        }

        private void bdatabase_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定挂载数据库?", "操作确认",
              MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //Do
            }
        }

        private void bservice_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定创建服务程序?", "操作确认",  MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //组策略关闭密码策略
                string a = "$";
                Process.Start("cmd.exe", @" /c echo [version] >gp.inf");
                Process.Start("cmd.exe", @" /c echo signature= "+" \"$CHICAGO$\" >>gp.inf");
                Process.Start("cmd.exe", @" /c echo [System Access] >>gp.inf");
                Process.Start("cmd.exe", @" /c echo PasswordComplexity = 0 >>gp.inf");
                Process.Start("cmd.exe", @" /c secedit /configure /db gp.sdb /cfg gp.inf");
                Process.Start("cmd.exe", @" /c del /f /q gp.inf gp.sdb");

                //添加medicom系统用户
                Process.Start("cmd.exe", @" /c net user medicom medicom /add");
                Process.Start("cmd.exe", @" /c net localgroup Administrators medicom /add");
                Process.Start("cmd.exe", @" /c net localgroup Distributed COM Users medicom /add");
                Process.Start("cmd.exe", @" /c net user admin /active:yes");
                
                //注册dif,helper,pa服务
                Process.Start("cmd.exe", @" /c sc create MCDIFPASS binpath ="+iprocurl.Text+"\\PASS\\PASSCore.exe  start= auto displayname= Medicom DIFPASSCore Service");
                Process.Start("cmd.exe", @" /c sc create MCDIFPASSHLP binpath =" + iprocurl.Text + "\\PASS\\PASSHelper.exe  start= auto displayname= Medicom DIFPASSHelper Service");
                Process.Start("cmd.exe", @" /c sc create MCDIFPASSHLP binpath =" + iprocurl.Text + "\\PASSService\\ClinicService.exe  start= auto displayname= Medicom Clinic Service");

                //注册dif,helper COM组件
                //32位
                RegistryKey regkeySetKey64 = Registry.ClassesRoot.OpenSubKey(@"Wow6432Node\AppID\", true).CreateSubKey("{6D082A76-9C40-11D6-A4F9-00D059236DA5}"); 
                regkeySetKey64.SetValue("@", "Medicom DIFPASSCore");
                regkeySetKey64.SetValue("RunAs", ".\\medicom");
                regkeySetKey64.SetValue("AccessPermission", "hex:01,00,04,80,6c,00,00,00,88,00,00,00,00,00,00,00,14,00,\\ 00, 00, 02, 00, 58, 00, 04, 00, 00, 00, 00, 00, 14, 00, 07, 00, 00, 00, 01, 01, 00, 00, 00, 00, 00,\\ 01, 00, 00, 00, 00, 00, 00, 14, 00, 07, 00, 00, 00, 01, 01, 00, 00, 00, 00, 00, 05, 12, 00, 00, 00,\\ 00, 00, 14, 00, 07, 00, 00, 00, 01, 01, 00, 00, 00, 00, 00, 05, 04, 00, 00, 00, 00, 00, 14, 00, 07,\\ 00, 00, 00, 01, 01, 00, 00, 00, 00, 00, 05, 07, 00, 00, 00, 01, 05, 00, 00, 00, 00, 00, 05, 15, 00,\\ 00, 00, ef, e4, 52, bb, a2, c0, 48, 1d, a9, bd, 18, 7d, f4, 01, 00, 00, 01, 05, 00, 00, 00, 00, 00,\\ 05, 15, 00, 00, 00, ef, e4, 52, bb, a2, c0, 48, 1d, a9, bd, 18, 7d, f4, 01, 00, 00");
                regkeySetKey64.SetValue("LaunchPermission", "hex:01,00,04,80,6c,00,00,00,88,00,00,00,00,00,00,00,14,00,\\ 00, 00, 02, 00, 58, 00, 04, 00, 00, 00, 00, 00, 14, 00, 07, 00, 00, 00, 01, 01, 00, 00, 00, 00, 00,\\ 01, 00, 00, 00, 00, 00, 00, 14, 00, 07, 00, 00, 00, 01, 01, 00, 00, 00, 00, 00, 05, 12, 00, 00, 00,\\ 00, 00, 14, 00, 07, 00, 00, 00, 01, 01, 00, 00, 00, 00, 00, 05, 04, 00, 00, 00, 00, 00, 14, 00, 07,\\ 00, 00, 00, 01, 01, 00, 00, 00, 00, 00, 05, 07, 00, 00, 00, 01, 05, 00, 00, 00, 00, 00, 05, 15, 00,\\ 00, 00, ef, e4, 52, bb, a2, c0, 48, 1d, a9, bd, 18, 7d, f4, 01, 00, 00, 01, 05, 00, 00, 00, 00, 00,\\ 05, 15, 00, 00, 00, ef, e4, 52, bb, a2, c0, 48, 1d, a9, bd, 18, 7d, f4, 01, 00, 00");
                regkeySetKey64.Close();
                //32位
                RegistryKey regkeySetKey = Registry.ClassesRoot.OpenSubKey(@"AppID\", true).CreateSubKey("{6D082A76-9C40-11D6-A4F9-00D059236DA5}"); 
                regkeySetKey.SetValue("@", "Medicom DIFPASSCore");
                regkeySetKey.SetValue("RunAs", ".\\medicom");
                regkeySetKey.SetValue("AccessPermission", "hex:01,00,04,80,6c,00,00,00,88,00,00,00,00,00,00,00,14,00,\\ 00, 00, 02, 00, 58, 00, 04, 00, 00, 00, 00, 00, 14, 00, 07, 00, 00, 00, 01, 01, 00, 00, 00, 00, 00,\\ 01, 00, 00, 00, 00, 00, 00, 14, 00, 07, 00, 00, 00, 01, 01, 00, 00, 00, 00, 00, 05, 12, 00, 00, 00,\\ 00, 00, 14, 00, 07, 00, 00, 00, 01, 01, 00, 00, 00, 00, 00, 05, 04, 00, 00, 00, 00, 00, 14, 00, 07,\\ 00, 00, 00, 01, 01, 00, 00, 00, 00, 00, 05, 07, 00, 00, 00, 01, 05, 00, 00, 00, 00, 00, 05, 15, 00,\\ 00, 00, ef, e4, 52, bb, a2, c0, 48, 1d, a9, bd, 18, 7d, f4, 01, 00, 00, 01, 05, 00, 00, 00, 00, 00,\\ 05, 15, 00, 00, 00, ef, e4, 52, bb, a2, c0, 48, 1d, a9, bd, 18, 7d, f4, 01, 00, 00");
                regkeySetKey.SetValue("LaunchPermission", "hex:01,00,04,80,6c,00,00,00,88,00,00,00,00,00,00,00,14,00,\\ 00, 00, 02, 00, 58, 00, 04, 00, 00, 00, 00, 00, 14, 00, 07, 00, 00, 00, 01, 01, 00, 00, 00, 00, 00,\\ 01, 00, 00, 00, 00, 00, 00, 14, 00, 07, 00, 00, 00, 01, 01, 00, 00, 00, 00, 00, 05, 12, 00, 00, 00,\\ 00, 00, 14, 00, 07, 00, 00, 00, 01, 01, 00, 00, 00, 00, 00, 05, 04, 00, 00, 00, 00, 00, 14, 00, 07,\\ 00, 00, 00, 01, 01, 00, 00, 00, 00, 00, 05, 07, 00, 00, 00, 01, 05, 00, 00, 00, 00, 00, 05, 15, 00,\\ 00, 00, ef, e4, 52, bb, a2, c0, 48, 1d, a9, bd, 18, 7d, f4, 01, 00, 00, 01, 05, 00, 00, 00, 00, 00,\\ 05, 15, 00, 00, 00, ef, e4, 52, bb, a2, c0, 48, 1d, a9, bd, 18, 7d, f4, 01, 00, 00");
                //
                regkeySetKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Classes\CLSID\", true).CreateSubKey("{6D082A76-9C40-11D6-A4F9-00D059236DA5}"); 
                regkeySetKey.SetValue("@", "Medicom DIFPASSCore");
                regkeySetKey.SetValue("AppID", "{6D082A76-9C40-11D6-A4F9-00D059236DA5}");
                regkeySetKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Classes\CLSID\{6D082A76-9C40-11D6-A4F9-00D059236DA5}\", true).CreateSubKey("InprocServer32"); 
                regkeySetKey.SetValue("@", "C:\\MediComSoftware\\PASS\\PASSCore.dll");
                regkeySetKey.SetValue("ThreadingModel", "Both");
                regkeySetKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Classes\CLSID\{6D082A76-9C40-11D6-A4F9-00D059236DA5}\", true).CreateSubKey("ProgID"); 
                regkeySetKey.SetValue("@", "Component.DIFPASSCore.1");
                regkeySetKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Classes\CLSID\{6D082A76-9C40-11D6-A4F9-00D059236DA5}\", true).CreateSubKey("VersionIndependentProgID"); 
                regkeySetKey.SetValue("@", "Component.DIFPASSCore");
                //
                regkeySetKey = Registry.ClassesRoot.CreateSubKey("Component.DIFPASSCore"); 
                regkeySetKey.SetValue("@", "Medicom DIFPASSCore");
                regkeySetKey = Registry.ClassesRoot.OpenSubKey(@"Component.DIFPASSCore\", true).CreateSubKey("CLSID"); 
                regkeySetKey.SetValue("@", "{6D082A76-9C40-11D6-A4F9-00D059236DA5}");
                regkeySetKey = Registry.ClassesRoot.OpenSubKey(@"Component.DIFPASSCore\", true).CreateSubKey("CurVer"); 
                regkeySetKey.SetValue("@", "Component.DIFPASSCore.1");
                //
                regkeySetKey = Registry.ClassesRoot.CreateSubKey("Component.DIFPASSCore.1");
                regkeySetKey.SetValue("@", "Medicom DIFPASSCore");
                regkeySetKey = Registry.ClassesRoot.OpenSubKey(@"Component.DIFPASSCore.1\", true).CreateSubKey("CLSID"); 
                regkeySetKey.SetValue("@", "{6D082A76-9C40-11D6-A4F9-00D059236DA5}");

                regkeySetKey.Close();



                //关闭防火墙
                Process.Start("cmd.exe", @" /c netsh advfirewall set allprofiles state off");
                MessageBox.Show("操作完成");
            }

        }

        private void bdcom_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定更新组件权限?", "操作确认",
                 MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //查找AppID
                string PassAppID ="", HelperAppID="";
                ManagementClass mc = new ManagementClass("Win32_DCOMApplication");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {         
                    if (mo.Properties["Name"].Value != null && mo.Properties["Name"].Value.ToString() == "Medicom DIFPASSCore")
                    {
                        PassAppID = mo.Properties["AppID"].Value.ToString();
                        MessageBox.Show("found!");
                    }
                    if (mo.Properties["Name"].Value != null && mo.Properties["Name"].Value.ToString() == "Medicom DIFPASSHelper")
                    {
                        HelperAppID = mo.Properties["AppID"].Value.ToString();
                        MessageBox.Show("found!2");
                    }
                }
                //配置DCOM权限
                if(PassAppID!="" && HelperAppID != "") 
                {
                    Process.Start("cmd.exe", @" /c " + Application.StartupPath + "\\dcompermex.exe -al " + PassAppID + " set medicom permit level:ll,rl,la,ra");
                    Process.Start("cmd.exe", @" /c " + Application.StartupPath + "\\dcompermex.exe -aa " + PassAppID + " set medicom permit level:l,r");
                    Process.Start("cmd.exe", @" /c " + Application.StartupPath + "\\dcompermex.exe -al " + PassAppID + " set EVERYONE permit level:ll,rl,la,ra");
                    Process.Start("cmd.exe", @" /c " + Application.StartupPath + "\\dcompermex.exe -aa " + PassAppID + " set EVERYONE permit level:l,r");
                    Process.Start("cmd.exe", @" /c " + Application.StartupPath + "\\dcompermex.exe -al " + PassAppID + " set AHORTYMOUS LOGIN permit level:ll,rl,la,ra");
                    Process.Start("cmd.exe", @" /c " + Application.StartupPath + "\\dcompermex.exe -aa " + PassAppID + " set AHORTYMOUS LOGIN permit level:l,r");
                    Process.Start("cmd.exe", @" /c " + Application.StartupPath + "\\dcompermex.exe -al " + PassAppID + " set Distributed COM Users permit level:ll,rl,la,ra");
                    Process.Start("cmd.exe", @" /c " + Application.StartupPath + "\\dcompermex.exe -aa " + PassAppID + " set Distributed COM Users permit level:l,r");

                    Process.Start("cmd.exe", @" /c " + Application.StartupPath + "\\dcompermex.exe -al " + HelperAppID + " set medicom permit level:ll,rl,la,ra");
                    Process.Start("cmd.exe", @" /c " + Application.StartupPath + "\\dcompermex.exe -aa " + HelperAppID + " set medicom permit level:l,r");
                    Process.Start("cmd.exe", @" /c " + Application.StartupPath + "\\dcompermex.exe -al " + HelperAppID + " set EVERYONE permit level:ll,rl,la,ra");
                    Process.Start("cmd.exe", @" /c " + Application.StartupPath + "\\dcompermex.exe -aa " + HelperAppID + " set EVERYONE permit level:l,r");
                    Process.Start("cmd.exe", @" /c " + Application.StartupPath + "\\dcompermex.exe -al " + HelperAppID + " set AHORTYMOUS LOGIN permit level:ll,rl,la,ra");
                    Process.Start("cmd.exe", @" /c " + Application.StartupPath + "\\dcompermex.exe -aa " + HelperAppID + " set AHORTYMOUS LOGIN permit level:l,r");
                    Process.Start("cmd.exe", @" /c " + Application.StartupPath + "\\dcompermex.exe -al " + HelperAppID + " set Distributed COM Users permit level:ll,rl,la,ra");
                    Process.Start("cmd.exe", @" /c " + Application.StartupPath + "\\dcompermex.exe -aa " + HelperAppID + " set Distributed COM Users permit level:l,r");



                }
                //配置组策略

                MessageBox.Show("操作完成");

            }

        }

        private void bweb_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定配置Webservice?", "操作确认",
              MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MessageBox.Show("操作完成");
            }
        }

        private void outputclient_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("功能正在做...", "系统提示",
                 MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                //Do
            }

        }

        private void tbar_MouseDown(object sender, MouseEventArgs e)
        {
            this.mousePoint.X = e.X;
            this.mousePoint.Y = e.Y;
        }

        private void tbar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Top = Control.MousePosition.Y - mousePoint.Y + 13;
                this.Left = Control.MousePosition.X - mousePoint.X + 13;
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
