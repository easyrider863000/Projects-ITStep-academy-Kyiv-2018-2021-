import InterestingCounter from "../components/InterestingCounter";
import { connect } from 'react-redux'




function mapStateToProps(state) {
    return {
        value: Math.pow(state.count, 2)
    }
}

const ICApp = connect(mapStateToProps)(InterestingCounter)



export default ICApp