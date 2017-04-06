using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using SKGL;

namespace WindowsFormsApplication1
{
    
    public class valid
    {
        public bool _IsValid(string key)
        {
            try
            {
                //1.创建key生成对象
                var CreateAKey = new Generate();
                //2.设置密钥
                CreateAKey.secretPhase = "78020";
                //3.生成key，30天时间限制
                var key1 = CreateAKey.doKey(30);
                //4.还可以设置机器码以及设置起始日期,机器码是1个5位Int数
                var key2 = CreateAKey.doKey(30, 78020);
              

                return true;
                //this.decodeKeyToString();
                //string str = this._res.Substring(0, 9);
                //string str2 = this._a.getEightByteHash(this._res.Substring(9, 0x13), 0x3b9aca00).ToString().Substring(0, 9);
                //return (str == str2);
            }
            catch (Exception ex)
            {
                return false;
            }
        }






    }
}
