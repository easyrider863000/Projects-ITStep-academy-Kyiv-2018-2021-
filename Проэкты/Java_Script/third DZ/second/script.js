document.getElementsByClassName("open")[0].addEventListener("click",function(e){
    let div = document.createElement('div');
    div.className = "modal";
    div.innerHTML = (`<div id="btn">
        <div style="margin:30px;">Hello from Modal Window!</div>
        <input style="margin:5px 100px;" type="button" value="Close">
    </div>`);
    document.body.append(div);
    for(let i = 0;i<document.body.children.length;i++){
        if(document.body.children[i].className != "modal"){
            document.body.children[i].style.opacity = 0.5;
            document.body.children[i].setAttribute("disabled","disabled");
        }
    }
    document.getElementById("btn").addEventListener("click",function(event){
        let r = document.getElementById("btn");
        r.parentNode.removeChild(r);
        for(let i = 0;i<document.body.children.length;i++){
            if(document.body.children[i].className != "modal"){
                document.body.children[i].style.opacity = 1;
                document.body.children[i].removeAttribute("disabled");
            }
        }
    });
});
