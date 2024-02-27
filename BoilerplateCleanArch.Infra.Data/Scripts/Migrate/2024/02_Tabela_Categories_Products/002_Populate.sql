IF NOT EXISTS (SELECT 1 FROM Categories WITH (NOLOCK) WHERE [Name] = 'teste')
BEGIN
    INSERT INTO Categories VALUES ('teste');
END
GO