kind create cluster --name rabbit --image kindest/node:v1.18.4

kubectl apply -n rabbits -f .\kubernetes\rabbit-rbac.yaml --namespace=item

kubectl apply -n rabbits -f .\kubernetes\rabbit-configmap.yaml --namespace=item

kubectl apply -n rabbits -f .\kubernetes\rabbit-secret.yaml --namespace=item

kubectl apply -n rabbits -f .\kubernetes\rabbit-statefulset.yaml --namespace=item