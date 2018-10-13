import React, { Component } from 'react'

export default class Details extends Component {
    render(){
        return(
            <div className='roster-details-box'>
                <span><img alt={this.props.selected.name} src={this.props.selected.url} /></span>
                <span>{this.props.selected.bio}</span>
            </div>
        )
    }
}