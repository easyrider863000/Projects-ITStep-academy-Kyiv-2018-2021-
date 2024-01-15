update();
function update() {
    if (localStorage.getItem("kor") !== null) {
        let data = JSON.parse(localStorage.getItem("kor"))
        if ((data)['count'] > 0) {
            document.getElementsByClassName("center-user")[0].innerHTML = "<b>" + data['name'] + "</b><br>" + data['sum'] + " PLN"
            document.getElementsByClassName("kor-img")[0].innerHTML = '<div class="count-kor">' + data['count'] + '</div>'
        }
        else {
            document.getElementsByClassName("center-user")[0].innerHTML = "<b>" + data['name'] + "</b><br>0 PLN"
        }
        document.getElementsByClassName("last-btn")[0].innerHTML = "Wyloguj się"
    }
    else {
        document.getElementsByClassName("center-user")[0].innerHTML = "<b>Guest</b><br>0 PLN"
        document.getElementsByClassName("last-btn")[0].innerHTML = "Zaloguj się"
    }
}

document.getElementsByClassName("last-btn")[0].onclick = function (e) {
    if (localStorage.getItem("kor") !== null) {
        localStorage.removeItem("kor");
        document.location.reload(true);
    }
    else {
        window.location.href = "../../login.html";
    }
}