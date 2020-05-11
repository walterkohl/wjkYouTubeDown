using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Xml;
using System.Globalization;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Web.UI.WebControls;
using System.Runtime.CompilerServices;

namespace wjkYouTupe
{
    class DbLayerSQLCE
    {
        public static string tKey { private get; set; }
        public static string tValue { private get; set; }

        private static string tForm;
        public string getForm()
        {
            return tForm;
        }
        public void setForm(string Value)
        {
            tForm = Value.ToLower();
        }

        private static string tLang;
        public string getLang()
        {
            return tLang;
        }
        public void setLang(string Value)
        {
            tLang = Value;
        }

        public static string Fallback;
        public string getFallback()
        {
            return Fallback;
        }
        public void setFallback(string value)
        {
            Fallback = value;
        }

        public static SqlCeConnection conn;

        public SqlCeConnection GetConn()
        {
            return conn;
        }

        private void SetConn(SqlCeConnection value)
        {
            conn = value;
        }
        public DbLayerSQLCE(string _Fallback = "de-DE")
        {
            setFallback(_Fallback);
            SetConn(CreateConnection());
        }
        /// <summary>
        /// Store the name of the form and the language for future usw.
        /// </summary>
        /// <param name="_Form">Name of the form.</param>
        /// <param name="_Lang">The used language in the form 'xx-XX'. Exa.: 'en-US'.</param>
        /// <param name="_Fallback">If a translation can't be found the basic culture (stored in the variable 'Fallback') will be used (standard is 'de-DE' German.</param>
        public DbLayerSQLCE(string _Form, string _Lang, string _Fallback = "de-DE")
        {
            setForm(_Form);
            setLang(_Lang);
            setFallback(_Fallback);
            SetConn(CreateConnection());
        }
        /// <summary>
        /// It creates the SQL CE Connection for the database called RessourcesDB.sdf in the application.
        /// If the database not exists it will be created and filled with the basic translations,
        /// </summary>
        /// <returns>The SqlCeConnection and opens the "conn" as test.</returns>
        static SqlCeConnection CreateConnection()
        {
            string temp = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string dbPath = temp + @"\wjkYouTubeDown\RessourcesDB.sdf";
            SqlCeConnection conn = new SqlCeConnection(@"Data Source = " + dbPath);
            try
            {
                conn.Open();
            }
            catch (SqlCeException ex)
            {
                string test = ex.Message;
                if (ex.ErrorCode == -2147467259)
                {
                    CreateDatabae(dbPath);
                    CreateTableTranslate(dbPath);
                    InsertFirstData(dbPath);
                }
            }
            return conn;
        }
        /// <summary>
        /// It creates the database in dbPath. It's called in the catch handler of "CreateConnection()".
        /// </summary>
        /// <param name="dbPath">The given path an name of the database.</param>
        private static void CreateDatabae(string dbPath)
        {
            try
            {
                File.Delete(dbPath);
                SqlCeEngine engine = new SqlCeEngine(@"Data Source = " + dbPath);
                engine.CreateDatabase();
            }
            catch (SqlCeException ex)
            {
                HandleException(ex, "CreateDatabae");
            }
            catch (Exception ex)
            {
                HandleException(ex, "CreateDatabae");
            }
        }
        /// <summary>
        /// It creates the table Translate in the database. It's called in the catch handler of "CreateConnection()".
        /// </summary>
        /// <param name="dbPath">The given path an name of the database.</param>
        private static void CreateTableTranslate(string dbPath)
        {
            SqlCeCommand cmd;
            SqlCeConnection conn = new SqlCeConnection(@"Data Source = " + dbPath);
            cmd = conn.CreateCommand();

            string sql = "CREATE TABLE Translate(";
            sql += "[ID] INT              IDENTITY(1, 1) NOT NULL CONSTRAINT ID_PK PRIMARY KEY, ";
            sql += "[Form]  NVarChar(100)    NOT NULL, ";
            sql += "[Lang]  NVarChar(10)     NOT NULL, ";
            sql += "[Key]   NVarChar(100)    NOT NULL, ";
            sql += "[Value] NText)";

            try
            {
                cmd.CommandText = sql;
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd.ExecuteNonQuery();
            }
            catch (SqlCeException ex)
            {
               HandleException(ex, "CreateTableTranslate");
            }
            catch (Exception ex)
            {
                HandleException(ex, "CreateTableTranslate");
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
            }
        }
        /// <summary>
        /// It inserts the basic records in the table Translate in the database. It's called in the catch handler of "CreateConnection()".
        /// The function uses the SQL calls in the text file "FirstData_transform.sql" placed in the root directory of the application.
        /// </summary>
        /// <param name="dbPath">The given path an name of the database.</param>
        private static void InsertFirstData(string dbPath)
        {
            string sqlPath = Environment.CurrentDirectory + @"\FirstData_transform.sql";
            StreamReader r = null;
            string line;
            SqlCeCommand cmd;
            SqlCeConnection conn = new SqlCeConnection(@"Data Source = " + dbPath);
            cmd = conn.CreateCommand();

            try
            {
                r = File.OpenText(sqlPath);
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                while ((line = r.ReadLine()) != null)
                {
                    cmd.CommandText = line;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlCeException ex)
            {
                HandleException(ex, "InsertFirstData");
            }
            catch (Exception ex)
            {
                HandleException(ex, "InsertFirstData");
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
                r.Close();
            }

        }

        public bool GetSingleTranslation(ref string value, string _Form, string _key, string _lang, bool IsEditable=true)
        {
            string _value = string.Empty;
            tValue = value;
            tKey = _key;

            try
            {
                if (string.IsNullOrEmpty(_Form)) { throw new NullReferenceException("Missing: _Form"); }
                if (string.IsNullOrEmpty(_lang)) { throw new NullReferenceException("Missing: _lang"); }
                string[] temp = _lang.Split('-');
                if (temp.Length != 2) { throw new Exception("The language description is wrong. Form \"xx-XX\", ex.: \"en-US\""); }
                if (string.IsNullOrEmpty(tKey)) { throw new NullReferenceException("Missing: tKey"); }
                if (string.IsNullOrEmpty(Fallback)) { throw new NullReferenceException("Missing: Fallback"); }

                _value = GetSingleTranslation(tKey, _lang, _Form);

                if (string.IsNullOrEmpty(_value))
                {
                    if (IsEditable && _lang == Fallback)
                    {
                        InsertInDB(_Form, _lang, tKey, tValue);
                        //it's to test if the value is well stored in the database.
                        value = GetSingleTranslation(tKey, _lang, _Form);
                        return true;
                    }
                    else
                    {
                        value = string.Empty;
                        return false;
                    }
                }
                else
                {
                    value = _value;
                    return true;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "GetSingleTranslation");
            }
            return false;
        }
        /// <summary>
        /// It returns a translation from the database by language, form (both set by referencing the class) and key. The value is set by the developer and should be in the Fallback langauage.
        /// When IsEditable is true: If the record can't be found in the database it will be inserted. NOT IMPLEMENTED: If the value is different from the database it will be updated.
        /// </summary>
        /// <param name="value">The text of the control by reference.</param>
        /// <param name="_key">The name of the control.</param>
        /// <param name="IsEditable">If true the translation is in init mode, so the value is in Fallback language and the records can be add, edited or deleted.</param>
        /// <returns>Returns true it the record was found, when IsEditable was true: also if the record was inserted or updated. The Value reference returns always the value from the database.</returns>
        public bool GetSingleTranslation(ref string value, string _key, bool IsEditable = false)
        {
            string _value = string.Empty;
            tValue = value;
            tKey = _key;

            try
            {
                if (string.IsNullOrEmpty(tForm)) { throw new NullReferenceException("Missing: tForm"); }
                if (string.IsNullOrEmpty(tLang)) { throw new NullReferenceException("Missing: tLang"); }
                string[] temp = tLang.Split('-');
                if (temp.Length != 2) { throw new Exception("The language description is wrong. Form \"xx-xx\", ex.: \"en-US\""); }
                if (string.IsNullOrEmpty(tKey)) { throw new NullReferenceException("Missing: tKey"); }
                if (string.IsNullOrEmpty(Fallback)) { throw new NullReferenceException("Missing: Fallback"); }

                _value = GetSingleTranslation(tKey, tLang, tForm);

                if (string.IsNullOrEmpty(_value))
                {
                    if (IsEditable && tLang == Fallback)
                    {
                        InsertInDB(tForm, tLang, tKey, value);
                        //it's to test if the value is well stored in the database.
                        value = GetSingleTranslation(tKey, tLang, tForm);
                        return true;
                    }
                    else
                    {
                        value = string.Empty;
                        return false;
                    }
                }
                // This part was made to update the changes the developer make direct in the database but we belive it will be better
                // to edit the translation only in the language editor.
                //
                //else if (_value != value && tLang == Fallback)
                //{
                //    if (IsEditable)
                //    {
                //        UpdateDB(tForm, tLang, tKey, value);
                //        //it's to test if the value is well stored in the database.
                //        value = GetSingleTranslation(tKey, tLang, tForm);
                //        return true;
                //    }
                //    else
                //    {
                //        value = _value;
                //        return true;
                //    }
                //}
                else
                {
                    value = _value;
                    return true;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "TryGetSingleTranslation");
            }
            return false;
        }
        /// <summary>
        /// It's to get a single translation.
        /// </summary>
        /// <param name="_Key">The given key name or control.</param>
        /// <returns>The value which are stored in the database.</returns>
        public string GetSingleTranslation(string _Key)
        {
            tKey = _Key;

            try
            {
                if (string.IsNullOrEmpty(tForm)) { throw new NullReferenceException("Missing: tForm"); }
                if (string.IsNullOrEmpty(tLang)) { throw new NullReferenceException("Missing: tLang"); }
                string[] temp = tLang.Split('-');
                if (temp.Length != 2) { throw new Exception("The language description is wrong. Form \"xx-xx\", ex.: \"en-US\""); }
                if (string.IsNullOrEmpty(tKey)) { throw new NullReferenceException("Missing: tKey"); }
                if (string.IsNullOrEmpty(Fallback)) { throw new NullReferenceException("Missing: Fallback"); }

                return GetSingleTranslation(tKey, tLang, tForm);
            }
            catch (Exception ex)
            {
                HandleException(ex, "TryGetSingleTranslation");
            }
            return string.Empty;
        }
        /// <summary>
        /// It's to get a single translation.
        /// </summary>
        /// <param name="_Key">The given key name or control.</param>
        /// <param name="_Form">The name of the form the key belongs to.</param>
        /// <returns>The value which are stored in the database.</returns>
        public string GetSingleTranslation(string _Key, string _Form)
        {
            tKey = _Key;

            try
            {
                if (string.IsNullOrEmpty(tForm)) { throw new NullReferenceException("Missing: tForm"); }
                if (string.IsNullOrEmpty(tLang)) { throw new NullReferenceException("Missing: tLang"); }
                string[] temp = tLang.Split('-');
                if (temp.Length != 2) { throw new Exception("The language description is wrong. Form \"xx-xx\", ex.: \"en-US\""); }
                if (string.IsNullOrEmpty(tKey)) { throw new NullReferenceException("Missing: tKey"); }
                if (string.IsNullOrEmpty(Fallback)) { throw new NullReferenceException("Missing: Fallback"); }

                return GetSingleTranslation(tKey, tLang, _Form);
            }
            catch (Exception ex)
            {
                HandleException(ex, "TryGetSingleTranslation");
            }
            return string.Empty;
        }
        /// <summary>
        /// It's to get a single translation.
        /// </summary>
        /// <param name="_Key">The given key name or control.</param>
        /// <param name="_Lang">A CultureInfo.Name string with two letter language and two letter region code. E.g. 'en-US'.</param>
        /// <param name="_Form">The name of the form the key belongs to.</param>
        /// <remarks>_Form = "all" one key used in all forms.</remarks>
        /// <returns>The value which are stored in the database. If nothing found a system string empty.</returns>
        public string GetSingleTranslation(string _Key, string _Lang, string _Form = "all")
        {
            SqlCeCommand cmd;
            cmd = conn.CreateCommand();
            SqlCeDataReader rdr = null;
            tKey = _Key;

            try
            {
                if (string.IsNullOrEmpty(_Form)) { throw new NullReferenceException("Missing: _Form"); }
                if (string.IsNullOrEmpty(_Lang)) { throw new NullReferenceException("Missing: _Lang"); }
                string[] temp = _Lang.Split('-');
                if (temp.Length != 2) { throw new Exception("The language description is wrong. Form \"xx-xx\", ex.: \"en-US\""); }
                if (string.IsNullOrEmpty(tKey)) { throw new NullReferenceException("Missing: tKey"); }

                cmd.Parameters.Add("@tForm", System.Data.SqlDbType.NVarChar).Value = (_Form == "all") ? "all" : _Form.ToLower();
                cmd.Parameters.Add("@tLang", System.Data.SqlDbType.NVarChar).Value = _Lang.ToLower();
                cmd.Parameters.Add("@tKey", System.Data.SqlDbType.NVarChar).Value = tKey;

                cmd.CommandText = "SELECT [Value] FROM [Translate] WHERE ([Form]=@tForm) AND ([Lang]=@tLang) AND ([Key]=@tKey)";
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                rdr = cmd.ExecuteReader();
                rdr.Read();
                return (rdr == null || rdr.GetValue(0) == DBNull.Value) ? string.Empty : rdr.GetString(0);
            }
            catch (SqlCeException ex)
            {
                HandleException(ex, "TryGetSingleTranslation");
            }
            catch (Exception ex)
            {
                HandleException(ex, "TryGetSingleTranslation");
            }
            finally
            {
                if (rdr != null && !rdr.IsClosed) { rdr.Close(); }
                if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
            }
            return string.Empty;
        }
        /// <summary>
        /// It's to get a single translation.
        /// </summary>
        /// <param name="_Key">The given key name or control.</param>
        /// <param name="_Lang">A CultureInfo.Name string with two letter language and two letter region code. E.g. 'en-US'.</param>
        /// <param name="_Form">The name of the form the key belongs to.</param>
        /// <param name="_Fallback">_Fallback = "de-DE" is not realy used. We are using the "Fallback" from the settimgs.</param>
        /// <remarks>_Form = "all" one key used in all forms.</remarks>
        /// <returns>The value which are stored in the database. otherwise the value of the "Fallback". If nothing found a system string empty.</returns>
        /// <returns>A System.String with the translation or, if not found the answer is in Fallback language.</returns>
        public string GetSingleTranslation(string _Key, string _Lang, string _Form = "all", string _Fallback = "de-DE")
        {
            SqlCeCommand cmd;
            cmd = conn.CreateCommand();
            SqlCeDataReader rdr = null;
            tKey = _Key;
            tLang = _Lang;

            try
            {
                if (string.IsNullOrEmpty(tForm)) { throw new NullReferenceException("Missing: tForm"); }
                if (string.IsNullOrEmpty(tLang)) { throw new NullReferenceException("Missing: tLang"); }
                string[] temp = tLang.Split('-');
                if (temp.Length != 2) { throw new Exception("The language description is wrong. Form \"xx-xx\", ex.: \"en-US\""); }
                if (string.IsNullOrEmpty(tKey)) { throw new NullReferenceException("Missing: tKey"); }
                if (string.IsNullOrEmpty(Fallback)) { throw new NullReferenceException("Missing: Fallback"); }

                cmd.Parameters.Add("@tForm", System.Data.SqlDbType.NVarChar).Value = (_Form == "all") ? "all" : tForm.ToLower();
                cmd.Parameters.Add("@tLang", System.Data.SqlDbType.NVarChar).Value = tLang;
                cmd.Parameters.Add("@tKey", System.Data.SqlDbType.NVarChar).Value = tKey;

                    cmd.CommandText = "SELECT [Value] FROM [Translate] WHERE ([Form]=@tForm) AND ([Lang]=@tLang) AND ([Key]=@tKey)";
                    if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                    rdr = cmd.ExecuteReader();
                try
                {
                    rdr.Read();
                    return rdr.GetString(0);
                }
                catch
                {
                    if (rdr != null && !rdr.IsClosed) { rdr.Close(); }
                    if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
                    if (tLang != Fallback)
                    {
                        /// tLang = Fallback;   
                        /// is a MUST or it ever revolving...
                        /// but can not do on this way otherwise the tLang will be changed for all cals we make from now on.
                        /// So we do it on this way:
                        return GetSingleTranslation(tKey, Fallback, tForm);
                    }    
                }
            }
            catch (SqlCeException ex)
            {
                HandleException(ex, "GetSingleTranslation");
            }
            catch (Exception ex)
            {
                HandleException(ex, "GetSingleTranslation");
            }
            finally
            {
                if (rdr != null && !rdr.IsClosed) { rdr.Close(); }
                if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
            }
            return string.Empty;
        }
        /// <summary>
        /// Returns a dictonary with all keys and controls of a form stored in the database.
        /// </summary>
        /// <param name="form">The form name given by the developer.</param>
        /// <returns>A Dictonary<string, string> with DB.Key and DB.Value.</returns>
        public Dictionary<string, string> GetAllFormControls(string form)
        {
            Dictionary<string, string> AllControls = new Dictionary<string, string>();
            SqlCeCommand cmd;
            cmd = conn.CreateCommand();
            SqlCeDataReader rdr = null;

            try
            {
                int x = 0;
                cmd.Parameters.Add("@tForm", System.Data.SqlDbType.NVarChar).Value = form.ToLower();
                cmd.Parameters.Add("@tLang", System.Data.SqlDbType.NVarChar).Value = Fallback;
                cmd.CommandText = "SELECT [Key], [Value] FROM [Translate] WHERE ([Form]=@tForm) AND ([Lang]=@tLang)";
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string temp1 = rdr.GetString(0); string temp2 = rdr.GetString(1);
                    AllControls.Add(temp1, temp2);
                }
                return AllControls;
            }
            catch (SqlCeException ex)
            {
                HandleException(ex, "GetAllFormControls");
            }
            catch (Exception ex)
            {
                HandleException(ex, "GetAllFormControls");
            }
            finally
            {
                if (rdr != null && !rdr.IsClosed) { rdr.Close(); }
                if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
            }
            return null;
        }
        /// <summary>
        /// Returns a list of installed languages as System.Strings.
        /// </summary>
        /// <param name="DispName">Selectes if the list has CultureInfo.DisplayNames (when true) or CultureInfo.NativeName (if false).</param>
        /// <returns>IList<string></string></returns>
        public List<string> GetTransLanguages(bool DispName=true)
        {
            SqlCeCommand cmd;
            cmd = conn.CreateCommand();
            SqlCeDataReader rdr = null;
            List<string> langList = null;
            try
            {
                cmd.CommandText = "SELECT [Lang] FROM [Translate] WHERE ([Form]='all') AND ([Key]='Lang')";
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CultureInfo culture = new CultureInfo(rdr.GetString(0));
                    if (DispName)
                    {
                        langList.Add(culture.DisplayName);
                    }
                    else
                    {
                        langList.Add(culture.NativeName);
                    }
                }
            }
            catch (SqlCeException ex)
            {
                HandleException(ex, "GetTransLanguages");
            }
            catch (Exception ex)
            {
                HandleException(ex, "GetTransLanguages");
            }
            finally
            {
                if (rdr != null && !rdr.IsClosed) { rdr.Close(); }
                if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
            }
            return langList;
        }
        /// <summary>
        /// Returns a System.Windows.Forms.Label with a flag image and the CultureInfo.NativeName (when nativName = true).
        /// </summary>
        /// <param name="LanguageName">A two letter country-region code (CultureInfo.Name).</param>
        /// <param name="nativName">True or false.</param>
        /// <returns>System.Windows.Forms.Label</returns>
        public object[] LanguageInfo(string LanguageName, bool nativName = true)
        {
            if (string.IsNullOrEmpty(LanguageName)) { throw new Exception("Datei nicht gefunden."); }
            System.Windows.Forms.Label label = new System.Windows.Forms.Label();
            ImageList imageList = new ImageList();
            object[] test = new object[2];
            try
            {
                CultureInfo culture = new CultureInfo(LanguageName);
                string ImgName = string.Empty;
                string pfad = string.Empty;
                if (nativName)
                {
                    test[0] = culture.NativeName;
                }
                else
                {
                    test[0] = culture.DisplayName ;
                }
                pfad = Environment.CurrentDirectory + @"\flags\";
                ImgName = culture.Name.Substring(0, 2);
                ImgName = (ImgName == "en") ? "gb" : ImgName;
                pfad += ImgName + ".png";
                if (!File.Exists(pfad)) { throw new Exception("Datei nicht gefunden."); }
                //imageList.Images.Add(Image.FromFile(pfad));
                //label.ImageList = imageList;
                //label.ImageIndex = 0;

                test[1] = System.Drawing.Image.FromFile(pfad);
                //label.ImageAlign = ContentAlignment.MiddleLeft;
            }
            catch (Exception ex)
            {
                HandleException(ex, "GetTransLanguages");
            }
            return test;
        }
        /// <summary>
        /// Returns a list of installed languages as two letter country-region code.
        /// </summary>
        /// <returns>IList<string></string></returns>
        public List<string> GetTransLanguages()
        {
            SqlCeCommand cmd;
            cmd = conn.CreateCommand();
            SqlCeDataReader rdr = null;
            List<string> langList = new List<string>();
            try
            {
                cmd.CommandText = "SELECT [Lang] FROM [Translate] WHERE ([Form]='all') AND ([Key]='Lang')";
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (!string.IsNullOrEmpty(rdr.GetString(0)))
                    {
                        CultureInfo culture = new CultureInfo(rdr.GetString(0));
                        langList.Add(culture.Name);
                    }
                }
            }
            catch (SqlCeException ex)
            {
                HandleException(ex, "GetTransLanguages");
            }
            catch (Exception ex)
            {
                HandleException(ex, "GetTransLanguages");
            }
            finally
            {
                if (rdr != null &&!rdr.IsClosed) { rdr.Close(); }
                if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
            }
            return langList;
        }
        /// <summary>
        /// Removes the language record for languages (only this, don't removes the control translations! So, when the languages are add again, the translations are there again.
        /// </summary>
        /// <param name="lang">The CultureInfo.Name.</param>
        /// <returns>True if a record was deleted otherwise false.</returns>
        public bool DeleteLanguage(string lang)
        {
            int rdr = 0;
            SqlCeCommand cmd;
            cmd = conn.CreateCommand();
            try
            {
                if (string.IsNullOrEmpty(lang)) { throw new NullReferenceException("Missing: lang"); }
                cmd.Parameters.Add("@lang", System.Data.SqlDbType.NVarChar).Value = lang;
                cmd.CommandText = "DELETE FROM [Translate] WHERE ([Form]='all') AND ([Key]='Lang') AND ([Lang]=@lang)";
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                rdr = cmd.ExecuteNonQuery();
            }
            catch (SqlCeException ex)
            {
                HandleException(ex, "DeleteLanguage");
            }
            catch (Exception ex)
            {
                HandleException(ex, "DeleteLanguage");
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
            }
            return (rdr >= 1) ? true : false;
        }
        /// <summary>
        /// Deletes a single record from the table "Translate" by a given ID.
        /// </summary>
        /// <param name="ID">The System.Data.SqlDbType.Int as System.Int32 of the ID of the record.</param>
        /// <returns></returns>
        public bool DeleteRecord(int ID)
        {
            int rdr = 0;
            SqlCeCommand cmd;
            cmd = conn.CreateCommand();
            try
            {
                if (ID <= 0) { throw new Exception("Wrong ID. ID is a minus value"); }
                cmd.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = ID;
                cmd.CommandText = "DELETE FROM [Translate] WHERE ([ID]=@ID)";
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                rdr = cmd.ExecuteNonQuery();
            }
            catch (SqlCeException ex)
            {
                HandleException(ex, "DeleteRecord");
            }
            catch (Exception ex)
            {
                HandleException(ex, "DeleteRecord");
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
            }
            return (rdr >= 1) ? true : false;
        }
        /// <summary>
        /// Deletes a single record from table "Translate" by given parameters.
        /// </summary>
        /// <param name="_Form">The name of the form.</param>
        /// <param name="_Lang">The used language in the form 'xx-XX'. Exa.: 'en-US'.</param>
        /// <param name="_Key">The given key word or control name.</param>
        /// <returns>Returns true if at least one record is affected.</returns>
        public bool DeleteRecord(string _Form, string _Lang, string _Key)
        {
            int rdr = 0;
            SqlCeCommand cmd;
            cmd = conn.CreateCommand();
            tKey = _Key;
            try
            {
                if (string.IsNullOrEmpty(_Form)) { throw new NullReferenceException("Missing: _Form"); }
                if (string.IsNullOrEmpty(_Lang)) { throw new NullReferenceException("Missing: _Lang"); }
                string[] temp = _Lang.Split('-');
                if (temp.Length != 2) { throw new Exception("The language description is wrong. Form \"xx-XX\", ex.: \"en-US\""); }
                if (string.IsNullOrEmpty(tKey)) { throw new NullReferenceException("Missing: tKey"); }
                cmd.Parameters.AddWithValue("@tForm", _Form.ToLower());
                cmd.Parameters.AddWithValue("@tLang", _Lang);
                cmd.Parameters.AddWithValue("@tKey", tKey);
                cmd.CommandText = "DELETE FROM [Translate] WHERE ([Form]=@tForm) AND ([Lang]=@tLang) AND ([Key]=@tKey)";
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                rdr = cmd.ExecuteNonQuery();
            }
            catch (SqlCeException ex)
            {
                HandleException(ex, "DeleteRecord");
            }
            catch (Exception ex)
            {
                HandleException(ex, "DeleteRecord");
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
            }
            return (rdr >= 1) ? true : false;
        }
        /// <summary>
        /// Removes the key from a given form out of the table "Translate" with all translations.
        /// </summary>
        /// <param name="Key">The Key to be removed.</param>
        /// <param name="form">The form the Key belongs to.</param>
        /// <returns>True if at least one record was deleted otherwise false.</returns>
        public bool DeleteRecord(string form, string Key)
        {
            int rdr = 0;
            SqlCeCommand cmd;
            cmd = conn.CreateCommand();
            try
            {
                if (string.IsNullOrEmpty(Key)) { throw new NullReferenceException("Missing: Key"); }
                if (string.IsNullOrEmpty(form)) { throw new NullReferenceException("Missing: form"); }
                cmd.Parameters.Add("@Key", System.Data.SqlDbType.NVarChar).Value = Key;
                cmd.Parameters.Add("@form", System.Data.SqlDbType.NVarChar).Value = form.ToLower();
                cmd.CommandText = "DELETE FROM [Translate] WHERE ([Form]=@form) AND ([Key]=@Key)";
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                rdr = cmd.ExecuteNonQuery();
            }
            catch (SqlCeException ex)
            {
                HandleException(ex, "DeleteKey");
            }
            catch (Exception ex)
            {
                HandleException(ex, "DeleteKey");
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
            }
            return (rdr >= 1) ? true : false;
        }
        /// <summary>
        /// It inserts an record into the table "Translate" of the database. If the same record exists it throws an error.
        /// </summary>
        /// <param name="_Form">The name of the form.</param>
        /// <param name="_Lang">The used language in the form 'xx-XX'. Exa.: 'en-US'.</param>
        /// <param name="_Key">The given key word or control name.</param>
        /// <param name="_Value">The string to store in the database.</param>
        /// <returns>True if the record was well stored in the database.</returns>
        public bool InsertInDB(string _Form, string _Lang, string _Key, string _Value)
        {
            SqlCeCommand cmd;
            cmd = conn.CreateCommand();
            tKey = _Key;
            tValue = _Value;
            try
            {
                if (string.IsNullOrEmpty(_Form)) { throw new NullReferenceException("Missing: _Form"); }
                if (string.IsNullOrEmpty(_Lang)) { throw new NullReferenceException("Missing: _Lang"); }
                string[] temp = _Lang.Split('-');
                if (temp.Length != 2) { throw new Exception("The language description is wrong. Form \"xx-XX\", ex.: \"en-US\""); }
                if (string.IsNullOrEmpty(tKey)) { throw new NullReferenceException("Missing: tKey"); }
                if (string.IsNullOrEmpty(tValue)) { throw new NullReferenceException("Missing: tValue"); }
                if (GetSingleTranslation(_Key, _Lang, _Form) != string.Empty)
                {
                    throw new Exception("This record allrady exists!");
                }

                cmd.Parameters.AddWithValue("@tForm", _Form.ToLower());
                cmd.Parameters.AddWithValue("@tLang", _Lang);
                cmd.Parameters.AddWithValue("@tKey", tKey);
                cmd.Parameters.AddWithValue("@tValue", tValue);
                cmd.CommandText = "INSERT INTO [Translate] ([Form], [Lang], [Key], [Value]) ";
                //cmd.CommandText += string.Format();
                cmd.CommandText += "VALUES (@tForm, @tLang, @tKey, @tValue)";
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                var result = cmd.ExecuteNonQuery();
                return (result > 0);
            }
            catch (SqlCeException ex)
            {
                HandleException(ex, "InsertInDB");
            }
            catch (Exception ex)
            {
                HandleException(ex, "InsertInDB");
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
            }
            return false;
        }
        /// <summary>
        /// It makes an update of a record in the database table "Translate".
        /// </summary>
        /// <param name="_Form">The windows form of the application.</param>
        /// <param name="_Lang">The used language in the form 'xx-XX'. Exa.: 'en-US'.</param>
        /// <param name="_Key">The key or control in the form-</param>
        /// <param name="_Value">The value of the key.</param>
        /// <returns>Returns true if the record was updated.</returns>
        public bool UpdateDB(string _Form, string _Lang, string _Key, string _Value)
        {
            SqlCeCommand cmd;
            cmd = conn.CreateCommand();
            tKey = _Key;
            tValue = _Value;
            try
            {
                if (string.IsNullOrEmpty(_Form)) { throw new NullReferenceException("Missing: _Form"); }
                if (string.IsNullOrEmpty(_Lang)) { throw new NullReferenceException("Missing: _Lang"); }
                string[] temp = _Lang.Split('-');
                if (temp.Length != 2) { throw new Exception("The language description is wrong. Form \"xx-xx\", ex.: \"en-US\""); }
                if (string.IsNullOrEmpty(tKey)) { throw new NullReferenceException("Missing: tKey"); }
                if (string.IsNullOrEmpty(tValue)) { throw new NullReferenceException("Missing: tValue"); }

                cmd.Parameters.AddWithValue("@tForm", _Form.ToLower());
                cmd.Parameters.AddWithValue("@tLang", _Lang);
                cmd.Parameters.AddWithValue("@tKey", tKey);
                cmd.Parameters.AddWithValue("@tValue", tValue);
                cmd.CommandText = "UPDATE Translate SET [Value]=@tValue WHERE ([Form]=@tForm) AND ([Lang]=@tLang) AND ([Key]=@tKey)";
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                var result = cmd.ExecuteNonQuery();
                return (result > 0);
            }
            catch (SqlCeException ex)
            {
                HandleException(ex, "UpdateDB");
            }
            catch (Exception ex)
            {
                HandleException(ex, "UpdateDB");
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
            }
            return false;
        }
        /// <summary>
        /// Returns a dataset with all records of the table "Translate".
        /// </summary>
        /// <returns>System.Data.DataSet</returns>
        public DataSet GetAllTranslations()
        {
            SqlCeCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM [Translate] ORDER BY [Form], [Key], [Lang]";
            DataSet dataSet = new DataSet("Translate");
            try
            {
                SqlCeDataAdapter adapter = new SqlCeDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (SqlCeException ex)
            {
                HandleException(ex, "GetAllTranslations");
            }
            catch (Exception ex)
            {
                HandleException(ex, "GetAllTranslations");
            }
            return dataSet;
        }
        /// <summary>
        /// Returns a dataset of all records of the table "Translate" by a given language.
        /// </summary>
        /// <param name="_lang">The used language in the form 'xx-XX'. Exa.: 'en-US'.</param>
        /// <returns>System.Data.DataSet.</returns>
        public DataSet GetTranslationByLang(string _lang)
        {
            SqlCeCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM [Translate] WHERE ([lang]='" + _lang + "') ORDER BY [Form], [Key]";
            DataSet dataSet = new DataSet("Translate");
            try
            {
                SqlCeDataAdapter adapter = new SqlCeDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            catch (SqlCeException ex)
            {
                HandleException(ex, "GetTranslationByLang");
            }
            catch (Exception ex)
            {
                HandleException(ex, "GetTranslationByLang");
            }
            return dataSet;
        }
        /// <summary>
        /// It writes an dataset to a selected file in XML formate.
        /// </summary>
        /// <param name="dsData">A System.Data.DataSet.</param>
        /// <param name="FileName">A path and filename to write the file to (if existe it will be overwritten).</param>
        public void CreateXmlFromDataSet(DataSet dsData, string FileName)
        {
            try
            {
                dsData.Tables[0].WriteXml(FileName);
            }
            catch (Exception ex)
            {
                HandleException(ex, "CreateXmlFromDataSet");
            }
        }
        /// <summary>
        /// In the moment we don't know what we shell do with the error handling. So we created a method to build a case for it.
        /// </summary>
        /// <param name="ex">The excepation we got.</param>
        /// <param name="at">The method (function) where we got the exception.</param>
        private static void HandleException(Exception ex, string at)
        {
            string a = ex.Message;
            string b = at;
        }

    }
}
