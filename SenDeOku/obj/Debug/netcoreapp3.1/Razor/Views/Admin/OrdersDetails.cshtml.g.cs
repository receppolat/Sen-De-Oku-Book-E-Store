#pragma checksum "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\OrdersDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0c72c542b9a610476a92fcc76c8831fae064aea5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_OrdersDetails), @"mvc.1.0.view", @"/Views/Admin/OrdersDetails.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c72c542b9a610476a92fcc76c8831fae064aea5", @"/Views/Admin/OrdersDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b853c2693020103458b52d8246f923ca3fd89014", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_OrdersDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SenDeOku.Models.OrderDetails>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control mb-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ChangeReceiptDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("40"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("40"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\OrdersDetails.cshtml"
  
    Layout = "_LayoutAdmin";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container \">\r\n    <div class=\"row\">\r\n        <div class=\"col-lg-12\">\r\n            <br />\r\n            <br />\r\n            <br />\r\n");
#nullable restore
#line 13 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\OrdersDetails.cshtml"
             try
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div>\r\n                    <a style=\"color:black\">#<b>");
#nullable restore
#line 16 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\OrdersDetails.cshtml"
                                          Write(Model.Receipt.ReceiptID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></a> <a class=\"pull-right\" style=\"color:black\">");
#nullable restore
#line 16 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\OrdersDetails.cshtml"
                                                                                                                     Write(Model.Receipt.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </a><br /><br />\r\n                    <a style=\"color:black\"><b>Toplam Fiyat: </b>");
#nullable restore
#line 17 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\OrdersDetails.cshtml"
                                                           Write(Model.Receipt.TotalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(" TL</a><br /><br />\r\n                    <a style=\"color:black\"><b>Adres: </b>");
#nullable restore
#line 18 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\OrdersDetails.cshtml"
                                                    Write(Model.Customer[0].Adress);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a><br /><br />\r\n");
#nullable restore
#line 19 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\OrdersDetails.cshtml"
                     if (Model.Receipt.Details == "Sipari?? Al??nd??")
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0c72c542b9a610476a92fcc76c8831fae064aea57526", async() => {
                WriteLiteral("\r\n                            <input type=\"hidden\" value=\"1\" name=\"statusid\" />\r\n                            <input type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 968, "\"", 1000, 1);
#nullable restore
#line 23 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\OrdersDetails.cshtml"
WriteAttributeValue("", 976, Model.Receipt.ReceiptID, 976, 24, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"receiptid\"/>\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0c72c542b9a610476a92fcc76c8831fae064aea58356", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
#nullable restore
#line 24 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\OrdersDetails.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Shipper.ShipperID);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 24 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\OrdersDetails.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = Model.ShipperList;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            <button class=\"btn btn-primary\">Sipari??i kargola</button>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 27 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\OrdersDetails.cshtml"
                    }else if(Model.Receipt.Details == "Sipari?? Kargoda")
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0c72c542b9a610476a92fcc76c8831fae064aea512413", async() => {
                WriteLiteral("\r\n                            <input type=\"hidden\" value=\"2\" name=\"statusid\" />\r\n                            <input type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 1600, "\"", 1632, 1);
#nullable restore
#line 31 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\OrdersDetails.cshtml"
WriteAttributeValue("", 1608, Model.Receipt.ReceiptID, 1608, 24, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"receiptid\"/>\r\n                            <div style=\"color:black\"><b>Kargo Firmas??:</b>");
#nullable restore
#line 32 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\OrdersDetails.cshtml"
                                                                     Write(Model.Shipper.ShipperName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div><br />\r\n                            <button class=\"btn btn-primary\">Teslimat?? onayla</button>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 35 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\OrdersDetails.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div style=\"color:black\"><b>Kargo Firmas??:</b>");
#nullable restore
#line 38 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\OrdersDetails.cshtml"
                                                                 Write(Model.Shipper.ShipperName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div><br />\r\n");
#nullable restore
#line 39 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\OrdersDetails.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </div>
                <table class=""table"">
                    <thead>
                        <tr>
                            <th scope=""col"">
                                ISBN
                            </th>
                            <th scope=""col"">
                                Kitap Ad??
                            </th>
                            <th scope=""col"">
                                Yazar Ad??
                            </th>
                            <th scope=""col"">
                                Yay??n Evi Ad??
                            </th>
                            <th scope=""col"">
                                Adet
                            </th>
                            <th scope=""col"">
                                Foto??raf
                            </th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 65 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\OrdersDetails.cshtml"
                          for (int i = 0; i < Model.Books.Count; i++)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td scope=\"row\">\r\n                                        ");
#nullable restore
#line 69 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\OrdersDetails.cshtml"
                                   Write(Model.Books[i].ISBN);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 72 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\OrdersDetails.cshtml"
                                   Write(Model.Books[i].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 75 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\OrdersDetails.cshtml"
                                   Write(Model.Authors[i].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 78 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\OrdersDetails.cshtml"
                                   Write(Model.Publishers[i].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 81 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\OrdersDetails.cshtml"
                                   Write(Model.Orders[i].BookCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        <a>&nbsp;</a>\r\n                                        <a>&nbsp;</a>\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "0c72c542b9a610476a92fcc76c8831fae064aea519590", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 4144, "~/mydoc/img/assets/books/", 4144, 25, true);
#nullable restore
#line 86 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\OrdersDetails.cshtml"
AddHtmlAttributeValue("", 4169, Model.Books[i].Photo, 4169, 21, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 89 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\OrdersDetails.cshtml"
                            }
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n");
#nullable restore
#line 93 "C:\Users\DESKTOP\Desktop\SenDeOku\SenDeOku\Views\Admin\OrdersDetails.cshtml"
            }
            catch
            {

            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <br />\r\n            <br />\r\n            <br />\r\n            <br />\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SenDeOku.Models.OrderDetails> Html { get; private set; }
    }
}
#pragma warning restore 1591
