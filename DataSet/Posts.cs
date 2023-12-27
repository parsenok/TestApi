using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.DataSet
{
    public class Posts
    {
        public int Id { get; set; }
        public int comments_count { get; set; }
        public int comments_like { get; set; }
        public int comments_repost { get; set; }
        public string User { get; set; }
    }
}
