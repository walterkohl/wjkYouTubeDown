# wjk-Video-Downloader: Importand informations for developers and other professionals
Lightwight download for YouTube and direct linked videos<br>
*** GUI: Multilingual Languages (at the moment: DE, EN) ***<br>
YouTube download based on [libvideo](https://github.com/omansak/libvideo) by [Omansak](https://github.com/omansak)

[Releases](https://github.com/walterkohl/wjkYouTubeDown/releases)


### Here are some informations for 
- developers they want to use my source or for 
- somebody how want to add translations or make changes there.


## Updates
### May 10, 2020
- Now you can backup all records in a XML-file or backup by a language.


### First of all
- Please look at the source, there are many notes for documentation why some things happens or not.<br>
- <br>


### Multilingual
- As long as I know ASP.net (from the beginning on) I try to find the best solution for the multilingualety. I write (overrite) own controls (see here in Git), using a own ressources provider to store it in a database amd so on. I like to have the translations in mz own control and in a database!<br>
- In this application I use simple functions to realice it. You'll find many ways to do it, try out whats the best for you is.<br>
- If you just want to edit the translation or fix something, please type in the empty download form (where you copy in normal situations the download link in) the word "trans" (without breakets) and click "Read file".<br>
- The "LangEditor" window pops up. Now you can edit the languages and can add languages too.<br>
- All I whish is to give me an response if you find something wrong or, if you add a language, send me please a text file with the new add records by e-mail (see below). I'll implement a function to do it. Not finished yet: May 10, 2020.<br>
- How you use the "Language Editor" you can find in a special help. We'll implement it soon. Not finished yet: May 10, 2020.<br>


### Database
- First I tried to use SQLite because I was looking for a very nice and small installation of a database. Shure it was also possible to use text or XML files but we never know what idea we have tomorrow. 😊<br>
- With the SQLite database I had no luck. It was not working well: the insert programaticly not works for example.<br>
- So I remember I worked in a other solution with MS SQL CE and was using this.<br>
- You have to know, in my applicatins I'm using in the most of the time a database layer, in the business logic you call only the layer. So it's more easy to change the db-engine.<br>
- With the MS SQL CE I'm not realy happy too. For example essetial things, like reader.HasRows() are not working and you not have a management console for the CE database. I believe Microsoft not love it's own child.<br>
- So it was necessary to write a own application. As web developer I made it quick in a IIS ASP.net site (a Grid- and DetailView are perfekt for my necessaries). But also in ASP.net you not found a datasource for the CE database. I made it self bya a dataset. I'll give you a link to download it, so you can save the work on it.<br>
- Befor I forget: the database is stored in "dbPath = temp + @'\wjkYouTubeDown\RessourcesDB.sdf'", where temp = "Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)". It's only implemented in the "dbLayer" at "CreateConnection()".<br>
▶ CAREFULL: if the database not exist or it's defekt or what ever, this file will be created (overwrites old one), also the table "Translate" and some records are inserted. So if you made changes don't forgt to make a copy of the database!<br>
- <br>


### FileWebRequest, HttpWebRequest etc.
- Sometimes I sit on an other enviroment and had no internet but want to show a friend the function of this application. At this time I handle only the HttpWebRequests.<br>
- With this information a rebuild the application to can use a local (network) file (video) too. By the way I a got the idea to make other downloads also possible (FTP a.s.o.) but this is a task for a next version after 2.0<br>
- <br>


### Contact
- You can reach me in Pattaya, Thailand. I speek German, English and Spain. I can understand also Italian, Portugues, French and a little Thai. Please use:<br>
- e-mail: kohl.walter@hotmail.com<br>
- Skype: Walter_Kohl<br>
- Line: wjk-Software<br>
- www: [walter-kohl.ch]http://walter-kohl.ch <br>
- LikedIn: ...<br>
- GitHub: ...<br>
- Phone: +66 88 525 9904<br>
- <br>

### Created
- Date and time: May 10, 2020 at 12.00 h (highnoon)<br>
- Last release: 1.3.0  (not published)<br>
- Last Git Sync: unknowen<br>
- <br>

