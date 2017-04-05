import React, { Component } from 'react';
import './App.css';
import './Header.css';

class Header extends Component {
    render() {
        return (
            <div className="header">
                <a href="#">Home</a>
                <a href="#">Login</a>
                <a href="#">Register</a>
            </div>
        )
    }
}
export default Header;