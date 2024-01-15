
let trackItem = document.querySelector('#trackItem');
let rail = document.querySelector('#rail');
let trackBar = document.querySelector("#trackBar");

let isMouseDown = false;

trackItem.addEventListener('mousedown',function(e) {
    isMouseDown = true;
});

document.addEventListener('mouseup',function(e) {
    isMouseDown = false;
});

document.addEventListener('mousemove', function(e) {

    let x = e.x;

    if (isMouseDown && x >= rail.offsetLeft && x <= rail.offsetLeft+rail.offsetWidth) {
        trackItem.style.left = `${x - 40}px`;
    }
});