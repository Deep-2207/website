#pragma checksum "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Home\Faq.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "62f02b016bcaba92bfc1345bd2244c075e31fa0c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Faq), @"mvc.1.0.view", @"/Views/Home/Faq.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"62f02b016bcaba92bfc1345bd2244c075e31fa0c", @"/Views/Home/Faq.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b5f94cf04a7ec23f27ac33992ef127038e0b3154", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Faq : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/faq/faq-banner.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Home\Faq.cshtml"
  
    ViewData["Title"] = "FAQ";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<section class=\"first-img\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "62f02b016bcaba92bfc1345bd2244c075e31fa0c4018", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</section>


<section class=""FAQ pt-0"" id=""FAQ"">
    <div class=""max-width-986 pt-0"">
        <div class=""row justify-content-center text-center"">
            <div class=""col-12 mb-5"" style=""position: relative;"">
                <h2 class=""headding-star"">FAQs</h2>
            </div>
        </div>
        <div class=""container container-max-width"">
            <p class=""text-center headding-content m-tb-36"">
                Whether you are Customer or Service provider,<br>We have tried our best to solve all your queries and questions.
            </p>

            <ul class=""nav nav-pills mb-3 col-md-12"" id=""pills-tab"" role=""tablist"">
                <li class=""nav-item col"" role=""presentation"">
                    <button class=""nav-link active col-md-6"" id=""customer-tab"" data-bs-toggle=""pill"" data-bs-target=""#customer"" type=""button"" role=""tab"" aria-controls=""customer"" aria-selected=""true"">For Customer</button>
                </li>
                <li class=""nav-item col"" role=""presenta");
            WriteLiteral(@"tion"">
                    <button class=""nav-link col-md-6"" id=""service-tab"" data-bs-toggle=""pill"" data-bs-target=""#service"" type=""button"" role=""tab"" aria-controls=""service"" aria-selected=""false"">For Service Provider</button>
                </li>

            </ul>


            <div class=""tab-content"" id=""pills-tabContent"">
                <div class=""tab-pane fade show active"" id=""customer"" role=""tabpanel""
                     aria-labelledby=""customer-tab"">
                    <div class=""accordion accordion-flush"" id=""accordionFlushExample"">
                        <div class=""accordion-item"">
                            <h3 class=""accordion-header"" id=""customer-headingOne"">
                                <button class=""accordion-button collapsed"" type=""button""
                                        data-bs-toggle=""collapse"" data-bs-target=""#customer-collapseOne""
                                        aria-expanded=""false"" aria-controls=""customer-collapseOne"">
                       ");
            WriteLiteral(@"             What's included in a cleaning?
                                </button>
                            </h3>
                            <div id=""customer-collapseOne"" class=""accordion-collapse collapse""
                                 aria-labelledby=""customer-headingOne"" data-bs-parent=""#accordionFlushExample"">
                                <div class=""accordion-body"">
                                    Bedroom, Living Room & Common Areas, Bathrooms, Kitchen, Extras
                                </div>
                            </div>
                        </div>
                        <div class=""accordion-item"">
                            <h3 class=""accordion-header"" id=""customer-headingTwo"">
                                <button class=""accordion-button collapsed"" type=""button""
                                        data-bs-toggle=""collapse"" data-bs-target=""#customer-collapseTwo""
                                        aria-expanded=""false"" aria-controls=""customer-c");
            WriteLiteral(@"ollapseTwo"">
                                    Which Helperland professional will come to my place?
                                </button>
                            </h3>
                            <div id=""customer-collapseTwo"" class=""accordion-collapse collapse""
                                 aria-labelledby=""customer-headingTwo"" data-bs-parent=""#accordionFlushExample"">
                                <div class=""accordion-body"">
                                    Helperland has a vast network of experienced, top-rated cleaners. Based on the time and date of your request, we work to assign the best professional available. Like working with a specific pro? Add them to your Pro Team from the mobile app and they'll be requested first for all future bookings. You will receive an email with details about your professional prior to your appointment.
                                </div>
                            </div>
                        </div>
                        <div class=""acc");
            WriteLiteral(@"ordion-item"">
                            <h3 class=""accordion-header"" id=""customer-headingThree"">
                                <button class=""accordion-button collapsed"" type=""button""
                                        data-bs-toggle=""collapse"" data-bs-target=""#customer-collapseThree""
                                        aria-expanded=""false"" aria-controls=""customer-collapseThree"">
                                    Can I skip or reschedule bookings?
                                </button>
                            </h3>
                            <div id=""customer-collapseThree"" class=""accordion-collapse collapse""
                                 aria-labelledby=""customer-headingThree"" data-bs-parent=""#accordionFlushExample"">
                                <div class=""accordion-body"">
                                    You can reschedule any booking for free at least 24 hours in advance of the scheduled start time. If you need to skip a booking within the minimum commitment, we");
            WriteLiteral(@"’ll credit the value of the booking to your account. You can use this credit on future cleanings and other Helperland services.
                                </div>
                            </div>
                        </div>
                        <div class=""accordion-item"">
                            <h3 class=""accordion-header"" id=""customer-headingFour"">
                                <button class=""accordion-button collapsed"" type=""button""
                                        data-bs-toggle=""collapse"" data-bs-target=""#customer-collapseFour""
                                        aria-expanded=""false"" aria-controls=""customer-collapseFour"">
                                    Do I need to be home for the booking?
                                </button>
                            </h3>
                            <div id=""customer-collapseFour"" class=""accordion-collapse collapse""
                                 aria-labelledby=""customer-headingFour"" data-bs-parent=""#accordionF");
            WriteLiteral(@"lushExample"">
                                <div class=""accordion-body"">
                                    We strongly recommend that you are home for the first clean of your booking to show your cleaner around. Some customers choose to give a spare key to their cleaner, but this decision is based on individual preferences.
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class=""tab-pane fade"" id=""service"" role=""tabpanel""
                     aria-labelledby=""service-tab"">
                    <div class=""accordion accordion-flush"" id=""accordionFlushExample2"">
                        <div class=""accordion-item"">
                            <h3 class=""accordion-header"" id=""service-provider-headingOne"">
                                <button class=""accordion-button collapsed"" type=""button""
                                        data-bs-toggle=""collapse"" data-bs-targ");
            WriteLiteral(@"et=""#service-provider-collapseOne""
                                        aria-expanded=""false"" aria-controls=""service-provider-collapseOne"">
                                    How much do service providers earn?
                                </button>
                            </h3>
                            <div id=""service-provider-collapseOne"" class=""accordion-collapse collapse""
                                 aria-labelledby=""service-provider-headingOne"" data-bs-parent=""#accordionFlushExample2"">
                                <div class=""accordion-body"">
                                    The self-employed service providers working with Helperland set their own payouts, this means that they decide how much they earn per hour.
                                </div>
                            </div>
                        </div>
                        <div class=""accordion-item"">
                            <h3 class=""accordion-header"" id=""service-provider-headingTwo"">
         ");
            WriteLiteral(@"                       <button class=""accordion-button collapsed"" type=""button""
                                        data-bs-toggle=""collapse"" data-bs-target=""#service-provider-collapseTwo""
                                        aria-expanded=""false"" aria-controls=""service-provider-collapseTwo"">
                                    What support do you provide to the service providers?
                                </button>
                            </h3>
                            <div id=""service-provider-collapseTwo"" class=""accordion-collapse collapse""
                                 aria-labelledby=""service-provider-headingTwo"" data-bs-parent=""#accordionFlushExample2"">
                                <div class=""accordion-body"">
                                    Our call-centre is available to assist the service providers with all queries or issues in regards to their bookings during office hours. Before a service provider starts receiving jobs, every individual partner receives an ori");
            WriteLiteral(@"entation session to familiarise with the online platform and their profile.
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>



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
