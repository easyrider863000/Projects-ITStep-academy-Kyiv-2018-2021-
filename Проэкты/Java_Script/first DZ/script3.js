// //task 1
// function is_num(ch){
//     if(ch in [0,0,0,0,0,0,0,0,0,0]){
//         return true;
//     }
//     return false;
// }
// function is_char(ch){
//     let chars = "qwertyuiopasdfghjklzxcvbnm";
//     for(i in chars){
//         if(chars[i] == ch)
//         return true;
//     }
//     return false;
// }
// function is_symb(ch){
//     let chars = "!@#$%^&*()_+\\|-={}[]:\"\',.<>/?`~";
//     for(i in chars){
//         if(chars[i] == ch)
//         return true;
//     }
//     return false;
// }
// function statistika(str){
//     let ch = 0;
//     let num = 0;
//     let sym = 0;
//     for(let i in str){
//         if(is_symb(str[i])){
//             sym++;
//         }
//         else if(is_num(str[i])){
//             num++;
//         }
//         else if(is_char(str[i])){
//             ch++;
//         }
//     }
//     document.write(`<h1>String = ${str}</h1>`)
//     document.write(`<h1>Chars = ${ch}</h1>`)
//     document.write(`<h1>Nums = ${num}</h1>`)
//     document.write(`<h1>Symbols = ${sym}</h1>`)
// }
// statistika("0=s.$5*t(rin)9.1\\g");





// //task 2
// function num_to_string(num){
//     if(num<10||num>=100){
//         return;
//     }
//     let num1 = (num-num%10)/10
//     let num2 = num%10;
//     let str_res = "";
//     if(num1==1){
//         switch(num2){
//             case 0:
//                 str_res+="десять";
//                 break;
//             case 1:
//                 str_res+="одиннадцать";
//             break;
//             case 2:
//                 str_res+="двенадцать";
//             break;
//             case 3:
//                 str_res+="тринадцать";
//             break;
//             case 4:
//                 str_res+="четырнадцать";
//             break;
//             case 5:
//                 str_res+="пятнадцать";
//             break;
//             case 6:
//                 str_res+="шестнадцать";
//             break;
//             case 7:
//                 str_res+="семнадцать";
//             break;
//             case 8:
//                 str_res+="восемнадцать";
//             break;
//             case 9:
//                 str_res+="девятнадцать";
//             break;
//         }
//     }
//     else{
//         switch(num1){
//             case 2:
//                 str_res+="двадцать";
//             break;
//             case 3:
//                 str_res+="тридцать";
//             break;
//             case 4:
//                 str_res+="сорок";
//             break;
//             case 5:
//                 str_res+="пятдесят";
//             break;
//             case 6:
//                 str_res+="шестьдесят";
//             break;
//             case 7:
//                 str_res+="семьдесят";
//             break;
//             case 8:
//                 str_res+="восемьдесят";
//             break;
//             case 9:
//                 str_res+="девяносто";
//             break;
//         }
//         str_res+=" ";
//         switch(num2){
//             case 1:
//                 str_res+="один";
//             break;
//             case 2:
//                 str_res+="два";
//             break;
//             case 3:
//                 str_res+="три";
//             break;
//             case 4:
//                 str_res+="четыре";
//             break;
//             case 5:
//                 str_res+="пять";
//             break;
//             case 6:
//                 str_res+="шесть";
//             break;
//             case 7:
//                 str_res+="семь";
//             break;
//             case 8:
//                 str_res+="восемь";
//             break;
//             case 9:
//                 str_res+="девять";
//             break;
//         }
//     }
//     return str_res;
// }
// alert(num_to_string(19));





// //task3
// function is_symb(ch){
//     let chars = "!@#$%^&*()_+\\|-={}[]:\"\',.<>/?`~";
//     for(i in chars){
//         if(chars[i] == ch)
//             return true;
//     }
//     return false;
// }
// function change_chars(str){
//     let new_str = "";
//     for(let i in str){
//         if(str[i] in [0,0,0,0,0,0,0,0,0,0]){
//             new_str+='_';
//         }
//         else if(!is_symb(str[i])){
//             if(str[i] == str[i].toLowerCase()){
//                 new_str+=str[i].toUpperCase();
//             }
//             else{
//                 new_str+=str[i].toLowerCase();
//             }
//         }
//         else{
//             new_str+=str[i];
//         }
//     }
//     return new_str;
// }
// alert(change_chars("2HELLO1world3"));







// //task 4
// function css_to_CamelCase(css){
//     let CamelCase = "";
//     for(let i in css){
//         if(css[i]=='-'){}
//         else if(css[i-1] =='-'){
//             CamelCase+=css[i].toUpperCase();
//         }
//         else{
//             CamelCase+=css[i];
//         }
//     }
//     return CamelCase;
// }
// alert(css_to_CamelCase("text-align"));







// //task5
// function ABR(str){
//     let new_str = "";
//     for(let i in str){
//         if(str[i]!=" "){
//             if(i==0){
//                 new_str = str[i].toUpperCase();
//             }
//             else if(str[i-1] ==' ' || str[i-1] =='-'){
//                 new_str+=str[i].toUpperCase();
//             }
//         }
//     }
//     return new_str;
// }
// alert(ABR("объектно-ориентированное программирование"));






// //task 6
// function long_string() {
//     let result = "";
//     for (let i = 0; i < arguments.length; i++) {
//         result += arguments[i];
//     }
//     return result;
// }
// alert(long_string("hello ","world"," or"," not"," world"));






// //task7
// function calk(str){
//     let arr = str.split(/[-+/*]/);
//     let resp = 0;
//     if(str.indexOf('/')>=0){
//         resp = parseFloat(arr[0])/parseFloat(arr[1]);
//     }
//     else if(str.indexOf('*')>=0){
//         resp = parseFloat(arr[0])*parseFloat(arr[1]);
//     }
//     else if(str.indexOf('-')>=0){
//         resp = parseFloat(arr[0])-parseFloat(arr[1]);
//     }
//     else if(str.indexOf('+')>=0){
//         resp = parseFloat(arr[0])+parseFloat(arr[1]);
//     }
//     return resp;
// }
// alert(calk("10*2"));





// //task 8
// function site_info(str){
//     protocol = str.substring(0,str.toString().indexOf("://"));
//     str = str.substring(str.toString().indexOf("://")+3);
//     domen = str.substring(0,str.indexOf("/"));
//     path = str.substring(str.indexOf("/"));
//     document.write(`<h1>Protocol: ${protocol}</h1>`)
//     document.write(`<h1>Domen: ${domen}</h1>`)
//     document.write(`<h1>Path: ${path}</h1>`)
// }
// site_info("https://itstep.org/ua/about");







// //task 9
// function split_string(str,r) {
//     str = str+r;
//     let arr = [];
//     let tmp = "";
//     for(let i = 0;i<str.length;i++){
//         if(str[i]!=r){
//             tmp+=str[i];
//         }
//         else if(str[i]==r){
//             arr.push(tmp);
//             tmp = "";
//         }
//     }
//     return arr;
// }
// alert(split_string("10/08/2002",'/'));






// //task 10
// function print(str) {
//     let arr = [];
//     for (let i = 1; i < arguments.length; i++) {
//         arr.push(arguments[i]);
//     }
//     new_str = "";
//     for(let i = 0;i<str.length;i++){
//         if(i!=0 && str[i-1] == '%' && str[i] in [0,0,0,0,0,0,0,0,0,0]){
//             new_str+=arr.shift();
//         }
//         else if(str[i]!='%'){
//             new_str+=str[i];
//         }
//     }
//     return new_str;
// }
// alert(print("Today is %1 %2.%3.%4","Monday","10","08","2020"));