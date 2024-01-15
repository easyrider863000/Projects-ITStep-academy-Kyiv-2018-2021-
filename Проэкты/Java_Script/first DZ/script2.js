// //Task-1
// class Buy{
//     constructor(name,count){
//         this.count = count;
//         this.name = name;
//         this.is_buy = false;
//     }
// }
// let arr = [new Buy("Bread",10),
//         new Buy("Coca-Cola",50),
//         new Buy("Beer",30)];
// function print(){
//     for(let prop in arr){
//         if(!arr[prop].is_buy){
//             document.write(`<h1>${arr[prop].name}  ${arr[prop].count}  ${arr[prop].is_buy}</h1>`);
//         }
//     }
//     for(let prop in arr){
//         if(arr[prop].is_buy){
//             document.write(`<h1>${arr[prop].name}  ${arr[prop].count}  ${arr[prop].is_buy}</h1>`);
//         }
//     }
// }
// function add_new_product(product){
//     let f = true;
//     for(let i in arr){
//         if(arr[i].name == product.name){
//             if(arr[i].is_buy){
//                 arr[i].count = product.count;
//                 arr[i].is_buy = false;
//                 f = false;
//             }
//             else{
//                 arr[i].count+=product.count;
//                 f = false;
//             }
//         }
//     }
//     if(f){
//         arr.push(product);
//     }
// }
// function buy_product(name_product){
//     for(let i in arr){
//         if(arr[i].name == name_product && arr[i].is_buy==false){
//             arr[i].is_buy = true;
//         }
//     }
// }

// buy_product("Coca-Cola");
// add_new_product(new Buy("Coca-Cola",10));
// print();



// //task 2
// class Product{
//     constructor(name,count,price){
//         this.name = name;
//         this.count = count;
//         this.price = price;
//     }
// }
// let arr = [new Product("Bread",2,12.50),
//     new Product("Pepper",5,50),
//     new Product("Tomato",3,15),
//     new Product("Milk",1,23),
//     new Product("Beer",6,28),
//     new Product("Cheese",3,70),
//     new Product("Meat",2,103),
//     new Product("Sugar",2,16),
//     new Product("Eggs",20,0.50)];
// function print(){
//     for(let i in arr){
//         document.write(`<h1>${parseInt(i)+1}. ${arr[i].name} ------ ${arr[i].price} * ${arr[i].count} = ${arr[i].price*arr[i].count}</h1>`)
//     }
// }
// function get_sum(){
//     let sum = 0;
//     for(let i in arr){
//         sum+=arr[i].price*arr[i].count;
//     }
//     return sum;
// }
// function get_big_buy(){
//     let big_buy = arr[0];
//     for(let i = 0;i<arr.length;i++){
//         if(arr[i].price*arr[i].count>big_buy.price*big_buy.count){
//             big_buy = arr[i];
//         }
//     }
//     return big_buy;
// }
// function get_avg_buy(){
//     let avg_buy = 0;
//     for(let i = 0;i<arr.length;i++){
//         avg_buy+=arr[i].price*arr[i].count;
//     }
//     if(avg_buy!=0){
//         avg_buy/=arr.length;
//         return avg_buy.toFixed(2);
//     }
//     else {
//         return 0;
//     }
// }

// //alert(get_avg_buy());
// //alert(get_big_buy().name);
// print();




// //task3
// let styles = [{
//     name:"color",
//     value:"red"
// },
// {
//     name:"font-weight",
//     value:"5em"
// },
// {
//     name:"text-decoration",
//     value:"line-through"
// },
// {
//     name:"text-align",
//     value:"center"
// }];
// function with_styles(text, arr){
//     let req_str = "<p style=\"";
//     for(let i in arr){
//         req_str+=arr[i]["name"]+":"+arr[i]["value"]+"; ";
//     }
//     req_str+=`\">${text}</p>`;
//     document.write(req_str);
// }
// with_styles("hello world",styles);






// //task 4
// class Classroom{
//     constructor(name_fklt,amount_of_people,name){
//         this.name = name;
//         this.name_fklt = name_fklt;
//         this.amount_of_people = amount_of_people;
//     }
// }
// class Group{
//     constructor(name_fklt,amount_of_people,name){
//         this.name = name;
//         this.name_fklt = name_fklt;
//         this.amount_of_people = amount_of_people;
//     }
// }
// let classrooms = [new Classroom("Информатика и вычислительная техника", 19, "ab"),
// new Classroom("Прикладная информатика", 11, "ba"),
// new Classroom("Программная инженерия", 13, "3"),
// new Classroom("Информационная безопасность", 17, "4"),
// new Classroom("Приборостроение", 15, "5"),
// new Classroom("Бизнес-информатика", 16, "6"),
// new Classroom("Информатика и вычислительная техника", 10, "7"),
// new Classroom("Прикладная информатика", 12, "8"),
// new Classroom("Программная инженерия", 20, "9"),
// new Classroom("Информационная безопасность", 19, "a"),
// new Classroom("Приборостроение", 14, "11"),
// new Classroom("Бизнес-информатика", 12, "12"),
// new Classroom("Информатика и вычислительная техника", 11, "13"),
// new Classroom("Прикладная информатика", 15, "14"),
// new Classroom("Программная инженерия", 14, "15"),
// new Classroom("Информационная безопасность", 10, "16"),
// new Classroom("Приборостроение", 13, "17"),
// new Classroom("Бизнес-информатика", 12, "18"),
// ];

// function print(){
//     for(let i in classrooms){
//         document.write(`<h1>${classrooms[i].name} аудитория - ${classrooms[i].amount_of_people} мест - ${classrooms[i].name_fklt}</h1>`)
//     }
// }
// function print_classrooms_by_fklt(fklt){
//     for(let i in classrooms){
//         if(fklt == classrooms[i].name_fklt)
//         document.write(`<h1>${classrooms[i].name} аудитория - ${classrooms[i].amount_of_people} мест - ${classrooms[i].name_fklt}</h1>`)
//     }
// }
// function print_classrooms_by_group(group){
//     for(let i in classrooms){
//         if(group.name_fklt == classrooms[i].name_fklt && group.amount_of_people<=classrooms[i].amount_of_people)
//         {
//             document.write(`<h1>${classrooms[i].name} аудитория - ${classrooms[i].amount_of_people} мест - ${classrooms[i].name_fklt}</h1>`)
//         }
//     }
// }
// function sort_by_amount(){
//     classrooms.sort(function(a,b){
//         return a.amount_of_people-b.amount_of_people;
//     })
// }
// function sort_by_name(){
//     classrooms = classrooms.sort(function(a,b){
//         if(a.name<b.name){
//             return 1;
//         }
//         else{
//             return -1;
//         }
//     });
// } 

// sort_by_name();
// print();