create database PPPK_Projekt
go

use PPPK_Projekt
go

create table Grad
(
IDGrad int primary key identity,
Naziv nvarchar(50) not null
)

create table Vozac
(
	IDVozac int primary key identity,
	Ime nvarchar(50) not null,
	Prezime nvarchar(50) not null,
	BrojMobitela nvarchar(50) not null,
	BrojVozacke nvarchar(50) not null
)
go

create table Vozila
(
	IDVozila int primary key identity,
	Tip nvarchar(50) not null,
	Marka nvarchar(50) not null,
	Godina Date not null,
	PocetniKilometri int not null
)
go

create table PutniNalog
(
	IDPutniNalog int primary key identity,
	VozacID int foreign key references Vozac(IDVozac),
	VoziloID int foreign key references Vozila(IDVozila),
	Pocetni_Grad int foreign key references Grad(IDGrad),
	Zavrsni_Grad int foreign key references Grad(IDGrad),
	Status int not null
)
go

insert into Grad(Naziv)
values('Zagreb')
insert into Grad(Naziv)
values('Beograd')
insert into Grad(Naziv)
values('Tirana')
insert into Grad(Naziv)
values('Stockholm')
insert into Grad(Naziv)
values('Oslo')
insert into Grad(Naziv)
values('Helsinki')
insert into Grad(Naziv)
values('Paris')
insert into Grad(Naziv)
values('Lisabon')
insert into Grad(Naziv)
values('London')
insert into Grad(Naziv)
values('Frankfurt')
insert into Grad(Naziv)
values('Skopje')
insert into Grad(Naziv)
values('Osijek')
insert into Grad(Naziv)
values('Rijeka')
insert into Grad(Naziv)
values('Manchester')
insert into Grad(Naziv)
values('Hannover')
insert into Grad(Naziv)
values('Ljubljana')
insert into Grad(Naziv)
values('Sarajevo')
insert into Grad(Naziv)
values('Vukovar')
insert into Grad(Naziv)
values('Bruxelles')
insert into Grad(Naziv)
values('Amsterdam')



insert into Vozac(Ime, Prezime, BrojMobitela, BrojVozacke)
values ('James', 'Hetfield', '099987654' , 1548756)
insert into Vozac(Ime, Prezime, BrojMobitela, BrojVozacke)
values ('Corey', 'Taylor', '0977458952' , 2541879)
insert into Vozac(Ime, Prezime, BrojMobitela, BrojVozacke)
values ('Jim', 'Roots', '0915487987' , 9587458)
insert into Vozac(Ime, Prezime, BrojMobitela, BrojVozacke)
values ('Ozzy', 'Osbourne', '0988548569' , 2125468)
insert into Vozac(Ime, Prezime, BrojMobitela, BrojVozacke)
values ('Bruce', 'Dickinson', '095874589' , 8745896)
insert into Vozac(Ime, Prezime, BrojMobitela, BrojVozacke)
values ('Phil', 'Anselmo', '099854216' , 1254789)
insert into Vozac(Ime, Prezime, BrojMobitela, BrojVozacke)
values ('David', 'Draiman', '0977854859' , 3254899)
insert into Vozac(Ime, Prezime, BrojMobitela, BrojVozacke)
values ('Alice', 'Cooper', '0958745896' , 9987588)
insert into Vozac(Ime, Prezime, BrojMobitela, BrojVozacke)
values ('Rob', 'Halford', '0912548965' , 4521558)

go

insert into Vozila(Tip, Marka, Godina, PocetniKilometri)
values ('X5','BMW','2015', 10000)
insert into Vozila(Tip, Marka, Godina, PocetniKilometri)
values ('CLS','Mercedes','2012', 30000)
insert into Vozila(Tip, Marka, Godina, PocetniKilometri)
values ('Corolla','Toyota','1999', 120000)
insert into Vozila(Tip, Marka, Godina, PocetniKilometri)
values ('Punto','Fiat','1995', 180000)
insert into Vozila(Tip, Marka, Godina, PocetniKilometri)
values ('Stilo','Fiat','2001', 150000)
insert into Vozila(Tip, Marka, Godina, PocetniKilometri)
values ('X1','BMW','2018', 5000)
insert into Vozila(Tip, Marka, Godina, PocetniKilometri)
values ('Accura','Honda','2017', 20000)
insert into Vozila(Tip, Marka, Godina, PocetniKilometri)
values ('Mondeo','Ford','2005', 60000)
insert into Vozila(Tip, Marka, Godina, PocetniKilometri)
values ('Fusion','Ford','2007', 40000)
insert into Vozila(Tip, Marka, Godina, PocetniKilometri)
values ('Astra','Opel','2009', 125000)

go

Insert into PutniNalog (VozacID, VoziloID, Pocetni_Grad, Zavrsni_Grad, Status)
values (1,3,1,6, 1)
Insert into PutniNalog (VozacID, VoziloID, Pocetni_Grad, Zavrsni_Grad, Status)
values (3,1,3,5, 3)
Insert into PutniNalog (VozacID, VoziloID, Pocetni_Grad, Zavrsni_Grad, Status)
values (5,4,7,12, 2)
Insert into PutniNalog (VozacID, VoziloID, Pocetni_Grad, Zavrsni_Grad, Status)
values (2,6,8,14, 2)
Insert into PutniNalog (VozacID, VoziloID, Pocetni_Grad, Zavrsni_Grad, Status)
values (6,3,16,9, 3)
Insert into PutniNalog (VozacID, VoziloID, Pocetni_Grad, Zavrsni_Grad, Status)
values (4,5,2,19, 1)
Insert into PutniNalog (VozacID, VoziloID, Pocetni_Grad, Zavrsni_Grad, Status)
values (1,2,18,17, 2)
Insert into PutniNalog (VozacID, VoziloID, Pocetni_Grad, Zavrsni_Grad, Status)
values (7,1,16,15, 1)

go

create proc dohvatiVozila
as
select * from Vozila

go

create proc dodajVozilo
@marka nvarchar(50),
@tip nvarchar(50),
@godina date,
@pocetnikilometri int
as
insert into Vozila(Tip, Marka, Godina, PocetniKilometri)
values(@tip, @marka, @godina ,@pocetnikilometri)

go

create proc urediVozilo
@id int,
@marka nvarchar(50),
@tip nvarchar(50),
@godina date,
@pocetnikilometri int
as
begin
update Vozila
set Tip = @tip, Marka = @marka, Godina = @godina ,PocetniKilometri = @pocetnikilometri
where IDVozila = @id
end

go

create proc obrisiVozilo
@id int
as
delete from Vozila
where IDVozila = @id

go


create proc dohvatiPutneNaloge
as
select * from PutniNalog

go

create proc dodajPutniNalog
@vozacID int,
@voziloID int,
@pocetniGrad int,
@zavrsniGrad int,
@status int
as
insert into PutniNalog(VozacID, VoziloID, Pocetni_Grad, Zavrsni_Grad, Status)
values(@vozacID, @voziloID, @pocetniGrad ,@zavrsniGrad, @status)

go

create proc urediPutniNalog
@id int,
@vozacID int,
@voziloID int,
@pocetniGrad int,
@zavrsniGrad int,
@status int
as
begin
update PutniNalog
set VozacID = @vozacID, VoziloID = @voziloID, Pocetni_Grad = @pocetniGrad ,Zavrsni_Grad = @zavrsniGrad ,Status = @status
where IDPutniNalog = @id
end

go

create proc obrisiPutniNalog
@id int
as
delete from PutniNalog
where IDPutniNalog = @id

go

create proc dohvatiGradove
as
select * from Grad

go

Truncate table PutniNalog
go
Truncate table Grad
go
Truncate table Vozila
go
Truncate table Vozac
go
