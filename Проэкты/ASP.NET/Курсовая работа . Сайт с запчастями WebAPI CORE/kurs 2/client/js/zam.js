if (localStorage.getItem("kor") !== null) {
    let data = JSON.parse(localStorage.getItem("kor"))
    if ((data)['count'] > 0) {
        $("#name").val((data)['name'])
        $("#surname").val((data)['surname'])
        $("#phone").val((data)['phone'])
        $("#email").val((data)['email'])

        $("#country").val((data)['address']['country'])
        $("#city").val((data)['address']['city'])
        $("#street").val((data)['address']['street'])
        $("#house").val((data)['address']['house'])
        $("#flat").val((data)['address']['flat'])

        let text = "";
        fetch("https://localhost:5001/api/goods")
            .then(response => response.json())
            .then(data2 => {
                mans = data2['data']

                for (let i = 0; i < data['items'].length; i++) {
                    item = mans.filter(j => j.id==parseInt(data['items'][i]))[0];
                    console.log(item);
                    text+='<div class="item-zak" id="item'+item['id']+'"><div class="delete-item-zak">X</div><div class="img-item-zak"><img src="'+item['photoPath']+'" alt=""></div><div class="poz-item-zak">'+item['name']+'<br><br>Numer artykułu: <br>'+item['number']+'</div><div class="price-item-zak" id="item'+item['id']+'pric"><span>'+item['price']+'</span> PLN</div><div class="count-item-zak"><div class="mar-count-item-zak"><div class="plus-zak" id="item'+item['id']+'plus">+</div><div class="count-zak-get" id="item'+item['id']+'count"><span>1</span></div><div class="minus-zak" id="item'+item['id']+'mins">-</div></div></div><div class="summa-item-zak" id="item'+item['id']+'summ"><span>'+item['price']+'</span> PLN</div></div>';
                    


                }
                console.log(text);

                document.getElementsByClassName("pod-zak")[0].innerHTML += text;
            })



        






    }
    else {
        alert("Twój koszyk jest pusty")
        window.location.href = "../index.html";
    }
}
else {
    alert("Twój koszyk jest pusty")
    window.location.href = "../index.html";
}








    // fetch("http://localhost:5000/api/clients/address/" + data['id'], {
    //     method: 'GET',
    //     headers: {
    //         "Content-Type": "application/json",
    //         "Authorization": "Bearer " + data['token']
    //     },
    //     redirect: 'follow'
    // }).then(response=>)