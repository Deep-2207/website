#pragma checksum "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Shared\_NewsLetter.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5c9ae4523e36b2aab98800a7d7f589c1dcae77dc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__NewsLetter), @"mvc.1.0.view", @"/Views/Shared/_NewsLetter.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c9ae4523e36b2aab98800a7d7f589c1dcae77dc", @"/Views/Shared/_NewsLetter.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37af33ccc2e6708637d6862e4cae0b6557aac472", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__NewsLetter : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<section");
            BeginWriteAttribute("class", " class=\"", 30, "\"", 96, 2);
            WriteAttributeValue("", 38, "pt-0", 38, 4, true);
#nullable restore
#line 2 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Shared\_NewsLetter.cshtml"
WriteAttributeValue(" ", 42, ViewBag.page ==  "home"? "bg-color-pal-grey" : "" , 43, 53, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
    <div class=""newsletter"">
        <div class=""text-center mb-4"">
            <h4>GET OUR NEWSLETTER</h4>
        </div>
        <div class=""text-center"">
            <input type=""text"" name=""email"" placeholder=""YOUR EMAIL"" class=""mb-3"">
            <button type=""submit"" class=""ms-2"">Submit</button>
        </div>
    </div>
</section>
");
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
