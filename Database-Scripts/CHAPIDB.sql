create database CHAPIDB
go

use CHAPIDB
go

create table Payload
(
	ObjectID int identity
		constraint PK_ObjetoJson
			primary key,
	startDateTime datetime2 not null,
	endDateTime datetime2 not null,
	alt int not null,
	hdop decimal(18,2) not null,
	info varchar(max),
	lat decimal(12,5) not null,
	lon decimal(12,5) not null,
	deviceName varchar(200),
	--new
	devEUI varchar(200),
	devAddr varchar(200),
	applicationID varchar(200),
	applicationName varchar(200)
)
go

create table ChevacaPackets
(
	PacketID int identity
		constraint PK_ChevacaPackets
			primary key,
	applicationID varchar(200),
	applicationName varchar(200),
	deviceName varchar(200),
	devEUI varchar(max),
	adr bit not null,
	dr int not null,
	fCnt int not null,
	fPort int not null,
	data varchar(max),
	paylodID int,
	confirmedUplink bit not null,
	devAddr varchar(200)
)
go

