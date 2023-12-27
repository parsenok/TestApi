using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestApi.DataSet
{
    public class DataSet
    {
        public List<User> Users { get; set; }
        public List<Posts> Posts { get; set; }
        public List<Comments> Comments { get; set; }
        public List<Sub> Sub { get; set; }
        public List<U_Subs> U_Subs { get; set; }
    }
}
