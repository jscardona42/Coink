-- Get countries
CREATE OR REPLACE FUNCTION sp_get_countries()
RETURNS TABLE (
    country_id INT,
    country_name TEXT
) AS $$
BEGIN
    RETURN QUERY
    SELECT id, name
    FROM countries
    ORDER BY name;
END;
$$ LANGUAGE plpgsql;

-- Get departmants by countryId
CREATE OR REPLACE FUNCTION sp_get_departments_by_country(
    p_country_id INT
)
RETURNS TABLE (
    department_id INT,
    department_name TEXT
) AS $$
BEGIN
    RETURN QUERY
    SELECT id, name
    FROM departments
    WHERE country_id = p_country_id
    ORDER BY name;
END;
$$ LANGUAGE plpgsql;

-- Get municipalities by departmentId
CREATE OR REPLACE FUNCTION sp_get_municipalities_by_department(
    p_department_id INT
)
RETURNS TABLE (
    municipality_id INT,
    municipality_name TEXT
) AS $$
BEGIN
    RETURN QUERY
    SELECT id, name
    FROM municipalities
    WHERE department_id = p_department_id
    ORDER BY name;
END;
$$ LANGUAGE plpgsql;



