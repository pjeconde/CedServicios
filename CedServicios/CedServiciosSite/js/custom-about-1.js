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



	
	//Parallax
	

			$('.parallax-about').parallax("50%", 0.4);

  

	//Top Page Slider
	

	 
	  $("#owl-top-page-slider").owlCarousel({
		 
		navigation: false, 
		slideSpeed : 300,
		autoPlay : 3000,
		singleItem:true
	 
	  });
	 




	//Skills Counter 
	

        $('.counter-skills').counterUp({
            delay: 100,
            time: 3000
        });



	//accordion	

		$(".accordion").smk_Accordion({
			closeAble: true, //boolean
		});



	 // Logos Carousel


	 
	  var owl = $("#owl-logos");
	 
	  owl.owlCarousel({
		 
		  itemsCustom : [
			[0, 2],
			[450, 2],
			[600, 2],
			[700, 3],
			[1000, 4],
			[1200, 4],
			[1400, 4],
			[1600, 4]
		  ],
		navigation : false,
		pagination: false,
		autoPlay: 2000
	 
	  });
	 



	//Blockquote
	

	 
	  $("#owl-blockquotes").owlCarousel({
		 
		navigation: false,
		pagination:false, 
		slideSpeed : 300,
		autoPlay : 5000,
		singleItem:true
	 
	  });
	 
	});
	
	
	
	
  })(jQuery); 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 





	