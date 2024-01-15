for(let i = 0;i<document.getElementsByClassName("btn").length;i++){
    document.getElementsByClassName("btn")[i].addEventListener("mouseover",function(e){
        let btn = document.getElementsByClassName("btn")[i]
        if(btn.offsetTop>=30){
            let div = document.createElement("div");
            div.innerHTML = `<div id="tip" class="tip1">Tool tip 1</div>`;
            div.style.position="absolute";
            div.style.left=`${btn.offsetWidth/2+btn.offsetLeft-75}px`;
            div.style.top = `${btn.offsetTop - 40}px`;
            document.body.append(div);
        }
        else{
            let div = document.createElement("div");
            div.innerHTML = `<div id="tip" class="tip2">Tool tip 2</div>`;
            div.style.position="absolute";
            div.style.left=`${btn.offsetWidth/2+btn.offsetLeft-75}px`;
            div.style.top = `${btn.offsetTop+20}px`;
            document.body.append(div);
        }
    });
    document.getElementsByClassName("btn")[i].addEventListener("mouseout",function(e){
        let r = document.getElementById("tip");
        r.parentNode.removeChild(r);
    });
}