using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel_Blog.Model
{
    [Table("Posts")]
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
        public int TypeId { get; set; }
        public virtual Type Type { get; set; }
        public virtual ICollection<PostTags> PostTags { get; set; }
    }
}
