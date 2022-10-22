cas_query="
CREATE ROLE IF NOT EXISTS 'crud_user' WITH SUPERUSER = true AND LOGIN = true AND PASSWORD = 'password';
CREATE KEYSPACE IF NOT EXISTS items_data WITH replication = {'class': 'SimpleStrategy', 'replication_factor': '1'};
EXIT;
"

del_def_role_query="DROP ROLE cassandra;"


first_exp=echo $cas_query | cqlsh -u 'cassandra' -p 'cassandra'
second_exp=echo $del_def_role_query | cqlsh -u 'crud_user' -p 'password'

until ($first_exp && $second_exp)
do
	now=$(date +%T)
	echo "[$now INIT CQLSH]: Node still unavailable, will retry another time"
	sleep 2
done &

exec /usr/local/bin/docker-entrypoint.sh "$@"