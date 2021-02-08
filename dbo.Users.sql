CREATE TABLE [dbo].[Users]
(
	[Id_User] INT NOT NULL  IDENTITY, 
    [User] VARCHAR(MAX) NULL, 
    [Password] VARCHAR(MAX) NULL, 
    [Icono] IMAGE NULL, 
    [Status] VARCHAR(MAX) NULL, 
    CONSTRAINT [PK_Table] PRIMARY KEY ([Id_User])
)
