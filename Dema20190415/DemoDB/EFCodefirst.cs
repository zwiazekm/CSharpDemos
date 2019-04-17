using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace DemoDB
{
    public class Photo
    {
        
        public int PhotoID { get; set; }
        public string Title { get; set; }
        public DateTime DateTaken { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; }
    }

    public class Comment
    {
        public int CommentID{ get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public virtual Photo Photo { get; set; }
    }

    public class PhotoContext: DbContext
    {
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
