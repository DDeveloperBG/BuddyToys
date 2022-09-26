minikube docker-env

@FOR /f "tokens=*" %i IN ('minikube -p minikube docker-env') DO @%i

kubectl apply -f receiver-configmap.yaml --namespace=item

kubectl apply -f receiver-deployment.yaml --namespace=item

kubectl apply -f receiver-service.yaml --namespace=item

cd ../../../services\item-system\receiver-service

docker build -t receiver-api -f Dockerfile .