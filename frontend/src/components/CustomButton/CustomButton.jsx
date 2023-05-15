import { Link } from 'react-router-dom';
import { Color } from '../../style/colors.js';
import { Button } from '@mantine/core';

export const CustomButton = (props) => {
    console.log(Color.Primary)
    return (
        /*         <Link to={props.link}>*/
        <Button color="purple" variant={props.variant} style={{ maxWidth: "100%", height: 'auto', fontSize: "16px", fontWeight: 700, padding: "16px 0", width: "320px", overflowWrap: 'break-word' }} radius="10px">
            {props.value}
        </Button>
        /*         </Link >*/
    )
}