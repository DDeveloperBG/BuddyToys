minikube docker-env

kubectl apply -f redis-conf.yaml --namespace=item

kubectl apply -f redis-pod.yaml --namespace=item