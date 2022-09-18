minikube start --cpus 4 --memory 8192

:: item-system setup
cd ./item-system
call item-system-setup.bat
cd ..

:: forum-system setup
cd ./forum-system
call forum-system-setup.bat
cd ..

:: clinic-system setup
cd ./clinic-system
call clinic-system-setup.bat
cd ..

:: log-system setup
cd ./log-system
call log-system.bat
cd ..