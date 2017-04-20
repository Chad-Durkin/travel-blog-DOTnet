using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel_Blog.Model
{
    [Table("Tags")]
    public class Tag
    {
        [Key]
        public int TagId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<PostTags> PostTags { get; set; }

        public static List<Tag> MakeTags(List<string> tagList)
        {
            List<Tag> outputList = new List<Tag>();
            for (int i = 0; i < tagList.Count; i++)
            {
                Tag newTag = new Tag();
                newTag.Name = tagList[i];
                outputList.Add(newTag);
            }
            return outputList;
        }
    }

}
