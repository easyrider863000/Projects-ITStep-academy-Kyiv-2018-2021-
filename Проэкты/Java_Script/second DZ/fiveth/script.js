table = document.getElementsByTagName("table")[0];
arr = [];
for(let i = 0;i<table.getElementsByTagName("tr")[0].getElementsByTagName("th").length;i++){
    arr.push(new Array());
    arr[0].push(table.getElementsByTagName("tr")[0].getElementsByTagName("th")[i].innerHTML);
    document.getElementsByTagName("table")[0].getElementsByTagName("tr")[0].getElementsByTagName("th")[i].addEventListener("mouseover", function(e){
        document.getElementsByTagName("table")[0].getElementsByTagName("tr")[0].getElementsByTagName("th")[i].style.cursor = "pointer";
    });
    document.getElementsByTagName("table")[0].getElementsByTagName("tr")[0].getElementsByTagName("th")[i].addEventListener("click", function(e){
        let tmpArr = [];
        for(let i = 1;i<arr.length - arr[0].length;i++){
            tmpArr.push(arr[i][getColumnByName(e.target.innerHTML)]);
        }
        let tmp_list = [];
        for(let i = 0;i<arr.length-arr[0].length;i++){
            tmp_list.push(new Array());
            for(let j = 0;j<arr[i].length;j++){
                tmp_list[i][j] = arr[i][j];
            }
        }
        tmp_list.shift();
        tmpArr.sort();
        for(let i = 0;i<tmpArr.length;i++){
            for(let j = 0;j<tmp_list.length;j++){
                if(tmpArr[i] == tmp_list[j][getColumnByName(e.target.innerHTML)]){
                    arr[i+1] = tmp_list[j];
                }
            }
        }
        updateTable();
    });
}
for(let i = 0;i<table.getElementsByTagName("tr").length;i++){
    arr.push(new Array());
    for(let j = 0;j<table.getElementsByTagName("tr")[i].getElementsByTagName("td").length;j++){
        arr[i].push(table.getElementsByTagName("tr")[i].getElementsByTagName("td")[j].innerHTML);
    }
}

function getColumnByName(name){
    for(let i = 0;i<arr[0].length;i++){
        if(arr[0][i] == name){
            return i;
        }
    }
}
function swap(obj1,obj2){
    let tmp = obj1;
    obj1 = obj2;
    obj2 = tmp;
}

function updateTable(){
    for(let i = 0;i<document.getElementsByTagName("table")[0].getElementsByTagName("tr").length;i++){
        for(let j = 0;j<document.getElementsByTagName("table")[0].getElementsByTagName("tr")[i].children.length;j++){
            document.getElementsByTagName("table")[0].getElementsByTagName("tr")[i].children[j].textContent = arr[i][j];
        }
    }
}
