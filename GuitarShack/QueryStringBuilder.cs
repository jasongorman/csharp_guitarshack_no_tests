using System.Collections.Generic;

namespace GuitarShack
{
    public class QueryStringBuilder
    {
        public QueryStringBuilder(Dictionary<string, string> queryParams)
        {
            QueryParams = queryParams;
        }

        private Dictionary<string, string> QueryParams { get; }

        public string Build()
        {
            string queryString = "?";

            foreach (var key in QueryParams.Keys)
            {
                queryString += key + "=" + QueryParams[key] + "&";
            }

            return queryString;
        }
    }
}