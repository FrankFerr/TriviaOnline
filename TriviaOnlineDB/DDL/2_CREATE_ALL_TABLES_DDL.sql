CREATE TABLE UTENTI(
    OID         INTEGER NOT NULL,
    EXTERNAL_ID VARCHAR2(60 CHAR),
    ID_USERNAME VARCHAR2(30 CHAR),
    ID_EMAIL    VARCHAR2(50 CHAR),
    FL_ATTIVO   CHAR(1) DEFAULT 'S'
);

CREATE INDEX PK_UTENTI ON UTENTI(OID);
CREATE INDEX PKP_UTENTI ON UTENTI(EXTERNAL_ID);

ALTER TABLE UTENTI ADD (
    CONSTRAINT PK_UTENTI
    PRIMARY KEY (OID),
    
    CONSTRAINT U_UTENTI_EXTERNAL_ID
    UNIQUE (EXTERNAL_ID),
    
    CONSTRAINT U_UTENTI_ID_EMAIL
    UNIQUE (ID_EMAIL),
    
    CONSTRAINT U_UTENTI_ID_USERNAME
    UNIQUE (ID_USERNAME)
);

CREATE SEQUENCE SEQ_UTENTI
    INCREMENT BY 1
    START WITH 1
    MAXVALUE 9999999
    MINVALUE 1
    NOCYCLE
;

CREATE TRIGGER TR_UTENTI
BEFORE INSERT ON UTENTI
FOR EACH ROW 
BEGIN
    :NEW.OID := SEQ_UTENTI.NEXTVAL;
END;
/

CREATE TABLE PARTITE(
    OID                     INTEGER NOT NULL,
    ID_PARTITA              VARCHAR2(20 CHAR) NOT NULL,
    DS_PARTITA              VARCHAR2(80 CHAR),
    DT_CREAZIONE            DATE DEFAULT SYSDATE NOT NULL,
    TP_PARTITA              CHAR(1) NOT NULL,
    DS_PASSWORD             VARCHAR2(80 CHAR),
    NM_PARTECIPANTI         NUMBER(2) DEFAULT 1 NOT NULL,
    NM_DOMANDE              NUMBER(2) NOT NULL,
    NM_RISPOSTE             NUMBER(2) DEFAULT 0 NOT NULL,
    NM_SEC_TIMEOUT_RISPOSTA NUMBER(3) DEFAULT 30 NOT NULL,
    FL_INIZIATA             CHAR(1) DEFAULT 'N' NOT NULL,
    DT_INIZIO               DATE,
    FL_CONCLUSA             CHAR(1) DEFAULT 'N' NOT NULL,
    DT_FINE                 DATE
);

CREATE INDEX PK_PARTITE ON PARTITE(OID);
CREATE INDEX PKP_PARTITE ON PARTITE(ID_PARTITA, TP_PARTITA);

ALTER TABLE PARTITE ADD (
    CONSTRAINT PK_PARTITE
    PRIMARY KEY (OID)
);

CREATE SEQUENCE SEQ_PARTITE
    INCREMENT BY 1
    START WITH 1
    MAXVALUE 9999999
    MINVALUE 1
    NOCYCLE
;

CREATE OR REPLACE TRIGGER TR_PARTITE
BEFORE INSERT ON PARTITE
FOR EACH ROW 
BEGIN
    :NEW.OID := SEQ_PARTITE.NEXTVAL;
END;
/

CREATE TABLE PARTITE_UTENTI(
    OID         INTEGER NOT NULL,
    OID_UTENTE  INTEGER NOT NULL,
    OID_PARTITA INTEGER NOT NULL,
    FL_CREATA   CHAR(1) NOT NULL
);

CREATE INDEX PK_PARTITE_UTENTI ON PARTITE_UTENTI(OID);
CREATE INDEX PKP_PARTITE_UTENTI ON PARTITE_UTENTI(OID_UTENTE, OID_PARTITA);

ALTER TABLE PARTITE_UTENTI ADD (
    CONSTRAINT PK_PARTITE_UTENTI
    PRIMARY KEY (OID),
    
    CONSTRAINT FK_PU_UTENTI
    FOREIGN KEY (OID_UTENTE)
    REFERENCES UTENTI(OID),
    
    CONSTRAINT FK_PU_PARTITA
    FOREIGN KEY (OID_PARTITA)
    REFERENCES PARTITE(OID)
    ON DELETE CASCADE
);

CREATE SEQUENCE SEQ_PARTITE_UTENTI
    INCREMENT BY 1
    START WITH 1
    MAXVALUE 9999999
    MINVALUE 1
    NOCYCLE
;

CREATE OR REPLACE TRIGGER TR_PARTITE_UTENTI
BEFORE INSERT ON PARTITE_UTENTI
FOR EACH ROW 
BEGIN
    :NEW.OID := SEQ_PARTITE_UTENTI.NEXTVAL;
END;
/

CREATE TABLE CATEGORIE(
    OID             INTEGER NOT NULL,
    ID_CATEGORIA    VARCHAR2(5 CHAR) NOT NULL,
    DS_CATEGORIA    VARCHAR2(30 CHAR),
    FL_ATTIVA       CHAR(1) DEFAULT 'S' NOT NULL
);

CREATE INDEX PK_CATEGORIE ON CATEGORIE(OID);
CREATE INDEX PKP_CATEGORIE ON CATEGORIE(ID_CATEGORIA);

ALTER TABLE CATEGORIE ADD (
    CONSTRAINT PK_CATEGORIE
    PRIMARY KEY (OID)
);

CREATE SEQUENCE SEQ_CATEGORIE
    INCREMENT BY 1
    START WITH 1
    MAXVALUE 9999999
    MINVALUE 1
    NOCYCLE
;

CREATE OR REPLACE TRIGGER TR_CATEGORIE
BEFORE INSERT ON CATEGORIE
FOR EACH ROW 
BEGIN
    :NEW.OID := SEQ_CATEGORIE.NEXTVAL;
END;
/

CREATE TABLE DOMANDE(
    OID             INTEGER NOT NULL,
    OID_CATEGORIA   INTEGER NOT NULL,
    ID_DOMANDA      NUMBER(4),
    DS_DOMANDA      VARCHAR2(255 CHAR),
    TP_DIFFICOLTA   CHAR(1) DEFAULT 'F' NOT NULL,
    FL_ATTIVA       CHAR(1) DEFAULT 'S' NOT NULL
);

CREATE INDEX PK_DOMANDE ON DOMANDE(OID);
CREATE INDEX PKP_DOMANDE ON DOMANDE(OID_CATEGORIA, ID_DOMANDA);

ALTER TABLE DOMANDE ADD (
    CONSTRAINT PK_DOMANDE
    PRIMARY KEY (OID),
    
    CONSTRAINT FK_CATEGORIA
    FOREIGN KEY (OID_CATEGORIA)
    REFERENCES CATEGORIE(OID)
    ON DELETE CASCADE
);

CREATE SEQUENCE SEQ_DOMANDE
    INCREMENT BY 1
    START WITH 1
    MAXVALUE 9999999
    MINVALUE 1
    NOCYCLE
;

CREATE OR REPLACE TRIGGER TR_DOMANDE
BEFORE INSERT ON DOMANDE
FOR EACH ROW 
BEGIN
    :NEW.OID := SEQ_DOMANDE.NEXTVAL;
END;
/

CREATE TABLE DOMANDE_RISPOSTE(
    OID             INTEGER NOT NULL,
    OID_DOMANDA     INTEGER NOT NULL,
    ID_RISPOSTA     NUMBER(4),
    DS_RISPOSTA     VARCHAR2(255 CHAR),
    FL_CORRETTA     CHAR(1) NOT NULL
);

CREATE INDEX PK_DOMANDE_RISPOSTE ON DOMANDE_RISPOSTE(OID);
CREATE INDEX PKP_DOMANDE_RISPOSTE ON DOMANDE_RISPOSTE(OID_DOMANDA, ID_RISPOSTA);

ALTER TABLE DOMANDE_RISPOSTE ADD (
    CONSTRAINT PK_DOMANDE_RISPOSTE
    PRIMARY KEY (OID),
    
    CONSTRAINT FK_DOMANDA
    FOREIGN KEY (OID_DOMANDA)
    REFERENCES DOMANDE(OID)
    ON DELETE CASCADE
);

CREATE SEQUENCE SEQ_DOMANDE_RISPOSTE
    INCREMENT BY 1
    START WITH 1
    MAXVALUE 9999999
    MINVALUE 1
    NOCYCLE
;

CREATE OR REPLACE TRIGGER TR_DOMANDE_RISPOSTE
BEFORE INSERT ON DOMANDE_RISPOSTE
FOR EACH ROW 
BEGIN
    :NEW.OID := SEQ_DOMANDE_RISPOSTE.NEXTVAL;
END;
/

CREATE TABLE PARTITE_DOMANDE(
    OID             INTEGER NOT NULL,
    OID_PARTITA     INTEGER NOT NULL,
    OID_DOMANDA     INTEGER NOT NULL,
    FL_PROPOSTA     CHAR(1) DEFAULT 'N' NOT NULL,
    NM_DOMANDA      NUMBER(3) NOT NULL
);

CREATE INDEX PK_PARTITE_DOMANDE ON PARTITE_DOMANDE(OID);
CREATE INDEX PKP_PARTITE_DOMANDE ON PARTITE_DOMANDE(OID_PARTITA, OID_DOMANDA);

ALTER TABLE PARTITE_DOMANDE ADD (
    CONSTRAINT PK_PARTITE_DOMANDE
    PRIMARY KEY (OID),
    
    CONSTRAINT FK_PARTITA
    FOREIGN KEY (OID_PARTITA)
    REFERENCES PARTITE(OID)
    ON DELETE CASCADE,
    
    CONSTRAINT FK_DOMANDE
    FOREIGN KEY (OID_DOMANDA)
    REFERENCES DOMANDE(OID)
);

CREATE SEQUENCE SEQ_PARTITE_DOMANDE
    INCREMENT BY 1
    START WITH 1
    MAXVALUE 9999999
    MINVALUE 1
    NOCYCLE
;

CREATE OR REPLACE TRIGGER TR_PARTITE_DOMANDE
BEFORE INSERT ON PARTITE_DOMANDE
FOR EACH ROW 
BEGIN
    :NEW.OID := SEQ_PARTITE_DOMANDE.NEXTVAL;
END;
/

CREATE TABLE PARTITE_UTENTI_RISPOSTE(
    OID                 INTEGER NOT NULL,
    OID_PARTITA_UTENTE  INTEGER NOT NULL,
    OID_DOMANDA         INTEGER NOT NULL,
    OID_RISPOSTA        INTEGER NOT NULL,
    FL_CORRETTA         CHAR(1)
);

CREATE INDEX PK_PARTITE_UTENTI_RISPOSTE ON PARTITE_UTENTI_RISPOSTE(OID);
CREATE INDEX PKP_PARTITE_UTENTI_RISPOSTE ON PARTITE_UTENTI_RISPOSTE(OID_PARTITA_UTENTE, OID_DOMANDA, OID_RISPOSTA);

ALTER TABLE PARTITE_UTENTI_RISPOSTE ADD (
    CONSTRAINT PK_PARTITE_UTENTI_RISPOSTE
    PRIMARY KEY (OID),
    
    CONSTRAINT FK_PUR_PARTITA_UTENTE
    FOREIGN KEY (OID_PARTITA_UTENTE)
    REFERENCES PARTITE_UTENTI(OID)
    ON DELETE CASCADE,
    
    CONSTRAINT FK_PUR_DOMANDA
    FOREIGN KEY (OID_DOMANDA)
    REFERENCES DOMANDE(OID),
    
    CONSTRAINT FK_PUR_RISPOSTA
    FOREIGN KEY (OID_RISPOSTA)
    REFERENCES DOMANDE_RISPOSTE(OID)
);

CREATE SEQUENCE SEQ_PARTITE_UTENTI_RISPOSTE
    INCREMENT BY 1
    START WITH 1
    MAXVALUE 9999999
    MINVALUE 1
    NOCYCLE
;

CREATE OR REPLACE TRIGGER TR_PARTITE_UTENTI_RISPOSTE
BEFORE INSERT ON PARTITE_UTENTI_RISPOSTE
FOR EACH ROW 
BEGIN
    :NEW.OID := SEQ_PARTITE_UTENTI_RISPOSTE.NEXTVAL;
END;
/

CREATE TABLE STORICO_PARTITE(
    OID                     INTEGER NOT NULL,
    ID_PARTITA              VARCHAR2(20 CHAR) NOT NULL,
    DS_PARTITA              VARCHAR2(80 CHAR),
    DT_CREAZIONE            DATE DEFAULT SYSDATE NOT NULL,
    TP_PARTITA              CHAR(1) NOT NULL,
    DS_PASSWORD             VARCHAR2(80 CHAR),
    NM_PARTECIPANTI         NUMBER(2) DEFAULT 1 NOT NULL,
    NM_DOMANDE              NUMBER(2) NOT NULL,
    NM_RISPOSTE             NUMBER(2) DEFAULT 0 NOT NULL,
    NM_SEC_TIMEOUT_RISPOSTA NUMBER(3) DEFAULT 30 NOT NULL,
    FL_INIZIATA             CHAR(1) DEFAULT 'N' NOT NULL,
    DT_INIZIO               DATE,
    FL_CONCLUSA             CHAR(1) DEFAULT 'N' NOT NULL,
    DT_FINE                 DATE
);

CREATE INDEX PK_STORICO_PARTITE ON STORICO_PARTITE(OID);
CREATE INDEX PKP_STORICO_PARTITE ON STORICO_PARTITE(ID_PARTITA, TP_PARTITA);

ALTER TABLE STORICO_PARTITE ADD (
    CONSTRAINT PK_STORICO_PARTITE
    PRIMARY KEY (OID)
);

CREATE SEQUENCE SEQ_STORICO_PARTITE
    INCREMENT BY 1
    START WITH 1
    MAXVALUE 9999999
    MINVALUE 1
    NOCYCLE
;

CREATE OR REPLACE TRIGGER TR_STORICO_PARTITE
BEFORE INSERT ON STORICO_PARTITE
FOR EACH ROW 
BEGIN
    :NEW.OID := SEQ_STORICO_PARTITE.NEXTVAL;
END;
/

CREATE TABLE STORICO_PARTITE_UTENTI(
    OID                     INTEGER NOT NULL,
    OID_STORICO_PARTITA     INTEGER NOT NULL,
    ID_USERNAME             INTEGER NOT NULL,
    NM_RISPOSTE_CORRETTE    NUMBER(2),
    FL_ESITO                CHAR(1)
);

CREATE INDEX PK_STORICO_PARTITE_UTENTI ON STORICO_PARTITE_UTENTI(OID);
CREATE INDEX PKP_STORICO_PARTITE_UTENTI ON STORICO_PARTITE_UTENTI(OID_STORICO_PARTITA, ID_USERNAME);

ALTER TABLE STORICO_PARTITE_UTENTI ADD (
    CONSTRAINT PK_STORICO_PARTITE_UTENTI
    PRIMARY KEY (OID),
    
    CONSTRAINT FK_SPU_STORICO_PARTITA
    FOREIGN KEY (OID_STORICO_PARTITA)
    REFERENCES STORICO_PARTITE(OID)
);

CREATE SEQUENCE SEQ_STORICO_PARTITE_UTENTI
    INCREMENT BY 1
    START WITH 1
    MAXVALUE 9999999
    MINVALUE 1
    NOCYCLE
;

CREATE OR REPLACE TRIGGER TR_STORICO_PARTITE_UTENTI
BEFORE INSERT ON STORICO_PARTITE_UTENTI
FOR EACH ROW 
BEGIN
    :NEW.OID := SEQ_STORICO_PARTITE_UTENTI.NEXTVAL;
END;
/

CREATE TABLE STORICO_PARTITE_UTENTI_DOM(
    OID                         INTEGER NOT NULL,
    OID_STORICO_PARTITA_UTENTE  INTEGER NOT NULL,
    DS_CATEGORIA                VARCHAR2(30 CHAR),
    FL_CORRETTA                 CHAR(1)
);

CREATE INDEX PK_STORICO_PARTITE_UTENTI_DOM ON STORICO_PARTITE_UTENTI_DOM(OID);
CREATE INDEX PKP_STORICO_PARTITE_UTENTI_DOM ON STORICO_PARTITE_UTENTI_DOM(OID_STORICO_PARTITA_UTENTE);

ALTER TABLE STORICO_PARTITE_UTENTI_DOM ADD (
    CONSTRAINT PK_STORICO_PARTITE_UTENTI_DOM
    PRIMARY KEY (OID),
    
    CONSTRAINT FK_SPUD_STORICO_PARTITA_UTENTE
    FOREIGN KEY (OID_STORICO_PARTITA_UTENTE)
    REFERENCES STORICO_PARTITE_UTENTI(OID)
);

CREATE SEQUENCE SEQ_STORICO_PARTITE_UTENTI_DOM
    INCREMENT BY 1
    START WITH 1
    MAXVALUE 9999999
    MINVALUE 1
    NOCYCLE
;

CREATE OR REPLACE TRIGGER TR_STORICO_PARTITE_UTENTI_DOM
BEFORE INSERT ON STORICO_PARTITE_UTENTI_DOM
FOR EACH ROW 
BEGIN
    :NEW.OID := SEQ_STORICO_PARTITE_UTENTI_DOM.NEXTVAL;
END;
/

