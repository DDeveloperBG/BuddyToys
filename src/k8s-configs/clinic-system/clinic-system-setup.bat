kubectl create -f clinic-namespace.yaml

:: sqlserver
cd ./sqlserver
call sqlserver-setup.bat
cd ..

:: forum-service
cd ./clinic-service
call clinic-setup.bat
cd ..