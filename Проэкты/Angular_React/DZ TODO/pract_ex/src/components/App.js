import React from 'react'
import Header from './Header.js'
import Main from './Main.js'
import Footer from './Footer.js'
import './App.css'


class App extends React.Component{
  constructor(props){
    super(props)
  }
  
  render(){
    return (
      <div className="back">
          <Header />    
          <Main />
          <Footer />
        </div>
    )}
}
    
export default App;
