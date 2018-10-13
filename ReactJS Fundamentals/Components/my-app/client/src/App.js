import React, { Component } from 'react';
import './App.css';
import Slider from './components/slider/Slider';
import Roster from './components/roster/Roster';

export default class App extends Component {
  render() {
    return (
      <div className="App">
        <Slider />
        <Roster />
      </div>
    );
  }
}