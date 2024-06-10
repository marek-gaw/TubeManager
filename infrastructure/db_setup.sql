CREATE ROLE docker
create user docker

SELECT rolname FROM pg_roles WHERE rolcanlogin;

alter role docker login
grant admin to marek with inherit true

ALTER DATABASE tubemanager OWNER TO marek;
GRANT USAGE, CREATE ON SCHEMA public TO marek

grant all privileges on database tubemanager to docker;
grant all privileges on all tables in schema public to docker;
grant all privileges on all sequences in schema public to docker;
grant all privileges on all functions in schema public to docker;
GRANT CREATE ON SCHEMA public TO docker;
