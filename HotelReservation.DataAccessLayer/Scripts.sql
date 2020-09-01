--Utworzenie tabel

Create Table Guests
(
	GuestId int Constraint Guests_id_pk Primary Key Identity(1, 1),
	Name nvarchar(45) not null,
	Surname nvarchar(60) not null,
	Email nvarchar(100) Unique not null,
	Phone char(11) Unique not null
);

Create Table Rooms
(
	RoomNumber int Constraint Rooms_id_pk Primary Key,
	Floor tinyint not null,
	RoomType tinyint not null,
	Area tinyint not null,
	NumberOfPlaces tinyint not null,
	PricePerNight decimal(6,2) not null
);

Create Table Reservations
(
	ReservationId int Constraint Reservations_id_pk Primary Key Identity(1, 1),
	NumberOfPeople tinyint not null,
	DateFrom date not null,
	DateTo date not null,
	GuestId int not null,
	RoomNumber int not null,
	COnstraint Reservations_GiestId_fk Foreign Key (GuestId) References Guests(GuestId),
	Constraint Reservations_RoomNumber_fk Foreign Key (RoomNumber) References Rooms(RoomNumber)
);

--Zapytanie 1 
Create Procedure First_Procedure
As
	Select Distinct R.RoomNumber, R.Floor, G.Name, G.Surname, G.Email, G.Phone,
		Count(Res.ReservationId) Over (Partition By R.RoomNumber) AS NumberOfFutureReservations
	From Rooms R
	Inner Join Reservations Res On R.RoomNumber = Res.RoomNumber
	Inner Join
		(
			Select GG.GuestId, GG.Name, GG.Surname, GG.Email, GG.Phone
			From Guests GG
			Inner Join Reservations Re On Re.GuestId = GG.GuestId 
			Where GETDATE() > Re.DateFrom AND GETDATE() < Re.DateTo
		) G On Res.GuestId = G.GuestId
	Where Res.DateFrom > GETDATE()
	Order By NumberOfFutureReservations DESC
Go

--Zapytanie 2
Create Procedure Second_Procedure
As
	Select G.Name, G.Surname, G.Email, G.Phone,
	Count(Res.ReservationId) As AllReservations,
	Avg(DateDiff(DAY, Res.DateFrom, Res.DateTo)) As AverageBookingDuration,
	(
		Select Top 1 RR.RoomNumber
		From Rooms RR
		Inner Join Reservations Ress On RR.RoomNumber = Ress.RoomNumber
		Inner Join Guests GG On GG.GuestId = Ress.GuestId
		Where GG.GuestId = G.GuestId
		Group by RR.RoomNumber
		Order By Count(Ress.ReservationId) DESC
	) AS RoomNumber
	From Guests G
	Inner Join Reservations Res On Res.GuestId = G.GuestId
	Inner Join Rooms R On Res.RoomNumber = R.RoomNumber
	Group By G.GuestId, G.Name, G.Surname, G.Email, G.Phone
Go