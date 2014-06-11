using RentaCar.Models;
using RentaCarEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace RentaCar.HtmlHelpers
{
    public static class PageHelpers
    {
        public static MvcHtmlString Pager(this HtmlHelper html, 
            string controller, string action, PagingInfo paging)
        {
            StringBuilder stringBuilder = new StringBuilder();

            int totalPage = (int)Math.Ceiling((decimal)paging.TotalItems/paging.ItemsPerPage);

            for (int i = 1; i <= totalPage; i++)
            {
                var tagBuilder = new TagBuilder("a");
                tagBuilder.MergeAttribute("href", string.Format("/{0}/{1}?page={2}&category={3}",
                    controller,action, i,paging.CurrentCategory));

                tagBuilder.InnerHtml = i.ToString();

                if (paging.CurrentPage == i)
                {
                    tagBuilder.AddCssClass("selected");
                }

                stringBuilder.Append(tagBuilder.ToString());
            }

            return MvcHtmlString.Create(stringBuilder.ToString());
        }

        public static MvcHtmlString Pager2(this HtmlHelper html, string param)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("<a href='/Product/GetProducts?page=5'>");
            builder.Append(param);
            builder.Append("</a>");

            return MvcHtmlString.Create(builder.ToString());
        }

      

            
        
    }
    }
