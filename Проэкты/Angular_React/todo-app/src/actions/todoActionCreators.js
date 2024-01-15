import { NEWTODO } from "./todoActions";

export const newTodo = () => ({
    type: NEWTODO
})

export const updateTodo = (text) => ({
    type: NEWTODO,
    text: text
})