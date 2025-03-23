CREATE OR REPLACE PROCEDURE CREATE_VIEW_MODEL(p_table IN VARCHAR2)
IS
BEGIN
    DBMS_OUTPUT.PUT_LINE('public class ' || REPLACE(INITCAP(LOWER(p_table)), '_', '') || 'VM');
    DBMS_OUTPUT.PUT_LINE('{');

    FOR rec IN (SELECT * FROM user_tab_columns WHERE table_name = UPPER(p_table))
    LOOP
        IF rec.column_name = 'OID' THEN
            DBMS_OUTPUT.PUT_LINE('[Key]');
        END IF;

        DBMS_OUTPUT.PUT('public ');

        CASE
            WHEN rec.data_type = 'NUMBER' AND (INSTR(rec.column_name, 'OID') <> 0 OR rec.data_scale > 0)
                THEN DBMS_OUTPUT.PUT('decimal');
            WHEN rec.data_type = 'NUMBER' AND rec.data_scale = 0 
                THEN DBMS_OUTPUT.PUT('int');
            WHEN rec.data_type IN ('CHAR', 'VARCHAR2')
                THEN DBMS_OUTPUT.PUT('string');
            WHEN rec.data_type = 'DATE'
                THEN DBMS_OUTPUT.PUT('DateTime');
        END CASE;

        IF rec.nullable = 'Y' THEN 
            DBMS_OUTPUT.PUT('? ');
        ELSE 
            DBMS_OUTPUT.PUT(' ');
        END IF;

        DBMS_OUTPUT.PUT_LINE(REPLACE(INITCAP(LOWER(rec.column_name)), '_', '') || ';');
        DBMS_OUTPUT.PUT_LINE('');

    END LOOP;

    DBMS_OUTPUT.PUT_LINE('}');    
END;
/