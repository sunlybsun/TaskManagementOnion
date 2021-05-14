create table dbo.Quote(
QuoteID int primary key not null,
QuoteType nvarchar(50) not null,
Contact nvarchar(50),
Task nvarchar(50),
DueDate datetime,
TaskType nvarchar(50)
)

insert dbo.Quote values(100,'DYR','lyb','quote-id due date','20200513 11:25 AM','Follow')
insert dbo.Quote values(102,'DYR','lyb','quote-id due date','20200513 11:25 AM','Follow')
