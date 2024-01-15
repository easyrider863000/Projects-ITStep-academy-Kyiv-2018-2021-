fetch('https://localhost:5001/api/categories')
    .then(response => response.json())
    .then(data => {
        text = '<div class="block-group-line"><div>Wszystko</div></div>';
        for (let i = 0; i < data['data'].length; i++) {
            text += '<div id=' + data['data'][i]['id'] + ' class="block-group-line"><div>' + data['data'][i]['name'] + '</div></div>'
        }
        document.getElementsByClassName('group-line')[0].innerHTML = text;
        for (let i = 0; i < document.getElementsByClassName('group-line').length; i++) {
            document.getElementsByClassName('group-line')[i].addEventListener('click', function (e) {
                fetch('https://localhost:5001/api/goods')
                    .then(response2 => response2.json())
                    .then(data2 => {
                        let res = data2['data'].filter(item => item['idCategory'] == e.target.parentElement.id)

                        localStorage.setItem("res", JSON.stringify(res))
                        window.location.href = "./grupaproduktow/katalog/index.html";
                    })
            })
        }
    })



