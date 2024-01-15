// import Counter from "../components/FormTodo";
import FormTodo from "../components/FormTodo";
import { connect } from 'react-redux'
import { increment, decrement } from "../actions/counterActionCreators";
import { newTodo, updateTodo } from "../actions/todoActionCreators";

function mapStateToProps(state) {
    return {
        todoList: state.todoList
    }
}

function mapDispatchToProps(dispatch) {
    return {
        addNewTodo: () => dispatch(newTodo()),
        updateNewTodo: (text) => dispatch(updateTodo(text)),
        // add: () => dispatch(increment()),
        // substract: () => dispatch(decrement())
    }
}



// const CounterApp = connect(mapStateToProps, mapDispatchToProps)(Counter)
const EntryTodo = connect(mapStateToProps, mapDispatchToProps)(FormTodo)

export default EntryTodo