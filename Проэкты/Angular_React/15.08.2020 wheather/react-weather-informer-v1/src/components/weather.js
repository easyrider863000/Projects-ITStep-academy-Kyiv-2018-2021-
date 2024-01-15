import React from 'react';
import '../App.css';

class Weather extends React.Component {

    render() {
            return (
                
                <div id="weather_box">

                <div class="container">
                {JSON.parse(sessionStorage.getItem('forecast')).map(answer=>{
                return(<div class="item">
                    <div>{answer['date']}</div>
                    <img src={"http:"+answer['day']['condition']['icon']}/>
                    <div>Min: {answer['day']['mintemp_c']}&#8451;</div>
                    <div>Max: {answer['day']['maxtemp_c']}&#8451;</div>
                </div>)
                })
                    
                
                }
                </div>
            </div>
        )
    }
}

export default Weather;
