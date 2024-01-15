import React from 'react';
import './JokeInfo.css';

function JokeInfo(props) {
    return (
            <div className="joke">
                <div className="joke-prop question">{props.info.question}</div>
                <div className="joke-prop punchline">{props.info.punchline}</div>
            </div>
    );
}

export default JokeInfo;