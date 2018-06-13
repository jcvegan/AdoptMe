import * as types from '../actions/actionTypes';

export default function petTypesReducer(state = [],action){
    switch(action.type){
        case types.LOAD_PETTYPES_SUCCESS:
            return Object.assign({},{isFetching:action.isFetching,petTypes:action.petTypes});
        case types.LOAD_PETTYPES_FAIL:
        return Object.assign({},{isFetching:action.isFetching,petTypes:action.petTypes,error:action.error});
        default:
            return state;
    }
}