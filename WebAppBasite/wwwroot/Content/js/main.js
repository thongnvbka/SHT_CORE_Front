
$(document).on("ready", function () {
    $(".owl-carousel").owlCarousel({
        loop: true,
        //margin: 30,
        nav: true,
        dots: false,
        autoplay: true,
        margin: 10,
        responsiveClass: true,
        navText: [
            "<i class='fa fa-chevron-left'></i>",
            "<i class='fa fa-chevron-right'></i>"
        ],
        responsive: {
            0: {
                items: 1,
                nav: true
            },
            600: {
                items: 3,
                nav: false
            },
            1000: {
                items: 5,
                nav: true,
                loop: false,
                margin: 20
            }
        }
    });





});


$(document).ready(function () {
    $(".dropdown-toggle").dropdown();
    $(".seach .dropdown-menu li:last-child").css("border-bottom", "none");
    $(function () {
        $('.navbar-toggle').click(function () {
            $('.navbar-nav').toggleClass('slide-in');
            $('.side-body').toggleClass('body-slide-in');
            $('#search').removeClass('in').addClass('collapse').slideUp(200);

            /// uncomment code for absolute positioning tweek see top comment in css
            //$('.absolute-wrapper').toggleClass('slide-in');

        });

        // Remove menu for searching
        $('#search-trigger').click(function () {
            $('.navbar-nav').removeClass('slide-in');
            $('.side-body').removeClass('body-slide-in');

            /// uncomment code for absolute positioning tweek see top comment in css
            //$('.absolute-wrapper').removeClass('slide-in');

        });
    });
});
$(document).ready(function () {
    $(".slider1").bxSlider({
        slideWidth: 211,
        minSlides: 2,
        maxSlides: 3,
        slideMargin: 10
    });
    $(".bxslider").bxSlider({
        mode: 'fade'
    });
    $(".admin-view").hover(function () {
        $(this).find(".language-hide").css("display", "block");
    },
        function () {
            $(this).find(".language-hide").css("display", "none");

        });
    $(".support-left").eq(0).css("border-left", "none");
    $(".tab-serice ul li .tab-img").click(function () {
        $(".tab-serice ul li .tab-img p").css("display", "none");
        $(".tab-serice ul li .tab-img p").removeClass("active_step");
        $(this).find("p").css("display", "block");

    });
});

