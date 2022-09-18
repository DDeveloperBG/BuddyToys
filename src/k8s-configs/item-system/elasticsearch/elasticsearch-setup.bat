helm repo add elastic https://helm.elastic.co

helm repo update

:: Install elastic search
helm install elasticsearch elastic/elasticsearch -f values.yaml --namespace=elk --create-namespace --wait

kubectl port-forward service/elasticsearch-master 9600 --namespace=elk