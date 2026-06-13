CREATE PROC SP_UserInActivate

@ID int,
@Status bit,
@PCDeleted nvarchar(50),
@UserDeleted int


AS


UPDATE USERS SET UserStatus = @Status,
				 PCNameWhoDeleted = @PCDeleted,
				 UserWhoDeleted = @UserDeleted  Where UserID = @ID;