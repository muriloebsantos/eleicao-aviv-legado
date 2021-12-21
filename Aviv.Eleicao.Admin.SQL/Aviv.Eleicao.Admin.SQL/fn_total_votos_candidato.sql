ALTER FUNCTION fn_total_votos_candidatos
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