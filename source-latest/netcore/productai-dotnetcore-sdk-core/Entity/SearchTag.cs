using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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

    public abstract class TagBase : ISearchTag
    {
        private string _operator = "and";

        private List<object> tags = new List<object>();  

        public TagBase(string _operator)
        {
            this._operator = _operator;
        }

        public void Add(ISearchTag tag)
        {
            tags.Add(tag);
        }

        public void Add(string tagString)
        {
            if (string.IsNullOrWhiteSpace(tagString))
                throw new ArgumentException(nameof(tagString));

            tags.Add(tagString);
        }

        public void Add(IList<string> tagList)
        {
            if (tagList != null)
                foreach (var tag in tagList.Where(p => !string.IsNullOrWhiteSpace(p)))
                    Add(tag);
        }

        public override string ToString()
        {
            var s = string.Format("\"{0}\":[", _operator);
            foreach (var tag in tags)
            {
                var _type = tag.GetType();
                if (_type == typeof(System.String))
                {
                    s += string.Format("\"{0}\",", tag);
                }
                else if (typeof(ISearchTag).IsAssignableFrom(_type))
                {
                    s += string.Format("{{{0}}},", tag.ToString());
                }
            }
            s = s.TrimEnd(',');
            return s + "]";
        }
    }

    public class AndTag : TagBase
    {
        public AndTag()
            : base("and")
        {

        }
    }

    public class OrTag : TagBase
    {
        public OrTag()
            : base("or")
        {

        }
    }
}