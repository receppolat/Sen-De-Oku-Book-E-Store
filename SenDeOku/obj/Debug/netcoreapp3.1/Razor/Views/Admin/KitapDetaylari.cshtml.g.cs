#pragma checksum "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\KitapDetaylari.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "215d9c83afd4a60c6bef64cbb85b73ae0d498167"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_KitapDetaylari), @"mvc.1.0.view", @"/Views/Admin/KitapDetaylari.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"215d9c83afd4a60c6bef64cbb85b73ae0d498167", @"/Views/Admin/KitapDetaylari.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b853c2693020103458b52d8246f923ca3fd89014", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_KitapDetaylari : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SenDeOku.Entities.Book>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("300"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("400"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "KitapDuzenle", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("color:red"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "KitapIslemleri", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\KitapDetaylari.cshtml"
  
    Layout = "_LayoutAdmin";
    int id = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "215d9c83afd4a60c6bef64cbb85b73ae0d4981675116", async() => {
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <title>Kitap Detaylar??</title>\r\n");
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "215d9c83afd4a60c6bef64cbb85b73ae0d4981676185", async() => {
                WriteLiteral("\r\n    <div class=\"container \">\r\n        <div class=\"row\">\r\n            <div class=\"col-lg-8\">\r\n                <h2>");
#nullable restore
#line 19 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\KitapDetaylari.cshtml"
               Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
#nullable disable
                WriteLiteral(" | ");
#nullable restore
#line 19 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\KitapDetaylari.cshtml"
                                                       Write(Html.DisplayFor(model => model.Author.Name));

#line default
#line hidden
#nullable disable
                WriteLiteral("</h2>\r\n                <hr />\r\n                <dl class=\"row\">\r\n\r\n                    <dt class=\"col-sm-3\">\r\n                        Kitap ID:\r\n                    </dt>\r\n                    <dd class=\"col-sm-9\">\r\n                        ");
#nullable restore
#line 27 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\KitapDetaylari.cshtml"
                   Write(Html.DisplayFor(model => model.BookID));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 28 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\KitapDetaylari.cshtml"
                          
                            id = Model.BookID;
                        

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </dd>\r\n\r\n                    <dt class=\"col-sm-3\">\r\n                        ISBN:\r\n                    </dt>\r\n                    <dd class=\"col-sm-9\">\r\n                        ");
#nullable restore
#line 37 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\KitapDetaylari.cshtml"
                   Write(Html.DisplayFor(model => model.ISBN));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </dd>\r\n\r\n                    <dt class=\"col-sm-3\">\r\n                        Kitap?? Ad??:\r\n                    </dt>\r\n                    <dd class=\"col-sm-9\">\r\n                        ");
#nullable restore
#line 44 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\KitapDetaylari.cshtml"
                   Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </dd>\r\n\r\n                    <dt class=\"col-sm-3\">\r\n                        Dil:\r\n                    </dt>\r\n                    <dd class=\"col-sm-9\">\r\n                        ");
#nullable restore
#line 51 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\KitapDetaylari.cshtml"
                   Write(Html.DisplayFor(model => model.Language));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </dd>\r\n\r\n                    <dt class=\"col-sm-3\">\r\n                        Yazar Ad??:\r\n                    </dt>\r\n                    <dd class=\"col-sm-9\">\r\n                        ");
#nullable restore
#line 58 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\KitapDetaylari.cshtml"
                   Write(Html.DisplayFor(model => model.Author.Name));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </dd>\r\n\r\n\r\n                    <dt class=\"col-sm-3\">\r\n                        Yay??nevi Ad??:\r\n                    </dt>\r\n                    <dd class=\"col-sm-9\">\r\n                        ");
#nullable restore
#line 66 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\KitapDetaylari.cshtml"
                   Write(Html.DisplayFor(model => model.Publisher.Name));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </dd>\r\n\r\n                    <dt class=\"col-sm-3\">\r\n                        ??evirmen Ad??:\r\n                    </dt>\r\n                    <dd class=\"col-sm-9\">\r\n                        ");
#nullable restore
#line 73 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\KitapDetaylari.cshtml"
                   Write(Html.DisplayFor(model => model.Translater));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </dd>\r\n\r\n                    <dt class=\"col-sm-3\">\r\n                        Kategori Ad??:\r\n                    </dt>\r\n                    <dd class=\"col-sm-9\">\r\n                        ");
#nullable restore
#line 80 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\KitapDetaylari.cshtml"
                   Write(Html.DisplayFor(model => model.category.Name));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </dd>\r\n\r\n                    <dt class=\"col-md-3\">\r\n                        Sayfa Say??s??:\r\n                    </dt>\r\n                    <dd class=\"col-md-9\">\r\n                        ");
#nullable restore
#line 87 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\KitapDetaylari.cshtml"
                   Write(Html.DisplayFor(model => model.PageCount));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </dd>\r\n\r\n                    <dt class=\"col-sm-3\">\r\n                        A????klama:\r\n                    </dt>\r\n                    <dd class=\"col-sm-9\">\r\n                        ");
#nullable restore
#line 94 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\KitapDetaylari.cshtml"
                   Write(Html.DisplayFor(model => model.Information));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </dd>\r\n\r\n                    <dt class=\"col-sm-3\">\r\n                        Fiyat:\r\n                    </dt>\r\n                    <dd class=\"col-sm-9\">\r\n                        ");
#nullable restore
#line 101 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\KitapDetaylari.cshtml"
                   Write(Html.DisplayFor(model => model.Price));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </dd>\r\n\r\n                    <dt class=\"col-sm-3\">\r\n                        ??ndirim Oran??:\r\n                    </dt>\r\n                    <dd class=\"col-sm-9\">\r\n                        %");
#nullable restore
#line 108 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\KitapDetaylari.cshtml"
                    Write(Html.DisplayFor(model => model.Discount));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </dd>\r\n\r\n                    <dt class=\"col-sm-3\">\r\n                        Stok Miktar??:\r\n                    </dt>\r\n                    <dd class=\"col-sm-9\">\r\n                        ");
#nullable restore
#line 115 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\KitapDetaylari.cshtml"
                   Write(Html.DisplayFor(model => model.Count));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                    </dd>
                </dl>

            </div>

            <div class=""col-lg-4"">
                <br />
                <br />
                <br />

                <dt class=""col-sm-3"">
                    Foto??raf:
                </dt>
                <dd class=""col-sm-9"">
                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "215d9c83afd4a60c6bef64cbb85b73ae0d49816714114", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 4115, "~/mydoc/img/assets/books/", 4115, 25, true);
#nullable restore
#line 130 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\KitapDetaylari.cshtml"
AddHtmlAttributeValue("", 4140, Html.DisplayFor(model => model.Photo), 4140, 38, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                </dd>\r\n            </div>\r\n        </div>\r\n\r\n        <div>\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "215d9c83afd4a60c6bef64cbb85b73ae0d49816715972", async() => {
                    WriteLiteral("D??zenle &nbsp;&nbsp; &nbsp;&nbsp;");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 136 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\KitapDetaylari.cshtml"
                                           WriteLiteral(id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "215d9c83afd4a60c6bef64cbb85b73ae0d49816718341", async() => {
                    WriteLiteral("Geri D??n");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        </div>\r\n\r\n    </div>\r\n");
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
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SenDeOku.Entities.Book> Html { get; private set; }
    }
}
#pragma warning restore 1591
