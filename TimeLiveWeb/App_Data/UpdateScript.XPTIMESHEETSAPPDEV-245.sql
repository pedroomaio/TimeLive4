Create table PaymentStatus(
 Id int primary key identity(0,1),
 State nvarchar(40) 
)

Insert into PaymentStatus values
('Not paid') , ('Ready to pay') , ('Paid')

Alter table AccountExpenseEntry
Add PaymentStatusId int REFERENCES PaymentStatus(Id) DEFAULT 0 NOT NULL
Alter table AccountEmployeeExpenseSheet
Add PaymentStatusId int REFERENCES PaymentStatus(Id) DEFAULT 0 NOT NULL
