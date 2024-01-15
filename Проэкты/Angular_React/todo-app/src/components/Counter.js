import React from 'react'

function Counter(props) {
    return (
        <div>
            <div className="d-flex align-items-center flex-column">
                <div>
                    <span className="display-3">{props.count}</span>
                </div>
                <div>
                    <button
                        className="btn btn-primary m-2"
                        onClick={() => props.add()}
                    >
                        Increment
                            </button>
                    <button
                        className="btn btn-secondary m-2"
                        onClick={() => props.substract()}
                    >
                        Decrement
                            </button>
                </div>
            </div>
        </div>
    )
}


export default Counter