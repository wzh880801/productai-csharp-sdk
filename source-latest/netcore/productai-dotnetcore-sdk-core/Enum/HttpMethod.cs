using System;

namespace MalongTech.ProductAI.Core
{
    public enum HttpMethod
    {
        [EnumDescription(Text = "GET")]
        GET,

        [EnumDescription(Text = "POST")]
        POST,

        [EnumDescription(Text = "PUT")]
        PUT,

        [EnumDescription(Text = "PATCH")]
        PATCH,

        [EnumDescription(Text = "DELETE")]
        DELETE
    }
}