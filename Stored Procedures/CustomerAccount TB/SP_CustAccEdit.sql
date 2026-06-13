CREATE PROC [dbo].[SP_CustAccEdit]

@ID int,
@CustomerID int,
@CustAccBillID int,
@CustAccCustomID	Nvarchar(50),
@CustAccName	Nvarchar(50),
@CustAccDebit decimal (18,3),
@CustAccCredit decimal (18,3),
@CustAccBalance decimal (18,3),
@CustAccNotes Nvarchar(400),
@PCNameWhoAdded Nvarchar(50),
@CustAccWhoAdded int,
@Date Nvarchar(50),
@Time Nvarchar(50)

AS

INSERT INTO CustomerAccount (CustAccID,CustAccCustomerID,CustAccBillID,CustAccCustomID,CustAccOperationName,CustAccDebit,CustAccCredit,
							 CustAccBalance,CustAccNotes,PCNameWhoAdded,CustAccWhoAdded,CustAccStatus,CustAccDate,CustAccTime)

					VALUES (@ID,@CustomerID,@CustAccBillID,@CustAccCustomID,@CustAccName,@CustAccDebit,@CustAccCredit,@CustAccBalance,@CustAccNotes,
							@PCNameWhoAdded,@CustAccWhoAdded,1,@Date,@Time);