(function($) { "use strict";


	//Home Sections fit screen	
				
		/*global $:false */
		$(function(){"use strict";
			$('.home').css({'height':($(window).height())+'px'});
			$(window).resize(function(){
			$('.home').css({'height':($(window).height())+'px'});
			});
		});
			
		
	//Page Scroll
	
	$(document).ready(function(){"use strict";
		$(".scroll").click(function(event){

			event.preventDefault();

			var full_url = this.href;
			var parts = full_url.split("#");
			var trgt = parts[1];
			var target_offset = $("#"+trgt).offset();
			var target_top = target_offset.top - 250;

			$('html, body').animate({scrollTop:target_top}, 1000);
		});

	

	
	//Navigation


		//toggle 3d navigation
		$('.cd-3d-nav-trigger').on('click', function(){
			toggle3dBlock(!$('.cd-header').hasClass('nav-is-visible'));
		});

		//select a new item from the 3d navigation
		$('.cd-3d-nav a').on('click', function(){
			var selected = $(this);
			selected.parent('li').addClass('cd-selected').siblings('li').removeClass('cd-selected');
			updateSelectedNav('close');
		});

		$(window).on('resize', function(){
			window.requestAnimationFrame(updateSelectedNav);
		});

		function toggle3dBlock(addOrRemove) {
			if(typeof(addOrRemove)==='undefined') addOrRemove = true;	
			$('.cd-header').toggleClass('nav-is-visible', addOrRemove);
			$('main').toggleClass('nav-is-visible', addOrRemove);
			$('.cd-3d-nav-container').toggleClass('nav-is-visible', addOrRemove);
		}

		//this function update the .cd-marker position
		function updateSelectedNav(type) {
			var selectedItem = $('.cd-selected'),
				selectedItemPosition = selectedItem.index() + 1, 
				leftPosition = selectedItem.offset().left,
				backgroundColor = selectedItem.data('color');

			$('.cd-marker').removeClassPrefix('color').addClass('color-'+ selectedItemPosition).css({
				'left': leftPosition,
			});
			if( type == 'close') {
				$('.cd-marker').one('webkitTransitionEnd otransitionend oTransitionEnd msTransitionEnd transitionend', function(){
					toggle3dBlock(false);
				});
			}
		}

		$.fn.removeClassPrefix = function(prefix) {
			this.each(function(i, el) {
				var classes = el.className.split(" ").filter(function(c) {
					return c.lastIndexOf(prefix, 0) !== 0;
				});
				el.className = $.trim(classes.join(" "));
			});
			return this;
		};




	
			//Slider Revolution
			

								
					jQuery('.tp-banner').show().revolution(
					{
						dottedOverlay:"none",
						delay:6000,
						startwidth:1460,
						startheight:700,
						hideThumbs:false,
						hideTimerBar:"on",
						
						navigationType:"bullet",
						navigationArrows:"none",
						
						touchenabled:"on",
						onHoverStop:"off",
						
						swipe_velocity: 0.7,
						swipe_min_touches: 1,
						swipe_max_touches: 1,
						drag_block_vertical: false,
												
						keyboardNavigation:"off",
						
						navigationHAlign:"center",
						navigationVAlign:"bottom",
						navigationHOffset:0,
						navigationVOffset:30,
								
						shadow:0,
						fullWidth:"off",
						fullScreen:"on",

						spinner:"spinner4",
						
						stopLoop:"off",
						stopAfterLoops:-1,
						stopAtSlide:-1,

						shuffle:"off",
						
						autoHeight:"off",						
						forceFullWidth:"off",		
					});
														
	
 
	
	//Parallax
	

			$('.parallax-3').parallax("50%", 0.4);
			$('.parallax-6').parallax("50%", 0.4);

 

	//Blockquote
	

	 
	  $("#owl-blockquotes").owlCarousel({
		 
		navigation: false,
		pagination:false, 
		slideSpeed : 300,
		autoPlay : 5000,
		singleItem:true
	 
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
	 

	
	 
 
	 // Office Carousel
	 

	 
	  $("#owl-office").owlCarousel({
		 
		navigation: false,
		slideSpeed : 300,
		autoPlay : 4000,
		singleItem:true
	 
	  });
	 



	//Counter 
	

        $('.counter').counterUp({
            delay: 100,
            time: 2000
        });


 
	//Timeline	
 

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


	
	//accordion	
	

		$(".accordion").smk_Accordion({
			closeAble: true, //boolean
		});

		

	/* Portfolio Sorting */



		(function ($) { 
		
		
			var container = $('#projects-grid');
			
			
			function getNumbColumns() { 
				var winWidth = $(window).width(), 
					columnNumb = 1;
				
				
				if (winWidth > 1500) {
					columnNumb = 3;
				} else if (winWidth > 1200) {
					columnNumb = 3;
				} else if (winWidth > 900) {
					columnNumb = 2;
				} else if (winWidth > 600) {
					columnNumb = 2;
				} else if (winWidth > 300) {
					columnNumb = 1;
				}
				
				return columnNumb;
			}
			
			
			function setColumnWidth() { 
				var winWidth = $(window).width(), 
					columnNumb = getNumbColumns(), 
					postWidth = Math.floor(winWidth / columnNumb);

			}
			
			$('#portfolio-filter #filter a').click(function () { 
				var selector = $(this).attr('data-filter');
				
				$(this).parent().parent().find('a').removeClass('current');
				$(this).addClass('current');
				
				container.isotope( { 
					filter : selector 
				});
				
				setTimeout(function () { 
					reArrangeProjects();
				}, 300);
				
				
				return false;
			});
			
			function reArrangeProjects() { 
				setColumnWidth();
				container.isotope('reLayout');
			}
			
			
			container.imagesLoaded(function () { 
				setColumnWidth();
				
				
				container.isotope( { 
					itemSelector : '.portfolio-box-1', 
					layoutMode : 'masonry', 
					resizable : false 
				} );
			} );
			
			
		
			
		
			$(window).on('debouncedresize', function () { 
				reArrangeProjects();
				
			} );
			
		
		} )(jQuery);
	} );





	/* DebouncedResize Function */
		(function ($) { 
			var $event = $.event, 
				$special, 
				resizeTimeout;
			
			
			$special = $event.special.debouncedresize = { 
				setup : function () { 
					$(this).on('resize', $special.handler);
				}, 
				teardown : function () { 
					$(this).off('resize', $special.handler);
				}, 
				handler : function (event, execAsap) { 
					var context = this, 
						args = arguments, 
						dispatch = function () { 
							event.type = 'debouncedresize';
							
							$event.dispatch.apply(context, args);
						};
					
					
					if (resizeTimeout) {
						clearTimeout(resizeTimeout);
					}
					
					
					execAsap ? dispatch() : resizeTimeout = setTimeout(dispatch, $special.threshold);
				}, 
				threshold : 150 
			};
		} )(jQuery);


	
	
	
	 // Portfolio Ajax

	 
			$(window).load(function() {
			'use strict';		  
			  var loader = $('.expander-wrap');
			if(typeof loader.html() == 'undefined'){
				$('<div class="expander-wrap"><div id="expander-wrap" class="container clearfix relative"><p class="cls-btn"><a class="close">X</a></p><div/></div></div>').css({opacity:0}).hide().insertAfter('.portfolio');
				loader = $('.expander-wrap');
			}
			$('.expander').on('click', function(e){
				e.preventDefault();
				e.stopPropagation();
				var url = $(this).attr('href');



				loader.slideUp(function(){
					$.get(url, function(data){
						var portfolioContainer = $('.portfolio');
						var topPosition = portfolioContainer.offset().top;
						var bottomPosition = topPosition + portfolioContainer.height();
						$('html,body').delay(600).animate({ scrollTop: bottomPosition - -10}, 800);
						var container = $('#expander-wrap>div', loader);
						
						container.html(data);
						$("#owl-portfolio-slider").owlCarousel({
							 
							navigation: false, 
							slideSpeed : 300,
							autoPlay : 5000,
							singleItem:true
						 
						});
						$(".container").fitVids();
					
						loader.slideDown(function(){
							if(typeof keepVideoRatio == 'function'){
								keepVideoRatio('.container > iframe');
							}
						}).delay(1000).animate({opacity:1}, 200);
					});
				});
			});
			
			$('.close', loader).on('click', function(){
				loader.delay(300).slideUp(function(){
					var container = $('#expander-wrap>div', loader);
					container.html('');
					$(this).css({opacity:0});
					
				});
				var portfolioContainer = $('.portfolio');
					var topPosition = portfolioContainer.offset().top;
					$('html,body').delay(0).animate({ scrollTop: topPosition - 70}, 500);
			});

	});	
	
	//Google map

	jQuery(document).ready(function(){
		var e=new google.maps.LatLng(44.789511,20.43633),
			o={zoom:14,center:new google.maps.LatLng(44.789511,20.43633),
			mapTypeId:google.maps.MapTypeId.ROADMAP,
			mapTypeControl:!1,
			scrollwheel:!1,
			draggable:!0,
			navigationControl:!1
		},
			n=new google.maps.Map(document.getElementById("google_map"),o);
			google.maps.event.addDomListener(window,"resize",function(){var e=n.getCenter();
			google.maps.event.trigger(n,"resize"),n.setCenter(e)});
			
			var g='<div class="map-tooltip"><h6>Clymene</h6><p>Checking out our office too?</p></div>',a=new google.maps.InfoWindow({content:g})
			,t=new google.maps.MarkerImage("images/map-pin.png",new google.maps.Size(40,70),
			new google.maps.Point(0,0),new google.maps.Point(20,55)),
			i=new google.maps.LatLng(44.789511,20.43633),
			p=new google.maps.Marker({position:i,map:n,icon:t,zIndex:3});
			google.maps.event.addListener(p,"click",function(){a.open(n,p)}),
			$(".button-map").click(function(){$("#google_map").slideToggle(300,function(){google.maps.event.trigger(n,"resize"),n.setCenter(e)}),
			$(this).toggleClass("close-map show-map")});

	}); 	

	
  })(jQuery); 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 





	