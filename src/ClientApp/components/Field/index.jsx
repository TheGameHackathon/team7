import React from 'react';
import styles from './styles.css'

export default class Field extends React.Component {
    constructor() {
        super();
        this.state = {
            colors: [styles.color1, styles.color2, styles.color3, styles.color4, styles.color5],
            field: [[], [],[],[],[]]
        }
    }

    createTable = () => {
        let table = [];
        for (let i = 0; i < this.state.field.length; i++) {
            let children = [];
            for (let j = 0; j < this.state.field[i].length; j++) {
                children.push(<td className={this.colors[this.state.field[i][j]]} onClick={() => this.postPos(i, j)}/>)
            }
            table.push(<tr>{children}</tr>)
        }
        return table
    };
    
    postPos = (i, j) => {
        fetch(`api/game/click?x=${j}&y=${i}`, {
            method: 'POST',
        }).then(response => response.json()).then(res => {
            this.setState({ field: res }); })
    };

    render () {
        this.colors = [styles.color1, styles.color2, styles.color3, styles.color4, styles.color5];
        return (
            <div className={styles.center}>
                <div className={styles.fieldWrapper}>
                    <table className={styles.field}>
                        {this.createTable()}
                    </table>
                </div>
            </div>
        );
    }

    componentDidMount() {
        fetch("api/game/field?width=5&height=5&colorsCount=5").then(response => response.json()).then(res => {
            this.setState({ field: res });
        })
    }
}
