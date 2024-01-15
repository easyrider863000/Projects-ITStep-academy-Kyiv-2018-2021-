for(let i = 0;i<document.getElementsByClassName("color-list")[0].children.length;i++){
    document.getElementsByClassName("color-list")[0].children[i].setAttribute("class","color-item");
}

for(let i = 0;i<document.getElementsByClassName("color-item").length;i++){
    document.getElementsByClassName("color-item")[i].addEventListener("click", function(e){
        for(let j = 0;j<document.getElementsByClassName("color-list")[0].children.length;j++){
            document.getElementsByClassName("color-list")[0].children[j].style.backgroundColor = "white";
        }
        e.target.style.backgroundColor = "orange";
    });
}
