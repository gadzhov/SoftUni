import React, { Component } from 'react';

export default class Image extends Component{
    render(){
        return(
            <div className='roster-image'>
                <img alt={this.props.element.name} 
                src={this.props.element.url} 
                onClick={() => this.props.changeCurrent(this.props.element.id)} />
            </div>
        )
    }
}