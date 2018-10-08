import React, { Component } from 'react';
import './App.css';
import rerender from '.';

let hours = 0;
let minutes = 0;
let seconds = 0;
let d = new Date();

const setHours = () => hours = d.getHours();
const setMinutes = () => minutes = d.getMinutes();
const setSeconds = () => seconds = d.getSeconds();
const setTime = () => {
  setHours();
  setMinutes();
  setSeconds();
};

setTime();

setInterval(() => {
  d = new Date();
  setTime();
  rerender();
}, 1000);

class App extends Component {
  render() {
    return (
      <div className="App">
        <div className="timer">
          <span className="hours">{hours}h:</span>
          <span className="minutes">{minutes}m:</span>
          <span className="seconds">{seconds}s</span>
        </div>
      </div>
    );
  }
}

export default App;
