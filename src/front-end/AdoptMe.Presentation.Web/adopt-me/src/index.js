import 'babel-polyfill';
import React from 'react';
import { render } from 'react-dom';
import { Router, browserHistory } from 'react-router';
import routes from './routes';
import '../node_modules/uikit/dist/css/uikit.min.css';
import './styles/adoptme-theme.css';
import UIkit from '../node_modules/uikit/dist/js/uikit';
import Icons from '../node_modules/uikit/dist/js/uikit-icons';
render(
    <Router history={browserHistory} routes={routes} />,
    document.getElementById('app')
);