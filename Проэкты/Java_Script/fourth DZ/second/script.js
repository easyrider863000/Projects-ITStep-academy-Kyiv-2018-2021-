i = 1;
let photos = ["https://cdn4.riastatic.com/photos/ir/new/auto/photo/bmw_640__294330119-620x415x70.webp",
"https://s0.rbk.ru/v6_top_pics/resized/1400x700_crop/media/img/0/16/754793048832160.jpg",
"https://img2.goodfon.ru/wallpaper/nbig/5/d2/subaru-impreza-wrx-sti-tuning-3950.jpg",
"https://i.pinimg.com/originals/fc/af/dc/fcafdc911ebbc49f124fdd2c414b77c1.png",
"https://scontent-yyz1-1.cdninstagram.com/v/t51.2885-15/e35/74694527_996586074029908_6900597065417917057_n.jpg?_nc_ht=scontent-yyz1-1.cdninstagram.com&_nc_cat=104&_nc_ohc=QyyWl7AFH-UAX9Dj2Mx&oh=ec83c2d7c3423afeb9e8f3ec9f06c1e5&oe=5E83F27E",
"https://i.pinimg.com/originals/90/9f/5e/909f5e6fefbb07830f0e8325bdd5a409.jpg",
"https://i.pinimg.com/736x/93/ae/4a/93ae4a33aa8e13cd33469ddaea8ce31e.jpg",
"https://c4.wallpaperflare.com/wallpaper/641/315/813/nissan-jdm-tuning-nissan-silvia-s15-wallpaper-preview.jpg",
"https://www.wallpaperup.com/uploads/wallpapers/2014/10/27/496994/79ade47172faf8cc98d1181110057ad0-700.jpg"];
document.getElementById("img").setAttribute("src",photos[0]);
document.getElementById("btn-left").onclick = function(e){
    document.getElementById("img").setAttribute("src",photos[i]);
    getPrev();
    
}
document.getElementById("btn-right").onclick = function(e){
    document.getElementById("img").setAttribute("src",photos[i]);
    getNext();
}




function getNext(){
    if(i+1<photos.length){
        i++;
    }
    else if(i+1 == photos.length){
        i = 0;
    }
}
function getPrev(){
    if(i>0){
        i--;
    }
    else if(i == 0){
        i = photos.length-1;
    }
}