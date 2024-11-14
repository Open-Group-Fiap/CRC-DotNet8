CREATE OR REPLACE PACKAGE pkg_insert_condominio AS
    -- Procedure para Auth
    PROCEDURE create_auth (
        p_email      t_op_crc_auth.email%TYPE,
        p_hash_senha t_op_crc_auth.hash_senha%TYPE,
        p_id_out     OUT t_op_crc_auth.id_auth%TYPE  -- Parâmetro de saída para o ID gerado
    );

    -- Procedure para Condomínio
    PROCEDURE create_condominio (
        p_nome       t_op_crc_condominio.nome%TYPE,
        p_endereco   t_op_crc_condominio.endereco%TYPE,
        p_id_out     OUT t_op_crc_condominio.id_condominio%TYPE  -- Parâmetro de saída para o ID gerado
    );

    -- Procedure para Morador
    PROCEDURE create_morador (
        p_id_condominio     t_op_crc_morador.id_condominio%TYPE,
        p_id_auth           t_op_crc_morador.id_auth%TYPE,
        p_cpf               t_op_crc_morador.cpf%TYPE,
        p_nome              t_op_crc_morador.nome%TYPE,
        p_qtd_moradores     t_op_crc_morador.qtd_moradores%TYPE,
        p_identificador_res t_op_crc_morador.identificador_res%TYPE,
        p_id_out            OUT t_op_crc_morador.id_morador%TYPE  -- Parâmetro de saída para o ID gerado
    );

    -- Procedure para Fatura
    PROCEDURE create_fatura (
        p_id_morador    t_op_crc_fatura.id_morador%TYPE,
        p_qtd_consumida t_op_crc_fatura.qtd_consumida%TYPE,
        p_dt_geracao    t_op_crc_fatura.dt_geracao%TYPE,
        p_id_out        OUT t_op_crc_fatura.id_fatura%TYPE  -- Parâmetro de saída para o ID gerado
    );

    -- Procedure para Bônus
    PROCEDURE create_bonus (
        p_id_condominio t_op_crc_bonus.id_condominio%TYPE,
        p_nome          t_op_crc_bonus.nome%TYPE,
        p_descricao     t_op_crc_bonus.descricao%TYPE,
        p_custo         t_op_crc_bonus.custo%TYPE,
        p_qtd_max       t_op_crc_bonus.qtd_max%TYPE,
        p_id_out        OUT t_op_crc_bonus.id_bonus%TYPE  -- Parâmetro de saída para o ID gerado
    );

    -- Procedure para Morador_Bonus
    PROCEDURE create_morador_bonus (
        p_id_morador t_op_crc_morador_bonus.id_morador%TYPE,
        p_id_bonus   t_op_crc_morador_bonus.id_bonus%TYPE,
        p_qtd        t_op_crc_morador_bonus.qtd%TYPE,
        p_id_out     OUT t_op_crc_morador_bonus.id_mb%TYPE  -- Parâmetro de saída para o ID gerado
    );

END pkg_insert_condominio;