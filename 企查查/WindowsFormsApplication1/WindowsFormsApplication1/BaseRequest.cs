using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class BaseRequest
    {
        //        state         M      返回码，状态:-1未登录,1失败,0成功
        //msg           M      返回结果描述
        //data          O      返回业务数据
        //obj           O      其他数据
        public ResultStateEnum state { get; set; }
        public string msg { get; set; }
        public string data { get; set; }
        public string obj { get; set; }
    }
}
