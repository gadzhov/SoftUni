import React, { Component } from 'react';
import './App.css';
import SignUp from './Components/SignUp';
import Login from './Components/Login';
import Pokemon from './Components/Pokemon';

class App extends Component {
  constructor(props){
    super(props);

    let user = JSON.parse(localStorage.getItem('user'))
    if(!user){
      user = {
        name: '',
        token: '',
        isAuth: false
      }
    }

    this.state = {
      user: user,
      showSignUp: false,
      showLogin: true
    }
  }

  signUpClicked = (event) => {
    event.preventDefault()
    this.resetState()
    this.setState({showSignUp: true})
  }

  loginClicked = (event) => {
    event.preventDefault()
    this.resetState()
    this.setState({showLogin: true})
  }

  resetState = () => {
    this.setState({
      showLogin: false,
      showSignUp: false
    })
  }

  login = (user) => {
    localStorage.setItem('user', JSON.stringify(user));
    this.resetState()
    this.setState({user})
  }

  signUp = () => {
    this.resetState()
    this.setState({showLogin: true})
  }

  render() {
    return (
      <div className="App">
        <header>
          {!this.state.user.isAuth ? <div><button onClick={this.signUpClicked}>SignUp</button>
          <button onClick={this.loginClicked}>Login</button></div> : null}
        </header>
        {this.state.showSignUp && !this.state.user.isAuth ? <SignUp signup={this.signUp} /> : null}
        {this.state.showLogin && !this.state.user.isAuth ? <Login login={this.login} /> : null}
        {this.state.user.isAuth ? <Pokemon /> : null}
      </div>
    );
  }
}

export default App;
