import React, { Component } from 'react';
import { Col, Form, FormGroup, ControlLabel, Button, FormControl } from 'react-bootstrap';
export default class Pokemon extends Component{
    constructor(props){
        super(props)

        this.state = {
            pokemons: [],
            name: '',
            image: '',
            info: '',
            validationErrorsMsg: {
                name: '',
                image: '',
                info: '',
            }
        }
    }

    componentDidMount = () => {
        this.fetchPokedex();
    }

    fieldChanged = (event) => {
        event.preventDefault()
        let currentState = this.state
        currentState[event.target.name] = event.target.value
        this.setState({ currentState })
        this.fieldValidation();
    }

    pokemonFormSubmited = (event) => {
        event.preventDefault()

        if(this.fieldValidation()){
            let formData = {
                pokemonName: this.state.name,
                pokemonImage: this.state.image,
                pokemonInfo: this.state.info
            }
            this.fetchCreatePokemon(formData);
        }
        
    }

    fieldValidation = () => {
        let currentErrors = this.state.validationErrorsMsg;

        this.state.name ? currentErrors.name = '' : currentErrors.name = 'Pokemon name is required.'
        this.state.image ? currentErrors.image = '' : currentErrors.image = 'Pokemon image url is required.'
        this.state.info ? currentErrors.info = '' : currentErrors.info = 'Pokemon info is required.'

        this.setState({validationErrorsMsg: currentErrors})

        const errorValues = Object.values(currentErrors);
        return errorValues.every(v => v === ''); // validation successfull
    }

    fetchCreatePokemon = (formData) => {
        fetch('http://localhost:5000/pokedex/create', {
            method: 'POST',
            body: JSON.stringify(formData),
            headers: {
                'Content-Type': 'application/json'
            }
        })
        .then(response => response.json())
        .then(response => this.fetchPokedex())
        .catch(error => console.log('Error: ' + error))
    }

    fetchPokedex = () => {
        fetch('http://localhost:5000/pokedex/pokedex/')
        .then(response => response.json())
        .then(response => this.setState({ pokemons: response.pokemonColection }))
        .catch(error => console.log('Error: ' + error))
    }

    render(){
        return(
            <div>
                <Col smOffset={4} sm={4}>
                    <h2>Pokemon</h2>
                    <Form horizontal onSubmit={this.pokemonFormSubmited}>
                        <FormGroup controlId="formHorizontalName">
                            <ControlLabel>
                                Pokemon Name
                            </ControlLabel>
                            <FormControl 
                                type="text" 
                                placeholder="Pokemon Name" 
                                name='name' 
                                value={this.state.name}
                                onChange={this.fieldChanged}/>
                                <span className='pull-left text-danger'>{this.state.validationErrorsMsg.name}</span>
                        </FormGroup>

                        <FormGroup controlId="formHorizontalPassword">
                            <ControlLabel>
                                Pokemon Image
                            </ControlLabel>
                            <FormControl 
                                type="url" 
                                placeholder="Pokemon image" 
                                name='image' 
                                value={this.state.image}
                                onChange={this.fieldChanged}/>
                                <span className='pull-left text-danger'>{this.state.validationErrorsMsg.image}</span>
                        </FormGroup>

                        <FormGroup controlId="formHorizontalPassword">
                            <ControlLabel>
                                Pokemon Info
                            </ControlLabel>
                            <FormControl 
                                type="text" 
                                placeholder="Pokemon Info" 
                                name='info' 
                                value={this.state.info}
                                onChange={this.fieldChanged}/>
                                <span className='pull-left text-danger'>{this.state.validationErrorsMsg.info}</span>
                        </FormGroup>

                        <FormGroup>
                            <Col smOffset={1} sm={10}>
                            <Button type="submit">Create a pokemon</Button>
                            </Col>
                        </FormGroup>
                    </Form>
                </Col>
                <Col sm={12}>
                    {this.state.pokemons.map((pokemon, i) => 
                    <Col key={i}>
                        <h4>{pokemon.pokemonName}</h4>
                        <span>{pokemon.pokemonInfo}</span>
                        <img className='img-responsive' src={pokemon.pokemonImage} alt={pokemon.pokemonName} />
                    </Col>)}
                </Col>
            </div>
        )
    }
} 