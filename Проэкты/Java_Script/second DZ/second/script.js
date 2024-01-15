document.addEventListener('click', function look(e){
    if(e.target.className == 'main li'){
        for(let i =0 ;i<e.target.children.length;i++){
            let param = e.target.children[i];
            if(param.style.display === "none"){
                param.style.display = "block";
            }
            else{
                param.style.display = "none";
            }
        }
    }
});
for(let i = 0;i<document.getElementsByClassName("li").length;i++){
    
    document.getElementsByClassName("li")[i].addEventListener("mouseover",function(e){
        e.target.style.fontWeight = "bolder";
        e.target.style.cursor = "pointer";
        for(let i = 0;i<e.target.children.length;i++){
                e.target.children[i].style.fontWeight = "normal";
            }
        });
    }


for(let i = 0;i<document.getElementsByClassName("li").length;i++){
    document.getElementsByClassName("li")[i].addEventListener("mouseout",function(e){
        e.target.style.fontWeight = "normal";
    });
}