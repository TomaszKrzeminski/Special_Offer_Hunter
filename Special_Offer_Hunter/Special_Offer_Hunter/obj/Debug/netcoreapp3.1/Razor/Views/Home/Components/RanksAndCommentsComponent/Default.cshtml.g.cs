#pragma checksum "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\Home\Components\RanksAndCommentsComponent\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b39e4eb80ab834d2342c4777017946a119ec87d5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Components_RanksAndCommentsComponent_Default), @"mvc.1.0.view", @"/Views/Home/Components/RanksAndCommentsComponent/Default.cshtml")]
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
#line 1 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\_ViewImports.cshtml"
using Special_Offer_Hunter;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\_ViewImports.cshtml"
using Special_Offer_Hunter.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\_ViewImports.cshtml"
using Special_Offer_Hunter.Components;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b39e4eb80ab834d2342c4777017946a119ec87d5", @"/Views/Home/Components/RanksAndCommentsComponent/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b031b71028ef41b39af5ecb29363207f489a3272", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Components_RanksAndCommentsComponent_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ShopRanksAndCommentsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddRank", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Rank", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddComment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<style>
    .rating > input {
        display: none
    }

    .rating > label {
        position: relative;
        width: 19px;
        font-size: 25px;
        color: #ff0000;
        cursor: pointer
    }

        .rating > label::before {
            content: ""\2605"";
            position: absolute;
            opacity: 0
        }

        .rating > label:hover:before,
        .rating > label:hover ~ label:before {
            opacity: 1 !important
        }

    .rating > input:checked ~ label:before {
        opacity: 1
    }

    .rating:hover > input:checked ~ label:before {
        opacity: 0.4
    }

    .rating2 > input {
        display: none
    }

    .rating2 > label {
        position: relative;
        width: 19px;
        font-size: 25px;
        color: #ff0000;
        cursor: pointer
    }

        .rating2 > label::before {
            content: ""\2605"";
            position: absolute;
            opacity: 1
        }
</style>

<div cl");
            WriteLiteral("ass=\"row\">\r\n    <div class=\"col-lg-12\">\r\n        <h5>Ocena</h5>\r\n        <div class=\"rating2\">\r\n");
#nullable restore
#line 58 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\Home\Components\RanksAndCommentsComponent\Default.cshtml"
             for (int i = 0; i < Model.shopRank; i++)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <input type=\"radio\" name=\"rating\"");
            BeginWriteAttribute("value", " value=\"", 1277, "\"", 1291, 1);
#nullable restore
#line 60 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\Home\Components\RanksAndCommentsComponent\Default.cshtml"
WriteAttributeValue("", 1285, i+1, 1285, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 1292, "\"", 1303, 1);
#nullable restore
#line 60 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\Home\Components\RanksAndCommentsComponent\Default.cshtml"
WriteAttributeValue("", 1297, i+1, 1297, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><label");
            BeginWriteAttribute("for", " for=\"", 1311, "\"", 1323, 1);
#nullable restore
#line 60 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\Home\Components\RanksAndCommentsComponent\Default.cshtml"
WriteAttributeValue("", 1317, i+1, 1317, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">☆</label>\r\n");
#nullable restore
#line 61 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\Home\Components\RanksAndCommentsComponent\Default.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n        </div>\r\n\r\n    </div>\r\n    <div class=\"col-lg-12\">\r\n        <h5>Liczba Komentarzy </h5>\r\n        <div>\r\n            <h7>");
#nullable restore
#line 70 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\Home\Components\RanksAndCommentsComponent\Default.cshtml"
           Write(Model.shopComments);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h7>
        </div>
    </div>
    <div class=""col-lg-12"">


        <div class=""card"">
            <div class=""row"">
                <div class=""col-lg-2""> <img src=""https://i.imgur.com/xELPaag.jpg"" width=""70"" class=""rounded-circle mt-2""> </div>
                <div class=""col-lg-10"">
                    <div class=""comment-box ml-2"">
");
#nullable restore
#line 81 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\Home\Components\RanksAndCommentsComponent\Default.cshtml"
                         if (Model.Rank)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <h4>Oceń</h4>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b39e4eb80ab834d2342c4777017946a119ec87d59327", async() => {
                WriteLiteral("\r\n                                <input type=\"hidden\" id=\"RankShopId\"");
                BeginWriteAttribute("value", " value=\"", 2124, "\"", 2145, 1);
#nullable restore
#line 85 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\Home\Components\RanksAndCommentsComponent\Default.cshtml"
WriteAttributeValue("", 2132, Model.ShopId, 2132, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" />
                                <div class=""rating""> <input type=""radio"" name=""rating"" value=""5"" id=""5""><label for=""5"">☆</label> <input type=""radio"" name=""rating"" value=""4"" id=""4""><label for=""4"">☆</label> <input type=""radio"" name=""rating"" value=""3"" id=""3""><label for=""3"">☆</label> <input type=""radio"" name=""rating"" value=""2"" id=""2""><label for=""2"">☆</label> <input type=""radio"" name=""rating"" value=""1"" id=""1""><label for=""1"">☆</label> </div>
                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 88 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\Home\Components\RanksAndCommentsComponent\Default.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 89 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\Home\Components\RanksAndCommentsComponent\Default.cshtml"
                         if (Model.Comment)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b39e4eb80ab834d2342c4777017946a119ec87d512838", async() => {
                WriteLiteral(@"
                                <div class=""comment-area""> <textarea id=""CommentShopText"" class=""form-control"" placeholder=""what is your view?"" rows=""4""></textarea> </div>
                                <input id=""CommentShopId"" type=""hidden"" name=""ShopId""");
                BeginWriteAttribute("value", " value=\"", 3082, "\"", 3103, 1);
#nullable restore
#line 93 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\Home\Components\RanksAndCommentsComponent\Default.cshtml"
WriteAttributeValue("", 3090, Model.ShopId, 3090, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" />
                                <div class=""comment-btns mt-2""></div>
                                <div class=""row"">

                                    <div class=""col-lg-6"">
                                        <div class=""pull-right""> <input class=""btn btn-primary"" id=""AddShopComment"" value=""Dodaj"" /> </div>
                                    </div>
                                </div>
                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 102 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\Home\Components\RanksAndCommentsComponent\Default.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n\r\n\r\n\r\n\r\n</div>\r\n<div class=\"col-lg-12\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b39e4eb80ab834d2342c4777017946a119ec87d516321", async() => {
                WriteLiteral("\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n<div class=\"col-lg-12\">\r\n    <h3>Komentarze</h3>\r\n");
#nullable restore
#line 120 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\Home\Components\RanksAndCommentsComponent\Default.cshtml"
     if (Model.listOfComments != null && Model.listOfComments.Count() > 0)
    {
        foreach (var item in Model.listOfComments)
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"card\">\r\n                <div class=\"row\">\r\n");
            WriteLiteral("                  \r\n                    <div class=\"col-lg-3\"><h5> ");
#nullable restore
#line 129 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\Home\Components\RanksAndCommentsComponent\Default.cshtml"
                                          Write(item.ApplicationUser.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5> </div>\r\n                    <div class=\"col-lg-3\"> <h6>");
#nullable restore
#line 130 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\Home\Components\RanksAndCommentsComponent\Default.cshtml"
                                          Write(item.Time.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h6> </div>
                    <div class=""col-lg-6""> </div>
                    <div class=""col-lg-12"">
                        <div class=""comment-box ml-2"">

                            <div class=""comment-area text-justify""> <textarea class=""form-control"">");
#nullable restore
#line 135 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\Home\Components\RanksAndCommentsComponent\Default.cshtml"
                                                                                              Write(item.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</textarea> </div>
                            <div class=""comment-btns mt-2"">
                                <div class=""row"">

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
");
#nullable restore
#line 145 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\Home\Components\RanksAndCommentsComponent\Default.cshtml"


        }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ShopRanksAndCommentsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
