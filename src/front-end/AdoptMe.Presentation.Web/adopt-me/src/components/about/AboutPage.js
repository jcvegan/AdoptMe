import React from 'react';
import {Link} from 'react-router';
import FontAwesomeIcon from '@fortawesome/react-fontawesome';
import { faCoffee,faPaw, faFlag, faBinoculars } from '@fortawesome/fontawesome-free-solid';
class AboutPage extends React.Component {
    render(){
        return (
        <div className="uk-section uk-padding-remove">
            <div className="uk-section bg-pet-about-1 uk-flex uk-flex-middle uk-text-center" data-uk-height-viewport="offset-top: true">
                <div className="uk-width-1-1">
                    <div className="uk-container uk-light">
                        <FontAwesomeIcon icon={faPaw} size="6x" />
                        <h1>Adoptame</h1>
                        <p>Un proyecto para encontrarle un hogar a animalitos rescatados</p>
                    </div>
                </div>
            </div>
            <div className="uk-section bg-pet-about-2 uk-flex uk-flex-middle uk-text-center" data-uk-height-viewport="offset-top: true">
                <div className="uk-width-1-1">
                    <div className="uk-container uk-dark">
                        <FontAwesomeIcon icon={faFlag} size="6x" />
                        <h1>Misión</h1>
                        <p>Colaborar con las personas involucradas en el rescate de las mascotas, como también a las personas que están en búsqueda de una adopción  de mascota para su cuidado</p>
                    </div>
                </div>
            </div>
            <div className="uk-section bg-pet-about-3 uk-flex uk-flex-middle uk-text-center" data-uk-height-viewport="offset-top: true">
                <div className="uk-width-1-1">
                    <div className="uk-container uk-dark">
                        <FontAwesomeIcon icon={faBinoculars} size="6x" />
                        <h1>Visión</h1>
                        <p>La visión de este proyecto es fomentar las adopciones, ubicando a las mascotas rescatadas en hogares que les brinden seguridad y calidad de vida.</p>
                    </div>
                </div>
            </div>
            <div className="uk-section bg-pet-about-4 uk-flex uk-flex-middle uk-text-center" data-uk-height-viewport="offset-top: true"></div>
            <div className="uk-section bg-pet-about-1 uk-flex uk-flex-middle uk-text-center" data-uk-height-viewport="offset-top: true"></div>
        </div>
        );
    }
}
export default AboutPage;