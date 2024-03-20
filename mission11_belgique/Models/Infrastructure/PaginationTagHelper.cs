using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using mission11_belgique.Models.ViewModels;

namespace mission11_belgique.Models.Infrastructure
{
    // Defines a custom Tag Helper for pagination
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PaginationTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;
        
        // Constructor to initialize the IUrlHelperFactory
        public PaginationTagHelper(IUrlHelperFactory temp)
        {
            urlHelperFactory = temp;
        }

        // Properties for accessing ViewContext, PageAction, and PaginationInfo
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext? ViewContext { get; set; }
        public string? PageAction { get; set; }
        public PaginationInfo PageModel { get; set; }

        // Properties for handling CSS classes for pagination styling
        public bool PageClassEnabled { get; set; } = false;
        public string PageClass { get; set; } = string.Empty;
        public string PageClassNormal { get; set; } = string.Empty;
        public string PageClassSelected { get; set; } = string.Empty;

        // Method to process the Tag Helper and generate pagination links
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (ViewContext != null && PageModel != null)
            {
                // Get the URL helper
                IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
                TagBuilder result = new TagBuilder("div");

                // Generate pagination links based on TotalNumPages in PageModel
                for (int i = 1; i <= PageModel.TotalNumPages; i++)
                {
                    TagBuilder tag = new TagBuilder("a");
                    tag.Attributes["href"] = urlHelper.Action(PageAction, new { pageNum = i });

                    // Add CSS classes for styling if PageClassEnabled is true
                    if (PageClassEnabled)
                    {
                        tag.AddCssClass(PageClass);
                        tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                    }

                    tag.InnerHtml.Append(i.ToString());
                    result.InnerHtml.AppendHtml(tag);
                }

                // Append the generated pagination links to the output
                output.Content.AppendHtml(result.InnerHtml);
            }
        }
    }
}
