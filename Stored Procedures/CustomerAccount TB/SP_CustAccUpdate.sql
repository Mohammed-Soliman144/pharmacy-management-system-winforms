CREATE PROC [dbo].[SP_CustAccUpdate]

@ID int,
@CustomerID int,
@CustAccBillID int,
@CustAccCustomID	Nvarchar(50),
@CustAccName	Nvarchar(50),
@CustAccDebit decimal (18,3),
@CustAccCredit decimal (18,3),
@CustAccBalance decimal (18,3),
@CustAccNotes Nvarchar(400),
@PCNameWhoModified Nvarchar(50),
@CustAccWhoModified int


AS


UPDATE CustomerAccount SET  CustAccCustomerID = @CustomerID,
							CustAccBillID = @CustAccBillID,
							CustAccCustomID = @CustAccCustomID,
							CustAccOperationName = @CustAccName,
							CustAccDebit = @CustAccDebit,
							CustAccCredit = @CustAccCredit,
							CustAccBalance = @CustAccBalance,
							CustAccNotes = @CustAccNotes,
							PCNameWhoModified = @PCNameWhoModified,
							CustAccWhoModified = @CustAccWhoModified WHERE CustAccID = @ID;
								