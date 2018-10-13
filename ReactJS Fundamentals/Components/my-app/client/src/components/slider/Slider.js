import React, { Component } from 'react';
import Button from '../slider/Button';

export default class Slider extends Component{
    constructor(props){
        super(props);

        this.state = {
            url: null,
            id: null
        };
    }

    fetchEpisode = id => {
        fetch('http://localhost:9999/episodePreview/' + id)
            .then(data => {
                return data.json()
            })
            .then(parseData => {
                this.setState(parseData);
            })
    }

    componentDidMount = () => {
        this.fetchEpisode(0);
    }

    changeEpisode = (episode) => {
        this.fetchEpisode(episode);
    }

    render(){
        return (
            <div>
                <div className='warper'>
                    <Button src='/left.png' 
                        className='slider-elem slider-button case-left' 
                        changeEpisode={this.changeEpisode}
                        selectedId={this.state.id - 1} />
                    <img 
                        className='sliderImg slider-elem'
                        alt='focusedEp' src={this.state.url}
                    />
                    <Button src='/right.png' 
                        className='slider-elem slider-button case-right'
                        changeEpisode={this.changeEpisode} 
                        selectedId={this.state.id + 1} />
                </div>
            </div>
        )
    }
}