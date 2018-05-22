import 'babel-polyfill';
import React from 'react';
import { render } from 'react-dom';
import configureStore from './store/configureStore';
import {Provider} from 'react-redux';
import { Router, browserHistory } from 'react-router';
import routes from './routes';
import {loadPetTypes}from './actions/petTypesActions';

import '../node_modules/uikit/dist/css/uikit.min.css';
import './styles/adoptme-theme.css';
import UIkit from '../node_modules/uikit/dist/js/uikit';
import Icons from '../node_modules/uikit/dist/js/uikit-icons';

const store = configureStore();
store.dispatch(loadPetTypes());

render(
    <Provider store={store}>
        <Router history={browserHistory} routes={routes} />
    </Provider>,
    //document.getElementById('app')
    document.getElementsByTagName("body")[0]
);