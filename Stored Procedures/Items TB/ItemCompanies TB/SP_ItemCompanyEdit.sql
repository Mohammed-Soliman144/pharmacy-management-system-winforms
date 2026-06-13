CREATE PROC SP_ItemCompanyEdit

@CompanyName Nvarchar(100),
@PcNameAdded Nvarchar(50),
@CompanyWhoAdded Nvarchar(50),
@CompanyStatus bit,
@Date Nvarchar(50),
@Time Nvarchar(50)

AS

INSERT INTO ItemCompanies (CompanyName,PCNameWhoAdded,CompanyWhoAdded,CompanyStatus,CompanyDate,CompanyTime)
					VALUES (@CompanyName,@PcNameAdded,@CompanyWhoAdded,@CompanyStatus,@Date,@Time);