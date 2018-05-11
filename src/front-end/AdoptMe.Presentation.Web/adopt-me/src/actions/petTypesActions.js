import axios from 'axios';

const ROOT_URL = "http://localhost:52176";

export function fetchAllPetTypes(){
    const requestPayload = axios({
        method:'get',
        url:ROOT_URL+'/api/pet/types',
        headers:[]
    });
    return {
        type:'FETCH_PET_TYPES',
        payload:requestPayload 
    };
}
export function fetchAllPetTypesSucceed(petTypes){
    return { type:'FETCH_PET_TYPES_SUCCEED',petTypes:petTypes };
}
export function fetchAllPetTypesError(error){
    return { type:'FETCH_PET_TYPES_ERROR',petTypes:error };
}