import React, { Component } from 'react';
import './App.css';
import rerender from '.';

let counter = 0;

const increase = () => {
  counter++;
  rerender();
}

const decrease = () => {
  counter--;
  rerender();
}

class App extends Component {
  render() {
    return (
      <div className="App">
        <div className="counter">{counter}</div>
        <button onClick={increase}>Increase</button>
        <button onClick={decrease}>Decrease</button>
      </div>
    );
  }
}

export default App;
