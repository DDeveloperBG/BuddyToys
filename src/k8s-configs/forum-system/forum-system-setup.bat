kubectl create -f forum-namespace.yaml

:: elasticsearch
cd ./elasticsearch
call elasticsearch.bat
cd ..

:: sqlserver
cd ./sqlserver
call sqlserver-setup.bat
cd ..

:: forum-service
cd ./forum-service
call forum-setup.bat
cd ..