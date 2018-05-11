import React, {PropTypes} from 'react';
import {connect} from 'react-redux';
import * as petTypesFetchAction from '../../actions/petTypesActions';

class BuscadorPage extends React.Component {
    constructor(props,context){
        super(props,context);
        this.state = {
            petTypeList: {
                petTypes:{
                    petTypes:[],
                    loading:false,
                    error:''
                }
            }
        };
    }

    componentDidMount(){
        this.props.fetchAllPetTypes();
    }
    

    render(){
        return (
        <div className="uk-section uk-padding-remove" data-uk-height-viewport="offset-top: true">
            <div className="uk-container-large"></div>
        </div>
        );
    }
}
BuscadorPage.propTypes = {
    fetchAllPetTypes: PropTypes.func.isRequired
};

function mapStateToProps(state,ownProps){
    return {
        petTypeList:state.petTypeList
    };
}

function mapDispatchToProps(dispatch){
    return {
        fetchAllPetTypes:() => dispatch(petTypesFetchAction.fetchAllPetTypes())
    };
}
export default connect(mapStateToProps,mapDispatchToProps)(BuscadorPage);
/*
const GetPetTypes = () =>{
    return fetch("http://localhost:52176/api/pet/types").then(response => {
        return response.json();
    }).catch(error => {
        throw error;
    });
};

*/