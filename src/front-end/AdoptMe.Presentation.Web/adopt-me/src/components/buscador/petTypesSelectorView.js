import React, { Component } from 'react';
class PetTypesSelectorView extends React.Component {
    constructor(props,context){
        super(props,context);
    }
    render(){
        const isFetching = this.props.petTypes.isFething;
        const types = this.props.petTypes.petTypes;
        return (
            <div className="uk-grid-small uk-child-width-expand@s" data-uk-grid>
                {this.props.petTypes.petTypes.map((type,i)=>{
                    return (<div className="uk-width-1-2@s"><label key={type.id}><input type="checkbox" className="uk-checkbox" /> {type.name}</label></div>)
                })}
            </div>
        );
    }
}
export default PetTypesSelectorView;