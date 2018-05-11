export default function petTypeReducer(state = [],action){
    switch(action.type){
        case 'FETCH_PET_TYPES':
            return [...state, Object.assign({},{petTypeList:{ petTypes: [], error: null, loading: true }})] ;
        case 'FETCH_PET_TYPES_SUCCEED':
            return;
        default:
            return state;
    }
}