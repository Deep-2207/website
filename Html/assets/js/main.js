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


  var posts = $(".accordion");

  // $(".container-max-width .control .buttons").click(function () {
  //   var customType = $(this).data("filter");
  //   console.log(customType);
  //   console.log(posts.length);

  //   posts.hide();
  //   $("." + customType).show();
  // });

  //collapse when scrolling
  $(document).ready(function () {
    $(window).scroll(function () {
      if (this.scrollY > 20) {
        $(".navbar .navbar-collapse").removeClass("show");
       
      }
      if($("body").click()){
        $(".navbar .navbar-collapse").removeClass("show");
      }
    });
  });
  ///hide navubar when click outside
  document.addEventListener("click", (evt) => {
    const navbar = document.getElementById("navbar-collapse");
    let targetElement = evt.target;

    do {
        if (targetElement == navbar) {
            
            return;
        }
        
        targetElement = targetElement.parentNode;
    } while (targetElement);
    $("#navbarSupportedContent").removeClass("show");
    
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

  //brightnetion body
  // $(".navbar-toggler").click(function () {
  //   $(".admin-body").toggleClass("bright");
    // $("section").toggleClass("bright");
  // });


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

  // $("footer .privacy-policy button").click(function () {
  //   $("footer .privacy-policy").toggleClass("unvisibal");
  // });

 
    $("#btnprivacy-policy").click(function(){
      // $("footer .privacy-policy").hide();
      document.getElementById("privacy-policy").style.setProperty('display', 'none', 'important')
     
    });
});
