import { INCREMENT, DECREMENT } from "../actions/counterActions";

export const counterReducer = (state, action) => {
    switch (action.type) {
        case INCREMENT:
            return { count: state.count + 1 }
        case DECREMENT:
            return { count: state.count - 1 }
    }
    return state
}
