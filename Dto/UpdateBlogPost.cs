using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Dto
{
    public class UpdateBlogPost
    {
        public string Title {get;set;} = string.Empty;
        public string Contents {get; set;} = string.Empty;
        public string Author {get;set;} = string.Empty;
        public string Category {get;set;} = string.Empty;
        public string[] Tags {get; set;}
        public DateTime UpdatedAt {get;set;} = DateTime.UtcNow;
    }
}