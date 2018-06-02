import React, {PropTypes} from 'react';
import {connect} from 'react-redux';
import uikit from '../../../node_modules/uikit/dist/js/uikit';
import * as accountActions from '../../actions/accountActions';

class NewAccountPage extends React.Component {
    constructor(props,context){
        super(props,context);
        this.state = {
            account : {
                userName:"",
                eMail:"",
                firstName : "",
                lastName:"",
                password:"",
                passwordConfirmation:""
            }
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
        const account = this.state.account;
        account.userName = event.target.value;
        this.setState({account: account});
    }
    onEmailChange(event){
        const account = this.state.account;
        account.eMail = event.target.value;
        this.setState({account: account});
    }

    onFirstNameChange(event){
        const account = this.state.account;
        account.firstName = event.target.value;
        this.setState({account: account});
    }
    onLastNameChange(event){
        const account = this.state.account;
        account.lastName = event.target.value;
        this.setState({account: account});
    }
    onPasswordChange(event){
        const account = this.state.account;
        account.password = event.target.value;
        this.setState({account: account});
    }
    onPasswordConfirmationChange(event){
        const account = this.state.account;
        account.passwordConfirmation = event.target.value;
        this.setState({account: account});
    }
    onClickSave(){
        //alert(this.state.eMail);
        //this.props.dispatch(accountActions.createAccount(this.state));
        //console.log(this.props);
        this.props.createAccount(this.state.account);
    }

    render(){
        return (
            <div className="uk-container-large">
                <div className="uk-backgroun-norepeat uk-background-cover uk-background-center-center uk-flex uk-flex-middle" uk-height-viewport="offset-top:true" style={{background:'../img/animal-be-free.jpg'}}></div>
                <form className="uk-grid-small uk-width-1-2@s" data-uk-grid>
                    <fieldset className="uk-fieldset uk-width-1-1">
                        <legend>
                            <h2>Únete a nuestra red</h2>
                        </legend>
                    </fieldset>
                    <div className="uk-width-1-2@s uk-inline">
                        <div className="uk-inline uk-width-1-1">
                            <input className="uk-input" type="text" placeholder="Nombres" value={this.state.account.firstName} onChange={this.onFirstNameChange}></input>
                        </div>
                    </div>
                    <div className="uk-width-1-2@s uk-inline">
                        <div className="uk-inline uk-width-1-1">
                            <input className="uk-input" type="text" placeholder="Apellidos" value={this.state.account.lastName} onChange={this.onLastNameChange}></input>
                        </div>
                    </div>
                    <div className="uk-width-1-1 uk-margin-bottom">
                        <div className="uk-inline uk-width-1-1">
                            <input className="uk-input" type="text" placeholder="Usuario" value={this.state.account.userName} onChange={this.onUsernameChange}></input>
                        </div>
                    </div>
                    <div className="uk-width-1-1 uk-margin-bottom">
                        <div className="uk-inline uk-width-1-1">
                            <input className="uk-input" type="text" placeholder="Correo Electrónico" value={this.state.account.eMail} onChange={this.onEmailChange}></input>
                        </div>
                    </div>
                    <div className="uk-width-1-2@s uk-inline">
                        <div className="uk-inline uk-width-1-1">
                            <input className="uk-input" type="password" placeholder="Contraseña" value={this.state.account.password} onChange={this.onPasswordChange}></input>
                        </div>
                    </div>
                    <div className="uk-width-1-2@s uk-inline">
                        <div className="uk-inline uk-width-1-1">
                            <input className="uk-input" type="password" placeholder="Confirmación Contraseña" value={this.state.account.passwordConfirmation} onChange={this.onPasswordConfirmationChange}></input>
                        </div>
                    </div>
                    <div className="uk-width-1-1">
                        <button type="button" className="uk-button uk-button-primary" onClick={this.onClickSave}>Registrame</button>
                    </div>
                </form>
            </div>
        );
    }
}

NewAccountPage.propTypes = {
    //dispatch:PropTypes.func.isRequired,
    createAccount:PropTypes.func.isRequired
};
function mapStateToProps(state,ownProps){
    return {
        accounts:state.accounts
    };
}
function mapDispatchToProps(dispatch){
    return {
        createAccount : account => { 
            console.log(account);
            uikit.notification("Creando cuenta...",{status:"primary"});
            dispatch(accountActions.createAccount(account));
        }
    };
}
export default connect(mapStateToProps,mapDispatchToProps)(NewAccountPage);