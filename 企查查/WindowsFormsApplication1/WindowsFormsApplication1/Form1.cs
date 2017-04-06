using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AngleSharp;
using System.Net;
using System.IO;
using DocumentFormat;
using HtmlAgilityPack;
using System.Collections;
using Newtonsoft.Json;
using System.Threading;
using System.Text.RegularExpressions;
using System.Configuration;
using Entity;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public static readonly string host = "www.qichacha.com";
        public static readonly string searchurl = "http://www.qichacha.com/search?key=";
        public static int count = 0;
        public static string CommonSearchtxt = "";
        private DataTable m_GradeTable;
        //定义两种行样式
        private DataGridViewCellStyle m_RowStyleNormal;
        private DataGridViewCellStyle m_RowStyleAlternate;
        private List<Company> dic = new List<Company>();
        private string SearchMsg = "";//查询之后的提示信息
        private bool RegisterState = false;//是否注册
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.dgvGrade.AutoGenerateColumns = false;
            this.SetRowStyle();
            this.searchmsg.Text = "系统当前时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            this.timer1.Interval = 1000;
            this.timer1.Start();
        }
        static public string GetHtmlTian(string searchtxt = "举贤", string url = "http://www.tianyancha.com/search?key=举贤&checkFrom=searchBox")
        {
            //aliyungf_tc=AQAAAJbhxRmF7gYAph7e3ZEipxj79Pyj; 
            //TYCID=65bded3123d64248a94e81443d59838b;
            // tnet=221.222.30.166; RTYCID=15d744bb57b8438ca3b8e2953d8520e1; 
            // _pk_ref.1.e431=%5B%22%22%2C%22%22%2C1490969397%2C%22https%3A%2F%2Fwww.baidu.com%2Flink%3Furl%3DgZtRHAw67ngt8vBPcUg2cDFGwqYWzLwOMIEZm90Jn1fuZnhsqpJ_UATZpEJDWoWo%26wd%3D%26eqid%3D80773fd10003cea00000000258d92302%22%5D; 
            // Hm_lvt_e92c8d65d92d534b0fc290df538b4758=1490625286,1490626264,1490626894,1490967325; 
            // Hm_lpvt_e92c8d65d92d534b0fc290df538b4758=1490970158; 
            // _pk_id.1.e431=b16d50edcd0adc48.1490026390.4.1490970158.1490969397.; 
            // _pk_ses.1.e431=*; token=a0b65cf3955d4b43b3f684d6c64cebce; 
            // _utm=9d236070a29b4536b0eff306b2dfeb48; 
            // paaptp=6dc640e17cd8b6de40d7f90c509d789fc95221a74001b009c115b24bf2490
            //2314256522
            HttpWebRequest myReq =
            (HttpWebRequest)WebRequest.Create("http://qimingpian.com/page/detailcom.html?src=magic&ticket=北京络可英网络科技有限公司&id=a00e5db23a0be042e41e3b3b2e4d5229&p=Lockin%20China&wd=络可英");
            var cookie = new CookieContainer();
            cookie.Add(new Cookie("unionid", "oP3fkwEmXltchuxJ7A9dDoVwtNJ8", "/", host));
            cookie.Add(new Cookie("backindex", "search", "/", host));
            //cookie.Add(new Cookie("_umdata", ""));
            myReq.CookieContainer = cookie;
            HttpWebResponse response = (HttpWebResponse)myReq.GetResponse();
            // Get the stream associated with the response.
            Stream receiveStream = response.GetResponseStream();

            // Pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);

            return readStream.ReadToEnd();
        }
        ///myReq.Host = "http://www.tianyancha.com";
        static public string GetHtml(string searchtxt = "举贤", string url = "http://www.qichacha.com/search?key=举贤")
        {
            //1736879475-1488895238-%7C1489073515
            HttpWebRequest myReq =
            (HttpWebRequest)WebRequest.Create(url);
            var cookie = new CookieContainer();
            cookie.Add(new Cookie("CNZZDATA1254842228", "1736879475-1488895238-%7C1489073515", "/", host));
            cookie.Add(new Cookie("gr_user_id", "a4cc88ae-cad6-477a-990d-8d5c0646c401", "/", host));
            cookie.Add(new Cookie("gr_session_id_9c1eb7420511f8b2", "a1180e36-2474-4aac-affe-557706df0c0e", "/", host));
            cookie.Add(new Cookie("_uab_collina", "148885724827196214353833", "/", host));
            cookie.Add(new Cookie("PHPSESSID", "pmsj77flaejh642aj8d70519c6", "/", host));
            //cookie.Add(new Cookie("_umdata", ""));
            myReq.CookieContainer = cookie;

            HttpWebResponse response = (HttpWebResponse)myReq.GetResponse();
            // Get the stream associated with the response.
            Stream receiveStream = response.GetResponseStream();

            // Pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);

            return readStream.ReadToEnd();
        }
        static List<string> statelist = new List<string>() { "存续", "停业", "在业" };
        /// <summary>
        /// 根据字符串组装企业对象
        /// </summary>
        /// <param name="alltext"></param>
        /// <returns></returns>
        public Company AssemblyCompany(HtmlNode alltext)
        {
            var node = alltext.InnerText.Split(new char[] { '\n' });
            Company newtab = new Company();
            //firm.*\bshtml
            Match m = Regex.Match(alltext.InnerHtml, @"firm.*\bshtml");
            if (m.Success)
            {
                newtab.CompanyUrl = m.Value;
            }

            foreach (var item in node)
            {
                if (item.IndexOf("企业法人") > -1)
                {
                    newtab.legalPerson = item;
                    continue;
                }
                if (item.IndexOf("联系方式") > -1)
                {
                    var phone = item.Replace("联系方式：", "");
                    var isphone = Regex.IsMatch(phone, @"^[1][3-8]\d{9}$");
                    if (isphone)
                    {
                        newtab.mobilePhone = "手机：" + phone;
                    }
                    else
                    {
                        newtab.mobilePhone = "座机：" + phone;
                    }

                    continue;
                }

                if (item.IndexOf("地址") > -1)
                {
                    newtab.Address = item;
                    continue;
                }
                if (item.IndexOf("公司") > -1)
                {
                    //System.Web.HttpUtility.HtmlEncode(
                    newtab.companyName = item.Trim();
                    continue;
                }
                if (newtab.companyName == null)
                {
                    newtab.companyName = node[0].Trim();
                    continue;
                }
                //Replace("万元", " ").Replace("万", " ")
                var other = item.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (other != null)
                {
                    foreach (var otheritem in other)
                    {
                        //品牌产品
                        if (otheritem.IndexOf("品牌") > -1 || otheritem.IndexOf("产品") > -1)
                        {
                            newtab.BrandNameProducts = otheritem;
                            continue;
                        }
                        //主要人员
                        if (otheritem.IndexOf("法人") > -1)
                        {
                            newtab.legalPerson = otheritem;
                            continue;
                        }
                        if (otheritem.IndexOf("主要人员") > -1)
                        {
                            newtab.KeyPersonnel = otheritem;
                            continue;
                        }
                        var num = 0.0;
                        Double.TryParse(otheritem, out num);
                        if (otheritem.IndexOf("商标") > -1)
                        {
                            newtab.Brand = otheritem;
                            continue;
                        }
                        if (otheritem.IndexOf("专利") > -1)
                        {
                            newtab.Patent = item;
                            continue;
                        }
                        if (num > 0)
                        {
                            newtab.registeredCapital = num.ToString() + "万元";
                            continue;
                        }
                        if (otheritem.IndexOf("万") > -1 || otheritem.IndexOf("元") > -1)
                        {
                            if (newtab.registeredCapital == null)
                            {
                                newtab.registeredCapital = otheritem;
                                continue;
                            }
                            if (newtab.registeredCapital.IndexOf("万") == -1 && newtab.registeredCapital.IndexOf("元") == -1)
                            {
                                newtab.registeredCapital = otheritem;
                                continue;
                            }

                        }
                        if (otheritem.IndexOf("-") > -1)
                        {
                            newtab.setupDate = otheritem;
                            continue;
                        }
                        if (statelist.Contains(otheritem))
                        {
                            newtab.operatingState = otheritem;
                            continue;
                        }
                    }
                }
            }
            newtab.AllText = alltext.InnerText;
            return newtab;
        }
        /// <summary>
        /// 获取跳转链接
        /// </summary>
        /// <param name="_doc"></param>
        /// <returns></returns>
        private IList<Company> GetHrefs(HtmlAgilityPack.HtmlDocument _doc)
        {
            var datalist = new List<Company>();
            //http://www.qichacha.com/company_getinfos?unique=d30ecbba46d507458d71ca263f0e06d0&companyname=%E4%B8%BE%E8%B4%A4%E7%BD%91%E7%A7%91%E6%8A%80%EF%BC%88%E5%8C%97%E4%BA%AC%EF%BC%89%E8%82%A1%E4%BB%BD%E6%9C%89%E9%99%90%E5%85%AC%E5%8F%B8&tab=base
            //http://www.qichacha.com/company_getinfos?unique=d30ecbba46d507458d71ca263f0e06d0&companyname=%E4%B8%BE%E8%B4%A4%E7%BD%91%E7%A7%91%E6%8A%80%EF%BC%88%E5%8C%97%E4%BA%AC%EF%BC%89%E8%82%A1%E4%BB%BD%E6%9C%89%E9%99%90%E5%85%AC%E5%8F%B8&tab=susong
            try
            {
                HtmlNodeCollection hrefs = _doc.DocumentNode.SelectNodes("//tbody/tr");
                //[starts-with(@class,'panel-body m_ahover')]
                HtmlNodeCollection hrefs2 = _doc.DocumentNode.SelectNodes("//a[@id='ajaxpage']");
                HtmlNodeCollection SearchMsgNode = _doc.DocumentNode.SelectNodes("//span[@id='countOld']");
                foreach (var item in SearchMsgNode)
                {
                    SearchMsg = item.InnerText; //countOld
                }

                //var ahref = _doc.DocumentNode.SelectNodes("//tbody/a");
                if (hrefs == null)

                    return null;
                //firm_d30ecbba46d507458d71ca263f0e06d0.shtml
                foreach (HtmlNode href in hrefs)
                {
                    datalist.Add(AssemblyCompany(href));
                }
                ///执行分页逻辑
                if (hrefs2 != null && hrefs2.Count > 0)
                {
                    var urltext = hrefs2[hrefs2.Count - 1].InnerText;
                    //>
                    if (urltext.IndexOf(">") > -1)
                    {
                        urltext = hrefs2[hrefs2.Count - 2].InnerText;
                    }
                    if (urltext.IndexOf(".") > -1)
                    {
                        count = Convert.ToInt32(urltext.Replace(".", ""));
                    }
                    //count = Convert.ToInt32(urltext.Replace(".", ""));
                    for (int i = 2; i <= count; i++)
                    {
                        var page = GetHtml("", "http://" + host + "/search_index?key=" + CommonSearchtxt + "&ajaxflag=1&p=" + i + "&");
                        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                        doc.LoadHtml(page);
                        HtmlNodeCollection detail = doc.DocumentNode.SelectNodes("//tbody/tr");

                        if (detail != null)
                        {
                            foreach (HtmlNode dt in detail)
                            {
                                datalist.Add(AssemblyCompany(dt));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;

            }
            //dic = datalist;
            //BindData();
            return datalist;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //%25E7%2599%25BE%25E5%25BA%25A6
            if (textBox1.Text == "")
            {
                return;
            }
            var searchurl = "http://www.qichacha.com/search_index?key={0}&ajaxflag=1{1}&";
            dgvGrade.DataSource = null;
            var query = "";
            if (radioButton1.Checked)
            {
                query = "&index=2";
            }
            if (radioButton2.Checked)
            {
                query = "&index=8";
            }
            var CommonSearchtxtList = textBox1.Text.Split(new char[] { ',' });
            foreach (var item in CommonSearchtxtList)
            {
                CommonSearchtxt = item;
                //searchurl + CommonSearchtxt
                string cnblogsHtml = GetHtml("", searchurl.With(CommonSearchtxt, query));
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();

                doc.LoadHtml(cnblogsHtml);
                //ThreadPool.QueueUserWorkItem(s =>
                //{
                //    dic = GetHrefs(doc);
                //});
                dic.AddRange(GetHrefs(doc));

            }

            if (dic != null)
            {
                //{ "企业名称", "企业法人", "联系方式", "地址", "注册资本", "注册日期", "营业状态" };
                SetRowStyle();
                BindData();
                //bindingSource1.DataSource = dic.ToList();
                //dataGridView1.DataSource = bindingSource1;
            }
            MessageBox.Show(SearchMsg.Replace("\n", ""));
            toolStripStatusLabel1.Text = SearchMsg.Replace("\n", "");
            //label2.Text = string.Concat("共检索到：", dic.Count, "条记录");
        }
        /// <summary>
        /// 设置行样式
        /// </summary>
        private void SetRowStyle()
        {
            //可根据需要设置更多样式属性，如字体、对齐、前景色、背景色等
            this.m_RowStyleNormal = new DataGridViewCellStyle();
            this.m_RowStyleNormal.BackColor = Color.LightBlue;
            this.m_RowStyleNormal.SelectionBackColor = Color.LightSteelBlue;

            this.m_RowStyleAlternate = new DataGridViewCellStyle();
            this.m_RowStyleAlternate.BackColor = Color.LightGray;
            this.m_RowStyleAlternate.SelectionBackColor = Color.LightSlateGray;
        }
        public void BindData()
        {
            var count_ = 0;
            m_GradeTable = new DataTable() { TableName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") };
            m_GradeTable.Columns.Add("序号", typeof(string));
            m_GradeTable.Columns.Add("企业名称", typeof(string));
            m_GradeTable.Columns.Add("企业法人", typeof(string));
            m_GradeTable.Columns.Add("联系方式", typeof(string));
            m_GradeTable.Columns.Add("地址", typeof(string));
            m_GradeTable.Columns.Add("注册资本", typeof(string));
            m_GradeTable.Columns.Add("注册日期", typeof(DateTime));
            m_GradeTable.Columns.Add("营业状态", typeof(string));
            m_GradeTable.Columns.Add("专利", typeof(string));
            m_GradeTable.Columns.Add("品牌产品", typeof(string));
            m_GradeTable.Columns.Add("商标", typeof(string));
            foreach (var item in dic)
            {
                count_++;
                //if (RegisterState == false && count_ > 50)
                //{
                //    break;
                //}
                m_GradeTable.Rows.Add(new string[] { count_.ToString(), item.companyName, item.legalPerson, item.mobilePhone, item.Address, item.registeredCapital, item.setupDate, item.operatingState, item.Patent, item.BrandNameProducts, item.Brand });
            }
            dgvGrade.DataSource = m_GradeTable;
            //this.bindingSource1.DataSource = m_GradeTable;
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.searchmsg.Text = "系统当前时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");

        }

        public void IsRegister()
        {
            string value = ConfigurationManager.AppSettings["token"];
            if (value != "")
            {
                RegisterState = true;
            }
            //string[] keys = ConfigurationManager.AppSettings.AllKeys;
            //for (int i = 0; i < keys.Length; i++)
            //{
            //    string key = keys[i];
            //    //通过Key来索引Value

            //    Console.WriteLine(i.ToString() + ". " + key + " = " + value);
            //}
        }
        private void 导出ExeclToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (RegisterState == false)
            //{
            //    return;
            //}
            var saveurl = "";
            StreamWriter myStream;
            saveFileDialog1.Filter = "Excel 文件(*.xlsx)|Excel 文件(*.xls)|*.xlsx|*.xls|所有文件(*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                myStream = new StreamWriter(saveFileDialog1.FileName);
                myStream.Write(saveurl); //写入
                myStream.Close();//关闭流
            }
            WriteExcel(m_GradeTable, saveFileDialog1.FileName);
        }
        public static void WriteExcel(DataTable dt, string filePath)
        {
            if (!string.IsNullOrEmpty(filePath) && null != dt && dt.Rows.Count > 0)
            {
                NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();

                NPOI.SS.UserModel.ISheet sheet = book.CreateSheet(dt.TableName);

                NPOI.SS.UserModel.IRow row = sheet.CreateRow(0);
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    row.CreateCell(i).SetCellValue(dt.Columns[i].ColumnName);
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    NPOI.SS.UserModel.IRow row2 = sheet.CreateRow(i + 1);
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        row2.CreateCell(j).SetCellValue(Convert.ToString(dt.Rows[i][j]));
                    }
                }
                // 写入到客户端  
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    book.Write(ms);
                    using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        byte[] data = ms.ToArray();
                        fs.Write(data, 0, data.Length);
                        fs.Flush();
                    }
                    book = null;
                }
            }
        }

        private void 联系我们ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var cont = new Contact();
            //cont.ShowDialog();
        }

        private void 注册ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Register d = new Register();
            //d.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            valid d = new valid();
            d._IsValid("78020");


        }

        private void button3_Click(object sender, EventArgs e)
        {
            var str = GetHtmlTian();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(str);
        }
    }
}
