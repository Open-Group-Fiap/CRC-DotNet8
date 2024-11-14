CREATE OR REPLACE PACKAGE BODY pkg_insert_condominio AS

    -- Procedure para inserir em Auth
    PROCEDURE create_auth (
        p_email      t_op_crc_auth.email%TYPE,
        p_hash_senha t_op_crc_auth.hash_senha%TYPE,
        p_id_out     OUT t_op_crc_auth.id_auth%TYPE
    ) IS
BEGIN
INSERT INTO t_op_crc_auth (email, hash_senha)
VALUES (p_email, p_hash_senha)
    RETURNING id_auth INTO p_id_out;
END create_auth;

    -- Procedure para inserir em Condomínio
    PROCEDURE create_condominio (
        p_nome       t_op_crc_condominio.nome%TYPE,
        p_endereco   t_op_crc_condominio.endereco%TYPE,
        p_id_out     OUT t_op_crc_condominio.id_condominio%TYPE
    ) IS
BEGIN
INSERT INTO t_op_crc_condominio (nome, endereco)
VALUES (p_nome, p_endereco)
    RETURNING id_condominio INTO p_id_out;
END create_condominio;

    -- Procedure para inserir em Morador
    PROCEDURE create_morador (
        p_id_condominio     t_op_crc_morador.id_condominio%TYPE,
        p_id_auth           t_op_crc_morador.id_auth%TYPE,
        p_cpf               t_op_crc_morador.cpf%TYPE,
        p_nome              t_op_crc_morador.nome%TYPE,
        p_qtd_moradores     t_op_crc_morador.qtd_moradores%TYPE,
        p_identificador_res t_op_crc_morador.identificador_res%TYPE,
        p_id_out            OUT t_op_crc_morador.id_morador%TYPE
    ) IS
BEGIN
INSERT INTO t_op_crc_morador (id_condominio, id_auth, cpf, nome, qtd_moradores, identificador_res)
VALUES (p_id_condominio, p_id_auth, p_cpf, p_nome, p_qtd_moradores, p_identificador_res)
    RETURNING id_morador INTO p_id_out;
END create_morador;

    -- Procedure para inserir em Fatura
    PROCEDURE create_fatura (
        p_id_morador    t_op_crc_fatura.id_morador%TYPE,
        p_qtd_consumida t_op_crc_fatura.qtd_consumida%TYPE,
        p_dt_geracao    t_op_crc_fatura.dt_geracao%TYPE,
        p_id_out        OUT t_op_crc_fatura.id_fatura%TYPE
    ) IS
BEGIN
INSERT INTO t_op_crc_fatura (id_morador, qtd_consumida, dt_geracao)
VALUES (p_id_morador, p_qtd_consumida, p_dt_geracao)
    RETURNING id_fatura INTO p_id_out;
END create_fatura;

    -- Procedure para inserir em Bônus
    PROCEDURE create_bonus (
        p_id_condominio t_op_crc_bonus.id_condominio%TYPE,
        p_nome          t_op_crc_bonus.nome%TYPE,
        p_descricao     t_op_crc_bonus.descricao%TYPE,
        p_custo         t_op_crc_bonus.custo%TYPE,
        p_qtd_max       t_op_crc_bonus.qtd_max%TYPE,
        p_id_out        OUT t_op_crc_bonus.id_bonus%TYPE
    ) IS
BEGIN
INSERT INTO t_op_crc_bonus (id_condominio, nome, descricao, custo, qtd_max)
VALUES (p_id_condominio, p_nome, p_descricao, p_custo, p_qtd_max)
    RETURNING id_bonus INTO p_id_out;
END create_bonus;

    -- Procedure para inserir em Morador_Bonus
    PROCEDURE create_morador_bonus (
        p_id_morador t_op_crc_morador_bonus.id_morador%TYPE,
        p_id_bonus   t_op_crc_morador_bonus.id_bonus%TYPE,
        p_qtd        t_op_crc_morador_bonus.qtd%TYPE,
        p_id_out     OUT t_op_crc_morador_bonus.id_mb%TYPE
    ) IS
BEGIN
INSERT INTO t_op_crc_morador_bonus (id_morador, id_bonus, qtd)
VALUES (p_id_morador, p_id_bonus, p_qtd)
    RETURNING id_mb INTO p_id_out;
END create_morador_bonus;

END pkg_insert_condominio;