import React, { Component } from 'react';
import './App.css';
// import Header from  './Header';
// import Footer from './Footer';
// import Person from './Person'
// import Counter from './Counter'
// import List from './List'
import List2 from './List2'

class App extends Component {
  render() {
      return (
      <div className="App">
        <List2 items={["Sofia", "Varna", "Kostenets"]}/>
      </div>
    );
  }
}

export default App;
