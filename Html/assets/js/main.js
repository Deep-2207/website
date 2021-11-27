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
});
