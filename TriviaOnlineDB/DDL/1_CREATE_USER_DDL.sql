-- da eseguire come utente SYSDBA

CREATE USER TriviaOnlinePROD IDENTIFIED BY triviaonlineprod;

GRANT UNLIMITED TABLESPACE TO TriviaOnlinePROD;

GRANT ALL PRIVILEGES TO TriviaOnlinePROD;


CREATE USER TriviaOnlineTEST IDENTIFIED BY triviaonlinetest;

GRANT UNLIMITED TABLESPACE TO TriviaOnlineTEST;

GRANT ALL PRIVILEGES TO TriviaOnlineTEST;