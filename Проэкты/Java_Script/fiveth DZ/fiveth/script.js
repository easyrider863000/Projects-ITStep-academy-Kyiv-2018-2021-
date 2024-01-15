let groups = ["Group1","Group2","Group3","Group4","Group5","Group6"];
let arr = [
    {
        name:"Group1",
        students:
        [
            "Student1",
            "Student2",
            "Student3"
        ],
        topic:"",
        checked_students:[],
        lesson:3
    },
    {
        name:"Group2",
        students:
        [
            "Student4",
            "Student5",
            "Student6"
        ],
        topic:"",
        checked_students:[],
        lesson:1
    },
    {
        name:"Group3",
        students:
        [
            "Student7",
            "Student8",
            "Student9"
        ],
        topic:"",
        checked_students:[],
        lesson:2
    },
    {
        name:"Group4",
        students:
        [
            "Student10",
            "Student11",
            "Student12"
        ],
        topic:"",
        checked_students:[],
        lesson:4
    },
    {
        name:"Group5",
        students:
        [
            "Student13",
            "Student14",
            "Student15"
        ],
        topic:"",
        checked_students:[],
        lesson:9
    },
    {
        name:"Group6",
        students:
        [
            "Student16",
            "Student17",
            "Student18"
        ],
        topic:"JS",
        checked_students:[0,1],
        lesson:1
    }
];
document.getElementById("hidden").style.display = "none";
document.getElementById("group").innerHTML = get_groups();
function get_groups(){
    let text = "";
    for(let i = 0;i<groups.length;i++){
        text+=`<option>${groups[i]}</option>`;
    }
    return text;
}
document.getElementById("select").addEventListener("click",showResult);
document.getElementById("save").addEventListener("click",saveResult);



function saveResult(){
    if(document.getElementById("topic").getElementsByTagName("input")[0].value.length>0){
        let stud = document.getElementById("students").getElementsByTagName("tr");
        let new_obj;
        new_obj = 
        {
            name:document.getElementById("group").value,
            lesson:document.getElementById("lesson").value,
            topic:document.getElementById("topic").getElementsByTagName("input")[0].value,
            students:[],
            checked_students:[]
        };
        for(let i = 1;i<stud.length;i++){
            new_obj["students"].push(stud[i].getElementsByTagName("td")[0].innerHTML);
            if(stud[i].getElementsByTagName("input")[0].checked){
                new_obj["checked_students"].push(i-1);
            }
        }
        arr.push(new_obj);
        showResult();
    }
}
function showResult(){
    document.getElementById("group").addEventListener("click",showResult);
    document.getElementById("lesson").addEventListener("click",showResult);
    document.getElementById("hidden").style.display = "block";
    
    selected_group = document.getElementById("group").value;
    selected_lesson = document.getElementById("lesson").value;
    document.getElementById("save").disabled=false;

    
    for(let i = 0;i<arr.length;i++){
        if(arr[i]["name"] == selected_group && arr[i]["lesson"] == selected_lesson){
            let stud = document.getElementById("students");
            stud.innerHTML = `<tr>
            <th style="width: 200px; text-align: left;">Name</th>
            <th>Is present</th>
            </tr>`;
            if(arr[i]["checked_students"].length>0){
                document.getElementById("topic").innerHTML = `${arr[i]["topic"]}`;            
                let is_check;
                for(let j = 0;j<arr[i]["students"].length;j++){
                    is_check = false;
                    for(let g = 0;g<arr[i]["checked_students"].length;g++){
                        if(j == arr[i]["checked_students"][g]){
                            is_check = true;
                        }
                    }
                    if(is_check){
                        stud.innerHTML+=`<tr>
                        <td>${arr[i]["students"][j]}</td>
                        <td>present</td>
                        </tr>`;
                    }
                    else{
                        stud.innerHTML+=`<tr>
                        <td>${arr[i]["students"][j]}</td>
                        <td></td>
                        </tr>`;
                    }
                }
                document.getElementById("save").disabled = true;
            }
            else{
                document.getElementById("topic").innerHTML = `<input type="text">`;
                for(let j = 0;j<arr[i]["students"].length;j++){
                    stud.innerHTML+=`<tr>
                        <td>${arr[i]["students"][j]}</td>
                        <td><input type="checkbox"></td>
                        </tr>`;
                }
            }
        }
        else if(arr[i]["name"] == selected_group ){
            let stud = document.getElementById("students");
            stud.innerHTML = `<tr>
            <th style="width: 200px; text-align: left;">Name</th>
            <th>Is present</th>
            </tr>`;          
            document.getElementById("topic").innerHTML = `<input type="text">`;
            for(let j = 0;j<arr[i]["students"].length;j++){
                stud.innerHTML+=`<tr>
                <td>${arr[i]["students"][j]}</td>
                <td><input type="checkbox"></td>
                </tr>`;
            } 
        }
    }
}


