DROP TABLE IF EXISTS Books;
CREATE TABLE Books(
	Id int not null auto_increment primary key,
	Title varchar(100) not null,
	Summary varchar(1000) not null,
	PublishingCompany varchar(100) not null,
	Author varchar(100) not null,
	ReleaseDate date not null,

);