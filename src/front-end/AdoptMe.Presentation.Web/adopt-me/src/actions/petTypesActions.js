import * as types from './actionTypes';
import axios from 'axios';
const ROOT_URL = "http://localhost:52176";

export function loadPetTypesSuccess(petTypes){
    return {type: types.LOAD_PETTYPES_SUCCESS, petTypes: petTypes };
}

export function loadPetTypes(){
    /*return function(dispatch){
        fetch(ROOT_URL+'/api/pet/types').then((response) => {
            dispatch(loadPetTypesSuccess(response.json()));
        }).catch(error => {
            throw(error);
        });
    };*/

    return function(dispatch){
        dispatch({type:types.LOAD_PETTYPES_SUCCESS, isFetching: true,petTypes:[]});
        axios.get(ROOT_URL+'/api/pet/types').then((response)=>{
            dispatch({type:types.LOAD_PETTYPES_SUCCESS,isFetching:false,petTypes:response.data});
        });
    };
}