let arr = [
    {
        img:"https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcSLmBYEwqhegE3TuV5K4Bz_xOfDcvkVs3RPJxZ2c9nXI4FD_CYqiARDwC_LP1aLYtz8V5uBT_6xDseQccjRm5j10Plu8MAKknyziTTnBJER16j-KznY-crg&usqp=CAc",
        name:"Изучаем JavaScript. Руководство по созданию современных веб-сайтов",
        author:"Етан Браун",
        price:16
    },
    {
        img:"https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcTL2DSzVvoWHKZYMvsmp3hcJAgb3HJsgo0YgD-AstNdn3lzkLIZ_E7CpbQf2cZ-Fujcftg0Y8QiuyazWleNOorTNrZaPaUDaGjxhIsgRUJyBwJrj45fMIon&usqp=CAc",
        name:"Изучаем программирование на JavaScript",
        author:"Эрик Фримен, Элизабет Робсон",
        price:20
    },
    {
        img:"https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcSBA2Wh1HrQJSS2fxXD2KuCK5aZFxYyJbUDh4bByBeALHnIVf_ROezRQlefQmcO6jhs56LDDMssZm4ghC6SRJHGm6qCS1pw04sN23vR6X4j&usqp=CAc",
        name:"Javascript для дітей",
        author:"Морґан Нік",
        price:23
    }
];
let text = "";
for(let i = 0;i<arr.length;i++){
    text+=
    `<div class="item" style="border-style: solid; width: 150px;">
    <img width="150px" src="${arr[i].img}">
    <div class="name">${arr[i].name}</div>
    <span style="color: grey;">${arr[i].author}</span>
    <div style="text-align: right;">${arr[i].price}$</div>
    <button class="select" style="width:150px">Select</button>
</div>`;
}
document.getElementById("books").innerHTML=text;
let selects = document.getElementsByClassName("select");
for(let i = 0;i<selects.length;i++){
    selects[i].addEventListener("click",function(e){
        document.getElementById("book").value = selects[i].parentElement.getElementsByClassName("name")[0].innerHTML;
    });
}


document.getElementById("buy").onclick = function(e){
    let book = document.getElementById("book");
    let quantity = document.getElementById("quantity");
    let name = document.getElementById("name");
    let addres = document.getElementById("addres");
    let date = document.getElementById("date");
    if(book.value.length>0
        &&parseInt(quantity.value)>0
        &&name.value.length>0
        &&+addres.value.length>0
        &&date.value.length>0){
            document.getElementById("books").style.display = "none";
            document.getElementById("form").style.display = "none";
            document.getElementById("result").innerHTML = `<h3>Result:</h3>
            <div style="border-style: solid;">${name.value}, thanks for the order!
            <br>
            Book "${book.value}" in amount ${quantity.value} pc. will be delivered on ${date.value.split('-')[2]}.${date.value.split('-')[1]}.${date.value.split('-')[0]} to ${addres.value}.</div>`
    }
}