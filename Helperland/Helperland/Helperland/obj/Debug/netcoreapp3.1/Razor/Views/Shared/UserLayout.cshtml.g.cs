#pragma checksum "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Shared\UserLayout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aa4bce9d6d1e89ede00a514b18f0b13c4d913436"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_UserLayout), @"mvc.1.0.view", @"/Views/Shared/UserLayout.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aa4bce9d6d1e89ede00a514b18f0b13c4d913436", @"/Views/Shared/UserLayout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b4b1c47201b9aa2787e6cec5b59d0d5213a1108", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_UserLayout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("nav-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("aria-current", new global::Microsoft.AspNetCore.Html.HtmlString("page"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Dashboard", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Customer", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "CustomerPartialView", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "ServiceProviderPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Shared\UserLayout.cshtml"
  
    Layout = "~/Views/shared/_Layout.cshtml";
    var user = Context.Session.GetString("User");
    SessionUser sessionUser = new SessionUser();

    if (user != null)
    {
        sessionUser = JsonConvert.DeserializeObject<SessionUser>(user);
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<section class=\"headding-name text-center p-t-64\">\r\n    <h2 class=\"headding\">\r\n        Welcome ");
#nullable restore
#line 14 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Shared\UserLayout.cshtml"
           Write(sessionUser.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    </h2>
</section>

<section class=""customer-service-provider"">
    <div class=""max-width sidebar-max-width"">
        <nav class=""navbar-expand-xl sidebar-main"">

            <div class=""sidebar"">

                <div class=""collapse navbar-collapse sidebar-div-menu"" id=""navbarSupportedContent"">
                    <ul class=""navbar-nav me-auto mb-2 mb-lg-0 sidebar-ul"" id=""sidebar-menu"">
                        <li class=""nav-item"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aa4bce9d6d1e89ede00a514b18f0b13c4d9134367387", async() => {
                WriteLiteral("Dashbord");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </li>\r\n");
#nullable restore
#line 29 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Shared\UserLayout.cshtml"
                         if (sessionUser.UserType == UserTypeEnum.Customer.ToString())
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "aa4bce9d6d1e89ede00a514b18f0b13c4d9134369291", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 32 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Shared\UserLayout.cshtml"
                        }
                        else
                        {


#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "aa4bce9d6d1e89ede00a514b18f0b13c4d91343610720", async() => {
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
            WriteLiteral("\r\n");
#nullable restore
#line 37 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Shared\UserLayout.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </ul>\r\n                </div>\r\n            </div>\r\n        </nav>\r\n        ");
#nullable restore
#line 42 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Shared\UserLayout.cshtml"
   Write(RenderBody());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    </div>
</section>

<div class=""modal"" id=""trmodel"" tabindex=""-1"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-dialog-centered "">
        <div class=""modal-content"">

            <div class=""modal-body"">
                <button type=""button"" class=""btn-close model-colse"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
                <h3 class=""mb-30"">Service Details</h3>

                <label id=""d&t"">
                </label>
                <label class=""d-block fw-bold"">Duration: <span id=""duration"" class=""fw-normal pl-1""></span><span class=""fw-normal"">Hrs</span></label>
                <hr />
                <label class=""d-block"">Service Id:<span id=""srid"" class=""fw-normal""></span></label>
                <label");
            BeginWriteAttribute("id", " id=\"", 2277, "\"", 2282, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    Extra:
                    <span class=""extraservice"" id=""extra""></span>
                </label>
                <label class=""col-md-6"">
                    Net Amount:
                    <span id=""price"" class=""modelprice""></span><span class=""modelprice"">€</span>
                </label>


                <hr />

                <label");
            BeginWriteAttribute("class", " class=\"", 2658, "\"", 2666, 0);
            EndWriteAttribute();
            WriteLiteral(">Service Address:<span id=\"serviceaddress\"></span> </label>\r\n                <label>Phone:<span");
            BeginWriteAttribute("class", " class=\"", 2762, "\"", 2770, 0);
            EndWriteAttribute();
            WriteLiteral(" id=\"phonenumber\"></span> </label>\r\n                <label>Email:<span");
            BeginWriteAttribute("class", " class=\"", 2841, "\"", 2849, 0);
            EndWriteAttribute();
            WriteLiteral(" id=\"email\"></span> </label>\r\n\r\n                <hr />\r\n\r\n                <label>Comments<span");
            BeginWriteAttribute("class", " class=\"", 2944, "\"", 2952, 0);
            EndWriteAttribute();
            WriteLiteral(" id=\"comments\"></span> </label>\r\n                <label id=\"pet\"></label>\r\n\r\n\r\n\r\n                <div id=\"btnreschedulejsdashbord\">\r\n\r\n                </div>\r\n\r\n");
            WriteLiteral("\r\n\r\n\r\n            </div>\r\n\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 98 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Shared\UserLayout.cshtml"
Write(RenderSection("UserLayoutSection", required: false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    <script>\r\n        $(\'#sidebar-menu li a\').click(function ()\r\n        {\r\n            $(\'#sidebar-menu li\').removeClass(\"active\");\r\n            \r\n            $(\"#sidebar-menu li\").addClass(\"active\");\r\n        });\r\n    </script>\r\n");
            }
            );
            WriteLiteral("\r\n\r\n\r\n");
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
