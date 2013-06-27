create database Chat

use Chat

create table tbCreateAccount
(
loginName varchar(100) primary key,
firstName varchar(100) Not Null,
lastName varchar(100)Not Null,
passwd varchar(100)Not Null,
gender varchar(10)Not Null,
type varchar(20)Not Null,
)

insert into tbCreateAccount values('admin','Admin','Admin','111','Male','Administrator')


create table tbAddContact
(
loginName varchar(100) primary key Foreign Key references tbCreateAccount(loginName)
)

create table tbContactList
(
loginName varchar(100) primary key Foreign Key references tbCreateAccount(loginName),
userStatus varchar(10)Not Null
)


create table tbOfflineUsersMessage
(
ToLoginName varchar(100) foreign key references tbCreateAccount(loginName),
FromLoginName varchar(100) foreign key references tbCreateAccount(loginName),
Message varchar(1000)
)

create table tbOnlineUsersMessage
(
ToLoginName varchar(100) foreign key references tbCreateAccount(loginName),
FromLoginName varchar(100) foreign key references tbCreateAccount(loginName),
Message varchar(1000)
)

create table tbContactListChanged
(
status varchar(10)
)

CREATE TRIGGER trgForContactListChanged 
ON tbContactList
FOR INSERT,UPDATE,DELETE
AS
BEGIN
insert into tbContactListChanged values('true')
END





