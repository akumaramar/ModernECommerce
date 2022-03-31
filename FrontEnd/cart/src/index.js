import faker from "faker";

const shoppingCartNumber = faker.random.number(200);


document.querySelector('#shoppingcart-list').innerHTML = shoppingCartNumber;