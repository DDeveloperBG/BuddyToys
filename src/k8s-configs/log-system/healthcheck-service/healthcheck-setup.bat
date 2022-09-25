minikube docker-env

@FOR /f "tokens=*" %i IN ('minikube -p minikube docker-env') DO @%i

kubectl apply -f healthcheck-deployment.yaml --namespace=log

cd ../../../services\log-system\health-check-service

docker build -t healthcheck-api -f Dockerfile .