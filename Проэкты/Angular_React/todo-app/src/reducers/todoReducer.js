import { NEWTODO } from "../actions/todoActions";

export const todoReducer = (state, action) => {
    switch (action.type) {
        case NEWTODO:
            console.log(action.text)
            return { todoList: state.TodoList.push(action.text) }
        }
    return state
}
