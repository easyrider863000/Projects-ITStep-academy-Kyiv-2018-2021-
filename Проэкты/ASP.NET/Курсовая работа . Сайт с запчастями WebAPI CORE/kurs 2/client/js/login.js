document.getElementsByClassName("sub-register")[0].onclick = function (e) {
    let login = $("#login").val()
    let name = $("#name").val()
    let surname = $("#surname").val()
    let phone = $("#phone").val()
    let email = $("#email").val()
    let password = $("#password").val()
    let password2 = $("#password2").val()

    if (login.length <= 0 || name.length <= 0 || surname.length <= 0 || phone.length <= 0
        || email.length <= 0 || password.length <= 0 || password2.length <= 0) {
        alert("Nie wszystkie pola są wypełnione")
        return;
    }
    if (password2 !== password) {
        alert("Hasło różni się")
        return;
    }
    if (!validateEmail(email)) {
        alert("E-mail jest nieprawidłowy")
        return;
    }
    if (!validatePhone(phone)) {
        alert("Telefon jest nieprawidłowy")
        return;
    }


    let description = "[" + $('input[name=radbut]:checked').val() + "]"
    let country = $("#country").val()
    let city = $("#city").val()
    let kodmail = $("#kodmail").val()
    let street = $("#street").val()
    let house = $("#house").val()
    let flat = $("#flat").val()
    if (country.length > 0 || city.length > 0 || kodmail.length > 0 || street.length > 0 || house.length > 0) {
        if (description.length <= 0 || country.length <= 0 || city.length <= 0 || kodmail.length <= 0 || street.length <= 0 || house.length <= 0) {
            alert("Musisz wypełnić wszystkie pola z adresem lub w ogóle nie podawać informacji o adresie")
            return;
        }
        description += " [" + $("#kodmail").val() + "]"
        description += " [" + $("#phone2").val() + "]"
    }
    fetch("http://localhost:5000/api/clients", {
        method: 'POST',
        body: JSON.stringify({ "Name": "" + name + "", "SurName": "" + surname + "", "Description": "" + description + "", "Login": "" + login + "", "Password": "" + password + "", "IdRole": 1 }),
        headers: {
            "Content-Type": "application/json"
        },
        redirect: 'follow'
    })
        .then(response => {
            if (response.status == 200) {
                fetch("http://localhost:5000/api/auth/authenticate", {
                    method: 'POST',
                    body: JSON.stringify({ "Login": "" + login + "", "Password": "" + password + "" }),
                    headers: {
                        "Content-Type": "application/json"
                    },
                    redirect: 'follow'
                })
                    .then(response => response.json())
                    .then(data => {
                        fetch("http://localhost:5000/api/clients/address/" + data['data']['id'], {
                            method: 'POST',
                            body: JSON.stringify({
                                "country": "" + country + "",
                                "city": "" + city + "",
                                "street": "" + street + "",
                                "house": "" + house + "",
                                "flat": "" + flat + "",
                                "description": "" + description + ""
                            }),
                            headers: {
                                "Content-Type": "application/json",
                                "Authorization": "Bearer " + data['data']['token']
                            },
                            redirect: 'follow'
                        }).then(response => response.json())
                            .then(data3 => {
                                let obj = {
                                    name: name,
                                    surname: surname,
                                    login: login,
                                    token: data['data']['token'],
                                    phone: ""+phone,
                                    email: ""+email,
                                    address:data3,
                                    id: data['data']['id'],
                                    sum: 0,
                                    count: 0,
                                    items: []
                                }

                                let addressId = data3['id']
                                fetch("http://localhost:5000/api/clients/addressphone/" + data['data']['id'] + "/" + addressId, {
                                    method: 'POST',
                                    body: JSON.stringify({
                                        "phoneNumber": "" + phone + ""
                                    }),
                                    headers: {
                                        "Content-Type": "application/json",
                                        "Authorization": "Bearer " + data['data']['token']
                                    },
                                    redirect: 'follow'
                                }).then(response => {
                                        fetch("http://localhost:5000/api/clients/addressmail/" + data['data']['id'] + "/" + addressId, {
                                            method: 'POST',
                                            body: JSON.stringify({
                                                "mail": "" + email + ""
                                            }),
                                            headers: {
                                                "Content-Type": "application/json",
                                                "Authorization": "Bearer " + data['data']['token']
                                            },
                                            redirect: 'follow'
                                        })
                                    }).then(response => {
                                        localStorage.setItem("kor", JSON.stringify(obj));
                                        document.location.reload(true)
                                    })
                            })
                    })
            }
            else {
                response.text().then(function (text) { alert(text) })
            }
        })
}


document.getElementsByClassName("sub-login-page")[0].onclick = function (e) {
    let login = document.getElementById('login-i').value;
    let passw = document.getElementById('pass-i').value;
    if (login.length > 0 && passw.length > 0) {
        fetch("http://localhost:5000/api/auth/authenticate", {
            method: 'POST',
            body: JSON.stringify({ "Login": "" + login + "", "Password": "" + passw + "" }),
            headers: {
                "Content-Type": "application/json"
            },
            redirect: 'follow'
        })
            .then(response => response.json())
            .then(data => {
                fetch("http://localhost:5000/api/clients/address/" + data['data']['id'], {
                    method: 'GET',
                    headers: {
                        "Content-Type": "application/json",
                        "Authorization": "Bearer " + data['data']['token']
                    },
                    redirect: 'follow'
                }).then(response => response.json())
                    .then(data2 => {
                        fetch("http://localhost:5000/api/clients/addressphone/" + data['data']['id'] + "/" + data2['data']['id'], {
                            method: 'GET',
                            headers: {
                                "Content-Type": "application/json",
                                "Authorization": "Bearer " + data['data']['token']
                            },
                            redirect: 'follow'
                        }).then(response => response.json())
                            .then(data3 => {
                                fetch("http://localhost:5000/api/clients/addressmail/" + data['data']['id'] + "/" + data2['data']['id'], {
                                    method: 'GET',
                                    headers: {
                                        "Content-Type": "application/json",
                                        "Authorization": "Bearer " + data['data']['token']
                                    },
                                    redirect: 'follow'
                                }).then(response => response.json())
                                    .then(data4 => {
                                        let obj = {
                                            name: data['data']['name'],
                                            surname: data['data']['surName'],
                                            login: data['data']['login'],
                                            token: data['data']['token'],
                                            phone: ""+data3['data'][0]['phoneNumber'],
                                            email: ""+data4['data'][0]['mail'],
                                            address: data2['data'][0],
                                            id: data['data']['id'],
                                            sum: 0,
                                            count: 0,
                                            items: []
                                        }
                                        localStorage.setItem("kor", JSON.stringify(obj));
                                        document.location.reload(true)
                                    })
                            })
                    })
            })
    }
}






function validateEmail(email) {
    const re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
}
function validatePhone(phone) {
    const re = /^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$/im;
    return re.test(String(phone).toLowerCase());
}