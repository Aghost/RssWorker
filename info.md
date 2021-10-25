# Info
## psql commands
`sudo -u username psql -d database_name -U database_username`
`sudo -u username psql -d database_name -U database_username <<EOF
"sql commands"
EOF
`

## Initialize database
sql cmds:
`create table articles(id SERIAL PRIMARY KEY, title TEXT, link TEXT, publication TEXT);`
`create table rssfeeds(id SERIAL PRIMARY KEY, name TEXT, link TEXT, lastupdated TEXT);`
`grant all privileges on database csharpproject to appuser;`

## Links
- dbcontext and other services in Program.cs:
https://entityframeworkcore.com/knowledge-base/59749330/ef-core-dbcontext-inside-net-core-worker-windows-service
https://www.tutorialsteacher.com/core/aspnet-core-program

- IHttpClientFactory:
https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests

- system aggregate error:
https://stackoverflow.com/questions/63155869/system-aggregateexception-some-services-are-not-able-to-be-constructed-in-my
