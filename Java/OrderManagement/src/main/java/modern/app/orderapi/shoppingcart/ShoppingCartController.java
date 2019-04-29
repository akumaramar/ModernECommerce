package modern.app.orderapi.shoppingcart;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class ShoppingCartController {
	
	@RequestMapping("/shoppingcart")
	public String getAllItems() {
		
		return "All shopping cart";
		
	}

}
