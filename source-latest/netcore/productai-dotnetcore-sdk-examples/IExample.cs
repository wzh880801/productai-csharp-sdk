using System;
using MalongTech.ProductAI.Core;

namespace MalongTech.ProductAI.Examples
{
    interface IExample
    {
        void Run(IWebClient client);
    }
}