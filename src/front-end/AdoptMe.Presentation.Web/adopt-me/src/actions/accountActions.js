import * as types from '../actions/actionTypes';
import axios from 'axios';

export function createAccount(account){
    return function(dispatch){
        dispatch({type:types.ACTION_CREATE_ACCOUNT_BEGIN,account:account});
        let accountModel = {
            Username:account.userName,
            Password:account.password,
            ConfirmPassword:account.passwordConfirmation,
            Email:account.eMail,
            ConfirmEmail:account.eMail,
            FirstName:account.firstName,
            LastName:account.lastName,
            BirthDate:null
        };
        axios.post(types.ROOT_URL+'/api/account/create', accountModel).then((response)=>{
            dispatch({type:types.ACTION_CREATE_ACCOUNT_SUCCESS,response:response.data});
        }).catch((error)=>{
            dispatch({type:types.ACTION_CREATE_ACCOUNT_FAIL,error:error.response.data.errors});
        });
    };
}
export function validateUsername(account){
    return function(dispatch){
        dispatch({type:types.ACTION_VALIDATE_USERNAME_BEGIN,isValid:true,message:''});
        axios.get(types.ROOT_URL+'/api/account/'+account.userName+'/validateName').then((response)=>{
            dispatch({type:types.ACTION_VALIDATE_USERNAME_SUCCESS,validation:{username:response.data.isValid}});
        }).catch((error)=>{
            //console.log(error);
            dispatch({type:types.ACTION_VALIDATE_USERNAME_SUCCESS,validation:{username:false}});
        });
    };
}
export function validateEmail(account) {
    return function(dispatch) {
        dispatch({ type: types.ACTION_VALIDATE_EMAIL_BEGIN, isValid: true, message: '' });
        axios.get(types.ROOT_URL+'/api/account/'+account.eMail+'/validateEmail').then((response)=>{
            dispatch({type:types.ACTION_VALIDATE_EMAIL_SUCCESS,validation:{eMail:response.data.isValid}});
        }).catch((error)=>{
            dispatch({type:types.ACTION_VALIDATE_EMAIL_FAIL,validation:{eMail:false}});
        });
    };
}