// // task-1
// class Car{
//     constructor(manufacturer,model,year,avg_speed)
//     {
//         this.manufacturer = manufacturer;
//         this.model = model;
//         this.year = year;
//         this.avg_speed = avg_speed;
//     }
//     print(){
//         alert("Manufacturer: "+this.manufacturer
//         +"\nModel: "+this.model
//         +"\nYear: "+this.year
//         +"\nAvarage speed : "+this.avg_speed);
//     }
//     GetTime(distance) {
//         let time = distance/this.avg_speed;
//         if (time>4) {
//             time = time+Math.floor(Math.round(time)/4)
//         }
//         time = time.toFixed(1);
//         return time;
//     }
// }

// let car = new Car("BMW","640i","2013","100");
// car.print();
// alert(car.GetTime(1000));



// // task-2
// class Fraction{
//     constructor(numerator, denominator){
//         this.numerator = numerator;
//         this.denominator = denominator;
//     }
//     NormalizeFraction(Fraction){
//         if(Fraction.denominator==0 || Fraction.numerator==0){
//             Fraction.numerator = 0;
//             Fraction.denominator = 0;
//             return 0;
//         }
//         if(Fraction.numerator<0 && Fraction.denominator<0){
//             Fraction.numerator = Fraction.numerator+Math.abs(Fraction.numerator)*2;
//             Fraction.denominator = Fraction.denominator+Math.abs(Fraction.denominator)*2;
//         }
//         let sm;
//         if(Fraction.numerator==Fraction.denominator){
//             Fraction.denominator = 1;
//             Fraction.numerator = 1;
//             return Fraction;
//         }
//         else if(Fraction.numerator>Fraction.denominator){
//             sm = Math.abs(Fraction.denominator);
//         }
//         else{
//             sm = Math.abs(Fraction.numerator);
//         }
//         for (var i = sm; i > 1; i--){
//             if(Fraction.numerator%i==0&&Fraction.denominator%i==0){
//                 Fraction.numerator = Fraction.numerator/i;
//                 Fraction.denominator = Fraction.denominator/i;
//             }             
//         }
//     }
//     Plus(Fraction1,Fraction2){
//         this.numerator = Fraction2.numerator*Fraction1.denominator+Fraction2.denominator*Fraction1.numerator;
//         this.denominator = Fraction2.denominator*Fraction1.denominator;
//         this.NormalizeFraction(this);
//         return this;
//     }
//     Minus(Fraction1,Fraction2){
//         this.numerator = Fraction2.denominator*Fraction1.numerator-Fraction2.numerator*Fraction1.denominator;
//         this.denominator = Fraction2.denominator*Fraction1.denominator;
//         this.NormalizeFraction(this);
//         return this;
//     }
//     Multiply(Fraction1,Fraction2){
//         this.numerator = Fraction2.numerator*Fraction1.numerator;
//         this.denominator = Fraction2.denominator*Fraction1.denominator;
//         this.NormalizeFraction(this);
//         return this;
//     }
//     Divide(Fraction1,Fraction2){
//         this.numerator = Fraction1.numerator*Fraction2.denominator;
//         this.denominator = Fraction1.denominator*Fraction2.numerator;
//         this.NormalizeFraction(this);
//         return this;
//     }
    
// }

// let fr1 = new Fraction(32,3);
// let fr2 = new Fraction(16,9);
// fr1.Minus(fr1,fr2);
// // fr1.Plus(fr1,fr2);
// // fr1.Multiply(fr1,fr2);
// // fr1.Divide(fr1,fr2);
// alert(fr1.numerator+"   "+fr1.denominator);




// // task3
// class Time{
//     constructor(hour,minute,second){
//         if(this.is_valid(hour,minute,second)){
//             this.hour = hour;
//             this.minute = minute;
//             this.second = second;
//         }
//         else{
//             this.hour = 0;
//             this.minute = 0;
//             this.second = 0;
//         }
//     }
//     print(){
//         alert(this.hour+" : "+this.minute+" : "+this.second);
//     }

//     normilize_time(){
//         this.hour = this.hour%24;
//         this.minute = this.minute%60;
//         this.second = this.second%60;
//     }
//     is_valid(h, m, s){
//         if(h>=1&&h<=23){
//             if(m>=0&&m<=59){
//                 if(s>=0&&s<=59){
//                     return true;
//                 }
//             }
//         }
//         else if(h==0){
//             if(m==0){
//                 if(s>=1&&s<=59){
//                     return true;
//                 }
//             }
//             else if(m>=1&&m<=59){
//                 if(s>=0&&s<=59){
//                     return true;
//                 }
//             }
//         }
//         return false;
//     }
//     second_to_time(sec){
//         //alert((sec - ((sec%3600 - sec%60)) - (sec%60))/3600)
//         //alert((sec%3600 - sec%60)/60);
//         //alert((sec%60));
//         if(sec>86400){
//             sec = sec%86400;
//         }

//         return new Time((sec - ((sec%3600 - sec%60)) - (sec%60))/3600,(sec%3600 - sec%60)/60,sec%60)
//     }
//     time_to_second(time){
//         return time.hour*60*60+time.minute*60+time.second;
//     }
//     plus_seconds(sec){
//         let scnd = sec+this.time_to_second(this);
//         this.hour = this.second_to_time(scnd).hour;
//         this.minute = this.second_to_time(scnd).minute;
//         this.second = this.second_to_time(scnd).second;
//     }
//     plus_minutes(min){
//         let scnd = this.time_to_second(this)+min*60;
//         this.hour = this.second_to_time(scnd).hour;
//         this.minute = this.second_to_time(scnd).minute;
//         this.second = this.second_to_time(scnd).second;
//     }
//     plus_hours(hour){
//         let scnd = this.time_to_second(this)+hour*3600;
//         this.hour = this.second_to_time(scnd).hour;
//         this.minute = this.second_to_time(scnd).minute;
//         this.second = this.second_to_time(scnd).second;
//     }
// }


// // var time = new Time(0,0,1);
// // time.print();
// // time.plus_hours(23);
// // time.plus_minutes(59);
// // time.plus_seconds(58);
// // time.print();