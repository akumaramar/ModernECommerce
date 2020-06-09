#######################################################################
# Terraform Script to create Azure Infrastructure to deploy in VM Modes
#######################################################################


#######################################################################
# Variables
#######################################################################

variable "azure_subscription_id" {}


#variable "azure_subscription_id" {
#  default = "dbe576b0-40b0-48d0-a49a-3829258f2d67"
#}

#######################################################################
# Providers
#######################################################################
provider "azurerm" {
  # whilst the `version` attribute is optional, we recommend pinning to a given version of the Provider
  version = "=2.0.0"
  features {}
  #azure_subscription_id = "dbe576b0-40b0-48d0-a49a-3829258f2d67"
}

variable "prefix" {
  default = "m2mtest"
}

# Create a resource group
resource "azurerm_resource_group" "main" {
  name     = "${var.prefix}-resources"
  location = "West US 2"
}

# Create a virtual network
resource "azurerm_virtual_network" "main" {
  name                = "${var.prefix}-network"
  address_space       = ["10.1.0.0/16"]
  location            = azurerm_resource_group.main.location
  resource_group_name = azurerm_resource_group.main.name
}

# Create subnet1 in network
resource "azurerm_subnet" "web-sub" {
  name                 = "web-sub"
  resource_group_name  = azurerm_resource_group.main.name
  virtual_network_name = azurerm_virtual_network.main.name
  address_prefix       = "10.1.0.0/28"
}

# Create subnet2 in network
resource "azurerm_subnet" "db-sub" {
  name                 = "db-sub"
  resource_group_name  = azurerm_resource_group.main.name
  virtual_network_name = azurerm_virtual_network.main.name
  address_prefix       = "10.1.0.16/28"
}

# Create NSG for Web Server
resource "azurerm_network_security_group" "main-web-nsg" {
  name                = "web-sub-nsg"
  location            = azurerm_resource_group.main.location
  resource_group_name = azurerm_resource_group.main.name

  # Web Traffic
  security_rule {
    name                       = "WebTraffic"
    priority                   = 310
    direction                  = "Inbound"
    access                     = "Allow"
    protocol                   = "*"
    source_port_range          = "*"
    destination_port_range     = "80"
    source_address_prefix      = "*"
    destination_address_prefix = "*"
  }

  # RDP
  security_rule {
    name                       = "RDP"
    priority                   = 300
    direction                  = "Inbound"
    access                     = "Allow"
    protocol                   = "Tcp"
    source_port_range          = "*"
    destination_port_range     = "3389"
    source_address_prefix      = "*"
    destination_address_prefix = "*"
  }

}

# Associate nsg to subnet
resource "azurerm_subnet_network_security_group_association" "example" {
  subnet_id                 = azurerm_subnet.web-sub.id
  network_security_group_id = azurerm_network_security_group.main-web-nsg.id
}


# Create NSG for DB Server Subnet
resource "azurerm_network_security_group" "main-db-nsg" {
  name                = "db-sub-nsg"
  location            = azurerm_resource_group.main.location
  resource_group_name = azurerm_resource_group.main.name
  
}

# Create Web Server Public IP
resource "azurerm_public_ip" "webip" {
  name                    = "${var.prefix}-web01-pip"
  location                = azurerm_resource_group.main.location
  resource_group_name     = azurerm_resource_group.main.name
  allocation_method       = "Dynamic"
  idle_timeout_in_minutes = 30

}


# Create network interface
resource "azurerm_network_interface" "main-web" {
  name                = "${var.prefix}-web-nic"
  location            = azurerm_resource_group.main.location
  resource_group_name = azurerm_resource_group.main.name

  ip_configuration {
    name                          = "web-server-networkConfig"
    subnet_id                     = azurerm_subnet.web-sub.id
    private_ip_address_allocation = "Dynamic"
    public_ip_address_id          = azurerm_public_ip.webip.id
  }
}

resource "azurerm_network_interface" "main-db" {
  name                = "${var.prefix}-db-nic"
  location            = azurerm_resource_group.main.location
  resource_group_name = azurerm_resource_group.main.name

  ip_configuration {
    name                          = "web-server-networkConfig"
    subnet_id                     = azurerm_subnet.db-sub.id
    private_ip_address_allocation = "Dynamic"
  }
}

# Create Web Server
resource "azurerm_windows_virtual_machine" "example" {
  name                = "${var.prefix}-web01"
  resource_group_name = azurerm_resource_group.main.name
  location            = azurerm_resource_group.main.location
  size                = "Standard_DS1_v2"
  admin_username      = "akumaramar"
  admin_password      = "RameshPandit17@"
  network_interface_ids = [
    azurerm_network_interface.main-web.id,
  ]

  os_disk {
    caching              = "ReadWrite"
    storage_account_type = "Standard_LRS"
  }

  source_image_reference {
    publisher = "MicrosoftWindowsServer"
    offer     = "WindowsServer"
    sku       = "2016-Datacenter"
    version   = "latest"
  }
}


# Create DB Server

# Create Network Security Group (NSG)

# Assign Network Groups to subnets

# Craete Application Gateway

# Set Web Application Firewall(WAF)

# 
