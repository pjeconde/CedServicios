/*!
 * Hidescroll.js
 * Version: 1.0.0
 * Show and hide nav on scroll
 * Author: @jedrzejchalubek
 * Site: http://jedrzejchalubek.com/
 * Licensed under the MIT license
 */
!function(a,b,c){function d(b,c){this.options=a.extend({},f,c),this.navbar=b,this.init()}var e="hidescroll",f={offset:0,interval:250,stickClass:"stick",visibleClass:"visible",hiddenClass:"hidden"};d.prototype.calculate=function(){var b=a(c).scrollTop();this.direction=b>this.scroll?-1:1,this.action=!0,this.scroll=b},d.prototype.bindings=function(){var b=this.options;this.navbar.bind({normalPosition:function(){a(this).removeClass(b.stickClass+" "+b.visibleClass+" "+b.hiddenClass)},stickHiddenPosition:function(){a(this).addClass(b.stickClass+" "+b.hiddenClass).removeClass(b.visibleClass)},stickVisiblePosition:function(){a(this).addClass(b.visibleClass).removeClass(b.hiddenClass)}})},d.prototype.handle=function(){return this.navbar.trigger(0===this.scroll?"normalPosition":this.direction<0&&this.scroll>this.options.offset?"stickHiddenPosition":"stickVisiblePosition")},d.prototype.events=function(){a(b).on("scroll",a.proxy(this.calculate,this))},d.prototype.status=function(){var a=this;setInterval(function(){a.action&&(a.handle(),a.action=!1)},this.options.interval)},d.prototype.init=function(){this.scroll=0,this.direction=0,this.options.offset=0===this.options.offset?this.navbar.outerHeight():this.options.offset,this.action=!0,this.bindings(),this.events(),this.status()},a.fn[e]=function(b){return this.each(function(){a.data(this,"api_"+e)||a.data(this,"api_"+e,new d(a(this),b))})}}(jQuery,window,document);