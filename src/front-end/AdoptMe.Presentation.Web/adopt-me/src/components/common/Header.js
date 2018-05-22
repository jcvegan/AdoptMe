import React, {PropTypes} from 'react';
import {Link,IndexLink} from 'react-router';
import UIKit from '../../../node_modules/uikit/dist/js/uikit';
import UIKitIcons from '../../../node_modules/uikit/dist/js/uikit-icons';
import LogIn from '../security/LoginView';
import FontAwesomeIcon from '@fortawesome/react-fontawesome';
import { faCoffee,faPaw } from '@fortawesome/fontawesome-free-solid';

const Header = () => {
    return (
            <nav className="uk-navbar-container uk-active" data-uk-navbar data-uk-sticky>
                <div className="uk-navbar-center">
                    <div className="uk-navbar-center-left">
                        <ul className="uk-navbar-nav uk-visible@m">
                            <li><Link to="/nosotros" activeClassName="active">Nosotros</Link></li>
                            <li><Link to="/buscador" activeClassName="active">Buscador</Link></li>
                        </ul>
                    </div>
                    <IndexLink to="/" className="uk-navbar-item uk-logo"><FontAwesomeIcon size="2x" icon={faPaw} /> Adoptame</IndexLink>
                    <div className="uk-navbar-center-right uk-visible@m">
                        <LogIn inNav/>
                    </div>
                </div>
            </nav>
    );
};

export default Header;