let arr = [];
for(let i = 0;i<document.getElementsByClassName("btn").length;i++){
    arr.push(true);
}
for(let i = 0;i<document.getElementsByClassName("btn").length;i++){
    document.getElementsByClassName("btn")[i].addEventListener("click", function(e){
        for(let j = 0;j<document.getElementsByClassName("text").length;j++){
            if(document.getElementsByClassName("text")[j].style.display == "block"){
                arr[j] = false;
                document.getElementsByClassName("text")[j].style.display = "none";
            }
            else{
                arr[j] = true;
            }
        }
        let element = document.getElementsByClassName("btn")[i];
        if(arr[i]){
            element.parentElement.getElementsByClassName("text")[0].style.display = "block";
            arr[i] = false;
        }
        else{
            element.parentElement.getElementsByClassName("text")[0].style.display = "none";
            arr[i] = true;
        }
    });
}