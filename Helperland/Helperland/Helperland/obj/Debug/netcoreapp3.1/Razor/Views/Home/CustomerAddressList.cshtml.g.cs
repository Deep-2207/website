#pragma checksum "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Home\CustomerAddressList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "189878e57cbe955c4c2553dfefa3721da872c6f9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_CustomerAddressList), @"mvc.1.0.view", @"/Views/Home/CustomerAddressList.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"189878e57cbe955c4c2553dfefa3721da872c6f9", @"/Views/Home/CustomerAddressList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b4b1c47201b9aa2787e6cec5b59d0d5213a1108", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_CustomerAddressList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<UserAddress>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Home\CustomerAddressList.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Home\CustomerAddressList.cshtml"
 if (Model.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <script type=\"text/javascript\">\r\n\r\n        $(\"#btnaddressbookservice\").removeClass(\"disabled\");\r\n    </script>\r\n");
#nullable restore
#line 13 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Home\CustomerAddressList.cshtml"
     foreach (UserAddress address in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"form-check\">\r\n            <input class=\"form-check-input\" type=\"radio\" name=\"UserAddress\"");
            BeginWriteAttribute("id", " id=\"", 363, "\"", 386, 1);
#nullable restore
#line 16 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Home\CustomerAddressList.cshtml"
WriteAttributeValue("", 368, address.AddressId, 368, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n                   value=\"option1\" checked>\r\n            <label class=\"form-check-label\"");
            BeginWriteAttribute("for", " for=\"", 477, "\"", 501, 1);
#nullable restore
#line 18 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Home\CustomerAddressList.cshtml"
WriteAttributeValue("", 483, address.AddressId, 483, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <p class=\"d-block m-0\">\r\n                    <span class=\"point fw-bold\">Address: </span>\r\n                    ");
#nullable restore
#line 21 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Home\CustomerAddressList.cshtml"
               Write(address.AddressLine1);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 21 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Home\CustomerAddressList.cshtml"
                                     Write(address.AddressLine2);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 21 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Home\CustomerAddressList.cshtml"
                                                           Write(address.City);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 21 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Home\CustomerAddressList.cshtml"
                                                                         Write(address.PostalCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </p>\r\n\r\n                <p class=\"d-block m-0\"> <span class=\"point fw-bold\">Phone number: </span>");
#nullable restore
#line 24 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Home\CustomerAddressList.cshtml"
                                                                                    Write(address.Mobile);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </label>\r\n\r\n        </div>\r\n");
#nullable restore
#line 28 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Home\CustomerAddressList.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Home\CustomerAddressList.cshtml"
     
}
else
{


#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-danger\" id=\"EmptyAddress\" role=\"alert\">\r\n        You Don\'t have a added any Address yet....!!\r\n    </div>\r\n");
            WriteLiteral("    <script type=\"text/javascript\">\r\n        alert(\"under\");\r\n        $(\"#btnaddressbookservice\").addClass(\"disabled\");\r\n    </script>\r\n");
#nullable restore
#line 51 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Home\CustomerAddressList.cshtml"

}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<UserAddress>> Html { get; private set; }
    }
}
#pragma warning restore 1591
