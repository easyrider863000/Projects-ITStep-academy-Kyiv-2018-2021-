import React from 'react'
import {todosData} from '../todosData.js';
import './Main.css'
import TodoItem from './TodoItem.js'

class Main extends React.Component{
    constructor(props){
        super(props)
        this.state={
            obj:todosData
        }
    }
    render(){
        return (
        <div className="main">    
            {this.state.obj.map(item => <TodoItem key={item.id} item={item}/>)
            }
        </div>
    )
}}

export default Main;
