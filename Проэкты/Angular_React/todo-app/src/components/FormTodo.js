import React from 'react'

function FormTodo(props) {
    return (
        <div>
            <div className="d-flex align-items-center flex-column">
            
                <div>
                <div class="form-group">
                    <input type="text" key={props.textbox} class="form-control" value={props.textbox} onChange={()=>props.updateNewTodo(props.textbox)} placeholder="Enter new todo"/>
                </div>
                    <button
                        className="btn btn-danger m-2"
                        onClick={() => props.addNewTodo()}
                    >
                        Add
                            </button>
                </div>
            </div>
        </div>
    )
}


export default FormTodo