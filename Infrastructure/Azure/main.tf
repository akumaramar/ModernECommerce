#######################################################################
# Terraform Script to create Azure Infrastructure to deploy in VM Modes
#######################################################################


#######################################################################
# Variables
#######################################################################
variable "prefix" {
  default = "m2mtest"
}

variable "location" {
  default = "West US 2"
}

variable "vnet_cidr_range" {
  type    = list(string)
  default = ["10.1.0.0/16"]
}

variable "subnet_prefixes" {
  type    = list(string)
  default = ["10.1.0.0/28", "10.1.0.16/28"]
  
}

variable "subnet_names" {
  type    = list(string)
  default = ["web-sub", "db-sub"]
}


#######################################################################
# Providers
#######################################################################
provider "azurerm" {
  # whilst the `version` attribute is optional, we recommend pinning to a given version of the Provider
  version = "=2.0.0"
  features {}
  #azure_subscription_id = "dbe576b0-40b0-48d0-a49a-3829258f2d67"
}

#######################################################################
# Resource Group
#######################################################################
resource "azurerm_resource_group" "main" {
  name     = "${var.prefix}-resources"
  location = "West US 2"
}

#######################################################################
# Compute
#######################################################################
module "windowsservers" {
  source                        = "Azure/compute/azurerm"
  resource_group_name           = azurerm_resource_group.main.name
  vm_hostname                   = "${var.prefix}-web01"
  is_windows_image              = true
  admin_username                = "#################"
  admin_password                = "#################"
  vm_os_publisher               = "MicrosoftWindowsServer"
  vm_os_offer                   = "WindowsServer"
  vm_os_sku                     = "2016-Datacenter"
  vm_size                       = "Standard_DS1_v2"
  vnet_subnet_id                = module.vnet-main.vnet_subnets[0]
}


#######################################################################
# Network
#######################################################################
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

# Create NSG for DB Server Subnet
resource "azurerm_network_security_group" "main-db-nsg" {
  name                = "db-sub-nsg"
  location            = azurerm_resource_group.main.location
  resource_group_name = azurerm_resource_group.main.name
  
}

module "vnet-main" {
  source              = "Azure/vnet/azurerm"
  resource_group_name = azurerm_resource_group.main.name
  vnet_name           = "${var.prefix}-network"
  address_space       = var.vnet_cidr_range
  subnet_prefixes     = var.subnet_prefixes
  subnet_names        = var.subnet_names

  nsg_ids = {
    web-sub   = azurerm_network_security_group.main-web-nsg.id
    db-sub    = azurerm_network_security_group.main-db-nsg.id
  }

}


