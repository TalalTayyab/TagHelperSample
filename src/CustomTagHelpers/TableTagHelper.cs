using System;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using Microsoft.AspNet.Razor.TagHelpers;
using System.Text;
using Microsoft.AspNet.Routing;
using System.Linq;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Mvc.Rendering.Expressions;

namespace CustomTagHelpers
{
    [TagName("ctable")]
    [ContentBehavior(ContentBehavior.Replace)]
    public class TableTagHelper : TagHelper
    {
        private const string ItemsAttributeName = "asp-items";

        private const string ColumnsAttributeName = "asp-columns";

 
        [HtmlAttributeName(ItemsAttributeName)]
        public IEnumerable<object> Items { get; set; }


        [HtmlAttributeName(ColumnsAttributeName)]
        public string[] Columns { get; set; }

       

        [Activate]
        protected internal ViewContext ViewContext { get; set; }

        
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            if (Items == null || Columns == null)
                throw new InvalidOperationException("Please pass asp-items and asp-columns");

            StringBuilder content = new StringBuilder();
            output.TagName = "table";
            content.Append(GetColumnHeader());

            foreach (var item in Items)
            {
                content.Append(GetRow(item));
            }

            output.Content = content.ToString();
           
        }

        


        string GetColumnHeader()
        {
           
            RouteValueDictionary r = new RouteValueDictionary(Items.First());

            TagBuilder row = new TagBuilder("tr");

            StringBuilder tags = new StringBuilder();
            for (int i = 0; i < Columns.Length; i++)
            {
                TagBuilder hdr = new TagBuilder("th");
                hdr.SetInnerText(Columns[i]);
                tags.Append(hdr.ToString());
            }


            row.InnerHtml = tags.ToString();
            return row.ToString();
        }//GetColumnHeader

        string GetRow(object item)
        {
            RouteValueDictionary r = new RouteValueDictionary(item);
            TagBuilder row = new TagBuilder("tr");

            StringBuilder tags = new StringBuilder();
            for (int i = 0; i < Columns.Length; i++)
            {
                TagBuilder hdr = new TagBuilder("td");

                dynamic colValue = r[Columns[i]];

                string value = string.Empty;

                if (colValue != null)
                    value = colValue.ToString();


                hdr.SetInnerText(value);
                tags.Append(hdr.ToString());
            }

            row.InnerHtml = tags.ToString();
            return row.ToString();
        }//GetRow

    }
}