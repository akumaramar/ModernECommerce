import faker from "faker";
import React from "react";
import ReactDOM from "react-dom";



let products = '';

for (let index = 0; index < 10; index++) {
    const name = faker.commerce.productName();
    products += `<div>${name}</div>`;    
}

const App = () => {
    return products;
}

ReactDOM.render(<App/>, document.querySelector('#product-list'));

//document.querySelector('#product-list').innerHTML = products;
//console.log(products);