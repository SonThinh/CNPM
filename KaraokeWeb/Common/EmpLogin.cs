using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KaraokeWeb.Common
{
    [Serializable]
    public class EmpLogin
    {
        public int EmpId { get; set; }
        public string UserName { get; set; }


    }
}