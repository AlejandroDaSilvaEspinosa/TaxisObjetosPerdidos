import React, { Component } from 'react';
import { FormErrors } from './validationForm';
import { ObjectsTable } from './ObjectsTable';

export class Home extends Component {

    constructor(props) {
        super(props);
        this.state = {
            name: '',
            formErrors: '',
            nameValid: false,
            formValid: false,
            listObjects: [{}]
        }
    }
    handleUserInput(e) {
        const value = e.target.value;
        this.setState({ name: value },
            () => { this.validateField(value) });
    }

    validateField(value) {
        let fieldValidationErrors = this.state.formErrors;
        let nameValid = this.state.nameValid;
        nameValid = value.match(/^[a-zA-Z0-9 \u00C0-\u017F]*$/) && value.length >= 4;
        fieldValidationErrors = nameValid ? '' : 'Solo se permite caracteres alfanumericos y el minimo de caracteres es 4';
        this.setState({
            formErrors: fieldValidationErrors,
            nameValid: nameValid
        }, this.validateForm);
    }

    validateForm() {
        this.setState({ formValid: this.state.nameValid });
    }
    Submit(e, nameObject) {
        e.preventDefault();
        fetch('Home/GetObjects', {
            method: 'POST', 
            body: JSON.stringify(nameObject), 
            headers: {
                'Content-Type': 'application/json'
            }
        })
            .then(res => res.json())
            .then((data) => {
                this.setState({ listObjects: data })
            })
            .catch(console.log)
    }
    render() {
        return (

            < div >
                <h2>Buscar Objeto Perdido</h2>
                <div className={"form-group"} >
                   <label htmlFor="name">Tipo de objeto</label>
                    <input type="text" className=" form-control"
                        name="name" value={this.state.name} onChange={(event) => this.handleUserInput(event)} />
                </div>
                <div className=" panel panel-default">
                    <FormErrors formErrors={this.state.formErrors} />
                </div>
                <button className=" btn btn-primary" disabled={!this.state.formValid} onClick={(event) => this.Submit(event,this.state.name)}>
                    Buscar
                </button>
                <div>
                    <ObjectsTable objectsTable={this.state.listObjects} />
                </div>
            </div>
        );
    }
}
