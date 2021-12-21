USE [aviv_eleicao]
GO
ALTER TABLE [dbo].[tb_voto] DROP CONSTRAINT [FK_tb_voto_tb_eleicao_cargo]
GO
ALTER TABLE [dbo].[tb_voto] DROP CONSTRAINT [FK_tb_voto_tb_eleicao]
GO
ALTER TABLE [dbo].[tb_eleicao_cargo_candidato] DROP CONSTRAINT [FK_tb_eleicao_cargo_candidato_tb_status]
GO
ALTER TABLE [dbo].[tb_eleicao_cargo_candidato] DROP CONSTRAINT [FK_tb_eleicao_cargo_candidato_tb_eleicao_cargo]
GO
ALTER TABLE [dbo].[tb_eleicao_cargo_candidato] DROP CONSTRAINT [FK_tb_eleicao_cargo_candidato_tb_candidato]
GO
ALTER TABLE [dbo].[tb_eleicao_cargo] DROP CONSTRAINT [FK_tb_eleicao_cargo_tb_eleicao]
GO
/****** Object:  Table [dbo].[tb_voto]    Script Date: 27/12/2012 00:40:27 ******/
DROP TABLE [dbo].[tb_voto]
GO
/****** Object:  Table [dbo].[tb_status]    Script Date: 27/12/2012 00:40:27 ******/
DROP TABLE [dbo].[tb_status]
GO
/****** Object:  Table [dbo].[tb_eleicao_cargo_candidato]    Script Date: 27/12/2012 00:40:27 ******/
DROP TABLE [dbo].[tb_eleicao_cargo_candidato]
GO
/****** Object:  Table [dbo].[tb_eleicao_cargo]    Script Date: 27/12/2012 00:40:27 ******/
DROP TABLE [dbo].[tb_eleicao_cargo]
GO
/****** Object:  Table [dbo].[tb_eleicao]    Script Date: 27/12/2012 00:40:27 ******/
DROP TABLE [dbo].[tb_eleicao]
GO
/****** Object:  Table [dbo].[tb_candidato]    Script Date: 27/12/2012 00:40:27 ******/
DROP TABLE [dbo].[tb_candidato]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_total_votos_candidatos]    Script Date: 27/12/2012 00:40:27 ******/
DROP FUNCTION [dbo].[fn_total_votos_candidatos]
GO
/****** Object:  StoredProcedure [dbo].[sp_rel_eleicao]    Script Date: 27/12/2012 00:40:27 ******/
DROP PROCEDURE [dbo].[sp_rel_eleicao]
GO
/****** Object:  StoredProcedure [dbo].[sp_gerencia_voto]    Script Date: 27/12/2012 00:40:27 ******/
DROP PROCEDURE [dbo].[sp_gerencia_voto]
GO
/****** Object:  StoredProcedure [dbo].[sp_gerencia_eleicao_cargo_candidato]    Script Date: 27/12/2012 00:40:27 ******/
DROP PROCEDURE [dbo].[sp_gerencia_eleicao_cargo_candidato]
GO
/****** Object:  StoredProcedure [dbo].[sp_gerencia_eleicao_cargo]    Script Date: 27/12/2012 00:40:27 ******/
DROP PROCEDURE [dbo].[sp_gerencia_eleicao_cargo]
GO
/****** Object:  StoredProcedure [dbo].[sp_gerencia_eleicao]    Script Date: 27/12/2012 00:40:27 ******/
DROP PROCEDURE [dbo].[sp_gerencia_eleicao]
GO
/****** Object:  StoredProcedure [dbo].[sp_gerencia_candidato]    Script Date: 27/12/2012 00:40:27 ******/
DROP PROCEDURE [dbo].[sp_gerencia_candidato]
GO
/****** Object:  StoredProcedure [dbo].[sp_gerencia_candidato]    Script Date: 27/12/2012 00:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_gerencia_candidato] 
  @str_acao	VARCHAR(3) = NULL,
  @int_id_candidato INT = NULL,
  @str_nome_candidato VARCHAR(50) = NULL,
  @str_apelido_candidato VARCHAR(50) = NULL,
  @img_foto_candidato IMAGE = NULL,
  @int_id_eleicao_cargo INT = NULL
AS
BEGIN

  IF(UPPER(@str_acao) = 'INS')
  BEGIN
    INSERT INTO tb_candidato(
	    str_nome_candidato,
		str_apelido_candidato,
		dte_data_cadastro,
		img_foto_candidato
	)
	VALUES(
	  @str_nome_candidato,
	  @str_apelido_candidato,
	  GETDATE(),
	  @img_foto_candidato
	)
	SELECT @@IDENTITY AS int_id_candidato
  END

  ELSE IF(UPPER(@str_acao) = 'UPD')
  BEGIN
    UPDATE tb_candidato
	SET str_nome_candidato = @str_nome_candidato,
		str_apelido_candidato = @str_apelido_candidato,
		img_foto_candidato = @img_foto_candidato
	WHERE
	  int_id_candidato = @int_id_candidato

	SELECT @int_id_candidato
  END

  ELSE IF(UPPER(@str_acao) = 'DEL')
  BEGIN
    DELETE FROM tb_candidato
	WHERE int_id_candidato = @int_id_candidato
  END

  -- SELECIONAR
  ELSE IF (UPPER(@str_acao) = 'SEL')
  BEGIN
    SELECT
	 c.int_id_candidato,
	 c.str_nome_candidato,
	 ISNULL(c.str_apelido_candidato,'') AS str_apelido_candidato,
	 c.img_foto_candidato,
	 CONVERT(VARCHAR(10),c.dte_data_cadastro,103) + ' ' + CONVERT(VARCHAR(10),c.dte_data_cadastro,108) AS dte_data_cadastro
	FROM
	 tb_candidato c (NOLOCK)
	WHERE
	  int_id_candidato = @int_id_candidato

  END

  -- PESQUISAR
  ELSE IF (UPPER(@str_acao) = 'PES')
  BEGIN
    SELECT
	 c.int_id_candidato,
	 c.str_nome_candidato,
	 ISNULL(c.str_apelido_candidato,'') AS str_apelido_candidato
	FROM
	 tb_candidato c (NOLOCK)
	WHERE
	  ((@str_nome_candidato IS NULL OR @str_nome_candidato = '') OR (c.str_nome_candidato LIKE '%' + @str_nome_candidato + '%'))
	  AND
	  ((@str_apelido_candidato IS NULL OR @str_apelido_candidato = '') OR (c.str_apelido_candidato LIKE '%' + @str_apelido_candidato + '%'))
	  AND
	  ((@int_id_candidato IS NULL OR @int_id_candidato = 0) OR (CONVERT(VARCHAR,c.int_id_candidato) LIKE '%' + CONVERT(VARCHAR, @int_id_candidato) + '%'))
	ORDER
	  BY c.str_nome_candidato 
  END

   -- PESQUISAR PARA INSERIR NA ELEICAO
  ELSE IF (UPPER(@str_acao) = 'P-I')
  BEGIN
    SELECT
	 c.int_id_candidato,
	 c.str_nome_candidato,
	 ISNULL(c.str_apelido_candidato,'') AS str_apelido_candidato
	FROM
	 tb_candidato c (NOLOCK)
	WHERE
	  (c.int_id_candidato NOT IN(SELECT e.int_id_candidato FROM tb_eleicao_cargo_candidato (NOLOCK) e WHERE e.int_id_eleicao_cargo = @int_id_eleicao_cargo))
	  AND
	  ((@str_nome_candidato IS NULL OR @str_nome_candidato = '') OR (c.str_nome_candidato LIKE '%' + @str_nome_candidato + '%'))
	  AND
	  ((@str_apelido_candidato IS NULL OR @str_apelido_candidato = '') OR (c.str_apelido_candidato LIKE '%' + @str_apelido_candidato + '%'))
	  AND
	  ((@int_id_candidato IS NULL OR @int_id_candidato = 0) OR (CONVERT(VARCHAR,c.int_id_candidato) LIKE '%' + CONVERT(VARCHAR, @int_id_candidato) + '%'))
	ORDER
	  BY c.str_nome_candidato 
  END



END
GO
/****** Object:  StoredProcedure [dbo].[sp_gerencia_eleicao]    Script Date: 27/12/2012 00:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_gerencia_eleicao]
  @str_acao	VARCHAR(3) = 'PES',
  @int_id_eleicao INT = NULL,
  @str_nome VARCHAR(50) = NULL,
  @int_numero_eleitores INT = NULL
AS
BEGIN
  
  DECLARE @msg NVARCHAR(4000)

  -- inserir eleição
  IF(UPPER(@str_acao) = 'INS')
  BEGIN
    INSERT INTO tb_eleicao(
		str_nome_eleicao,
		dte_data_cadastro,
		dte_data_inicio,
		dte_data_fim,
		int_numero_eleitores)
	VALUES(
	    @str_nome,
		GETDATE(),
		NULL,
		NULL,
		@int_numero_eleitores
	)
	SELECT @@IDENTITY AS int_id_eleicao
	  
  END

  ELSE IF(UPPER(@str_acao) = 'UPD')
  BEGIN
    UPDATE tb_eleicao
	SET str_nome_eleicao = @str_nome,
	    int_numero_eleitores = @int_numero_eleitores
	WHERE int_id_eleicao = @int_id_eleicao

	SELECT @int_id_eleicao AS int_id_eleicao
  END

  ELSE IF(UPPER(@str_acao) = 'DEL')
  BEGIN
    DELETE FROM tb_eleicao
	WHERE int_id_eleicao = @int_id_eleicao
  END

  -- abrir eleição
  ELSE IF(UPPER(@str_acao) = 'ABR')
  BEGIN
     DECLARE @str_eleicao_aberta VARCHAR(50) = NULL,
			 @codigo_eleicao_aberta VARCHAR(10) = NULL
	 
	 SELECT TOP 1
	   @str_eleicao_aberta = e.str_nome_eleicao,
	   @codigo_eleicao_aberta = CONVERT(VARCHAR(10),e.int_id_eleicao)
	 FROM
	  tb_eleicao e (NOLOCK)
	 WHERE
	   e.dte_data_inicio IS NOT NULL AND e.dte_data_fim IS NULL
	 
	 IF(@codigo_eleicao_aberta IS NOT NULL)
	 BEGIN
	     SET @msg =  N'Esta eleição não pode ser aberta. A eleição "' + @codigo_eleicao_aberta + '-' + @str_eleicao_aberta + '" já está aberta e não foi fechada'
	     RAISERROR(@msg,16,16);
	   	 RETURN
	 END
	 ELSE IF(@int_numero_eleitores IS NULL OR @int_numero_eleitores = 0)
	 BEGIN
	     SET @msg =  N'O número de eleitores deve ser maior do que 1'
	     RAISERROR(@msg,16,16);
	   	 RETURN
	 END
	 ELSE
	 BEGIN
	   UPDATE tb_eleicao
	   SET dte_data_inicio = GETDATE()
	   WHERE int_id_eleicao = @int_id_eleicao
	 END
  END

  -- fechar eleição
  ELSE IF(UPPER(@str_acao) = 'FEC')
  BEGIN
    IF(EXISTS(SELECT 1 FROM tb_eleicao_cargo (NOLOCK) WHERE int_id_eleicao = @int_id_eleicao AND (dte_data_inicio IS NOT NULL AND dte_data_fim IS NULL)))
	BEGIN
	  RAISERROR('Eleição não encerrada. Há uma votação de cargo aberta e precisa ser fechada.',16,16)
	  RETURN
	END
	ELSE
	BEGIN
		UPDATE tb_eleicao
		SET dte_data_fim = GETDATE()
		WHERE int_id_eleicao = @int_id_eleicao
    END
  END

  -- PESQUISAR
  ELSE IF (UPPER(@str_acao) = 'PES')
  BEGIN
    SELECT
	 e.int_id_eleicao,
	 e.str_nome_eleicao
	FROM
	 tb_eleicao e (NOLOCK)
	WHERE
	  ((@str_nome IS NULL OR @str_nome = '') OR (e.str_nome_eleicao LIKE '%' + @str_nome + '%'))
	  AND
	  ((@int_id_eleicao IS NULL OR @int_id_eleicao = 0) OR (CONVERT(VARCHAR,e.int_id_eleicao) LIKE '%' + CONVERT(VARCHAR, @int_id_eleicao) + '%'))
	ORDER
	  BY int_id_eleicao DESC
  END

  -- seleciona dados eleição
  ELSE IF(UPPER(@str_acao) = 'SEL')
  BEGIN
    SELECT
	  e.int_id_eleicao,
	  e.str_nome_eleicao,
	  ISNULL(CONVERT(VARCHAR(10), e.dte_data_cadastro, 103) + ' ' + CONVERT(VARCHAR(10), e.dte_data_cadastro, 108),'') as dte_data_cadastro,
	  ISNULL(CONVERT(VARCHAR(10), e.dte_data_inicio, 103) + ' ' + CONVERT(VARCHAR(10), e.dte_data_inicio, 108),'') as dte_data_inicio,
	  ISNULL(CONVERT(VARCHAR(10), e.dte_data_fim, 103) + ' ' + CONVERT(VARCHAR(10), e.dte_data_fim, 108),'') as dte_data_fim,
	  ISNULL((SELECT COUNT(*) FROM tb_voto v (NOLOCK) WHERE v.int_id_eleicao = @int_id_eleicao) ,0) AS int_votos,
	  ISNULL((SELECT COUNT(*) FROM tb_voto v (NOLOCK) WHERE str_tipo_voto = 'V' AND v.int_id_eleicao = @int_id_eleicao) ,0) AS int_votos_validos,
	  ISNULL((SELECT COUNT(*) FROM tb_voto v (NOLOCK) WHERE str_tipo_voto = 'B' AND v.int_id_eleicao = @int_id_eleicao) ,0) AS int_votos_brancos,
	  ISNULL((SELECT COUNT(*) FROM tb_voto v (NOLOCK) WHERE str_tipo_voto = 'N' AND v.int_id_eleicao = @int_id_eleicao) ,0) AS int_votos_nulos,
	  ISNULL(e.int_numero_eleitores,'') AS int_numero_eleitores 
	FROM
	 tb_eleicao e (NOLOCK)
	WHERE 
	  e.int_id_eleicao = @int_id_eleicao
  END

END
GO
/****** Object:  StoredProcedure [dbo].[sp_gerencia_eleicao_cargo]    Script Date: 27/12/2012 00:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_gerencia_eleicao_cargo]
  @str_acao VARCHAR(3) = NULL,
  @int_id_eleicao_cargo INT = NULL,
  @int_id_eleicao INT = NULL,
  @str_nome_cargo VARCHAR(50) = NULL,
  @int_numero_vagas INT = NULL
AS
BEGIN

  
  IF(UPPER(@str_acao) = 'INS')
  BEGIN
	  IF(EXISTS(SELECT 1 FROM tb_eleicao (NOLOCK) WHERE int_id_eleicao = @int_id_eleicao AND dte_data_inicio IS NOT NULL))
	  BEGIN
		RAISERROR(N'Cargo não inserido. A eleição já foi iniciada.', 16, 16)
		RETURN
	  END
	  ELSE
	  BEGIN
      INSERT INTO tb_eleicao_cargo(
		  int_id_eleicao,
		  str_nome_cargo,
		  int_numero_vagas,
		  dte_data_inicio,
		  dte_data_fim
	)
	VALUES(
		  @int_id_eleicao,
		  @str_nome_cargo,
		  @int_numero_vagas,
		  NULL,
		  NULL
	)
  END
  END

  ELSE IF (UPPER(@str_acao) = 'UPD')
  BEGIN
   IF(EXISTS(SELECT 1 FROM tb_eleicao (NOLOCK) WHERE int_id_eleicao = @int_id_eleicao AND dte_data_inicio IS NOT NULL))
   BEGIN
	  RAISERROR(N'Cargo não atualizado. A eleição já foi iniciada.', 16, 16)
	  RETURN
	END
    UPDATE tb_eleicao_cargo
	SET str_nome_cargo = @str_nome_cargo,
		int_numero_vagas = @int_numero_vagas
	WHERE
	  int_id_eleicao_cargo = @int_id_eleicao_cargo
  END

  ELSE IF(UPPER(@str_acao) = 'DEL')
  BEGIN
    IF(EXISTS(SELECT 1 FROM tb_eleicao (NOLOCK) WHERE int_id_eleicao = @int_id_eleicao AND dte_data_inicio IS NOT NULL))
	BEGIN
		RAISERROR(N'Cargo não excluido. A eleição já foi iniciada.', 16, 16)
		RETURN
	 END
	 ELSE
	 BEGIN
	   DELETE FROM tb_eleicao_cargo
	   WHERE int_id_eleicao_cargo = @int_id_eleicao_cargo
	 END
  END

  --iniciar
  ELSE IF(UPPER(@str_acao) = 'INI')
  BEGIN
    IF(EXISTS(SELECT 1 FROM tb_eleicao (NOLOCK) WHERE int_id_eleicao = @int_id_eleicao AND dte_data_inicio IS NULL))
	BEGIN
		RAISERROR(N'Votação para o cargo não iniciada. A eleição não foi iniciada.', 16, 16)
		RETURN
	 END
	 ELSE IF(EXISTS(SELECT 1 FROM tb_eleicao (NOLOCK) WHERE int_id_eleicao = @int_id_eleicao AND dte_data_fim IS NOT NULL))
	 BEGIN
		RAISERROR(N'Votação para o cargo não iniciada. A eleição já foi encerrada.', 16, 16)
		RETURN
	 END
	 ELSE IF(EXISTS(SELECT 1 FROM tb_eleicao_cargo (NOLOCK) WHERE int_id_eleicao = @int_id_eleicao AND (dte_data_inicio IS NOT NULL AND dte_data_fim IS NULL)))
	 BEGIN
		RAISERROR(N'Votação para o cargo não iniciada. A eleição já tem um cargo com votação aberta.', 16, 16)
		RETURN
	 END
	 ELSE IF(EXISTS(SELECT 1 FROM tb_eleicao_cargo (NOLOCK) WHERE int_id_eleicao_cargo = @int_id_eleicao_cargo AND dte_data_inicio IS NOT NULL))
	 BEGIN
		RAISERROR(N'Votação para o cargo não iniciada. A eleição para esse cargo já está aberta', 16, 16)
		RETURN
	 END
	 ELSE
	 BEGIN
	   UPDATE tb_eleicao_cargo
	   SET dte_data_inicio = GETDATE()
	   WHERE int_id_eleicao_cargo = @int_id_eleicao_cargo
	 END
  END

  -- encerrar
  ELSE IF(UPPER(@str_acao) = 'FEC')
  BEGIN
    IF(EXISTS(SELECT 1 FROM tb_eleicao (NOLOCK) WHERE int_id_eleicao = @int_id_eleicao AND dte_data_inicio IS NULL))
	BEGIN
		RAISERROR(N'Votação para o cargo não encerrada. A eleição não foi iniciada.', 16, 16)
		RETURN
	 END
	 ELSE IF(EXISTS(SELECT 1 FROM tb_eleicao (NOLOCK) WHERE int_id_eleicao = @int_id_eleicao AND dte_data_fim IS NOT NULL))
	 BEGIN
		RAISERROR(N'Votação para o cargo não foi encerrada. A eleição já foi encerrada.', 16, 16)
		RETURN
	 END
	 ELSE IF(EXISTS(SELECT 1 FROM tb_eleicao_cargo (NOLOCK) WHERE int_id_eleicao_cargo = @int_id_eleicao_cargo AND dte_data_inicio IS NULL))
	 BEGIN
		RAISERROR(N'Votação para o cargo não foi encerrada. A votação para o cargo não foi aberta', 16, 16)
		RETURN
	 END
	 ELSE IF(EXISTS(SELECT 1 FROM tb_eleicao_cargo (NOLOCK) WHERE int_id_eleicao_cargo = @int_id_eleicao_cargo AND dte_data_fim IS NOT NULL))
	 BEGIN
		RAISERROR(N'Votação para o cargo não encerrada. A eleição para esse cargo já está encerrada', 16, 16)
		RETURN
	 END
	 ELSE
	 BEGIN
	   UPDATE tb_eleicao_cargo
	   SET dte_data_fim = GETDATE()
	   WHERE int_id_eleicao_cargo = @int_id_eleicao_cargo
	 END
  END

  ELSE IF(UPPER(@str_acao) = 'SEL')
  BEGIN
    SELECT
	 c.int_id_eleicao_cargo,
	 c.str_nome_cargo,
	 c.int_numero_vagas,
	 ISNULL(CONVERT(VARCHAR(10), c.dte_data_inicio, 103) + ' ' + CONVERT(VARCHAR(10), c.dte_data_inicio, 108),'') as dte_data_inicio,
	 ISNULL(CONVERT(VARCHAR(10), c.dte_data_fim, 103) + ' ' + CONVERT(VARCHAR(10), c.dte_data_fim, 108),'') as dte_data_fim,
	 (SELECT COUNT(*) FROM tb_voto v (NOLOCK) WHERE v.int_id_eleicao_cargo = c.int_id_eleicao_cargo) as int_votos,
	 (SELECT COUNT(*) FROM tb_voto v (NOLOCK) WHERE v.int_id_eleicao_cargo = c.int_id_eleicao_cargo AND str_tipo_voto = 'V') as int_votos_validos,
	 (SELECT COUNT(*) FROM tb_voto v (NOLOCK) WHERE v.int_id_eleicao_cargo = c.int_id_eleicao_cargo AND str_tipo_voto = 'B') as int_votos_brancos,
	 (SELECT COUNT(*) FROM tb_voto v (NOLOCK) WHERE v.int_id_eleicao_cargo = c.int_id_eleicao_cargo AND str_tipo_voto = 'N') as int_votos_nulos
	FROM
	  tb_eleicao_cargo c (NOLOCK)
	WHERE
	  int_id_eleicao = @int_id_eleicao
	ORDER BY
	  c.str_nome_cargo
  END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_gerencia_eleicao_cargo_candidato]    Script Date: 27/12/2012 00:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_gerencia_eleicao_cargo_candidato]
   
   @str_acao VARCHAR(3) = NULL,
   @int_id_eleicao_cargo_candidato INT = NULL,
   @int_id_eleicao_cargo INT = NULL,
   @int_id_candidato INT = NULL

AS
BEGIN

   -- insert
  IF(UPPER(@str_acao) = 'INS')
  BEGIN
    IF(NOT EXISTS(SELECT 1 FROM tb_eleicao_cargo_candidato WHERE int_id_eleicao_cargo = @int_id_eleicao_cargo AND int_id_candidato = @int_id_candidato))
	BEGIN
	   INSERT INTO tb_eleicao_cargo_candidato(	
	     int_id_eleicao_cargo,
		 int_id_candidato,
		 str_status
	   )
	   VALUES(
	     @int_id_eleicao_cargo,
		 @int_id_candidato,
		 'D'
	   )
	   SELECT @@IDENTITY
	END
  END

  ELSE IF(UPPER(@str_acao) = 'SEL')
  BEGIN
    SELECT
	  cargo.int_id_eleicao_cargo_candidato,
	  cargo.int_id_candidato,
	  can.str_nome_candidato,
	  s.str_nome_status,
	  dbo.fn_total_votos_candidatos(cargo.int_id_candidato, cargo.int_id_eleicao_cargo) AS int_votos
	FROM
	 tb_eleicao_cargo_candidato cargo (NOLOCK)
	 INNER JOIN tb_candidato can (NOLOCK) ON can.int_id_candidato = cargo.int_id_candidato
	 INNER JOIN tb_status s (NOLOCK) ON s.str_status = cargo.str_status
	WHERE
	  int_id_eleicao_cargo = @int_id_eleicao_cargo
	ORDER BY 
	  int_votos DESC,
	  can.str_nome_candidato
  END

  ELSE IF(UPPER(@str_acao) = 'DEL')
  BEGIN
    DELETE FROM tb_eleicao_cargo_candidato
	WHERE int_id_eleicao_cargo_candidato = @int_id_eleicao_cargo_candidato
  END

   -- eleger
  ELSE IF(UPPER(@str_acao) = 'ELE')
  DECLARE @int_id_eleicao INT = (SELECT int_id_eleicao FROM tb_eleicao_cargo (NOLOCK) WHERE int_id_eleicao_cargo = @int_id_eleicao_cargo)
  BEGIN
    IF(EXISTS(SELECT 1 FROM tb_eleicao_cargo (NOLOCK) WHERE int_id_eleicao_cargo = @int_id_eleicao_cargo AND dte_data_inicio IS NULL))
	BEGIN
	  RAISERROR('Votação do cargo não foi aberta',16,16)
	  RETURN
	END
	ELSE IF(EXISTS(SELECT 1 FROM tb_eleicao_cargo (NOLOCK) WHERE int_id_eleicao_cargo = @int_id_eleicao_cargo AND dte_data_fim IS NULL))
	BEGIN
	  RAISERROR('Votação do cargo não foi fechada',16,16)
	  RETURN
	END
	ELSE IF
	(
	  (SELECT COUNT(*) FROM tb_eleicao_cargo_candidato WHERE int_id_eleicao_cargo = @int_id_eleicao_cargo AND str_status = 'E')
	  >=
	  (SELECT int_numero_vagas FROM tb_eleicao_cargo WHERE int_id_eleicao_cargo = @int_id_eleicao_cargo)
	)
	BEGIN
	  RAISERROR('O número de candidatos eleitos para esse cargo já foi atingindo',16,16)
	  RETURN
	END
	ELSE IF(EXISTS(
	  SELECT 1
	  FROM
	    tb_eleicao_cargo_candidato (NOLOCK) can
		INNER JOIN tb_eleicao_cargo (NOLOCK) car ON CAR.int_id_eleicao_cargo = can.int_id_eleicao_cargo
	  WHERE
	    can.str_status = 'E' AND car.int_id_eleicao = @int_id_eleicao and int_id_candidato = @int_id_candidato
	))
	BEGIN
	  RAISERROR('Candidato já eleito nessa eleição',16,16)
	  RETURN
	END

	ELSE
	BEGIN
	  UPDATE tb_eleicao_cargo_candidato
	  SET str_status = 'E'
	  WHERE int_id_eleicao_cargo = @int_id_eleicao_cargo AND int_id_candidato = @int_id_candidato

	  UPDATE tb_eleicao_cargo_candidato
	  SET str_status = 'O'
	  WHERE 
	    int_id_candidato = @int_id_candidato 
		AND
		str_status <> 'E'
		AND
		int_id_eleicao_cargo IN(SELECT int_id_eleicao_cargo FROM tb_eleicao_cargo (NOLOCK) WHERE int_id_eleicao = @int_id_eleicao)
	       

	END

  END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_gerencia_voto]    Script Date: 27/12/2012 00:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_gerencia_voto]
  @str_acao VARCHAR(3) = NULL,
  @int_id_eleicao INT = NULL,
  @int_id_eleicao_cargo INT = NULL,
  @int_numero_candidato INT = NULL,
  @str_tipo_voto CHAR(1) = NULLL
AS
BEGIN
   -- selecionar informação sobre eleição
  IF(UPPER(@str_acao) = 'INF')
  BEGIN
    SELECT
	  car.int_id_eleicao_cargo,
	  car.int_id_eleicao,
	  car.str_nome_cargo,
	  ele.str_nome_eleicao
	FROM
	  tb_eleicao_cargo car (NOLOCK)
	  INNER JOIN tb_eleicao ele (NOLOCK) on ele.int_id_eleicao = car.int_id_eleicao
     WHERE
	   (car.dte_data_inicio IS NOT NULL AND car.dte_data_fim IS NULL)
	   AND
	   (ele.dte_data_inicio IS NOT NULL AND ele.dte_data_fim IS NULL)
  END

   -- pesquisa candidato
  ELSE IF(UPPER(@str_acao) = 'PES')
  BEGIN
    SELECT
	  c.str_nome_candidato,
	  ISNULL(c.str_apelido_candidato,'') AS str_apelido_candidato,
	  c.img_foto_candidato
	FROM 
	 tb_eleicao_cargo_candidato cc (NOLOCK)
	 INNER JOIN tb_candidato c (NOLOCK) ON c.int_id_candidato = cc.int_id_candidato
	WHERE
	  cc.int_id_candidato = @int_numero_candidato 
	  AND
	  cc.int_id_eleicao_cargo = @int_id_eleicao_cargo
	  AND
	  cc.str_status = 'D' -- disponivel
  END

  ELSE IF(UPPER(@str_acao) = 'INS')
  BEGIN
    
	IF(EXISTS(
	   SELECT 1
	   FROM
	     tb_eleicao_cargo c (NOLOCK)
		 INNER JOIN tb_eleicao e (NOLOCK) ON e.int_id_eleicao = c.int_id_eleicao
	   WHERE
		  c.int_id_eleicao_cargo = @int_id_eleicao_cargo
		  AND
		 (
	       (c.dte_data_inicio IS NULL OR c.dte_data_fim IS NOT NULL)
		 OR
		   (e.dte_data_inicio IS NULL OR e.dte_data_fim IS NOT NULL)
		 )
	 ))
	 BEGIN
	   RAISERROR('Voto não computado. Eleição ou votação para o cargo fechada',16,16)
	   RETURN
	 END

	 IF(
	    (SELECT COUNT(*) FROM tb_voto (NOLOCK) WHERE int_id_eleicao = @int_id_eleicao AND int_id_eleicao_cargo = @int_id_eleicao_cargo)
	    =	
		(SELECT int_numero_eleitores FROM tb_eleicao (NOLOCK) where int_id_eleicao = @int_id_eleicao)
	   )
	 BEGIN
	   RAISERROR('Voto não computado. Limite de votos atingido',16,16)
	   RETURN
	 END

    INSERT INTO tb_voto(
	  int_id_eleicao,
	  int_id_eleicao_cargo,
	  int_numero_candidato,
	  dte_data_voto,
	  str_tipo_voto)
	VALUES(
	  @int_id_eleicao,
	  @int_id_eleicao_cargo,
	  @int_numero_candidato,
	  GETDATE(),
	  @str_tipo_voto
	)

	 IF(
	    (SELECT COUNT(*) FROM tb_voto (NOLOCK) WHERE int_id_eleicao = @int_id_eleicao AND int_id_eleicao_cargo = @int_id_eleicao_cargo)
	    =	
		(SELECT int_numero_eleitores FROM tb_eleicao (NOLOCK) where int_id_eleicao = @int_id_eleicao)
	   )
	 BEGIN
	   UPDATE tb_eleicao_cargo
	   SET dte_data_fim = GETDATE()
	   WHERE int_id_eleicao_cargo = @int_id_eleicao_cargo
	 END

  END

END
GO
/****** Object:  StoredProcedure [dbo].[sp_rel_eleicao]    Script Date: 27/12/2012 00:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_rel_eleicao]
  @str_acao VARCHAR(3) = NULL,
  @int_id_eleicao INT = 5
AS
BEGIN

  SELECT
	  e.int_id_eleicao,
	  e.str_nome_eleicao,
	  ISNULL(CONVERT(VARCHAR(10), e.dte_data_cadastro, 103) + ' ' + CONVERT(VARCHAR(10), e.dte_data_cadastro, 108),'') as dte_data_cadastro,
	  ISNULL(CONVERT(VARCHAR(10), e.dte_data_inicio, 103) + ' ' + CONVERT(VARCHAR(10), e.dte_data_inicio, 108),'') as dte_data_inicio,
	  ISNULL(CONVERT(VARCHAR(10), e.dte_data_fim, 103) + ' ' + CONVERT(VARCHAR(10), e.dte_data_fim, 108),'') as dte_data_fim,
	  ISNULL((SELECT COUNT(*) FROM tb_voto v (NOLOCK) WHERE v.int_id_eleicao = @int_id_eleicao) ,0) AS int_votos,
	  ISNULL((SELECT COUNT(*) FROM tb_voto v (NOLOCK) WHERE str_tipo_voto = 'V' AND v.int_id_eleicao = @int_id_eleicao) ,0) AS int_votos_validos,
	  ISNULL((SELECT COUNT(*) FROM tb_voto v (NOLOCK) WHERE str_tipo_voto = 'B' AND v.int_id_eleicao = @int_id_eleicao) ,0) AS int_votos_brancos,
	  ISNULL((SELECT COUNT(*) FROM tb_voto v (NOLOCK) WHERE str_tipo_voto = 'N' AND v.int_id_eleicao = @int_id_eleicao) ,0) AS int_votos_nulos
	FROM
	 tb_eleicao e (NOLOCK)
	WHERE
	  int_id_eleicao = @int_id_eleicao


   SELECT
	 c.int_id_eleicao_cargo,
	 c.str_nome_cargo,
	 c.int_numero_vagas,
	 ISNULL(CONVERT(VARCHAR(10), c.dte_data_inicio, 103) + ' ' + CONVERT(VARCHAR(10), c.dte_data_inicio, 108),'') as dte_data_inicio,
	 ISNULL(CONVERT(VARCHAR(10), c.dte_data_fim, 103) + ' ' + CONVERT(VARCHAR(10), c.dte_data_fim, 108),'') as dte_data_fim
	FROM
	  tb_eleicao_cargo c (NOLOCK)
	WHERE
	  int_id_eleicao = @int_id_eleicao
	ORDER BY
	  c.str_nome_cargo

	SELECT
	  cargo.int_id_eleicao_cargo_candidato,
	  cargo.int_id_eleicao_cargo,
	  cargo.int_id_candidato,
	  can.str_nome_candidato,
	  s.str_nome_status,
	  dbo.fn_total_votos_candidatos(cargo.int_id_candidato, cargo.int_id_eleicao_cargo) AS int_votos
	FROM
	 tb_eleicao_cargo_candidato cargo (NOLOCK)
	 INNER JOIN tb_eleicao_cargo car (NOLOCK) ON car.int_id_eleicao_cargo = cargo.int_id_eleicao_cargo
	 INNER JOIN tb_candidato can (NOLOCK) ON can.int_id_candidato = cargo.int_id_candidato
	 INNER JOIN tb_status s (NOLOCK) ON s.str_status = cargo.str_status
	WHERE
	  car.int_id_eleicao = @int_id_eleicao
	ORDER BY 
	  int_votos DESC,
	  can.str_nome_candidato

END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_total_votos_candidatos]    Script Date: 27/12/2012 00:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_total_votos_candidatos]
(
  @int_id_candidato INT,
  @int_id_eleicao_cargo INT
)
RETURNS INT

AS
BEGIN

  DECLARE @int_votos INT = 0

  IF((SELECT dte_data_fim FROM tb_eleicao_cargo (NOLOCK) WHERE int_id_eleicao_cargo = @int_id_eleicao_cargo) IS NOT NULL)
  BEGIN
	  SET @int_votos = 
	  (
		SELECT 
		 COUNT(*)
		FROM
		  tb_voto (NOLOCK)
		WHERE
		 int_numero_candidato = @int_id_candidato 
		 AND
		 int_id_eleicao_cargo = @int_id_eleicao_cargo
	  )
  END
  RETURN @int_votos

END
GO
/****** Object:  Table [dbo].[tb_candidato]    Script Date: 27/12/2012 00:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_candidato](
	[int_id_candidato] [int] IDENTITY(1000,1) NOT NULL,
	[str_nome_candidato] [varchar](50) NOT NULL,
	[str_apelido_candidato] [varchar](50) NULL,
	[dte_data_cadastro] [datetime] NULL,
	[img_foto_candidato] [image] NULL,
 CONSTRAINT [PK_tb_candidato] PRIMARY KEY CLUSTERED 
(
	[int_id_candidato] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_eleicao]    Script Date: 27/12/2012 00:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_eleicao](
	[int_id_eleicao] [int] IDENTITY(1,1) NOT NULL,
	[str_nome_eleicao] [varchar](50) NOT NULL,
	[dte_data_cadastro] [datetime] NULL,
	[dte_data_inicio] [datetime] NULL,
	[dte_data_fim] [datetime] NULL,
	[int_numero_eleitores] [int] NULL,
 CONSTRAINT [PK_tb_eleicao] PRIMARY KEY CLUSTERED 
(
	[int_id_eleicao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_eleicao_cargo]    Script Date: 27/12/2012 00:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_eleicao_cargo](
	[int_id_eleicao_cargo] [int] IDENTITY(1,1) NOT NULL,
	[int_id_eleicao] [int] NOT NULL,
	[str_nome_cargo] [varchar](50) NOT NULL,
	[int_numero_vagas] [int] NOT NULL,
	[dte_data_inicio] [datetime] NULL,
	[dte_data_fim] [datetime] NULL,
 CONSTRAINT [PK_tb_eleicao_cargo] PRIMARY KEY CLUSTERED 
(
	[int_id_eleicao_cargo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_eleicao_cargo_candidato]    Script Date: 27/12/2012 00:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_eleicao_cargo_candidato](
	[int_id_eleicao_cargo_candidato] [int] IDENTITY(1,1) NOT NULL,
	[int_id_eleicao_cargo] [int] NOT NULL,
	[int_id_candidato] [int] NOT NULL,
	[str_status] [varchar](2) NOT NULL,
 CONSTRAINT [PK_tb_eleicao_cargo_candidato] PRIMARY KEY CLUSTERED 
(
	[int_id_eleicao_cargo_candidato] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_status]    Script Date: 27/12/2012 00:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_status](
	[str_status] [varchar](2) NOT NULL,
	[str_nome_status] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tb_status] PRIMARY KEY CLUSTERED 
(
	[str_status] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_voto]    Script Date: 27/12/2012 00:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_voto](
	[int_id_voto] [int] IDENTITY(1,1) NOT NULL,
	[int_id_eleicao] [int] NOT NULL,
	[int_id_eleicao_cargo] [int] NOT NULL,
	[int_numero_candidato] [int] NOT NULL,
	[dte_data_voto] [datetime] NOT NULL,
	[str_tipo_voto] [char](1) NULL,
 CONSTRAINT [PK_tb_voto] PRIMARY KEY CLUSTERED 
(
	[int_id_voto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[tb_eleicao_cargo]  WITH CHECK ADD  CONSTRAINT [FK_tb_eleicao_cargo_tb_eleicao] FOREIGN KEY([int_id_eleicao])
REFERENCES [dbo].[tb_eleicao] ([int_id_eleicao])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tb_eleicao_cargo] CHECK CONSTRAINT [FK_tb_eleicao_cargo_tb_eleicao]
GO
ALTER TABLE [dbo].[tb_eleicao_cargo_candidato]  WITH CHECK ADD  CONSTRAINT [FK_tb_eleicao_cargo_candidato_tb_candidato] FOREIGN KEY([int_id_candidato])
REFERENCES [dbo].[tb_candidato] ([int_id_candidato])
GO
ALTER TABLE [dbo].[tb_eleicao_cargo_candidato] CHECK CONSTRAINT [FK_tb_eleicao_cargo_candidato_tb_candidato]
GO
ALTER TABLE [dbo].[tb_eleicao_cargo_candidato]  WITH CHECK ADD  CONSTRAINT [FK_tb_eleicao_cargo_candidato_tb_eleicao_cargo] FOREIGN KEY([int_id_eleicao_cargo])
REFERENCES [dbo].[tb_eleicao_cargo] ([int_id_eleicao_cargo])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tb_eleicao_cargo_candidato] CHECK CONSTRAINT [FK_tb_eleicao_cargo_candidato_tb_eleicao_cargo]
GO
ALTER TABLE [dbo].[tb_eleicao_cargo_candidato]  WITH CHECK ADD  CONSTRAINT [FK_tb_eleicao_cargo_candidato_tb_status] FOREIGN KEY([str_status])
REFERENCES [dbo].[tb_status] ([str_status])
GO
ALTER TABLE [dbo].[tb_eleicao_cargo_candidato] CHECK CONSTRAINT [FK_tb_eleicao_cargo_candidato_tb_status]
GO
ALTER TABLE [dbo].[tb_voto]  WITH CHECK ADD  CONSTRAINT [FK_tb_voto_tb_eleicao] FOREIGN KEY([int_id_eleicao])
REFERENCES [dbo].[tb_eleicao] ([int_id_eleicao])
GO
ALTER TABLE [dbo].[tb_voto] CHECK CONSTRAINT [FK_tb_voto_tb_eleicao]
GO
ALTER TABLE [dbo].[tb_voto]  WITH CHECK ADD  CONSTRAINT [FK_tb_voto_tb_eleicao_cargo] FOREIGN KEY([int_id_eleicao_cargo])
REFERENCES [dbo].[tb_eleicao_cargo] ([int_id_eleicao_cargo])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tb_voto] CHECK CONSTRAINT [FK_tb_voto_tb_eleicao_cargo]
GO
