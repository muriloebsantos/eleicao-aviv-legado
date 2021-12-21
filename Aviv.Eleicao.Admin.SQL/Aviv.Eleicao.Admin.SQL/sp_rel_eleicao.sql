ALTER PROCEDURE sp_rel_eleicao
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