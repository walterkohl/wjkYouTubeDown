--
-- File generated with SQLiteStudio v3.2.1 on Sa Apr 11 13:56:25 2020
--
-- Text encoding used: System
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Table: Translate
CREATE TABLE Translate (ID INTEGER PRIMARY KEY ASC ON CONFLICT FAIL AUTOINCREMENT NOT NULL, Form VARCHAR (100) NOT NULL, Lang VARCHAR (10) NOT NULL, "Key" VARCHAR (100) NOT NULL, Value VARCHAR (1000));
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (1, 'start', 'de-DE', 'NoYouTube3', 'Dies scheint kein YouTube-Link zu sein.');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (2, 'start', 'de-DE', 'NoYouTube2', 'Soll ich zum Direktlink für Videos wechseln?');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (3, 'start', 'de-DE', 'NoYouTube1', 'Dies scheint kein YouTube-Link zu sein.');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (4, 'start', 'en-US', 'NoYouTube1', 'This does not appear to be a YouTube link.');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (5, 'start', 'en-US', 'NoYouTube2', 'Should I switch to the direct link for videos?');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (6, 'start', 'en-US', 'NoYouTube3', 'This does not appear to be a YouTube link.');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (7, 'start', 'de-DE', 'IsYouTube1', 'Dies scheint ein YouTube-Link zu sein.');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (8, 'start', 'de-DE', 'IsYouTube2', 'Soll ich zum Download für YouTube-Videos wechseln?');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (9, 'start', 'de-DE', 'IsYouTube3', 'Wechsel zu YouTube');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (10, 'start', 'de-DE', 'Exception1', 'Ich konnte die Datei nicht laden...');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (11, 'all', 'de-DE', 'Exception21', 'Bitte neu versuchen!');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (12, 'all', 'de-DE', 'Exception22', 'Fehler beim Verarbeiten');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (13, 'start', 'de-DE', 'Infotext1', 'YouTube-Infos: ');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (14, 'start', 'de-DE', 'Infotext3', 'Speichername: ');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (15, 'start', 'de-DE', 'Infotext4', 'Erweiterung: ');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (16, 'start', 'de-DE', 'Infotext5', 'Ganzer Name: ');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (17, 'start', 'de-DE', 'Infotext6', 'Auflösung: ');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (18, 'start', 'de-DE', 'Infotext7', 'Videoformat: ');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (19, 'start', 'de-DE', 'Infotext2', 'Originaltitel: ');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (20, 'start', 'de-DE', 'Infotext8', 'Selfmade-Infos: ');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (21, 'start', 'de-DE', 'Infotext9', 'Originaltitel: ');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (22, 'start', 'de-DE', 'Infotext10', 'Speichername: ');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (23, 'start', 'de-DE', 'Infotext11', 'Erweiterung: ');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (24, 'start', 'de-DE', 'Infotext12', 'Platz für eigene Einträge...');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (25, 'start', 'de-DE', 'Infotext13', 'Speicherort: ');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (26, 'start', 'de-DE', 'folderBrowserDialog1', 'Wähle das Verzeichnis zum Speichern aus');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (27, 'start', 'de-DE', 'Infotext15', 'Diese Informationen werden gespeichert unter:');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (28, 'start', 'de-DE', 'Infotext14', 'Dateigröße');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (29, 'start', 'de-DE', 'ReadFile.Text', 'Datei lesen');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (31, 'start', 'de-DE', 'radioYouTube.Text', 'YouTube-Link');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (32, 'start', 'de-DE', 'radioURL.Text', 'Video-URL');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (33, 'start', 'de-DE', 'label6.Text', 'Die Datei existiert, bitte umbenennen!');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (34, 'start', 'de-DE', 'label5.Text', '*** Speichern ***');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (35, 'start', 'de-DE', 'label4.Text', 'Speichern unter');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (36, 'start', 'de-DE', 'label3.Text', 'Nachfolgende Videoinformationen in Datei speichern');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (37, 'start', 'de-DE', 'label2.Text', 'Dateiname zum Speichern');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (38, 'start', 'de-DE', 'label1.Text', 'Bitte den Link aus YouTube hierher kopieren.');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (39, 'start', 'de-DE', 'groupURL.Text', 'URL');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (40, 'start', 'de-DE', 'DdLang.Items', 'th-TH');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (41, 'start', 'de-DE', 'DdLang.Items', 'de-DE');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (42, 'start', 'de-DE', 'DdLang.Items', 'en-US');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (43, 'start', 'de-DE', 'CheckSaveInfo.Text', 'Ja: Infos speichern');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (44, 'start', 'de-DE', 'button3.Text', 'Name okay?');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (45, 'start', 'de-DE', 'button2.Text', 'Speichern');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (46, 'start', 'de-DE', 'button1.Text', 'Verzeichnis zum Speichern wählen');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (47, 'start', 'de-DE', 'BtnReset.Text', 'Rücksetzen');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (48, 'start', 'de-DE', 'BtnPreviewFile.Text', 'Vorschau');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (49, 'start', 'de-DE', 'BtnHelp.Text', 'Hilfe');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (50, 'start', 'de-DE', 'BtnAbout.Text', 'Über');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (51, 'start', 'en-US', 'BtnReset.Text', 'Reset');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (52, 'start', 'en-US', 'BtnPreviewFile.Text', 'Preview');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (53, 'start', 'en-US', 'BtnHelp.Text', 'Help');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (54, 'start', 'en-US', 'BtnAbout.Text', 'About');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (55, 'all', 'en-US', 'Exception21', 'Please try again!');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (56, 'all', 'en-US', 'Exception22', 'Error during processing');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (57, 'all', 'en-US', 'Lang', NULL);
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (58, 'all', 'de-DE', 'Lang', NULL);
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (59, 'start', 'de-DE', 'MessageBoxOverwrite1', 'Diese Datei ist bereits vorhanden.');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (60, 'start', 'de-DE', 'MessageBoxOverwrite2', 'Soll sie ueberschrieben werden?');
INSERT INTO Translate (ID, Form, Lang, "Key", Value) VALUES (61, 'start', 'de-DE', 'MessageBoxOverwrite3', 'Datei ueberschreiben?');

COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
