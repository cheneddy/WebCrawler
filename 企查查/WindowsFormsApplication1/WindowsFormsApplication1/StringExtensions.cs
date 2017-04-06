using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;
using Newtonsoft.Json;
namespace WindowsFormsApplication1
{
    public static class StringExtensions
    {
        /// <summary>
        /// 获取截取后的字符串,英文占1个字节，中文占两个字节
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length">最多中文数</param>
        /// <returns></returns>
        public static string GetByteString(this string str, int length)
        {
            byte[] b = Encoding.Default.GetBytes(str);
            string newStr = str;
            if (b.Length > length * 2)
            {
                byte[] b1 = new byte[length * 2];
                for (int i = 0; i < length * 2; i++)
                {
                    b1[i] = b[i];
                }
                newStr = Encoding.Default.GetString(b1) + "...";
                if (newStr.Contains('?'))
                {
                    byte[] b2 = new byte[length * 2 - 1];
                    for (int i = 0; i < b1.Length - 1; i++)
                    {
                        b2[i] = b1[i];
                    }
                    newStr = Encoding.Default.GetString(b2) + "...";
                }
            }
            return newStr;
        }

        /// <summary>
        /// 判断字符串是否为null或者空
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
        /// <summary>
        /// 使用string.Format方式将字符串连接起来
        /// </summary>
        /// <param name="str"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string With(this string str, params object[] args)
        {
            return string.Format(str, args);
        }
        /// <summary>
        /// 拼接URL字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UrlSupply(this string str)
        {
            if (str.IndexOf("?") == -1) return str + "?";
            return str + "&";
        }
        /// <summary>
        /// 将字符串以MD5方式加密
        /// </summary>
        /// eddy 20150905
        /// 解决过期问题
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetMD5(this string str)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(str);
            bs = md5.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToUpper());
            }
            string password = s.ToString();
            return password;
            //return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
        }
        /// <summary>
        /// 将字符串以SHA1方式加密
        /// </summary>
        /// eddy 20150905
        /// 解决过期问题
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetSHA1(this string str)
        {
            System.Security.Cryptography.SHA1CryptoServiceProvider SHA1 = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(str);
            bs = SHA1.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToUpper());
            }
            string password = s.ToString();
            return password;
            //return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "SHA1");
        }
        /// <summary>
        /// 带有密钥的加解密
        /// 加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        //public static string KeyEncrypt(this string str)
        //{
        //    using (DESCryptoServiceProvider provider = new DESCryptoServiceProvider())
        //    {
        //        byte[] inputByteArray = Encoding.UTF8.GetBytes(str);
        //        provider.Key = ASCIIEncoding.ASCII.GetBytes(ComHelper.ComKey.Substring(0, ComHelper.ComKey.Length));
        //        provider.IV = ASCIIEncoding.ASCII.GetBytes(ComHelper.ComKey);

        //        MemoryStream ms = new MemoryStream();
        //        using (CryptoStream cs = new CryptoStream(ms, provider.CreateEncryptor(), CryptoStreamMode.Write))
        //        {
        //            cs.Write(inputByteArray, 0, inputByteArray.Length);
        //            cs.FlushFinalBlock();
        //            cs.Close();
        //        }
        //        string s = Convert.ToBase64String(ms.ToArray());
        //        ms.Close();
        //        return s;
        //    }
        //}
        /// <summary>
        /// 带有密钥的加解密
        /// 解密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        //public static string KeyDecrypt(this string str)
        //{
        //    byte[] inputByteArray = Convert.FromBase64String(str);
        //    using (DESCryptoServiceProvider provider = new DESCryptoServiceProvider())
        //    {

        //        provider.Key = ASCIIEncoding.ASCII.GetBytes(ComHelper.ComKey.Substring(0, 8));
        //        provider.IV = ASCIIEncoding.ASCII.GetBytes(ComHelper.ComKey);

        //        MemoryStream ms = new MemoryStream();
        //        using (CryptoStream cs = new CryptoStream(ms, provider.CreateDecryptor(), CryptoStreamMode.Write))
        //        {
        //            cs.Write(inputByteArray, 0, inputByteArray.Length);
        //            cs.FlushFinalBlock();
        //            cs.Close();
        //        }
        //        string s = Encoding.UTF8.GetString(ms.ToArray());
        //        ms.Close();
        //        return s;
        //    }
        //}
        /// <summary>
        /// 以Byte方式截取字符串长度
        /// 默认从0开始截取
        /// </summary>
        /// <param name="s"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string ByteSubstring(this string s, int length, string info)
        {
            if (length < ByteLength(s))
            {
                return s.ByteSubstring(0, length) + info;
            }
            return s.ByteSubstring(0, length);
        }
        public static int ByteLength(this string s)
        {
            byte[] bytes = System.Text.Encoding.Unicode.GetBytes(s);
            int n = 0, i = 0;
            for (; i < bytes.GetLength(0); i++)
            {
                if (i % 2 == 0) n++;
                else
                    if (bytes[i] > 0) n++;
            }
            return n;
        }
        /// <summary>
        /// 以Byte方式截取字符串长度
        /// 默认从0开始截取
        /// </summary>
        /// <param name="s"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string ByteSubstring(this string s, int length)
        {
            return s.ByteSubstring(0, length);
        }
        /// <summary>
        /// 以Byte方式截取字符串长度
        /// </summary>
        /// <param name="s"></param>
        /// <param name="startIndex">开始位置（从0开始）</param>
        /// <param name="length">要截取的长度</param>
        /// <returns></returns>
        public static string ByteSubstring(this string s, int startIndex, int length)
        {
            byte[] bytes = System.Text.Encoding.Unicode.GetBytes(s);
            int n = 0, i = 0;
            for (; i < bytes.GetLength(0) && n < length; i++)
            {
                if (i % 2 == 0) n++;
                else
                    if (bytes[i] > 0) n++;
            }
            if (i % 2 == 1)
            {
                if (bytes[i] > 0) i = i - 1;
                else i = i + 1;
            }
            return System.Text.Encoding.Unicode.GetString(bytes, startIndex, length == 0 ? bytes.GetLength(0) : i);
        }
        /// <summary>
        /// 将一个字符串反序列化为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="s"></param>
        /// <returns></returns>
        public static T FromJson<T>(this string s)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(s, new JsonSerializerSettings() { DateFormatHandling = DateFormatHandling.IsoDateFormat });
        }
        /// <summary>
        /// 将字符串序列化为json格式
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToJson(this string s)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(s, new JsonSerializerSettings() { DateFormatHandling = DateFormatHandling.IsoDateFormat });
        }
        public static string GetSafeString(this string s)
        {
            Regex r = new Regex(@"[^\u4e00-\u9fa5A-Za-z0-9]", RegexOptions.IgnoreCase);
            return r.Replace(s, "").Replace("/", "_").Replace(@"\", "_");
        }
        /// <summary>
        /// 将字符串转换为int类型，如果转换失败则返回0
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int ToInt(this string s)
        {
            int c = 0;
            if (!int.TryParse(s, out c))
            {
                c = 0;
            }
            return c;
        }
        /// <summary>
        /// 将字符串转换为int类型，如果转换失败则返回默认数字dNum
        /// </summary>
        /// <param name="s"></param>
        /// <param name="dNum">默认数字</param>
        /// <returns></returns>
        public static int ToInt(this string s, int dNum)
        {
            int c = 0;
            if (!int.TryParse(s, out c))
            {
                c = dNum;
            }
            return c;
        }
        /// <summary>
        /// 将字符串转换为long类型，如果转换失败则返回0
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static long ToLong(this string s)
        {
            long c = 0;
            if (!long.TryParse(s, out c))
            {
                c = 0;
            }
            return c;
        }
        /// <summary>
        /// 将字符串转换为long类型，如果转换失败则返回默认数字dNum
        /// </summary>
        /// <param name="s"></param>
        /// <param name="dNum">默认数字</param>
        /// <returns></returns>
        public static long ToLong(this string s, int dNum)
        {
            long c = 0;
            if (!long.TryParse(s, out c))
            {
                c = dNum;
            }
            return c;
        }
        /// <summary>
        /// 将字符串转换为Datetime类型，如果转换失败则返回1970年1月1日
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static DateTime ToDatetime(this string s)
        {
            DateTime d;
            if (!DateTime.TryParse(s, out d))
            {
                d = new DateTime(1970, 1, 1);
            }
            return d;
        }
        /// <summary>
        /// 将字符串转换为decimal类型，如果转换失败则返回0
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this string s)
        {
            decimal c = 0;
            if (!decimal.TryParse(s, out c))
            {
                c = 0;
            }
            return c;
        }

        /// <summary>
        /// 参数URL编码，同JS的encodeURIComponent
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string EscapeDataString(this string t)
        {
            return Uri.EscapeDataString(t);
        }

        /// <summary>
        /// 参数URL解码，同JS的decodeURIComponent
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string UnescapeDataString(this string t)
        {
            if (t.IsNullOrEmpty())
            {
                return "";
            }
            return Uri.UnescapeDataString(t);
        }

        /// <summary>
        /// URL Encode 编码
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        //public static string URLEncode(this string t)
        //{
        //    return HttpUtility.UrlEncode(t, Encoding.UTF8);
        //}

        /// <summary>
        /// URL Decode 解码
        /// </summary>
        /// <param name="pStr"></param>
        /// <returns></returns>
        //public static string URLDecode(this string t)
        //{
        //    return HttpUtility.UrlDecode(t, Encoding.UTF8);
        //}
        public static string ReplaceRegex(this string t, string Regex)
        {
            // Regex r = new Regex("<.*?>");
            Regex r = new Regex(Regex);
            return r.Replace(t, "");
        }
    }
}
