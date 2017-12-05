use SportsStore
drop table Orders
CREATE TABLE [dbo].[Orders] (
    [OrderID]     INT             IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (100)  NOT NULL,
    [Line1]	    NVARCHAR (200)  NOT NULL,
    [Line2]	    NVARCHAR (200)  NULL,
    [Line3]	    NVARCHAR (200)  NULL,
    [City]          NVARCHAR (100)   NOT NULL,
    [State]         NVARCHAR (50)   NOT NULL,
    [Zip]           NVARCHAR (10)   NOT NULL,
    [Country]        NVARCHAR (50)   NOT NULL,
    [Giftwrap]      INT,
	[Shipped]	    INT,
    PRIMARY KEY CLUSTERED ([OrderID] ASC)
);

Create Table CartLine(
	[CartLineID]     INT             IDENTITY (1, 1) NOT NULL,
	[OrderId] INT NOT NULL,
	[ProductId] INT NOT NULL,
	[Quantity] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([CartLineID] ASC),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
);