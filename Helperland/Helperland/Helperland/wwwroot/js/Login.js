
//global variable
var RegExpressEmail = new RegExp("^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");


//login aajax
function btnlogin() {
    if ($("#txtloginemail").val() == "") {
        document.getElementById("spnemailerror").innerHTML = "Please enter the Email"
    }
    else if (!RegExpressEmail.test($("#txtloginemail").val())) {
        document.getElementById("spnemailerror").innerHTML = "Please enter the Valid Email"
    }
    else {
        document.getElementById("spnemailerror").innerHTML = ""
    }

    if ($("#txtloginpassword").val() == "") {
        document.getElementById("spnpassworderror").innerHTML = "Please enter the Password";
    }
    else {
        document.getElementById("spnpassworderror").innerHTML = "";
    }

    if (document.getElementById("spnemailerror").innerHTML == "" &&
        document.getElementById("spnpassworderror").innerHTML == "") {

        debugger;
        var logindetails = {}

        logindetails.Email = $("#txtloginemail").val();
        logindetails.Password = $("#txtloginpassword").val();
        logindetails.IsRemember = $('#chkIsremember').prop('checked');;
        $("#loader").addClass("is-active");
        $.ajax({
            type: 'post',
            url: '/Account/login',

            dataType: 'json',
            contentType: 'application/json',
            data: JSON.stringify(logindetails),
            //data: { "Email": Email, "Password": Password, "IsRemember": IsRemember }
            success: function (resp) {
                //   reset addressform
                //AddressBox(false);
                //FillCustomerAddressList();
                console.log(resp.status)
                $("#loader").removeClass("is-active");

                if (resp.status == "OK") {
                    window.location.href = "Http://" + window.location.host + "/" + resp.url;

                } else {
                    BootstrapAlert("dvloginerrormesag", resp.errorMessage, "danger")
                }


            },
            error: function (err) {
                console.log(err);
            }
        });
    }
}

function btnsendforgotrpswdmail() {
    debugger;

    if ($("#inpfogEmail").val() == "") {
        document.getElementById("spnforgoterror").innerHTML = "Please enter the Email"
    }
    else if (!RegExpressEmail.test($("#inpfogEmail").val())) {
        document.getElementById("spnforgoterror").innerHTML = "Please enter the Valid Email"
    }
    else {
        document.getElementById("spnforgoterror").innerHTML = ""
    }

    if (document.getElementById("spnforgoterror").innerHTML == "") {

        var forgotpasswordobj = {}
        forgotpasswordobj.email = $("#inpfogEmail").val();
        $("#loader").addClass("is-active");
        $.ajax({
            type: 'post',
            url: '/Account/forgotpassword',
            dataType: 'json',
            contentType: 'application/json',
            data: JSON.stringify(forgotpasswordobj),
            success: function (resp) {
                $("#loader").removeClass("is-active");
                if (resp.status == "OK") {
                    $('#forgotmodel').modal('hide');
                    forgotswal();

                }
                else {
                    BootstrapAlert("dvforgotpassword", resp.errorMessage, "danger")

                }
            },
            error: function (err) {
                console.log(err);
            }
        });
    }
}

function forgotswal() {
    Swal.fire({
        icon: 'success',
        title: 'Forgot Password',
        text: 'If provided email is a registered email ID on Helperland, you will receive an email with further instructions on how to reset your password.',
    })
}
function BootstrapAlert(id, message, type) {
    var wrapper = document.createElement('div')
    wrapper.innerHTML = '<div class="alert alert-' + type + ' alert-dismissible" role="alert">' + message + '<button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button></div>'
    $('#' + id).html(wrapper);
}
