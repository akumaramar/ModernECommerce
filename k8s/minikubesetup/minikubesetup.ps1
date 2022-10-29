echo "Deleting current environment"
minikube delete
echo "Starting minikube environment"
minikube start --driver=hyperv
echo "Docker Enviroment"
minikube docker-env
echo "Kubectl setup"
& minikube -p minikube docker-env --shell powershell | Invoke-Expression
echo "Setup Kubectl Setup"
function kubectl { minikube kubectl -- $args }