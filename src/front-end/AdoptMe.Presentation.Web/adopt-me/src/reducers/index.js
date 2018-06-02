import {combineReducers} from 'redux';
import accounts from './accountReducer';
import petTypes from './petTypeReducers';
const rootReducer = combineReducers({
    accounts: accounts,
    petTypes: petTypes
});

export default rootReducer;