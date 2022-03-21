$(document).ready(function () {
    
    $('#example').DataTable({

        "dom": '<"top"i>rt<"bottom"flp><"clear">',
        "bFilter": false, //hide Search bar
        "pagingType": "full_numbers",
        paging: true,
        "pagingType": "full_numbers",
        // bFilter: false,
        ordering: true,
        searching: true,
        info: true,
        "oLanguage": {
            "sInfo": "Total Records: _TOTAL_"
        },
        "dom": 'Bt<"top">rt<"bottom"lip><"clear">',
        responsive: true,
        "order": [],
        "bDestroy": true,
        orderCellsTop: true,
        fixedHeader: true
        //buttons: {
        //    dom: {
        //        button: {
        //            tag: 'button',
        //            className: ''
        //        }
        //    },
        //    buttons: [{
        //        extend: 'excel',
        //        text: 'Export',
        //        className: "Export",
        //        exportOptions: {
        //            columns: [0, 1, 2, 3]
        //        },
        //    }]
        //}
    });
   
    getuserrequest();
   
   
    
});

function AppendZero(input) {
    if (input.length == 1) {
        return '0' + input;
    }
    return input;
}


$("#btnserchsubmit").click(function () {
    
    var t = $('#example').DataTable();
    // t.search('');
    var username = $("#serchusername").val();
    var usertype = $("#idusertype option:selected").text();
    var phonenumber = $("#idphonenumber").val();
    var postalcode = $("#idpostalcode").val();
    var fromdate = $("#txtFromDate").val();
    var todate = $("#txtToDate").val();
    t.column(0).search(username).draw(true);
    /*console.log(t.search($("#serchusername").val()));*/
    if (usertype != "User Type") {
        t.column(3).search(usertype).draw(true);
    }
    t.column(4).search(phonenumber).draw(true);
    t.column(5).search(postalcode).draw(true);
    if ($("#txtFromDate").val() != '' && $("#txtToDate").val() != '') {
        jQuery.fn.dataTable.ext.search.push(
            function (settings, data, dataIndex) {
                var min = new Date(parseInt($("#txtFromDate").val().toString().split('-')[0]), parseInt(parseInt($("#txtFromDate").val().toString().split('-')[1]) - 1), parseInt($("#txtFromDate").val().toString().split('-')[2]), 0, 0, 0, 0);
                var max = new Date(parseInt($("#txtToDate").val().toString().split('-')[0]), parseInt(parseInt($("#txtToDate").val().toString().split('-')[1]) - 1), parseInt($("#txtToDate").val().toString().split('-')[2]), 0, 0, 0, 0);
                var date = new Date(parseInt(data[2].toString().split('-')[2]), parseInt(parseInt(data[2].toString().split('-')[1]) - 1), parseInt(data[2].toString().split('-')[0]), 0, 0, 0, 0);
                var inputtagdate = AppendZero(AppendZero((date.getMonth() + 1).toString()) + "-" + date.getDate().toString()) + "-" + date.getFullYear().toString();
                if (
                    (min === null && max === null) ||
                    (min === null && date <= max) ||
                    (min <= date && max === null) ||
                    (min <= date && date <= max)
                ) {
                    console.log('success');
                    return true;
                }
                else {
                    console.log('error');
                    return false;
                }

            }
        );
        t.draw();
    }
});
$("#btnclear").click(function () {
    var table = $('#example').DataTable();
  
    $('#txtFromDate').val('');
    $('#txtFromDate').attr('type', 'text');
    $('#txtToDate').val('');
    $('#txtToDate').attr('type', 'text');
    $("#txtToDate").attr({
        "min": ''
    });
    $("#txtFromDate").attr({
        "max": ''
    });
    $("#serchusername").val('')
    $("#idusertype").val(0);
    $("#idphonenumber").val('');
    $("#idpostalcode").val('');
    table
        .search('')
        .columns().search('')
        .draw();
   
});

function getuserrequest() {
    $("#loader").addClass("is-active");
    $.ajax({
        type: 'post',
        url: '/Admin/newuser',
        success: function (resp) {
            $("#loader").removeClass("is-active");
            console.log(resp);
            $('#example').DataTable().clear();

            resp.forEach(function (element) {
                var t = $('#example').DataTable();
                date = new Date(element.createdDate);
                var inputtagdate = AppendZero(date.getDate().toString()) + "-" + AppendZero((date.getMonth() + 1).toString()) + "-" + date.getFullYear().toString();
                //user type id
                var usertype;
                if (element.userTypeId == 3) {
                    usertype = 'Customer';
                }
                else if (element.userTypeId == 2) {
                    usertype = 'Serviceprovider';
                }
                else {
                    usertype = 'Admin';
                }

                //var userstatus;
                //if (element.isActive == true) {
                //    userstatus = '<button class="active">Active</button>';
                //}
                //else {
                //    userstatus = '<button class="btn-Cancel" value="InActive">InActive</button>';
                //}
                //var userstatus;
                //var activeanddeactive;
                //if (element.isApproved != true) {
                //    userstatus = '<button class="btnapprove">Approve</button>';
                //    activeanddeactive = '<li><a class="dropdown-item" href="#">Approve</a></li>' +
                //                         '<li><a class="dropdown-item" href="#">Deactivate</a></li>'
                //}
                //else {
                //    if (element.isActive == true) {
                //        userstatus = '<button class="active">Active</button>';
                //        activeanddeactive = '<li><a class="dropdown-item" href="#">Deactivate</a></li>'
                //    }
                //    else {
                //        userstatus = '<button class="btn-Cancel" value="InActive">InActive</button>';
                //        activeanddeactive = '<li><a class="dropdown-item" href="#">Active</a></li>';   
                //    }
                   
                //}
                  var userstatus;
                var activeanddeactive;
                if (element.isApproved != true) {
                    userstatus = '<button class="btnapprove">Approve</button>';
                    activeanddeactive = '<li><a class="dropdown-item" href="#" onclick="AppeoveUser(' + element.userId + ')">Approve</a></li>';
                    if (element.isActive == true) {
                        activeanddeactive += '<li><a class="dropdown-item" href="#" onclick="ActiveDeactive(' + element.userId + ',0)">Deactivate</a></li>';
                    }
                    else {
                        activeanddeactive += '<li><a class="dropdown-item" href="#" onclick="ActiveDeactive(' + element.userId + ',1)">Active</a></li>';
                    }
                                        
                }
                else {
                    if (element.isActive == true) {
                        userstatus = '<button class="active">Active</button>';
                        activeanddeactive = '<li><a class="dropdown-item" href="#" onclick="ActiveDeactive(' + element.userId + ',1)">Deactivate</a></li>'
                    }
                    else {
                        userstatus = '<button class="btn-Cancel" value="InActive">InActive</button>';
                        activeanddeactive = '<li><a class="dropdown-item" href="#" onclick="ActiveDeactive(' + element.userId + ',0)">Active</a></li>';
                    }

                }

                t.row.add([
                    element.firstName + " " + element.lastName,
                    '',
                    '<img src="..//img/service-provider-upcoming-service/calendar2.png" alt="" class="me-1"><span class="bold">' + inputtagdate,                   
                    usertype,
                    element.mobile,
                    element.zipCode,
                    userstatus,
                    '<div class="nav-item dropdown action">'+
                    '<a class= "nav-link dropdown-toggle" href = "#" id = "navbarDropdown" role = "button"' +
                    'data-bs-toggle="dropdown" aria-expanded="false" >' +
                    '<img src="..//img/admin-user/group-38.png" alt="">' +
                    '</a>' +
                    '<ul class="dropdown-menu dropdown-menu-lg-end" aria-labelledby="navbarDropdown">' +
                    activeanddeactive,
                    '</ul>' +
                    '</div >'

                ]).draw(false);
               
            });
        },
        error: function (err) {
            $("#loader").removeClass("is-active");
            console.log(err);
        }
    });
}

function AppeoveUser(userid) {
    $.ajax({
        type: 'post',
        url: '/Admin/approve',
        data: { 'userid': userid},
        success: function (resp) {
            console.log(resp);
            Swal.fire(
                'Approve!',
                'You are Approved '+ userid +' now thay can login',
                'success'
            )
            afterload();
            
        },
        error: function (err) {
            $("#loader").removeClass("is-active");
            console.log(err);
        }
    });
}
function ActiveDeactive(userid, index) {
    console.log(index);
    $.ajax({
        type: 'post',
        url: '/Admin/activedeactive',
        data: { 'userid': userid, 'index': index },
        success: function (resp) {
            console.log(resp);
            if (index == 1) {
                Swal.fire(
                    'Activated!',
                    userid + ' User is Activated',
                    'success'
                )
            }
            else {
                Swal.fire(
                    'DisActivated!',
                    userid + ' User is DisActivated',
                    'success'
                )
            }           
            afterload();
        },
        error: function (err) {
            $("#loader").removeClass("is-active");
            console.log(err);
        }
    });
}
function afterload() {
    $('#example').DataTable().clear().draw();
    getuserrequest();
}

$("#txtToDate").change(function () {
    $("#txtFromDate").attr({
        "max": $("#txtToDate").val(),   
    });
});
$("#txtFromDate").change(function () {
    $("#txtToDate").attr({
        "min": $("#txtFromDate").val(),
    });
});