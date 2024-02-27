﻿If Not Exists (Select 1 From tb_teste (Nolock) Where Nome = 'vinicius') 
Begin
	
	INSERT INTO tb_teste VALUES (1,'vinicius');
End
GO