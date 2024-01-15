let text = document.getElementsByClassName('rightside-catalog')[0].innerHTML
let dat = JSON.parse(localStorage['res'])
fetch("https://localhost:5001/api/manufacturers")
    .then(response => response.json())
    .then(data2 => {
        mans = data2['data']
        for(let i = 0 ;i<dat.length;i++){
            text+='<div class="item"><div class="img-item"><img src="'+dat[i]['photoPath']+'" alt=""></div><div class="right-item"><div class="title-item">'+dat[i]['name']+'</div><div class="text-items"><div class="text-item"><div>Marka: <br>'+mans.filter(item => item['id'] == dat[i]['idManufacturer'])[0]['name']+'</div><div>Oznaczenie towaru:<br>'+dat[i]['number']+'</div></div><div class="price-item">'+dat[i]['price']+' EUR</div></div><div id="'+dat[i]['price']+'" class="but-item"><div id="'+dat[i]['id']+'" class="dodaj">DODAJ DO<br>KOSZYKA</div><div class="parametr">Parametry</div></div></div></div>'
        }
        document.getElementsByClassName('rightside-catalog')[0].innerHTML = text;
        for(let i = 0;i<document.getElementsByClassName("dodaj").length;i++){
            document.getElementsByClassName("dodaj")[i].onclick = function(e){
                let obj = JSON.parse(localStorage.getItem("kor"));
                obj['items'].push(document.getElementsByClassName("dodaj")[i].id);
                obj['sum']= parseFloat(obj['sum'])+parseFloat(document.getElementsByClassName("dodaj")[i].parentElement.id);
                obj['count']+=1
                localStorage.setItem("kor",JSON.stringify(obj));
                document.location.reload(true);
            }
        }
})