using System.Collections.Generic;

namespace TestTask.Repository.Models
{
    public class ModelForSearch
    {
        public ModelForSearch(int skip, int take, Dictionary<string, string> sort, string search)
        {
            Skip = skip;
            Take = take;
            Sort = sort;
            Search = search;
        }
        
        public int Skip { get; set; }
        
        public int Take { get; set; }
        
        public Dictionary<string,string> Sort { get; set; }
        
        public string Search { get; set; }
    }
}