import React from 'react'
import CounterApp from '../containers/CounterApp'
import ICApp from '../containers/ICApp'
import EntryTodo from '../containers/EntryTodo'
import Footer from './Footer'
import Header from './Header'

function App() {
    return (
        <>
            <Header />
            {/* <div className="d-flex justify-content-between">
                <CounterApp />
                <ICApp />
            </div> */}
            <FormTodo />

            <Footer />
        </>
    )
}

export default App;