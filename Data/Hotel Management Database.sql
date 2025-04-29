create database myHotel

create table rooms(
roomid int Identity(1,1) primary key,
roomNo varchar(250) not null unique,
roomType varchar(250) not null,
bed varchar(250) not null,
price decimal not null,
booked varchar(50) default 'NO'
);

ALTER TABLE rooms
ALTER COLUMN price decimal(18,2);


create table customer(
cid int Identity(1,1) primary key,
cname varchar(250) not null,
mobile bigint not null,
nationality varchar(250) not null,
gender varchar(50) not null,
dob varchar(50) not null,
idproof varchar(250) not null,
email varchar(350) not null,
checkin varchar(250) not null,
checkout varchar(250),
chekout varchar(250) not null default 'NO',
roomid int not null,
foreign key (roomid) references rooms(roomid)
);

select * from customer


create table employee
(
eid int Identity(1,1) primary key,
ename varchar(250) not null,
worktime varchar(250) not null,
position varchar(250) not null,
emailid varchar(250) not null,
username varchar(150) not null,
pass varchar(150) not null
);

select * from employee

