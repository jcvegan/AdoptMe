import React, {PropTypes} from 'react';

class LogIn extends React.Component{
    constructor(props,context){
        super(props,context);
    }

    render(){
        if(this.props.inNav == true){
            return (
                <div className="uk-navbar-item">
                    <form>
                        <input className="uk-input uk-form-width-small" type="text" placeholder="Usuario" />
                        <input className="uk-input uk-form-width-small" type="password" placeholder="Contraseña" />
                        <button className="uk-button uk-button-primary" type="button">Ingresar</button>
                    </form>
                </div>
            );
        }
        else{
            return (
                <div></div>
            )
        }
    }
}
export default LogIn;