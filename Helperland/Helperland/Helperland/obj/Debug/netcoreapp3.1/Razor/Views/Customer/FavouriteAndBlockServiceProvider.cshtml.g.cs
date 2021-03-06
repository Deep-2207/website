#pragma checksum "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Customer\FavouriteAndBlockServiceProvider.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7d46d79e3c7db56a88b23c10b1b811e678b8d544"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_FavouriteAndBlockServiceProvider), @"mvc.1.0.view", @"/Views/Customer/FavouriteAndBlockServiceProvider.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7d46d79e3c7db56a88b23c10b1b811e678b8d544", @"/Views/Customer/FavouriteAndBlockServiceProvider.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b4b1c47201b9aa2787e6cec5b59d0d5213a1108", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_FavouriteAndBlockServiceProvider : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Customer\FavouriteAndBlockServiceProvider.cshtml"
  
    Layout = "~/Views/Shared/UserLayout.cshtml";
    ViewData["Title"] = "BlockCustomer";
    var user = Context.Session.GetString("User");
    SessionUser sessionUser = new SessionUser();

    if (user != null)
    {
        sessionUser = JsonConvert.DeserializeObject<SessionUser>(user);
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"customer-table  dvblockcustomer custfb\">\r\n    <input type=\"hidden\" id=\"hiddenuserid\"");
            BeginWriteAttribute("value", " value=\"", 408, "\"", 435, 1);
#nullable restore
#line 13 "F:\PSD TO HTML\website\Helperland\Helperland\Helperland\Views\Customer\FavouriteAndBlockServiceProvider.cshtml"
WriteAttributeValue("", 416, sessionUser.UserID, 416, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n    <input type=\"hidden\" id=\"hiddenServiceRequestId\"");
            BeginWriteAttribute("value", " value=\"", 493, "\"", 501, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n    <input type=\"hidden\" id=\"hiddenserviceproviderid\"");
            BeginWriteAttribute("value", " value=\"", 560, "\"", 568, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n    <table id=\"example\" class=\"display customer-table blockcustomer\" style=\"width:100%\">\r\n        <thead class=\"d-none\">\r\n            <tr>\r\n                <th>Service ID <img");
            BeginWriteAttribute("alt", " alt=\"", 749, "\"", 755, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"sorting-img\"></th>\r\n                <th>Service data <img");
            BeginWriteAttribute("alt", " alt=\"", 821, "\"", 827, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"sorting-img\"></th>\r\n                <th class=\"cus-dait\">Customer details <img");
            BeginWriteAttribute("alt", " alt=\"", 914, "\"", 920, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"sorting-img\"></th>\r\n\r\n                <th>Customer ratings<img");
            BeginWriteAttribute("alt", " alt=\"", 991, "\"", 997, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"sorting-img\"></th>\r\n                <th>buttons<img");
            BeginWriteAttribute("alt", " alt=\"", 1057, "\"", 1063, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"sorting-img\"></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody class=\"row row-cols-1 row-cols-md-2 g-4 mt-0\">\r\n        </tbody>\r\n    </table>\r\n</div>\r\n\r\n\r\n");
            DefineSection("UserLayoutSection", async() => {
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

                ""bFilter"": false, //hide Search bar
                ""pagingType"": ""full_numbers"",
                paging: true,
                ""pagingType"": ""full_numbers"",
                // bFilter: false,
                ordering: true,
                searching: false,
                info: true,

                ""oLang");
                WriteLiteral(@"uage"": {
                    ""sInfo"": ""Total Records: _TOTAL_""
                },
                ""dom"": 'Bt<""top"">rt<""bottom""lip><""clear"">',
                responsive: true,
                ""order"": [],

            });
        });

        $(document).ready(function () {
            loaddata();

        });

        function loaddata() {
            $(""#loader"").addClass(""is-active"");
            $.ajax({
                url: '/customer/getspforcust',
                type: 'post',

                success: function (respo) {
                    $(""#loader"").removeClass(""is-active"");
                    $('#example').DataTable().clear();

                    console.log(respo);
                    respo.forEach(function (element) {
                        var t = $('#example').DataTable();
                        //var btnbandu;
                        //debugger;
                        //if (element.blockeduser != null) {
                        //    btnnbandu = '<button cl");
                WriteLiteral(@"ass=""btn btn-danger btn-Accept btn-rounded-17 btn-blockUnblock"" onclick=""BlockUnBlockAndFavUnFav(' + element.customeruserid + ')"" value=""UnBlock"">UnBlock</button>'
                        //}
                        //else {
                        //    btnnbandu = '<button class=""btn btn-danger btn-tomato btn-rounded-17 btn-blockUnblock"" onclick=""BlockUnBlockAndFavUnFav(' + element.customeruserid + ')"" value=""Block"">Block</button>'
                        //}
                        var spratingsinput;
                        if (element.spratings != null) {
                            spratingsinput = '<input required class= ""ratingspdashboard d-none""  value = ""' + element.spratings + '"" type = ""text"" title = """" > ';
                        }
                        else {
                            spratingsinput = 'Not Rated';
                        }
                        var btnblock;
                        var btnfav;
                        if (element.spfavblock != null) {
      ");
                WriteLiteral(@"                      if (element.spfavblock.isBlocked == false) {
                                btnblock = '<button class=""btn btn-danger btn-tomato btn-rounded-17 btn-blockUnblock"" onclick=""BlockUnBlockAndFavUnFav(' + element.spid + ',' + element.spfavblock.isFavorite + ',true)"" value=""Block"">Block</button>'
                            }
                            else {
                                btnblock = '<button class=""btn btn-danger btn-Accept btn-rounded-17 btn-blockUnblock"" onclick=""BlockUnBlockAndFavUnFav(' + element.spid + ',' + element.spfavblock.isFavorite + ',false)"" value=""UnBlock"">UnBlock</button>'
                            }

                            if (element.spfavblock.isFavorite == false) {
                                btnfav = '<button class=""btn btn-danger btn-tomato btn-rounded-17 btn-blockUnblock"" onclick=""BlockUnBlockAndFavUnFav(' + element.spid + ',true,' + element.spfavblock.isBlocked + ')"" value=""Block"">Fav</button>'
                            }
      ");
                WriteLiteral(@"                      else {
                                btnfav = '<button class=""btn btn-danger btn-Accept btn-rounded-17 btn-blockUnblock"" onclick=""BlockUnBlockAndFavUnFav(' + element.spid + ',false,' + element.spfavblock.isBlocked + ')"" value=""UnBlock"">UnFav</button>'
                            }
                        }
                        else {
                            btnblock = '<button class=""btn btn-danger btn-tomato btn-rounded-17 btn-blockUnblock"" onclick=""BlockUnBlockAndFavUnFav(' + element.spid + ',false,true)"" value=""Block"">Block</button>'
                            btnfav = '<button class=""btn btn-danger btn-tomato btn-rounded-17 btn-blockUnblock"" onclick=""BlockUnBlockAndFavUnFav(' + element.spid +',true,false)"" value=""Block"">Fav</button>'
                        }
                        t.row.add([
                            '<img src=""../' + element.spprofile + '"" alt=""Alternate Text"" />',
                            element.spName,
                            'Ser");
                WriteLiteral(@"vices' + element.spservicecount,
                            spratingsinput,
                            btnblock + "" "" + btnfav
                        ]).draw(false);
                    });
                }
            });
        }
       
        function BlockUnBlockAndFavUnFav(spid, isfav, isblock) {
            debugger;
            var bfsp = {}
            bfsp.spid = spid;
            bfsp.isfav = isfav;
            bfsp.isblock = isblock;
            $(""#loader"").addClass(""is-active"");
            $.ajax({
                url: '/customer/FavAndBlock',
                type: 'post',
                dataType: 'json',
                contentType: 'application/json',
                data: JSON.stringify(bfsp),
                success: function (respo) {
                    $(""#loader"").removeClass(""is-active"");
                    $('#example').DataTable().clear();

                    console.log(respo);
                    location.reload();
                    //  $("".bt");
                WriteLiteral("n-blockUnblock\").html(\"Unblock\");\r\n                }\r\n            });\r\n\r\n        }\r\n\r\n    </script>\r\n");
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
