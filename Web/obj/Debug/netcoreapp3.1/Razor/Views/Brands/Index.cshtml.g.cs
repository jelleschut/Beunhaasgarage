#pragma checksum "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Brands\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "239834766d9eb18a51f6d69b12d0ebe654ac1d77"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Brands_Index), @"mvc.1.0.view", @"/Views/Brands/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"239834766d9eb18a51f6d69b12d0ebe654ac1d77", @"/Views/Brands/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae3211996784a65c9fa1ff826bb54959fd1a4755", @"/Views/_ViewImports.cshtml")]
    public class Views_Brands_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Core.Models.Model>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "~/Views/Partial/Search/_Partial_Index_Search.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-light font-weight-bold"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Brands\Index.cshtml"
  
    ViewData["Title"] = "Brands";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Brands</h1>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "239834766d9eb18a51f6d69b12d0ebe654ac1d774590", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<table class=\"table table-striped table-hover table-sm\">\r\n    <thead class=\"thead-dark\">\r\n        <tr class=\"d-flex\">\r\n            <th class=\"col-2\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "239834766d9eb18a51f6d69b12d0ebe654ac1d775893", async() => {
#nullable restore
#line 15 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Brands\Index.cshtml"
                                                                                                                  Write(Html.DisplayNameFor(model => model.Brand.Name));

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-order", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 15 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Brands\Index.cshtml"
                                                                               WriteLiteral(ViewData["BrandSortParm"]);

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
            WriteLiteral("\r\n            </th>\r\n            <th class=\"col-10\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "239834766d9eb18a51f6d69b12d0ebe654ac1d778613", async() => {
#nullable restore
#line 18 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Brands\Index.cshtml"
                                                                                                                  Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-order", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 18 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Brands\Index.cshtml"
                                                                               WriteLiteral(ViewData["ModelSortParm"]);

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
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody class=\"border\">\r\n");
#nullable restore
#line 23 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Brands\Index.cshtml"
         foreach (var item in Model.Select(m => m.Brand).Distinct())
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr class=\"d-flex\">\r\n                <td");
            BeginWriteAttribute("id", " id=\"", 928, "\"", 941, 1);
#nullable restore
#line 26 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Brands\Index.cshtml"
WriteAttributeValue("", 933, item.Id, 933, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"col-12\">\r\n                    <span>");
#nullable restore
#line 27 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Brands\Index.cshtml"
                     Write(Html.ActionLink(item.Name, "Edit", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    <div class=\"float-right\">\r\n                        <button");
            BeginWriteAttribute("id", " id=\"", 1130, "\"", 1155, 2);
#nullable restore
#line 29 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Brands\Index.cshtml"
WriteAttributeValue("", 1135, item.Name, 1135, 10, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1145, "-edit-link", 1145, 10, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"edit-btn btn btn-sm btn-link\">Edit</button>\r\n                    </div>\r\n                    <div class=\"input-group input-group-sm d-none\">\r\n                        <input type=\"text\"");
            BeginWriteAttribute("value", " value=\"", 1348, "\"", 1366, 1);
#nullable restore
#line 32 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Brands\Index.cshtml"
WriteAttributeValue("", 1356, item.Name, 1356, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <div class=\"input-group-append\">\r\n                            <button");
            BeginWriteAttribute("id", " id=\"", 1463, "\"", 1487, 2);
            WriteAttributeValue("", 1468, "save-btn-", 1468, 9, true);
#nullable restore
#line 34 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Brands\Index.cshtml"
WriteAttributeValue("", 1477, item.Name, 1477, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("name", " name=\"", 1488, "\"", 1503, 1);
#nullable restore
#line 34 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Brands\Index.cshtml"
WriteAttributeValue("", 1495, item.Id, 1495, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-success save-btn-brand\" type=\"button\">Save</button>\r\n                        </div>\r\n                        <div class=\"input-group-append\">\r\n                            <button");
            BeginWriteAttribute("id", " id=\"", 1698, "\"", 1724, 2);
            WriteAttributeValue("", 1703, "cancel-btn-", 1703, 11, true);
#nullable restore
#line 37 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Brands\Index.cshtml"
WriteAttributeValue("", 1714, item.Name, 1714, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger cancel-btn\" type=\"button\">Cancel</button>\r\n                        </div>\r\n                    </div>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 42 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Brands\Index.cshtml"
             foreach (var item2 in Model.Where(m => m.Brand == item))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr class=\"d-flex\">\r\n                    <td class=\"offset-2 col-10\">\r\n                        <span");
            BeginWriteAttribute("id", " id=\"", 2095, "\"", 2109, 1);
#nullable restore
#line 46 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Brands\Index.cshtml"
WriteAttributeValue("", 2100, item2.Id, 2100, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 46 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Brands\Index.cshtml"
                                        Write(item2.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        <div class=\"float-right\">\r\n                            <button");
            BeginWriteAttribute("id", " id=\"", 2217, "\"", 2254, 4);
#nullable restore
#line 48 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Brands\Index.cshtml"
WriteAttributeValue("", 2222, item.Name, 2222, 10, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2232, "-", 2232, 1, true);
#nullable restore
#line 48 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Brands\Index.cshtml"
WriteAttributeValue("", 2233, item2.Name, 2233, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2244, "-edit-link", 2244, 10, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"edit-btn btn btn-sm btn-link\">Edit</button> |\r\n                            <button");
            BeginWriteAttribute("id", " id=\"", 2345, "\"", 2381, 4);
#nullable restore
#line 49 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Brands\Index.cshtml"
WriteAttributeValue("", 2350, item.Name, 2350, 10, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2360, "-", 2360, 1, true);
#nullable restore
#line 49 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Brands\Index.cshtml"
WriteAttributeValue("", 2361, item2.Name, 2361, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2372, "-add-link", 2372, 9, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"add-btn btn btn-sm btn-link\">Add</button>\r\n                        </div>\r\n                        <div class=\"input-group input-group-sm d-none\">\r\n                            <input type=\"text\"");
            BeginWriteAttribute("value", " value=\"", 2584, "\"", 2603, 1);
#nullable restore
#line 52 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Brands\Index.cshtml"
WriteAttributeValue("", 2592, item2.Name, 2592, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" >\r\n                            <div class=\"input-group-append\">\r\n                                <button");
            BeginWriteAttribute("id", " id=\"", 2709, "\"", 2745, 4);
            WriteAttributeValue("", 2714, "save-btn-", 2714, 9, true);
#nullable restore
#line 54 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Brands\Index.cshtml"
WriteAttributeValue("", 2723, item.Name, 2723, 10, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2733, "-", 2733, 1, true);
#nullable restore
#line 54 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Brands\Index.cshtml"
WriteAttributeValue("", 2734, item2.Name, 2734, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("name", " name=\"", 2746, "\"", 2762, 1);
#nullable restore
#line 54 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Brands\Index.cshtml"
WriteAttributeValue("", 2753, item2.Id, 2753, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-success save-btn-model\" type=\"button\">Save</button>\r\n                            </div>\r\n                            <div class=\"input-group-append\">\r\n                                <button");
            BeginWriteAttribute("id", " id=\"", 2969, "\"", 3007, 4);
            WriteAttributeValue("", 2974, "cancel-btn-", 2974, 11, true);
#nullable restore
#line 57 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Brands\Index.cshtml"
WriteAttributeValue("", 2985, item.Name, 2985, 10, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2995, "-", 2995, 1, true);
#nullable restore
#line 57 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Brands\Index.cshtml"
WriteAttributeValue("", 2996, item2.Name, 2996, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("name", " name=\"", 3008, "\"", 3024, 1);
#nullable restore
#line 57 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Brands\Index.cshtml"
WriteAttributeValue("", 3015, item2.Id, 3015, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger cancel-btn\" type=\"button\">Cancel</button>\r\n                            </div>\r\n                        </div>\r\n                        \r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 63 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Brands\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 63 "C:\Users\SCHUB05\Documents\InfoSupport\Projects\Blok1Opdracht\Beunhaasgarage\Web\Views\Brands\Index.cshtml"
             
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function() {

            $('.edit-btn').click(function() {
                $(this).parent().addClass('d-none');
                $(this).parent().prev().addClass('d-none');
                $(this).parent().next().removeClass('d-none');
                $(this).parent().next().select();
            });

            $('.save-btn-model').click(function () {
                let id = parseInt($(this).attr('name'));
                let modelName = $(this).attr('id').split('-')[3];

                $.ajax({
                    url: 'Api/ModelsApiEndpoint/' + id + '/' + modelName,
                    method: 'PUT',
                    data: name,
                    dataType: 'JSON',
                    contentType: 'application/json',
                    success: (data) => {
                        console.log('succes');
                        console.log(data);
                    },
                    error: (data) => {
                        cons");
                WriteLiteral(@"ole.log(data);
                    },
                });
                hideEdit(this);
            });

            $('.save-btn-brand').click(function () {
                let id = parseInt($(this).attr('name'));
                let name = $(this).attr('id').split('-')[2];
                let Brand = {
                    Id: id,
                    Name: name
                }

                $.ajax({
                    url: 'Api/BrandsApiEndpoint/' + id,
                    method: 'PUT',
                    data: JSON.stringify(Brand),
                    dataType: 'JSON',
                    contentType: 'application/json',
                    success: (data) => {
                        console.log('succes');
                        console.log(data);
                    },
                    error: (data) => {
                        console.log(data);
                    },
                });
                hideEdit(this);
            });

            $('.cancel-");
                WriteLiteral(@"btn').click(function() { hideEdit(this) });

            function hideEdit(element) {
                $(element).parent().parent().addClass('d-none');
                $(element).parent().parent().prev().removeClass('d-none');
                $(element).parent().parent().prev().prev().removeClass('d-none');
            };
        });
    </script>
");
            }
            );
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Core.Models.Model>> Html { get; private set; }
    }
}
#pragma warning restore 1591