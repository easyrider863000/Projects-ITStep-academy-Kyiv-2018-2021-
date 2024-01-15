$(document).ready(function(){
	var countitems = parseInt($("#count-items").val());
	var summaget = 0;
	for (var i = 1; i < countitems+1; i++) {
		var sumget = $("#item"+i+"summ span").html();
		summaget += parseFloat(sumget, 10);
	}
	$(".info-suuma span").html(summaget.toFixed(2));
	$(".plus-zak").click(function(){
		var iditem = $(this).attr('id');
		iditem = iditem.substring(0, iditem.length - 4);
		var countitem = $("#"+iditem+"count span").html();
		countitem++;
		$("#"+iditem+"count span").html(countitem);
		var price = $("#"+iditem+"pric span").html();
		var summa = price*countitem;
		summaget = summaget - parseFloat($("#"+iditem+"summ span").html(),10);
		$("#"+iditem+"summ span").html(summa.toFixed(2));
		summaget = summaget + parseFloat(summa.toFixed(2),10);
		$(".info-suuma span").html(summaget.toFixed(2));
	})
	$(".minus-zak").click(function(){
		var iditem = $(this).attr('id');
		iditem = iditem.substring(0, iditem.length - 4);
		var countitem = $("#"+iditem+"count span").html();
		if (countitem>0){
			countitem--;
			$("#"+iditem+"count span").html(countitem);
			var price = $("#"+iditem+"pric span").html();
			var summa = price*countitem;
			$("#"+iditem+"summ span").html(summa.toFixed(2));
			summaget -= price;
			$(".info-suuma span").html(summaget.toFixed(2));
		}
	})
	$('.history-item-block').click(function (event) {
		var iditemhist = $(this).attr('id');
        $("#"+iditemhist+"-show").slideToggle();
        event.stopPropagation();
    });
})
