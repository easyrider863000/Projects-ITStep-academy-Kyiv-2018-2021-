let arr = [
    "Odessa - Lviv",
    "Kyiv - Ternopil",
    "Odessa - Kyiv",
    "Kyiv - Lviv",
    "Odessa - Ternopil"
];
let price =50;
let html_options = "";
for(let i = 0;i<arr.length;i++){
    html_options+=`<option value="${arr[i]}">${arr[i]}</option>`
}
document.getElementById("places").style.display = "none";
document.getElementById("result").style.display = "none";
document.getElementById("dir").innerHTML = html_options;
let list;
document.getElementById("search").onclick = function(e){
    let v = document.getElementById("date").value;
    if(v.length>0){
        list = document.getElementById("dir").value;
        document.getElementById("places").style.display = "block";
    }
}
for(let i = 0;i<document.getElementsByName("check").length;i++){
    document.getElementsByName("check")[i].addEventListener("click",function(e){
        if(document.getElementsByName("check")[i].checked){
            document.getElementById("price").innerHTML= parseInt(document.getElementById("price").innerHTML)+price;
        }
        else if(!document.getElementsByName("check")[i].checked){
            document.getElementById("price").innerHTML= parseInt(document.getElementById("price").innerHTML)-price;
        }
    });
}
document.getElementById("book").onclick = function(e){
    let book = {
        dir: document.getElementById("dir").value,
        date: document.getElementById("date").value.split('-'),
        seats:[]
    }
    for(let i = 0;i<document.getElementsByName("check").length;i++){
        if(document.getElementsByName("check")[i].checked){
            book["seats"].push(document.getElementsByName("check")[i].parentElement.getElementsByTagName("label")[0].innerHTML);
        }
    }
    if(book.seats.length>0){
        document.getElementById("choose").style.display = "none";
        document.getElementById("result").style.display = "block";
        let tr;
        for(let i = 0;i<book.seats.length;i++){
            tr = document.createElement("tr");
            tr.innerHTML = `<td>${book.dir}</td><td>${book.date[2]}.${book.date[1]}.${book.date[0]}</td><td>${book.seats[i]}</td>`
            document.getElementById("last-table").append(tr);
        }
    }
}