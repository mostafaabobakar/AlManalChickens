$(window).on("load", function () {
  $(".loader").fadeOut(1000);
  new WOW().init();
});

$(document).ready(function () {
  "use strict";
  $(".close-open-nav").on("click", function (e) {
    e.stopPropagation();
    $(this).toggleClass("active");
    if ($(this).hasClass("active")) {
      $(".nav_bar").addClass("active");
    } else {
      $(".nav_bar").removeClass("active");
    }
  });

  $("body").on("click", function () {
    $(".close-open-nav.active").click();
  });

  $(".nav_bar a").each(function () {
    if (window.location.href.includes($(this).attr("href"))) {
      $(this).addClass("active");
    }
  });

  $(window).scroll(function () {
    if ($(this).scrollTop() > 300) {
      $(".back-to-top").addClass("active");
    } else {
      $(".back-to-top").removeClass("active");
    }
  });

  $(".back-to-top").on("click", function () {
    $("html, body").animate(
      {
        scrollTop: 0,
      },
      500
    );
  });
});

$(document).ready(function () {
  "use strict";
  $(".owl-index").owlCarousel({
    loop: true,
    margin: 0,
    nav: true,
    dots: true,
    rtl: true,
    lazyLoad: true,
    smartSpeed: 2200,
    autoplay: true,
    autoplayTimeout: 3500,
    navText: [
      "<span><i class='fas fa-angle-left'></i></span>",
      "<span><i class='fas fa-angle-right'></i></span>",
    ],
    responsive: {
      0: {
        items: 1,
      },
      600: {
        items: 1,
      },
      1000: {
        items: 1,
      },
    },
  });
});


$(document).ready(function () {
  "use strict";
  $(".select_2").select2();

  $(".filter_Pro .btn_").on("click", function () {
    $(".filter_Pro .btn_").removeClass("active");
    $(this).addClass("active");
    

  });

});