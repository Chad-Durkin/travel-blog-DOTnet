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

        public static List<string> ParseTags(string tagString)
        {
            List<string> TagList = new List<string>();
            string TagHolder = "";

            for(var i = 0; i < tagString.Length; i++)
            {
                if(tagString[i] != ',' && tagString[i] != ' ')
                {
                    TagHolder += tagString[i];
                } else
                {
                    if (tagString[i-1] != ',' && tagString[i - 1] != ' ')
                    {
                        TagHolder.ToLower();
                        TagList.Add(TagHolder);
                    }
                    TagHolder = "";
                }
            }
            TagList.Add(TagHolder);
            return TagList;
        }
    }
}
