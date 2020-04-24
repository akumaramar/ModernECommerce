#######################################################################
# Terraform Script to create Azure Infrastructure to deploy in VM Modes
#######################################################################

# Variables
#variable "azure_subscription_id" {
#  default = "dbe576b0-40b0-48d0-a49a-3829258f2d67"
#}

# Configure the Azure Provider
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

# Create network interface
resource "azurerm_network_interface" "main-web" {
  name                = "${var.prefix}-web-nic"
  location            = azurerm_resource_group.main.location
  resource_group_name = azurerm_resource_group.main.name

  ip_configuration {
    name                          = "web-server-networkConfig"
    subnet_id                     = azurerm_subnet.web-sub.id
    private_ip_address_allocation = "Dynamic"
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
