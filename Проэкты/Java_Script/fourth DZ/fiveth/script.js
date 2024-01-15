Date.prototype.daysInMonth = function() {
    return 32 - new Date(this.getFullYear(), this.getMonth(), 32).getDate();
}; // for safari ---- 33
document.getElementById("btn").onclick = function(e){
    for(let i = 0;i<document.getElementsByTagName("td").length;i++){
        document.getElementsByTagName("td")[i].innerHTML = `<br>`
    }
    if(document.getElementsByTagName("tr").length>6){
        let r = document.getElementsByTagName("tr")[document.getElementsByTagName("tr").length-1];
        r.parentElement.removeChild(r);
    }
    let m = document.getElementById("m").value;
    let y = document.getElementById("y").value;
    let date = new Date(y,m-1,1);
    let j;
    if(date.getDay() == 0){
        j = 6;
    }
    else{
        j = date.getDay()-1;
    }
    let arr = [];
    for(let i = 0;i<date.daysInMonth();i++){
        arr.push(i+1);
    }
    for(let i = j;i<document.getElementsByTagName("td").length&&arr.length>0;i++)
    {
        document.getElementsByTagName("td")[i].textContent = arr.shift();
    }
    if(arr.length>0){
        document.getElementsByTagName("table")[0].innerHTML+=(`<tr>
        <td><br></td>
        <td><br></td>
        <td><br></td>
        <td><br></td>
        <td><br></td>
        <td><br></td>
        <td><br></td>
    </tr>`);
        let last = document.getElementsByTagName("tr")[document.getElementsByTagName("tr").length-1];
        for(let i = 0;i<last.children.length&&arr.length>0;i++){
            last.children[i].innerHTML = arr.shift();
        }
    }
}