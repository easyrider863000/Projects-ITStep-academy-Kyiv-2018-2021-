document.onclick = function(e){
    let field = document.getElementById("field");
    let ball = document.getElementById("ball");
    if(e.x-field.offsetLeft+ball.offsetWidth/2 <field.offsetWidth && e.y-field.offsetTop+ball.offsetHeight/2<field.offsetHeight && e.x - field.offsetLeft>ball.offsetWidth/2&&e.y - field.offsetTop>ball.offsetHeight/2){
        document.getElementById("ball").style.left = `${e.x - ball.offsetWidth/2}px`;
        document.getElementById("ball").style.top = `${e.y - ball.offsetHeight/2}px`;
    }
};