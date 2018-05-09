export default function accountReducer(state = [], action){
    switch(action.type){
        case 'CREATE_ACCOUNT':
            debugger;
            return [...state,Object.assign({},action.account)];
        
        default:
            return state;
    }
}