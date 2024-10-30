using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Data.Helper
{
    public class QueryObject
    {
       public string? Title {get;set;} = null;
       public string? Contents {get;set;} = null;
       public string? Author{get;set;} = null;
       public string? Category {get;set;} = null;
       public int PageNumber {get;set;} = 1;
       public int PageSize {get;set;} = 10; 
    }
}