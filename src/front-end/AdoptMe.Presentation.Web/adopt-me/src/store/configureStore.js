import {createStore,applyMiddleware} from 'redux';
import rootReducer from '../reducers';
import reduxImmutableStateInvariant from 'redux-immutable-state-invariant';
import thunks from 'redux-thunk';
import { createLogger } from 'redux-logger';
export default function configureStore(initialState){
    return createStore(
        rootReducer,
        initialState,
        applyMiddleware(thunks,reduxImmutableStateInvariant(),createLogger())
    );
}