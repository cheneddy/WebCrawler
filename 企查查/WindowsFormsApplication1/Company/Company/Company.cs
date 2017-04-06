using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Company
    {
        //{ "企业名称", "企业法人", "联系方式", "地址", "注册资本", "注册日期", "营业状态" };
        public string AllText { get; set; }
        /// <summary>
        /// 专利
        /// </summary>
        public string Patent { get; set; }
        /// <summary>
        /// 主要人员
        /// </summary>
        public string KeyPersonnel { get; set; }
        /// <summary>
        /// 企业详情地址
        /// </summary>
        public string CompanyUrl { get; set; }
        /// <summary>
        /// 企业名称
        /// </summary>
        public string companyName { set; get; }
        /// <summary>
        /// 品牌产品
        /// </summary>
        public string BrandNameProducts{get;set;}
        public string landline { get; set; }
        public string mobilePhone { get; set; }
        /// <summary>
        /// 座机
        /// </summary>
        public string Mobile { get;set;}
        public string Address { get; set; }
        /// <summary>
        /// 商标
        /// </summary>
        public string Brand { get; set; }
        /// <summary>
        /// 法人
        /// </summary>
        public string legalPerson { get; set; }
        public string operatingState { get; set; }

        public string setupDate { get; set; }
        /// <summary>
        /// 注册资本
        /// </summary>
        public string registeredCapital { get; set; }
    }
}
