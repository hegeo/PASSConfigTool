using Microsoft.Win32;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml;

namespace PassConfigTool
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        //INI引入
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);
        [DllImport("kernel32")]
        private static extern int WritePrivateProfileString(string lpApplicationName, string lpKeyName, string lpString, string lpFileName);
        public int state = 0;
        public int scannum = 0;
        public int editnum = 0;

        public MainWindow()
        {
            InitializeComponent();
            Log("PASS4服务配置工具 v2.5");
            Log("...");
            Log("获取安装路径!");
            InstallPathTextBox.Text = GetReg();
            if (InstallPathTextBox.Text != "请输入MedicomSoftware安装路径，点击'扫描'开始查找配置文件")
            {
                Log("安装路径:" + InstallPathTextBox.Text);
            }
            else { Log("获取安装路径失败!"); }
        }


        //扫描
        private void ScanButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Log("开始扫描配置文件!");
                if (File.Exists(@InstallPathTextBox.Text + "\\PASS4\\PASS4Service\\PASS4CoreService.ini"))
                {
                    string str = INIReader("CustomScreenWebSvc", "CheckURL", "", @InstallPathTextBox.Text + "\\PASS4\\PASS4Service\\PASS4CoreService.ini");
                    Match m = Regex.Match(str, @"\d{1,3}.\d{1,3}.\d{1,3}.\d{1,3}");
                    if (m.Success)
                    {
                        LastConfig.Text = m.Value;
                        SaveConfig.Text = m.Value;
                        Log("当前的服务器IP:"+m.Value);
                    }
                    a1.Foreground = Brushes.LawnGreen;
                    state = 1;
                }
                else { a1.Foreground = Brushes.LightGray; }
                if (File.Exists(@InstallPathTextBox.Text + "\\PASS4\\PASS4WebService\\config.ini"))
                { a2.Foreground = Brushes.LawnGreen; state = 1; scannum += 1; }
                else { a2.Foreground = Brushes.LightGray; }
                if (File.Exists(@InstallPathTextBox.Text + "\\PASS4\\PASS4WebService\\McConfig.js"))
                { a3.Foreground = Brushes.LawnGreen; state = 1; scannum += 1; }
                else { a3.Foreground = Brushes.LightGray; }
                if (File.Exists(@InstallPathTextBox.Text + "\\PASS4\\PASS4WebService\\PassJs\\Mcloader.js"))
                { a4.Foreground = Brushes.LawnGreen; state = 1; scannum += 1; }
                else { a4.Foreground = Brushes.LightGray; }
                if (File.Exists(@InstallPathTextBox.Text + "\\PASS4\\PASS4BSClient\\PassJs\\McConfig.js"))
                { a5.Foreground = Brushes.LawnGreen; state = 1; scannum += 1; }
                else { a5.Foreground = Brushes.LightGray; }
                if (File.Exists(@InstallPathTextBox.Text + "\\PASS4\\PASS4BSClient\\PassJs\\Mcloader.js"))
                { a6.Foreground = Brushes.LawnGreen; state = 1; scannum += 1; }
                else { a6.Foreground = Brushes.LightGray; }
                if (File.Exists(@InstallPathTextBox.Text + "\\PASS4\\PASS4Client\\PASS4Invoke.ini"))
                {
                    string strPort = INIReader("PassServer", "Port", "", @InstallPathTextBox.Text + "\\PASS4\\PASS4Client\\PASS4Invoke.ini");
                    string strIISPort = INIReader("PASSPharmReview", "WebServiceURL", "", @InstallPathTextBox.Text + "\\PASS4\\PASS4Client\\PASS4Invoke.ini");
                    LastConfig_Port.Text = strPort;
                    SaveConfig_Port.Text = strPort;
                    Log("当前的PASS端口:" + strPort);
                    Match m = Regex.Match(strIISPort, @":\d{1,5}");                   
                    if (m.Success)
                    {
                        LastConfig_IISPort.Text = m.Value.Remove(0, 1);
                        SaveConfig_IISPort.Text = m.Value.Remove(0, 1);
                        Log("当前的IIS端口:" + m.Value.Remove(0, 1));
                    }
                    a7.Foreground = Brushes.LawnGreen;
                    state = 1;
                }
                else { a7.Foreground = Brushes.LightGray; }
                if (File.Exists(@InstallPathTextBox.Text + "\\PASSADR\\web.config"))
                { b1.Foreground = Brushes.LawnGreen; state = 1; scannum += 1; }
                else { b1.Foreground = Brushes.LightGray; }
                if (File.Exists(@InstallPathTextBox.Text + "\\PASSDoctorQuery\\web.config"))
                { b2.Foreground = Brushes.LawnGreen; state = 1; scannum += 1; }
                else { b2.Foreground = Brushes.LightGray; }
                if (File.Exists(@InstallPathTextBox.Text + "\\PASSUserTool\\web.config"))
                { b3.Foreground = Brushes.LawnGreen; state = 1; scannum += 1; }
                else { b3.Foreground = Brushes.LightGray; }
                if (File.Exists(@InstallPathTextBox.Text + "\\PASSPharmReview\\web.config"))
                { b4.Foreground = Brushes.LawnGreen; state = 1; scannum += 1; }
                else { b4.Foreground = Brushes.LightGray; }
                if (File.Exists(@InstallPathTextBox.Text + "\\PASSPharmReview\\McConfig.js"))
                { b5.Foreground = Brushes.LawnGreen; state = 1; scannum += 1; }
                else { b5.Foreground = Brushes.LightGray; }
                if (File.Exists(@InstallPathTextBox.Text + "\\PASSPA2\\PASSPA2Client\\PASSPA2.ini"))
                { b6.Foreground = Brushes.LawnGreen; state = 1; scannum += 1; }
                else { b6.Foreground = Brushes.LightGray; }
                if (File.Exists(@InstallPathTextBox.Text + "\\PASSPA2\\PASSPA2Service\\PASSPA2Service.exe.config"))
                { b7.Foreground = Brushes.LawnGreen; state = 1; scannum += 1; }
                else { b7.Foreground = Brushes.LightGray; }
                if (state == 1) { Log("扫描配置文件成功！"); }
                else { };
            }
            catch (Exception ee)
            {
                MessageBox.Show("扫描出错了!");
                Log("扫描文件错误!");
            }


        }
        //保存
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (state == 0)
            {
                MessageBox.Show("请先执行扫描!");
            }
            else
            {
                Log("准备更新配置!");
                Log("开始校验输入信息!");
                Match checkip = Regex.Match(SaveConfig.Text, @"^((2[0-4]\d|25[0-5]|[1]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[1]?\d\d?)$");
                Match checkport = Regex.Match(SaveConfig_Port.Text, @"^[1-9]$|(^[1-9][0-9]$)|(^[1-9][0-9][0-9]$)|(^[1-9][0-9][0-9][0-9]$)|(^[1-6][0-5][0-5][0-3][0-5]$)");
                Match checkiisport = Regex.Match(SaveConfig_IISPort.Text, @"^[1-9]$|(^[1-9][0-9]$)|(^[1-9][0-9][0-9]$)|(^[1-9][0-9][0-9][0-9]$)|(^[1-6][0-5][0-5][0-3][0-5]$)");

                if (checkip.Success && checkport.Success && checkiisport.Success)
                {
                    try
                    {
                        Log("校验成功!");
                        Log("更新后服务器IP:" + SaveConfig.Text);
                        Log("更新后PASS端口:" + SaveConfig_Port.Text);
                        Log("更新后IIS端口:" + SaveConfig_IISPort.Text);
                        Log("开始更新配置文件!");
                        if (File.Exists(@InstallPathTextBox.Text + "\\PASS4\\PASS4Service\\PASS4CoreService.ini"))
                        {
                            //PASSIM服务端
                            if (File.Exists(@InstallPathTextBox.Text + "\\PASS4\\PASS4IM\\Web.config"))
                            {
                                BakFile(@InstallPathTextBox.Text + "\\PASS4\\PASS4IM\\Web.config");
                                XMLConfigUpdater("PASSCore_IP", SaveConfig.Text + ":" + SaveConfig_Port.Text, @InstallPathTextBox.Text + "\\PASS4\\PASS4IM\\Web.config");                
                                XMLConfigxUpdater("connStr", SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASS4\\PASS4IM\\Web.config");
                                XMLConfigxUpdater("connStr_User", SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASS4\\PASS4IM\\Web.config");
                                editnum+=1; Log("更新了" + @InstallPathTextBox.Text + "\\PASS4\\PASS4IM\\Web.config");
                            }

                            //PASSIMJS
                            if (File.Exists(@InstallPathTextBox.Text + "\\PASS4\\PASS4IM\\Scripts\\McConfig.js"))
                            {
                                BakFile(@InstallPathTextBox.Text + "\\PASS4\\PASS4IM\\Scripts\\McConfig.js");
                                JSxUpdater(SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASS4\\PASS4IM\\Scripts\\McConfig.js");
                                editnum+=1; Log("更新了" + @InstallPathTextBox.Text + "\\PASS4\\PASS4IM\\Scripts\\McConfig.js");
                            }
                            BakFile(@InstallPathTextBox.Text + "\\PASS4\\PASS4Service\\PASS4CoreService.ini");
                            INIWriter("System", "Port", SaveConfig_Port.Text, @InstallPathTextBox.Text + "\\PASS4\\PASS4Service\\PASS4CoreService.ini");
                            INIxWriter("Database", "ADOConnString", SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASS4\\PASS4Service\\PASS4CoreService.ini");
                            INIxWriter("Database", "ADOConnStringUser", SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASS4\\PASS4Service\\PASS4CoreService.ini");
                            INIxWriter("CustomScreenWebSvc", "ValidateURL", SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASS4\\PASS4Service\\PASS4CoreService.ini");
                            INIxWriter("CustomScreenWebSvc", "CheckURL", SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASS4\\PASS4Service\\PASS4CoreService.ini");
                            editnum+=1; Log("更新了" + @InstallPathTextBox.Text + "\\PASS4\\PASS4Service\\PASS4CoreService.ini");
                            a1.Foreground = Brushes.Gold;
                        }
                        if (File.Exists(@InstallPathTextBox.Text + "\\PASS4\\PASS4WebService\\Config.ini"))
                        {
                            BakFile(@InstallPathTextBox.Text + "\\PASS4\\PASS4WebService\\Config.ini");
                            INIWriter("connection_pass_core", "IP", SaveConfig.Text, @InstallPathTextBox.Text + "\\PASS4\\PASS4WebService\\Config.ini");
                            INIWriter("connection_pass_core", "PORT", SaveConfig_Port.Text, @InstallPathTextBox.Text + "\\PASS4\\PASS4WebService\\Config.ini");
                            editnum+=1; Log("更新了" + @InstallPathTextBox.Text + "\\PASS4\\PASS4WebService\\Config.ini");
                            a2.Foreground = Brushes.Gold;
                        }
                        if (File.Exists(@InstallPathTextBox.Text + "\\PASS4\\PASS4WebService\\McConfig.js"))
                        {
                            if (File.Exists(@InstallPathTextBox.Text + "\\PASS4\\PASS4WebService\\PassJs\\McConfig.js"))
                            {
                                BakFile(@InstallPathTextBox.Text + "\\PASS4\\PASS4WebService\\PassJs\\McConfig.js");
                                JSxUpdater(SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASS4\\PASS4WebService\\PassJs\\McConfig.js");
                                editnum+=1; Log("更新了" + @InstallPathTextBox.Text + "\\PASS4\\PASS4WebService\\PassJs\\McConfig.js");
                            }
                            BakFile(@InstallPathTextBox.Text + "\\PASS4\\PASS4WebService\\McConfig.js");
                            JSxUpdater(SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASS4\\PASS4WebService\\McConfig.js");
                            editnum+=1; Log("更新了" + @InstallPathTextBox.Text + "\\PASS4\\PASS4WebService\\McConfig.js");
                            a3.Foreground = Brushes.Gold;
                        }
                        if (File.Exists(@InstallPathTextBox.Text + "\\PASS4\\PASS4WebService\\PassJs\\Mcloader.js"))
                        {
                            BakFile(@InstallPathTextBox.Text + "\\PASS4\\PASS4WebService\\PassJs\\Mcloader.js");
                            JSxUpdater(SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASS4\\PASS4WebService\\PassJs\\Mcloader.js");
                            editnum+=1; Log("更新了" + @InstallPathTextBox.Text + "\\PASS4\\PASS4WebService\\PassJs\\Mcloader.js");
                            a4.Foreground = Brushes.Gold;         
                        }
                        if (File.Exists(@InstallPathTextBox.Text + "\\PASS4\\PASS4BSClient\\PassJs\\McConfig.js"))
                        {
                            BakFile(@InstallPathTextBox.Text + "\\PASS4\\PASS4BSClient\\PassJs\\McConfig.js");
                            JSxUpdater(SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASS4\\PASS4BSClient\\PassJs\\McConfig.js");
                            editnum+=1; Log("更新了" + @InstallPathTextBox.Text + "\\PASS4\\PASS4BSClient\\PassJs\\McConfig.js");
                            a5.Foreground = Brushes.Gold;
                        }
                        if (File.Exists(@InstallPathTextBox.Text + "\\PASS4\\PASS4BSClient\\PassJs\\Mcloader.js"))
                        {
                            BakFile(@InstallPathTextBox.Text + "\\PASS4\\PASS4BSClient\\PassJs\\Mcloader.js");
                            JSxUpdater(SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASS4\\PASS4BSClient\\PassJs\\Mcloader.js");
                            editnum+=1; Log("更新了" + @InstallPathTextBox.Text + "\\PASS4\\PASS4BSClient\\PassJs\\Mcloader.js");
                            a6.Foreground = Brushes.Gold;
                        }
                        if (File.Exists(@InstallPathTextBox.Text + "\\PASS4\\PASS4Client\\PASS4Invoke.ini"))
                        {
                            BakFile(@InstallPathTextBox.Text + "\\PASS4\\PASS4Client\\PASS4Invoke.ini");
                            INIxWriter("PassServer", "WebServiceURL", SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASS4\\PASS4Client\\PASS4Invoke.ini");
                            INIWriter("PassServer", "Server", SaveConfig.Text, @InstallPathTextBox.Text + "\\PASS4\\PASS4Client\\PASS4Invoke.ini");
                            INIWriter("PassServer", "Port", SaveConfig_Port.Text.Trim(), @InstallPathTextBox.Text + "\\PASS4\\PASS4Client\\PASS4Invoke.ini");
                            INIxWriter("PASSPharmReview", "WebServiceURL", SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASS4\\PASS4Client\\PASS4Invoke.ini");
                            INIxWriter("RefPlatform", "RefPlatformURL", SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASS4\\PASS4Client\\PASS4Invoke.ini");
                            editnum+=1; Log("更新了" + @InstallPathTextBox.Text + "\\PASS4\\PASS4Client\\PASS4Invoke.ini");

                            //PASSIM客户端
                            if (File.Exists(@InstallPathTextBox.Text + "\\PASS4\\PASS4Client\\PASSIMClient.ini"))
                            {
                                BakFile(@InstallPathTextBox.Text + "\\PASS4\\PASS4Client\\PASSIMClient.ini");
                                INIxWriter("SERVER", "HttpServer", SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASS4\\PASS4Client\\PASSIMClient.ini");
                                editnum+=1; Log("更新了" + @InstallPathTextBox.Text + "\\PASS4\\PASS4Client\\PASSIMClient.ini");

                            }
                            a7.Foreground = Brushes.Gold;
                        }

                        if (File.Exists(@InstallPathTextBox.Text + "\\PASSADR\\web.config"))
                        {
                            BakFile(@InstallPathTextBox.Text + "\\PASSADR\\web.config");
                            XMLDBConStrUpdater("PASSAdrDbConnectionStr", SaveConfig.Text, @InstallPathTextBox.Text + "\\PASSADR\\Web.config");
                            XMLDBConStrUpdater("PASSPA2DbConnectionStr", SaveConfig.Text, @InstallPathTextBox.Text + "\\PASSADR\\Web.config");
                            XMLConfigUpdater("PASSIP", SaveConfig.Text, @InstallPathTextBox.Text + "\\PASSADR\\Web.config");
                            XMLConfigUpdater("PASSPORT", SaveConfig_Port.Text, @InstallPathTextBox.Text + "\\PASSADR\\Web.config");
                            XMLConfigxUpdater("PASSIM", SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASSADR\\Web.config");
                            XMLConfigxUpdater("PASS4Web", SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASSADR\\Web.config");
                            XMLConfigxUpdater("PASSUserTool", SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASSADR\\Web.config");
                            editnum+=1; Log("更新了" + @InstallPathTextBox.Text + "\\PASSADR\\Web.config");
                            b1.Foreground = Brushes.Gold;
                        }
                        if (File.Exists(@InstallPathTextBox.Text + "\\PASSDoctorQuery\\web.config"))
                        {
                            //DQPassJS
                            if (File.Exists(@InstallPathTextBox.Text + "\\PASSDoctorQuery\\Scripts\\PassJS\\McConfig.js"))
                            {
                                BakFile(@InstallPathTextBox.Text + "\\PASSDoctorQuery\\Scripts\\PassJS\\McConfig.js");
                                JSxUpdater(SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASSDoctorQuery\\Scripts\\PassJS\\McConfig.js");
                                editnum+=1; Log("更新了" + @InstallPathTextBox.Text + "\\PASSDoctorQuery\\Scripts\\PassJS\\McConfig.js");
                            }
                            if (File.Exists(@InstallPathTextBox.Text + "\\PASSDoctorQuery\\Scripts\\PassJS\\Mcloader.js"))
                            {
                                BakFile(@InstallPathTextBox.Text + "\\PASSDoctorQuery\\Scripts\\PassJS\\Mcloader.js");
                                JSxUpdater(SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASSDoctorQuery\\Scripts\\PassJS\\Mcloader.js");
                                editnum+=1; Log("更新了" + @InstallPathTextBox.Text + "\\PASSDoctorQuery\\Scripts\\PassJS\\Mcloader.js");
                            }
                            BakFile(@InstallPathTextBox.Text + "\\PASSDoctorQuery\\web.config");
                            XMLDBConStrUpdater("PASSPA2DbConnectionStr", SaveConfig.Text, @InstallPathTextBox.Text + "\\PASSDoctorQuery\\web.config");
                            XMLDBConStrUpdater("PASSPRDbConnectionStr", SaveConfig.Text, @InstallPathTextBox.Text + "\\PASSDoctorQuery\\web.config");
                            XMLConfigUpdater("PASSIP", SaveConfig.Text, @InstallPathTextBox.Text + "\\PASSDoctorQuery\\web.config");
                            XMLConfigUpdater("PASSPORT", SaveConfig_Port.Text, @InstallPathTextBox.Text + "\\PASSDoctorQuery\\web.config");
                            XMLConfigxUpdater("PASSIM", SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASSDoctorQuery\\web.config");
                            XMLConfigxUpdater("PASS4Web", SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASSDoctorQuery\\web.config");
                            editnum+=1; Log("更新了" + @InstallPathTextBox.Text + "\\PASSDoctorQuery\\web.config");
                            b2.Foreground = Brushes.Gold;
                        }
                        if (File.Exists(@InstallPathTextBox.Text + "\\PASSUserTool\\web.config"))
                        {
                            //UTPassJS
                            if (File.Exists(@InstallPathTextBox.Text + "\\PASSUserTool\\Scripts\\PassJS\\McConfig.js"))
                            {
                                BakFile(@InstallPathTextBox.Text + "\\PASSUserTool\\Scripts\\PassJS\\McConfig.js");
                                JSxUpdater(SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASSUserTool\\Scripts\\PassJS\\McConfig.js");
                                editnum+=1; Log("更新了" + @InstallPathTextBox.Text + "\\PASSUserTool\\Scripts\\PassJS\\McConfig.js");
                            }
                            if (File.Exists(@InstallPathTextBox.Text + "\\PASSUserTool\\Scripts\\PassJS\\Mcloader.js"))
                            {
                                BakFile(@InstallPathTextBox.Text + "\\PASSUserTool\\Scripts\\PassJS\\Mcloader.js");
                                JSxUpdater(SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASSUserTool\\Scripts\\PassJS\\Mcloader.js");
                                editnum+=1; Log("更新了" + @InstallPathTextBox.Text + "\\PASSUserTool\\Scripts\\PassJS\\Mcloader.js");
                            }

                            BakFile(@InstallPathTextBox.Text + "\\PASSUserTool\\web.config");
                            XMLDBConStrUpdater("PASSPA2DbConnectionStr", SaveConfig.Text, @InstallPathTextBox.Text + "\\PASSUserTool\\web.config");
                            XMLConfigUpdater("PASSIP", SaveConfig.Text, @InstallPathTextBox.Text + "\\PASSUserTool\\web.config");
                            XMLConfigUpdater("PASSPORT", SaveConfig_Port.Text, @InstallPathTextBox.Text + "\\PASSUserTool\\web.config");
                            XMLConfigxUpdater("PASSIM", SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASSUserTool\\web.config");
                            XMLConfigxUpdater("PASS4Web", SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASSUserTool\\web.config");
                            editnum+=1; Log("更新了" + @InstallPathTextBox.Text + "\\PASSUserTool\\web.config");
                            b3.Foreground = Brushes.Gold;
                        }
                        if (File.Exists(@InstallPathTextBox.Text + "\\PASSPharmReview\\web.config"))
                        {
                            BakFile(@InstallPathTextBox.Text + "\\PASSPharmReview\\web.config");
                            XMLDBConStrUpdater("PASSPRDbConnectionStr", SaveConfig.Text, @InstallPathTextBox.Text + "\\PASSPharmReview\\web.config");
                            XMLDBConStrUpdater("PASSPA2DbConnectionStr", SaveConfig.Text, @InstallPathTextBox.Text + "\\PASSPharmReview\\web.config");
                            XMLConfigUpdater("PASSIP", SaveConfig.Text, @InstallPathTextBox.Text + "\\PASSPharmReview\\web.config");
                            XMLConfigUpdater("PASSPORT", SaveConfig_Port.Text, @InstallPathTextBox.Text + "\\PASSPharmReview\\web.config");
                            XMLConfigxUpdater("PASSPR", SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASSPharmReview\\web.config");
                            XMLConfigxUpdater("PASSIM", SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASSPharmReview\\web.config");
                            XMLConfigxUpdater("PASS4Web", SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASSPharmReview\\web.config");
                            XMLConfigxUpdater("PASSUserTool", SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASSPharmReview\\web.config");
                            editnum+=1; Log("更新了" + @InstallPathTextBox.Text + "\\PASSPharmReview\\web.config");
                            b4.Foreground = Brushes.Gold;
                        }
                        if (File.Exists(@InstallPathTextBox.Text + "\\PASSPharmReview\\McConfig.js"))
                        {
                            BakFile(@InstallPathTextBox.Text + "\\PASSPharmReview\\McConfig.js");
                            JSxUpdater(SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASSPharmReview\\McConfig.js");
                            editnum+=1; Log("更新了" + @InstallPathTextBox.Text + "\\PASSPharmReview\\McConfig.js");
                            b5.Foreground = Brushes.Gold;
                        }

                        //new  PassContent
                        if (File.Exists(@InstallPathTextBox.Text + "\\PASSPharmReview\\PassContent\\PassJs\\McLoader.js"))
                        {
                            BakFile(@InstallPathTextBox.Text + "\\PASSPharmReview\\PassContent\\PassJs\\McLoader.js");
                            JSxUpdater(SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASSPharmReview\\PassContent\\PassJs\\McLoader.js");
                            editnum+=1; Log("更新了" + @InstallPathTextBox.Text + "\\PASSPharmReview\\PassContent\\PassJs\\McLoader.js");
                            b5.Foreground = Brushes.Gold;
                        }
                        if (File.Exists(@InstallPathTextBox.Text + "\\PASSPharmReview\\PassContent\\PassJs\\McConfig.js"))
                        {
                            BakFile(@InstallPathTextBox.Text + "\\PASSPharmReview\\PassContent\\PassJs\\McConfig.js");
                            JSxUpdater(SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASSPharmReview\\PassContent\\PassJs\\McConfig.js");
                            editnum+=1; Log("更新了" + @InstallPathTextBox.Text + "\\PASSPharmReview\\PassContent\\PassJs\\McConfig.js");
                            b5.Foreground = Brushes.Gold;
                        }




                        if (File.Exists(@InstallPathTextBox.Text + "\\PASSPA2\\PASSPA2Client\\PASSPA2.ini"))
                        {
                            //PASS4客户端
                            if (File.Exists(@InstallPathTextBox.Text + "\\PASSPA2\\PASSPA2Client\\PASSPA2.ini"))
                            {
                                BakFile(@InstallPathTextBox.Text + "\\PASSPA2\\PASSPA2Client\\PASS4Invoke.ini");
                                INIxWriter("PassServer", "WebServiceURL", SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASSPA2\\PASSPA2Client\\PASS4Invoke.ini");
                                INIxWriter("PassServer", "Server", SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASSPA2\\PASSPA2Client\\PASS4Invoke.ini");
                                INIWriter("PassServer", "Port", SaveConfig_Port.Text, @InstallPathTextBox.Text + "\\PASSPA2\\PASSPA2Client\\PASS4Invoke.ini");
                                INIxWriter("PASSPharmReview", "WebServiceURL", SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASSPA2\\PASSPA2Client\\PASS4Invoke.ini");
                                INIxWriter("RefPlatform", "RefPlatformURL", SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASSPA2\\PASSPA2Client\\PASS4Invoke.ini");
                                editnum+=1; Log("更新了" + @InstallPathTextBox.Text + "\\PASSPA2\\PASSPA2Client\\PASS4Invoke.ini");

                            }
                            //PASSIM客户端
                            if (File.Exists(@InstallPathTextBox.Text + "\\PASSPA2\\PASSPA2Client\\PASSIMClient.ini"))
                            {
                                BakFile(@InstallPathTextBox.Text + "\\PASSPA2\\PASSPA2Client\\PASSIMClient.ini");
                                INIxWriter("SERVER", "HttpServer", SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASSPA2\\PASSPA2Client\\PASSIMClient.ini");
                                editnum+=1; Log("更新了" + @InstallPathTextBox.Text + "\\PASSPA2\\PASSPA2Client\\PASSIMClient.ini");
                            }
                            //PA2客户端
                            BakFile(@InstallPathTextBox.Text + "\\PASSPA2\\PASSPA2Client\\PASSPA2.ini");
                            INIxWriter("DATABASE", "ADOConnString", SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASSPA2\\PASSPA2Client\\PASSPA2.ini");
                            INIxWriter("PASSDoctorQuery", "ReviewUrl", SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASSPA2\\PASSPA2Client\\PASSPA2.ini");
                            editnum+=1; Log("更新了" + @InstallPathTextBox.Text + "\\PASSPA2\\PASSPA2Client\\PASSPA2.ini");
                            b6.Foreground = Brushes.Gold;
                        }

                        if (File.Exists(@InstallPathTextBox.Text + "\\PASSPA2\\PASSPA2Service\\PASSPA2Service.exe.config"))
                        {
                            //PA2采集
                            BakFile(@InstallPathTextBox.Text + "\\PASSPA2\\PASSPA2Service\\PASSPA2Service.exe.config");
                            XMLConfigUpdater("PASSIP", SaveConfig.Text, @InstallPathTextBox.Text + "\\PASSPA2\\PASSPA2Service\\PASSPA2Service.exe.config");
                            XMLConfigUpdater("PASSPORT", SaveConfig_Port.Text, @InstallPathTextBox.Text + "\\PASSPA2\\PASSPA2Service\\PASSPA2Service.exe.config");
                            XMLConfigxUpdater("Web1", SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASSPA2\\PASSPA2Service\\PASSPA2Service.exe.config");
                            XMLConfigxUpdater("DbConn1", SaveConfig.Text, SaveConfig_IISPort.Text, @InstallPathTextBox.Text + "\\PASSPA2\\PASSPA2Service\\PASSPA2Service.exe.config");
                            editnum+=1; Log("更新了" + @InstallPathTextBox.Text + "\\PASSPA2\\PASSPA2Service\\PASSPA2Service.exe.config");
                            b7.Foreground = Brushes.Gold;
                        }

                        MessageBox.Show("配置已保存!");
                        Log("配置文件更新完成!");
                        Log("共更新了"+editnum+"个文件!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("配置保存失败!\n请在日志查看详情!");
                        Log("配置文件更新失败!");
                        Log("错误详情："+ ex);

                    }
                }
                else
                {
                    MessageBox.Show("输入的IP或端口不正确!");
                }


            }
        }
      

        //获取注册表
        public string GetReg()
        {
            //路径 注意'\'为转义字符
            string path = "SOFTWARE\\MediComSoftware\\PASS4";
            string path32 = "SOFTWARE\\WOW6432Node\\MediComSoftware\\PASS4";
            RegistryKey key = Registry.LocalMachine.OpenSubKey(path);//打开LOCALMACHINE下的子键
            RegistryKey key32 = Registry.LocalMachine.OpenSubKey(path32);
            if (key != null)
            {
                object model = key.GetValue("InstallPath");
                if (model != null)
                {
                    return model.ToString();
                }
                else
                {
                    object model32 = key32.GetValue("InstallPath");
                    if (model != null)
                    {
                        return model.ToString();
                    }
                    else
                    {
                        Console.WriteLine("InstallPath键不存在");
                    }
                }
            }
            else
            {
                Console.WriteLine("MediComSoftware键不存在");
            }
            return "请输入MedicomSoftware安装路径，点击'扫描'开始查找配置文件";
        }
        //备份文件
        public void BakFile(string filepath)
        {
            if (File.Exists(filepath + ".bak"))
            {
                System.IO.File.Copy(filepath, filepath + ".bak", true);
            }
            else
            {
                System.IO.File.Copy(filepath, filepath + ".bak", false);
            }

        }

        //INI更新方法
        public string INIReader(string section, string key, string def, string file)
        {
            StringBuilder sb = new StringBuilder(1024);
            GetPrivateProfileString(section, key, def, sb, 1024, file);
            return sb.ToString();
        }
        public void INIWriter(string section, string key, string value, string file)
        {
            WritePrivateProfileString(section, key, value, file);
        }
        public void INIxWriter(string section, string key, string host, string port, string file)
        {
            StringBuilder sb = new StringBuilder(1024);
            GetPrivateProfileString(section, key, "", sb, 1024, file);
            string str = sb.ToString();
            Match CheckUrlPort = Regex.Match(str, @"//\d{1,3}.\d{1,3}.\d{1,3}.\d{1,3}:\d{2,5}/");
            Match CheckUrl = Regex.Match(str, @"//\d{1,3}.\d{1,3}.\d{1,3}.\d{1,3}/");
            Match CheckIP = Regex.Match(str, @"\d{1,3}.\d{1,3}.\d{1,3}.\d{1,3}");
            if (CheckUrlPort.Success)
            {
                str = Regex.Replace(str, @"//\d{1,3}.\d{1,3}.\d{1,3}.\d{1,3}:\d{2,5}/", "//" + host + ':' + port + "/");
                WritePrivateProfileString(section, key, str, file);
            }
            else if (CheckUrl.Success)
            {
                str = Regex.Replace(str, @"//\d{1,3}.\d{1,3}.\d{1,3}.\d{1,3}/", "//" + host + ":" + port + '/');
                WritePrivateProfileString(section, key, str, file);
            }
            else if (CheckIP.Success)
            {
                str = Regex.Replace(str, @"\d{1,3}.\d{1,3}.\d{1,3}.\d{1,3}", host);
                WritePrivateProfileString(section, key, str, file);
            }
            else
            {;
            }

        }

        //XML更新方法
        public void XMLDBConStrUpdater(string key, string value, string file)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(file);
            XmlNode node = xmlDoc.SelectSingleNode(@"//add[@name='" + key + "']");
            if (node != null)
            {
                XmlElement ele = (XmlElement)node;
                string str = ele.GetAttribute("connectionString");
                str = Regex.Replace(str, @"\d{1,3}.\d{1,3}.\d{1,3}.\d{1,3}", value);
                ele.SetAttribute("connectionString", str);
                xmlDoc.Save(file);
            }
            else { }
        }
        public void XMLConfigUpdater(string key, string value, string file)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(file);
            XmlNode node = xmlDoc.SelectSingleNode(@"//add[@key='" + key + "']");
            if (node != null)
            {
                XmlElement ele = (XmlElement)node;
                ele.SetAttribute("value", value);
                xmlDoc.Save(file);
            }
            else { }

        }
        public void XMLConfigxUpdater(string key, string host, string port, string file)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(file);
            XmlNode node = xmlDoc.SelectSingleNode(@"//add[@key='" + key + "']");
            if (node != null)
            {
                XmlElement ele = (XmlElement)node;
                string str = ele.GetAttribute("value");

                Match CheckUrlPort = Regex.Match(str, @"//\d{1,3}.\d{1,3}.\d{1,3}.\d{1,3}:\d{2,5}/");
                Match CheckUrl = Regex.Match(str, @"//\d{1,3}.\d{1,3}.\d{1,3}.\d{1,3}/");
                Match CheckIP = Regex.Match(str, @"\d{1,3}.\d{1,3}.\d{1,3}.\d{1,3}");
                if (CheckUrlPort.Success)
                {
                    str = Regex.Replace(str, @"//\d{1,3}.\d{1,3}.\d{1,3}.\d{1,3}:\d{2,5}/", "//" + host + ':' + port + "/");
                    ele.SetAttribute("value", str);
                    xmlDoc.Save(file);
                }
                else if (CheckUrl.Success)
                {
                    str = Regex.Replace(str, @"//\d{1,3}.\d{1,3}.\d{1,3}.\d{1,3}/", "//" + host + ":" + port + "/");
                    ele.SetAttribute("value", str);
                    xmlDoc.Save(file);
                }
                else if (CheckIP.Success)
                {
                    str = Regex.Replace(str, @"\d{1,3}.\d{1,3}.\d{1,3}.\d{1,3}", host);
                    ele.SetAttribute("value", str);
                    xmlDoc.Save(file);
                }
                else { }
            }
            else
            { }
           
        }



        //JS更新方法（JSxUpdater为网址IP替换模式）
        public void JSxUpdater(string host, string port, string file)
        {
            string str = File.ReadAllText(file);
            Match CheckUrlPort = Regex.Match(str, @"//\d{1,3}.\d{1,3}.\d{1,3}.\d{1,3}:\d{2,5}/");
            Match CheckUrl = Regex.Match(str, @"//\d{1,3}.\d{1,3}.\d{1,3}.\d{1,3}/");
            Match CheckIP = Regex.Match(str, @"\d{1,3}.\d{1,3}.\d{1,3}.\d{1,3}");
            if (CheckUrlPort.Success)
            {
                str = Regex.Replace(str, @"//\d{1,3}.\d{1,3}.\d{1,3}.\d{1,3}:\d{1,5}/", "//" + host + ":" + port + "/");
                File.WriteAllText(file, str, Encoding.UTF8);
            }
            else if (CheckUrl.Success)
            {
                str = Regex.Replace(str, @"//\d{1,3}.\d{1,3}.\d{1,3}.\d{1,3}/", "//" + host + ":" + port + "/");
                File.WriteAllText(file, str, Encoding.UTF8);
            }
            else
            {
                str = Regex.Replace(str, @"\d{1,3}.\d{1,3}.\d{1,3}.\d{1,3}", host);
                File.WriteAllText(file, str, Encoding.UTF8);
            }
        }

        private void Grid_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void Log(string info)
        {
            using (StreamWriter file = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\PASS4服务配置工具日志.txt", true))
            {
                      file.WriteLine("["+ DateTime.Now.ToString() +"] "+info);// 直接追加文件末尾，换行 
            }

        }

        private void label_Copy3_MouseEnter(object sender, MouseEventArgs e)
        {
            label_Copy3.Content = "☺ 数据库配置成'.'时本工具不会进行修改，请手动修改为IP格式";
        }

        private void label_Copy3_MouseLeave(object sender, MouseEventArgs e)
        {
            label_Copy3.Content = "☺ 保存配置时会同步更新PASSIM，并在各配置文件同目录备份副本";
        }

        private void ExitButton_MouseDown(object sender, MouseButtonEventArgs e)
        {

            Application.Current.Shutdown();
        }

    }

}

