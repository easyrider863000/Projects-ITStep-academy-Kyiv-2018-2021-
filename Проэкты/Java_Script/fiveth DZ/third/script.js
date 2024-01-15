document.getElementById("result").style.display = "none";
document.getElementById("btn").onclick = function(e){
    if(document.getElementById("text").value.length>0){
        let ch = document.getElementsByName("check");
        let text = "";
        for(let i =0;i<ch.length;i++){
            if(ch[i].checked){
                text+="<"+ch[i].value+">";
            }
        }
        text+=document.getElementById("text").value;
        for(let i =ch.length-1;i>0;i--){
            if(ch[i].checked){
                text+="</"+ch[i].value+">";
            }
        }
        let rd = document.getElementsByName("radio");
        for(let i =0;i<rd.length;i++){
            if(rd[i].checked){
                document.getElementById("text-result").style.textAlign = rd[i].value;        
            }
        }
        document.getElementById("result").style.display = "block";
        document.getElementById("text-result").innerHTML = text;
    }
}