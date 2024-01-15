document.getElementsByTagName("input")[0].onclick = function(e){
    let obj = getNext();
    for(let i =0;i<document.getElementsByClassName("colors")[0].children.length;i++){
        document.getElementsByClassName("colors")[0].children[i].style.backgroundColor = "darkgrey"; 
    }
    document.getElementsByClassName("colors")[0].children[obj.index].style.backgroundColor = obj.color;
}

function getNext(){
    let o;
    for(let i =0;i<document.getElementsByClassName("colors")[0].children.length;i++){
        if(document.getElementsByClassName("colors")[0].children[i].style.backgroundColor == "yellow"){
            o = {color:"green",index:2};
            break;
        }
        if(document.getElementsByClassName("colors")[0].children[i].style.backgroundColor == "red"){
            o = {color:"yellow",index:1};
            break;
        }
        if(document.getElementsByClassName("colors")[0].children[i].style.backgroundColor == "green"){
            o = {color:"red",index:0};
            break;
        }
    }
    return o;
}