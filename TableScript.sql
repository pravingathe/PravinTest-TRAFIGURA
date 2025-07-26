CREATE TABLE Transactions (
    TransactionID INT IDENTITY(1,1) PRIMARY KEY,
    TradeID INT NOT NULL,
    Version INT NOT NULL,
    SecurityCode NVARCHAR(10) NOT NULL,
    Quantity INT NOT NULL,
    Action NVARCHAR(10) CHECK (Action IN ('INSERT', 'UPDATE', 'CANCEL')) NOT NULL,
    BuySell NVARCHAR(4) CHECK (BuySell IN ('Buy', 'Sell')) NOT NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
);