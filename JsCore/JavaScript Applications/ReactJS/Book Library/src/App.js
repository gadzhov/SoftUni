import React, { Component } from 'react';
import './App.css';
import NavigationBar from './Components/NavigationBar';
import Footer from './Components/Footer';
// import $ from 'jquery';

export default class App extends Component {
  constructor(props) {
    super(props);
        this.state = {
          username: sessionStorage.getItem("username"),
          userId: sessionStorage.getItem("userId")
        };
      }
  render() {
      return (
          <div className="App">
            <header>
              <NavigationBar username={this.state.username}/>
              <div id="loadingBox">Loading...</div>
              <div id="infoBox">Info msg</div>
              <div id="errorBox">Error msg</div>
            </header>
            <div id="main">
              <h1>Main</h1>
              <p>Main app view</p>
            </div>
            <Footer/>
          </div>
      );
  }
}
