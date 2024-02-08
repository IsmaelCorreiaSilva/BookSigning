DROP TABLE IF EXISTS Books;
CREATE TABLE Books(
	boo_id int not null auto_increment primary key,
	boo_title varchar(100) not null,
	boo_summary varchar(1000) not null,
	boo_publishingCompany varchar(100) not null,
	boo_author varchar(100) not null,
	boo_releaseDate date not null,

);
CREATE TABLE SubscriptionType(
	sub_title varchar(100) not null,
	sub_description varchar(500) not null,
	sub_price decimal not null
);