import * as types from '../actions/actionTypes';
import uikit from '../../node_modules/uikit/dist/js/uikit';
export default function accountReducer(state = {}, action){
    switch(action.type){
        case 'CREATE_ACCOUNT':
            return Object.assign({},action.account);
        case types.ACTION_VALIDATE_USERNAME_SUCCESS:
            return Object.assign({},{isValid:action.isValid});
        case types.ACTION_VALIDATE_EMAIL_SUCCESS:
            return Object.assign({},{isValid:action.isValid});
        case types.ACTION_VALIDATE_EMAIL_FAIL:
            return Object.assign({},{isValid:action.isValid});
        case types.ACTION_CREATE_ACCOUNT_SUCCESS:
            uikit.notification("El usuario ha sido registrado",{status:'success'});
            return Object.assign({},{
                account:{
                    userName:"",
                    eMail:"",
                    firstName : "",
                    lastName:"",
                    password:"",
                    passwordConfirmation:""
                }
            });
        case types.ACTION_CREATE_ACCOUNT_FAIL:
            action.error.map((error)=>{
                uikit.notification(error,{status:'danger'});
            });
            return state;
        default:
            return state;
    }
}