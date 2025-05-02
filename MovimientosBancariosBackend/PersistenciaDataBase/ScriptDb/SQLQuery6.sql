create database MovimientosCuentaBPO
use MovimientosCuentaBPO

CREATE TABLE Cuenta (
    IdCuenta INT PRIMARY KEY IDENTITY,
    NumeroCuenta VARCHAR(20) UNIQUE NOT NULL,
    NombreTitular VARCHAR(100) NOT NULL,
    Saldo DECIMAL(18, 2) NOT NULL DEFAULT 0.00,
    EstadoCuenta VARCHAR(20) NOT NULL DEFAULT 'Activa', -- Activa, Cancelada
    FechaCreacion DATETIME NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Transaccion (
    IdTransaccion INT PRIMARY KEY IDENTITY,
    IdCuentaOrigen INT NOT NULL,
    IdCuentaDestino INT NOT NULL,
    Monto DECIMAL(18, 2) NOT NULL,
    Fecha DATETIME NOT NULL DEFAULT GETDATE(),
    TipoTransaccion VARCHAR(20) NOT NULL, -- Envio, Reverso
    Estado VARCHAR(20) NOT NULL DEFAULT 'Exitosa', -- Exitosa, Reversada
    FOREIGN KEY (IdCuentaOrigen) REFERENCES Cuenta(IdCuenta),
    FOREIGN KEY (IdCuentaDestino) REFERENCES Cuenta(IdCuenta)
);

CREATE TABLE Movimiento (
    IdMovimiento INT PRIMARY KEY IDENTITY,
    IdCuenta INT NOT NULL,
    IdTransaccion INT NOT NULL,
    TipoMovimiento VARCHAR(10) NOT NULL, -- Entrada, Salida
    Monto DECIMAL(18, 2) NOT NULL,
    Fecha DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (IdCuenta) REFERENCES Cuenta(IdCuenta),
    FOREIGN KEY (IdTransaccion) REFERENCES Transaccion(IdTransaccion)
);