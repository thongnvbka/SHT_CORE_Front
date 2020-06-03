(function ($) {

    //Chọn dịch vụ lấy list video
    $('#select_dv').on('change', function () {
        var dulieu = $(this).val();
        var id_post = $(this).data('id');
        var title = $(this).find(':selected').data('title');
        var key = $(this).find(':selected').data('key');
        $('#danhmuc_title').html(title);
        $('#clipbox').html(`<div class="loadingbox">
				  <div class="c"></div>
					<div class="c1 c"></div>
					  <div class="c2 c"></div>
						<div class="c3 c"></div>
						  <div class="c4 c"></div>
							<div class="c5 c"></div>
							  <div class="c6 c"></div>
								<div class="c7 c"></div>
								  <div class="c8 c"></div>
									<div class="c9 c"></div>
				</div>`);
        $.ajax({ // Hàm ajax
            type: "post", //Phương thức truyền post hoặc get
            dataType: "html", //Dạng dữ liệu trả về xml, json, script, or html
            url: 'https://benhvienthammykangnam.vn/wp-admin/admin-ajax.php', // Nơi xử lý dữ liệu
            data: {
                action: "random", //Tên action, dữ liệu gởi lên cho server
                id_post: id_post, //Tên dịch vụ
                dulieu: dulieu, //Tên dịch vụ
                title: title, //Tiêu đề dịch vụ
                key: key, //Tiêu đề dịch vụ
            },
            beforeSend: function () {
                // Có thể thực hiện công việc load hình ảnh quay quay trước khi đổ dữ liệu ra
            },
            success: function (response) {
                // console.log(response);

                //Làm gì đó khi dữ liệu đã được xử lý
                $('#clipbox').html(response); // Đổ dữ liệu trả về vào thẻ &lt;div class="display-post"&gt;&lt;/div&gt;
            },
            error: function (jqXHR, textStatus, errorThrown) {
                //Làm gì đó khi có lỗi xảy ra
                console.log('The following error occured: ' + textStatus, errorThrown);
            }
        });
    });


    //on click rend iframe

    //Phần sử dụng khi làm full video
    // $( ".fixvideo .img" ).click(function() {
    // var id_video = $(this).data('id');
    // $('#fixvideo').html('<div class="aspect-ratio-box"><div class="aspect-ratio-box_inside"><div id="player"></div></div></div>');
    // $('#mb_comment_video').html('<div class="fb-comments mb" data-href="https://hanhtrinhlotxac.vn?'+id_video+'" data-numposts="5" data-width="100%">');
    // FB.XFBML.parse();
    // change_yt(id_video);
    // });
    $("body").on('click', '.videoplay', function () {
        var title = $(this).data('title');
        // var des = $(this).find('.video_des').data('description');
        var id_video = $(this).data('id');
        $('html,body').animate({ scrollTop: 1000 }, 1000, 'swing');
        $('.videomain').addClass('slidePageClip');
        $('.videomain').html(`
			<div class="container">
				<div class="fixvideo" id="fixvideo">
					<div class="row">
						<div class="col-xl-12">
							<div class="slidePageClipBox mainclip">
								<div class="aspect-ratio-box"><div class="aspect-ratio-box_inside"><div id="player"></div></div></div>
							</div>
						</div>
					</div>
				</div>
			</div>`)
        change_yt(id_video);
        var height = $('.contentfix .col-lg-8').innerHeight();
        $('.contentfix .hmb').css('height', height);
        // console.log(height);

    });
    //on scroll show video bottom



    //API EMBEB YOUTUBE
    var tag = document.createElement('script');

    tag.src = "https://www.youtube.com/iframe_api";
    var firstScriptTag = document.getElementsByTagName('script')[0];
    firstScriptTag.parentNode.insertBefore(tag, firstScriptTag);

    //Funtion thay video
    function change_yt(id) {
        var player;
        player = new YT.Player('ytplayer', {
            height: '100%',
            width: '100%',
            videoId: id,
            playerVars: { rel: 0 },
            events: {
                'onReady': onPlayerReady,
                'onStateChange': onPlayerStateChange
            }
        });
    }

    //Autoplay khi load video
    function onPlayerReady(event) {
        event.target.playVideo();

    }
    //Event check video khi có thay đổi
    var done = false;
    function onPlayerStateChange(event) {
        var target = $(window);
        $(document).scroll(function () {
            scroll_top = $(target).scrollTop();

            var win1 = $(".videopage").offset().top - 100;
            if (scroll_top >= win1 && event.data == '1' && !done) {
                $("#fixvideo .mainclip").addClass("videofix");
                // console.log(scroll_top);
            } else if (scroll_top < win1 && !done) {
                $("#fixvideo .mainclip").removeClass("videofix");
                console.log(scroll_top);
            }
        });

    }

    function stopVideo() {
        player.stopVideo();

    }
    //END API EMBEB YOUTUBE

    //load more video

    $("body").on('click', '.loadmore-btn', function () {
        var i = 1;
        var sectionclass = $(this).data('class');
        console.log(sectionclass);
        $("." + sectionclass + ' .videoplay.hide').each(function () {
            // console.log(i);
            if (i <= 9) {
                $(this).removeClass('hide');
                i++;
            }
        });

        if (i < 10) {
            $('.loadmore-btn').hide();
        }
    });

})(jQuery);