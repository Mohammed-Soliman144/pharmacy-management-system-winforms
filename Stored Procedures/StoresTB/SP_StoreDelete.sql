CREATE PROC SP_StoreDelete

@ID int


AS


DELETE FROM Stores WHERE StoreID = @ID;