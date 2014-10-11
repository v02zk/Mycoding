using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication2
{
    class KeyWordCache
    {

        public static string KEYWORD = "keyword";
        public static string REGDOC = "regdoc";
        public static string CUSTOMIZE = "customize";

        private static int CACHESIZE = 9;
        public static int KEYWORDLENGTH = 500;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filepath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filepath);


        public static List<string> getAllKeyWordCache()
        {
            List<string> result;
            StringBuilder temp = new StringBuilder(KeyWordCache.KEYWORDLENGTH);
            int re = GetPrivateProfileString(KeyWordCache.KEYWORD, "history", "", temp, KeyWordCache.KEYWORDLENGTH, filePath.KEYWORDFILEPATH);
            string t = temp.ToString();

            char[] chSplit = ",".ToCharArray();
            string[] key = t.Split(chSplit);
            result = new List<string>(key);
            result.RemoveAll(spaceContents);
            return result;
        }

        /// <summary>
        /// predicate to remove "" or null string
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static bool spaceContents(string s)
        {
            if (s == "" || s == null)
                return true;
            return false;
        }

        public static void putKeyWordInCache(string keyword,string section)
        {

            if (File.Exists(filePath.KEYWORDFILEPATH))
            {

                StringBuilder temp = new StringBuilder(KEYWORDLENGTH);
                int re = GetPrivateProfileString(section, "history", "", temp, KEYWORDLENGTH, filePath.KEYWORDFILEPATH);
                string t = temp.ToString();
                
                char[] chSplit = ",".ToCharArray();
                string[] key = t.Split(chSplit);
                
                List<string> keyList = new List<string>(key);

                if (keyList.Contains(keyword))
                {
                    if (keyword != keyList[0])
                    {                      
                        keyList.Remove(keyword);
                        keyList.Reverse();
                        keyList.Add(keyword);
                        keyList.Reverse();
                    }
                }
                else
                {
                    if (keyList.Count() == CACHESIZE)
                    {
                        keyList.Remove(keyList[CACHESIZE - 1]);
                    }
                    keyList.Reverse();
                    keyList.Add(keyword);
                    keyList.Reverse();
                }

                string value = null;
                foreach (string s in keyList)
                {
                    if (keyList.Last() != s)
                        value += s + ",";
                    else
                        value += s;
                }

                WritePrivateProfileString(section, "history", value, filePath.KEYWORDFILEPATH);

            }
        }

        public static void update(ComboBox cbx,string section)
        {
            List<string> result = getAllKeyWordCache();
            cbx.Items.Clear();
            foreach (string s in result)
            {
               cbx.Items.Add(s);
            }
           
        }
    }
}
