#pragma checksum "C:\Users\bure\Desktop\UTB\5. semestr\PWT\cviko\eshop\eshop\Areas\Customer\Views\CustomerOrders\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d0b441c1cee275b6af358cdc1c9d81930f307769"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Customer_Views_CustomerOrders_Index), @"mvc.1.0.view", @"/Areas/Customer/Views/CustomerOrders/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Customer/Views/CustomerOrders/Index.cshtml", typeof(AspNetCore.Areas_Customer_Views_CustomerOrders_Index))]
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
#line 1 "C:\Users\bure\Desktop\UTB\5. semestr\PWT\cviko\eshop\eshop\Areas\Customer\Views\_ViewImports.cshtml"
using eshop;

#line default
#line hidden
#line 2 "C:\Users\bure\Desktop\UTB\5. semestr\PWT\cviko\eshop\eshop\Areas\Customer\Views\_ViewImports.cshtml"
using eshop.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d0b441c1cee275b6af358cdc1c9d81930f307769", @"/Areas/Customer/Views/CustomerOrders/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a88d630971f609a38fbdea6b52651c4e9e57cc30", @"/Areas/Customer/Views/_ViewImports.cshtml")]
    public class Areas_Customer_Views_CustomerOrders_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IList<Order>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Details.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("include", "Development", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Details.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("exclude", "Development", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.EnvironmentTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\bure\Desktop\UTB\5. semestr\PWT\cviko\eshop\eshop\Areas\Customer\Views\CustomerOrders\Index.cshtml"
  
    ViewData["Title"] = "My Orders";

#line default
#line hidden
            BeginContext(67, 4, true);
            WriteLiteral("<h2>");
            EndContext();
            BeginContext(72, 17, false);
#line 5 "C:\Users\bure\Desktop\UTB\5. semestr\PWT\cviko\eshop\eshop\Areas\Customer\Views\CustomerOrders\Index.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(89, 11, true);
            WriteLiteral("</h2>\r\n<h3>");
            EndContext();
            BeginContext(101, 19, false);
#line 6 "C:\Users\bure\Desktop\UTB\5. semestr\PWT\cviko\eshop\eshop\Areas\Customer\Views\CustomerOrders\Index.cshtml"
Write(ViewData["Message"]);

#line default
#line hidden
            EndContext();
            BeginContext(120, 19, true);
            WriteLiteral("</h3>\r\n\r\n<br />\r\n\r\n");
            EndContext();
#line 10 "C:\Users\bure\Desktop\UTB\5. semestr\PWT\cviko\eshop\eshop\Areas\Customer\Views\CustomerOrders\Index.cshtml"
  
    if (Model != null && Model != null && Model.Count > 0)
    {
        foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(258, 163, true);
            WriteLiteral("            <table style=\"width:100%\" class=\"table table-responsive table-striped table-bordered\">\r\n                <tr>\r\n                    <th class=\"col-sm-1\">");
            EndContext();
            BeginContext(422, 16, false);
#line 17 "C:\Users\bure\Desktop\UTB\5. semestr\PWT\cviko\eshop\eshop\Areas\Customer\Views\CustomerOrders\Index.cshtml"
                                    Write(nameof(Order.ID));

#line default
#line hidden
            EndContext();
            BeginContext(438, 48, true);
            WriteLiteral("</th>\r\n                    <th class=\"col-sm-2\">");
            EndContext();
            BeginContext(487, 25, false);
#line 18 "C:\Users\bure\Desktop\UTB\5. semestr\PWT\cviko\eshop\eshop\Areas\Customer\Views\CustomerOrders\Index.cshtml"
                                    Write(nameof(Order.OrderNumber));

#line default
#line hidden
            EndContext();
            BeginContext(512, 48, true);
            WriteLiteral("</th>\r\n                    <th class=\"col-sm-3\">");
            EndContext();
            BeginContext(561, 24, false);
#line 19 "C:\Users\bure\Desktop\UTB\5. semestr\PWT\cviko\eshop\eshop\Areas\Customer\Views\CustomerOrders\Index.cshtml"
                                    Write(nameof(Order.TotalPrice));

#line default
#line hidden
            EndContext();
            BeginContext(585, 48, true);
            WriteLiteral("</th>\r\n                    <th class=\"col-sm-3\">");
            EndContext();
            BeginContext(634, 23, false);
#line 20 "C:\Users\bure\Desktop\UTB\5. semestr\PWT\cviko\eshop\eshop\Areas\Customer\Views\CustomerOrders\Index.cshtml"
                                    Write(nameof(Order.Confirmed));

#line default
#line hidden
            EndContext();
            BeginContext(657, 48, true);
            WriteLiteral("</th>\r\n                    <th class=\"col-sm-3\">");
            EndContext();
            BeginContext(706, 29, false);
#line 21 "C:\Users\bure\Desktop\UTB\5. semestr\PWT\cviko\eshop\eshop\Areas\Customer\Views\CustomerOrders\Index.cshtml"
                                    Write(nameof(Order.DateTimeCreated));

#line default
#line hidden
            EndContext();
            BeginContext(735, 93, true);
            WriteLiteral("</th>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"col-sm-1\">");
            EndContext();
            BeginContext(829, 7, false);
#line 24 "C:\Users\bure\Desktop\UTB\5. semestr\PWT\cviko\eshop\eshop\Areas\Customer\Views\CustomerOrders\Index.cshtml"
                                    Write(item.ID);

#line default
#line hidden
            EndContext();
            BeginContext(836, 48, true);
            WriteLiteral("</td>\r\n                    <td class=\"col-sm-2\">");
            EndContext();
            BeginContext(885, 16, false);
#line 25 "C:\Users\bure\Desktop\UTB\5. semestr\PWT\cviko\eshop\eshop\Areas\Customer\Views\CustomerOrders\Index.cshtml"
                                    Write(item.OrderNumber);

#line default
#line hidden
            EndContext();
            BeginContext(901, 48, true);
            WriteLiteral("</td>\r\n                    <td class=\"col-sm-3\">");
            EndContext();
            BeginContext(950, 15, false);
#line 26 "C:\Users\bure\Desktop\UTB\5. semestr\PWT\cviko\eshop\eshop\Areas\Customer\Views\CustomerOrders\Index.cshtml"
                                    Write(item.TotalPrice);

#line default
#line hidden
            EndContext();
            BeginContext(965, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 27 "C:\Users\bure\Desktop\UTB\5. semestr\PWT\cviko\eshop\eshop\Areas\Customer\Views\CustomerOrders\Index.cshtml"
                     if (item.Confirmed == true)
                    {

#line default
#line hidden
            BeginContext(1045, 154, true);
            WriteLiteral("                        <td>\r\n                            <span style=\"color: lightgreen; font-weight: bold\"> YES </span>\r\n                        </td>\r\n");
            EndContext();
#line 32 "C:\Users\bure\Desktop\UTB\5. semestr\PWT\cviko\eshop\eshop\Areas\Customer\Views\CustomerOrders\Index.cshtml"
                    }
                    else
                    {

#line default
#line hidden
            BeginContext(1271, 146, true);
            WriteLiteral("                        <td>\r\n                            <span style=\"color: red; font-weight: bold\"> NO </span>\r\n                        </td>\r\n");
            EndContext();
#line 38 "C:\Users\bure\Desktop\UTB\5. semestr\PWT\cviko\eshop\eshop\Areas\Customer\Views\CustomerOrders\Index.cshtml"
                    }

#line default
#line hidden
            BeginContext(1440, 41, true);
            WriteLiteral("                    <td class=\"col-sm-3\">");
            EndContext();
            BeginContext(1482, 20, false);
#line 39 "C:\Users\bure\Desktop\UTB\5. semestr\PWT\cviko\eshop\eshop\Areas\Customer\Views\CustomerOrders\Index.cshtml"
                                    Write(item.DateTimeCreated);

#line default
#line hidden
            EndContext();
            BeginContext(1502, 56, true);
            WriteLiteral("</td>\r\n                </tr>\r\n\r\n\r\n            </table>\r\n");
            EndContext();
            BeginContext(1560, 19, true);
            WriteLiteral("            <button");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 1579, "\"", 1611, 2);
            WriteAttributeValue("", 1584, "order_items_button_", 1584, 19, true);
#line 45 "C:\Users\bure\Desktop\UTB\5. semestr\PWT\cviko\eshop\eshop\Areas\Customer\Views\CustomerOrders\Index.cshtml"
WriteAttributeValue("", 1603, item.ID, 1603, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1612, 27, true);
            WriteLiteral(" class=\"btn-group btn-link\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 1639, "\"", 1726, 9);
            WriteAttributeValue("", 1649, "ViewHideDetails(", 1649, 16, true);
            WriteAttributeValue(" ", 1665, "\'order_items_\'", 1666, 15, true);
            WriteAttributeValue(" ", 1680, "+", 1681, 2, true);
#line 45 "C:\Users\bure\Desktop\UTB\5. semestr\PWT\cviko\eshop\eshop\Areas\Customer\Views\CustomerOrders\Index.cshtml"
WriteAttributeValue(" ", 1682, item.ID, 1683, 8, false);

#line default
#line hidden
            WriteAttributeValue("", 1691, ",", 1691, 1, true);
            WriteAttributeValue(" ", 1692, "\'order_items_button_\'", 1693, 22, true);
            WriteAttributeValue(" ", 1714, "+", 1715, 2, true);
#line 45 "C:\Users\bure\Desktop\UTB\5. semestr\PWT\cviko\eshop\eshop\Areas\Customer\Views\CustomerOrders\Index.cshtml"
WriteAttributeValue(" ", 1716, item.ID, 1717, 8, false);

#line default
#line hidden
            WriteAttributeValue("", 1725, ")", 1725, 1, true);
            EndWriteAttribute();
            BeginContext(1727, 24, true);
            WriteLiteral(">View Details</button>\r\n");
            EndContext();
#line 46 "C:\Users\bure\Desktop\UTB\5. semestr\PWT\cviko\eshop\eshop\Areas\Customer\Views\CustomerOrders\Index.cshtml"


            // order detail

#line default
#line hidden
            BeginContext(1784, 16, true);
            WriteLiteral("            <div");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 1800, "\"", 1825, 2);
            WriteAttributeValue("", 1805, "order_items_", 1805, 12, true);
#line 49 "C:\Users\bure\Desktop\UTB\5. semestr\PWT\cviko\eshop\eshop\Areas\Customer\Views\CustomerOrders\Index.cshtml"
WriteAttributeValue("", 1817, item.ID, 1817, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1826, 226, true);
            WriteLiteral(" style=\"display:none\">\r\n                <h4>Order Items</h4>\r\n                <table style=\"width:41.667%\" class=\"table table-responsive table-bordered\">\r\n                    <tr>\r\n                        <th class=\"col-sm-3\">");
            EndContext();
            BeginContext(2053, 20, false);
#line 53 "C:\Users\bure\Desktop\UTB\5. semestr\PWT\cviko\eshop\eshop\Areas\Customer\Views\CustomerOrders\Index.cshtml"
                                        Write(nameof(Product.Name));

#line default
#line hidden
            EndContext();
            BeginContext(2073, 52, true);
            WriteLiteral("</th>\r\n                        <th class=\"col-sm-3\">");
            EndContext();
            BeginContext(2126, 23, false);
#line 54 "C:\Users\bure\Desktop\UTB\5. semestr\PWT\cviko\eshop\eshop\Areas\Customer\Views\CustomerOrders\Index.cshtml"
                                        Write(nameof(Product.Content));

#line default
#line hidden
            EndContext();
            BeginContext(2149, 52, true);
            WriteLiteral("</th>\r\n                        <th class=\"col-sm-1\">");
            EndContext();
            BeginContext(2202, 24, false);
#line 55 "C:\Users\bure\Desktop\UTB\5. semestr\PWT\cviko\eshop\eshop\Areas\Customer\Views\CustomerOrders\Index.cshtml"
                                        Write(nameof(OrderItem.Amount));

#line default
#line hidden
            EndContext();
            BeginContext(2226, 52, true);
            WriteLiteral("</th>\r\n                        <th class=\"col-sm-1\">");
            EndContext();
            BeginContext(2279, 23, false);
#line 56 "C:\Users\bure\Desktop\UTB\5. semestr\PWT\cviko\eshop\eshop\Areas\Customer\Views\CustomerOrders\Index.cshtml"
                                        Write(nameof(OrderItem.Price));

#line default
#line hidden
            EndContext();
            BeginContext(2302, 36, true);
            WriteLiteral("</th>\r\n                    </tr>\r\n\r\n");
            EndContext();
#line 59 "C:\Users\bure\Desktop\UTB\5. semestr\PWT\cviko\eshop\eshop\Areas\Customer\Views\CustomerOrders\Index.cshtml"
                      
                        foreach (var itemOrderItems in item.OrderItems)
                        {

#line default
#line hidden
            BeginContext(2462, 87, true);
            WriteLiteral("                            <tr>\r\n                                <td class=\"col-sm-3\">");
            EndContext();
            BeginContext(2550, 27, false);
#line 63 "C:\Users\bure\Desktop\UTB\5. semestr\PWT\cviko\eshop\eshop\Areas\Customer\Views\CustomerOrders\Index.cshtml"
                                                Write(itemOrderItems.Product.Name);

#line default
#line hidden
            EndContext();
            BeginContext(2577, 60, true);
            WriteLiteral("</td>\r\n                                <td class=\"col-sm-3\">");
            EndContext();
            BeginContext(2638, 30, false);
#line 64 "C:\Users\bure\Desktop\UTB\5. semestr\PWT\cviko\eshop\eshop\Areas\Customer\Views\CustomerOrders\Index.cshtml"
                                                Write(itemOrderItems.Product.Content);

#line default
#line hidden
            EndContext();
            BeginContext(2668, 60, true);
            WriteLiteral("</td>\r\n                                <td class=\"col-sm-1\">");
            EndContext();
            BeginContext(2729, 21, false);
#line 65 "C:\Users\bure\Desktop\UTB\5. semestr\PWT\cviko\eshop\eshop\Areas\Customer\Views\CustomerOrders\Index.cshtml"
                                                Write(itemOrderItems.Amount);

#line default
#line hidden
            EndContext();
            BeginContext(2750, 60, true);
            WriteLiteral("</td>\r\n                                <td class=\"col-sm-1\">");
            EndContext();
            BeginContext(2811, 20, false);
#line 66 "C:\Users\bure\Desktop\UTB\5. semestr\PWT\cviko\eshop\eshop\Areas\Customer\Views\CustomerOrders\Index.cshtml"
                                                Write(itemOrderItems.Price);

#line default
#line hidden
            EndContext();
            BeginContext(2831, 42, true);
            WriteLiteral("</td>\r\n                            </tr>\r\n");
            EndContext();
#line 68 "C:\Users\bure\Desktop\UTB\5. semestr\PWT\cviko\eshop\eshop\Areas\Customer\Views\CustomerOrders\Index.cshtml"
                        }
                    

#line default
#line hidden
            BeginContext(2923, 106, true);
            WriteLiteral("                </table>\r\n            </div>\r\n            <br />\r\n            <br />\r\n            <br />\r\n");
            EndContext();
#line 75 "C:\Users\bure\Desktop\UTB\5. semestr\PWT\cviko\eshop\eshop\Areas\Customer\Views\CustomerOrders\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(3040, 14, true);
            WriteLiteral("        <hr>\r\n");
            EndContext();
#line 77 "C:\Users\bure\Desktop\UTB\5. semestr\PWT\cviko\eshop\eshop\Areas\Customer\Views\CustomerOrders\Index.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(3078, 36, true);
            WriteLiteral("        <h2>Orders are empty!</h2>\r\n");
            EndContext();
#line 81 "C:\Users\bure\Desktop\UTB\5. semestr\PWT\cviko\eshop\eshop\Areas\Customer\Views\CustomerOrders\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(3124, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(3144, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(3150, 104, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("environment", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d0b441c1cee275b6af358cdc1c9d81930f30776920098", async() => {
                    BeginContext(3185, 10, true);
                    WriteLiteral("\r\n        ");
                    EndContext();
                    BeginContext(3195, 39, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d0b441c1cee275b6af358cdc1c9d81930f30776920518", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    EndContext();
                    BeginContext(3234, 6, true);
                    WriteLiteral("\r\n    ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.EnvironmentTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper.Include = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3254, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(3260, 108, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("environment", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d0b441c1cee275b6af358cdc1c9d81930f30776922930", async() => {
                    BeginContext(3295, 10, true);
                    WriteLiteral("\r\n        ");
                    EndContext();
                    BeginContext(3305, 43, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d0b441c1cee275b6af358cdc1c9d81930f30776923350", async() => {
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
                    EndContext();
                    BeginContext(3348, 6, true);
                    WriteLiteral("\r\n    ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.EnvironmentTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper.Exclude = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3368, 2, true);
                WriteLiteral("\r\n");
                EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IList<Order>> Html { get; private set; }
    }
}
#pragma warning restore 1591
