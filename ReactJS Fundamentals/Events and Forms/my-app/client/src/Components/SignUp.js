import React, { Component } from 'react';
import { Form, FormGroup, Col, FormControl, ControlLabel, Checkbox, Button } from 'react-bootstrap';


export default class SignUp extends Component{
    constructor(props){
        super(props);

        this.state = {
            name: '',
            email: '',
            confirmEmail: '',
            password: '',
            confirmPassword: '',
            termsAccepted: false,
            validationErrorsMsg: {
                name: '',
                email: '',
                confirmEmail: '',
                password: '',
                confirmPassword: '',
                termsAccepted: ''
            }
        }
    }

    signUpSubmited = (event) => {
        event.preventDefault();
        
        if(this.fieldValidation()){
            let formData = {
                email: this.state.email,
                password: this.state.password,
                name: this.state.name
            }
            this.fetchSignUp(formData);
        }
    }

    fieldChanged = (event) => {
        let currentFormData = this.state;
        if (event.target.name === 'termsAccepted') {
            currentFormData.termsAccepted = !currentFormData.termsAccepted
        } else {
            currentFormData[event.target.name] = event.target.value;
            this.fieldValidation();
        }

        this.setState(currentFormData);
    }

    fieldValidation = () => {
        let currentErrors = this.state.validationErrorsMsg;

        this.state.name ? currentErrors.name = '' : currentErrors.name = 'User name is required.'
        this.state.email ? currentErrors.email = '' : currentErrors.email = 'Email is required.'
        this.state.confirmEmail && this.state.confirmEmail === this.state.email ? currentErrors.confirmEmail = '' : currentErrors.confirmEmail = 'Eemail and confirm email need to be the same.'
        this.state.password.length >= 8 ? currentErrors.password = '' : currentErrors.password = 'Password must be at least 8 characters long.'
        this.state.confirmPassword && this.state.confirmPassword === this.state.password ? currentErrors.confirmPassword = '' : currentErrors.confirmPassword = 'Password and confirm password need to be the same.'
        this.state.termsAccepted ? currentErrors.termsAccepted = '' : currentErrors.termsAccepted = 'You need to accept the terms.'

        this.setState({validationErrorsMsg: currentErrors})

        const errorValues = Object.values(currentErrors);
        return errorValues.every(v => v === ''); // validation successfull
    }

    fetchSignUp = (formData) => {
        fetch('http://localhost:5000/auth/signup', {
            method: 'POST', // or 'PUT'
            body: JSON.stringify(formData), // data can be `string` or {object}!
            headers:{
                'Content-Type': 'application/json'
            }
        })
        .then(response => response.json())
        .then(response => {
            if(response.success)
            console.log('Yes')
                this.props.signup()
        })
        .catch(error => console.error('Error:', error));
    } 

    render(){
        return(
            <div>
                <Col smOffset={4} sm={4}>
                    <h2>SignUp</h2>
                    <Form horizontal onSubmit={this.signUpSubmited}>
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
                            <span className='pull-left text-danger'>{this.state.validationErrorsMsg.email}</span>
                        </FormGroup>

                        <FormGroup controlId="formHorizontalConfirmEmail">
                            <ControlLabel>
                                Confirm Email
                            </ControlLabel>
                            <FormControl 
                                type="email" 
                                placeholder="Confirm Email"
                                name='confirmEmail'
                                value={this.state.confirmEmail}
                                onChange={this.fieldChanged} />
                            <span className='pull-left text-danger'>{this.state.validationErrorsMsg.confirmEmail}</span>
                        </FormGroup>

                        <FormGroup controlId="formHorizontalUserName">
                            <ControlLabel>
                                User Name
                            </ControlLabel>
                            <FormControl 
                                type="text" 
                                placeholder="User Name"
                                name='name'
                                value={this.state.name}
                                onChange={this.fieldChanged} />
                            <span className='pull-left text-danger'>{this.state.validationErrorsMsg.name}</span>
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
                                onChange={this.fieldChanged} />
                            <span className='pull-left text-danger'>{this.state.validationErrorsMsg.password}</span>
                        </FormGroup>

                        <FormGroup controlId="formHorizontalConfirmPassword">
                            <ControlLabel>
                                    Confirm Password
                            </ControlLabel>
                            <FormControl 
                                type="password" 
                                placeholder="Confirm Password"
                                name='confirmPassword'
                                value={this.state.confirmPassword}
                                onChange={this.fieldChanged} />
                            <span className='pull-left text-danger'>{this.state.validationErrorsMsg.confirmPassword}</span>
                        </FormGroup>

                        <FormGroup>
                            <Col smOffset={1} sm={10}>
                            <Checkbox 
                                value={this.state.termsAccepted} 
                                onChange={this.fieldChanged}
                                name='termsAccepted'>
                                I agree with the terms
                            </Checkbox>
                            <span className='pull-left text-danger'>{this.state.validationErrorsMsg.termsAccepted}</span>
                            </Col>
                        </FormGroup>

                        <FormGroup>
                            <Col smOffset={1} sm={10}>
                            <Button type="submit">Sign up</Button>
                            </Col>
                        </FormGroup>
                    </Form>
                </Col>
            </div>
        )
    }
}