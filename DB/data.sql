select * from userInfo;

insert into userInfo values ('Peter', 'Rader', 'admin@admin.com', 'admin', null, 1, 0, 0);
insert into userInfo values ('Deli', 'Deli', 'deli@deli.com', 'deli', null, 0, 1, 0);
insert into userInfo values ('Bakery', 'Bakery', 'bakery@bakery.com', 'bakery', null, 0, 0, 1);
insert into deliOrder values ('Mr. Frankfort', '555-555-5555', GETDATE(), '5-15-2018 18:44:32', 1, 40, 0, 1);

delete from userInfo where id = 3;

select * from store

insert into store values('Wellington Apples');