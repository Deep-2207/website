#pragma checksum "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Customer\ServiceHistory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "99ed51726eff522dcb9dc1e43baba05826061049"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_ServiceHistory), @"mvc.1.0.view", @"/Views/Customer/ServiceHistory.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"99ed51726eff522dcb9dc1e43baba05826061049", @"/Views/Customer/ServiceHistory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b4b1c47201b9aa2787e6cec5b59d0d5213a1108", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_ServiceHistory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/customer-service/forma-1-copy-19.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Customer/customer.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Customer\ServiceHistory.cshtml"
  
    Layout = "~/Views/Shared/UserLayout.cshtml";
    ViewData["Title"] = "ServiceHistory";
    var user = Context.Session.GetString("User");
    SessionUser sessionUser = new SessionUser();

    if (user != null)
    {
        sessionUser = JsonConvert.DeserializeObject<SessionUser>(user);
    }
    var compeleted = (int)ServiceStatusEnum.completed;
    var cancelled = (int)ServiceStatusEnum.Cancel;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"customer-table \">\r\n    <div class=\"sub-headding p-b-10\">\r\n        <h2>Service History</h2>\r\n");
            WriteLiteral("    </div>\r\n    <input type=\"hidden\" id=\"hiddenuserid\"");
            BeginWriteAttribute("value", " value=\"", 633, "\"", 660, 1);
#nullable restore
#line 20 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Customer\ServiceHistory.cshtml"
WriteAttributeValue("", 641, sessionUser.UserID, 641, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n    <input type=\"hidden\" id=\"hiddenServiceRequestId\"");
            BeginWriteAttribute("value", " value=\"", 718, "\"", 726, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n    <input type=\"hidden\" id=\"hiddenserviceproviderid\"");
            BeginWriteAttribute("value", " value=\"", 785, "\"", 793, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n    <table id=\"example\" class=\"display customer-table history-table\" style=\"width:100%\">\r\n        <thead>\r\n            <tr>\r\n                <th>Service ID<img");
            BeginWriteAttribute("alt", " alt=\"", 958, "\"", 964, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"sorting-img\"></th>\r\n                <th>Service Details<img");
            BeginWriteAttribute("alt", " alt=\"", 1032, "\"", 1038, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"sorting-img\"></th>\r\n                <th>Service Provider <img");
            BeginWriteAttribute("alt", " alt=\"", 1108, "\"", 1114, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"sorting-img\"></th>\r\n                <th class=\"cus-dait\">Payment <img");
            BeginWriteAttribute("alt", " alt=\"", 1192, "\"", 1198, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"sorting-img\"></th>\r\n                <th>Status <img");
            BeginWriteAttribute("alt", " alt=\"", 1258, "\"", 1264, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"sorting-img\"></th>\r\n                <th>Rate SP <img");
            BeginWriteAttribute("alt", " alt=\"", 1325, "\"", 1331, 0);
            EndWriteAttribute();
            WriteLiteral(@" class=""sorting-img""></th>

            </tr>
        </thead>
        <tbody>
        </tbody>

    </table>
</div>


<div class=""modal fade"" id=""rateSPModal"" aria-hidden=""true"" aria-labelledby=""rateSPModal"" tabindex=""-1"">
    <div class=""modal-dialog modal-dialog-centered"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <div class=""float-start dvProimgContainer d-flex justify-content-center align-items-center me-3"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "99ed51726eff522dcb9dc1e43baba058260610498291", async() => {
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
            WriteLiteral(@"</div>
                <div>
                    <label class=""fs1 fw-bold"" id=""modelserviceprovidername""></label>

                    <div id=""spRating""></div>
                </div>
                <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
            </div>
            <div class=""modal-body"">

                <input type=""hidden""");
            BeginWriteAttribute("value", " value=\"", 2263, "\"", 2271, 0);
            EndWriteAttribute();
            WriteLiteral(" id=\"hiddenserviceproviderid\" />\r\n                <label class=\"fs1 fw-bold mb-2\">Rate your service provider</label>\r\n                <div class=\"d-flex justify-content-between mb-3\">\r\n                    <div");
            BeginWriteAttribute("class", " class=\"", 2481, "\"", 2489, 0);
            EndWriteAttribute();
            WriteLiteral("><label class=\"mt-2\">On time arrival</label></div>\r\n                    <input id=\"ontimearrival\" class=\"stardisplay d-none\"");
            BeginWriteAttribute("value", " value=\"", 2614, "\"", 2622, 0);
            EndWriteAttribute();
            WriteLiteral(" type=\"text\"");
            BeginWriteAttribute("title", " title=\"", 2635, "\"", 2643, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n\r\n                </div>\r\n                <div class=\"d-flex justify-content-between mb-3\">\r\n                    <div class=\"col-md-4 d-inline-block\"><label class=\"mt-2\">Friendly</label></div>\r\n                    <input id=\"Friendly\"");
            BeginWriteAttribute("value", " value=\"", 2881, "\"", 2889, 0);
            EndWriteAttribute();
            WriteLiteral(" type=\"text\"");
            BeginWriteAttribute("title", " title=\"", 2902, "\"", 2910, 0);
            EndWriteAttribute();
            WriteLiteral(@" class=""stardisplay d-none"">
                </div>
                <div class=""d-flex justify-content-between mb-3"">
                    <div class=""col-md-4""><label class=""mt-2"">Quality of service</label></div>
                    <input id=""Qualityofservice""");
            BeginWriteAttribute("value", " value=\"", 3176, "\"", 3184, 0);
            EndWriteAttribute();
            WriteLiteral(" type=\"text\"");
            BeginWriteAttribute("title", " title=\"", 3197, "\"", 3205, 0);
            EndWriteAttribute();
            WriteLiteral(@" class=""stardisplay d-none"">
                </div>
                <div class=""row"">
                    <div class=""col-md-12""><label class=""mt-2"">Feedback on service provider</label></div>
                </div>
                <div class=""row mt-1"">
                    <div class=""col-md-12"">
                        <textarea class=""form-control"" id=""txtFeedbackToSP""></textarea>
                    </div>
                </div>
                <button class=""btnExport mt-2 fw-bold py-2 px-3 btncontinue"" id=""btnsubmitrating"" onclick=""submitrating()"">Submit</button>
            </div>
        </div>
    </div>
</div>

<div class=""modal fade"" id=""rateedspmodel"" aria-hidden=""true"" aria-labelledby=""rateSPModal"" tabindex=""-1"">
    <div class=""modal-dialog modal-dialog-centered"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <div class=""float-start dvProimgContainer d-flex justify-content-center align-items-center me-3"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "99ed51726eff522dcb9dc1e43baba0582606104912833", async() => {
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
            WriteLiteral("</div>\r\n                <div>\r\n                    <label class=\"fs1 fw-bold\" id=\"modelserviceprovidernamerated\"></label>\r\n");
            WriteLiteral(@"                    <div id=""spRated""></div>
                </div>
                <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
            </div>
            <div class=""modal-body text-center"">
                You are already rated this service

                <button class=""btnExport mt-2 fw-bold py-2 px-3 btncontinue"" id=""moelratedok"">Okay</button>
            </div>
        </div>
    </div>
</div>


");
            DefineSection("UserLayoutSection", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "99ed51726eff522dcb9dc1e43baba0582606104914623", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"

    <script>
        function AppendZero(input) {
            if (input.length == 1) {
                return '0' + input;
            }
            return input;
        }

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
                    { ""orderable"": fals");
                WriteLiteral(@"e, ""targets"": 4 }
                ],

                ""bFilter"": false, //hide Search bar
                ""pagingType"": ""full_numbers"",
                paging: true,
                ""pagingType"": ""full_numbers"",
                // bFilter: false,
                ordering: true,
                searching: false,
                info: true,
                ""columnDefs"": [
                    { ""orderable"": false, ""targets"": 5 }
                ],
                ""oLanguage"": {
                    ""sInfo"": ""Total Records: _TOTAL_""
                },
                ""dom"": 'Bt<""top"">rt<""bottom""lip><""clear"">',
                responsive: true,
                ""order"": [],
                buttons: {
                    dom: {
                        button: {
                            tag: 'button',
                            className: ''
                        }
                    },
                    buttons: [{
                        extend: 'excel',
                        ");
                WriteLiteral(@"text: 'Export',
                        className: ""Export"",
                        exportOptions: {
                            columns: [0, 1, 2, 3]
                        },
                    }]
                }
            });
        });

            $(window).on('load', function () {

            var userid = $(""#hiddenuserid"").val();
                $(""#loader"").addClass(""is-active"");
            $.ajax({
                type: 'Post',
                url: '/customer/loadtable',
                data: { ""userid"": userid },
                success: function (respo) {
                    $(""#loader"").removeClass(""is-active"");
                    respo.forEach(function (element) {
                        var t = $('#example').DataTable();
                        date = new Date(element.serviceStartDate);
                        var d2 = new Date(element.serviceStartDate);
                        /*console.log(element.servicehours);*/
                        d2.setMinutes(d2.get");
                WriteLiteral(@"Minutes() + (element.serviceHours * 60));
                        var temptime = AppendZero(date.getHours().toString()) + "":"" + AppendZero(date.getMinutes().toString()) + "" - "" + AppendZero(d2.getHours().toString()) + "":"" + AppendZero(d2.getMinutes().toString())
                        var inputtagdate =  AppendZero(date.getDate().toString()) + ""-"" + AppendZero((date.getMonth() + 1).toString()) + ""-"" + date.getFullYear().toString();

                        var spandate = date.getFullYear().toString() + AppendZero((date.getMonth() + 1).toString()) + AppendZero(date.getDate().toString()) ;
                        var totalrating = 0;
                        var sprating = 0;
                        var count = 0;

                        element.ratings.forEach(function (e) {
                        /*   console.log(""rating of"" + e);*/
                            totalrating = totalrating + e.ratings;
                            count++;
                        });

                        if (c");
                WriteLiteral(@"ount > 0) {
                            sprating = Math.round((totalrating / count) * 10) / 10;
                        }
                       // console.log(sprating);
                        var txtname;
                        var txtcalss;
                        var ratinginput;
                        var btnrate;

                        if (element.status == ");
#nullable restore
#line 221 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Customer\ServiceHistory.cshtml"
                                         Write(cancelled);

#line default
#line hidden
#nullable disable
                WriteLiteral(@") {
                            txtname = 'Cancel';
                            txtcalss = 'status-cancelled';
                            ratinginput = '';
                            btnrate = 'disabled btnratedisable' ;
                        }
                        else {
                            txtname = 'Completed';
                            txtcalss = 'status-Completed';
                            ratinginput = '<div class=""d-flex""><img class=""align-self-center mr-3"" src=""..//img/customer-service/forma-1-copy-19.png""> <div class=""media-body""> ' + element.serviceProvider.firstName + "" "" + element.serviceProvider.lastName + '<input required class= ""ratingspdashboard""  value = ""' + sprating + '"" type = ""text"" title = """" >  </div></div>';
                            btnrate = '';
                        }
                        t.row.add([
                            '<span class=""tdclick""> <a onclick=""showservicerequestdetailmodel(' + element.serviceRequestId +',1)"" class=""startid ");
                WriteLiteral(@"d-flex justify-content-center align-items-center"" href=""#""> ' + element.serviceRequestId + '</a></span>',
                            '<span class=""d-none"">' + spandate+'</span><img src=' + ""..//img/customer-service/calendar.png"" + ' alt=""""><span class=""bold"">' + inputtagdate + '</span> <br>' + temptime,
                            ratinginput,
                            '<span class=""price""> ' + element.totalCost + '???' + '</span>',
                            '<label class= ""btn ' + txtcalss + '"" value = """" > ' + txtname + '</label> ' + '</td >',
                            '<button class=""btn rate ' + btnrate +' ""  value="""" onclick=""oprnratingmodel(' + element.serviceRequestId + ', ' + sprating + ', ' + element.serviceProviderId + ')"" >Rate SP</button></td>',
                        ]).draw(false);
                       
                        txtname = """";
                        txtcalss = """";
                        totalrating = 0;
                        sprating = 0;
                   ");
                WriteLiteral(@"     count = 0;
                        ratinginput = '';
                    });
                }
            });
            $('.rb-rating').rating({
                'showCaption': true,
                'stars': '3',
                'min': '0',
                'max': '3',
                'step': '1',
                'size': 'xs',
                'starCaptions': { 0: 'status:nix', 1: 'status:wackelt', 2: 'status:geht', 3: 'status:laeuft' }
            });
                $("".stardisplay"").rating({
                min: 0,
                max: 5,
                step: 0.1,
                size: ""xm"",
                stars: ""5"",
                showClear: false,
               /* readonly: true,*/
                starCaptions: function (val) {
                    return val;
                },
            });
        });


            function oprnratingmodel(servicerequestid, sptotalrating, spid) {


                var servicerequestid = servicerequestid;
                var ");
                WriteLiteral(@"userid = $(""#hiddenuserid"").val();
                var serviceontimearrival = $(""#ontimearrival"").val();
                var serviceFriendly = $(""#Friendly"").val();
                var serviceQualityofservice = $(""#Qualityofservice"").val();

                console.log(sptotalrating);
                $(""#totalratingofsp"").val(sptotalrating.toString());
                console.log($(""#totalratingofsp"").val());
                $(""#spRating"").html(""<input id='totalratingofsp' class='spRating' type='text' value='"" + sptotalrating + ""' hidden>"")
                $(""#spRated"").html(""<input id='totalratedofsp' class='spRating' type='text' value='"" + sptotalrating + ""' hidden>"");
                $("".spRating"").rating({
                    min: 0,
                    max: 5,
                    step: 0.1,
                    size: ""xs"",
                    stars: ""5"",
                    showClear: false,
                    readonly: true,
                    starCaptions: function (val) {
         ");
                WriteLiteral(@"               return val;
                    }
                });
                $(""#hiddenserviceproviderid"").val(spid);
                $(""#hiddenServiceRequestId"").val(servicerequestid);
               // console.log(spid + ""seviceprovider"");

                //console.log(servicerequestid);
                //console.log(serviceontimearrival);
                //console.log(serviceFriendly);
                //console.log(serviceQualityofservice);
                $.ajax({
                    type: 'Post',
                    url: '/customer/ratesp',
                    data: {
                        ""servicerequestid"": servicerequestid,
                        ""userid"": userid,
                        ""serviceontimearrival"": serviceontimearrival,
                        ""serviceFriendly"": serviceFriendly,
                        ""serviceQualityofservice"": serviceQualityofservice
                    },
                    success: function (respo) {

                     /* console");
                WriteLiteral(@".log(respo);*/

                        if (respo.result.ratingId == 0 && respo.status != ""error"") {
                            debugger;


                            $(""#modelserviceprovidername"").html(respo.result.serviceProvider.firstName + respo.result.serviceProvider.lastName);



                          /*  console.log(sptotalrating);*/

                            $('.rb-rating').rating({
                                'showCaption': true,
                                'stars': '3',
                                'min': '0',
                                'max': '3',
                                'step': '1',
                                'size': 'xs',
                                'starCaptions': { 0: 'status:nix', 1: 'status:wackelt', 2: 'status:geht', 3: 'status:laeuft' }
                            });
                            $("".overallstardisplay"").rating({
                                min: 0,
                                max: 5,
                  ");
                WriteLiteral(@"              step: 0.1,
                                size: ""xs"",
                                stars: ""5"",
                                showClear: false,
                                readonly: true,
                                starCaptions: function (val) {
                                    return val;
                                }
                            });
                            $('#rateSPModal').modal('show');
                        }
                        else if (respo.status != ""error""){
                            $(""#modelserviceprovidernamerated"").html(respo.result.serviceProvider.firstName + respo.result.serviceProvider.lastName);
                            $(""#rateedspmodel"").modal('show');
                        }

                    }
                });
            }

            function submitrating() {

                var one = $(""#ontimearrival"").val();
                var two = $(""#Friendly"").val();
                var three = $");
                WriteLiteral(@"(""#Qualityofservice"").val();

                var totalrating = Math.round((parseFloat(one) + parseFloat(two) + parseFloat(three)) * 10 / 3) / 10


                var userratings = {
                    serviceRequestId: $(""#hiddenServiceRequestId"").val(),
                    ratingTo : $(""#hiddenserviceproviderid"").val(),
                     ratingFrom : $(""#hiddenuserid"").val(),
                    onTimeArrival: $(""#ontimearrival"").val(),
                    friendly: $(""#Friendly"").val(),
                    qualityOfService: $(""#Qualityofservice"").val(),
                    comments: $(""#txtFeedbackToSP"").val(),
                    ratings: totalrating

                };

                $.ajax({
                    url: '/customer/submitratings',
                    type: 'post',
                    data: userratings,
                    datatype: ""json"",
                    cache: false,

                    success: function (resp) {

                        if (resp) {
 ");
                WriteLiteral(@"                           $('#rateSPModal').modal('hide');
                            location.reload();
                        }

                    }
                });


        }
        $(""#moelratedok"").click(function () {
            $(""#rateedspmodel"").modal(""hide"");
        });

    </script>
    <script src=""https://cdn.datatables.net/buttons/2.1.0/js/dataTables.buttons.min.js""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/pdfmake.min.js""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/vfs_fonts.js""></script>
    <script src=""https://cdn.datatables.net/buttons/2.1.0/js/buttons.html5.min.js""></script>
    <script src=""https://cdn.datatables.net/buttons/2.1.0/js/buttons.print.min.js""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js""></script>
    <script src=""https://cdn.datata");
                WriteLiteral("bles.net/buttons/2.1.0/js/dataTables.buttons.min.js\"></script>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
