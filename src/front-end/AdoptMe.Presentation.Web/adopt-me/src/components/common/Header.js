import React, {PropTypes} from 'react';
import {Link,IndexLink} from 'react-router';
import LogIn from '../security/LoginView';

const Header = () => {
    return (
        /*<div className="uk-position-top">*/
            <nav className="uk-navbar-container uk-dark" uk-navbar>
                <div className="uk-navbar-center">
                    <div className="uk-navbar-left">
                        <a className="uk-navbar-toggle" uk-navbar-toggle-icon href=""></a>
                        <div>
                            <ul className="uk-navbar-nav">
                                <li><IndexLink to="/" activeClassName="active">Home</IndexLink></li>
                                <li><Link to="/about" activeClassName="active">About</Link></li>
                            </ul>
                        </div>
                    </div>
                    <IndexLink to="/" className="uk-navbar-item uk-navbar-center uk-logo">Adopt Me</IndexLink>
                    <div className="uk-navbar-right">
                        <div>
                            <LogIn/>
                        </div>
                    </div>
                </div>
            </nav>
        /*</div>*/
    );
};

export default Header;