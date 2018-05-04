import React, {PropTypes} from 'react';

const LogIn = () => {
    return (
        <div className="uk-navbar-item">
            <form>
                <input className="uk-input uk-form-width-small" type="text" placeholder="Usuario" />
                <input className="uk-input uk-form-width-small" type="password" placeholder="Contraseña" />
                <button className="uk-button uk-button-primary" type="button">Ingresar</button>
            </form>
        </div>
    );
};
export default LogIn;