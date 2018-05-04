import React from 'react';
import {Link} from 'react-router';
import NewAccountPage from '../account/NewAccountPage';
class HomePage extends React.Component {
    render(){
        return (
            <div className="uk-container uk-container-large">
                <NewAccountPage />
            </div>
        );
    }
}
export default HomePage;