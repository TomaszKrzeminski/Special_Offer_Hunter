#pragma checksum "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\Home\GetUserPicturePatch.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "788d2d530f8a9b7824de35c08c8c38c292f46bb2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_GetUserPicturePatch), @"mvc.1.0.view", @"/Views/Home/GetUserPicturePatch.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"788d2d530f8a9b7824de35c08c8c38c292f46bb2", @"/Views/Home/GetUserPicturePatch.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b031b71028ef41b39af5ecb29363207f489a3272", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_GetUserPicturePatch : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<string>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<img style=\"width: 640px; height: 480px;\"");
            BeginWriteAttribute("src", " src=", 56, "", 67, 1);
#nullable restore
#line 2 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\Home\GetUserPicturePatch.cshtml"
WriteAttributeValue("", 61, Model, 61, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 67, "\"", 73, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<string> Html { get; private set; }
    }
}
#pragma warning restore 1591
