using System;

namespace MalongTech.ProductAI.Core
{
    [System.AttributeUsage(AttributeTargets.Field)]
    public class EnumDescriptionAttribute : Attribute
    {
        public string Text { get; set; }

        public EnumDescriptionAttribute()
            : base()
        {

        }

        public EnumDescriptionAttribute(string text)
            : this()
        {
            this.Text = text;
        }
    }
}