#pragma checksum "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Areas\Identity\Pages\Account\Manage\Picture.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3e825830eb0dca123e5aeda0d8b220cbc690e820"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Identity_Pages_Account_Manage_Picture), @"mvc.1.0.razor-page", @"/Areas/Identity/Pages/Account/Manage/Picture.cshtml")]
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
#line 1 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Areas\Identity\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Areas\Identity\Pages\_ViewImports.cshtml"
using Special_Offer_Hunter.Areas.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Areas\Identity\Pages\_ViewImports.cshtml"
using Special_Offer_Hunter.Areas.Identity.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Areas\Identity\Pages\_ViewImports.cshtml"
using Special_Offer_Hunter.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Areas\Identity\Pages\Account\_ViewImports.cshtml"
using Special_Offer_Hunter.Areas.Identity.Pages.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Areas\Identity\Pages\Account\Manage\_ViewImports.cshtml"
using Special_Offer_Hunter.Areas.Identity.Pages.Account.Manage;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e825830eb0dca123e5aeda0d8b220cbc690e820", @"/Areas/Identity/Pages/Account/Manage/Picture.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"825f2220ae37620a5f352693bfc2e390c31c617c", @"/Areas/Identity/Pages/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"061cfa8c130093d3d2552087fb422a271c4038ce", @"/Areas/Identity/Pages/Account/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d4f374b3166d00246e529cb5c217c01702abc007", @"/Areas/Identity/Pages/Account/Manage/_ViewImports.cshtml")]
    public class Areas_Identity_Pages_Account_Manage_Picture : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("PictureAddForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Login", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ChangePicture", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_ValidationScriptsPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/webcamjs/webcam.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Areas\Identity\Pages\Account\Manage\Picture.cshtml"
  
    ViewData["Title"] = "Picture";
    ViewData["ActivePage"] = ManageNavPages.Picture;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>
</style>











<div class=""container"">
    <div class=""col col-lg-12"">
        <h3>Zmień swoje zdjęcie</h3>
    </div>
    <div class=""col col-lg-12"" id=""GetPicture"">
        <img style=""width: 640px;
        height: 480px;""");
            BeginWriteAttribute("src", " src=", 383, "", 414, 1);
#nullable restore
#line 27 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Areas\Identity\Pages\Account\Manage\Picture.cshtml"
WriteAttributeValue("", 388, Model.Input.UserPhotoPath, 388, 26, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 414, "\"", 420, 0);
            EndWriteAttribute();
            WriteLiteral(@">
    </div>
    <div class=""col col-lg-12"">



        <div class=""row"">
            <div class=""col-lg-12"">
                <div class=""panel panel-default col-lg-12"">
                    <div class=""row"">
                        <div class=""panel-body col-lg-12"">


                            <div class=""col-lg-12"" id=""my_camera""></div>

                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3e825830eb0dca123e5aeda0d8b220cbc690e8209089", async() => {
                WriteLiteral(@"
                                <input type=""button"" class=""btn btn-success"" value=""Zrób zdjęcie"" onClick=""take_snapshot()"">
                                <input id=""dialogOpen"" class=""btn btn-primary"" value=""Dodaj zdjęcie z dysku"" />
                                <input id=""RemovePicture"" class=""btn btn-danger"" value=""Usuń zdjęcie"" onClick=""remove_picture()"" />
                            ");
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
                <div class=""panel panel-default col-lg-12"">
                    <div class=""row"">
                        <div class=""panel-heading col-lg-12""></div>
                        <div class=""panel-body col-lg-12 "">

                            <div class=""col-lg-12"" id=""results"">Twoje zdjęcie pojawi się tutaj</div>



                        </div>
                        <div class=""col-lg-12"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3e825830eb0dca123e5aeda0d8b220cbc690e82011295", async() => {
                WriteLiteral("\r\n                                <div id=\"UserImagePath\">\r\n\r\n                                </div>\r\n");
                WriteLiteral("                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-returnUrl", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 65 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Areas\Identity\Pages\Account\Manage\Picture.cshtml"
                                           WriteLiteral(Model.ReturnUrl);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["returnUrl"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-returnUrl", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["returnUrl"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
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




            </div>


        </div>









    </div>
    <div class=""col col-lg-4""></div>
    <div class=""col col-lg-4""></div>

</div>




<div style=""display:none;"" id=""dialog"">


    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3e825830eb0dca123e5aeda0d8b220cbc690e82014311", async() => {
                WriteLiteral(@"
        <div>
            <div>
                <label>Dodaj Zdjęcie</label>
            </div>
            <div>
                <input title=""Musisz wybrać plik"" class=""required error"" id=""choose"" type=""file"" name=""file"" />

                <input id=""Upload"" style=""display:none"" ");
                WriteLiteral(" value=\"Upload\" />\r\n\r\n            </div>\r\n\r\n        </div>\r\n\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3e825830eb0dca123e5aeda0d8b220cbc690e82016839", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"

    <script src=""https://code.jquery.com/jquery-1.11.1.min.js""></script>

    <script src=""https://code.jquery.com/ui/1.11.1/jquery-ui.min.js""></script>

    <link rel=""stylesheet"" href=""https://code.jquery.com/ui/1.11.1/themes/smoothness/jquery-ui.css"" />

    <script>
        $(document).ready(function ()
        {




            function ReloadPicture() {


                var result = $('#UserImagePath input').val();

                 $.ajax({
                              url: '");
#nullable restore
#line 148 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Areas\Identity\Pages\Account\Manage\Picture.cshtml"
                               Write(Url.Action("GetUserPicturePatch", "Home"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
                              type: 'GET',
                              data: {Path:result},
                      success: function (result) {
                          $('#GetPicture').empty();
                          $('#GetPicture').html(result);


                      },
                              error: function (jqXHR) {
                                  alert(""Error"");
                      },
                      complete: function (jqXHR, status) {
                              }

                  });


            }










            //$('UserImagePath').on('change','#FileName', function () {

            //    alert(""change"");


            //    var result = $('#UserImagePath input');
            //    alert(result);



            //});


              function SavePicture()
        {





                  var formData = new FormData();
                  formData.append('file', $('#choose')[0].files[0]);


                  $.");
                WriteLiteral("ajax({\r\n                      url: \'");
#nullable restore
#line 202 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Areas\Identity\Pages\Account\Manage\Picture.cshtml"
                       Write(Url.Action("ChangePicture", "Login"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
                      type: 'POST',
                      data: formData,
                      processData: false,  // tell jQuery not to process the data
                      contentType: false,  // tell jQuery not to set contentType
                      success: function (result) {
                          var D = $('#dialog');
                          D.dialog(""close"");
                          $('#UserImagePath').empty();
                          $('#UserImagePath').html(result);
                          ReloadPicture();

                      },
                      error: function (jqXHR) {
                      },
                      complete: function (jqXHR, status) {







                      }
                  });


        }




            $(""#dialog"").dialog({
                autoOpen: false,
                draggable: false,
                resizable: false,
                width: 500,
                height: 400,
                modal: tr");
                WriteLiteral(@"ue,
                show: 'slideDown',
                hide: 'slideUp',
                dialogClass: ""no-close"",
                complete: function (code,text) {

                    //alert(""Complete"");
                    $('#UserImagePath').empty();
                    $('#UserImagePath').html(text);

                },
                buttons: [
                    {

                        text: ""Anuluj"",
                        click: function () {
                            $(this).dialog(""close"");
                        }


                    },
                    {

                        text: ""Potwierdź"",
                        click: function () {
                            //$(""#Upload"").click();

                            SavePicture();

                        }
                    }
                ]
            });


            $(""#dialogOpen"").click(function () {



                $(""#dialog"").dialog('open');
            });







");
                WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n        });\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n    </script>\r\n\r\n\r\n\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3e825830eb0dca123e5aeda0d8b220cbc690e82022563", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
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












         function ReloadPicture() {


                var result = $('#UserImagePath input').val();

                 $.ajax({
                              url: '");
#nullable restore
#line 341 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Areas\Identity\Pages\Account\Manage\Picture.cshtml"
                               Write(Url.Action("GetUserPicturePatch", "Home"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
                              type: 'GET',
                              data: {Path:result},
                      success: function (result) {
                          $('#GetPicture').empty();
                          $('#GetPicture').html(result);


                      },
                              error: function (jqXHR) {
                                  alert(""Error"");
                      },
                      complete: function (jqXHR, status) {
                              }

                  });


            }




        function remove_picture()
            {

                 //var result = $('#UserImagePath input').val();

                 $.ajax({
                              url: '");
#nullable restore
#line 370 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Areas\Identity\Pages\Account\Manage\Picture.cshtml"
                               Write(Url.Action("RemovePicture", "Login"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
                              type: 'Post',
                      success: function (result) {
                          $('#GetPicture').empty();
                          $('#GetPicture').html(result);


                           var Result = $('#UserImagePath input').val();

                 $.ajax({
                              url: '");
#nullable restore
#line 380 "C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\Areas\Identity\Pages\Account\Manage\Picture.cshtml"
                               Write(Url.Action("GetUserPicturePatch", "Home"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
                              type: 'GET',
                              data: {Path:result},
                      success: function (resultt) {
                          $('#GetPicture').empty();
                          $('#GetPicture').html(resultt);


                      },
                              error: function (jqXHR) {
                                  alert(""Error"");
                      },
                     complete: function (jqXHR, status) {




                              }

                  });



                      },
                              error: function (jqXHR) {
                                  alert(""Error"");
                      },
                      complete: function (jqXHR, status) {
                              }

                  });






            }

        function take_snapshot() {
            // take snapshot and get image data
            Webcam.snap(function (data_uri) {
                // displa");
                WriteLiteral(@"y results in page
                document.getElementById('results').innerHTML =
                    '<img src=""' +
                    data_uri +
                    '""/>';

                //Webcam.upload(data_uri,
                //    '/Login/Capture',
                //    function (code, text) {
                //        alert('Photo Captured');
                //    });

                Webcam.upload(data_uri,
                    '/Login/ChangeCapture',
                    function (code, text) {




                        $('#UserImagePath').empty();
                        $('#UserImagePath').html(text);

                        ReloadPicture();

                    });


            });
        }
    </script>


");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PictureModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<PictureModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<PictureModel>)PageContext?.ViewData;
        public PictureModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
