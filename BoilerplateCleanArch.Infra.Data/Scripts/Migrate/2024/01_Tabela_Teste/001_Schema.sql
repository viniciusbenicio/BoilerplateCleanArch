IF Object_Id('tb_teste') IS NULL 
BEGIN
  CREATE TABLE tb_teste
  (
   Id INT PRIMARY KEY,
   Nome VARCHAR(30)
  );
END