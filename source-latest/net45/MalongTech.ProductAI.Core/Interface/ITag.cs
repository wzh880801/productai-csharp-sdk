using System;
using System.Collections.Generic;

namespace MalongTech.ProductAI.Core
{
    public interface ITag
    {
        ISearchTag Tag { get; set; }
    }

    public interface ISearchTag
    {
        void Add(ISearchTag andTag);

        void Add(string tagString);

        void Add(IList<string> tags);
    }
}