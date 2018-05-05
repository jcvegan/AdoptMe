import React, {PropTypes} from 'react';

class NewAccountPage extends React.Component {
    constructor(props,context){
        super(props,context);
        this.state = {
            userName:"",
            eMail:"",
            firstName : "",
            lastName:"",
            password:"",
            passwordConfirmation:""
        };
        this.isValid = false;
        this.onUsernameChange = this.onUsernameChange.bind(this);
        this.onFirstNameChange = this.onFirstNameChange.bind(this);
        this.onLastNameChange = this.onLastNameChange.bind(this);
        this.onEmailChange = this.onEmailChange.bind(this);
        this.onPasswordChange = this.onPasswordChange.bind(this);
        this.onPasswordConfirmationChange = this.onPasswordConfirmationChange.bind(this);
        this.onClickSave = this.onClickSave.bind(this);
    }

    onUsernameChange(event){
        const account = this.state;
        account.userName = event.target.value;
        this.setState({userName: account.userName});
    }
    onEmailChange(event){
        const account = this.state;
        account.eMail = event.target.value;
        this.setState({eMail: account.eMail});
    }

    onFirstNameChange(event){
        const account = this.state;
        account.firstName = event.target.value;
        this.setState({firstName: account.firstName});
    }
    onLastNameChange(event){
        const account = this.state;
        account.lastName = event.target.value;
        this.setState({lastName: account.lastName});
    }
    onPasswordChange(event){
        const account = this.state;
        account.password = event.target.value;
        this.setState({password: account.password});
    }
    onPasswordConfirmationChange(event){
        const account = this.state;
        account.passwordConfirmation = event.target.value;
        this.setState({passwordConfirmation: account.passwordConfirmation});
    }
    onClickSave(event){
        alert(this.state.eMail);
    }

    render(){
        return (
            <div className="uk-container-large">
                <div className="uk-backgroun-norepeat uk-background-cover uk-background-center-center uk-flex uk-flex-middle" uk-height-viewport="offset-top:true" style={{background:'../img/animal-be-free.jpg'}}></div>
                <form className="uk-grid-small uk-width-1-2@s" uk-grid>
                    <fieldset className="uk-fieldset uk-width-1-1">
                        <legend>
                            <h2>Únete a nuestra red</h2>
                        </legend>
                    </fieldset>
                    <div className="uk-width-1-2@s uk-inline uk-margin">
                        <div className="uk-inline uk-width-1-1">
                            <input className="uk-input" type="text" placeholder="Nombres" value={this.state.firstName} onChange={this.onFirstNameChange}></input>
                        </div>
                    </div>
                    <div className="uk-width-1-2@s uk-inline uk-margin">
                        <div className="uk-inline uk-width-1-1">
                            <input className="uk-input" type="text" placeholder="Apellidos" value={this.state.lastName} onChange={this.onLastNameChange}></input>
                        </div>
                    </div>
                    <div className="uk-width-1-1 uk-margin-bottom">
                        <div className="uk-inline uk-width-1-1">
                            <input className="uk-input" type="text" placeholder="Usuario" value={this.state.userName} onChange={this.onUsernameChange}></input>
                        </div>
                    </div>
                    <div className="uk-width-1-1 uk-margin-bottom">
                        <div className="uk-inline uk-width-1-1">
                            <input className="uk-input" type="text" placeholder="Correo Electrónico" value={this.state.eMail} onChange={this.onEmailChange}></input>
                        </div>
                    </div>
                    <div className="uk-width-1-2@s uk-inline uk-margin-bottom">
                        <div className="uk-inline uk-width-1-1">
                            <input className="uk-input" type="password" placeholder="Contraseña" value={this.state.password} onChange={this.onPasswordChange}></input>
                        </div>
                    </div>
                    <div className="uk-width-1-2@s uk-inline uk-margin-bottom">
                        <div className="uk-inline uk-width-1-1">
                            <input className="uk-input" type="password" placeholder="Confirmación Contraseña" value={this.state.passwordConfirmation} onChange={this.onPasswordConfirmationChange}></input>
                        </div>
                    </div>
                    <div className="uk-width-1-1 uk-margin-bottom">
                        <button type="button" className="uk-button uk-button-primary" onClick={this.onClickSave}>Registrame</button>
                    </div>
                </form>
            </div>
        );
    }
}

export default NewAccountPage;