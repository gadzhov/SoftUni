import React, { Component } from 'react';
import Images from './images/Images';
import Details from './details/Details';

export default class Roster extends Component{
    constructor(props){
        super(props);

        this.state = {
            data: [],
            currentSelected: {}
        }
    }

    fetchRoster = () => {
        fetch('http://localhost:9999/roster/')
            .then(data => {
                return data.json()
            })
            .then(parseData => {
                if (parseData.length !== 0)
                    this.setState({data: parseData, currentSelected: parseData[0]});
            })
    }

    fetchCharacter = id => {
        fetch('http://localhost:9999/character/' + id)
        .then(data => {
            return data.json();
        })
        .then(parseData => {
            this.setState({currentSelected: parseData});
        })
    }

    componentDidMount = () => {
        this.fetchRoster();
    }

    changeCurrentSelected = id => {
        this.fetchCharacter(id);
    }

    render(){
        return (
            <div className='roster'>
                <Images data={this.state.data} changeCurrent={this.changeCurrentSelected} />
                <Details selected={this.state.currentSelected} />
            </div>
        )
    }
}