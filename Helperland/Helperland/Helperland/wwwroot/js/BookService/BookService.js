///*const { error } = require("jquery");

/*global variable*/
var ExtraservicedCheckedcount = 0;
var basictime = 3;
var totaltime;
var _servicehourlyRate = 18;

function checkAvailability() {
    var zipcode = document.getElementById('txtzipcode').value.trim();
    if (zipcode.length == 6) {
        $.ajax({
            //type: 'Post',
            //url: '/home/CheckPostalCode',
            //data: { "postalcode": zipcode },
            //success: function (respo) {

            //},
            //error: function (respo) {
            //    alert('error:' + respo.responseText);
            //}

            type: 'Post',
            url: '/home/CheckPostalCode',
            data: { "postalcode": zipcode },
            success: function (respo) {
                if (respo) {


                    document.getElementById('pills-home-tab').classList.add("fill");
                    document.getElementById('pills-schedule-tab').classList.remove("disabled");
                    document.getElementById('pills-paln').classList.add("show");
                    document.getElementById('pills-paln').classList.add("active");
                    $('#pills-schedule-tab').tab('show');

                    getDate();
                    //time
                    $("#basictime span").html(3 + 'hrs');
                    $("#total-time span").html(3 + 'hrs');

                    //change
                    $("#singal-charg span").html(54 + '€');
                    $("#total-charg span").html(54 + '€');
                    /*sum += parseInt($(this).html());*/

                }
                else {
                    document.getElementById('spn_error_zipcode').innerHTML = "We are not providing service in this area. We’ll notify you if any Helper would start working near your area!!";
                }
            },
            error: function (respo) {
                alert('error:' + respo.responseText);
            }
        });

    }
    else {
        document.getElementById('spn_error_zipcode').innerHTML = "Enter Postal Code";
    }
}
function btnsetuptab() {
    document.getElementById('pills-schedule-tab').classList.add("disabled");
    document.getElementById('pills-profile-tab').classList.add("disabled");
    document.getElementById('pills-payment-tab').classList.add("disabled");

    document.getElementById('pills-schedule-tab').classList.remove("fill");
    document.getElementById('pills-profile-tab').classList.remove("fill");
}
function btnscheduleuptab() {
    document.getElementById('pills-profile-tab').classList.add("disabled");
    document.getElementById('pills-payment-tab').classList.add("disabled");

    document.getElementById('pills-profile-tab').classList.remove("fill");
}
function btndetailstab() {

    document.getElementById('pills-payment-tab').classList.add("disabled");
}
function btntotalservices(userid) {
    //$ajax({
    //    type: "post",
    //    url:

    //})

    document.getElementById('pills-details').classList.add("show");
    document.getElementById('pills-details').classList.add("active");
    document.getElementById('pills-schedule-tab').classList.add("fill");
    document.getElementById('pills-profile-tab').classList.remove("disabled");
    $('#pills-profile-tab').tab('show');


    getalladdressbyuserID(userid);
    FillCityDropdown();


}

$(".btnCancel").click(function () {
    $(".btnaddress").removeClass(" d-none");
    $(".btnaddress").addClass(" d-block");

    $(".newAddress").addClass(" d-none");
});

$(".btnaddress").click(function () {
    $(this).addClass(" d-none");
    $(".newAddress").removeClass(" d-none");
    $(".newAddress").addClass(" d-block");
});

function btnNewAddress() {
    /*$('#inpcurrentpostalcode').html($("#txtzipcode").val());*/
    $('#inpcurrentpostalcode').val($("#txtzipcode").val());
    /* alert($('#txtzipcode').val());*/

    $.ajax({
        type: "POST",
        url: "/home/FillCityDropdown",
        success: function (res) {
            $.each(res.d, function (data, value) {

                $("#ddlNationality").append($("<option></option>").val(value.CountryId).html(value.CountryName));
            })
        }

    });
}

function getDate() {
    var today = new Date();
    nextday = today.getDate() + 1;
    document.getElementById("txtFromDate").value = today.getFullYear() + '-' + ('0' + (today.getMonth() + 1)) + '-' + (nextday);

    $("#ppytime_time").html((nextday) + '-' + ('0' + (today.getMonth() + 1)) + '-' + today.getFullYear() + $("#drpselecttime option:selected").text());
    $("#txtFromDate").attr("min", (today.getFullYear() + '-' + ('0' + (today.getMonth() + 1)) + '-' + (nextday)));
}

$("#txtFromDate").change(function () {
    chnagebasictimeanddate();
    totalpaymentfunc();

});
$("#drpselecttime").change(function () {
    chnagebasictimeanddate();
    // totalpaymentfunc();
    checkingtime();
});

$("#ddlselecttime").change(function () {

    var inputcheckbox = document.getElementsByClassName("Excheckbox");
    var tempcheckedcount = 0;
    for (var i = 0; i <= 4; i++) {
        if (inputcheckbox[i].checked) {
            tempcheckedcount++;
        }

    }
    temptime = totaltime - (tempcheckedcount * 0.5) + 3;
    selecttime = $('#ddlselecttime :selected').val();

    //console.log(temptime);
    console.log($('#ddlselecttime :selected').val());
    console.log(temptime);


    if (temptime > selecttime) {
        console.log("invalid");
    }
    else {
        console.log("valid");
    }

    chnageDate();
    totalpaymentfunc();
    checkingtime();
    tempcheckedcount = 0;
});

//$('#txtFromDate').change(function () {
//    //fillServiceDateTimePaymentSummary();
//    alert("hrllo");
//});
//$('#ddlselecttime').change(function () {
//    //fillServiceDateTimePaymentSummary();
//    //checkServiceTimeLimit   
//    alert("hrllo");
//});

function chnageDate() {


    basictime = parseFloat($("#ddlselecttime option:selected").val());
    $("#basictime span").html(basictime + "hrs");
    $("#total_time span").html(basictime + "hrs");

}

function chnagebasictimeanddate() {
    var chnagedate = new Date($("#txtFromDate").val());

    $("#ppytime_time").html((chnagedate.getDate()) + '-' + ('0' + (chnagedate.getMonth() + 1)) + '-' + chnagedate.getFullYear() + $("#drpselecttime option:selected").text())



}

$('.Excheckbox').click(function () {
    var inputcheckbox = document.getElementsByClassName("Excheckbox");;
    var htmlcontent = "";
    var count = 0;
    for (var i = 0; i <= 4; i++) {

        if (inputcheckbox[i].checked) {
            htmlcontent += '<p class="tmp-time extra" id="ex_">' + inputcheckbox[i].value + ' <span class="text-right">30min</span></p>'
            count++;
        }

    }
    //totalcharg = 75 + (13 * count);
    //alert(count);
    if (htmlcontent == "") {
        $("#ex_services").html("");
    }
    else {
        $("#ex_services").html(' <label class="fw-bold" id="ex">Extras</label>' + htmlcontent);
    }

    // if ($(this).is(":checked")) {
    ////    //total time
    //   totaltime += 0.5;
    ////    //total change
    ////    /*totalcharg += 13;*/
    //}
    //else {
    //    totaltime -= 0.5;
    ////    //total change
    ////     totalcharg -= 9;
    ////     alert(totaltime);
    //}
    totalpaymentfunc();
    checkingtime();
});


function totalpaymentfunc() {

    totaltime = basictime


    var totalpayment;
    var inputcheckbox = document.getElementsByClassName("Excheckbox");
    for (var i = 0; i <= 4; i++) {
        if (inputcheckbox[i].checked) {
            totaltime += 0.5;

        }

        totalpayment = totaltime * _servicehourlyRate;



    }
    $("#total_time span").html(totaltime + 'hrs');
    $("#singal-charg span").html(totalpayment + '€');
    $("#total-charg span").html(totalpayment + '€');
    /* console.log($("#ddlselecttime [value= " + totaltime + "]").attr('selected', 'true'));*/
    /*$('select[name="ddlselecttime"]').find(parseFloat('option[value="' + totaltime + '"]')).attr("selected", true);*/
    /*$('select[name="ddlselecttime"]').find('option[value=' + 122 + ']'.toString().trim()).attr("selected", true);*/
    //debugger;
    /*$('select[name="ddlselecttime"]').find('.ddlselecttimevalue[value="' + totaltime + '"]'.toString().trim()).attr("selected", true);*/
    $("#ddlselecttime").val(totaltime);
}

function checktotalExtraservicechecked() {
    var inputcheckbox = document.getElementsByClassName("Excheckbox");;
    for (var i = 0; i <= 4; i++) {
        if (inputcheckbox[i].checked) {
            ExtraservicedCheckedcount++;
        }

    }

}

function checkingtime() {

    var time1 = $("#drpselecttime").val();
    var time2 = $("#ddlselecttime").val();

    checkingtotaltime = parseInt(time1) + totaltime;
    if (checkingtotaltime > 21) {
        $("#errormessage").text("Could not completed the service request, because service booking request is must be completed within 21: 00 time");
        $("#btntotalservices").addClass("disabled");
        console.log("working");
    }
    else {
        $("#errormessage").text("");
        $("#btntotalservices").removeClass("disabled");
    }
}


function SaveNewAddress() {
    debugger;


    //if ($("#spnstreetnameerror").html("") != "") {
    //    $("#spnstreetnameerror").html("Please enter the Streetname").fadeIn(1000);
    //    if ($("#House_number").html("") != "") {
    //        $("#spnhousenumbererror").html("Please enter the Housenumber").fadeIn(1000);

    //        if ($("#Phone_Number").html("") != "") {
    //            $("#spnmobilenumbererror").html("Please enter the MobileNumber").fadeIn(1000);
    //        }
    //        else {
    //            $("#spnmobilenumbererror").html("");
    //        }
    //    }
    //    else {
    //        $("#spnhousenumbererror").html("");
    //    }
    //}
    //else {
    //    /* $("#spnstreetnameerror").html("");*/


    //    }

    if (document.getElementById("Street_name").value.length > 0) {
        document.getElementById("spnstreetnameerror").innerHTML = "";
        if (document.getElementById("House_number").value.length > 0) {
            document.getElementById("spnhousenumbererror").innerHTML = "";
            if (document.getElementById("Phone_Number").value.length > 0) {
                if (document.getElementById("Phone_Number").value.length < 10) {
                    document.getElementById("spnmobilenumbererror").innerHTML = "Enter valid Mobile number!!";
                    document.getElementById("spnstreetnameerror").innerHTML = "";
                    document.getElementById("spnhousenumbererror").innerHTML = "";
                }
                else {
                    document.getElementById("spnmobilenumbererror").innerHTML = "";

                    var newaddress = {}
                    newaddress.userid = $("#userid").val();
                    newaddress.StreetName = $("#Street_name").val()
                    newaddress.Housenumber = $("#House_number").val();
                    newaddress.City = $("#City").val();
                    newaddress.inpcurrentpostalcode = $("#inpcurrentpostalcode").val();
                    newaddress.PhoneNumber = $("#Phone_Number").val();
                    console.log(newaddress);

                    $.ajax({
                        url: '/Home/AddCustomerUserAddress',
                        type: 'post',
                        dataType: 'json',
                        contentType: 'application/json',
                        data: JSON.stringify(newaddress),
                        success: function (resp) {
                            //   reset addressform
                            //AddressBox(false);
                            //FillCustomerAddressList();
                            if (resp) {
                                getalladdressbyuserID(newaddress.userid);
                                clearnewaddressdetail();
                                $(".btnaddress").removeClass(" d-none");
                                $(".btnaddress").addClass(" d-block");

                                $(".newAddress").addClass(" d-none");
                                alert("success");
                            }
                            else {
                                alert("erorr");
                            }

                        },
                        error: function (err) {
                            console.log(err);
                        }
                    });
                }
            }
            else {
                document.getElementById("spnmobilenumbererror").innerHTML = "Enter Mobile number!!";
                document.getElementById("spnstreetnameerror").innerHTML = "";
                document.getElementById("spnhousenumbererror").innerHTML = "";
            }
        }
        else {
            document.getElementById("spnhousenumbererror").innerHTML = "Enter House number!!";
            document.getElementById("spnstreetnameerror").innerHTML = "";
            document.getElementById("spnmobilenumbererror").innerHTML = "";
        }
    }
    else {
        document.getElementById("spnstreetnameerror").innerHTML = "Enter Street name!!";
        document.getElementById("spnhousenumbererror").innerHTML = "";
        document.getElementById("spnmobilenumbererror").innerHTML = "";
    }

}

function FillCityDropdown() {
    var postalcode = $('#txtzipcode').val();

    $.ajax({
        type: "POST",
        url: '/home/FillCityDropdown',
        data: { "postalcode": postalcode },
        success: function (respo) {
            $("#City").empty();
            respo.forEach((city) => $('#City').append($("<option></option>").val(city.cityName).html(city.cityName)));
        }
    })
}

//$("#EmptyAddress").load(function () {
//    alert("disable");
//    $("#btnaddressbookservice").addClass("disabled");
//});
//$("#btnaddressbookservice").click(function () {
//    $("#EmptyAddress").load
//})

function getalladdressbyuserID(userid) {
    $("#useraddress")
        .load('/Home/GetAddressByUserID?userId=' + userid);
}
function clearnewaddressdetail() {

    document.getElementById("Street_name").value = "";
    document.getElementById("House_number").value = "";
    document.getElementById("Phone_Number").value = "";

}

//tab 4
//$("btnselectedaddress").click(function () {
//    $('#pills-payment-tab').tab('show');
//});

function btnAddAddresstab() {
    document.getElementById('pills-payment').classList.add("show");
    document.getElementById('pills-payment').classList.add("active");
    document.getElementById('pills-profile-tab').classList.add("fill");
    $('#pills-payment-tab').tab('show');




}
function completbooking() {
    debugger;
    var cardNumberRegularExpressionPattern = new RegExp("^[0-9]{16}$");
    var cardExpairedRegularExpressionPattern = new RegExp("^[0-9]{4}$");
    var cardCVCRegularExpressionPattern = new RegExp("^[0-9]{3}$");
    if ($("#cardnumber").val() == "") {
        document.getElementById("spncardnumbervalidation").innerHTML = "Please enter the Cardnumber";

    }
    else if (!cardNumberRegularExpressionPattern.test($("#cardnumber").val())) {
        document.getElementById("spncardnumbervalidation").innerHTML = "Please enter the valid number(16 digit)";
    }
    else {
        document.getElementById("spncardnumbervalidation").innerHTML = "";
    }


    if ($("#cardexpaired").val() == "") {
        document.getElementById("spncardexpairedvalidation").innerHTML = "Please enter the cardexpired";
    }
    else if (!cardExpairedRegularExpressionPattern.test($("#cardexpaired").val())) {
        document.getElementById("spncardexpairedvalidation").innerHTML = "Please Enter the Valid MM/YY(4 digit)";
    }
    else {
        document.getElementById("spncardexpairedvalidation").innerHTML = "";
    }
    if ($("#cardCVC").val() == "") {
        document.getElementById("spncardCVCvalidation").innerHTML = "Please enter the CardCVC";
    }
    else if (!cardCVCRegularExpressionPattern.test($("#cardCVC").val())) {
        document.getElementById("spncardCVCvalidation").innerHTML = "Please Enter the Valid CVC(3 digit)";
    }
    else {
        document.getElementById("spncardCVCvalidation").innerHTML = "";
    }
    if ($("#chktermsandcondion").checked) {
        document.getElementById("checktermsandcondtionerror").innerHTML = "";
    }
    else {
        document.getElementById("checktermsandcondtionerror").innerHTML = "(* Required field)";
    }

    /*checktotalExtraservicechecked();*/
    checktotalExtraservicechecked();
    var completebooking = {}
    //common data
    completebooking.userid = $("#userid").val();

    //tab-1
    completebooking.zipcode = $("#txtzipcode").val();

    //tab-2
    completebooking.serviceDate = $("#txtFromDate").val();
    completebooking.serviceTime = $("#drpselecttime option:selected").text();
    completebooking.servicehourlyRate = _servicehourlyRate;
    completebooking.serviceHours = (parseFloat($("#ddlselecttime").val()) - (ExtraservicedCheckedcount * 0.5));
    completebooking.extraHours = (ExtraservicedCheckedcount * 0.5);

    completebooking.extraServicecName = [];
    $('input[name="Excheckbox"]').each(function () {
        if (this.checked) {
            completebooking.extraServicecName.push(this.value);
        }
    });
    //  console.log(totaltime);
    totalamount = (parseFloat($("#ddlselecttime option:selected").val()) * _servicehourlyRate);
    completebooking.subtotal = totalamount;
    completebooking.totalcost = totalamount;
    completebooking.comment = $("#txtcomment").val();
    completebooking.haspets = $("#chkHasPet").prop('checked');


    //tab-3
    completebooking.addressid = $('input[name=UserAddress]:checked').attr("id");

    //tab-4
    completebooking.paymentdone = true;

    // completebooking.serviceHours = $("#ddlselecttime option:selected").val();

    console.log(ExtraservicedCheckedcount);
    console.log(totaltime);

   

    if (document.getElementById("spncardnumbervalidation").innerHTML == "" &&
        document.getElementById("spncardexpairedvalidation").innerHTML == "" &&
        document.getElementById("spncardCVCvalidation").innerHTML == "" &&
        document.getElementById("chktermsandcondion").checked) {
       
        $.ajax({
            url: '/Home/Completbooking',
            type: 'post',
            dataType: 'json',
            contentType: 'application/json',
            data: JSON.stringify(completebooking),
            success: function (resp) {
                console.log(resp)
                if (resp) {
                   
                    $("#CompletBooking").modal('show');
                    $("#serviceID").html(resp.ServiceRequestID);
                   

                }
               


            },
            error: function (err) {
                console.log(err);
            }
        });
    }
}