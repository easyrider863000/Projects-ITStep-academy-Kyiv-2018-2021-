import React from 'react';
import './JokeList.css';
import JokeInfo from './JokeInfo.js';
import {JOKES} from '../jokes';

function JokesList() {
    return (
        <div className="jokes-list">    
            {JOKES.map(joke => <JokeInfo info={joke} />)}
        </div>
    );
}

export default JokesList;