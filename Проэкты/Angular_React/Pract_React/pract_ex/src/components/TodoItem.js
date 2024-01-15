import React from 'react'
import './TodoItem.css'

function TodoItem(props) {
    console.log(props);
    return (
        <div className="item">
                <input type="checkbox" checked={props.item.completed}></input>
                <span>{props.item.text}</span>            
        </div>
    )
}

export default TodoItem