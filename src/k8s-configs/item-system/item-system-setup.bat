:: elasticsearch setup
cd ./elasticsearch
call elasticsearch-setup.bat
cd ..

:: redis setup
cd ./redis
call redis-setup.bat
cd ..

:: cassandra setup
cd ./cassandra
call cassandra-setup.bat
cd ..

:: rabbitmq setup
cd ./rabbitmq
call rabbitmq-setup.bat
cd ..

:: sqlserver setup
cd ./sqlserver
call sqlserver-setup.bat
cd ..

:: itemread-service
cd ./itemread-service
call itemread-setup.bat
cd ..

:: itemsearch-service
cd ./itemsearch-service
call itemsearch-setup.bat
cd ..

:: management-service
cd ./management-service
call management-setup.bat
cd ..

:: order-service
cd ./order-service
call order-setup.bat
cd ..

:: payment-interface
cd ./payment-interface
call payment-setup.bat
cd ..

:: receiver-service
cd ./receiver-service
call receiver-setup.bat
cd ..

:: shipment-interface
cd ./shipment-interface
call shipment-setup.bat
cd ..

:: wishlist-service
cd ./wishlist-service
call wishlist-setup.bat
cd ..