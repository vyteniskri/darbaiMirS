#@(#) script.ddl

DROP TABLE IF EXISTS saskaitos;
DROP TABLE IF EXISTS perkamos_prekes;
DROP TABLE IF EXISTS uzsakymai;
DROP TABLE IF EXISTS prekiu_kainos;
DROP TABLE IF EXISTS prekes;
DROP TABLE IF EXISTS darbuotojai;
DROP TABLE IF EXISTS sporto_irangos_parduotuves;
DROP TABLE IF EXISTS parametrai;
DROP TABLE IF EXISTS spalvos;
DROP TABLE IF EXISTS medziagos;
DROP TABLE IF EXISTS tiekejai;
DROP TABLE IF EXISTS miestai;
DROP TABLE IF EXISTS klientai;
CREATE TABLE klientai
(
	asmens_kodas int (11) NOT NULL,
	vardas varchar (255) NOT NULL,
	pavarde varchar (255) NOT NULL,
	gimimo_data date NOT NULL,
	telefonas varchar (255) NOT NULL,
	e_pastas varchar (255) NOT NULL,
	PRIMARY KEY(asmens_kodas)
);

CREATE TABLE miestai
(
	pavadinimas varchar (255) NOT NULL,
	miesto_id integer (11) NOT NULL,
	PRIMARY KEY(miesto_id)
);

CREATE TABLE tiekejai
(
	tiekejo_id int (11) NOT NULL,
	pavadinimas varchar (255) NOT NULL,
	telefonas varchar (255) NOT NULL,
	e_pastas varchar (255) NOT NULL,
	adresas varchar (255) NOT NULL,
	PRIMARY KEY(tiekejo_id)
);

CREATE TABLE medziagos
(
	medziagos_id integer (11) NOT NULL,
	name char (10) NOT NULL,
	PRIMARY KEY(medziagos_id)
);
INSERT INTO medziagos(medziagos_id, name) VALUES(1, 'plienas');
INSERT INTO medziagos(medziagos_id, name) VALUES(2, 'plasmase');
INSERT INTO medziagos(medziagos_id, name) VALUES(3, 'guma');
INSERT INTO medziagos(medziagos_id, name) VALUES(4, 'neoprenas');
INSERT INTO medziagos(medziagos_id, name) VALUES(5, 'poliamidas');

CREATE TABLE spalvos
(
	spalvos_id integer (11) NOT NULL,
	name char (7) NOT NULL,
	PRIMARY KEY(spalvos_id)
);
INSERT INTO spalvos(spalvos_id, name) VALUES(1, 'juoda');
INSERT INTO spalvos(spalvos_id, name) VALUES(2, 'balta');
INSERT INTO spalvos(spalvos_id, name) VALUES(3, 'raudona');
INSERT INTO spalvos(spalvos_id, name) VALUES(4, 'melyna');
INSERT INTO spalvos(spalvos_id, name) VALUES(5, 'ruda');
INSERT INTO spalvos(spalvos_id, name) VALUES(6, 'zalia');

CREATE TABLE parametrai
(
	svoris float NOT NULL,
	ilgis float NOT NULL,
	patvarumas varchar (255) NOT NULL,
	plotis float NOT NULL,
	medziaga integer (11) NOT NULL,
	spalva integer (11) NOT NULL,
	parametro_id integer (11) NOT NULL,
	PRIMARY KEY(parametro_id),
	FOREIGN KEY(spalva) REFERENCES spalvos (spalvos_id),
	FOREIGN KEY(medziaga) REFERENCES medziagos (medziagos_id)
);

CREATE TABLE sporto_irangos_parduotuves
(
	pavadinimas varchar (255) NOT NULL,
	adresas varchar (255) NOT NULL,
	telefonas varchar (255) NOT NULL,
	e_pastas varchar (255) NOT NULL,
	parduotuves_id integer (11) NOT NULL,
	fk_miestas integer (11) NOT NULL,
	PRIMARY KEY(parduotuves_id),
	CONSTRAINT turi FOREIGN KEY(fk_miestas) REFERENCES miestai (miesto_id)
);

CREATE TABLE darbuotojai
(
	vardas varchar (255) NOT NULL,
	pavarde varchar (255) NOT NULL,
	tabelio_nr int (11) NOT NULL,
	fk_sporto_irangos_parduotuve integer (11) NOT NULL,
	PRIMARY KEY(tabelio_nr),
	CONSTRAINT dirba FOREIGN KEY(fk_sporto_irangos_parduotuve) REFERENCES sporto_irangos_parduotuves (parduotuves_id)
);

CREATE TABLE prekes
(
	pavadinimas varchar (255) NOT NULL,
	aprasymas varchar (255) NOT NULL,
	prekes_id integer (11) NOT NULL,
	fk_tiekejas int (11) NOT NULL,
	fk_parametras integer (11) NOT NULL,
	PRIMARY KEY(prekes_id),
	CONSTRAINT tiekia FOREIGN KEY(fk_tiekejas) REFERENCES tiekejai (tiekejo_id),
	CONSTRAINT priklauso FOREIGN KEY(fk_parametras) REFERENCES parametrai (parametro_id)
);

CREATE TABLE prekiu_kainos
(
	galioja_nuo date NOT NULL,
	galioja_iki date NOT NULL,
	kaina float NOT NULL,
	fk_preke integer (11) NOT NULL,
	PRIMARY KEY(galioja_nuo, fk_preke),
	CONSTRAINT parduodama_uz FOREIGN KEY(fk_preke) REFERENCES prekes (prekes_id)
);

CREATE TABLE uzsakymai
(
	uzsakymo_nr int (11) NOT NULL,
	uzsakymo_data date NOT NULL,
	fk_darbuotojas int (11) NOT NULL,
	fk_klientas int (11) NOT NULL,
	PRIMARY KEY(uzsakymo_nr),
	CONSTRAINT patvirtina FOREIGN KEY(fk_darbuotojas) REFERENCES darbuotojai (tabelio_nr),
	CONSTRAINT atlieka FOREIGN KEY(fk_klientas) REFERENCES klientai (asmens_kodas)
);

CREATE TABLE perkamos_prekes
(
	kiekis int (11) NOT NULL,
	kaina float NOT NULL,
	fk_uzsakymas int (11) NOT NULL,
	fk_preke int (11) NOT NULL,
	fk_prekes_kaina_galioja_nuo date NOT NULL,
	PRIMARY KEY(fk_uzsakymas, fk_preke, fk_prekes_kaina_galioja_nuo),
	CONSTRAINT itraukta_i FOREIGN KEY(fk_uzsakymas) REFERENCES uzsakymai (uzsakymo_nr),
	CONSTRAINT nurodoma_uz FOREIGN KEY(fk_preke, fk_prekes_kaina_galioja_nuo) REFERENCES prekiu_kainos (fk_preke, galioja_nuo)
);

CREATE TABLE saskaitos
(
	saskaitos_nr int (11) NOT NULL,
	data date NOT NULL,
	suma float NOT NULL,
	saskaitos_id integer (11) NOT NULL,
	fk_uzsakymas int (11) NOT NULL,
	fk_klientas int (11) NOT NULL,
	PRIMARY KEY(saskaitos_id),
	CONSTRAINT israsyta FOREIGN KEY(fk_uzsakymas) REFERENCES uzsakymai (uzsakymo_nr),
	CONSTRAINT sumokejo FOREIGN KEY(fk_klientas) REFERENCES klientai (asmens_kodas)
);
