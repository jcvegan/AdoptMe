import React, {PropTypes} from 'react';
import {Link,IndexLink} from 'react-router';
import LogIn from '../security/LoginView';

const Header = () => {
    return (
        <div className="uk-section-secondary">
            <nav className="uk-navbar-container uk-navbar-transparent" uk-navbar>
                <div className="uk-navbar-center">
                    <div className="uk-navbar-left">
                        <ul className="uk-navbar-nav">
                            <li><Link to="/nosotros" activeClassName="active">Nosotros</Link></li>
                        </ul>
                    </div>
                    <div className="uk-navbar-center">
                        <IndexLink to="/" className="uk-navbar-center uk-navbar-item uk-logo">Adoptame</IndexLink>
                    </div>
                    <div className="uk-navbar-right">
                        <LogIn/>
                    </div>
                </div>
            </nav>
        </div>
    );
};

export default Header;