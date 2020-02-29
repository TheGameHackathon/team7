import React from 'react';
import styles from './styles.css'

export default class Field extends React.Component {
    constructor() {
        super();
        this.state = {
            colors: [styles.color1, styles.color2, styles.color3, styles.color4, styles.color5],
            field: [[4]]
        }
    }

    render () {
        this.colors = [styles.color1, styles.color2, styles.color3, styles.color4, styles.color5]
        return (
            <div className={styles.center}>
                <div className={styles.fieldWrapper}>
                    <table className={styles.field}>
                        <tr>

                            <td className={this.colors[this.state.field[0][0]]}></td>
                            <td className={this.colors[this.state.field[0][1]]}></td>
                            <td className={this.colors[this.state.field[0][2]]}></td>
                            <td className={this.colors[this.state.field[0][3]]}></td>
                            <td className={this.colors[this.state.field[0][4]]}></td>
                        </tr>
                        <tr>
                            <td className={this.colors[this.state.field[0][0]]}></td>
                            <td className={this.colors[this.state.field[0][1]]}></td>
                            <td className={this.colors[this.state.field[0][2]]}></td>
                            <td className={this.colors[this.state.field[0][3]]}></td>
                            <td className={this.colors[this.state.field[0][4]]}></td>
                        </tr>
                        <tr>
                            <td className={this.colors[this.state.field[0][0]]}></td>
                            <td className={this.colors[this.state.field[0][1]]}></td>
                            <td className={this.colors[this.state.field[0][2]]}></td>
                            <td className={this.colors[this.state.field[0][3]]}></td>
                            <td className={this.colors[this.state.field[0][4]]}></td>
                        </tr>
                        <tr>
                            <td className={this.colors[this.state.field[0][0]]}></td>
                            <td className={this.colors[this.state.field[0][1]]}></td>
                            <td className={this.colors[this.state.field[0][2]]}></td>
                            <td className={this.colors[this.state.field[0][3]]}></td>
                            <td className={this.colors[this.state.field[0][4]]}></td>
                        </tr>
                        <tr>
                            <td className={this.colors[this.state.field[0][0]]}></td>
                            <td className={this.colors[this.state.field[0][1]]}></td>
                            <td className={this.colors[this.state.field[0][2]]}></td>
                            <td className={this.colors[this.state.field[0][3]]}></td>
                            <td className={this.colors[this.state.field[0][4]]}></td>
                        </tr>
                    </table>
                </div>
            </div>
        );
    }

    componentDidMount() {
        fetch("api/game/field?width=5&height=5&color=5").then(response => response.json()).then(res => {
            this.setState({ field: res });
        })
    }
}
