#pragma checksum "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Customer\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3c0c38071e893e7b12458eace2eb63e168f95e64"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_Dashboard), @"mvc.1.0.view", @"/Views/Customer/Dashboard.cshtml")]
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
#line 1 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\_ViewImports.cshtml"
using Helperland;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\_ViewImports.cshtml"
using Helperland.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\_ViewImports.cshtml"
using Helperland.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\_ViewImports.cshtml"
using Helperland.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\_ViewImports.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\_ViewImports.cshtml"
using Helperland.Enums;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3c0c38071e893e7b12458eace2eb63e168f95e64", @"/Views/Customer/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b4b1c47201b9aa2787e6cec5b59d0d5213a1108", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ServiceRequest>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("extrabtn w-auto"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Book_Services", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/service-provider-upcoming-service/calendar2.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/service-provider-upcoming-service/layer-712.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("align-self-center mr-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/customer-service/forma-1-copy-19.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Generic placeholder image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Customer/customer.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Customer\Dashboard.cshtml"
  
    Layout = "~/Views/Shared/UserLayout.cshtml";
    ViewData["Title"] = "Dashboard";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"customer-table \">\r\n    <div class=\"sub-headding p-b-10\">\r\n        <h2>Service Dashboard</h2>\r\n        <div class=\"Export w-auto\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3c0c38071e893e7b12458eace2eb63e168f95e648693", async() => {
                WriteLiteral("New Service Booking");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n\r\n    <table id=\"example\" class=\"display customer-table customer-dashboard\" style=\"width:100%\">\r\n        <thead>\r\n            <tr>\r\n                <th>Service ID<img");
            BeginWriteAttribute("alt", " alt=\"", 597, "\"", 603, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"sorting-img\"></th>\r\n                <th>Service Details<img");
            BeginWriteAttribute("alt", " alt=\"", 671, "\"", 677, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"sorting-img\"></th>\r\n                <th class=\"text-start\">Service Provider <img");
            BeginWriteAttribute("alt", " alt=\"", 766, "\"", 772, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"sorting-img\"></th>\r\n                <th class=\"cus-dait\">Payment <img");
            BeginWriteAttribute("alt", " alt=\"", 850, "\"", 856, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"sorting-img\"></th>\r\n                <th>Action<img");
            BeginWriteAttribute("alt", " alt=\"", 915, "\"", 921, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"sorting-img\"></th>\r\n\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 27 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Customer\Dashboard.cshtml"
             if (Model.Any())
            {
                foreach (ServiceRequest service in Model)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Customer\Dashboard.cshtml"
                     if (service.Status != (int)ServiceStatusEnum.Cancel && service.Status != (int)ServiceStatusEnum.completed)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr");
            BeginWriteAttribute("onclick", " onclick=\"", 1309, "\"", 1355, 3);
            WriteAttributeValue("", 1319, "modelpopp(", 1319, 10, true);
#nullable restore
#line 33 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Customer\Dashboard.cshtml"
WriteAttributeValue("", 1329, service.ServiceRequestId, 1329, 25, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1354, ")", 1354, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"cptabletr\">\r\n                            <td class=\"tdclick\"><a");
            BeginWriteAttribute("onclick", " onclick=\"", 1427, "\"", 1496, 4);
            WriteAttributeValue("", 1437, "showservicerequestdetailmodel(", 1437, 30, true);
#nullable restore
#line 34 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Customer\Dashboard.cshtml"
WriteAttributeValue("", 1467, service.ServiceRequestId, 1467, 25, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1492, ",", 1492, 1, true);
            WriteAttributeValue(" ", 1493, "0)", 1494, 3, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"startid d-flex justify-content-center align-items-center\" href=\"#\"> ");
#nullable restore
#line 34 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Customer\Dashboard.cshtml"
                                                                                                                                                                                               Write(service.ServiceRequestId);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </a></td>\r\n                            <td class=\"tdclick\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "3c0c38071e893e7b12458eace2eb63e168f95e6414049", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" <span>");
#nullable restore
#line 36 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Customer\Dashboard.cshtml"
                                                                                                          Write(service.ServiceStartDate.Date.ToString("dd-MM-yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> <br>\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "3c0c38071e893e7b12458eace2eb63e168f95e6415583", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("  ");
#nullable restore
#line 37 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Customer\Dashboard.cshtml"
                                                                                                     Write(service.ServiceStartDate.TimeOfDay.ToString().Remove(5, 3));

#line default
#line hidden
#nullable disable
            WriteLiteral(" -  ");
#nullable restore
#line 37 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Customer\Dashboard.cshtml"
                                                                                                                                                                     Write(service.ServiceStartDate.AddMinutes(service.ServiceHours * 60).TimeOfDay.ToString().Remove(5, 3));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                            </td>\r\n                            <td>\r\n");
#nullable restore
#line 41 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Customer\Dashboard.cshtml"
                                 if (service.ServiceProviderId != null)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <div class=\"media d-flex\">\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "3c0c38071e893e7b12458eace2eb63e168f95e6418037", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        <div class=\"media-body\">\r\n                                            ");
#nullable restore
#line 46 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Customer\Dashboard.cshtml"
                                       Write(service.User.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("  ");
#nullable restore
#line 46 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Customer\Dashboard.cshtml"
                                                                Write(service.User.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("  <br>\r\n");
#nullable restore
#line 47 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Customer\Dashboard.cshtml"
                                              
                                                decimal totalRating = 0;
                                                decimal spRating = 0;
                                                int count = 0;
                                                foreach (Rating r in service.Ratings)
                                                {
                                                    totalRating = totalRating + r.Ratings;
                                                    count++;
                                                }
                                                if (count > 0)
                                                {
                                                    spRating = Math.Round((totalRating / count) * 10) / 10;
                                                }
                                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <input required");
            BeginWriteAttribute("id", " id=\"", 3656, "\"", 3687, 1);
#nullable restore
#line 61 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Customer\Dashboard.cshtml"
WriteAttributeValue("", 3661, service.ServiceProviderId, 3661, 26, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"ratingspdashboard\"");
            BeginWriteAttribute("value", " value=\"", 3714, "\"", 3731, 1);
#nullable restore
#line 61 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Customer\Dashboard.cshtml"
WriteAttributeValue("", 3722, spRating, 3722, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" type=\"text\"");
            BeginWriteAttribute("title", " title=\"", 3744, "\"", 3752, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                            <div class=\"clearfix\"></div>\r\n                                        </div>\r\n                                    </div>\r\n");
#nullable restore
#line 65 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Customer\Dashboard.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td class=\"price\">");
#nullable restore
#line 68 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Customer\Dashboard.cshtml"
                                         Write(service.TotalCost);

#line default
#line hidden
#nullable disable
            WriteLiteral(" €</td>\r\n                            <td");
            BeginWriteAttribute("class", " class=\"", 4098, "\"", 4106, 0);
            EndWriteAttribute();
            WriteLiteral(" id=\"btnreschedulejs\">\r\n                                <label class=\"btn btnReschedule\"");
            BeginWriteAttribute("value", " value=\"", 4195, "\"", 4203, 0);
            EndWriteAttribute();
            WriteLiteral(" data-toggle=\"rechedual\"");
            BeginWriteAttribute("onclick", " onclick=\"", 4228, "\"", 4282, 3);
            WriteAttributeValue("", 4238, "rescheduleservice(", 4238, 18, true);
#nullable restore
#line 70 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Customer\Dashboard.cshtml"
WriteAttributeValue("", 4256, service.ServiceRequestId, 4256, 25, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4281, ")", 4281, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Reschedule</label>\r\n                                <label class=\"btn btncancel\"");
            BeginWriteAttribute("value", " value=\"", 4364, "\"", 4372, 0);
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 4373, "\"", 4423, 3);
            WriteAttributeValue("", 4383, "cancelservice(", 4383, 14, true);
#nullable restore
#line 71 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Customer\Dashboard.cshtml"
WriteAttributeValue("", 4397, service.ServiceRequestId, 4397, 25, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4422, ")", 4422, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Cancel</label>\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 74 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Customer\Dashboard.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 74 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Customer\Dashboard.cshtml"
                     
                }
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n        </tbody>\r\n\r\n    </table>\r\n</div>\r\n\r\n<input id=\"hiddenServiceRequestId\" type=\"hidden\" />\r\n\r\n");
            WriteLiteral(@"
<div class=""modal"" id=""rechedual"" tabindex=""-1"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-dialog-centered "">
        <div class=""modal-content"">

            <div class=""modal-body"">
                <button type=""button"" class=""btn-close model-colse"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
                <h3 class=""mb-30"">Reschedule Service</h3>

                <div class=""alert alert-danger d-none"" id=""errormesgrechedual"" role=""alert"">

                </div>

                <div class=""row row-cols-1 row-cols-md-2 g-4 mt-0"">
                    <div class=""col mt-0"">
                        <label for=""datechange"" class=""form-label"">Change Date</label>
                        <input type=""date"" class=""form-control"" id=""datechange"">

                    </div>
                    <div class=""col mt-0"">
                        <label for=""exampleInputEmail1"" class=""form-label"">Select Time</label>
                        <se");
            WriteLiteral("lect class=\"form-select\" id=\"drpselecttime\">\r\n\r\n");
#nullable restore
#line 111 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Customer\Dashboard.cshtml"
                             for (double i = 8; i <= 18; i = (i + 0.5))
                            {

                                string[] s = i.ToString().Split('.');

#line default
#line hidden
#nullable disable
            WriteLiteral("                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3c0c38071e893e7b12458eace2eb63e168f95e6426794", async() => {
#nullable restore
#line 115 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Customer\Dashboard.cshtml"
                                              Write(s[0]);

#line default
#line hidden
#nullable disable
                WriteLiteral(": ");
#nullable restore
#line 115 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Customer\Dashboard.cshtml"
                                                      Write(s.Length == 2? "30" : "00");

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 115 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Customer\Dashboard.cshtml"
                                   WriteLiteral(i);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 116 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Customer\Dashboard.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </select>
                    </div>

                </div>
                <span class=""text-danger"" id=""spantimechange""></span>
                <button class=""btn btn-primary btn-lg btnlogin mt-2"" type=""button"" onclick=""changeservicetime()"">Save</button>

            </div>

        </div>
    </div>
</div>

");
            WriteLiteral(@"
<div class=""modal"" id=""cancelservice"" tabindex=""-1"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-dialog-centered "">
        <div class=""modal-content"">

            <div class=""modal-body"">
                <button type=""button"" class=""btn-close model-colse"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
                <h3 class=""mb-30"">Cancel Service</h3>


                <div class=""form-group"">
                    <label for=""exampleFormControlTextarea1""> Why do you want to cancel your booking? (We'll forward the justification to your helper.)</label>
                    <textarea class=""form-control"" id=""exampleFormControlTextarea1"" rows=""3""></textarea>
                </div>
                <button class=""btn btn-primary btn-lg btnlogin mt-2"" type=""button"" onclick=""cancelservicepost()"">Cancel</button>

            </div>

        </div>
    </div>
</div>


");
            DefineSection("UserLayoutSection", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3c0c38071e893e7b12458eace2eb63e168f95e6430632", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <script>

        $(document).ready(function () {
            $('#example').on('draw.dt', function () { //every time ajax call, this code execute

                $("".ratingspdashboard"").rating({
                    min: 0,
                    max: 5,
                    step: 0.1,
                    size: ""xs"",
                    stars: ""5"",
                    showClear: false,
                    readonly: true,
                    starCaptions: function (val) {
                        return val;
                    }
                });
            });
            $('#example').DataTable({
                ""dom"": '<""top""i>rt<""bottom""flp><""clear"">',
                ""columnDefs"": [
                    { ""orderable"": false, ""targets"": 4 }
                ],

                ""bFilter"": false, //hide Search bar
                ""pagingType"": ""full_numbers"",
                paging: true,
                ""pagingType"": ""full_numbers"",
                // bFilter: false,
        ");
                WriteLiteral(@"        ordering: true,
                searching: false,
                info: true,
                ""columnDefs"": [
                    { ""orderable"": false, ""targets"": 4 }
                ],
                ""oLanguage"": {
                    ""sInfo"": ""Total Records: _TOTAL_""
                },
                ""dom"": '<""top"">rt<""bottom""lip><""clear"">',
                responsive: true,
                ""order"": []
            });
            $('#example').on('draw.dt', function () { //every time ajax call, this code execute
               
                $("".ratingspdashboard"").rating({
                    min: 0,
                    max: 5,
                    step: 0.1,
                    size: ""xs"",
                    stars: ""5"",
                    showClear: false,
                    readonly: true,
                    starCaptions: function (val) {
                        return val;
                    },
                    starCaptionClasses: function () {
                        ret");
                WriteLiteral("urn \"fs-16\";\n                    },\n                });\n            });\r\n           \r\n        });\r\n    </script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ServiceRequest>> Html { get; private set; }
    }
}
#pragma warning restore 1591
