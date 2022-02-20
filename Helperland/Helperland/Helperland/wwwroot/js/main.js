$(document).ready(function () {
    $(window).scroll(function () {
        if (this.scrollY > 20) {
            $(".homePage.navbar").addClass("navbar-bg-color");
        } else {
            $(".homePage.navbar").removeClass("navbar-bg-color");
        }
        if (this.scrollY > 500) {
            $(".scroll-up-btn").addClass("show");
        } else {
            $(".scroll-up-btn").removeClass("show");
        }
    });

    $(".top-arrow").click(function () {
        $("html").animate({ scrollTop: 0 });
    });


    

    //collapse when scrolling
    $(document).ready(function () {
        $(window).scroll(function () {
            if (this.scrollY > 20) {
                $(".navbar .navbar-collapse").removeClass("show");

            }
            if ($("body").click()) {
                $(".navbar .navbar-collapse").removeClass("show");
            }
        });
    });
    

    //collapse(hide navbar) when scrolling
    $(document).ready(function () {
        $(window).scroll(function () {

            $(".navbar .navbar-collapse").removeClass("show");
            $('.backblack').removeClass("open");

        });
    });

    //black backgroung on open side navbar
    $('.navbar-toggler').click(function () {
        $('.backblack').addClass("open");
    });
    $('.backblack').click(function () {
        $(".navbar .navbar-collapse").removeClass("show");
        $('.backblack').removeClass("open");
    });

    var items = document.querySelectorAll("#sidebar-menu li"),
        tab = [],
        index;

    for (var i = 0; i < items.length; i++) {
        tab.push(items[i].innerHTML);
        console.log(tab[i]);
    }
    for (var i = 0; i < items.length; i++) {
        items[i].onclick = function () {
            index = tab.indexOf(this.innerHTML);
            console.log(index + "COnsole check");
        };
    }

    // admin-management sub menu
    $(".sub-menu ul").hide();
    $(".sub-menu a").click(function () {
        $(this).parent(".sub-menu").children("ul").slideToggle("100");
        $(this).find(".right").toggleClass("fa-caret-up fa-caret-down");
    });

   

    //collapse(hide navbar) when scrolling
    $(document).ready(function () {
        $(window).scroll(function () {

            $(".navbar .navbar-collapse").removeClass("show");
            $('.backblack').removeClass("open");

        });
    });

    //black backgroung on open side navbar
    $('.navbar-toggler').click(function () {
        $('.backblack').addClass("open");
    });
    $('.backblack').click(function () {
        $(".navbar .navbar-collapse").removeClass("show");
        $('.backblack').removeClass("open");
    });

    //admin sub-menu

    $(".drop-1").click(function () {
        $(".admin-body .admin-dashboard ul .drop-1").toggleClass("bg-gray");
    });
    $(".drop-2").click(function () {
        $(".admin-body .admin-dashboard ul .drop-2").toggleClass("bg-gray");
    });
    $(".drop-3").click(function () {
        $(".admin-body .admin-dashboard ul .drop-3").toggleClass("bg-gray");
    });

    $(".drop-1").click(function () {
        $(".sidebar-collapse-ul .drop-1").toggleClass("bg-gray");
    });
    $(".drop-2").click(function () {
        $(".sidebar-collapse-ul .drop-2").toggleClass("bg-gray");
    });
    $(".drop-3").click(function () {
        $(".sidebar-collapse-ul .drop-3").toggleClass("bg-gray");
    });




    //$("#btnprivacy-policy").click(function () {
    //    // $("footer .privacy-policy").hide();
    //    document.getElementById("privacy-policy").style.setProperty('display', 'none', 'important')

    //});


    //bluer function for the time date
    $("#txtFromDate").blur(function () {
        if (!$("#txtFromDate").val()) {
            $('#txtFromDate').attr('type', 'text');
        } else {
            $('#txtFromDate').attr('type', 'date');
        }
    });

    $("#txtToDate").blur(function () {
        if (!$("#txtToDate").val()) {
            $('#txtToDate').attr('type', 'text');
        } else {
            $('#txtToDate').attr('type', 'date');
        }
    });
    //navbar collasped when model appere
    $(".modal").on('show.bs.modal', function () {
        $(".navbar .navbar-collapse").removeClass("show");
        $('.backblack').removeClass("open");
    });


    //file name in input countect us
    $('#formFileLg').change(function (e) {
        var fileName = e.target.files[0].name;
        document.getElementById("filename").innerHTML = fileName;
    });

    $('#formFileLg').click(function(e){
        
        document.getElementById("filename").innerHTML = "";
    });
    
    // this will get the full URL at the address bar
    var url = window.location.href;
    // hightlight active link
    $(".navbar .navbar-nav .nav-item a").each(function () {
        // checks if its the same on the address bar
        if (url == (this.href)) {
            $(this).addClass("active");
        }
    });
   

    //$('.navbar ul li').click(function () {
    //    $(this).addClass('activat').siblings().removeClass('activat');
    //})

});



//function btnclose() {
//    alert('HELLO 1');
//    //$.ajax({
//    //    url: '/Home/index',
//    //})
//    alert('HE;LLO');

//    onclick = "$('#modal_id').modal('hide');"
//}
