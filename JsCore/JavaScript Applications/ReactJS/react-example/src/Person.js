import React, { Component } from 'react';

class Person extends React.Component {
    render() {
        return (
            <div>
                <h1>{this.props.person}</h1>
                <h1>{this.props.phone}</h1>
            </div>
        )
    }
}
export default Person;