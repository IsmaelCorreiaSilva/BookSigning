DROP TABLE IF EXISTS Books;
CREATE TABLE Books(
	boo_id int not null auto_increment primary key,
	boo_title varchar(100) not null,
	boo_summary varchar(1000) not null,
	boo_publishingCompany varchar(100) not null,
	boo_author varchar(100) not null,
	boo_releaseDate date not null,

);
DROP TABLE IF EXISTS SubscriptionType;
CREATE TABLE SubscriptionType(
	sub_id  int not null auto_increment primary key,
	sub_title varchar(100) not null,
	sub_description varchar(500) not null,
	sub_price decimal not null
);
DROP TABLE IF EXISTS Subscriber;
CREATE TABLE Subscriber(
	sbs_id int not null auto_increment primary key,
	sbs_name varchar(100) not NULL,
	sbs_phone varchar(15) not null
);
DROP TABLE IF EXISTS MonthlyShipping;
CREATE TABLE MonthlyShipping(
	mon_id int not null auto_increment primary key,
	mon_description varchar(500) not NULL,
	mon_gift varchar(200) not null
);