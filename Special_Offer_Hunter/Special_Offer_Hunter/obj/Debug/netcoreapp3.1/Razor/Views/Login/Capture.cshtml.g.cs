#pragma checksum "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Views\Login\Capture.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4a3f0c876168630a28f659bfc89d5b4778df06c9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Login_Capture), @"mvc.1.0.view", @"/Views/Login/Capture.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a3f0c876168630a28f659bfc89d5b4778df06c9", @"/Views/Login/Capture.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b031b71028ef41b39af5ecb29363207f489a3272", @"/Views/_ViewImports.cshtml")]
    public class Views_Login_Capture : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
            WriteLiteral(@"<div class=""col-md-2""></div>
<div class=""col-md-4"">
    <div class=""panel panel-default"">
        <div class=""panel-heading"">Camera</div>
        <div class=""panel-body"">
            <div id=""my_camera""></div>
            <!-- A button for taking snaps -->
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4a3f0c876168630a28f659bfc89d5b4778df06c93875", async() => {
                WriteLiteral("\r\n                <input type=\"button\" class=\"btn btn-success\" value=\"Take Snapshot\" onClick=\"take_snapshot()\">\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

        </div>
    </div>
</div>
<div class=""col-md-4"">
    <div class=""panel panel-default"">
        <div class=""panel-heading"">Captured Photo</div>
        <div class=""panel-body"">
            <div id=""results"">Your captured image will appear here...</div>
        </div>
        <br />
        <br />
    </div>
</div>



<script language=""JavaScript"">
    Webcam.set({
        width: 320,
        height: 240,
        image_format: 'jpeg',
        jpeg_quality: 90
    });
    Webcam.attach('#my_camera');
</script>
<!-- Code to handle taking the snapshot and displaying it locally -->
<script language=""JavaScript"">
    function take_snapshot() {
        // take snapshot and get image data
        Webcam.snap(function (data_uri) {
            // display results in page
            document.getElementById('results').innerHTML =
                '<img src=""' +
                data_uri +
                '""/>';

            Webcam.upload(data_uri,
                '/Camera/Capt");
            WriteLiteral("ure\',\r\n                function (code, text) {\r\n                    alert(\'Photo Captured\');\r\n                });\r\n\r\n        });\r\n    }\r\n</script>  ");
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