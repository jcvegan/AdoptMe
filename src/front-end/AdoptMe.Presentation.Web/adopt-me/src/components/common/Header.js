import React, {PropTypes} from 'react';
import {Link,IndexLink} from 'react-router';
import UIKit from '../../../node_modules/uikit/dist/js/uikit';
import UIKitIcons from '../../../node_modules/uikit/dist/js/uikit-icons';
import LogIn from '../security/LoginView';

const Header = () => {
    return (
            <nav className="uk-navbar-container uk-active uk-navbar-primary" data-uk-navbar data-uk-sticky>
                <div className="uk-navbar-center">
                    <div className="uk-navbar-center-left">
                        <ul className="uk-navbar-nav">
                            <li><Link to="/nosotros" activeClassName="active">Nosotros</Link></li>
                            <li><Link to="/buscador" activeClassName="active">Buscador</Link></li>
                        </ul>
                    </div>
                    <IndexLink to="/" className="uk-navbar-item uk-logo">ADOPTAME</IndexLink>
                    <div className="uk-navbar-center-right">
                        <LogIn/>
                    </div>
                </div>
            </nav>
    );
};

export default Header;