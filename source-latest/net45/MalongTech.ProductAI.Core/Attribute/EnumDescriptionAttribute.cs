﻿using System;

namespace MalongTech.ProductAI.Core
{
    [AttributeUsage(AttributeTargets.Field)]
    internal class EnumDescriptionAttribute : Attribute
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