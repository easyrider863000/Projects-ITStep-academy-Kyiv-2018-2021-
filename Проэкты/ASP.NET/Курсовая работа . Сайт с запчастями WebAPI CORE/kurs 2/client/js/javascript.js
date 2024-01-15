$(document).ready(function(){
	$('.slider-it').owlCarousel({
	    loop:true,
	    margin:10,
	    nav:true,
	    responsive:{
	        0:{
	            items:1
	        },
	        600:{
	            items:1
	        },
	        1000:{
	            items:1
	        }
	    }
	});
	$('.slider-it-partners').owlCarousel({
	    loop:true,
	    margin:10,
	    nav:true,
	    responsive:{
	        0:{
	            items:3
	        },
	        768:{
	            items:6
	        },
	        1000:{
	            items:6
	        }
	    }
	});
	$('.slider-it-video').owlCarousel({
	    loop:true,
	    margin:10,
	    nav:true,
	    responsive:{
	        0:{
	            items:1
	        },
	        600:{
	            items:1
	        },
	        1000:{
	            items:1
	        }
	    }
	});
	$('.topcarusel1').owlCarousel({
		items: 3,
	    loop: true,
	    dots: false,
	    mouseDrag: false,
    	touchDrag: false,
	    nav: true
	});
	$(".owl-next").html("");
	$(".owl-prev").html("");
	$(".exit-reg img").click(function(){
		$(".register").fadeOut(500);
	})
	$(".btn-reg").click(function(){
		if(localStorage.getItem('kor')===null){
			$(".register").fadeIn(500);
		}
		else{	alert("Jesteś już zalogowany")	}
	})
	$(".getchat").click(function(){
		$('.chat').fadeIn(500);
		$('.getchat').fadeOut(500);
	})
	$(document).mouseup(function (e){ // событие клика по веб-документу
		var div = $("#chat"); // тут указываем ID элемента
		if (!div.is(e.target) // если клик был не по нашему блоку
		    && div.has(e.target).length === 0) { // и не по его дочерним элементам
			div.fadeOut(500); // скрываем его
			$('.getchat').fadeIn(500);
		}
	});
	
})
