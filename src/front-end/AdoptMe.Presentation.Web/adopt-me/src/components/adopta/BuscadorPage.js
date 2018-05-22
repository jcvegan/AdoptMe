import React, { Component } from 'react';
import PropTypes from 'prop-types';
import {connect} from 'react-redux';
import {bindActionCreators} from 'redux';
import * as petTypesActions from '../../actions/petTypesActions';
import PetTypesSelectorView from '../buscador/petTypesSelectorView';

class BuscadorPage extends React.Component {
    constructor(props,context){
        super(props,context);
        /*this.state = {
            petTypeList: {
                petTypes:{
                    petTypes:[],
                    loading:false,
                    error:''
                }
            }
        };*/
    }

    componentDidMount(){
    }
    
    render(){
        return (
        <div className="uk-section uk-padding-remove" data-uk-height-viewport="offset-top: true">
            <div className="uk-container-large">
                <div className="uk-grid-collapse uk-grid-divider uk-child-width-expand@s" data-uk-grid>
                    <div className="uk-width-1-3@m">
                            <h3>Buscador</h3>
                            <PetTypesSelectorView petTypes={this.props.petTypes} />
                    </div>
                </div>
            </div>
        </div>
        );
    }
}
BuscadorPage.propTypes = {
    petTypes:PropTypes.array.isRequired
};

function mapStateToProps(state, ownProps){
    return {
        petTypes: state.petTypes
    };
}
function mapDispacthToProps(dispatch){
    return {
        actions:bindActionCreators(petTypesActions,dispatch)
    };
}
export default connect(mapStateToProps,mapDispacthToProps)(BuscadorPage);