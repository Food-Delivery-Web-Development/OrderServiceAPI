CREATE TABLE Customer (
    Id UUID PRIMARY KEY,
    FullName VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    AddressId UUID NOT NULL,
    CreatedAt TIMESTAMP NOT NULL
);

CREATE TABLE Address (
    Id UUID PRIMARY KEY,
    Street VARCHAR(255) NOT NULL,
    City VARCHAR(100) NOT NULL,
    Country VARCHAR(100) NOT NULL
);

CREATE TABLE Product (
    Id UUID PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Description TEXT,
    Price DECIMAL(10, 2) NOT NULL,
    Category VARCHAR(100)
);

CREATE TABLE Order (
    Id UUID PRIMARY KEY,
    CustomerId UUID NOT NULL,
    Status VARCHAR(50) NOT NULL,
    OrderDate TIMESTAMP NOT NULL,
    TotalAmount DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (CustomerId) REFERENCES Customer(Id),
);

CREATE TABLE OrderItem (
    Id UUID PRIMARY KEY,
    OrderId UUID NOT NULL,
    ProductId UUID NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (OrderId) REFERENCES Order(Id),
    FOREIGN KEY (ProductId) REFERENCES Product(Id)
);