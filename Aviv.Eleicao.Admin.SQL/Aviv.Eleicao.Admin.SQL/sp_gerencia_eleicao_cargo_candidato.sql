ALTER PROCEDURE sp_gerencia_eleicao_cargo_candidato
   
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