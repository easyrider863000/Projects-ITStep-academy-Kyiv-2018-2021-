import React, { Component } from "react"

class App extends Component {
  constructor() {
    super()
    this.state = { fName: '', sName: '', age: '', gender: '', destination: '', dietaryRestrictions: 
    { 
      Vegan: false,
      Ovo_Vegetarian: false,
      Lacto_Vegetarian: false,
      Lacto_Ovo_Vegetarians: false,
      Pescetarians: false
    } }
    this.handleChangeName = this.handleChangeName.bind(this);
    this.handleChangeSurName = this.handleChangeSurName.bind(this);
    this.handleChangeAge = this.handleChangeAge.bind(this);
    this.handleChangeGender = this.handleChangeGender.bind(this);
    this.handleChangeDestination = this.handleChangeDestination.bind(this);
    this.handleChangeDietaryRestrictions = this.handleChangeDietaryRestrictions.bind(this);
  }
  handleChangeName(event) {
    this.setState({ fName: event.target.value });
  }
  handleChangeSurName(event) {
    this.setState({ sName: event.target.value });
  }
  handleChangeAge(event) {
    this.setState({ age: event.target.value });
  }
  handleChangeGender(event) {
    this.setState({ gender: event.target.value });
  }
  handleChangeDestination(event) {
    this.setState({ destination: event.target.value });
  }
  handleChangeDietaryRestrictions(event) {
    let state2 = this.state.dietaryRestrictions;
    state2[event.target.name]=event.target.checked;
    this.setState({dietaryRestrictions: state2});
  }

  render() {
    return (
      <main>
        <form>
          <input type="text" placeholder="First Name" value={this.state.fName} onChange={this.handleChangeName} /><br />
          <input type="text" placeholder="Last Name" value={this.state.sName} onChange={this.handleChangeSurName} /><br />
          <input type="number" placeholder="Age" value={this.state.age} onChange={this.handleChangeAge} /><br />
          <div className="radio">
            <label>
              <input type="radio" value="Male" onChange={this.handleChangeGender} checked={this.state.gender === 'Male'} />
              Male
            </label>
          </div>
          <div className="radio">
            <label>
              <input type="radio" value="Female" onChange={this.handleChangeGender} checked={this.state.gender === 'Female'} />
              Female
            </label>
          </div>
          <select value={this.state.destination} onChange={this.handleChangeDestination}>
            <option value="Kyiv">Kyiv</option>
            <option value="Moscow">Moscow</option>
            <option value="London">London</option>
            <option value="NewYork">New York</option>
            <option value="Pekin">Pekin</option>
          </select>
          <br />
          <label>
            <input
              type="checkbox"
              name="Vegan"
              checked={this.state.dietaryRestrictions.Vegan}
              onChange={this.handleChangeDietaryRestrictions}
            />
            Vegan
          </label>
          <br />
          <label>
            <input
              type="checkbox"
              name="Ovo_Vegetarian"
              checked={this.state.dietaryRestrictions.Ovo_Vegetarian}
              onChange={this.handleChangeDietaryRestrictions}
            />
            Ovo-Vegetarian
          </label>
          <br />
          <label>
            <input
              type="checkbox"
              name="Lacto_Vegetarian"
              checked={this.state.dietaryRestrictions.Lacto_Vegetarian}
              onChange={this.handleChangeDietaryRestrictions}
            />
            Lacto-Vegetarian
          </label>
          <br />
          <label>
            <input
              type="checkbox"
              name="Lacto_Ovo_Vegetarians"
              checked={this.state.dietaryRestrictions.Lacto_Ovo_Vegetarian}
              onChange={this.handleChangeDietaryRestrictions}
            />
            Lacto-Ovo-Vegetarian
          </label>
          <br />
          <label>
            <input
              type="checkbox"
              name="Pescetarians"
              checked={this.state.dietaryRestrictions.Pescetarians}
              onChange={this.handleChangeDietaryRestrictions}
            />
            Pescetarians
          </label>
          <br />

          <button>Submit</button>
        </form>
        <hr />
        <h2><font color="#3AC1EF">Entered information:</font></h2>
        <p>Your name: {this.state.fName} {this.state.sName}</p>
        <p>Your age: {this.state.age}</p>
        <p>Your gender: {this.state.gender}</p>
        <p>Your destination: {this.state.destination}</p>
        <p style ={{margin:"10px 50px", fontSize:"12px", color:"grey"}}>
          {
        Object.keys(this.state.dietaryRestrictions).map((key, index) => ( 
          this.state.dietaryRestrictions[key]?
            <p key={index}> {key} {this.state.dietaryRestrictions[key]}</p> 
          :<span></span>
        ))
      }
        </p>
      </main>
    )
  }
}
export default App