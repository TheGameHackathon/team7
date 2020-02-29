import React from 'react';
import styles from './styles.css'

export default class Field extends React.Component {
    render () {
        return (
            <div className={styles.center}>
                <div className={styles.fieldWrapper}>
                    <table className={styles.field}>
                        <tr>
                            <td className={styles.color1}></td>
                            <td className={styles.color1}></td>
                            <td className={styles.color1}></td>
                            <td className={styles.color1}></td>
                            <td className={styles.color1}></td>
                        </tr>
                        <tr>
                            <td className={styles.color1}></td>
                            <td className={styles.color1}></td>
                            <td className={styles.color1}></td>
                            <td className="color3"></td>
                            <td className="color4"></td>
                        </tr>
                        <tr>
                            <td className="color4"></td>
                            <td className="color4"></td>
                            <td className="color4"></td>
                            <td className="color1"></td>
                            <td className="color5"></td>
                        </tr>
                        <tr>
                            <td className="color1"></td>
                            <td className="color5"></td>
                            <td className="color1"></td>
                            <td className="color1"></td>
                            <td className="color2"></td>
                        </tr>
                        <tr>
                            <td className={styles.color1}></td>
                            <td className="color2"></td>
                            <td className="color1"></td>
                            <td className="color1"></td>
                            <td className="color3"></td>
                        </tr>
                    </table>
                </div>
            </div>
        );
    }
}
