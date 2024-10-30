using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    [Table("Post")]
    public class Post
    {
        public int Id {get; set;}
        public string Title {get; set;} = string.Empty;
        public string Contents {get; set;} = string.Empty;
        public string Author {get;set;} = string.Empty;
        public string Category {get;set;} = string.Empty;
        public string[] Tags {get; set;}
        public DateTime CreatedAt {get;set;} = DateTime.UtcNow;
        public DateTime UpdatedAt {get; set;} = DateTime.UtcNow;

    }
}