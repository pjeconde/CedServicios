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
	});


	
	//Parallax
	
	$(document).ready(function(){
			$('.parallax-services-2').parallax("50%", 0.4);
	});
  

	//Top Page Slider
	
	$(document).ready(function() {
	 
	  $("#owl-top-page-slider").owlCarousel({
		 
		navigation: false, 
		slideSpeed : 300,
		autoPlay : 3000,
		singleItem:true
	 
	  });
	 
	});


	
	//Interest Point 
	
	jQuery(document).ready(function($){
		//open interest point description
		$('.cd-single-point').children('a').on('click', function(){
			var selectedPoint = $(this).parent('li');
			if( selectedPoint.hasClass('is-open') ) {
				selectedPoint.removeClass('is-open').addClass('visited');
			} else {
				selectedPoint.addClass('is-open').siblings('.cd-single-point.is-open').removeClass('is-open').addClass('visited');
			}
		});
		//close interest point description
		$('.cd-close-info').on('click', function(event){
			event.preventDefault();
			$(this).parents('.cd-single-point').eq(0).removeClass('is-open').addClass('visited');
		});
	});	


	//accordion	
	
	jQuery(document).ready(function($){
		$(".accordion").smk_Accordion({
			closeAble: true, //boolean
		});
	});	


	 // Logos Carousel

	$(document).ready(function() {
	 
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
	 
	});	

	


	 // Pricing Tables

	jQuery(document).ready(function($){
		//hide the subtle gradient layer (.cd-pricing-list > li::after) when pricing table has been scrolled to the end (mobile version only)
		checkScrolling($('.cd-pricing-body'));
		$(window).on('resize', function(){
			window.requestAnimationFrame(function(){checkScrolling($('.cd-pricing-body'))});
		});
		$('.cd-pricing-body').on('scroll', function(){ 
			var selected = $(this);
			window.requestAnimationFrame(function(){checkScrolling(selected)});
		});

		function checkScrolling(tables){
			tables.each(function(){
				var table= $(this),
					totalTableWidth = parseInt(table.children('.cd-pricing-features').width()),
					tableViewport = parseInt(table.width());
				if( table.scrollLeft() >= totalTableWidth - tableViewport -1 ) {
					table.parent('li').addClass('is-ended');
				} else {
					table.parent('li').removeClass('is-ended');
				}
			});
		}

		//switch from monthly to annual pricing tables
		bouncy_filter($('.cd-pricing-container'));

		function bouncy_filter(container) {
			container.each(function(){
				var pricing_table = $(this);
				var filter_list_container = pricing_table.children('.cd-pricing-switcher'),
					filter_radios = filter_list_container.find('input[type="radio"]'),
					pricing_table_wrapper = pricing_table.find('.cd-pricing-wrapper');

				//store pricing table items
				var table_elements = {};
				filter_radios.each(function(){
					var filter_type = $(this).val();
					table_elements[filter_type] = pricing_table_wrapper.find('li[data-type="'+filter_type+'"]');
				});

				//detect input change event
				filter_radios.on('change', function(event){
					event.preventDefault();
					//detect which radio input item was checked
					var selected_filter = $(event.target).val();

					//give higher z-index to the pricing table items selected by the radio input
					show_selected_items(table_elements[selected_filter]);

					//rotate each cd-pricing-wrapper 
					//at the end of the animation hide the not-selected pricing tables and rotate back the .cd-pricing-wrapper
					
					if( !Modernizr.cssanimations ) {
						hide_not_selected_items(table_elements, selected_filter);
						pricing_table_wrapper.removeClass('is-switched');
					} else {
						pricing_table_wrapper.addClass('is-switched').eq(0).one('webkitAnimationEnd oanimationend msAnimationEnd animationend', function() {		
							hide_not_selected_items(table_elements, selected_filter);
							pricing_table_wrapper.removeClass('is-switched');
							//change rotation direction if .cd-pricing-list has the .cd-bounce-invert class
							if(pricing_table.find('.cd-pricing-list').hasClass('cd-bounce-invert')) pricing_table_wrapper.toggleClass('reverse-animation');
						});
					}
				});
			});
		}
		function show_selected_items(selected_elements) {
			selected_elements.addClass('is-selected');
		}

		function hide_not_selected_items(table_containers, filter) {
			$.each(table_containers, function(key, value){
				if ( key != filter ) {	
					$(this).removeClass('is-visible is-selected').addClass('is-hidden');

				} else {
					$(this).addClass('is-visible').removeClass('is-hidden is-selected');
				}
			});
		}
	});	

 
	//Timeline	
 
	jQuery(document).ready(function($){
		var $timeline_block = $('.cd-timeline-block');

		//hide timeline blocks which are outside the viewport
		$timeline_block.each(function(){
			if($(this).offset().top > $(window).scrollTop()+$(window).height()*0.75) {
				$(this).find('.cd-timeline-img, .cd-timeline-content').addClass('is-hidden');
			}
		});

		//on scolling, show/animate timeline blocks when enter the viewport
		$(window).on('scroll', function(){
			$timeline_block.each(function(){
				if( $(this).offset().top <= $(window).scrollTop()+$(window).height()*0.75 && $(this).find('.cd-timeline-img').hasClass('is-hidden') ) {
					$(this).find('.cd-timeline-img, .cd-timeline-content').removeClass('is-hidden').addClass('bounce-in');
				}
			});
		});
	});
 

 
	
  })(jQuery); 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 





	