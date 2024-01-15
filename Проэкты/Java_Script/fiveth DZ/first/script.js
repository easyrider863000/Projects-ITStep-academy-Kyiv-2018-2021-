document.getElementById("send").onclick = function(e){
    let d = new Date(Date.now());
    let time = d.toLocaleTimeString()+" "+d.toLocaleDateString();

    let name = document.getElementById("name");
    let msg = document.getElementById("msg");
    let child = document.createElement('div');
    child.innerHTML = `<div class="item">
    <div class="container">
        <span>${name.value}</span>
        <span>${time}</span>
    </div>
    <hr>
    <div>
        ${msg.value}
    </div>
</div>`
    document.getElementById("msgs").append(child);
    name.value = "";
    msg.value = "";
}


