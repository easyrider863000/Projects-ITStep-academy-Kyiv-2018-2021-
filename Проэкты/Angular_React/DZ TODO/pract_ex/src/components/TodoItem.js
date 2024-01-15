import React from 'react'
import './TodoItem.css'

class TodoItem extends React.Component{
    constructor(props){
        super(props)
        this.state={
            text:props.item.text,
            completed:props.item.completed,
            id:props.item.id
        }
    }

    toggleChange = () => {
        this.setState({
          completed: !this.state.completed
        });
    }

    render() {
        return (
            <div className="item">
                <input type="checkbox" checked={this.state.completed} onChange={this.toggleChange}></input>
                <span>{this.state.text}</span>            
            </div>
        )
    }
}

export default TodoItem 