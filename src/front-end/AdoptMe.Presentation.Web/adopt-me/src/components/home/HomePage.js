import React from 'react';
import {Link} from 'react-router';
import NewAccountPage from '../account/NewAccountPage'
class HomePage extends React.Component {
    render(){
        return (
            <div>
                <NewAccountPage />
            </div>
        );
    }
}
export default HomePage;