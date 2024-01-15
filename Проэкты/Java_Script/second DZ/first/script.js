list = document.body.getElementsByTagName("li");
for(let i=0;i<list.length;i++){
    if(list[i].innerHTML.indexOf("://")>=0 && list[i].innerHTML.indexOf("http")>=0){
        list[i].style.textDecorationLine = "underline"
        list[i].style.textDecorationStyle = "dotted"
    }
}
