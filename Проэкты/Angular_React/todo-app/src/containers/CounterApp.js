import Counter from "../components/Counter";
import { connect } from 'react-redux'
import { increment, decrement } from "../actions/counterActionCreators";

function mapStateToProps(state) {
    return {
        count: state.count
    }
}

function mapDispatchToProps(dispatch) {
    return {
        add: () => dispatch(increment()),
        substract: () => dispatch(decrement())
    }
}



const CounterApp = connect(mapStateToProps, mapDispatchToProps)(Counter)

export default CounterApp