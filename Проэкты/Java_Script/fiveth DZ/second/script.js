let answers = [];
let questions = [
    {
        question:"How many letters are in the word \"Hello\"",
        answer:["5","2"],
        correct_answer:0
    },
    {
        question:"How many letters are in the word \"World\"",
        answer:["4","5"],
        correct_answer:1
    },
    {
        question:"How many letters are in the word \"Script\"",
        answer:["5","6"],
        correct_answer:1
    },
    {
        question:"How many letters are in the word \"Accord\"",
        answer:["6","7"],
        correct_answer:0
    },
    {
        question:"How many letters are in the word \"Corolla\"",
        answer:["7","1"],
        correct_answer:0
    }
];
let j = 0;
document.getElementById("que").innerHTML = (j+1)+") "+questions[j].question+" ?";
document.getElementById("lab1").innerHTML = questions[j].answer[0];
document.getElementById("lab2").innerHTML = questions[j].answer[1];
j++;
document.getElementById("btn").onclick = function(e){
    let radios = document.getElementsByName("radio");
    let f = false;
    for(let i = 0;i<radios.length;i++){
        if(radios[i].checked){
            f = true;
            answers.push(radios[i].value);
        }
    }
    if(f){
        if(j<questions.length){
            if(j == questions.length-1){
                document.getElementById("btn").value = "Finish";
            }
            document.getElementById("que").innerHTML = (j+1)+") "+questions[j].question+" ?";
            document.getElementById("lab1").innerHTML = questions[j].answer[0];
            document.getElementById("lab2").innerHTML = questions[j].answer[1];
            document.getElementById("ans1").checked = false;
            document.getElementById("ans2").checked = false;
        }
        else{
            document.getElementById("block1").style.display = "none";
            let balls = 0;
            for(let i = 0;i<answers.length;i++){
                if(answers[i] == questions[i]["correct_answer"]){
                    balls++;
                }    
            }
            document.getElementById("block2").innerHTML = "Result: "+balls+" correct answers to "+questions.length+" questions.";
        }
        j++;
    }
}