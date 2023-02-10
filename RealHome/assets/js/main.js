$(window).load(function () {
    $('#JiSlider').JiSlider({color: '#fff', start: 1, reverse: true}).addClass('ff')
})

$(function() {
            
    var menu_ul = $('.faq > li > ul'),
           menu_a  = $('.faq > li > a');
    
    menu_ul.hide();

    menu_a.click(function(e) {
        e.preventDefault();
        if(!$(this).hasClass('active')) {
            menu_a.removeClass('active');
            menu_ul.filter(':visible').slideUp('normal');
            $(this).addClass('active').next().stop(true,true).slideDown('normal');
        } else {
            $(this).removeClass('active');
            $(this).next().stop(true,true).slideUp('normal');
        }
    });

});

$(window).load(function() {
    $("#flexiselDemo1").slick({
        pauseOnHover: true,
        infinite: true,
        slidesToShow: 4,
        slidesToScroll: 2,
        arrow:true,
        enableResponsiveBreakpoints: true,
        responsiveBreakpoints: { 
            portrait: { 
                changePoint:480,
                visibleItems: 1
            }, 
            landscape: { 
                changePoint:640,
                visibleItems:2
            },
            tablet: { 
                changePoint:768,
                visibleItems: 2
            }
        }
    });
    
});

$(window).load(function() {
    $.fn.lightspeedBox();
});



$(document).ready(function() {
    $("#owl-demo").owlCarousel({
        items :3,
        itemsDesktop : [768,2],
        itemsDesktopSmall : [414,1],
        lazyLoad : true,
        autoPlay : true,
        navigation :true,

        navigationText :  false,
        pagination : true,

    });
  
});

if ($('#toTop').length) {
    var scrollTrigger = 100, // px
        backToTop = function () {
            var scrollTop = $(window).scrollTop();
            if (scrollTop > scrollTrigger) {
                $('#toTop').addClass('show');
            } else {
                $('#toTop').removeClass('show');
            }
        };
    backToTop();
    $(window).on('scroll', function () {
        backToTop();
    });
    $('#toTop').on('click', function (e) {
        e.preventDefault();
        $('html,body').animate({
            scrollTop: 0
        }, 1200);
    });
}

/*$(document).ready(function() {
    /*
        var defaults = {
        containerID: 'toTop', // fading element id
        containerHoverID: 'toTopHover', // fading element hover id
        scrollSpeed: 1200,
        easingType: 'linear' 
        };
                                  
    $().UItoTop({ easingType: 'easeOutQuart' });
});*/

jQuery(document).ready(function($) {
    $(".scroll").click(function(event){     
        event.preventDefault();
        var Toscroll=$(this.hash).offset().top;
        $('html,body').animate({scrollTop:Toscroll},1000);
        //$( ".overlay-close" ).trigger("click" );
        setTimeout(function () { $('.overlay-close').trigger('click'); }, 1100);
    });
});

$(document).ready(function () {
    $('#verticalTab').easyResponsiveTabs({
        type: 'vertical',
        width: 'auto',
        fit: true
    });
});


// You can also use "$(window).load(function() {"
$(function () {
  // Slideshow 4
    $("#slider4").responsiveSlides({
        auto: true,
        pager: false,
        nav: true,
        speed: 500,
        namespace: "callbacks",
        before: function () {
          $('.events').append("<li>before event fired.</li>");
        },
        after: function () {
          $('.events').append("<li>after event fired.</li>");
        }
    });

});

(function ($, window, document) {
    var formHandler = {
        init: function () {
            var $form = $('#request-form'); 
            $form.on('click', 'input[type="submit"]', function (e) {
                e.preventDefault();
                $(this).parent().parent().find('input,textarea').removeClass('error');
                $(this).parent().parent().find('div.label-error').remove();
                if ($(this).hasClass('processing')) { return; }
                formHandler.submit($form);
            });
        },
        validate: function ($form) {
            var valid = true;
            var items = $form.find(':input[data-validate]').each(function () {
                $el = $(this);
                var methods = $el.data('validate').split(';');
                for (var i = 0; i < methods.length; i++) {
                    if (typeof formHandler[methods[i]] === 'function' && $el.is(':visible')) {
                        if (!formHandler[methods[i]]($el.val())) {
                            formHandler.showError($el);
                            valid = false;
                            break;
                        }
                    }
                }
            });
            return valid;
        },
        isFilled: function (val) {
            return $.trim(val) !== '';
        },
        isEmail: function (val) {
            if ($.trim(val) === '') {
                return true;
            }
            var re = /^([a-zA-Z0-9_\.\-!])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            return re.test($.trim(val));
        },
        showError: function ($el) {
            $el.addClass('error');
            $el.after('<div class="label-error">' + $el.attr("data-val-required") + '</div>');
        },
        submit: function ($form) {
            var valid = true;
            $form.find('input,textarea').removeClass('error');
            valid = formHandler.validate($form);
            if (valid) {
                if ($form.hasClass('ajax-form')) {
                    // ajax submission
                    formHandler.ajaxSubmit($form);
                } else {
                    $form.submit();
                }
            } else {
                $(':input.error', $form).first().focus();
            }
        },
        ajaxSubmit: function ($form) {      
            $form.find('input[type="submit"]').val('processing');
            // $form.find('input[type="submit"]').html('<button class="btn btn-submit"><i class="fa fa-spinner"></i></button>');
            var url = $form.attr('action');
            var method = $form.attr('method');
            var $bubleAlert = $('#bubble-alert');
            $.ajax({
                    type: method,
                    url: url,
                    data: $form.serialize(),
                    dataType: 'json',
                    encode: true,
                    timeout: 15 * 1000
                })
                .done(function (data) {
                    if (data.result == 'true') {
                        $bubleAlert.removeClass('error').addClass('success').text(data.message);
                        $form.find('input[type="submit"]').val('Send');
                    } else {
                        $bubleAlert.removeClass('success').addClass('error').text(data.message);
                    }
                    $form.find('input[type="text"],input[type="email"],textarea,select').val('');
                })
                .fail(function(data) {
                    console.log(data);
                    $bubleAlert.removeClass('success').addClass('error').html($bubleAlert.data('message-default'));
                })
                .always(function() {
                    setTimeout(function() {
                            $form.find('input[type="submit"]').removeClass('processing');
                            $bubleAlert.removeClass('success error').html('');
                        },
                        5000);
                });
        }
    }

    $(document).ready(function () {
        formHandler.init();
    });
})(jQuery, window, document);


