using System;
using System.Collections.Generic;
using System.Linq;

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
        private List<object> tags = new List<object>();

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
            var s = "\"and\":[";
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

    public class OrTag : ISearchTag
    {
        private List<object> tags = new List<object>();

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
            var s = "\"or\":[";
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
}