import React from 'react';
import '../App.css';

class Form extends React.Component {

    render() {
        return (
            <div id="form_box">
                <form onSubmit={this.props.weather}>
                    <input type="text" name="city" placeholder="Город"/>
                    <button>Получить погоду</button>
                </form>
            </div>
        )
    }

}

export default Form;
