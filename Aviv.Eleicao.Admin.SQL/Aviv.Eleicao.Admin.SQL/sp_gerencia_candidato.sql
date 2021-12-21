ALTER PROCEDURE sp_gerencia_candidato 
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

	SELECT @int_id_candidato AS int_id_candidato
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