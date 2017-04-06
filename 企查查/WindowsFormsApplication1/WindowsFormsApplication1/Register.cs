using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
        // 取得设备硬盘的卷标号  
        public static string GetDiskVolumeSerialNumber()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid='D:'");
            disk.Get();
            return disk.GetPropertyValue("VolumeSerialNumber").ToString();
        }

        //获得CPU的序列号  
        public static string getCpu()
        {
            string strCpu = null;
            ManagementClass myCpu = new ManagementClass("win32_Processor");
            ManagementObjectCollection myCpuConnection = myCpu.GetInstances();
            foreach (ManagementObject myObject in myCpuConnection)
            {
                strCpu = myObject.Properties["Processorid"].Value.ToString();
                break;
            }
            return strCpu;
        }

        //生成机器码  
        public static string getMNum()
        {
            string strNum = getCpu() + GetDiskVolumeSerialNumber();//获得24位Cpu和硬盘序列号  
            string strMNum = strNum.Substring(0, 24);//从生成的字符串中取出前24个字符做为机器码  
            return strMNum;
        }
        public static int[] intCode = new int[127];//存储密钥  
        public static int[] intNumber = new int[25];//存机器码的Ascii值  
        public static char[] Charcode = new char[25];//存储机器码字  
        public static void setIntCode()//给数组赋值小于10的数  
        {
            for (int i = 1; i < intCode.Length; i++)
            {
                intCode[i] = i % 9;
            }
        }


        //生成注册码        
        public static string getRNum()
        {
            setIntCode();//初始化127位数组  
            for (int i = 1; i < Charcode.Length; i++)//把机器码存入数组中  
            {
                Charcode[i] = Convert.ToChar(getMNum().Substring(i - 1, 1));
            }
            for (int j = 1; j < intNumber.Length; j++)//把字符的ASCII值存入一个整数组中。  
            {
                intNumber[j] = intCode[Convert.ToInt32(Charcode[j])] + Convert.ToInt32(Charcode[j]);
            }
            string strAsciiName = "";//用于存储注册码  
            for (int j = 1; j < intNumber.Length; j++)
            {
                if (intNumber[j] >= 48 && intNumber[j] <= 57)//判断字符ASCII值是否0－9之间  
                {
                    strAsciiName += Convert.ToChar(intNumber[j]).ToString();
                }
                else if (intNumber[j] >= 65 && intNumber[j] <= 90)//判断字符ASCII值是否A－Z之间  
                {
                    strAsciiName += Convert.ToChar(intNumber[j]).ToString();
                }
                else if (intNumber[j] >= 97 && intNumber[j] <= 122)//判断字符ASCII值是否a－z之间  
                {
                    strAsciiName += Convert.ToChar(intNumber[j]).ToString();
                }
                else//判断字符ASCII值不在以上范围内  
                {
                    if (intNumber[j] > 122)//判断字符ASCII值是否大于z  
                    {
                        strAsciiName += Convert.ToChar(intNumber[j] - 10).ToString();
                    }
                    else
                    {
                        strAsciiName += Convert.ToChar(intNumber[j] - 9).ToString();
                    }
                }
            }
            return strAsciiName;
        }



        /// <summary>  
        /// 检测是否注册  
        /// </summary>  
        /// <returns></returns>  
        private bool CheckReg()
        {
            try
            {
                string str = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\mysoft", "ZhiShang", 0).ToString();
                if (string.IsNullOrEmpty(str) || (str != txtRNum.Text.Trim()))
                {
                    MessageBox.Show("本软件未经许可，不能使用！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                    MessageBox.Show("本软件已经注册，不需重复注册！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            catch
            {
                MessageBox.Show("本软件未经许可，不能使用！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private void btnGetInfo_Click_1(object sender, EventArgs e)
        {
            txtCPU.Text = getCpu();
            txtDisk.Text = GetDiskVolumeSerialNumber();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtMNum.Text = getMNum();
            txtRNum.Text = getRNum();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!CheckReg())
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\mysoft", "ZhiShang", txtRNum.Text.Trim(), RegistryValueKind.String);
                MessageBox.Show("注册成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CheckReg();
        }  
    }
}
