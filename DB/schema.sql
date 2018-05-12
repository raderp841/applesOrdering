create table userInfo
(
	id				int			primary key			identity(1,1),
	firstName		varchar(20) not null,
	lastName		varchar(20) not null,
	email			varchar(50) not null,
	password		varchar(20) not null,
	passwordSalt	varchar(max)null,
	isAdmin			bit			not null,
	isDeli			bit			not null,
	isBakery		bit			not null
);

create table bakeryOrder
(
	id				int			primary key			identity(1,1),
	orderName		varchar(50) not null,
	phoneNumber		varchar(20) not null,
	orderTime		dateTime    not null,
	pickUpTime		dateTime    not null,
	userInfoId		int			not null,
	size			varchar(30) not null,
	dough			varchar(30) not null,
	icing			varchar(30) not null,
	messageInfo		varchar(200) null,
	borderTrim		varchar(100) null,
	kitNumber		int			 null,
	kitName			varchar(100) null,

	constraint fk_bakeryOrder_userInfo foreign key (userInfoId) references userInfo(id)
);

create table deliOrder
(
	id				int			primary key			identity(1,1),
	orderName		varchar(50) not null,
	phoneNumber		varchar(20) not null,
	orderTime		dateTime    not null,
	pickUpTime		dateTime    not null,
	userInfoId		int			not null,
	numberOfPieces  int			not null,

	constraint fk_deliOrder_userInfo foreign key (userInfoId) references userInfo(id)
);
