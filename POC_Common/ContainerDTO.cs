using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POC_Common
{
    public class ContainerDTO<T>
    {
        public List<T> list { get; set; }

        public int total { get; set; }
    }
}