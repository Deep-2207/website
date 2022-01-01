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
  
  var items = document.querySelectorAll("#sidebar-menu li"),
   tab =[],index;
   
   for(var i=0;i<items.length;i++){
     tab.push(items[i].innerHTML);
     console.log(tab[i]);
   } 
  for(var i=0;i<items.length;i++){
    items[i].onclick = function(){
      index = tab.indexOf(this.innerHTML);
      console.log(index + "COnsole check");
    };
  }
// data table js start
//   $(document).ready(function() {
//     $('#example').DataTable( {
//         "order": [[ 3, "desc" ]],
//         "bPaginate": false, //hide pagination
//         "bFilter": false, //hide Search bar
//         "bInfo": false, // hide showing entries
        
//     } );
// } );



          // $('#example').dataTable({
          //     "bProcessing": true,
          //     "sAutoWidth": false,
          //     "bDestroy":true,
          //     "sPaginationType": "bootstrap", // full_numbers
          //     "iDisplayStart ": 10,
          //     "iDisplayLength": 10,
          //"bPaginate": false, //hide pagination
          //   "bFilter": false, //hide Search bar
          //     "bInfo": false, // hide showing entries
          // })
          //    
// data table js end



});
