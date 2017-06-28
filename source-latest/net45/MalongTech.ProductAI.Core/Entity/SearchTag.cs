using System;
using System.Collections.Generic;

namespace MalongTech.ProductAI.Core
{
    public class SearchTag : ITag
    {
        public ISearchTag Tag { get; set; }

        public override string ToString()
        {
            return string.Format("{{{0}}}", Tag.ToString());
        }
    }

    public class AndTag : ISearchTag
    {
        private List<string> json = new List<string>();

        public void Add(ISearchTag tag)
        {
            json.Add(tag.ToString());
        }

        public void Add(string tagString)
        {
            json.Add(tagString);
        }

        public override string ToString()
        {
            var s = "\"and\":[";
            foreach(var _json in json)
            {
                if (!string.IsNullOrWhiteSpace(_json))
                {
                    if (_json.StartsWith("{"))
                    {
                        s += string.Format("{0},", _json);
                    }
                    else
                    {
                        s += string.Format("\"{0}\",", _json);
                    }
                }
            }
            s = s.TrimEnd(',');
            return s + "]";
        }
    }

    public class OrTag : ISearchTag
    {
        private List<string> json = new List<string>();

        public void Add(ISearchTag tag)
        {
            json.Add(tag.ToString());
        }

        public void Add(string tagString)
        {
            json.Add(tagString);
        }

        public override string ToString()
        {
            var s = "{\"or\":[";
            foreach (var _json in json)
            {
                if (!string.IsNullOrWhiteSpace(_json))
                {
                    if (_json.StartsWith("{"))
                    {
                        s += string.Format("{0},", _json);
                    }
                    else
                    {
                        s += string.Format("\"{0}\",", _json);
                    }
                }
            }
            s = s.TrimEnd(',');
            return s + "]}";
        }
    }
}