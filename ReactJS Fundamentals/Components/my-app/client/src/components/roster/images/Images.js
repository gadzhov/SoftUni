import React, { Component } from 'react';
import Image from './Image';

export default class Images extends Component{
    render(){
        return(
            <div className='roster-images-box'>
                {this.props.data.map((data, i) => {
                    return <Image element={data} changeCurrent={this.props.changeCurrent} key={i} />
                })}
                <div className='clearfix'></div>
            </div>
        )
    }
}