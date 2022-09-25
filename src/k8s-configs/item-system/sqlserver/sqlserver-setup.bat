kubectl apply -f sqlserver-secret.yaml --namespace=item

kubectl apply -f sqlserver-storageclass.yaml --namespace=item

kubectl apply -f sqlserver-pvc.yaml --namespace=item

kubectl apply -f sqlserver-deployment.yaml --namespace=item

kubectl apply -f sqlserver-service.yaml --namespace=item

pause