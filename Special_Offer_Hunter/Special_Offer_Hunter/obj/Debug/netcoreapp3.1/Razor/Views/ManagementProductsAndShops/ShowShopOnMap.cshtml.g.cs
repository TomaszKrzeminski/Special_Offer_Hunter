#pragma checksum "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\ManagementProductsAndShops\ShowShopOnMap.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1dac553063aa82e7d6661ae981bc54a20d8f7037"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ManagementProductsAndShops_ShowShopOnMap), @"mvc.1.0.view", @"/Views/ManagementProductsAndShops/ShowShopOnMap.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1dac553063aa82e7d6661ae981bc54a20d8f7037", @"/Views/ManagementProductsAndShops/ShowShopOnMap.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b031b71028ef41b39af5ecb29363207f489a3272", @"/Views/_ViewImports.cshtml")]
    public class Views_ManagementProductsAndShops_ShowShopOnMap : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ShopLocationViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/index.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/mobile-or-tablet.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/formatters.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<link rel=\'stylesheet\' type=\'text/css\' href=\'https://api.tomtom.com/maps-sdk-for-web/cdn/5.x/5.69.1/maps/maps.css\'>\r\n<link rel=\'stylesheet\' type=\'text/css\' href=\'https://api.tomtom.com/maps-sdk-for-web/cdn/5.x/5.69.1/maps/css-styles/routing.css\' />\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1dac553063aa82e7d6661ae981bc54a20d8f70375659", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<style>
    .icon {
        background-size: cover;
        height: 30px;
        width: 30px;
    }

    .route-marker {
        align-items: center;
        background-color: #4a90e2;
        border: solid 3px #2faaff;
        border-radius: 50%;
        display: flex;
        height: 32px;
        justify-content: center;
        transition: width .1s, height .1s;
        width: 32px;
    }


    .marker-icon {
        background-position: center;
        background-size: 22px 22px;
        border-radius: 50%;
        height: 22px;
        left: 4px;
        position: absolute;
        text-align: center;
        top: 3px;
        transform: rotate(45deg);
        width: 22px;
    }

    .marker {
        height: 30px;
        width: 30px;
    }

    .marker-content {
        background: #c30b82;
        border-radius: 50% 50% 50% 0;
        height: 30px;
        left: 50%;
        margin: -15px 0 0 -15px;
        position: absolute;
        top: 50%;
     ");
            WriteLiteral(@"   transform: rotate(-45deg);
        width: 30px;
    }

        .marker-content::before {
            background: #ffffff;
            border-radius: 50%;
            content: """";
            height: 24px;
            margin: 3px 0 0 3px;
            position: absolute;
            width: 24px;
        }
</style>




<input id=""Lat"" type=""hidden""");
            BeginWriteAttribute("value", " value=\"", 1724, "\"", 1732, 0);
            EndWriteAttribute();
            WriteLiteral("  />\r\n<input id=\"Lon\" type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 1768, "\"", 1776, 0);
            EndWriteAttribute();
            WriteLiteral("  />\r\n\r\n\r\n    <div class=\"row\">\r\n        <div class=\"col col-lg-12\">\r\n            <div id=\'map\' class=\'map\' style=\"min-height:320px; min-width:568px;\"></div>\r\n        </div>\r\n\r\n\r\n    </div>\r\n\r\n\r\n\r\n\r\n\r\n\r\n<input id=\"myTomTomKey\" type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 2017, "\"", 2049, 1);
#nullable restore
#line 89 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\ManagementProductsAndShops\ShowShopOnMap.cshtml"
WriteAttributeValue("", 2025, ViewData["MyTomTomKey"], 2025, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n<input id=\"myPositionLat\" type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 2094, "\"", 2128, 1);
#nullable restore
#line 90 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\ManagementProductsAndShops\ShowShopOnMap.cshtml"
WriteAttributeValue("", 2102, ViewData["MyPositionLat"], 2102, 26, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n<input id=\"myPositionLon\" type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 2173, "\"", 2207, 1);
#nullable restore
#line 91 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\ManagementProductsAndShops\ShowShopOnMap.cshtml"
WriteAttributeValue("", 2181, ViewData["MyPositionLon"], 2181, 26, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
            WriteLiteral("\r\n<script src=\'https://api.tomtom.com/maps-sdk-for-web/cdn/5.x/5.69.1/maps/maps-web.min.js\'></script>\r\n<script src=\'https://api.tomtom.com/maps-sdk-for-web/cdn/5.x/5.69.1/services/services-web.min.js\'></script>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1dac553063aa82e7d6661ae981bc54a20d8f703710526", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1dac553063aa82e7d6661ae981bc54a20d8f703711566", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            WriteLiteral(@"<script>


    ///// Map
    var myTomTomKey = document.getElementById('myTomTomKey').value;

    var myPLat = document.getElementById('myPositionLat').value;
    var myPLong = document.getElementById('myPositionLon').value;

    var center = { lat: myPLat, lng: myPLong }

    document.getElementById('Lat').value = myPLat;
    document.getElementById('Lon').value = myPLong;














    var roundLatLng = Formatters.roundLatLng;
    //var center = [4.890659, 52.373154];
    var popup = new tt.Popup({
        offset: 35
    });
    var map = tt.map({
        key: myTomTomKey,
        container: 'map',
        dragPan: !isMobileOrTablet(),
        center: center,
        zoom: 14
    });
    map.addControl(new tt.FullscreenControl());
    map.addControl(new tt.NavigationControl());

    var marker = new tt.Marker({
        draggable: true
    }).setLngLat(center).addTo(map);

    function onDragEnd() {
        var lngLat = marker.getLngLat();
        lngLat = ");
            WriteLiteral(@"new tt.LngLat(roundLatLng(lngLat.lng), roundLatLng(lngLat.lat));



        document.getElementById('Lat').value = lngLat.lng.toString();
        document.getElementById('Lon').value = lngLat.lat.toString();




        popup.setHTML(lngLat.toString());
        popup.setLngLat(lngLat);
        marker.setPopup(popup);
        marker.togglePopup();


      var button2=  document.getElementById('LocalizationD');
        button2.disabled = false;


    }







    marker.on('dragend', onDragEnd);






</script>





");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ShopLocationViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
