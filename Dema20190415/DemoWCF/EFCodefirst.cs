using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Runtime.Serialization;

namespace DemoDB
{
    [DataContract]
    public class Photo
    {
        [DataMember]
        public int PhotoID { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
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
