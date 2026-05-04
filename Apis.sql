use PUNTOVENTAUH
go
--catalogo de usuarios


create table [Productos](
codigoBarra varchar(108) not null primary key,
Descripcion varchar(300) not null,
PrecioCompra decimal(12,2) not null,
Impuesto decimal (12,2) not null,
PrecioVenta decimal (12,2) not null,
FechaRegistro datetime not null default getdate(),
Estado char not null default 'A')

INSERT INTO Productos (codigoBarra, Descripcion, PrecioCompra, Impuesto, PrecioVenta)
VALUES ('12345678', 'Producto A', 100.50, 18.00, 118.50);

INSERT INTO Productos (codigoBarra, Descripcion, PrecioCompra, Impuesto, PrecioVenta)
VALUES ('98765432', 'Producto B', 200.75, 36.00, 236.75);

INSERT INTO Productos (codigoBarra, Descripcion, PrecioCompra, Impuesto, PrecioVenta)
VALUES ('11223344', 'Producto C', 150.30, 27.00, 177.30);


create table [Clientes](
cedula varchar(80) not null primary key,
NombreCompleto varchar(180) not null,
FechaNacimiento datetime not null,
LimiteCredito decimal (12,2) not null,
Direccion varchar(250) not null,
Telefono int not null,
FechaRegistro datetime not null default getdate(),
Estado char not null default 'A')
go

INSERT INTO Clientes (cedula, NombreCompleto, FechaNacimiento, LimiteCredito, Direccion, Telefono)
VALUES ('1234567890', 'Juan Pérez', '1990-05-15', 5000.00, 'Calle 123, Ciudad A', 123456789);

INSERT INTO Clientes (cedula, NombreCompleto, FechaNacimiento, LimiteCredito, Direccion, Telefono)
VALUES ('2987654321', 'María López', '1985-10-20', 7000.00, 'Avenida 456, Ciudad B', 987654321);

INSERT INTO Clientes (cedula, NombreCompleto, FechaNacimiento, LimiteCredito, Direccion, Telefono)
VALUES ('1122334455', 'Carlos García', '1978-03-25', 3000.00, 'Boulevard 789, Ciudad C', 112233445);
