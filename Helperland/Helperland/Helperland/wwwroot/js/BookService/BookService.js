
/*global variable*/
var ExtraservicedCheckedcount = 0;
var basictime = 3;
var totaltime;
var _servicehourlyRate = 18;

/*tab-1*/
function checkAvailability() {

    var zipcode = document.getElementById('txtzipcode').value.trim();

    if ($("#txtzipcode").val() == "") {
        document.getElementById('spn_error_zipcode').innerHTML = "Enter Postal Code";
    }
    else if (zipcode.length == 6) {
        $("#loader").addClass("is-active");
        $.ajax({
            type: 'Post',
            url: '/home/CheckPostalCode',
            data: { "postalcode": zipcode },
            success: function (respo) {
                if (respo) {

                    $("#loader").removeClass("is-active");
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
            error: function (err) {
                $("#loader").removeClass("is-active");
                console.log(err);
            }
        });

    }
    else {
        document.getElementById('spn_error_zipcode').innerHTML = "Enter Valid Postal Code";
    }
}

/*tab - 2*/
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
    document.getElementById('pills-details').classList.add("show");
    document.getElementById('pills-details').classList.add("active");
    document.getElementById('pills-schedule-tab').classList.add("fill");
    document.getElementById('pills-profile-tab').classList.remove("disabled");
    $('#pills-profile-tab').tab('show');

    getalladdressbyuserID(userid);
    FillCityDropdown();
}

function getDate() {
    var today = new Date();
    today.setDate(today.getDate() + 1)
    var nextDate = today.getFullYear().toString() + "-" + AppendZero((today.getMonth() + 1).toString()) + "-" + AppendZero(today.getDate().toString());
    console.log(nextDate);
    document.getElementById("txtFromDate").value = nextDate;
    $("#ppytime_time").html(AppendZero(today.getDate().toString()) + "-" + AppendZero((today.getMonth() + 1).toString()) + "-" +  today.getFullYear().toString() + " " + $("#drpselecttime option:selected").text());
    $("#txtFromDate").attr("min", (today.getFullYear().toString() + "-" + AppendZero((today.getMonth() + 1).toString()) + "-" + AppendZero(today.getDate().toString())));
}

function setdate(inputDate) {
    const date = new Date(inputDate);
    document.getElementById("datechange").value = AppendZero(date.getDate().toString()) + "/" + AppendZero((date.getMonth() + 1).toString()) + "/" + AppendZero(date.getFullYear().toString());
    return AppendZero(date.getDate().toString()) + "/" + AppendZero((date.getMonth() + 1).toString()) + "/" + AppendZero(date.getFullYear().toString());
}

function AppendZero(input) {
    if (input.length == 1) {
        return '0' + input;
    }
    return input;
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
var tempselecttime;
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
    
    console.log($('#ddlselecttime :selected').val());
    console.log(temptime);
    debugger;

    if (totaltime > selecttime) {
        console.log("invalid");
        tempselecttime = $('#ddlselecttime :selected').val();
        $('#validtimemodel').modal('show');
    }
    else {
        console.log("valid");
    }

    chnageDate();
    totalpaymentfunc();
    checkingtime();
    tempcheckedcount = 0;
});

function btnclearextraservice() {
    debugger;
    if (tempselecttime == 3.00) {
        var inputcheckbox = document.getElementsByClassName("Excheckbox");
        count = 0
        for (var i = 0; i <= 4; i++) {
            if (inputcheckbox[i].checked) {
                $('.Excheckbox').prop('checked', false); // Unchecks it
                count++;
                $("#ex_services").html("");
            }
        }
        $("#ddlselecttime").val(3.00);
        $("#total_time span").html(3.00 + "hrs");
        $('#validtimemodel').modal('hide');
    }
    else {
        $('#validtimemodel').modal('hide');
    }
}

function chnageDate() {


    basictime = parseFloat($("#ddlselecttime option:selected").val());
    $("#basictime span").html(basictime + "hrs");
    $("#total_time span").html(basictime + "hrs");

}

function chnagebasictimeanddate() {
    var chnagedate = new Date($("#txtFromDate").val());

    $("#ppytime_time").html(AppendZero(chnagedate.getDate().toString()) + '-' + AppendZero((chnagedate.getMonth() + 1).toString()) + '-' + chnagedate.getFullYear() + " " + $("#drpselecttime option:selected").text())



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

    $("#ddlselecttime").val(totaltime);
}

function checktotalExtraservicechecked() {
    var inputcheckbox = document.getElementsByClassName("Excheckbox");
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

/*tab -3*/
function SaveNewAddress() {
    debugger;
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
                    debugger;
                    var newaddress = {}
                    newaddress.userid = $("#userid").val();
                    newaddress.StreetName = $("#Street_name").val()
                    newaddress.Housenumber = $("#House_number").val();
                    newaddress.City = $("#City").val();
                    newaddress.PostalCode = $("#inpcurrentpostalcode").val();
                    newaddress.MobileNumber = $("#Phone_Number").val();
                    console.log(newaddress + "new address");
                    $("#loader").addClass("is-active");
                    $.ajax({
                        url: '/Home/AddCustomerUserAddress',
                        type: 'post',
                        dataType: 'json',
                        contentType: 'application/json',
                        data: JSON.stringify(newaddress),
                        success: function (resp) {
                            $("#loader").removeClass("is-active");
                            if (resp) {
                                getalladdressbyuserID(newaddress.userid);
                                clearnewaddressdetail();
                                $(".btnaddress").removeClass(" d-none");
                                $(".btnaddress").addClass(" d-block");

                                $(".newAddress").addClass(" d-none");
                                
                            }
                        },
                        error: function (err) {
                            $("#loader").removeClass("is-active");
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
    $("#loader").addClass("is-active");
    $.ajax({
        type: "POST",
        url: '/home/FillCityDropdown',
        data: { "postalcode": postalcode },
        success: function (respo) {
            $("#loader").removeClass("is-active");
            $("#City").empty();
            respo.forEach((city) => $('#City').append($("<option></option>").val(city.cityName).html(city.cityName)));
        },
        error: function (err) {
            $("#loader").removeClass("is-active");
            console.log(err);
        }
    })
}

function getalladdressbyuserID(userid) {
    debugger;
    console.log($("#txtzipcode").val());
    $("#useraddress").load('/Home/GetAddressByUserID?userId=' + userid + '&postalcode=' + $("#txtzipcode").val());
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
    $('#inpcurrentpostalcode').val($("#txtzipcode").val());
    $("#loader").addClass("is-active");
    $.ajax({
        type: "POST",
        url: "/home/FillCityDropdown",
        success: function (res) {
            $("#loader").removeClass("is-active");
            $.each(res.d, function (data, value) {

                $("#ddlNationality").append($("<option></option>").val(value.CountryId).html(value.CountryName));
            })
        },
        error: function (err) {
            $("#loader").removeClass("is-active");
            console.log(err);
        }
    });
}

function clearnewaddressdetail() {
    document.getElementById("Street_name").value = "";
    document.getElementById("House_number").value = "";
    document.getElementById("Phone_Number").value = "";
}

function btnAddAddresstab() {
    document.getElementById('pills-payment').classList.add("show");
    document.getElementById('pills-payment').classList.add("active");
    document.getElementById('pills-profile-tab').classList.add("fill");
    $('#pills-payment-tab').tab('show');
}

//tab 4

function completbooking() {

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
    completebooking.serviceStartDate = $("#txtFromDate").val();
    completebooking.serviceStarttime = $("#drpselecttime option:selected").text();
    completebooking.servicehourlyRate = _servicehourlyRate;
    completebooking.serviceHours = parseFloat($("#ddlselecttime").val());
    completebooking.extraHours = (ExtraservicedCheckedcount * 0.5);
   
    completebooking.extraservicesName = [];
    $('input[name="Excheckbox"]').each(function () {
        if (this.checked) {
            completebooking.extraservicesName.push(this.value);
        }
    });
    //  console.log(totaltime);
    totalamount = (parseFloat($("#ddlselecttime option:selected").val()) * _servicehourlyRate);
    completebooking.subtotal = totalamount;
    completebooking.totalcost = totalamount;
    completebooking.comments = $("#txtcomment").val();
    completebooking.haspets = $("#chkHasPet").prop('checked');



    //tab-3
    completebooking.userAddressID = $('input[name=UserAddress]:checked').attr("id");

    //tab-4
    completebooking.paymentdone = true;

    // completebooking.serviceHours = $("#ddlselecttime option:selected").val();

    console.log(ExtraservicedCheckedcount);
    console.log(totaltime);
    console.log(completebooking);


    if (document.getElementById("spncardnumbervalidation").innerHTML == "" &&
        document.getElementById("spncardexpairedvalidation").innerHTML == "" &&
        document.getElementById("spncardCVCvalidation").innerHTML == "" &&
        document.getElementById("chktermsandcondion").checked) {
        $("#loader").addClass("is-active");
        $.ajax({
            
            url: '/Home/Completbooking',
            type: 'post',
            dataType: 'json',
            contentType: 'application/json',
            data: JSON.stringify(completebooking),
            success: function (resp) {
                console.log(resp)
                $("#loader").removeClass("is-active");
                if (resp) {
                    $("#CompletBooking").modal('show');
                    $("#serviceID").html(resp.serviceRequestID);
                }
            },
            error: function (err) {
                $("#loader").removeClass("is-active");
                console.log(err);
            }
        });
    }
}