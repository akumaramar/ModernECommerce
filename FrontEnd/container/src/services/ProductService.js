export async function getAllProducts() {
    try {
        const response = await fetch('http://localhost:8889/products');
        return response.json();
        
    } catch (error) {
        console.log(error);
        
    }

}