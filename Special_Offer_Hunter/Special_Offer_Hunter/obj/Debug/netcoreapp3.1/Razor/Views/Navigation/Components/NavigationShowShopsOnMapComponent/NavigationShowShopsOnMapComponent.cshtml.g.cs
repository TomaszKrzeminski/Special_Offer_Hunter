#pragma checksum "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\Navigation\Components\NavigationShowShopsOnMapComponent\NavigationShowShopsOnMapComponent.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9e165dd1a75dc8952e07de0c045b40b773d34437"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Navigation_Components_NavigationShowShopsOnMapComponent_NavigationShowShopsOnMapComponent), @"mvc.1.0.view", @"/Views/Navigation/Components/NavigationShowShopsOnMapComponent/NavigationShowShopsOnMapComponent.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e165dd1a75dc8952e07de0c045b40b773d34437", @"/Views/Navigation/Components/NavigationShowShopsOnMapComponent/NavigationShowShopsOnMapComponent.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b031b71028ef41b39af5ecb29363207f489a3272", @"/Views/_ViewImports.cshtml")]
    public class Views_Navigation_Components_NavigationShowShopsOnMapComponent_NavigationShowShopsOnMapComponent : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductLocationViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/index.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/mobile-or-tablet.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<!DOCTYPE html>\r\n<html class=\'use-all-space\'>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9e165dd1a75dc8952e07de0c045b40b773d344375264", async() => {
                WriteLiteral(@"
    <meta http-equiv='X-UA-Compatible' content='IE=Edge' />
    <meta charset='UTF-8'>
    <title>Maps SDK for Web - Static route</title>
    <meta name='viewport'
          content='width=device-width,initial-scale=1,maximum-scale=1,user-scalable=no' />
    <link rel='stylesheet' type='text/css' href='https://api.tomtom.com/maps-sdk-for-web/cdn/5.x/5.69.1/maps/maps.css'>
    <link rel='stylesheet' type='text/css' href='https://api.tomtom.com/maps-sdk-for-web/cdn/5.x/5.69.1/maps/css-styles/routing.css' />
    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9e165dd1a75dc8952e07de0c045b40b773d344376043", async() => {
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
    </style>

");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9e165dd1a75dc8952e07de0c045b40b773d344378429", async() => {
                WriteLiteral("\r\n\r\n    <input id=\"myTomTomKey\" type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 1227, "\"", 1259, 1);
#nullable restore
#line 40 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\Navigation\Components\NavigationShowShopsOnMapComponent\NavigationShowShopsOnMapComponent.cshtml"
WriteAttributeValue("", 1235, ViewData["MyTomTomKey"], 1235, 24, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n    <input id=\"myPositionLat\" type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 1308, "\"", 1342, 1);
#nullable restore
#line 41 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\Navigation\Components\NavigationShowShopsOnMapComponent\NavigationShowShopsOnMapComponent.cshtml"
WriteAttributeValue("", 1316, ViewData["MyPositionLat"], 1316, 26, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n    <input id=\"myPositionLon\" type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 1391, "\"", 1425, 1);
#nullable restore
#line 42 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\Navigation\Components\NavigationShowShopsOnMapComponent\NavigationShowShopsOnMapComponent.cshtml"
WriteAttributeValue("", 1399, ViewData["MyPositionLon"], 1399, 26, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n    <input id=\"Shops2\" type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 1467, "\"", 1491, 1);
#nullable restore
#line 43 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\Navigation\Components\NavigationShowShopsOnMapComponent\NavigationShowShopsOnMapComponent.cshtml"
WriteAttributeValue("", 1475, Model.JsonShops, 1475, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" />



    <div id='map' class='map'></div>
    <script src='https://api.tomtom.com/maps-sdk-for-web/cdn/5.x/5.69.1/maps/maps-web.min.js'></script>
    <script src='https://api.tomtom.com/maps-sdk-for-web/cdn/5.x/5.69.1/services/services-web.min.js'></script>
    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9e165dd1a75dc8952e07de0c045b40b773d3443711167", async() => {
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
                WriteLiteral(@"
    <script>



        var myTomTomKey = document.getElementById('myTomTomKey').value;

        var myPLat = document.getElementById('myPositionLat').value;
        var myPLong = document.getElementById('myPositionLon').value;

        var HQ = { lat: myPLat, lng: myPLong }




        var map = tt.map({
            key: myTomTomKey,
            container: 'map',
            style: 'tomtom://vector/1/basic-main',
            dragPan: !isMobileOrTablet(),
            center: HQ,
            zoom: 10
        });
        map.addControl(new tt.FullscreenControl());
        map.addControl(new tt.NavigationControl());

        function createMarkerElement(type) {
            var element = document.createElement('div');
            var innerElement = document.createElement('div');

            element.className = 'route-marker';
            innerElement.className = 'icon tt-icon -white -' + type;
            element.appendChild(innerElement);
            return element;
        }");
                WriteLiteral(@"

        function addMarkers(feature) {
            var startPoint, endPoint;
            if (feature.geometry.type === 'MultiLineString') {
                startPoint = feature.geometry.coordinates[0][0]; //get first point from first line
                endPoint = feature.geometry.coordinates.slice(-1)[0].slice(-1)[0]; //get last point from last line
            } else {
                startPoint = feature.geometry.coordinates[0];
                endPoint = feature.geometry.coordinates.slice(-1)[0];
            }

            new tt.Marker({ element: createMarkerElement('start') }).setLngLat(startPoint).addTo(map);
            new tt.Marker({ element: createMarkerElement('finish') }).setLngLat(endPoint).addTo(map);
        }

        function findFirstBuildingLayerId() {
            var layers = map.getStyle().layers;
            for (var index in layers) {
                if (layers[index].type === 'fill-extrusion') {
                    return layers[index].id;
                }
   ");
                WriteLiteral(@"         }

            throw new Error('Map style does not contain any layer with fill-extrusion type.');
        }



        var Shops2 = document.getElementById('Shops2').value;
        var obj = JSON.parse(Shops2);


        function MakeLocationElements(obj) {

            var text = """";




            for (var i = 0; i < obj.length; i++) {
                var l1 = obj[i].center[0];
                var l2 = obj[i].center[1];
                text += l2 + "","" + l1 + "":"";
            }

            text = text.substring(0, text.length - 1);
            return text;
        }


        var locationsChanges = MakeLocationElements(obj);




        map.once('load', function () {
            tt.services.calculateRoute({
                key: myTomTomKey,
                traffic: false,
                locations: locationsChanges
            })
                .go()
                .then(function (response) {
                    var geojson = response.toGeoJson();
    ");
                WriteLiteral(@"                map.addLayer({
                        'id': 'route',
                        'type': 'line',
                        'source': {
                            'type': 'geojson',
                            'data': geojson
                        },
                        'paint': {
                            'line-color': '#4a90e2',
                            'line-width': 8
                        }
                    }, findFirstBuildingLayerId());

                    addMarkers(geojson.features[0]);

                    var bounds = new tt.LngLatBounds();
                    geojson.features[0].geometry.coordinates.forEach(function (point) {
                        bounds.extend(tt.LngLat.convert(point));
                    });
                    map.fitBounds(bounds, { duration: 0, padding: 50 });
                });
        });
    </script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductLocationViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
