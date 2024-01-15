import React from 'react';
import './App.css';
import Info from './components/info.js';
import Form from './components/form.js';
import Weather from './components/weather.js';

const API_KEY = '32a9e645f12140d09b1214816201604';
const days=7
class App extends React.Component {

    get_weather = async (event) => {
        event.preventDefault();
        let api_city = event.target.elements.city.value;
        let api_data = await fetch(`http://api.weatherapi.com/v1/forecast.json?key=${API_KEY}&q=${api_city}&days=${days}`);
        let api_json = await api_data.json();
        sessionStorage.setItem('forecast', JSON.stringify(api_json['forecast']['forecastday']));
        window.location.reload(false);
    }

    render() {
        return (
            <div id="main_box">
                <Info />
                <Form weather={this.get_weather} />
                <Weather />
            </div>
        )
    }

}

export default App;
