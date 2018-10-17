import React, { Component } from 'react';
import { Col, Form, FormGroup, ControlLabel, FormControl, Button } from 'react-bootstrap';

export default class Login extends Component{
    constructor(props){
        super(props)

        this.state = {
            email: '',
            password: '',
            validationErrorMsg: ''
        }
    }

    fieldChanged = (event) => {
        event.preventDefault()
        let currentState = this.state
        currentState[event.target.name] = event.target.value
        this.setState({ currentState })
    }

    loginSubmited = (event) => {
        event.preventDefault()
        let formData = {
            email: this.state.email,
            password: this.state.password
        };
        this.fetchLogin(formData)
    }

    fetchLogin = (formData) => {
        fetch('http://localhost:5000/auth/login', {
            method:'POST',
            body: JSON.stringify(formData),
            headers: {
                'Content-Type': 'application/json'
            }
        })
        .then(response => response.json())
        .then(response => {
            if(response.success){
                let user = {
                    name: response.user.name,
                    token: response.token,
                    isAuth: true
                }
                this.setState({validationErrorMsg: ''})
                this.props.login(user)
            } else {
                this.setState({validationErrorMsg: 'Wrong email/password.'})
            }
        })
        .catch(error => console.log('Error: ' + error))
    }

    render(){
        return(
            <div>
                <Col smOffset={4} sm={4}>
                    <h2>Login</h2>
                    <Form horizontal onSubmit={this.loginSubmited}>
                        <FormGroup controlId="formHorizontalEmail">
                            <ControlLabel>
                                Email
                            </ControlLabel>
                            <FormControl 
                                type="email" 
                                placeholder="Email" 
                                name='email' 
                                value={this.state.email}
                                onChange={this.fieldChanged}/>
                        </FormGroup>

                        <FormGroup controlId="formHorizontalPassword">
                            <ControlLabel>
                                Password
                            </ControlLabel>
                            <FormControl 
                                type="password" 
                                placeholder="Password" 
                                name='password' 
                                value={this.state.password}
                                onChange={this.fieldChanged}/>
                        </FormGroup>

                        <FormGroup>
                            <Col smOffset={1} sm={10}>
                            <Button type="submit">Login</Button>
                            </Col>
                        </FormGroup>
                        <span className='pull-left text-danger'>{this.state.validationErrorMsg}</span>
                    </Form>
                </Col>
            </div>
        )
    }
}