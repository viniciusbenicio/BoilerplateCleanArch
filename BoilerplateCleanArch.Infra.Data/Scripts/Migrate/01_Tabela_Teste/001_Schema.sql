﻿If Object_Id('tb_teste') Is Null 
BEGIN
  CREATE TABLE tb_teste
  (
   Id INT  PRIMARY KEY,
   Nome VARCHAR(30)
  )
END