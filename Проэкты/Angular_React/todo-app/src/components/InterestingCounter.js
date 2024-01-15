import React from 'react'


function InterestingCounter(props) {
    return (
        <div className="d-flex align-items-center rounded-circle border border-primary">
            <span className="display-3">{props.value}</span>
        </div>
    )
}

export default InterestingCounter