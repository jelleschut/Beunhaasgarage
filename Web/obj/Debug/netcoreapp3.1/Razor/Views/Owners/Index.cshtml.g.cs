#pragma checksum "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Owners\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3f9eae9091feacbf76cb9161101467544a8818aa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Owners_Index), @"mvc.1.0.view", @"/Views/Owners/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\_ViewImports.cshtml"
using Web.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f9eae9091feacbf76cb9161101467544a8818aa", @"/Views/Owners/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae3211996784a65c9fa1ff826bb54959fd1a4755", @"/Views/_ViewImports.cshtml")]
    public class Views_Owners_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Core.Models.Owner>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-light font-weight-bold"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Owners\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 7 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Owners\Index.cshtml"
Write(ViewData["Type"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n<div class=\"row\">\r\n    <div class=\"col-4\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f9eae9091feacbf76cb9161101467544a8818aa5641", async() => {
                WriteLiteral("\r\n            <input type=\"hidden\" name=\"type\"");
                BeginWriteAttribute("value", " value=\"", 248, "\"", 273, 1);
#nullable restore
#line 11 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Owners\Index.cshtml"
WriteAttributeValue("", 256, ViewData["Type"], 256, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("/>\r\n            <label for=\"search\" class=\"control-label\"><b>Search</b></label>\r\n            <div class=\"form-group input-group no-color\">\r\n                <input type=\"text\" class=\"form-control\" id=\"search\" name=\"search\"");
                BeginWriteAttribute("value", " value=\"", 495, "\"", 528, 1);
#nullable restore
#line 14 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Owners\Index.cshtml"
WriteAttributeValue("", 503, ViewData["SearchFilter"], 503, 25, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                <div class=\"input-group-append\">\r\n                    <button type=\"submit\" class=\"btn btn-info\">Search</button>\r\n                </div>\r\n            </div>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n    <div class=\"offset-7 col-1 mt-auto form-group\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f9eae9091feacbf76cb9161101467544a8818aa8661", async() => {
                WriteLiteral("New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n<table class=\"table table-striped table-hover table-sm\">\r\n    <thead class=\"thead-dark\">\r\n        <tr class=\"d-flex\">\r\n            <th class=\"col-2\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f9eae9091feacbf76cb9161101467544a8818aa10107", async() => {
#nullable restore
#line 30 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Owners\Index.cshtml"
                                                                                                                                                    Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-type", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 30 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Owners\Index.cshtml"
                                                                              WriteLiteral(ViewData["Type"]);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["type"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-type", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["type"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 30 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Owners\Index.cshtml"
                                                                                                                  WriteLiteral(ViewData["NameSortParm"]);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["order"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-order", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["order"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </th>\r\n            <th class=\"col-2\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f9eae9091feacbf76cb9161101467544a8818aa13666", async() => {
#nullable restore
#line 33 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Owners\Index.cshtml"
                                                                                                                                                    Write(Html.DisplayNameFor(model => model.City));

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-type", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 33 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Owners\Index.cshtml"
                                                                              WriteLiteral(ViewData["Type"]);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["type"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-type", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["type"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 33 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Owners\Index.cshtml"
                                                                                                                  WriteLiteral(ViewData["CitySortParm"]);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["order"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-order", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["order"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </th>\r\n            <th class=\"col-2\">\r\n                <div class=\"text-light font-weight-bold\">\r\n                    Address\r\n                </div>\r\n            </th>\r\n            <th class=\"col-2\">\r\n                ");
#nullable restore
#line 41 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Owners\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Zipcode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th class=\"col-2\">\r\n                <div class=\"text-light font-weight-bold\">\r\n                    ");
#nullable restore
#line 45 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Owners\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </th>\r\n            <th class=\"col-2\">\r\n                <div class=\"text-light font-weight-bold\">\r\n                    ");
#nullable restore
#line 50 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Owners\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </th>\r\n");
            WriteLiteral("        </tr>\r\n    </thead>\r\n    <tbody class=\"border\">\r\n");
#nullable restore
#line 57 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Owners\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr class=\"d-flex\">\r\n                <td class=\"col-2\">\r\n                    ");
#nullable restore
#line 61 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Owners\Index.cshtml"
               Write(Html.ActionLink(item.Name, "Details", new { id = item.OwnerId }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td class=\"col-2\">\r\n                    ");
#nullable restore
#line 64 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Owners\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.City));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td class=\"col-2\">\r\n                    ");
#nullable restore
#line 67 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Owners\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Street));

#line default
#line hidden
#nullable disable
            WriteLiteral("  ");
#nullable restore
#line 67 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Owners\Index.cshtml"
                                                           Write(Html.DisplayFor(modelItem => item.HouseNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td class=\"col-2\">\r\n                    ");
#nullable restore
#line 70 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Owners\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Zipcode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td class=\"col-2\">\r\n                    ");
#nullable restore
#line 73 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Owners\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td class=\"col-2\" style=\"word-wrap: break-word\">\r\n                    ");
#nullable restore
#line 76 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Owners\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 79 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Owners\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Core.Models.Owner>> Html { get; private set; }
    }
}
#pragma warning restore 1591
