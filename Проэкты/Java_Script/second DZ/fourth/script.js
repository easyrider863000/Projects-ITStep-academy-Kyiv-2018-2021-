document.onkeydown = function(event) {
    if ((event.ctrlKey && (event.keyCode == 83))||(event.ctrlKey && (event.keyCode == 69))) {
        if(event.keyCode == 69){
            text_area = document.body.getElementsByClassName("text-area")[0].textContent;
            document.body.getElementsByClassName("text-area")[0].style.display = "none";
            document.body.getElementsByClassName("text-div")[0].textContent = text_area;
            document.body.getElementsByClassName("text-div")[0].style.display = "block";
        }
        if(event.keyCode == 83){
            text_div = document.body.getElementsByClassName("text-div")[0].value;
            document.body.getElementsByClassName("text-div")[0].style.display = "none";
            document.body.getElementsByClassName("text-area")[0].textContent = text_div;
            document.body.getElementsByClassName("text-area")[0].style.display = "block";
        }
        return false;
    }
}