﻿#region "using"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Threading;

#endregion

//ok

//*****************
//？？？？？  VB中可以用Preserver来重新定义数组的大小同时保持已经存在的数据；
//？？？？？  c#中是new就可以了还是需要别的方式进行处理，需要验证；？？？？？
//*****************

namespace PengDongNanTools
    {

    //TCPIP接口
    /// <summary>
    /// TCPIP接口【软件作者：彭东南, southeastofstar@163.com
    /// </summary>
    public interface TCPIPInterface
        {

        /// <summary>
        /// 验证IP端口的有效性
        /// </summary>
        /// <param name="TargetPort">目标端口</param>
        /// <returns>是否验证成功</returns>
        bool VerifyPort(ushort TargetPort);

        /// <summary>
        /// 验证IP地址的有效性，如果验证成功则返回正确IP地址
        /// </summary>
        /// <param name="TargetIPAddress">待验证IP地址字符串</param>
        /// <returns></returns>
        IPAddress VerifyIPAddress(string TargetIPAddress);

        /// <summary>
        /// 验证IP地址的有效性，如果验证成功则返回正确IP地址
        /// </summary>
        /// <param name="TargetIPAddress">待验证IP地址字符串</param>
        /// <param name="GetBackIPAddress">返回正确的IP地址</param>
        /// <returns></returns>
        bool VerifyIPAddress(string TargetIPAddress, out IPAddress GetBackIPAddress);

        /// <summary>
        /// 验证IP地址和端口的有效性
        /// </summary>
        /// <param name="TargetIPAddress">目标IP地址字符串</param>
        /// <param name="TargetPort">目标端口</param>
        /// <returns>是否验证成功</returns>
        bool VerifyIPAddressAndPort(ref string TargetIPAddress, ref ushort TargetPort);

        /// <summary>
        /// 验证IP地址和端口的有效性
        /// </summary>
        /// <param name="TargetIPAddress">目标IP地址字符串</param>
        /// <param name="TargetPort">目标端口</param>
        /// <param name="GetBackIPAddress">返回正确的IP地址</param>
        /// <returns></returns>
        bool VerifyIPAddressAndPort(string TargetIPAddress, ushort TargetPort,
            out IPAddress GetBackIPAddress);

        ///// <summary>
        ///// 错误信息
        ///// </summary>
        //string ErrorMessage;

        /// <summary>
        /// 获取TCP/IP网络中所有可用的IP地址
        /// </summary>
        /// <returns>返回TCP/IP网络中所有可用IP地址的字符串数组</returns>
        string[] SearchAvailableIPAddresses();

        /// <summary>
        /// 获取网络中已经联网的MAC地址【字符串数组】
        /// </summary>
        /// <returns></returns>
        string[] SearchAvailableMACAddress();

        /// <summary>
        /// 返回当前电脑IP4地址
        /// </summary>
        /// <returns></returns>
        string GetLocalIP4Address();

        /// <summary>
        /// 返回当前电脑MAC地址
        /// </summary>
        /// <returns></returns>
        string GetLocalMACAddress();

        /// <summary>
        /// 返回当前电脑IP6地址
        /// </summary>
        /// <returns></returns>
        string GetLocalIP6Address();

        /// <summary>
        /// 返回当前电脑名[HOSTNAME]
        /// </summary>
        /// <returns></returns>
        string GetPCName();

        /// <summary>
        /// 按照输入的IP地址区段搜索以太网设备
        /// </summary>
        /// <param name="TargetIPSegment">需要进行搜索的IP地址目标分段
        /// 例如搜索 "192.168.1.0~255" 整个区段的可用IP地址，则参数为 "192.168.1"
        /// </param>
        /// <returns>返回已经搜索到以太网设备的IP地址字符串数组</returns>
        string[] SearchIPAddressForCertainSegment(string TargetIPSegment);

        /// <summary>
        /// 搜索网络中所有可用计算机的名称
        /// </summary>
        /// <returns>返回搜索到的计算机名称数组</returns>
        string[] SearchAvailablePCNames();

        /// <summary>
        /// 将ASCII码字符串转换为16进制码【HEX】
        /// </summary>
        /// <param name="TargetString">字符串</param>
        /// <returns></returns>
        string StringConvertToHEX(string TargetString);

        }

    //TCPIPInterface接口的实现类
    /// <summary>
    /// TCPIPInterface接口的实现类【软件作者：彭东南, southeastofstar@163.com】
    /// </summary>
    public class TCPIP : TCPIPInterface
        {

        #region "变量定义"

        /// <summary>
        /// 更新信息至文本框时是否显示日期和时间，默认为True
        /// </summary>
        public bool ShowDateTimeForMessage = true;

        /// <summary>
        /// 软件作者
        /// </summary>
        public string Author
            {
            get { return "软件作者：彭东南"; }
            }

        string ErrorMessage;// = "";
        //string TempErrorMessage;// = "";

        /// <summary>
        /// 当错误信息相同时，是否重复显示
        /// </summary>
        public bool UpdatingSameMessage = true;

        bool SuccessBuiltNew;// = false;
        bool PasswordIsCorrect;// = false;

        /// <summary>
        /// 获取错误信息
        /// </summary>
        /// <returns></returns>
        public string ErrorMessageString()
            {
            return ErrorMessage;                         
            }

        private Button ButtonUseForInvoke = new Button();

        //利用委托和代理进行跨线程安全操作控件，以此避免跨线程操作异常
        //*****************************
        private delegate void AddMessageToRichTextBox(ref System.Windows.Forms.RichTextBox TargetRichTextBox, string TargetText);
        //private AddMessageToRichTextBox ActualAddMessageToRichTextBox;
        private delegate void AddMessageToTextBox(ref System.Windows.Forms.TextBox TargetTextBox, string TargetText);
        //private AddMessageToTextBox ActualAddMessageToTextBox;
        private delegate void ClearTextBoxDelegate(ref System.Windows.Forms.TextBox TargetTextBox);
        private delegate void ClearRichTextBoxDelegate(ref System.Windows.Forms.RichTextBox TargetRichTextBox);

        //*****************************
        private delegate void ChangeButtonEnableStatusDelegate(ref System.Windows.Forms.Button TargetControl, bool TargetEnabledStatus);
        private delegate void ChangeMenuEnableStatusDelegate(ref System.Windows.Forms.ToolStripMenuItem TargetControl, bool TargetEnabledStatus);
        private delegate void ChangeStatusLabelEnableStatusDelegate(ref System.Windows.Forms.ToolStripStatusLabel TargetControl, bool TargetEnabledStatus);
        //*****************************
        private delegate void ChangeStatusLabelTextDelegate(ref System.Windows.Forms.ToolStripStatusLabel TargetControl, string TargetText);
        //*****************************
        private delegate void ChangeStatusLabelBackColorDelegate(ref System.Windows.Forms.ToolStripStatusLabel TargetControl, System.Drawing.Color TargetColor);
        private delegate void ChangeMenuBackColorDelegate(ref System.Windows.Forms.ToolStripMenuItem TargetControl, System.Drawing.Color TargetColor);
        private delegate void ChangeButtonBackColorDelegate(ref System.Windows.Forms.Button TargetControl, System.Drawing.Color TargetColor);
        //*****************************
        
        #endregion

        #region "已完成代码"

        //创建实现TCPIPInterface接口类的实例
        /// <summary>
        /// 创建实现TCPIPInterface接口类的实例
        /// </summary>
        /// <param name="DLLPassword">使用此DLL的密码</param>
        public TCPIP(string DLLPassword)
            {

            SuccessBuiltNew = false;
            PasswordIsCorrect = false;

            if (DLLPassword == "ThomasPeng" || (DLLPassword == "pengdongnan") || (DLLPassword == "彭东南"))
                {
                PasswordIsCorrect = true;
                SuccessBuiltNew = true;
                }
            else
                {
                PasswordIsCorrect = false;
                SuccessBuiltNew = false;
                MessageBox.Show("Right Prohibited.\return\n     You don't have the given right to use this DLL library, please contact with ThomasPeng.\r\n你未得到授权的密码，无法使用此DLL进行软件开发！请与作者彭东南联系：southeastofstar@163.com\r\n                                                                版权所有： 彭东南", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
                }

            }

        //将ASCII码转换为16进制码【HEX】
        /// <summary>
        /// 将ASCII码转换为16进制码【HEX】
        /// </summary>
        /// <param name="TargetString">目标字符串</param>
        /// <returns></returns>
        public string StringConvertToHEX(string TargetString)
            {

            if (SuccessBuiltNew == false | PasswordIsCorrect == false) 
                {
                MessageBox.Show("Right Prohibited.\r\n     You don't have the given right to use this DLL library, please contact with ThomasPeng.\r\n你未得到授权的密码，无法使用此DLL进行软件开发！请与作者彭东南联系：southeastofstar@163.com\r\n                                                                版权所有： 彭东南", "非法操作", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return "";
                }

            if (SuccessBuiltNew == false)
                {
                MessageBox.Show("You failed to initialize this class, invalid operation.", "非法操作", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return "";
                }

            string TempResult = "";

            try
                {
                for (Int16 a = 0; a < TargetString.Length; a++)
                    {
                    TempResult += Conversion.Hex(Strings.Asc(Strings.Mid(TargetString, 1 + a, 1)));
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show(ex.Message);
                return "";
                }

            return TempResult;

            }        
        
        //验证IP端口的有效性
        /// <summary>
        /// 验证IP端口的有效性
        /// </summary>
        /// <param name="TargetPort">目标端口</param>
        /// <returns>是否验证成功</returns>
        public bool VerifyPort(ushort TargetPort)
            {

            if (PasswordIsCorrect == false)
                {
                MessageBox.Show("Right Prohibited.\r\n     You don't have the given right to use this DLL library, please contact with ThomasPeng.\r\n你未得到授权的密码，无法使用此DLL进行软件开发！请与作者彭东南联系：southeastofstar@163.com\r\n                                                                版权所有： 彭东南", "非法操作", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
                }

            try
                {

                if (TargetPort < 0 | TargetPort > 65535)
                    {
                    MessageBox.Show("The port value for the Server is not correct, please retry.\r\n你输入的IP地址无效，正确值得范围为0~65535，请修改后再重试.");
                    return false;
                    }
                else 
                    {
                    return true;
                    }
                
                }
            catch(Exception)
                {
                return false;
                }
            
            }

        //验证IP地址的有效性，如果验证成功则返回正确IP地址
        /// <summary>
        /// 验证IP地址的有效性，如果验证成功则返回正确IP地址
        /// </summary>
        /// <param name="TargetIPAddress">待验证IP地址字符串</param>
        /// <returns></returns>
        public IPAddress VerifyIPAddress(string TargetIPAddress)
            {

            if (PasswordIsCorrect == false)
                {
                MessageBox.Show("Right Prohibited.\r\n     You don't have the given right to use this DLL library, please contact with ThomasPeng.\r\n你未得到授权的密码，无法使用此DLL进行软件开发！请与作者彭东南联系：southeastofstar@163.com\r\n                                                                版权所有： 彭东南", "非法操作", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
                }

            IPAddress TempIPAddress = IPAddress.Parse("127.0.0.1");
            string[] GetCorrectIPAddress=new string[4];
            Int16[] TempGetIPAddress=new Int16[4];
                        
            try
                {

                //1、判断输入的服务器IP地址是否正确
                if (IPAddress.TryParse(TargetIPAddress, out TempIPAddress) == false)
                    {
                    MessageBox.Show("The format of IP address is not correct, please retry.\r\nIP地址格式不正确， 请修改参数.");
                    return null;
                    }
                else
                    {
                    //************************************
                    //此处解析IP地址不对："192.168.000.024"解析为"192.168.000.20"
                    //故需要自己写算法得到正确IP地址
                    //string TempStr=Convert.ToString(TempIPAddress);
                    //GetCorrectIPAddress = Strings.Split(TempStr,".");

                    //------------------------------------
                    GetCorrectIPAddress = Strings.Split(TargetIPAddress, ".");
                    //************************************

                    for (Int16 a = 0; a < 4; a++) 
                        {

                        TempGetIPAddress[a] = Convert.ToInt16(GetCorrectIPAddress[a]);

                        if(TempGetIPAddress[a]>255 | TempGetIPAddress[a]<0)
                            {
                            MessageBox.Show("The IP address you input is invalid, the value is 0~255, please revise and retry.\r\n你输入的IP地址无效，正确值得范围为0~255，请修改后再重试.");
                            return null;
                            }
                        
                        }                                       

                    }
                
                }
            catch(Exception)
                {
                return null;
                }

            string TempStr = Convert.ToString(TempGetIPAddress[0]) + "." + Convert.ToString(TempGetIPAddress[1]) + "." + Convert.ToString(TempGetIPAddress[2]) + "." + Convert.ToString(TempGetIPAddress[3]);
            return IPAddress.Parse(TempStr);

            //return IPAddress.Parse(Convert.ToString(TempGetIPAddress[0]) + "." + Convert.ToString(TempGetIPAddress[1]) + "." + Convert.ToString(TempGetIPAddress[2]) + "." + Convert.ToString(TempGetIPAddress[3]));

            }

        //验证IP地址的有效性，如果验证成功则返回正确IP地址
        /// <summary>
        /// 验证IP地址的有效性，如果验证成功则返回正确IP地址
        /// </summary>
        /// <param name="TargetIPAddress">待验证IP地址字符串</param>
        /// <param name="GetBackIPAddress">返回正确的IP地址</param>
        /// <returns></returns>
        public bool VerifyIPAddress(string TargetIPAddress, out IPAddress GetBackIPAddress)
            {

            if (PasswordIsCorrect == false)
                {
                MessageBox.Show("Right Prohibited.\r\n     You don't have the given right to use this DLL library, please contact with ThomasPeng.\r\n你未得到授权的密码，无法使用此DLL进行软件开发！请与作者彭东南联系：southeastofstar@163.com\r\n                                                                版权所有： 彭东南", "非法操作", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                GetBackIPAddress = null;
                return false;
                }

            IPAddress TempIPAddress = IPAddress.Parse("127.0.0.1");
            string[] GetCorrectIPAddress = new string[4];
            Int16[] TempGetIPAddress = new Int16[4];

            try
                {

                //1、判断输入的服务器IP地址是否正确
                if (IPAddress.TryParse(TargetIPAddress, out TempIPAddress) == false)
                    {
                    MessageBox.Show("The format of IP address is not correct, please retry.\r\nIP地址格式不正确， 请修改参数.");
                    GetBackIPAddress = null;
                    return false;
                    }
                else
                    {
                    //************************************
                    //此处解析IP地址不对："192.168.000.024"解析为"192.168.000.20"
                    //故需要自己写算法得到正确IP地址
                    //string TempStr=Convert.ToString(TempIPAddress);
                    //GetCorrectIPAddress = Strings.Split(TempStr,".");

                    //------------------------------------
                    GetCorrectIPAddress = Strings.Split(TargetIPAddress, ".");
                    //************************************

                    for (Int16 a = 0; a < 4; a++)
                        {

                        TempGetIPAddress[a] = Convert.ToInt16(GetCorrectIPAddress[a]);

                        if (TempGetIPAddress[a] > 255 | TempGetIPAddress[a] < 0)
                            {
                            MessageBox.Show("The IP address you input is invalid, the value is 0~255, please revise and retry.\r\n你输入的IP地址无效，正确值得范围为0~255，请修改后再重试.");
                            GetBackIPAddress = null;
                            return false;
                            }

                        }

                    }

                string TempStr = Convert.ToString(TempGetIPAddress[0]) + "." + Convert.ToString(TempGetIPAddress[1]) + "." + Convert.ToString(TempGetIPAddress[2]) + "." + Convert.ToString(TempGetIPAddress[3]);
                GetBackIPAddress = IPAddress.Parse(TempStr);

                }
            catch (Exception)
                {
                GetBackIPAddress = null;
                return false;
                }
                 
            return true;
                   
            }              

        //验证IP地址和端口的有效性
        /// <summary>
        /// 验证IP地址和端口的有效性
        /// </summary>
        /// <param name="TargetIPAddress">目标IP地址字符串</param>
        /// <param name="TargetPort">目标端口</param>
        /// <returns>是否验证成功</returns>
        public bool VerifyIPAddressAndPort(ref string TargetIPAddress, ref ushort TargetPort)
            {

            if (PasswordIsCorrect == false)
                {
                MessageBox.Show("Right Prohibited.\r\n     You don't have the given right to use this DLL library, please contact with ThomasPeng.\r\n你未得到授权的密码，无法使用此DLL进行软件开发！请与作者彭东南联系：southeastofstar@163.com\r\n                                                                版权所有： 彭东南", "非法操作", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
                }

            IPAddress TempIPAddress = IPAddress.Parse("127.0.0.1");
            string[] GetCorrectIPAddress = new string[4];
            Int16[] TempGetIPAddress = new Int16[4];
            bool IPAddressCorrect, PortCorrect;

            IPAddressCorrect = false;
            PortCorrect = false;

            try
                {

                //1、判断输入的服务器IP地址是否正确
                if (IPAddress.TryParse(TargetIPAddress, out TempIPAddress) == false)
                    {
                    MessageBox.Show("The format of IP address is not correct, please retry.\r\nIP地址格式不正确， 请修改参数.");
                    //TargetIPAddress = "";
                    IPAddressCorrect = false;
                    }
                else
                    {
                    //************************************
                    //此处解析IP地址不对："192.168.000.024"解析为"192.168.000.20"
                    //故需要自己写算法得到正确IP地址
                    //string TempStr=Convert.ToString(TempIPAddress);
                    //GetCorrectIPAddress = Strings.Split(TempStr,".");

                    //------------------------------------
                    GetCorrectIPAddress = Strings.Split(TargetIPAddress, ".");
                    //************************************

                    for (Int16 a = 0; a < 4; a++)
                        {

                        TempGetIPAddress[a] = Convert.ToInt16(GetCorrectIPAddress[a]);

                        if (TempGetIPAddress[a] > 255 | TempGetIPAddress[a] < 0)
                            {
                            MessageBox.Show("The IP address you input is invalid, the value is 0~255, please revise and retry.\r\n你输入的IP地址无效，正确值得范围为0~255，请修改后再重试.");
                            //TargetIPAddress = "";
                            IPAddressCorrect = false;
                            }

                        }

                    }

                IPAddressCorrect = true;

                if (TargetPort < 0 | TargetPort > 65535)
                    {
                    MessageBox.Show("The port value for the Server is not correct, please retry.\r\n你输入的IP地址无效，正确值得范围为0~65535，请修改后再重试.");
                    PortCorrect = false;
                    }
                else
                    {
                    PortCorrect = true;
                    }

                }
            catch (Exception)
                {
                //TargetIPAddress = "";
                return false;
                }

            if (IPAddressCorrect == false | PortCorrect == false)
                {
                return false;
                }
            else if (IPAddressCorrect == true & PortCorrect == true)
                return true;
            else
                return false;
            
            }

        //验证IP地址和端口的有效性
        /// <summary>
        /// 验证IP地址和端口的有效性
        /// </summary>
        /// <param name="TargetIPAddress">目标IP地址字符串</param>
        /// <param name="TargetPort">目标端口</param>
        /// <param name="GetBackIPAddress">返回正确的IP地址</param>
        /// <returns></returns>
        public bool VerifyIPAddressAndPort(string TargetIPAddress, ushort TargetPort,
            out IPAddress GetBackIPAddress)
            {

            if (PasswordIsCorrect == false)
                {
                MessageBox.Show("Right Prohibited.\r\n     You don't have the given right to use this DLL library, please contact with ThomasPeng.\r\n你未得到授权的密码，无法使用此DLL进行软件开发！请与作者彭东南联系：southeastofstar@163.com\r\n                                                                版权所有： 彭东南", "非法操作", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                GetBackIPAddress = null;
                return false;
                }

            IPAddress TempIPAddress = IPAddress.Parse("127.0.0.1");
            string[] GetCorrectIPAddress = new string[4];
            Int16[] TempGetIPAddress = new Int16[4];
            bool IPAddressCorrect, PortCorrect;

            IPAddressCorrect = false;
            PortCorrect = false;

            try
                {

                //1、判断输入的服务器IP地址是否正确
                if (IPAddress.TryParse(TargetIPAddress, out TempIPAddress) == false)
                    {
                    MessageBox.Show("The format of IP address is not correct, please retry.\r\nIP地址格式不正确， 请修改参数.");
                    GetBackIPAddress = null;
                    IPAddressCorrect = false;
                    }
                else
                    {
                    //************************************
                    //此处解析IP地址不对："192.168.000.024"解析为"192.168.000.20"
                    //故需要自己写算法得到正确IP地址
                    //string TempStr=Convert.ToString(TempIPAddress);
                    //GetCorrectIPAddress = Strings.Split(TempStr,".");

                    //------------------------------------
                    GetCorrectIPAddress = Strings.Split(TargetIPAddress, ".");
                    //************************************

                    for (Int16 a = 0; a < 4; a++)
                        {

                        TempGetIPAddress[a] = Convert.ToInt16(GetCorrectIPAddress[a]);

                        if (TempGetIPAddress[a] > 255 | TempGetIPAddress[a] < 0)
                            {
                            MessageBox.Show("The IP address you input is invalid, the value is 0~255, please revise and retry.\r\n你输入的IP地址无效，正确值得范围为0~255，请修改后再重试.");
                            GetBackIPAddress = null;
                            IPAddressCorrect = false;
                            }

                        }

                    }

                IPAddressCorrect = true;

                if (TargetPort < 0 | TargetPort > 65535)
                    {
                    MessageBox.Show("The port value for the Server is not correct, please retry.\r\n你输入的IP地址无效，正确值得范围为0~65535，请修改后再重试.");
                    PortCorrect = false;
                    }
                else
                    {
                    PortCorrect = true;
                    }

                }
            catch (Exception)
                {
                GetBackIPAddress = null;
                return false;
                }

            if (IPAddressCorrect == false)
                {
                GetBackIPAddress = null;
                return false;
                }
            else if (IPAddressCorrect == true & PortCorrect == true)
                {
                string TempStr = Convert.ToString(TempGetIPAddress[0]) + "." + Convert.ToString(TempGetIPAddress[1]) + "." + Convert.ToString(TempGetIPAddress[2]) + "." + Convert.ToString(TempGetIPAddress[3]);
                GetBackIPAddress = IPAddress.Parse(TempStr);
                return true;
                }
            else
                {
                GetBackIPAddress = null;
                return false;
                }
            
            }

        // 获取TCP/IP网络中所有可用的IP地址
        /// <summary>
        /// 获取TCP/IP网络中所有可用的IP地址
        /// </summary>
        /// <returns>返回TCP/IP网络中所有可用IP地址的字符串数组</returns>
        public string[] SearchAvailableIPAddresses()
            {

            if (PasswordIsCorrect == false)
                {
                MessageBox.Show("Right Prohibited.\r\n     You don't have the given right to use this DLL library, please contact with ThomasPeng.\r\n你未得到授权的密码，无法使用此DLL进行软件开发！请与作者彭东南联系：southeastofstar@163.com\r\n                                                                版权所有： 彭东南", "非法操作", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
                }

            string InstructionsForSearchingIPAddress = "";
            bool ChineseLanguage = false;

            //定义变量存储文件名
            string BATFileNameForGetIPAddress = "C:\\Windows\\Temp\\SearchIPAddress.bat";
            string TXTFileNameForSaveIPAddress = "C:\\Windows\\Temp\\GotIPAddress.txt";

            //Int16 iMaxCountOfComputers = 100;
            string[] sAllIPAddress;  //存储网络中实际存在的IP地址
            //Int16 iWaitTimeCount;    //定义最大等待时间，超时就退出扫描等待

            //定义类用于操作计算机相关信息，类似于VB .NET中的my.computer
            Microsoft.VisualBasic.Devices.Computer pcFileSystem= new Microsoft.VisualBasic.Devices.Computer();

            try
                {

                //System.Net.NetworkInformation.TcpConnectionInformation xx;
                Microsoft.VisualBasic.Devices.Network TempNetwork = new Microsoft.VisualBasic.Devices.Network();

                //bool TempBool;
                //TempBool = TempNetwork.IsAvailable;

                if (TempNetwork.IsAvailable == false)
                    {
                    MessageBox.Show("This compueter has not connected to the network yet, please check the reason and retry.\r\n计算机未连接到网络，请检查原因后再尝试搜索.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return null;
                    }

                //1、清除目录下的原有BAT/TXT文件记录【如果存在的话】
                if (pcFileSystem.FileSystem.FileExists(BATFileNameForGetIPAddress) == true) 
                    {
                    pcFileSystem.FileSystem.DeleteFile(BATFileNameForGetIPAddress);
                    }

                if (pcFileSystem.FileSystem.FileExists(TXTFileNameForSaveIPAddress) == true)
                    {
                    pcFileSystem.FileSystem.DeleteFile(TXTFileNameForSaveIPAddress);
                    }

                //*****************************
                //以下是通过批处理命令arp -a得到的结果：
                //
                //接口: 192.168.0.125 --- 0x3
                //  Internet 地址         物理地址              类型
                //  192.168.0.1           8c-a6-df-7e-81-fa     动态        
                //  192.168.0.101         74-04-2b-d3-db-1e     动态        
                //  192.168.0.124         fc-d7-33-3a-5d-cc     动态        
                //  192.168.0.255         ff-ff-ff-ff-ff-ff     静态        
                //  224.0.0.2             01-00-5e-00-00-02     静态        
                //  224.0.0.22            01-00-5e-00-00-16     静态        
                //  224.0.0.251           01-00-5e-00-00-fb     静态        
                //  224.0.0.252           01-00-5e-00-00-fc     静态        
                //255.255.255.255       ff-ff-ff-ff-ff-ff     静态
                //以上总共3列，Tokens=1得到IP地址这一列，Tokens=2得到物理地址这一列，Tokens=3得到类型这一列，而且上面的内容是以空格为分隔符；

                //**********************************
                //Tokens用于获取第n列的内容；
                //delims用于定义分隔符；
                //skip=n 忽略文本开头的前n行；
                //eol=c  忽略以某字符开头的行；
                //**********************************

                //2、组织BAT命令
                //将DOS的批处理命令写入文件BAT中

                //>：批处理命令中的>是将内容导出到某文件或其它目标，并进行覆盖，比如：ECHO Done>C:\Example.txt,即将文字Done写入文件C:\Example.txt，如果原来存在此文件，则会覆盖
                //>>：同样是导出内容，但是执行的是添加的动作，如果原来存在某文件或目标，则会在最后添加相应内容

                //方法二：在批处理文件的最后一句添加一条删除自身的语句，执行后就扫描此文件是否存在，如果不存在就读取保存的txt文件进行IP地址读取处理；

                if (ChineseLanguage == true)
                    {

                    InstructionsForSearchingIPAddress = "\r\nchcp 936\r\nCOLOR 0A\r\nCLS\r\n@ECHO Off\r\nfor /f \"skip=3 tokens=1,* delims= \" %%i in ('arp -a') do ECHO %%i>> " + TXTFileNameForSaveIPAddress + "\r\nECHO.\r\ndel " + BATFileNameForGetIPAddress;

                    //COLOR 0A
                    //'CLS
                    //'@ECHO Off
                    //'Title 查询局域网内在线电脑IP
                    //':send
                    //'@ECHO off&setlocal enabledelayedexpansion
                    //'ECHO 正在获取本机的IP地址，请稍等... 
                    //'for /f "tokens=2 skip=1 delims=: " %%i in ('nbtstat -n') do ( 
                    //'set "IP=%%i" 
                    //'set IP=!IP:~1,-1! 
                    //'ECHO 本机IP为：!IP! 
                    //'goto :next 
                    //')
                    //':next 
                    //'for /f "delims=. tokens=1,2,3,4,5" %%i in ("%IP%") do setrange=%%i.%%j.%%k 
                    //'ECHO.&ECHO 正在获取本网段内的其它在线计算机名，请稍等...
                    //'ECHO 本网段【%range%.*】内的计算机有： 
                    //'for /f "delims=" %%i in ('net view') do ( 
                    //'set "var=%%i" 
                    //'::查询在线计算机名称 
                    //'if "!var:~0,2!"=="\\" ( 
                    //'set "var=!var:~2!" 
                    //'ECHO !var! 
                    //'ping -n 1 !var!>nul ECHO !var!
                    //')) 
                    //'ECHO.
                    //'ECHO 正在获取本网段内的其它在线计算机IP，请稍等... 
                    //'arp -a
                    //'for /f "skip=1 tokens=1,* delims= " %%i in ('arp -a') do ECHO IP： %%i 正在使用
                    //'ECHO.
                    //'ECHO 查询完毕，按任意键退出...
                    //'pause>nul

                    }
                else 
                    {
                    //转换为简体中文，才能够正确显示绿色字体，否则白色字体
                    InstructionsForSearchingIPAddress = "\r\nchcp 936\r\nCOLOR 0A\r\nCLS\r\n@ECHO Off\r\nfor /f \"skip=3 tokens=1,* delims= \" %%i in ('arp -a') do ECHO %%i>> " + TXTFileNameForSaveIPAddress + "\r\nECHO.\r\ndel " + BATFileNameForGetIPAddress;
                    
                    }

                //3、写入BAT命令至文件
                //保存的中文会乱码，不支持GB码
                //pcFileSystem.FileSystem.WriteAllText(BATFileNameForGetIPAddress, InstructionsForSearchingIPAddress, false, System.Text.Encoding.ASCII) //System.Text.Encoding.GetEncoding(936));

                //保存的中文不会乱码，但是在DOS环境下会乱码
                pcFileSystem.FileSystem.WriteAllText(BATFileNameForGetIPAddress,InstructionsForSearchingIPAddress,false);

                //4、执行BAT命令【隐藏DOS命令窗口】
                Microsoft.VisualBasic.Interaction.Shell(BATFileNameForGetIPAddress, Microsoft.VisualBasic.AppWinStyle.Hide);
                //Microsoft.VisualBasic.Interaction.Shell(BATFileNameForGetIPAddress, Microsoft.VisualBasic.AppWinStyle.Hide,true,2000);

                //5、等待BAT命令完成
                //方法一：读取指定文件，并判断完成标志

                //方法二：在批处理文件的最后一句添加一条删除自身的语句，执行后就扫描此文件是否存在，如果不存在就读取保存的txt文件进行IP地址读取处理；
                Int16 iOverTimeCounter = 0;

                do
                    {

                    Thread.Sleep(1);
                    System.Windows.Forms.Application.DoEvents();
                    iOverTimeCounter += 1;
                    if(iOverTimeCounter>=5000)
                        {

                        if (MessageBox.Show("It took a bit long time to search but haven't finished yet, are you sure to continue?\r\n已经花了比较长的时间进行搜索，但还没有完成，还要继续吗？",
                            "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                            {
                            iOverTimeCounter = 0;
                            }
                        else 
                            {
                            return null;
                            }
                        
                        }
                    
                    }while(pcFileSystem.FileSystem.FileExists(BATFileNameForGetIPAddress)==true);

                //6、判断是否已经联网，并处理没有网络就退出函数
                //如果记录IP地址的TXT文件不存在，则证明电脑没有和其它网络相连

                if (pcFileSystem.FileSystem.FileExists(TXTFileNameForSaveIPAddress) == false) 
                    {
                    MessageBox.Show("Maybe you don't run this program with the Administrator right, or there was an system error. Please check the reason and retry.\r\n你没有以管理员身份运行此程序或者已经引发了系统错误，请检查是否开启网络发现和其他原因后再尝试.",
                        "Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    return null;
                    }

                //7、从文本文件读取记录进行处理
                //用File.ReadAllLines方法读取文件会执行关闭动作，会导致DOS BAT文件执行写入时出现异常

                //读取存储IP地址的文件
                sAllIPAddress = System.IO.File.ReadAllLines(TXTFileNameForSaveIPAddress);

                //清除目录下的原有BAT/TXT文件记录【如果存在的话】
                if (pcFileSystem.FileSystem.FileExists(BATFileNameForGetIPAddress) == true)
                    {
                    pcFileSystem.FileSystem.DeleteFile(BATFileNameForGetIPAddress);
                    }

                if (pcFileSystem.FileSystem.FileExists(TXTFileNameForSaveIPAddress) == true)
                    {
                    pcFileSystem.FileSystem.DeleteFile(TXTFileNameForSaveIPAddress);
                    }

                //执行BAT文件时可能会出现权限不够无法执行或者执行中遇到错误的情况，导致保存执行结果的TXT文件为空，在此进行判断。

                if(sAllIPAddress.Length==0)                    
                    {
                    MessageBox.Show("Maybe you don't run this program with the Administrator right, or there was an system error. Please check the reason and retry.\r\n你没有以管理员身份运行此程序或者已经引发了系统错误，请检查是否开启网络发现和其他原因后再尝试.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return null; 
                    }

                //临时存储IP地址，按照最大的额度来定义
                string[] TempAllIPAddress=new string[sAllIPAddress.Length];

                //计算实际有效的IP地址个数：去除空字符串，可能会有最后一个是回车换行符号
                Int16 ActualNumberOfIPAddress = 0;
                int TempLength=sAllIPAddress.Length;

                for (int b = 0; b < TempLength; b++)
                    {

                    if ((sAllIPAddress[b] != "") & (sAllIPAddress[b] != "\r\n"))
                        {
                        TempAllIPAddress[ActualNumberOfIPAddress] = sAllIPAddress[b];
                        ActualNumberOfIPAddress += 1;
                        }
                    }

                //重新定义AllIPAddress的长度，用于保存IP地址
                sAllIPAddress=new string[ActualNumberOfIPAddress];

                //将读取到的IP地址复制到AllIPAddress
                for (int b = 0; b < ActualNumberOfIPAddress; b++) 
                    {
                    sAllIPAddress[b]=TempAllIPAddress[b];
                    }

                }
            catch(Exception ex)
                {
                //清除目录下的原有BAT/TXT文件记录【如果存在的话】
                if (pcFileSystem.FileSystem.FileExists(BATFileNameForGetIPAddress) == true)
                    {
                    pcFileSystem.FileSystem.DeleteFile(BATFileNameForGetIPAddress);
                    }

                if (pcFileSystem.FileSystem.FileExists(TXTFileNameForSaveIPAddress) == true)
                    {
                    pcFileSystem.FileSystem.DeleteFile(TXTFileNameForSaveIPAddress);
                    }
                MessageBox.Show(ex.Message);
                return null;
                }

            return sAllIPAddress;
            
            }

        //获取网络中已经联网的MAC地址【字符串数组】
        /// <summary>
        /// 获取网络中已经联网的MAC地址【字符串数组】
        /// </summary>
        /// <returns></returns>
        public string[] SearchAvailableMACAddress()
            {

            if (PasswordIsCorrect == false)
                {
                MessageBox.Show("Right Prohibited.\r\n     You don't have the given right to use this DLL library, please contact with ThomasPeng.\r\n你未得到授权的密码，无法使用此DLL进行软件开发！请与作者彭东南联系：southeastofstar@163.com\r\n                                                                版权所有： 彭东南", "非法操作", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
                }

            string GetIPAndMACAddress = "";
            //bool ChineseLanguage = false;

            //定义变量存储文件名
            string BATFileNameForGetIPAndMACAddress = "C:\\Windows\\Temp\\SearchMACAddress.bat";
            string TXTFileNameForSaveIPAndMACAddress = "C:\\Windows\\Temp\\GotMACAddress.txt";

            //Int16 iMaxCountOfComputers = 100;
            string[] sAllMACAddress;  //存储网络中实际存在的IP地址
            //Int16 iWaitTimeCount;    //定义最大等待时间，超时就退出扫描等待

            //定义类用于操作计算机相关信息，类似于VB .NET中的my.computer
            Microsoft.VisualBasic.Devices.Computer pcFileSystem = new Microsoft.VisualBasic.Devices.Computer();

            try
                {

                //System.Net.NetworkInformation.TcpConnectionInformation xx;
                Microsoft.VisualBasic.Devices.Network TempNetwork = new Microsoft.VisualBasic.Devices.Network();

                //bool TempBool;
                //TempBool = TempNetwork.IsAvailable;

                if (TempNetwork.IsAvailable == false)
                    {
                    MessageBox.Show("This compueter has not connected to the network yet, please check the reason and retry.\r\n计算机未连接到网络，请检查原因后再尝试搜索.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return null;
                    }

                //1、清除目录下的原有BAT/TXT文件记录【如果存在的话】
                if (pcFileSystem.FileSystem.FileExists(BATFileNameForGetIPAndMACAddress) == true)
                    {
                    pcFileSystem.FileSystem.DeleteFile(BATFileNameForGetIPAndMACAddress);
                    }

                if (pcFileSystem.FileSystem.FileExists(TXTFileNameForSaveIPAndMACAddress) == true)
                    {
                    pcFileSystem.FileSystem.DeleteFile(TXTFileNameForSaveIPAndMACAddress);
                    }

                //*****************************
                //以下是通过批处理命令arp -a得到的结果：
                //
                //接口: 192.168.0.125 --- 0x3
                //  Internet 地址         物理地址              类型
                //  192.168.0.1           8c-a6-df-7e-81-fa     动态        
                //  192.168.0.101         74-04-2b-d3-db-1e     动态        
                //  192.168.0.124         fc-d7-33-3a-5d-cc     动态        
                //  192.168.0.255         ff-ff-ff-ff-ff-ff     静态        
                //  224.0.0.2             01-00-5e-00-00-02     静态        
                //  224.0.0.22            01-00-5e-00-00-16     静态        
                //  224.0.0.251           01-00-5e-00-00-fb     静态        
                //  224.0.0.252           01-00-5e-00-00-fc     静态        
                //255.255.255.255       ff-ff-ff-ff-ff-ff     静态
                //以上总共3列，Tokens=1得到IP地址这一列，Tokens=2得到物理地址这一列，Tokens=3得到类型这一列，而且上面的内容是以空格为分隔符；

                //**********************************
                //Tokens用于获取第n列的内容；
                //delims用于定义分隔符；
                //skip=n 忽略文本开头的前n行；
                //eol=c  忽略以某字符开头的行；
                //**********************************

                //2、组织BAT命令
                //将DOS的批处理命令写入文件BAT中

                //>：批处理命令中的>是将内容导出到某文件或其它目标，并进行覆盖，比如：ECHO Done>C:\Example.txt,即将文字Done写入文件C:\Example.txt，如果原来存在此文件，则会覆盖
                //>>：同样是导出内容，但是执行的是添加的动作，如果原来存在某文件或目标，则会在最后添加相应内容

                GetIPAndMACAddress = "@ECHO Off\r\nfor /f \"skip=3 tokens=2,* delims= \" %%i in ('arp -a') do ECHO %%i>>\r\n" + TXTFileNameForSaveIPAndMACAddress +"\r\ndel " + BATFileNameForGetIPAndMACAddress;
                
                //3、写入BAT命令至文件
                //保存的中文会乱码，不支持GB码
                //pcFileSystem.FileSystem.WriteAllText(BATFileNameForGetIPAddress, InstructionsForSearchingIPAddress, false, System.Text.Encoding.ASCII) //System.Text.Encoding.GetEncoding(936));

                //保存的中文不会乱码，但是在DOS环境下会乱码
                pcFileSystem.FileSystem.WriteAllText(BATFileNameForGetIPAndMACAddress, GetIPAndMACAddress, false);

                //4、执行BAT命令【隐藏DOS命令窗口】
                Microsoft.VisualBasic.Interaction.Shell(BATFileNameForGetIPAndMACAddress, Microsoft.VisualBasic.AppWinStyle.Hide);
                //Microsoft.VisualBasic.Interaction.Shell(BATFileNameForGetIPAddress, Microsoft.VisualBasic.AppWinStyle.Hide,true,2000);

                //5、等待BAT命令完成
                //方法一：读取指定文件，并判断完成标志

                //方法二：在批处理文件的最后一句添加一条删除自身的语句，执行后就扫描此文件是否存在，如果不存在就读取保存的txt文件进行IP地址读取处理；
                Int16 iOverTimeCounter = 0;

                do
                    {

                    Thread.Sleep(1);
                    System.Windows.Forms.Application.DoEvents();
                    iOverTimeCounter += 1;
                    if (iOverTimeCounter >= 5000)
                        {

                        if (MessageBox.Show("It took a bit long time to search but haven't finished yet, are you sure to continue?\r\n已经花了比较长的时间进行搜索，但还没有完成，还要继续吗？",
                            "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                            {
                            iOverTimeCounter = 0;
                            }
                        else
                            {
                            return null;
                            }

                        }

                    } while (pcFileSystem.FileSystem.FileExists(BATFileNameForGetIPAndMACAddress) == true);

                //6、判断是否已经联网，并处理没有网络就退出函数
                //如果记录IP地址的TXT文件不存在，则证明电脑没有和其它网络相连

                if (pcFileSystem.FileSystem.FileExists(TXTFileNameForSaveIPAndMACAddress) == false)
                    {
                    MessageBox.Show("Maybe you didn't run this program with the Administrator right, or there was an system error. Please check the reason and retry.\r\n你没有以管理员身份运行此程序或者已经引发了系统错误，请检查是否开启网络发现和其他原因后再尝试.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return null;
                    }

                //7、从文本文件读取记录进行处理
                //用File.ReadAllLines方法读取文件会执行关闭动作，会导致DOS BAT文件执行写入时出现异常

                //读取存储IP地址的文件
                sAllMACAddress = System.IO.File.ReadAllLines(TXTFileNameForSaveIPAndMACAddress);

                //清除目录下的原有BAT/TXT文件记录【如果存在的话】
                if (pcFileSystem.FileSystem.FileExists(BATFileNameForGetIPAndMACAddress) == true)
                    {
                    pcFileSystem.FileSystem.DeleteFile(BATFileNameForGetIPAndMACAddress);
                    }

                if (pcFileSystem.FileSystem.FileExists(TXTFileNameForSaveIPAndMACAddress) == true)
                    {
                    pcFileSystem.FileSystem.DeleteFile(TXTFileNameForSaveIPAndMACAddress);
                    }

                //执行BAT文件时可能会出现权限不够无法执行或者执行中遇到错误的情况，导致保存执行结果的TXT文件为空，在此进行判断。

                if (sAllMACAddress.Length == 0)
                    {
                    MessageBox.Show("Maybe you didn't run this program with the Administrator right, or there was an system error. Please check the reason and retry.\r\n你没有以管理员身份运行此程序或者已经引发了系统错误，请检查是否开启网络发现和其他原因后再尝试.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return null;
                    }

                //临时存储IP地址，按照最大的额度来定义
                string[] TempAllIPAddress = new string[sAllMACAddress.Length];

                //计算实际有效的IP地址个数：去除空字符串，可能会有最后一个是回车换行符号
                Int16 ActualNumberOfIPAddress = 0;
                int TempLength = sAllMACAddress.Length;

                for (int b = 0; b < TempLength; b++)
                    {

                    if ((sAllMACAddress[b] != "") & (sAllMACAddress[b] != "\r\n"))
                        {
                        TempAllIPAddress[ActualNumberOfIPAddress] = sAllMACAddress[b];
                        ActualNumberOfIPAddress += 1;
                        }
                    }

                //重新定义AllIPAddress的长度，用于保存IP地址
                sAllMACAddress = new string[ActualNumberOfIPAddress];

                //将读取到的IP地址复制到AllIPAddress
                for (int b = 0; b < ActualNumberOfIPAddress; b++)
                    {
                    sAllMACAddress[b] = TempAllIPAddress[b];
                    }

                }
            catch (Exception ex)
                {
                //清除目录下的原有BAT/TXT文件记录【如果存在的话】
                if (pcFileSystem.FileSystem.FileExists(BATFileNameForGetIPAndMACAddress) == true)
                    {
                    pcFileSystem.FileSystem.DeleteFile(BATFileNameForGetIPAndMACAddress);
                    }

                if (pcFileSystem.FileSystem.FileExists(TXTFileNameForSaveIPAndMACAddress) == true)
                    {
                    pcFileSystem.FileSystem.DeleteFile(TXTFileNameForSaveIPAndMACAddress);
                    }
                MessageBox.Show(ex.Message);
                return null;
                }

            return sAllMACAddress;
            
            }

        //返回当前电脑IP4地址
        /// <summary>
        /// 返回当前电脑IP4地址
        /// </summary>
        /// <returns></returns>
        public string GetLocalIP4Address()
            {

            if (PasswordIsCorrect == false)
                {
                MessageBox.Show("Right Prohibited.\r\n     You don't have the given right to use this DLL library, please contact with ThomasPeng.\r\n你未得到授权的密码，无法使用此DLL进行软件开发！请与作者彭东南联系：southeastofstar@163.com\r\n                                                                版权所有： 彭东南", "非法操作", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
                }

            //'************************
            //'Dns法子总是以IPHostEntry对象的形式返回信息.它从 Internet 域名系统 (DNS) 检索关于特定主机的信息。它属于System.Net 命令空间
            //'其最常用的几个法子如下:
            //'获取当前电脑名:    System.Net.Dns.GetHostName()
            //'根据电脑名取出整个IP地址：System.Net.Dns.Resolve(电脑名).AddressList 或者 System.Net.Dns.GetHostByName(电脑名).AddressList根据IP地址取出电脑名：System.Net.Dns.Resolve(IP地址).HostName

            //'Public Shared Function GetHostEntry(ByVal address As System.Net.IPAddress) As System.Net.IPHostEntry
            //'System.Net.Dns(的成员)
            //'摘要:
            //'将 IP 地址解析为 System.Net.IPHostEntry 实例。

            //'参数:
            //'address: IP 地址。

            //'返回值:
            //'一个 System.Net.IPHostEntry 实例，包含有关 address 中指定的主机的地址信息。

            //'异常:
            //'System.ArgumentNullException: address 为 null。
            //'System.Net.Sockets.SocketException: 解析 address 时遇到错误。
            //'System.ArgumentException: address 是无效的 IP 地址

            string ActualIPAddress = "";

            try
                {

                //'*******************
                //'如果没有联网，则会返回字符串数组【两行】"::1     127.0.0.1" ////一个ScopeId,然后是IP4地址,可能是0.0.0.0，那这样就要用127.0.0.1代替///
                //'如果电脑已经联网，且只有一个网络，则会返回一个IP6地址【ScopeId】和IP4地址，例如：【两行】fe80::8119:e3fd:5efd:884e%3    192.168.0.125
                //'如果电脑已经联网，并且联到内、外网，则会返回两个IP6地址【ScopeId】,然后是两个IP4地址，第一个是外网IP4地址，第二个是内网IP4地址，如下面所示：
                //'Host(Name) : plc08
                //'IP address List : 
                //'fe80::803a:3983:6633:e634%12
                //'fe80::287b:21e:3f57:f512%11
                //'169.254.187.94
                //'192.168.10.237
                //'2001:0:808:808:287b:21e:3f57:f512

                //'所以必须要对找到的IP地址进行刷选，查找符号'.'，然后判断所查到的IP地址数是否为1个，否则就选择第二个为本机IP地址
                //'*******************

                //获得本地计算机的主机名 
                string HostName = "";
                HostName = System.Net.Dns.GetHostName();

                //解析获得的本地计算机主机名
                IPHostEntry HostInfo = System.Net.Dns.GetHostEntry(HostName);

                if(HostInfo.AddressList[0].ToString()=="::1")
                    {
                    MessageBox.Show("No other computer/device in the network...\r\n此时网络中没有其它设备...",
                        "",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return "127.0.0.1";
                    }

                int iIdex = 0;
                string[] sTempIPAddress=new string[HostInfo.AddressList.Length];
                Int16 iTempIPCount = 0;

                //找出IP4地址：从获取的字符串搜索.，有符号.则是IP4地址
                for (iIdex = 0; iIdex < HostInfo.AddressList.Length;iIdex++ ) 
                    {
                    
                    if(Strings.InStr(HostInfo.AddressList[iIdex].ToString(),".")>0)
                        {
                        sTempIPAddress[iTempIPCount] = HostInfo.AddressList[iIdex].ToString();
                        iTempIPCount += 1;
                        }

                    }

                //进行判断并得到正确的本机IP4地址
                if (iTempIPCount == 1)
                    {
                    ActualIPAddress = sTempIPAddress[0];
                    }
                else
                    { 
                    ActualIPAddress = sTempIPAddress[1];
                    }

                }
            catch(Exception ex)
                {
                MessageBox.Show(ex.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return "";
                }

            return ActualIPAddress;
            
            }

        //返回当前电脑MAC地址
        /// <summary>
        /// 返回当前电脑MAC地址
        /// </summary>
        /// <returns></returns>
        public string GetLocalMACAddress()
            {

            if (PasswordIsCorrect == false)
                {
                MessageBox.Show("Right Prohibited.\r\n     You don't have the given right to use this DLL library, please contact with ThomasPeng.\r\n你未得到授权的密码，无法使用此DLL进行软件开发！请与作者彭东南联系：southeastofstar@163.com\r\n                                                                版权所有： 彭东南", "非法操作", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
                }

            string ActualMACAddress = "";

            try
                {

                System.Management.ManagementObjectSearcher GetMAC = new System.Management.ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration");

                foreach (System.Management.ManagementObject MACObj in GetMAC.Get())
                    {

                    System.Management.ManagementObject TempMAC = new System.Management.ManagementObject("IPEnabled");

                    if (Convert.ToBoolean(MACObj["IPEnabled"]) == true)
                        {
                        ActualMACAddress = MACObj["MACAddress"].ToString();
                        }
                    }

                }
            catch (Exception ex)
                {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
                }

            return ActualMACAddress;
            
            }

        //返回当前电脑IP6地址
        /// <summary>
        /// 返回当前电脑IP6地址
        /// </summary>
        /// <returns></returns>
        public string GetLocalIP6Address()
            {

            if (PasswordIsCorrect == false)
                {
                MessageBox.Show("Right Prohibited.\r\n     You don't have the given right to use this DLL library, please contact with ThomasPeng.\r\n你未得到授权的密码，无法使用此DLL进行软件开发！请与作者彭东南联系：southeastofstar@163.com\r\n                                                                版权所有： 彭东南", "非法操作", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
                }

            string ActualIPAddress = "";

            try
                {

                //'*******************
                //'如果没有联网，则会返回字符串数组【两行】"::1     127.0.0.1" ////一个ScopeId,然后是IP4地址,可能是0.0.0.0，那这样就要用127.0.0.1代替///
                //'如果电脑已经联网，且只有一个网络，则会返回一个IP6地址【ScopeId】和IP4地址，例如：【两行】fe80::8119:e3fd:5efd:884e%3    192.168.0.125
                //'如果电脑已经联网，并且联到内、外网，则会返回两个IP6地址【ScopeId】,然后是两个IP4地址，第一个是外网IP4地址，第二个是内网IP4地址，如下面所示：
                //'Host(Name) : plc08
                //'IP address List : 
                //'fe80::803a:3983:6633:e634%12
                //'fe80::287b:21e:3f57:f512%11
                //'169.254.187.94
                //'192.168.10.237
                //'2001:0:808:808:287b:21e:3f57:f512

                //'所以必须要对找到的IP地址进行刷选，查找符号'.'，然后判断所查到的IP地址数是否为1个，否则就选择第二个为本机IP地址
                //'*******************

                //获得本地计算机的主机名 
                string HostName = "";
                HostName = System.Net.Dns.GetHostName();

                //解析获得的本地计算机主机名
                IPHostEntry HostInfo = System.Net.Dns.GetHostEntry(HostName);

                if (HostInfo.AddressList[0].ToString() == "::1")
                    {
                    MessageBox.Show("No other computer/device in the network...\r\n此时网络中没有其它设备...",
                        "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return "";
                    }

                int iIdex = 0;
                string[] sTempIPAddress = new string[HostInfo.AddressList.Length];
                Int16 iTempIPCount = 0;

                //找出IP6地址：从获取的字符串搜索::，有符号.则是IP6地址
                for (iIdex = 0; iIdex < HostInfo.AddressList.Length; iIdex++)
                    {

                    if (Strings.InStr(HostInfo.AddressList[iIdex].ToString(), "::") > 0)
                        {
                        sTempIPAddress[iTempIPCount] = HostInfo.AddressList[iIdex].ToString();
                        iTempIPCount += 1;
                        }

                    }

                //进行判断并得到正确的本机IP6地址
                if (iTempIPCount == 1)
                    {
                    ActualIPAddress = sTempIPAddress[0];
                    }
                else
                    {
                    ActualIPAddress = sTempIPAddress[1];
                    }

                }
            catch (Exception ex)
                {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
                }

            return ActualIPAddress;
            
            }

        //返回当前电脑名[HOSTNAME]
        /// <summary>
        /// 返回当前电脑名[HOSTNAME]
        /// </summary>
        /// <returns></returns>
        public string GetPCName()
            {

            if (PasswordIsCorrect == false)
                {
                MessageBox.Show("Right Prohibited.\r\n     You don't have the given right to use this DLL library, please contact with ThomasPeng.\r\n你未得到授权的密码，无法使用此DLL进行软件开发！请与作者彭东南联系：southeastofstar@163.com\r\n                                                                版权所有： 彭东南", "非法操作", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
                }

            string TempPCName = "";

            try
                {
                TempPCName = System.Net.Dns.GetHostName();
                }
            catch (Exception ex)
                {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
                }

            return TempPCName;

            }

        //按照输入的IP地址区段搜索以太网设备
        /// <summary>
        /// 按照输入的IP地址区段搜索以太网设备
        /// </summary>
        /// <param name="TargetIPSegment">需要进行搜索的IP地址目标分段
        /// 例如搜索 "192.168.1.0~255" 整个区段的可用IP地址，则参数为 "192.168.1"
        /// </param>
        /// <returns>返回已经搜索到以太网设备的IP地址字符串数组</returns>
        public string[] SearchIPAddressForCertainSegment(string TargetIPSegment)
            {

            if (PasswordIsCorrect == false)
                {
                MessageBox.Show("Right Prohibited.\r\n     You don't have the given right to use this DLL library, please contact with ThomasPeng.\r\n你未得到授权的密码，无法使用此DLL进行软件开发！请与作者彭东南联系：southeastofstar@163.com\r\n                                                                版权所有： 彭东南", "非法操作", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
                }

            if(TargetIPSegment=="")
                {
                MessageBox.Show("The parameter \"TargetIPSegment\" is empty, please pass the correct parameter and retry.\r\n参数\"TargetIPSegment\"为空，请传递正确参数后再尝试.",
                    "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
                }

            //查找是否有两个"."号，如果没有则判断为参数不正确
            if (Strings.InStr(TargetIPSegment, ".") > 0)
                {

                //先找到第一个"."的位置，然后以这个位置为起点找下一个"."的位置；
                if (Strings.InStr(Strings.InStr(TargetIPSegment, ".") + 1, TargetIPSegment, ".") <= 0)
                    {
                    ErrorMessage = "参数\"TargetIPSegment\"不正确，例如：设置\"192.168.1\"来搜索区段\"192.168.1.0~255\", 请修改参数后再重试.";
                    MessageBox.Show("The value of parameter \"TargetIPSegment\" is not correct. For example: set \"192.168.1\" to search segment \"192.168.1.0~255\", please revise it and retry.\rn参数\"TargetIPSegment\"不正确，例如：设置\"192.168.1\"来搜索区段\"192.168.1.0~255\", 请修改参数后再重试.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                    }

                }
            else 
                {
                MessageBox.Show("The value of parameter \"TargetIPSegment\" is not correct. For example: set \"192.168.1\" to search segment \"192.168.1.0~255\", please revise it and retry.\rn参数\"TargetIPSegment\"不正确，例如：设置\"192.168.1\"来搜索区段\"192.168.1.0~255\", 请修改参数后再重试.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
                }

            //******************
            ushort usIP4, usIP3, usIP2;
            ushort usAllScannedIPCount=0;
            string[] sAllScannedIPAddress=null;
            //string sTempLocalIPAddress = "";
            string[] sTempAddress;

           //******************

            //最好是添加代码验证参数全部是数字和"."，没有其它非法字符

            try
                {

                //System.Net.NetworkInformation.TcpConnectionInformation xx;
                Microsoft.VisualBasic.Devices.Network TempNetwork = new Microsoft.VisualBasic.Devices.Network();

                //bool TempBool;
                //TempBool = TempNetwork.IsAvailable;

                if (TempNetwork.IsAvailable == false)
                    {
                    MessageBox.Show("This compueter has not connected to the network yet, please check the reason and retry.\r\n计算机未连接到网络，请检查原因后再尝试搜索.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return null;
                    }

                sTempAddress = Strings.Split(TargetIPSegment,".");

                if(sTempAddress.Length<3 | sTempAddress.Length>3)
                    {
                    ErrorMessage = "参数\"TargetIPSegment\"不正确，例如：设置\"192.168.1\"来搜索区段\"192.168.1.0~255\", 请修改参数后再重试.";
                    MessageBox.Show("The value of parameter \"TargetIPSegment\" is not correct. For example: set \"192.168.1\" to search segment \"192.168.1.0~255\", please revise it and retry.\rn参数\"TargetIPSegment\"不正确，例如：设置\"192.168.1\"来搜索区段\"192.168.1.0~255\", 请修改参数后再重试.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                    }

                if(sTempAddress[0]=="" | sTempAddress[1]=="" | sTempAddress[2]=="")
                    {
                    ErrorMessage = "IP地址段的值必须为0~255";
                    MessageBox.Show("The IP address section can't be empty, it must be 0~255.\r\nIP地址段的值必须为0~255",
                        "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return null;
                    }

                //三个分段任意一个不在0~255就报错
                if((Convert.ToInt16(sTempAddress[0])<0 | Convert.ToInt16(sTempAddress[0])>255)|
                    (Convert.ToInt16(sTempAddress[1])<0 | Convert.ToInt16(sTempAddress[1])>255)|
                    (Convert.ToInt16(sTempAddress[2])<0 | Convert.ToInt16(sTempAddress[2])>255))
                    {
                    ErrorMessage = "IP地址段的值必须为0~255";
                    MessageBox.Show("The IP address section can't be empty, it must be 0~255.\r\nIP地址段的值必须为0~255",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                    }

                ErrorMessage = "正在搜索网络中的以太网设备...";

                usIP4 = Convert.ToUInt16(sTempAddress[0]);
                usIP3 = Convert.ToUInt16(sTempAddress[1]);
                usIP2 = Convert.ToUInt16(sTempAddress[2]);

                //******************
                DateTime BeginTime, FinishTime, TempTime, OverTime;
                TimeSpan SpentTimeForSearching;

                FinishTime = DateTime.Now;
                BeginTime=DateTime.Now;
                OverTime=DateTime.Now;
                //******************

                Ping PingSender = new Ping();
                IPAddress Address;
                PingReply Reply;

                for (Int16 IP1 = 0; IP1 <= 255;IP1++) 
                    {

                    Address = IPAddress.Parse(usIP4 + "." + usIP3 + "." + usIP2 + "." + IP1);
                    Reply = PingSender.Send(Address,3);

                    System.Windows.Forms.Application.DoEvents();

                    if (Reply.Status == IPStatus.Success)
                        {
                        sAllScannedIPAddress = new string[usAllScannedIPCount];
                        sAllScannedIPAddress[usAllScannedIPCount] = Reply.Address.ToString();
                        }
                    else 
                        {
                        }

                    usAllScannedIPCount += 1;

                    TempTime = DateTime.Now;
                    SpentTimeForSearching = TempTime - OverTime;

                    if (SpentTimeForSearching.Minutes>1) 
                        {

                        if (MessageBox.Show("It already took " + SpentTimeForSearching.Minutes + "minute(s) to search the TCP/IP device, are you sure to continue?\r\n已经耗时 " + SpentTimeForSearching.Minutes + "分钟，是否还要继续进行搜索？",
                            "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                            {
                            ErrorMessage = "已经耗时 " + SpentTimeForSearching.Minutes + " 分钟，退出搜索...";
                            break;
                            }
                        else 
                            {
                            ErrorMessage = "已经耗时 " + SpentTimeForSearching.Minutes + " 分钟，继续进行搜索...";
                            OverTime = DateTime.Now;
                            System.Windows.Forms.Application.DoEvents();
                            }

                        }
                    
                    }

                FinishTime = DateTime.Now;
                SpentTimeForSearching = FinishTime - BeginTime;

                if (sAllScannedIPAddress.Length == 0)
                    {
                    ErrorMessage = "总计搜索到0个以太网设备." + " 耗时：" + SpentTimeForSearching.Minutes + "分" + SpentTimeForSearching.Seconds + "秒" +
                       SpentTimeForSearching.Milliseconds + "毫秒";

                    MessageBox.Show("There is no available TCP/IP device in the network, the searching spent: " + SpentTimeForSearching.Minutes + "m" +
                           SpentTimeForSearching.Seconds + "s" + SpentTimeForSearching.Milliseconds + "ms\r\n 总计搜索到0个以太网设备." +
                           " 耗时：" + SpentTimeForSearching.Minutes + "分" + SpentTimeForSearching.Seconds + "秒"
                           + SpentTimeForSearching.Milliseconds + "毫秒", "Overtime", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                else 
                    {

                    ErrorMessage = "总计搜索到 " + sAllScannedIPAddress.Length + " 个以太网设备， 耗时：" + SpentTimeForSearching.Minutes + "分" +
                              SpentTimeForSearching.Seconds + "秒" + SpentTimeForSearching.Milliseconds + "毫秒";

                    MessageBox.Show("There is(are) " + sAllScannedIPAddress.Length + " available TCP/IP device(s) in the network, the searching spent: " + SpentTimeForSearching.Minutes + "m" +
                        SpentTimeForSearching.Seconds + "s" + SpentTimeForSearching.Milliseconds + "ms\r\n 总计搜索到0个以太网设备." +
                        " 耗时：" + SpentTimeForSearching.Minutes + "分" + SpentTimeForSearching.Seconds + "秒"
                        + SpentTimeForSearching.Milliseconds + "毫秒", "Overtime", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                for (Int16 a = 0; a < sAllScannedIPAddress.Length;a++ ) 
                    {
                    ErrorMessage = "Found device-- No.: " + (a + 1) + " IP address: " + sAllScannedIPAddress[a];
                    }
                
                }
            catch (Exception ex)
                {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
                }

            return sAllScannedIPAddress;

            }

        //搜索网络中所有可用计算机的名称
        /// <summary>
        /// 搜索网络中所有可用计算机的名称
        /// </summary>
        /// <returns>返回搜索到的计算机名称数组</returns>
        public string[] SearchAvailablePCNames()
            {

            if (PasswordIsCorrect == false)
                {
                MessageBox.Show("Right Prohibited.\r\n     You don't have the given right to use this DLL library, please contact with ThomasPeng.\r\n你未得到授权的密码，无法使用此DLL进行软件开发！请与作者彭东南联系：southeastofstar@163.com\r\n                                                                版权所有： 彭东南","非法操作",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return null;
                }

            string InstructionsForSearchingPCNames = "";
            //bool ChineseLanguage = false;

            //定义变量存储文件名
            string BATFileNameForGetPCNames = "C:\\Windows\\Temp\\SearchPCNames.bat";
            string TXTFileNameForSavePCNames = "C:\\Windows\\Temp\\GotPCNames.txt";

            //Int16 iMaxCountOfComputers = 100;
            string[] sAllPCNames;  //存储网络中实际存在的IP地址
            //Int16 iWaitTimeCount;    //定义最大等待时间，超时就退出扫描等待

            //******************************
            DateTime BeginTime, FinishTime;
            TimeSpan SpentTimeForSearching;

            FinishTime = DateTime.Now;
            BeginTime = DateTime.Now;
            //******************************

            //定义类用于操作计算机相关信息，类似于VB .NET中的my.computer
            Microsoft.VisualBasic.Devices.Computer pcFileSystem = new Microsoft.VisualBasic.Devices.Computer();

            try
                {

                //System.Net.NetworkInformation.TcpConnectionInformation xx;
                Microsoft.VisualBasic.Devices.Network TempNetwork = new Microsoft.VisualBasic.Devices.Network();

                //bool TempBool;
                //TempBool = TempNetwork.IsAvailable;

                if (TempNetwork.IsAvailable == false)
                    {
                    MessageBox.Show("This compueter has not connected to the network yet, please check the reason and retry.\r\n计算机未连接到网络，请检查原因后再尝试搜索.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return null;
                    }

                //1、清除目录下的原有BAT/TXT文件记录【如果存在的话】
                if (pcFileSystem.FileSystem.FileExists(BATFileNameForGetPCNames) == true)
                    {
                    pcFileSystem.FileSystem.DeleteFile(BATFileNameForGetPCNames);
                    }

                if (pcFileSystem.FileSystem.FileExists(TXTFileNameForSavePCNames) == true)
                    {
                    pcFileSystem.FileSystem.DeleteFile(TXTFileNameForSavePCNames);
                    }

                //**********************************
                //Tokens用于获取第n列的内容；
                //delims用于定义分隔符；
                //skip=n 忽略文本开头的前n行；
                //eol=c  忽略以某字符开头的行；
                //**********************************
                
                //'以下为执行net view的结果：
                //'**************************
                //'服务器名称            注解

                //'-------------------------------------------------------------------------------
                //'\\2FP                  IQC                                                     
                //'\\CCD01                CCD                                             
                //'\\ED20150604NY                                                              
                //'\\ED20150907OQ                                                              
                //'\\ED20160414DH                                                              
                //'\\EDJK                                                                      
                //'\\EDFILE1                                                                   
                //'\\EDFILE2                                                                   
                //'\\EDERP                                                                      
                //'\\EDPRN              edacprn                                                 
                //'\\FD06                 仓库                                           
                //'\\FD07                 仓库                                           
                //'\\6T7CJF                                                              
                //'\\ID02                                                                         
                //'\\MD12                                                                         
                //'\\MD13                 MD                                              
                //'\\PL04                电控                                            
                //'\\PL06                电控                                             
                //'\\PL08                电控                                              
                //'\\RNPF11F8F                                                                    
                //'命令成功完成。
                //'**************************

               //'其它几种可能的情况：
               // '1、出现的内容为：列表是空的。【没有连接网络时】
               // '2、出现错误代码：6118【没有开启网络发现时】

               // '根据以上情况，正确的结果是：
               // '1、命令执行完后文件内容的行数必须大于4行及以上；
               // '2、行以\\开头

               // '处理方法：
               // '1、读取所有行到数组；
               // '2、导入内存后，去掉前两行和最后一行；
               // '3、跳过\\，找到字符串中第一个空格字符' '的位置,
               // '   取得从\\后的第一个字符到整个字符串中第一个空格字符的位置-1之间的字符串，即为计算机在网络中的名称；
               // '4、从第一个空格字符的位置到字符串整长，取得字符串，进行判断，如果全部为空格，则备注名为空；否则去掉前缀空格和后缀空格得到计算机的备注名；

               // '2、组织BAT命令
               // '将DOS的批处理命令写入文件BAT中

               // '>：批处理命令中的>是将内容导出到某文件或其它目标，并进行覆盖，比如：ECHO Done>C:\Example.txt,即将文字Done写入文件C:\Example.txt，如果原来存在此文件，则会覆盖
               // '>>：同样是导出内容，但是执行的是添加的动作，如果原来存在某文件或目标，则会在最后添加相应内容

               // '方法：在批处理文件的最后一句添加一条删除自身的语句，执行后就扫描此文件是否存在，如果不存在就读取保存的txt文件进行IP地址读取处理；

                InstructionsForSearchingPCNames = "@ECHO Off\r\nnet view>> " + TXTFileNameForSavePCNames + "\r\ndel " + BATFileNameForGetPCNames;

                //3、写入BAT命令至文件
                //保存的中文会乱码，不支持GB码
                //pcFileSystem.FileSystem.WriteAllText(BATFileNameForGetIPAddress, InstructionsForSearchingIPAddress, false, System.Text.Encoding.ASCII) //System.Text.Encoding.GetEncoding(936));

                //保存的中文不会乱码，但是在DOS环境下会乱码
                pcFileSystem.FileSystem.WriteAllText(BATFileNameForGetPCNames, InstructionsForSearchingPCNames, false);

                //4、执行BAT命令【隐藏DOS命令窗口】
                Microsoft.VisualBasic.Interaction.Shell(BATFileNameForGetPCNames, Microsoft.VisualBasic.AppWinStyle.Hide);
                //Microsoft.VisualBasic.Interaction.Shell(BATFileNameForGetIPAddress, Microsoft.VisualBasic.AppWinStyle.Hide,true,2000);

                //5、等待BAT命令完成
                 //方法二：在批处理文件的最后一句添加一条删除自身的语句，执行后就扫描此文件是否存在，如果不存在就读取保存的txt文件进行IP地址读取处理；
                
                Int16 iOverTimeCounter = 0;

                do
                    {

                    Thread.Sleep(1);
                    System.Windows.Forms.Application.DoEvents();
                    iOverTimeCounter += 1;
                    if (iOverTimeCounter >= 5000)
                        {

                        if (MessageBox.Show("It took a bit long time to search but haven't finished yet, are you sure to continue?\r\n已经花了比较长的时间进行搜索，但还没有完成，还要继续吗？",
                            "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                            {
                            iOverTimeCounter = 0;
                            }
                        else
                            {
                            return null;
                            }

                        }

                    } while (pcFileSystem.FileSystem.FileExists(BATFileNameForGetPCNames) == true);

                //6、判断是否已经联网，并处理没有网络就退出函数
                //如果记录IP地址的TXT文件不存在，则证明电脑没有和其它网络相连

                if (pcFileSystem.FileSystem.FileExists(TXTFileNameForSavePCNames) == false)
                    {
                    MessageBox.Show("Maybe you didn't run this program with the Administrator right, or there was an system error. Please check the reason and retry.\r\n你没有以管理员身份运行此程序或者已经引发了系统错误，请检查是否开启网络发现和其他原因后再尝试.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return null;
                    }

                //7、从文本文件读取记录进行处理
                //用File.ReadAllLines方法读取文件会执行关闭动作，会导致DOS BAT文件执行写入时出现异常

                //读取存储IP地址的文件
                sAllPCNames = System.IO.File.ReadAllLines(TXTFileNameForSavePCNames);

                //清除目录下的原有BAT/TXT文件记录【如果存在的话】
                if (pcFileSystem.FileSystem.FileExists(BATFileNameForGetPCNames) == true)
                    {
                    pcFileSystem.FileSystem.DeleteFile(BATFileNameForGetPCNames);
                    }

                if (pcFileSystem.FileSystem.FileExists(TXTFileNameForSavePCNames) == true)
                    {
                    pcFileSystem.FileSystem.DeleteFile(TXTFileNameForSavePCNames);
                    }

                //执行BAT文件时可能会出现权限不够无法执行或者执行中遇到错误的情况，导致保存执行结果的TXT文件为空，在此进行判断。

                if (sAllPCNames.Length == 0)
                    {
                    MessageBox.Show("Maybe you didn't run this program with the Administrator right, or there was an system error. Please check the reason and retry.\r\n你没有以管理员身份运行此程序或者已经引发了系统错误，请检查是否开启网络发现和其他原因后再尝试.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return null;
                    }

                //临时存储IP地址，按照最大的额度来定义
                string[] TempAllPCNames = new string[sAllPCNames.Length];

                //计算实际有效的计算机名称数组个数：去除空字符串，可能会有最后一个是回车换行符号
                Int16 ActaulNumberOfPCNames = 0;
                int TempLength = sAllPCNames.Length;

                for (int b = 0; b < TempLength; b++)
                    {

                    if ((sAllPCNames[b] != "") & (sAllPCNames[b] != "\r\n"))
                        {
                        TempAllPCNames[ActaulNumberOfPCNames] = sAllPCNames[b];
                        ActaulNumberOfPCNames += 1;
                        }
                    }

                //重新定义AllPCNames的长度，用于保存计算机名称数组
                sAllPCNames = new string[ActaulNumberOfPCNames];

                //将读取到的计算机名称复制到AllPCNames
                for (int b = 0; b < ActaulNumberOfPCNames; b++)
                    {
                    sAllPCNames[b] = TempAllPCNames[b];
                    }

                }
            catch (Exception ex)
                {
                //清除目录下的原有BAT/TXT文件记录【如果存在的话】
                if (pcFileSystem.FileSystem.FileExists(BATFileNameForGetPCNames) == true)
                    {
                    pcFileSystem.FileSystem.DeleteFile(BATFileNameForGetPCNames);
                    }

                if (pcFileSystem.FileSystem.FileExists(TXTFileNameForSavePCNames) == true)
                    {
                    pcFileSystem.FileSystem.DeleteFile(TXTFileNameForSavePCNames);
                    }
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
                }

            FinishTime = DateTime.Now;
            SpentTimeForSearching = FinishTime - BeginTime;

            if (sAllPCNames.Length == 1)
                {
                MessageBox.Show("There is " + sAllPCNames.Length + " available PC in the network, the searching spent: " + 
                  SpentTimeForSearching.Minutes + "m" + SpentTimeForSearching.Seconds + "s" + SpentTimeForSearching.Milliseconds + "ms" 
                  + "\r\n总计搜索到 " + sAllPCNames.Length + " 个PC， 耗时：" + SpentTimeForSearching.Minutes + "分" +
                  SpentTimeForSearching.Seconds + "秒" + SpentTimeForSearching.Milliseconds + "毫秒","Information",
                  MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            else 
                {
                  MessageBox.Show("There are " + sAllPCNames.Length + " available PCs in the network, the searching spent: " + 
                  SpentTimeForSearching.Minutes + "m" + SpentTimeForSearching.Seconds + "s" + SpentTimeForSearching.Milliseconds + "ms" 
                  + "\r\n总计搜索到 " + sAllPCNames.Length + " 个PC， 耗时：" + SpentTimeForSearching.Minutes + "分" +
                  SpentTimeForSearching.Seconds + "秒" + SpentTimeForSearching.Milliseconds + "毫秒","Information",
                  MessageBoxButtons.OK,MessageBoxIcon.Information);
                }

            //返回获取的计算机名称数组
            return sAllPCNames;

            }
        
        #endregion

        }//Class

    }//Namespace
