import React from 'react';
import styles from './styles.css';

export default class Field extends React.Component {
    constructor() {
        super();
        this.state = {
            field: [],
        };
    }

    componentDidMount() {
        fetch("api/game/field")
            .then(response => response.json())
            .then(res => this.setState({
                field: res,
            }));

    }

    generateField() {
        var styles_c = [styles.color1, styles.color2, styles.color3, styles.color4, styles.color5];
        var res = [];
        console.log(this.state.field)
        for(var k = 0; k<5; k++) {
            var arr = [];
            for (var i = 0; i < 5; i++) {
                // arr.push(<td className={styles_c[this.state.field[k][i]]}/>)
            }
            var a = <tr>{arr}</tr>;
            res.push(a);
        }
        this.setState({ field: res } );
        return this.state.field;
    }

    render() {
        return (
            <div className={styles.center}>
                <div className={styles.fieldWrapper}>
                    <table className={styles.field}>
                        {
                            this.generateField()
                        }
                    </table>
                </div>
            </div>
            // <div className={ styles.root }/>
        );
    }
}
