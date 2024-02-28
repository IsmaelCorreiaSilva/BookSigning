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

CREATE PROCEDURE add_subscription_type (
	IN title VARCHAR(100), IN sdescription VARCHAR(500), IN price DECIMAL,
	OUT subscription_type
)
BEGIN
 INSERT INTO SubscriptionType (sub_title, sub_description, sub_price) VALUES (title, sdescription, price)
 SELECT * FROM SubscriptionType WHERE sub_id = (SELECT MAX(sub_id) FROM SubscriptionType)
END