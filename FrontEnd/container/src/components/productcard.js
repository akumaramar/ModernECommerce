import React from "react";
import {Link} from "react-router-dom";

const ProductCard = (props) =>{

    const { id, href, imageSrc, imageAlt, name, price } = props.product;

    console.log(props);
        
    return(
        <Link to={href} state={props.product}>
          <div className="w-full aspect-w-1 aspect-h-1 bg-gray-200 rounded-lg overflow-hidden xl:aspect-w-7 xl:aspect-h-8">
                  <img
                    src={imageSrc}
                    alt={imageAlt}
                    className="w-full h-full object-center object-cover group-hover:opacity-75"
                  />
                </div>
                <h3 className="mt-4 text-sm text-gray-700">{name}</h3>
                <p className="mt-1 text-lg font-medium text-gray-900">{price}</p>
        </Link>
    );
}

export default ProductCard;