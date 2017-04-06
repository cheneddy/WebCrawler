using CommonHelps;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Form1 d1 = new Form1();
            //d1.Show();


            ErrorLable.Text = "";
            var errtxt = "";
            HttpHelper htp = new HttpHelper();
            var item = new HttpItem() { };
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                ErrorLable.Text = "清输入账号密码！！！";
                return;
            }
            var user = new User() { userName = textBox2.Text, passWord = textBox1.Text };
            //item.Method = "POST";
            //item.ContentType = "";
            item.URL = "http://114.215.68.246:8080/madman-manager-web/user/login?userName={0}&passWord={1}".With(user.userName, user.passWord.GetMD5());
            //item.Postdata = Newtonsoft.Json.JsonConvert.SerializeObject(user, new JsonSerializerSettings() { DateFormatHandling = DateFormatHandling.IsoDateFormat });
            var req = htp.GetHtml(item);
            var result = req.Html.FromJson<BaseRequest>();
            switch (result.state)
            {
                case ResultStateEnum.未登录:
                    errtxt = "";
                    break;
                case ResultStateEnum.失败:
                    errtxt = "账号或密码错误";
                    break;
                case ResultStateEnum.成功:
                    this.Hide();
                    Form1 d = new Form1();
                    d.Show();
                    break;
                default:
                    break;
            }
            ErrorLable.Text = errtxt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //HttpHelper htp = new HttpHelper();
            //var item = new HttpItem() { };
            //var user = new Company() { companyName = "test1" };
            ////item.Method = "POST";
            ////item.ContentType = "";
            //var date = Newtonsoft.Json.JsonConvert.SerializeObject(user, new JsonSerializerSettings() { DateFormatHandling = DateFormatHandling.IsoDateFormat });
            //item.URL = "http://114.215.68.246:8080/madman-manager-web/companyBaseInfo/save?companyBaseInfo={0}".With(date);
            ////item.Postdata = Newtonsoft.Json.JsonConvert.SerializeObject(user, new JsonSerializerSettings() { DateFormatHandling = DateFormatHandling.IsoDateFormat });
            //var req = htp.GetHtml(item);
            //var result = req.Html.FromJson<BaseRequest>();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var dd = CookieHelper.GetCookies("www.qichacha.com");
            var cc = HttpContext.Current.Request.Cookies["PHPSESSID"].Value;

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            //1736879475-1488895238-%7C1489073515
            var host = "www.tianyancha.com";//,1490625286,1490626264,1490626894
            HttpWebRequest myReq =
            (HttpWebRequest)WebRequest.Create("http://www.tianyancha.com/tongji/%E4%B8%BE%E8%B4%A4.json?random=1490627539848");
            var cookie = new CookieContainer();
            cookie.Add(new Cookie("Hm_lpvt_e92c8d65d92d534b0fc290df538b4758", "1490627539", "/", host));
            cookie.Add(new Cookie("token", "800c566686334d2a93727a5a3d5ded8f", "/", host));
            cookie.Add(new Cookie("paaptp", "d16b90e0f90d3e21e95346311a7f4708930a4b1e45008a51dc15b1053338d", "/", host));
            cookie.Add(new Cookie("aliyungf_tc", "AQAAAKe4TnuiqQIACKX1chiEpSFijNvk", "/", host));//1490026390,1490625286,1490626264,1490626894
            cookie.Add(new Cookie("Hm_lvt_e92c8d65d92d534b0fc290df538b4758", "1490026390", "/", host));
            //cookie.Add(new Cookie("_umdata", ""));
            myReq.CookieContainer = cookie;

            HttpWebResponse response = (HttpWebResponse)myReq.GetResponse();
            // Get the stream associated with the response.
            Stream receiveStream = response.GetResponseStream();

            // Pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(readStream.ReadToEnd());
        }
    }
}
