#pragma checksum "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\Home\Panel.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "41ea051d53c0788f9170b06e0b5b112dc48c162a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Panel), @"mvc.1.0.view", @"/Views/Home/Panel.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"41ea051d53c0788f9170b06e0b5b112dc48c162a", @"/Views/Home/Panel.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b031b71028ef41b39af5ecb29363207f489a3272", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Panel : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("Coordinates"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ChangeCoordinates", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\Home\Panel.cshtml"
  
    ViewData["Title"] = "Panel";

#line default
#line hidden
#nullable disable
            WriteLiteral("<style>\r\n    .block {\r\n        min-height: 200px;\r\n    }\r\n</style>\r\n<div class=\"container\">\r\n    <div class=\"row block bg-dark\">\r\n        <div class=\"col-lg-12\">\r\n            ");
#nullable restore
#line 13 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\Home\Panel.cshtml"
       Write(DateTime.Now.TimeOfDay);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"row block bg-light\">\r\n        <div id=\"OffersInNeighborhoodElement\" class=\"col-lg-12\">\r\n");
            WriteLiteral("            ");
#nullable restore
#line 19 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\Home\Panel.cshtml"
       Write(await Component.InvokeAsync("OffersInNeighborhoodComponent"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n        </div>\r\n    </div>\r\n    <div class=\"row block bg-secondary\">\r\n        <div id=\"ScanBarCode\" class=\"col-lg-12\">\r\n\r\n            ");
#nullable restore
#line 26 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\Home\Panel.cshtml"
       Write(await Component.InvokeAsync("ScanBarCodeComponent"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

        </div>
    </div>
    <div class=""row block bg-dark"">
        <div class=""col-lg-12"">

        </div>
    </div>
    <div class=""row block bg-light"">
        <div class=""col-lg-12"">

        </div>
    </div>
    <div class=""row block bg-secondary"">
        <div class=""col-lg-12"">

        </div>
    </div>
    <div class=""row block bg-dark"">
        <div class=""col-lg-12"">

        </div>
    </div>
    <div class=""row block bg-light"">
        <div class=""col-lg-12"">

        </div>
    </div>
    <div class=""row block bg-primary"">
        <div class=""col-lg-12"">

        </div>
    </div>




</div>

<div>
    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "41ea051d53c0788f9170b06e0b5b112dc48c162a6907", async() => {
                WriteLiteral("\r\n        <input type=\"hidden\" id=\"Longitude\" />\r\n        <input type=\"hidden\" id=\"Latitude\" />\r\n\r\n\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>




        $(document).ready(function ()
        {

            Webcam.set({
                width: 320,
                height: 240,
                image_format: 'jpeg',
                jpeg_quality: 90
            });


            Webcam.attach('#LiveCamera');


            function CaptureSnapshot() {
                Webcam.snap(function (data) {
                    // display results in page
                    document.getElementById('results').innerHTML = '<img src=""' + data + '""/>';
                    // Send image data to the controller to store locally or in database
                    Webcam.upload(data,
                        '/BarCode/CaptureImage',
                        function (code, text) {

                            $('#BarcodeResult').empty();
                            $('#BarcodeResult').html(text);

                        });
                });
            }

            $('#ScanBarCode').on('click','#CaptureSnapshot', functio");
                WriteLiteral(@"n () {

                CaptureSnapshot();

            });




///

function SearchSpecialOffer()
    {
        var form = $('#Coordinates');
        var x = $(""#Latitude"").val();
        var y = $(""#Longitude"").val();
        //var token = $('input[name=""__RequestVerificationToken""]').val();
            $.ajax({
                url: '");
#nullable restore
#line 130 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\Home\Panel.cshtml"
                 Write(Url.Action("ChangeCoordinates", "Home"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
               type: ""post"",
                data: {
                    //__RequestVerificationToken: token,
                    Latitude:x /* $(""#Latitude"").val()*/,
                    Longitude:y /*$(""#Longitude"").val()*/
                },
                success: function (result) {


                }
            });
    }


    function SetCoordinates()
    {
        navigator.geolocation.getCurrentPosition(function (position) {
            let lat = position.coords.latitude;
            let long = position.coords.longitude;

           let x = lat.toFixed(2);
           let y = long.toFixed(2);


            //var form = $('#Coordinates');
        //var x = $(""#Latitude"").val();
        //var y = $(""#Longitude"").val();
        //var token = $('input[name=""__RequestVerificationToken""]').val();
            $.ajax({
                url: '");
#nullable restore
#line 160 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\Home\Panel.cshtml"
                 Write(Url.Action("ChangeCoordinates", "Home"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
               type: ""post"",
                data: {
                    //__RequestVerificationToken: token,
                    Latitude:x /* $(""#Latitude"").val()*/,
                    Longitude:y /*$(""#Longitude"").val()*/
                },
                success: function (result) {


                }
            });




        });
    }


    SetCoordinates();

    function SendCoordinates()
    {
        var form = $('#Coordinates');
        var x = $(""#Latitude"").val();
        var y = $(""#Longitude"").val();
        //var token = $('input[name=""__RequestVerificationToken""]').val();
            $.ajax({
                url: '");
#nullable restore
#line 189 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\Home\Panel.cshtml"
                 Write(Url.Action("ChangeCoordinates", "Home"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
               type: ""post"",
                data: {
                    //__RequestVerificationToken: token,
                    Latitude:x /* $(""#Latitude"").val()*/,
                    Longitude:y /*$(""#Longitude"").val()*/
                },
                success: function (result) {


                }
            });
    }


            SendCoordinates();


            $(""body"").on('click', ""#SearchProductByFoundBarCode"", function (e) {
               
                e.stopPropagation();
            //$('#ScanBarCode').on('click','#SearchProductByFoundBarCode', function (e) {

              

                var BarCode1 = $(""#BarcodeResult #BarCodeProductDS"").val();
                var BarCode= $('#BarCodeSearch').val(BarCode1);
                var priceDescription = $(""#priceDescription"").val();
                var PriceValue = $(""#PriceValue"").val();
                var ProductName = $(""#ProductName"").val();
                var CategoryName = $(""#CategoryName"").val(");
                WriteLiteral(@");
                var ShopName = $(""#ShopName"").val();
                var Distance = $(""#Distance"").val();
                var SortMethod = $(""#sortMethod"").val();
                var sortType = $(""#sortType"").val();
                var SpecialOffer = false;
                if ($('#SpecialOffer').is("":checked"")) {
                    var SpecialOffer = true;
                }


                  //var t = $(""input[name='__RequestVerificationToken']"").val();
            $.ajax({
                url: '");
#nullable restore
#line 232 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\Home\Panel.cshtml"
                 Write(Url.Action("OffersInNeighborhood", "SpecialOffer"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
               type: ""get"",
                data: {
                    priceDescription: priceDescription ,
                    PriceValue: PriceValue ,
                    ProductName: ProductName,
                    CategoryName: CategoryName,
                    ShopName: ShopName,
                    Distance: Distance,
                    sortMethod: SortMethod,
                    sortType: sortType,
                    BarCode: BarCode,
                    SpecialOffer:SpecialOffer
                },
                headers:
                {
                    //""RequestVerificationToken"": t
                },
                success: function (result) {

                    $('#OffersInNeighborhoodElement').empty();
                    $('#OffersInNeighborhoodElement').html(result);

                }
            });



            });



           










            $('#OffersInNeighborhoodElement').on('click', '#FiltrOffersInNeighborhood', funct");
                WriteLiteral(@"ion (e) {


                e.stopPropagation();

                var priceDescription = $(""#priceDescription"").val();
                var PriceValue = $(""#PriceValue"").val();
                var ProductName = $(""#ProductName"").val();
                var CategoryName = $(""#CategoryName"").val();
                var ShopName = $(""#ShopName"").val();
                var Distance = $(""#Distance"").val();
                var SortMethod = $(""#sortMethod"").val();
                var sortType = $(""#sortType"").val();
                var BarCode = $('#BarCodeSearch').val();
                var SpecialOffer = false;
                if ($('#SpecialOffer').is("":checked""))
                {               
                var SpecialOffer = true;
                }
               



                var t = $(""input[name='__RequestVerificationToken']"").val();
            $.ajax({
                url: '");
#nullable restore
#line 300 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\Home\Panel.cshtml"
                 Write(Url.Action("OffersInNeighborhood", "SpecialOffer"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
               type: ""get"",
                data: {
                    priceDescription: priceDescription ,
                    PriceValue: PriceValue ,
                    ProductName: ProductName,
                    CategoryName: CategoryName,
                    ShopName: ShopName,
                    Distance: Distance,
                    sortMethod: SortMethod,
                    sortType: sortType,
                    BarCode: BarCode,
                    SpecialOffer:SpecialOffer
                },
                headers:
                {
                    ""RequestVerificationToken"": t
                },
                success: function (result) {

                    $('#OffersInNeighborhoodElement').empty();
                    $('#OffersInNeighborhoodElement').html(result);

                }
            });



            });


  });





    </script>
");
            }
            );
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
