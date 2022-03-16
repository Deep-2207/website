$(document).ready(function () {
    //$('#example').on('draw.dt', function () { //every time ajax call, this code execute

    //    //$(".ratingspdashboard").rating({
    //    //    min: 0,
    //    //    max: 5,


    //    //    step: 0.1,
    //    //    size: "xs",
    //    //    stars: "5",
    //    //    showClear: false,
    //    //    readonly: true,
    //    //    starCaptions: function (val) {
    //    //        return val;
    //    //    }
    //    //});   
    //    //    });
    //}
    $('#example').DataTable({

        "dom": '<"top"i>rt<"bottom"flp><"clear">',
      

        "bFilter": false, //hide Search bar
        "pagingType": "full_numbers",
        paging: true,
        "pagingType": "full_numbers",
        // bFilter: false,
        ordering: true,
        searching: false,
        info: true,
       
        "oLanguage": {
            "sInfo": "Total Records: _TOTAL_"
        },
        "dom": 'Bt<"top">rt<"bottom"lip><"clear">',
        responsive: true,
        "order": [],
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

   // getuserrequest();
    getuserrequest();
});

function AppendZero(input) {
    if (input.length == 1) {
        return '0' + input;
    }
    return input;
}

function getuserrequest() {
    $.ajax({
        type: 'post',
        url: '/Admin/newuser',
        success: function (resp) {
            console.log(resp);
            $('#example').DataTable().clear();

            resp.forEach(function (element) {
                var t = $('#example').DataTable();
                date = new Date(element.createdDate);
                var inputtagdate = AppendZero(date.getDate().toString()) + "-" + AppendZero((date.getMonth() + 1).toString()) + "-" + date.getFullYear().toString();
                //user type id
                var usertype;
                if (element.userTypeId == 2) {
                    usertype = 'Serviceprovider';
                }
                else {
                    usertype = 'Customer';
                }

                var userstatus;
                if (element.isActive == true) {
                    userstatus = '<button class="active">Active</button>';
                }
                else {
                    userstatus = '<button class="btn-Cancel" value="InActive">InActive</button>';
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
                    '<li><a class="dropdown-item" href="#">Edit</a></li>' +
                    '<li><a class="dropdown-item" href="#">Deactivate</a></li>' +
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
