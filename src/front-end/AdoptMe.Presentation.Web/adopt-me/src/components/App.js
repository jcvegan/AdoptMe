import React, {PropTypes} from 'react';
import Header from './common/Header';

class App extends React.Component {
    render(){
        return (
            <div className="uk-section-transparent">
                <Header/>
                <div className="uk-section uk-section-small uk-flex uk-flex-middle uk-text-center">
                    {this.props.children}
                </div>
            </div>
        );
    }
}

App.propTypes = {
    children: PropTypes.object.isRequired
};

export default App;