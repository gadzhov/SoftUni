import React, { Component } from 'react'

export default class Button extends Component {
    render(){
        return(
            <img alt='nope' 
                src={this.props.src}
                className={this.props.className}
                onClick={() => this.props.changeEpisode(this.props.selectedId)}/>
        )
    }
}