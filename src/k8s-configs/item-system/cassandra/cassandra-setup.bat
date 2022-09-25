kubectl apply -f cassandra-service.yaml --namespace=item

kubectl apply -f cassandra-statefulset.yaml --namespace=item

kubectl apply -f cassandra-storageclass.yaml --namespace=item

pause