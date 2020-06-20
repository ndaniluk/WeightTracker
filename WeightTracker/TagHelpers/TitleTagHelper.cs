using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WeightTracker.TagHelpers
{
   // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
   [HtmlTargetElement("HelperTitle")]
   public class TitleTagHelper : TagHelper
   {
      public override void Process(TagHelperContext context, TagHelperOutput output)
      {
         output.TagName = "h3";
         output.PreContent.SetHtmlContent("<u>");
         output.PostContent.SetHtmlContent("</u>");
      }
   }
}
