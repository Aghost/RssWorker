articles:
	sudo -u postgres psql -d csharpproject -U appuser -c 'select * from articles;'

feeds:
	sudo -u postgres psql -d csharpproject -U appuser -c 'select * from rssfeeds;'

db:
	sudo -u postgres psql -d csharpproject -U appuser -c 'create table articles(id SERIAL PRIMARY KEY, title TEXT, link TEXT, publication TEXT); create table rssfeeds(id SERIAL PRIMARY KEY, name TEXT, url TEXT)'

clear:
	sudo -u postgres psql -d csharpproject -U appuser -c 'drop table articles; drop table rssfeeds;'
