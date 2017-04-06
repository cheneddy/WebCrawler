using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QiChaCha
{
    using HtmlAgilityPack;
    using System.Text.RegularExpressions;
    public  class qichacha
    {
        static  List<string> statelist = new List<string>() { "存续", "停业", "在业" };//营业状态
        public static int count = 0;//用来存储数量
        private string searchUrl = string.Empty;//host 地址
        private string commonSearchtxt = string.Empty;//查询关键词
        public qichacha(string SearchUrl, string CommonSearchtxt)
        {
            this.searchUrl = SearchUrl;
            this.commonSearchtxt = CommonSearchtxt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_doc"></param>
        /// <param name="SearchMsg"></param>
        /// <returns></returns>
        private  IList<Company> GetHrefs(HtmlAgilityPack.HtmlDocument _doc, out string SearchMsg)
        {
            SearchMsg = "";
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
                        //var page =GetHtml("", searchUrl + "&ajaxflag=1&p=" + i + "&");
                        //HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                        //doc.LoadHtml(page);
                        //HtmlNodeCollection detail = doc.DocumentNode.SelectNodes("//tbody/tr");

                        //if (detail != null)
                        //{
                        //    foreach (HtmlNode dt in detail)
                        //    {
                        //        datalist.Add(AssemblyCompany(dt));
                        //    }
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                return null;

            }
            //BindData();
            return datalist;
        }
        /// <summary>
        /// 根据字符串组装企业对象
        /// </summary>
        /// <param name="alltext"></param>
        /// <returns></returns>
        public  Company AssemblyCompany(HtmlNode alltext)
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
    }
}
