using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleBlog.Core.Objects
{
    /// <summary>
    /// Yorum Tablosu
    /// </summary>
    public class Comment
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public int UserID { get; set; }
        public int ArticleID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual User User { get; set; }
        public virtual Article Article { get; set; }
    }
}
