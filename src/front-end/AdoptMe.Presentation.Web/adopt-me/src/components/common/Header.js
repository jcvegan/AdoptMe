import React, {PropTypes} from 'react';
import {Link,IndexLink} from 'react-router';
import LogIn from '../security/LoginView';

const Header = () => {
    return (
        <div className="uk-position-top">
            <nav className="uk-navbar-container uk-navbar-transparent uk-margin" uk-navbar>
                <div className="uk-navbar-left">
                    <ul className="uk-navbar-nav">
                        <li><IndexLink to="/" activeClassName="active">Home</IndexLink></li>
                        <li><Link to="/about" activeClassName="active">About</Link></li>
                    </ul>
                </div>
                <div className="uk-navbar-center">
                    <IndexLink to="/" className="uk-navbar-item uk-logo">Adopt Me</IndexLink>
                </div>
                <div className="uk-navbar-right">
                    <LogIn/>
                </div>
            </nav>
        </div>
    );
};

export default Header;