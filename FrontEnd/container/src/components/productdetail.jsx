import { ColorSwatchIcon } from "@heroicons/react/outline";
import React from "react";
import { useLocation } from "react-router-dom";


const ProdudctDetail = (props) => {

    const location = useLocation();
    const product = location.state;
    console.log('state Value');
    console.log(product);
    console.log('Props Value');
    console.log(props);

    //const { id, href, imageSrc, imageAlt, name, price } = props.product;

    const { id, href, imageSrc, imageAlt, name, price } = product;

    //console.log(name);

    return (
        <div>
            <di>
                Product Name: { name }
            </di>

        </div>
    )
}


export default ProdudctDetail;