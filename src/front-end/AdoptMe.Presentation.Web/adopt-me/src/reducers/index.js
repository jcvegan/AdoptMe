import {combineReducers} from 'redux';
import accounts from './accountReducer';

const rootReducer = combineReducers({
    accounts: accounts
});

export default rootReducer;