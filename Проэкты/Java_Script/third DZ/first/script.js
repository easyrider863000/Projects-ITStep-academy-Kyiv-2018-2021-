document.getElementsByClassName("input")[0].onkeydown = function(event){
    if ((event.keyCode < 48 || event.keyCode>57)&&(event.keyCode<96||event.keyCode>105)) {  
        return true;
    }
    else{
        return false;
    }
}