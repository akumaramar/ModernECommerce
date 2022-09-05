import faker from "faker";
import React, { useState } from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import ProductList from './components/productlist.jsx';
import ProdudctDetail from './components/productdetail.jsx';
import './index.css';


let products = '';

for (let index = 0; index < 10; index++) {
    const name = faker.commerce.productName();
    products += `<div>${name}</div>`;    
}

//const App = () => {
//    return products;
//}

const App = () => {
    return (
        <ProductList/>
    );
}

// ReactDOM.render(<App/>, document.querySelector('#product-list'));

const root = ReactDOM.createRoot(document.getElementById('product-list'));

root.render(
    <React.StrictMode>
      <App />
    </React.StrictMode>
    );


//document.querySelector('#product-list').innerHTML = products;
//console.log(products);