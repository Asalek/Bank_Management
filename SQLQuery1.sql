create database BANK
use BANK

--create table Login1(UserName nvarchar(20) primary key,Password1 nvarchar(30))

--create table client_info(account_Num int primary key identity(9000011,7),
--fullName nvarchar(max),
--email nvarchar(max),
--phone numeric(13,0),
--countryNegative nvarchar(5),
--card_type nvarchar(max) check (card_type in ('Visa','MasterCard')),
--gender nvarchar(10) check(gender in ('Male','Female')),
--Nationality nvarchar(20),
--dateOfBirth datetime,
--sold float,
--picture image)

--create table Transiction_history(id int primary key identity (1,1),withdraw_amount float,
--withdraw_Time dateTime,sender int references client_info(account_Num),
--receiver int references client_info(account_Num),transfer_Time dateTime)



insert into client_info values('asalerg','efer.afe@frf.cmo',0666492005,'+212','MASTCARD')