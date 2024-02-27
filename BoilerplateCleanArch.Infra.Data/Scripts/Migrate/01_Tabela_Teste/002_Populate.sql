IF NOT EXISTS (SELECT 1 FROM tb_teste WITH (NOLOCK) WHERE Nome = 'vinicius')
BEGIN
    INSERT INTO tb_teste VALUES (1, 'vinicius');
END
GO