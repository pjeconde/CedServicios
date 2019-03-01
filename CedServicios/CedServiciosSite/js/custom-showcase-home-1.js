(function($) { "use strict";


	
	//Navigation
	
	jQuery(document).ready(function($){
		//if you change this breakpoint in the style.css file (or _layout.scss if you use SASS), don't forget to update this value as well
		var MqL = 1170;
		//move nav element position according to window width
		moveNavigation();
		$(window).on('resize', function(){
			(!window.requestAnimationFrame) ? setTimeout(moveNavigation, 300) : window.requestAnimationFrame(moveNavigation);
		});

		//mobile - open lateral menu clicking on the menu icon
		$('.cd-nav-trigger').on('click', function(event){
			event.preventDefault();
			if( $('.cd-main-content').hasClass('nav-is-visible') ) {
				closeNav();
				$('.cd-overlay').removeClass('is-visible');
			} else {
				$(this).addClass('nav-is-visible');
				$('.cd-primary-nav').addClass('nav-is-visible');
				$('.cd-main-header').addClass('nav-is-visible');
				$('.cd-main-content').addClass('nav-is-visible').one('webkitTransitionEnd otransitionend oTransitionEnd msTransitionEnd transitionend', function(){
					$('body').addClass('overflow-hidden');
				});
				toggleSearch('close');
				$('.cd-overlay').addClass('is-visible');
			}
		});

		//open search form
		$('.cd-search-trigger').on('click', function(event){
			event.preventDefault();
			toggleSearch();
			closeNav();
		});

		//close lateral menu on mobile 
		$('.cd-overlay').on('swiperight', function(){
			if($('.cd-primary-nav').hasClass('nav-is-visible')) {
				closeNav();
				$('.cd-overlay').removeClass('is-visible');
			}
		});
		$('.nav-on-left .cd-overlay').on('swipeleft', function(){
			if($('.cd-primary-nav').hasClass('nav-is-visible')) {
				closeNav();
				$('.cd-overlay').removeClass('is-visible');
			}
		});
		$('.cd-overlay').on('click', function(){
			closeNav();
			toggleSearch('close')
			$('.cd-overlay').removeClass('is-visible');
		});


		//prevent default clicking on direct children of .cd-primary-nav 
		$('.cd-primary-nav').children('.has-children').children('a').on('click', function(event){
			event.preventDefault();
		});
		//open submenu
		$('.has-children').children('a').on('click', function(event){
			if( !checkWindowWidth() ) event.preventDefault();
			var selected = $(this);
			if( selected.next('ul').hasClass('is-hidden') ) {
				//desktop version only
				selected.addClass('selected').next('ul').removeClass('is-hidden').end().parent('.has-children').parent('ul').addClass('moves-out');
				selected.parent('.has-children').siblings('.has-children').children('ul').addClass('is-hidden').end().children('a').removeClass('selected');
				$('.cd-overlay').addClass('is-visible');
			} else {
				selected.removeClass('selected').next('ul').addClass('is-hidden').end().parent('.has-children').parent('ul').removeClass('moves-out');
				$('.cd-overlay').removeClass('is-visible');
			}
			toggleSearch('close');
		});

		//submenu items - go back link
		$('.go-back').on('click', function(){
			$(this).parent('ul').addClass('is-hidden').parent('.has-children').parent('ul').removeClass('moves-out');
		});

		function closeNav() {
			$('.cd-nav-trigger').removeClass('nav-is-visible');
			$('.cd-main-header').removeClass('nav-is-visible');
			$('.cd-primary-nav').removeClass('nav-is-visible');
			$('.has-children ul').addClass('is-hidden');
			$('.has-children a').removeClass('selected');
			$('.moves-out').removeClass('moves-out');
			$('.cd-main-content').removeClass('nav-is-visible').one('webkitTransitionEnd otransitionend oTransitionEnd msTransitionEnd transitionend', function(){
				$('body').removeClass('overflow-hidden');
			});
		}

		function toggleSearch(type) {
			if(type=="close") {
				//close serach 
				$('.cd-search').removeClass('is-visible');
				$('.cd-search-trigger').removeClass('search-is-visible');
			} else {
				//toggle search visibility
				$('.cd-search').toggleClass('is-visible');
				$('.cd-search-trigger').toggleClass('search-is-visible');
				if($(window).width() > MqL && $('.cd-search').hasClass('is-visible')) $('.cd-search').find('input[type="search"]').focus();
				($('.cd-search').hasClass('is-visible')) ? $('.cd-overlay').addClass('is-visible') : $('.cd-overlay').removeClass('is-visible') ;
			}
		}

		function checkWindowWidth() {
			//check window width (scrollbar included)
			var e = window, 
				a = 'inner';
			if (!('innerWidth' in window )) {
				a = 'client';
				e = document.documentElement || document.body;
			}
			if ( e[ a+'Width' ] >= MqL ) {
				return true;
			} else {
				return false;
			}
		}

		function moveNavigation(){
			var navigation = $('.cd-nav');
			var desktop = checkWindowWidth();
			if ( desktop ) {
				navigation.detach();
				navigation.insertBefore('.cd-header-buttons');
			} else {
				navigation.detach();
				navigation.insertAfter('.cd-main-content');
			}
		}



	

	//App Animation
	

		//update this value if you change this breakpoint in the style.css file (or _layout.scss if you use SASS)
		var MqL = 1070;

		//on desktop, switch from product intro div to product tour div
		$('a[href="#cd-product-tour"]').on('click', function(event){
			event.preventDefault();
			$('header').addClass('slide-down');
			if($(window).width() < MqL) {
				$('body,html').animate({'scrollTop': $('#cd-product-tour').offset().top - 30 }, 200); 
			} else {
				$('.cd-main-content-app').addClass('is-product-tour');
				uploadVideo(jQuery('.cd-active'));
			}
		});

		//update the slider - desktop only
		$('.cd-prev').on('click', function(event){
			event.preventDefault();
			var activeSlide = $('.cd-active');
			if(activeSlide.is(':first-child')) {
				//in this case - switch from product tour div to product intro div
				showProductIntro();
			} else {
				updateSlider(activeSlide, 'prev'); 
			}
		});
		$('.cd-next').on('click', function(event){
			event.preventDefault();
			var activeSlide = $('.cd-active');
			updateSlider(activeSlide, 'next'); 
		});

		$(document).keyup(function(event){
			if(event.which=='37' && $('.cd-main-content-app').hasClass('is-product-tour') ) {
				var activeSlide = $('.cd-active');
				if(activeSlide.is(':first-child')) {
					//in this case - switch from product tour div to product intro div
					showProductIntro();
				} else {
					updateSlider(activeSlide, 'prev'); 
				}
			} else if(event.which=='39' && $('.cd-main-content-app').hasClass('is-product-tour')) {
				var activeSlide = $('.cd-active');
				updateSlider(activeSlide, 'next');
			}
		});

		$(window).on('resize', function(){
			window.requestAnimationFrame(function(){
				if($(window).width() < MqL) {
					$('.cd-single-item').each(function(){
						$(this).find('img').css('opacity', 1).end().find('video').hide();
					});
				} else {
					$('.cd-single-item.cd-active').find('video').show();
					( $('.cd-main-content-app').hasClass('is-product-tour') ) ? $('header').addClass('slide-down') : $('header').removeClass('slide-down');
				}
			});
		});
		$(window).on('scroll', function(){
			window.requestAnimationFrame(function(){
				if($(window).width() < MqL && $(window).scrollTop() < $('#cd-product-tour').offset().top - 30 ) {
					$('header').removeClass('slide-down');
				} else if ($(window).width() < MqL && $(window).scrollTop() >= $('#cd-product-tour').offset().top - 30 ){
					$('header').addClass('slide-down');
				}
			});
		});

		function showProductIntro() {
			$('header').removeClass('slide-down');
			$('.cd-main-content-app').removeClass('is-product-tour');
			$('.cd-active').find('video').get(0).pause();
			$('.cd-single-item').find('video').each(function(){
				$(this).get(0).currentTime = 0;
			});
		}

		function updateSlider(active, direction) {
			var selected;
			if( direction == 'next' ) {
				selected = active.next();
				//on Firefox CSS transition/animation fails when parent element changes visibility attribute
				//so we have to change .cd-single-item childrens attributes after having changed its visibility value
				setTimeout(function() {
					active.removeClass('cd-active').addClass('cd-hidden').next().removeClass('cd-move-right').addClass('cd-active').one('webkitTransitionEnd otransitionend oTransitionEnd msTransitionEnd transitionend', function(){
						active.addClass('cd-not-visible');
					});
				}, 50);
			} else {
				selected = active.prev();
				//on Firefox CSS transition/animation fails when parent element changes visibility attribute
				//so we have to change .cd-single-item childrens attributes after having changed its visibility value
				setTimeout(function() {
					active.removeClass('cd-active').addClass('cd-move-right').prev().addClass('cd-active').one('webkitTransitionEnd otransitionend oTransitionEnd msTransitionEnd transitionend', function(){
						active.addClass('cd-not-visible');
					});
				}, 50);
			}
			//update visible slider
			selected.removeClass('cd-not-visible');
			//update slider navigation (in case we reached the last slider)
			updateSliderNav(selected);

		}

		function updateSliderNav(selected) {
			( selected.is(':last-child') ) ? $('.cd-next').addClass('cd-inactive') : $('.cd-next').removeClass('cd-inactive') ;
			$('.cd-loader').stop().hide().css('width', 0);
		}


	});	


	
  })(jQuery); 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 





	