//import 'products/ProductsIndex';
//import 'cart/CartIndex'
import React, { useState } from 'react';
import ReactDOM from 'react-dom/client';
import './index.css'
//import Navbar from './navigation/navbar.jsx';
//import Header from './layout/header';
import Layout from './layout/layout.jsx';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import ProductList from './components/productlist.jsx';
import ProdudctDetail from './components/productdetail.jsx';
//import { getAllProducts } from './services/ProductService';

//console.log('Container!');


const App = () => {
    return (
      <BrowserRouter>
      <Routes>
        <Route path="/" element={<Layout />}>
          <Route path="products" element={<ProductList />} />
          <Route path="productDetails" element={<ProdudctDetail />} />
        </Route>
      </Routes>
    </BrowserRouter>
    )    
  };

const root = ReactDOM.createRoot(document.getElementById('root'));

root.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>
  );

  /*
ReactDOM.render(
    <Home/>, 
    document.getElementById('root')
);*/