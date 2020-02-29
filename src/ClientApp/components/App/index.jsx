import React from 'react';
import styles from './styles.css';
import Field from '../Field';

export default class App extends React.Component {
    constructor () {
        super();
        this.state = {
            score: 50,
        };
    }

    render() {
        fetch()
        return (
            <div className={ styles.root }>
                <div className={styles.score}>
                    Ваш счет: { this.state.score }
                </div>
                <Field />
            </div>
        );
    }
    
    componentDidMount() {
        fetch("api/game/score")
            .then(response => response.json())
            .then(res => this.setState({
                score: res,
        }));
        
    }
}
