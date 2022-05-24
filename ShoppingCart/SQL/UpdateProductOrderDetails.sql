Alter procedure UpdateProductOrderDetails
(
@ProductId BIGINT 
)
As
BEGIN
	Update ProductDetails
	set Ordered = Ordered+1
	where ProductId =@ProductId
END
Go

exec UpdateProductOrderDetails 1