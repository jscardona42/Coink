CREATE OR REPLACE PROCEDURE sp_create_user(
    p_name TEXT,
    p_phone TEXT,
    p_address TEXT,
    p_municipality_id INT
)
LANGUAGE plpgsql
AS $$
BEGIN
    INSERT INTO users (name, phone, address, municipality_id)
    VALUES (p_name, p_phone, p_address, p_municipality_id);
END;
$$;