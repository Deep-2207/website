/*/*const { ajax } = require("jquery");*/

function modelpopp(id) {
   // $('#trmodel').modal('show');
    //var pdpArr = [];
    //debugger;
    //$('.cptabletr').each(function () {
    //    pdpArr.push($(this).data('pdp-id'));
    //});
    //console.log(pdpArr);
    //var data = {}
    //var currentRow = $("#example").closest("tr");
    //data.serviceid = currentRow.find("td:eq(0)").html();
    ///*find("td:eq(0)").text();*/
    //console.log(data);
   // var serviceid = currentRow.find("td:eq(0)").text();
   // console.log(serviceid)
   
}
//$('.tdclick').click(function () {
//    var serviceid = $(this).find("td").eq(0).html();
//    var serviceDetails = $(this).find("td").eq(1).html();
//    var serviceprovider = $(this).find("td").eq(2).html();
//    var serviceprice = $(this).find("td").eq(3).html();

//    document.getElementById("srid").innerHTML = serviceid;
//    document.getElementById("d&t").innerHTML = serviceDetails;
//    document.getElementById("sp").innerHTML = serviceprovider;
//    document.getElementById("price").innerHTML = serviceprice;


//    console.log(servicerequestid);
   

//});

$(".btnReschedule").click(function () {
    $('#rechedual').modal('show');
    //$.ajax({
    //    type: 'Post',
    //    url: '/customer/dispaydataformtheserviceid',
    //    data: { "servicerequestid": servicerequestid },
    //    success: function (respo) {
})


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

function showservicerequestdetailmodel(id, index) {
    $("#trmodel").modal("show");
    $("#hiddenServiceRequestId").val(id);
    console.log($("#hiddenServiceRequestId").val(id));

    $.ajax({
        type: 'Post',
        url: '/customer/dispaydataformtheserviceid',
        data: { "servicerequestid": id },
        success: function (respo) {
            console.log(respo);
            debugger;
            document.getElementById("d&t").innerHTML = respo.user.serviceStartDate;
            document.getElementById("duration").innerHTML = respo.user.serviceHours;
            document.getElementById("srid").innerHTML = respo.user.serviceRequestId;
            document.getElementById("extra").innerHTML = respo.serviceRequestExtraName;
            document.getElementById("price").innerHTML = respo.user.totalCost;
            document.getElementById("serviceaddress").innerHTML = respo.user.serviceRequestAddresses[0].addressLine1 +
                respo.user.serviceRequestAddresses[0].addressLine2 +
                respo.user.serviceRequestAddresses[0].postalCode +
                respo.user.serviceRequestAddresses[0].city;
            document.getElementById("phonenumber").innerHTML = respo.user.serviceRequestAddresses[0].mobile;
            document.getElementById("email").innerHTML = respo.user.serviceRequestAddresses[0].email;
            document.getElementById("comments").innerHTML = respo.user.comments;
            if (respo.user.hasPets == true) {
                document.getElementById("pet").innerHTML = '<img src="..//img/customer-service/included.png" alt="" /> I have pets at home'
               // alert("pet che");

            }
            else {
                document.getElementById("pet").innerHTML = '<img src="..//img/customer-service/not-included.png" alt="" /> I don' + "'" + 't have pets at home'
            }


            if (index == 0) {
                document.getElementById("btnreschedulejsdashbord").innerHTML = '<hr /><button class="btn btnReschedule d-inline-block" value="" onclick="rescheduleservicemodel()">Reschedule</button><button class="btn btncancel d-inline-block pl-2" value = "" onclick="canelservicemodel()"> Cancel</button>';
               
            }
            else {
                document.getElementById("btnreschedulejsdashbord").innerHTML = '';
               
            }
           
            $('#trmodel').modal('show');

            var inputDate = respo.user.serviceStartDate;
            const date = new Date(inputDate);
            var inputTagDate = date.getFullYear().toString() + "-" + AppendZero((date.getMonth() + 1).toString()) + "-" + AppendZero(date.getDate().toString());

            console.log(inputTagDate);

            $("#datechange").val(inputTagDate);
            //document.getElementById("datechange").value =
            //setdate(inputDate);
            //console.log(date.getFullYear().toString() + "/" + AppendZero((date.getMonth() + 1).toString()) + "/" + AppendZero(date.getDate().toString()));
            //  document.getElementById("datechange").value = "2022-07-22"
        },
        error: function (respo) {
            alert('error:' + respo.responseText);
        }
    });

}

function rescheduleservicemodel() {
    $("#trmodel").modal("hide");
    $("#rechedual").modal("show");
   
}
function canelservicemodel() {
    $("#trmodel").modal("hide");
    $("#cancelservice").modal("show");
    
}


function rescheduleservice(servicerequestid) {
    $("#hiddenServiceRequestId").val(servicerequestid);
    $("#errormesgrechedual").addClass(" d-none")
    $("#errormesgrechedual").html("");
    $.ajax({
        type: 'Post',
        url: '/customer/reschukeservicedate',
        data: { "servicerequestid": servicerequestid },
        success: function (respo) {
            console.log(respo);
            var inputDate = respo.serviceStartDate;
            const date = new Date(inputDate);
            var inputTagDate = date.getFullYear().toString() + "-" + AppendZero((date.getMonth() + 1).toString()) + "-" + AppendZero(date.getDate().toString());
            console.log(inputDate + "---" + date);
            $("#datechange").val(inputTagDate);
            var today = new Date();
            $("#datechange").attr("min", (today.getFullYear().toString() + '-' + AppendZero((today.getMonth() + 1).toString()) + '-' + AppendZero(today.getDate().toString())));

            //console.log(respo.serviceStartDate.)
            var hours = date.getHours(); //returns 0-23
            var minutes = date.getMinutes(); //returns 0-59
            
           
            $("#drpselecttime").val(hours + (minutes/60));


            
        }
    });
}

function changeservicetime() {
    
    var servicerequestid = $("#hiddenServiceRequestId").val();
    var changedate = $("#datechange").val();
    var time = $("#drpselecttime :selected").text();

    
    $.ajax({
        type: 'Post',
        url: '/customer/changeservicetimedate',
        data: {
            "servicerequestid": servicerequestid,
            "changedate": changedate,
            "chanhgetime": time
        },
        success: function (respo) {
            if (respo.serviceRequestConflict == true && respo.serviceovertime == true) {
                $('#rechedual').modal('hide');
                /* window.location.href = "/customer/dashboard";*/
                location.reload();
                
            }
            else {
                debugger;
                alert("not okay");
                console.log(respo);
                $("#errormesgrechedual").removeClass(" d-none")
                if (respo.serviceRequestConflict == false) {
                    $("#errormesgrechedual").html("Another service request has been assigned to the service provider on " + changedate + "Either choose another date or pick up a different time slot");
                }
                if (respo.serviceovertime == false) {
                    $("#errormesgrechedual").html("Could not completed the service request, because service booking request is must be completed within 21:00 time");
                }
                
                $('#rechedual').modal('show');
            }
           
        }
    });
}


function cancelservice(servicerequestid) {
    $('#cancelservice').modal('show');
    $("#hiddenServiceRequestId").val(servicerequestid);
  
}

function cancelservicepost() {
    var servicerequestid = $("#hiddenServiceRequestId").val();
    $.ajax({
        type: 'Post',
        url: '/customer/cancelservice',
        data: {
            "servicerequestid": servicerequestid,

        },
        success: function (respo) {
            if (respo) {
                $('#cancelservice').modal('hide');
                window.location.href = "/customer/dashboard";
            }
            else {
                alert("not okay");
            }

        }
    });
}

$("#btnsubmitrating").click(function () {
    var ratingdetails = {};
    ratingdetails.usertd = $("#hiddenServiceRequestId").val();
   /* ratingdetails.*/
});