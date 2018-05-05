import React from 'react';
import {Link} from 'react-router';
import NewAccountPage from '../account/NewAccountPage';
class HomePage extends React.Component {
    render(){
        return (
            <div className="uk-section uk-background-cover uk-height-viewport bg-pet-landing" >
                <div className="uk-container uk-container-large uk-dark">
                    <NewAccountPage />
                </div>
            </div>
        );
    }
}
export default HomePage;