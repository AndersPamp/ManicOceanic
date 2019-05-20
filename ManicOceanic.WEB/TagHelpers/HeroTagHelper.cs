using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ManicOceanic.WEB.TagHelpers
{
    public class HeroTagHelper: TagHelper
    {
       
            public override void Process(TagHelperContext context, TagHelperOutput output)
            {
                output.TagName = "div";
                output.Attributes.SetAttribute("class", "hero");
            }
        
    }
}
