import {combineReducers} from 'redux';
import account from './accountReducer';
import petTypes from './petTypeReducers';
const rootReducer = combineReducers({
    account: account,
    petTypes: petTypes
});

export default rootReducer;