create DATABASE Assess1DB
use Assess1DB
create table Sales_Raw(orderID int,
					   OrderDate VARCHAR(20),
					   CustomerName VARCHAR(100), --customer name is repeating
					   CustomerPhone VARCHAR(20),--as customer is repeating their phone number is also repeating
					   CustomerCity VARCHAR(50),--city is also repeating
					   ProductNames VARCHAR(200),   
					   Quantities VARCHAR(100),     
					   UnitPrices VARCHAR(100),     
					   SalesPerson VARCHAR(100)); --sales person also repeating

INSERT INTO Sales_Raw VALUES(101, '2024-01-05', 'Ravi Kumar', '9876543210', 'Chennai','Laptop,Mouse', '1,2', '55000,500', 'Anitha'),
							(102, '2024-01-06', 'Priya Sharma', '9123456789', 'Bangalore','Keyboard,Mouse', '1,1', '1500,500', 'Anitha'),
							(103, '2024-01-10', 'Ravi Kumar', '9876543210', 'Chennai','Laptop', '1', '54000', 'Suresh'),
							(104, '2024-02-01', 'John Peter', '9988776655', 'Hyderabad','Monitor,Mouse', '1,1', '12000,500', 'Anitha'),
							(105, '2024-02-10', 'Priya Sharma', '9123456789', 'Bangalore','Laptop,Keyboard', '1,1', '56000,1500', 'Suresh');

select * from Sales_Raw

create table Customer(CustomerID int identity primary key,
					  CustomerName varchar(100),
					  CustomerPhone varchar(20),
					  CustomerCity varchar(50));

select * from Customer

create table SalesPerson(SalesPersonID INT identity primary key,
						 SalesPerson varchar(50));

select * from  SalesPerson

create table TableProductNames(ProdID int identity primary key,
						  ProductNames varchar(200),
						  Unit int);

select * from TableProductNames

create table OrderTable(OrderID INT,
				  OrderDate date,
				  CustomerID int,
				  SalesPersonID int,
				  foreign key (CustomerID) REFERENCES Customer(CustomerID),
				  foreign key (SalesPersonID) REFERENCES SalesPerson(SalesPersonID)
				  );

select * from OrderTable

----------------------------- 3rd question ----------------------------

select 
    sp.SalesPerson,
    SUM(tp.Unit) AS TotalSales
from OrderTable o
join SalesPerson sp
    on o.SalesPersonID = sp.SalesPersonID
join TableProductNames tp
    on 1 = 1
GROUP BY sp.SalesPerson
HAVING SUM(tp.Unit) > 60000;



----------------------------- 5th question -----------------------------
Select UPPER(c.CustomerName) as CustomerName,
		DATENAME(Month, o.OrderDate) as OrderMonth,
		o.OrderDate
		from OrderTable o
		join Customer c
		on o.CustomerID = c.CustomerID
		where 
		MONTH(o.OrderDate) = 1
		AND YEAR(o.OrderDate) = 2026;