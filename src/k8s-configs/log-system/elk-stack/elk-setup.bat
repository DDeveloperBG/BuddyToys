helm repo add elastic https://helm.elastic.co

helm repo update

:: Install logstash
helm install logstash elastic/logstash --namespace=log --wait

:: Install elastic search
helm install elasticsearch elastic/elasticsearch -f values.yaml --namespace=log --create-namespace --wait

kubectl port-forward service/elasticsearch-master 9200 --namespace=log

:: Install kibana
helm install kibana elastic/kibana --namespace=log --wait

kubectl port-forward deployment/kibana-kibana 5601 --namespace=log