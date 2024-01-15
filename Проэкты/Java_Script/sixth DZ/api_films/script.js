class Movie{
    constructor(id,title,year,poster,released,genre,country,director,writer,actors,awards){
        this.id=id;
        this.title=title;
        this.year=year;
        this.poster=poster;
        this.released=released;
        this.genre=genre;
        this.country=country;
        this.director=director;
        this.writer=writer;
        this.actors=actors;
        this.awards=awards;
    }
}
class searchResponse{
    constructor(arr,pages,curPage){
        this.arr=arr;
        this.pages=pages;
        this.curPage = curPage;
    }
}

class MovieService{
    constructor(apikey){
        this.apiKey = apikey;
    }
    async search(title,type,page){
        return await fetch(`http://www.omdbapi.com/?apikey=${this.apiKey}&s=${title}&type=${type}&page=${page}`).then(obj=>obj.json()).then(prom=>{ return new searchResponse(prom["Search"],Math.ceil(parseInt(prom["totalResults"])/10),page)});
    }
    async getMovie(movieId){
        return await fetch(`http://www.omdbapi.com/?apikey=${this.apiKey}&i=${movieId}`).then(obj=>obj.json().then(prom=>{return new Movie(prom["imdbID"],prom["Title"],prom["Year"],prom["Poster"],prom["Released"],prom["Genre"],prom["Country"],prom["Director"],prom["Writer"],prom["Actors"],prom["Awards"])}));
    }
}


let ms = new MovieService("9d8e406b");

document.getElementById("more").style.display = "none";
document.getElementById("btn-srch").onclick = function(e){
    let title = document.getElementById("title").value;
    let type = document.getElementById("type").value;
    if(title.length>0){
        document.getElementById("Films").innerHTML = "";
        document.getElementById("load").style.display = "block";        
        ms.search(title,type,1).then(film=>{
            let curPage = 1;
            for(let i = 0;i<film.arr.length;i++){
                document.getElementById("Films").innerHTML+=`
                <div class="film">
                <span class="imdbID" style="display: none;">${film.arr[i]["imdbID"]}</span>
                <img width="150px" src="${film.arr[i]["Poster"]}">
                <h3>${film.arr[i]["Title"]}</h3>
                <span>${film.arr[i]["Year"]}</span>
                <button class="details">Details</button>
                </div>`;        
            }
            if(film.pages>1){
                document.getElementById("more").style.display = "block";
                document.getElementById("more").addEventListener("click",function(e){
                    document.getElementById("load").style.display = "block"; 
                    curPage++;
                    if(film.pages>=curPage){

                    ms.search(title,type,curPage).then(film=>{
                        for(let i = 0;i<film.arr.length;i++){
                            document.getElementById("Films").innerHTML+=`
                            <div class="film">
                            <span class="imdbID" style="display: none;">${film.arr[i]["imdbID"]}</span>
                            <img width="150px" src="${film.arr[i]["Poster"]}">
                            <h3>${film.arr[i]["Title"]}</h3>
                            <span>${film.arr[i]["Year"]}</span>
                            <button class="details">Details</button>
                            </div>`;       
                        }
                    for(let i = 0;i<document.getElementsByClassName("details").length;i++){
                        document.getElementsByClassName("details")[i].addEventListener("click",()=>OpenModal(document.getElementsByClassName("details")[i]));
                    }
                    document.getElementById("load").style.display = "none";         
                    
                });
            }
            else{
                document.getElementById("more").style.display = "none";
                document.getElementById("load").style.display = "none";
            }
            });
                
            }
            else{
                document.getElementById("more").style.display = "none";
            }
            for(let i = 0;i<document.getElementsByClassName("details").length;i++){
                    document.getElementsByClassName("details")[i].addEventListener("click",()=>OpenModal(document.getElementsByClassName("details")[i]));    
                }
            document.getElementById("load").style.display = "none";         
        });  
    }
}

function OpenModal(detail){
    let id = detail.parentElement.getElementsByClassName("imdbID")[0].innerHTML;
    document.getElementById("modalWindow").style.display = "block";
        document.getElementById("modalWindow").innerHTML = `
        <div class="modal-content">
        <span class="close">&times;</span>
        <div style="text-align: center;">    
        <img style="width:50px;" src="gif.gif">
        </div>
    </div>`;
    ms.getMovie(id).then(film=>{
        document.getElementById("modalWindow").innerHTML = 
        `<div class="modal-content">
            <span class="close">&times;</span>
            <div class="col">
                <img src="${film["poster"]}" >
                <div>
                    <div class="col">
                        <b>Title:</b>
                        <span>${film["title"]}</span>
                    </div>
                    <div class="col">
                        <b>Released:</b>
                        <span>${film["released"]}</span>
                    </div>
                    <div class="col">
                        <b>Genre:</b>
                        <span>${film["genre"]}</span>
                    </div>
                    <div class="col">
                        <b>Country:</b>
                        <span>${film["country"]}</span>
                    </div>
                    <div class="col">
                        <b>Director:</b>
                        <span>${film["director"]}</span>
                    </div>
                    <div class="col">
                        <b>Writer:</b>
                        <span>${film["writer"]}</span>
                    </div>
                    <div class="col">
                        <b>Actors:</b>
                        <span>${film["actors"]}</span>
                    </div>
                    <div class="col">
                        <b>Awards:</b>
                        <span>${film["awards"]}</span>
                    </div>
                </div>
            </div>
        </div>`;
        document.getElementsByClassName("close")[0].onclick = function(){
            document.getElementById("modalWindow").style.display = "none";
        }
    })
}