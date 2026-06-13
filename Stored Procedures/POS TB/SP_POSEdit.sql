CREATE PROC SP_POSEdit

@ID	int,
@CustomCode Nvarchar(50),
@POSName Nvarchar(50),
@POSBalance	decimal(18,3),
@PCNameWhoAdded Nvarchar(50),
@POSWhoAdded int,
@Date Nvarchar(50),
@Time Nvarchar(50)


AS


INSERT INTO POS (POSID,POSCustomCode,POSName,POSBalance,PCNameWhoAdded,POSWhoAdded,
				POSStatus,POSDate,POSTime)
			VALUES (@ID,@CustomCode,@POSName,@POSBalance,@PCNameWhoAdded,@POSWhoAdded,1,
					@Date,@Time);