document.getElementsByClassName("stretchable")[0].style.border = "2px solid";
document.getElementsByClassName("stretchable")[0].style.display = "block";
document.addEventListener("mousedown",function(e){
    el = document.getElementsByClassName("stretchable")[0];
    if(e.x - el.offsetLeft <el.clientWidth+20&& el.clientWidth<e.x - el.offsetLeft+20&&e.y - el.offsetTop <el.clientHeight+20&& el.clientHeight<e.y - el.offsetTop+20){
        mousedown = true;
    }
    else{
        mousedown = false;
    }
});
document.addEventListener("mouseup",function(e){
    if(mousedown){
        el = document.getElementsByClassName("stretchable")[0];
        document.getElementsByClassName("stretchable")[0].style.width = `${e.x - el.offsetLeft-2}px`;
        document.getElementsByClassName("stretchable")[0].style.height = `${e.y - el.offsetTop-2}px`;
    }
    mousedown = false;
});
document.addEventListener("mousemove",function(e){
    if(mousedown){
        el = document.getElementsByClassName("stretchable")[0];
        document.getElementsByClassName("stretchable")[0].style.width = `${e.x - el.offsetLeft-2}px`;
        document.getElementsByClassName("stretchable")[0].style.height = `${e.y - el.offsetTop-2}px`;
    }
});

let mousedown;
