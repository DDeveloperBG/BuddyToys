minikube docker-env

@FOR /f "tokens=*" %i IN ('minikube -p minikube docker-env') DO @%i

:: kubectl apply -f healthcheck-deployment.yaml

:: kubectl apply -f healthcheck-service.yaml

:: cd ../../../services\log-system\health-check-service

:: docker build -t healthcheck-api -f Dockerfile .