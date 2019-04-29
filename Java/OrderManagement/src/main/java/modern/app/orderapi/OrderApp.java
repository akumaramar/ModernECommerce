package modern.app.orderapi;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.ApplicationContext;


@SpringBootApplication
public class OrderApp {
	
	public static void main(String[] args) {
		
		ApplicationContext ctx = SpringApplication.run(OrderApp.class, args);
		
	} 
}
