ALTER PROCEDURE sp_gerencia_eleicao_cargo
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
		RAISERROR(N'Cargo n�o inserido. A elei��o j� foi iniciada.', 16, 16)
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
	  RAISERROR(N'Cargo n�o atualizado. A elei��o j� foi iniciada.', 16, 16)
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
		RAISERROR(N'Cargo n�o excluido. A elei��o j� foi iniciada.', 16, 16)
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
		RAISERROR(N'Vota��o para o cargo n�o iniciada. A elei��o n�o foi iniciada.', 16, 16)
		RETURN
	 END
	 ELSE IF(EXISTS(SELECT 1 FROM tb_eleicao (NOLOCK) WHERE int_id_eleicao = @int_id_eleicao AND dte_data_fim IS NOT NULL))
	 BEGIN
		RAISERROR(N'Vota��o para o cargo n�o iniciada. A elei��o j� foi encerrada.', 16, 16)
		RETURN
	 END
	 ELSE IF(EXISTS(SELECT 1 FROM tb_eleicao_cargo (NOLOCK) WHERE int_id_eleicao = @int_id_eleicao AND (dte_data_inicio IS NOT NULL AND dte_data_fim IS NULL)))
	 BEGIN
		RAISERROR(N'Vota��o para o cargo n�o iniciada. A elei��o j� tem um cargo com vota��o aberta.', 16, 16)
		RETURN
	 END
	 ELSE IF(EXISTS(SELECT 1 FROM tb_eleicao_cargo (NOLOCK) WHERE int_id_eleicao_cargo = @int_id_eleicao_cargo AND dte_data_inicio IS NOT NULL))
	 BEGIN
		RAISERROR(N'Vota��o para o cargo n�o iniciada. A elei��o para esse cargo j� est� aberta', 16, 16)
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
		RAISERROR(N'Vota��o para o cargo n�o encerrada. A elei��o n�o foi iniciada.', 16, 16)
		RETURN
	 END
	 ELSE IF(EXISTS(SELECT 1 FROM tb_eleicao (NOLOCK) WHERE int_id_eleicao = @int_id_eleicao AND dte_data_fim IS NOT NULL))
	 BEGIN
		RAISERROR(N'Vota��o para o cargo n�o foi encerrada. A elei��o j� foi encerrada.', 16, 16)
		RETURN
	 END
	 ELSE IF(EXISTS(SELECT 1 FROM tb_eleicao_cargo (NOLOCK) WHERE int_id_eleicao_cargo = @int_id_eleicao_cargo AND dte_data_inicio IS NULL))
	 BEGIN
		RAISERROR(N'Vota��o para o cargo n�o foi encerrada. A vota��o para o cargo n�o foi aberta', 16, 16)
		RETURN
	 END
	 ELSE IF(EXISTS(SELECT 1 FROM tb_eleicao_cargo (NOLOCK) WHERE int_id_eleicao_cargo = @int_id_eleicao_cargo AND dte_data_fim IS NOT NULL))
	 BEGIN
		RAISERROR(N'Vota��o para o cargo n�o encerrada. A elei��o para esse cargo j� est� encerrada', 16, 16)
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