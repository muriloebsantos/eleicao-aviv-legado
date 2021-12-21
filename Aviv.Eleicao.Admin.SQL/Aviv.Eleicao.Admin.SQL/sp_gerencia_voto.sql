ALTER PROCEDURE sp_gerencia_voto
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