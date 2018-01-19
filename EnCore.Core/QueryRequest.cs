using System;
using System.Collections.Generic;
using System.Text;

namespace EnCore.Core
{
    public interface IQueryRequest
    {
        int Page { get; set; }
        int Per_page { get; set; }
        string Sort { get; set; }
        string Q { get; set; }
        //    Awe.Core.Model.KeyValuePair[] Query { get; }
        bool Count { get; set; }
        string[] Fields { get; set; }
        string[] Embed { get; set; }

        string SortBy { get; }
        bool IsSortAscending { get; }
    }


    public class QueryRequest : IQueryRequest
    {
        public int Page { get; set; }
        public int Per_page { get; set; }
        public string Sort { get; set; }
        public string Q { get; set; }

        //public KeyValuePair[] Query
        //{
        //    get
        //    {
        //        List<KeyValuePair> results = new List<KeyValuePair>();

        //        if (!string.IsNullOrWhiteSpace(Q))
        //        {
        //            string[] partsColunm = Q.Split('/');

        //            if (partsColunm.Length > 0)
        //            {
        //                foreach (var param in partsColunm)
        //                {
        //                    string[] parameters = param.Split(':');
        //                    if (parameters.Length == 2)
        //                        results.Add(new KeyValuePair(parameters[0], parameters[1]));
        //                }
        //            }
        //        }
        //        return results.ToArray();
        //    }
        //} //TODO:agregar posibilidad de filtrar por varios key   public string Keyword { get; set; }

        public bool Count { get; set; }
        public string[] Embed { get; set; } //TODO: modificar por una expresion para realizar incluir
        public string[] Fields { get; set; }
        public string SortBy
        {
            get
            {
                var value = Sort;
                if (!string.IsNullOrWhiteSpace(value))
                    value = value.Trim()
                                 .Replace("-", "")
                                 .Replace("+", "");

                return value;
            }
        }

        public bool IsSortAscending
        {
            get
            {
                return !(!string.IsNullOrWhiteSpace(Sort) && Sort[0] == '-');
            }
        }

    }
}
