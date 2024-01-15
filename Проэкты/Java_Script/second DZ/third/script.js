for(let i = 0;i<document.getElementsByClassName("color-list")[0].children.length;i++){
    document.getElementsByClassName("color-list")[0].children[i].setAttribute("class","color-item");
}

for(let i = 0;i<document.getElementsByClassName("color-item").length;i++){
    document.getElementsByClassName("color-item")[i].addEventListener("click",mouse_keys)
}
document.addEventListener("keydown", function (e){
    ctrl = e.ctrlKey;
    shift = e.shiftKey;
});
document.addEventListener("keyup", function (e){
    ctrl = e.ctrlKey;
    shift = e.shiftKey;
});
let ctrl;
let shift;
let lastStep;
function setLastStep(t){
    lastStep = getPositionByObject(t);
}
function getPositionByObject(obj){
    let children = document.getElementsByClassName("color-list")[0].children;
    for(let i = 0;i<children.length;i++){
        if(children[i] == obj){
            return i;
        }
    }
}
function getObjectByPosition(j){
    let children = document.getElementsByClassName("color-list")[0].children;
    for(let i = 0;i<children.length;i++){
        if(i == j){
            return children[i];
        }
    }
}

function mouse_keys(e){
    if(shift){
        for(let j = 0;j<document.getElementsByClassName("color-list")[0].children.length;j++){
            document.getElementsByClassName("color-list")[0].children[j].style.backgroundColor = "white";
        }
        if(lastStep<getPositionByObject(e.target)){
            for(let i = lastStep;i<=getPositionByObject(e.target);i++){
                getObjectByPosition(i).style.backgroundColor = "orange";
            }
        }
        else{
            for(let i = getPositionByObject(e.target);i<=lastStep;i++){
                getObjectByPosition(i).style.backgroundColor = "orange";
            }
        }
    }
    else if(ctrl){
        e.target.style.backgroundColor = "orange";
        setLastStep(e.target);
    }
    else{
        for(let j = 0;j<document.getElementsByClassName("color-list")[0].children.length;j++){
            document.getElementsByClassName("color-list")[0].children[j].style.backgroundColor = "white";
        }
        e.target.style.backgroundColor = "orange";
        setLastStep(e.target);
    }
}
