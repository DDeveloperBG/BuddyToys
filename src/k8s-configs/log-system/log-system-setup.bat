kubectl create -f log-namespace.yaml

:: elk stack
cd ./elk-stack
call elk-setup.bat
cd ..

:: healthcheck-service
cd ./healthcheck-service
call healthcheck-setup.bat
cd ..