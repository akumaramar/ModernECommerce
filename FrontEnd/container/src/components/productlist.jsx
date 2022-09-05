import React from "react";
import { getAllProducts } from "../services/ProductService";
import ProductCard from "./productcard.jsx";

const products = [
    {
      id: 1,
      name: 'Earthen Bottle',
      href: '/productDetails',
      price: '$48',
      imageSrc: 'https://tailwindui.com/img/ecommerce-images/category-page-04-image-card-01.jpg',
      imageAlt: 'Tall slender porcelain bottle with natural clay textured body and cork stopper.',
    },
    {
      id: 2,
      name: 'Nomad Tumbler',
      href: '/productDetails',
      price: '$35',
      imageSrc: 'https://tailwindui.com/img/ecommerce-images/category-page-04-image-card-02.jpg',
      imageAlt: 'Olive drab green insulated bottle with flared screw lid and flat top.',
    },
    {
      id: 3,
      name: 'Focus Paper Refill',
      href: '/productDetails',
      price: '$89',
      imageSrc: 'https://tailwindui.com/img/ecommerce-images/category-page-04-image-card-03.jpg',
      imageAlt: 'Person using a pen to cross a task off a productivity paper card.',
    },
    {
      id: 4,
      name: 'Machined Mechanical Pencil',
      href: '/productDetails',
      price: '$35',
      imageSrc: 'https://tailwindui.com/img/ecommerce-images/category-page-04-image-card-04.jpg',
      imageAlt: 'Hand holding black machined steel mechanical pencil with brass tip and top.',
    },
    {
        id: 5,
        name: 'Machined Mechanical Pencil',
        href: '/productDetails',
        price: '$35',
        imageSrc: 'https://tailwindui.com/img/ecommerce-images/category-page-04-image-card-04.jpg',
        imageAlt: 'Hand holding black machined steel mechanical pencil with brass tip and top.',
      },

      {
        id: 6,
        name: 'Machined Mechanical Pencil',
        href: '/productDetails',
        price: '$35',
        imageSrc: 'https://tailwindui.com/img/ecommerce-images/category-page-04-image-card-04.jpg',
        imageAlt: 'Hand holding black machined steel mechanical pencil with brass tip and top.',
      },
    
    // More products...
  ]






const ProductList = () => {
    var productItems = products;//getAllProducts().Data;
    //console.log('Products :: ', productItems.lentgh);
    
    //if(productItems.lentgh === 0) return null;  
    //const [prouducts1, setProducts1] = useState({});

    /*
    const fetchAllProducts = () => {
      getAllProducts()
        .then(response => {
          console.log(response);
          setProducts1(response.Data);
        })
    }

    */
    
    // fetchAllProducts();

    const renderedList = productItems.map((product) => {
      return(
        <ProductCard product={product}/>
      )

    });

    return (
        <div className="bg-white">
        <div className="max-w-2xl mx-auto py-16 px-4 sm:py-24 sm:px-6 lg:max-w-7xl lg:px-8">
          <h2 className="sr-only">Products</h2>
          <div className="grid grid-cols-1 gap-y-10 sm:grid-cols-2 gap-x-6 lg:grid-cols-3 xl:grid-cols-4 xl:gap-x-8">
            {renderedList}
          </div>
        </div>
      </div>
    );
};

export default ProductList;