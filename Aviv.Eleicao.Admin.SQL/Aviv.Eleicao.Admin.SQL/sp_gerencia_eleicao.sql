ALTER PROCEDURE sp_gerencia_eleicao
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