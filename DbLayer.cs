using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using System.Globalization;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace wjkYouTupe
{
    class DbLayer
    {
        public static string tForm { private get; set; }
        public static string tKey { private get; set; }
        public static string tValue { private get; set; }
        public string Fallback { get; private set; }

        public static string tLang;
        public string getLang()
        {
            return tLang;
        }
        public void setLang(string Value)
        {
            tLang = Value;
        }
        /// <summary>
        /// Store the name of the form and the language for future usw.
        /// </summary>
        /// <param name="_Form">Name of the form.</param>
        /// <param name="_Lang">The used language in the form 'xx-XX'. Exa.: 'en-US'.</param>
        /// <param name="_Fallback">If a translation can't be found the basic culture (stored in the variable 'Fallback') will be used (standard is 'de-DE' German.</param>
        public DbLayer(string _Form, string _Lang, string _Fallback = "de-DE")
        {
            tForm = _Form;
            tLang = _Lang;
            Fallback = _Fallback;
            SetConn(CreateConnection());
        }

        private static SqliteConnection conn;

        private static SqliteConnection GetConn()
        {
            return conn;
        }

        private static void SetConn(SqliteConnection value)
        {
            conn = value;
        }

        static SqliteConnection CreateConnection()
        {
            string dbPath = Environment.CurrentDirectory + @"\RessourcesDB.sqlite";
            SqliteConnection conn = new SqliteConnection(@"Data Source = " + dbPath);
            try
            {
                conn.Open();
            }
            catch { }
            return conn;
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
            tForm = _Form;

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
        /// <param name="_Lang">A CultureInfo.Name string with two letter language and two letter region code. E.g. 'en-US'.</param>
        /// <param name="_Form">The name of the form the key belongs to.</param>
        /// <remarks>_Form = "all" one key used in all forms.</remarks>
        /// <returns>The value which are stored in the database.</returns>
        public string GetSingleTranslation(string _Key, string _Lang, string _Form = "all")
        {
            SqliteCommand cmd;
            cmd = conn.CreateCommand();
            SqliteDataReader rdr = null;
            tKey = _Key;
            tForm = _Form;
            tLang = _Lang;
            int doX = 0;

            try
            {
                if (string.IsNullOrEmpty(tForm)) { throw new NullReferenceException("Missing: tForm"); }
                if (string.IsNullOrEmpty(tLang)) { throw new NullReferenceException("Missing: tLang"); }
                string[] temp = tLang.Split('-');
                if (temp.Length != 2) { throw new Exception("The language description is wrong. Form \"xx-xx\", ex.: \"en-US\""); }
                if (string.IsNullOrEmpty(tKey)) { throw new NullReferenceException("Missing: tKey"); }
                if (string.IsNullOrEmpty(Fallback)) { throw new NullReferenceException("Missing: Fallback"); }

                cmd.Parameters.Add("@tForm", SqliteType.Text).Value = tForm;
                cmd.Parameters.Add("@tLang", SqliteType.Text).Value = tLang;
                cmd.Parameters.Add("@tKey", SqliteType.Text).Value = tKey;

                do
                {
                    cmd.CommandText = "SELECT Value FROM Translate WHERE (Form=@tForm) AND (Lang=@tLang) AND (Key=@tKey)";
                    if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                    rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        break;
                    }
                    else
                    {
                        rdr.Close();
                        SqliteParameter param = new SqliteParameter("@tLang", SqliteType.Text);
                        param.Value = Fallback;
                        cmd.Parameters.RemoveAt(1);
                        cmd.Parameters.Insert(1, param);
                    }
                    doX++;
                } while (doX <= 2);
                rdr.Read();
                return (rdr.HasRows) ? rdr.GetString(0) : null;
            }
            catch (SqliteException ex)
            {
                HandleException(ex, "TryGetSingleTranslation");
            }
            catch (Exception ex)
            {
                HandleException(ex, "TryGetSingleTranslation");
            }
            finally
            {
                rdr.Close();
                if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
            }
            return string.Empty;
        }
        /// <summary>
        /// Returns a dictonary with all keys and controls of a form stored in the database.
        /// </summary>
        /// <param name="lang">A CultureInfo.Name string with two letter language and two letter region code. E.g. 'en-US'.</param>
        /// <param name="form">The form name given by the developer.</param>
        /// <returns></returns>
        public Dictionary<string, string> GetAllFormControls(string lang, string form)
        {
            Dictionary<string, string> AllControls = new Dictionary<string, string>();
            SqliteCommand cmd;
            cmd = conn.CreateCommand();
            SqliteDataReader rdr = null;

            try
            {
                int x = 0;
                cmd.Parameters.Add("@tForm", SqliteType.Text).Value = form.ToLower();
                cmd.Parameters.Add("@tLang", SqliteType.Text).Value = lang;
                cmd.CommandText = "SELECT Key, Value FROM Translate WHERE (Form=@tForm) AND (Lang=@tLang)";
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string temp1 = rdr.GetString(0); string temp2 = rdr.GetString(1);
                    AllControls.Add(temp1, temp2);
                }
            }
            catch (SqliteException ex)
            {
                HandleException(ex, "GetAllFormControls");
            }
            catch (Exception ex)
            {
                HandleException(ex, "GetAllFormControls");
            }
            finally
            {
                rdr.Close();
                if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
            }
            return AllControls;
        }
        /// <summary>
        /// Returns a list of installed languages as System.Strings.
        /// </summary>
        /// <param name="DispName">Selectes if the list has CultureInfo.DisplayNames (when true) or CultureInfo.NativeName (if false).</param>
        /// <returns>IList<string></string></returns>
        public List<string> GetTransLanguages(bool DispName=true)
        {
            SqliteCommand cmd;
            cmd = conn.CreateCommand();
            SqliteDataReader rdr = null;
            List<string> langList = null;
            try
            {
                cmd.CommandText = "SELECT Lang FROM Translate WHERE (Form='all') AND (Key='Lang')";
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
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
            }
            catch (SqliteException ex)
            {
                HandleException(ex, "GetTransLanguages");
            }
            catch (Exception ex)
            {
                HandleException(ex, "GetTransLanguages");
            }
            finally
            {
                rdr.Close();
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
            Label label = new System.Windows.Forms.Label();
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

                test[1] = Image.FromFile(pfad);
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
            SqliteCommand cmd;
            cmd = conn.CreateCommand();
            SqliteDataReader rdr = null;
            List<string> langList = new List<string>();
            try
            {
                cmd.CommandText = "SELECT Lang FROM Translate WHERE (Form='all') AND (Key='Lang')";
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        if (!string.IsNullOrEmpty(rdr.GetString(0)))
                        {
                            CultureInfo culture = new CultureInfo(rdr.GetString(0));
                            langList.Add(culture.Name);
                        }
                    }
                }
            }
            catch (SqliteException ex)
            {
                HandleException(ex, "GetTransLanguages");
            }
            catch (Exception ex)
            {
                HandleException(ex, "GetTransLanguages");
            }
            finally
            {
                rdr.Close();
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
            SqliteCommand cmd;
            cmd = conn.CreateCommand();
            try
            {
                if (string.IsNullOrEmpty(lang)) { throw new NullReferenceException("Missing: lang"); }
                cmd.Parameters.Add("@lang", SqliteType.Text).Value = lang;
                cmd.CommandText = "DELETE FROM Translate WHERE (Form='all') AND (Key='Lang') AND (Lang='@lang')";
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                rdr = cmd.ExecuteNonQuery();
            }
            catch (SqliteException ex)
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
        /// This is for developer use to try out the database.
        /// </summary>
        /// <param name="tForm">(Was given when you implemented the class.) The name of the form.</param>
        /// <param name="tLang">(Was given when you implemented the class.) The used language in the form 'xx-XX'. Exa.: 'en-US'.</param>
        /// <param name="tKey">The given key word or control name.</param>
        /// <param name="tValue">The out string which is stored in the database.</param>
        /// <returns>True if the search found a result else false.</returns>
        public bool TryGetSingleTranslation(out string _Value, string _Key, string _Form, string _Lang)
        {
            SqliteCommand cmd;
            cmd = conn.CreateCommand();
            _Value = string.Empty;
            SqliteDataReader rdr = null;

            try
            {
                if (string.IsNullOrEmpty(tForm)) { throw new NullReferenceException("Missing: _Form"); }
                if (string.IsNullOrEmpty(tLang)) { throw new NullReferenceException("Missing: _Lang"); }
                string[] temp = tLang.Split('-');
                if (temp.Length != 2) { throw new Exception("The language description is wrong. Form \"xx-xx\", ex.: \"en-US\""); }
                if (string.IsNullOrEmpty(tKey)) { throw new NullReferenceException("Missing: tKey"); }

                cmd.Parameters.Add("@tForm", SqliteType.Text).Value = _Form.ToLower();
                cmd.Parameters.Add("@tLang", SqliteType.Text).Value = _Lang;
                cmd.Parameters.Add("@tKey", SqliteType.Text).Value = _Key;

                cmd.CommandText = "SELECT Value FROM Translate WHERE Form=@tForm AND Lang=@tLang AND Key=@tKey";
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    rdr.Read();
                    _Value = rdr.GetString(0);
                    return rdr.HasRows;
                }
            }
            catch (SqliteException ex)
            {
                HandleException(ex, "TryGetSingleTranslation");
            }
            catch (Exception ex)
            {
                HandleException(ex, "TryGetSingleTranslation");
            }
            finally
            {
                rdr.Close();
                if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
            }
            return false;
        }
        /// <summary>
        /// This is for developer use to try out the database.
        /// </summary>
        /// <param name="tForm">The name of the form.</param>
        /// <param name="tLang">The used language in the form 'xx-XX'. Exa.: 'en-US'.</param>
        /// <param name="tKey">The given key word or control name.</param>
        /// <param name="tValue">The string to store in the database.</param>
        /// <returns>True if the record was well stored in the database.</returns>
        public bool InsertInDB(string tForm, string tLang, string tKey, string tValue)
        {
            SqliteCommand cmd;
            cmd = conn.CreateCommand();
            try
            {
                if (string.IsNullOrEmpty(tForm)) { throw new NullReferenceException("Missing: tForm"); }
                if (string.IsNullOrEmpty(tLang)) { throw new NullReferenceException("Missing: tLang"); }
                string[] temp = tLang.Split('-');
                if (temp.Length != 2) { throw new Exception("The language description is wrong. Form \"xx-xx\", ex.: \"en-US\""); }
                if (string.IsNullOrEmpty(tKey)) { throw new NullReferenceException("Missing: tKey"); }
                if (string.IsNullOrEmpty(tValue)) { throw new NullReferenceException("Missing: tValue"); }

                cmd.Parameters.AddWithValue("@tForm", tForm);
                cmd.Parameters.AddWithValue("@tLang", tLang);
                cmd.Parameters.AddWithValue("@tKey", tKey);
                cmd.Parameters.AddWithValue("@tValue", tValue);
                cmd.CommandText = "INSERT INTO Translate (Form, Lang, Key, Value) VALUES (@tForm, @tLang, @tKey, @tValue)";
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                var result = cmd.ExecuteNonQuery();
                return (result > 0);
            }
            catch (SqliteException ex)
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
        /// In the moment we don't know what we shell do with the error handling. So we created a method to build a case for it.
        /// </summary>
        /// <param name="ex">The excepation we got.</param>
        /// <param name="at">The method (function) where we got the exception.</param>
        private void HandleException(Exception ex, string at)
        {
            string a = ex.Message;
            string b = at;
        }

    }
}
