package modern.app.orderapi.shoppingcart;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/shoppingcart")
public class ShoppingCartController {
	
	@RequestMapping(method = RequestMethod.GET)
	public String getAllItems() {
		
		return "All shopping cart";
	
	}

}
