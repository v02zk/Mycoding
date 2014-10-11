using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Word;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication2
{
    class HandleDocument
    {
        static object unknow = Type.Missing;
        static Object readOnly = true;
        static Object isVisibale = false;
        static  Object saveChanges = false;

        public Document openDocument(string filepath,ApplicationClass word)
        {
            Object filename = filepath;

            return word.Documents.Open(ref filename, ref unknow,
                        ref unknow, ref unknow, ref unknow, ref unknow,
                       ref unknow, ref unknow, ref unknow, ref unknow, ref unknow,
                       ref unknow, ref unknow, ref unknow, ref unknow, ref unknow);
        }

        public Dictionary<string, List<TermContainer>> getTestTextDocTOC(Document doc,ApplicationClass app)
        {
            generateTOC(doc,app);
            Range tocRange = doc.TablesOfContents[1].Range;  
            string[] tocContents = delimiterTOC(tocRange.Text);
           
            Dictionary<string, List<TermContainer>> dict = new Dictionary<string, List<TermContainer>>();
            string chapter = "";
            string section = "";
            
            foreach (string s in tocContents)
            {
                if (isLevelChapter(s))
                {
                     chapter = s;
                     dict.Add(s, new List<TermContainer>());
                }
                else
                {
                     if (isLevelSection(s))
                     {
                         section = s;
                     }
                     else
                     {
                         TermContainer term = new TermContainer(section, s, null);
                         dict[chapter].Add(term);
                     }
                }
                
            }
            return dict;
        }

        public Dictionary<string, List<TermContainer>> getTestSpecificationDocTOC(Document doc, ApplicationClass app)
        {
            generateTOC(doc, app);
            Range tocRange = doc.TablesOfContents[1].Range;
            string[] tocContents = delimiterTOC(tocRange.Text);

            Dictionary<string, List<TermContainer>> dict = new Dictionary<string, List<TermContainer>>();
            string chapter = "";

            foreach (string s in tocContents)
            {
                if (isLevel1(s))
                {
                    chapter = s;
                    dict.Add(s, new List<TermContainer>());
                }
                else
                {
                    if (isLevel2(s))
                    {
                        TermContainer term = new TermContainer("", s, null);
                        dict[chapter].Add(term);
                    }
                }

            }
            return dict;
        }

        private bool isLevel1(string s)
        {
            if (!s.Contains("."))
                return true;
            return false;
        }

        private bool isLevel2(string s)
        {
            if (s.LastIndexOf(".") == 1 || s.LastIndexOf(".") == 2)
                return true;
            return false;
        }

        private string[] delimiterTOC(string tocText)
        {
            string strDelimiters = "\r";
            char[] a_charDelimiter = strDelimiters.ToCharArray();
            string strTOC = tocText.TrimEnd(a_charDelimiter);
            string[] contents = strTOC.Split(a_charDelimiter);
            return contents;
        }

        /*
        * if row is Level 1 ==> 判断显示章的行
        */
        private bool isLevelChapter(string s)
        {
            if (s.Contains("第") && s.Contains("章"))
                return true;
            return false;
        }

        /*
         * if row is Level section ==> 判断显示节的行
         */
        private bool isLevelSection(string s)
        {
            if (s.Contains("节") && s.Contains("第"))
                return true;
            return false;
        }

        public void generateTOC(Document doc, ApplicationClass app)
        {
            Object oMissing = System.Reflection.Missing.Value;  
            Object oTrue = true;  
            Object oFalse = false;  
            Object oUpperHeadingLevel = "1";  
            Object oLowerHeadingLevel = "3";  
            Object oTOCTableID = "TableOfContents";  
     
            app.Selection.Start = 0;  
            app.Selection.End = 0;//将光标移动到文档开始位置  
            object beginLevel = 2;//目录开始深度  
            object endLevel = 2;//目录结束深度  
 
            object rightAlignPageNumber = true;// 指定页码右对其  

            doc.TablesOfContents.Add(app.Selection.Range, ref oTrue, ref oUpperHeadingLevel,  
                ref oLowerHeadingLevel, ref oMissing, ref oTOCTableID, ref oTrue,  
                ref oTrue, ref oMissing, ref oTrue, ref oTrue, ref oTrue);
        }

        public Dictionary<string, List<string>> generateSpecificationRegTOC(string filepath)
        {
            ApplicationClass app = new ApplicationClass();
            Document doc = new Document();
            HandleDocument handleDocument = new HandleDocument();
            doc = handleDocument.openDocument(filepath,app);

            Dictionary<string,List<string>> dict  = new Dictionary<string,List<string>>();
            int c = doc.Paragraphs.Count;
            bool isStart = false;
            string chapter = "";
            Regex regNum = new Regex("^[0-9]");
            Regex reg = new Regex(@"[\u4e00-\u9fa5]");//

            
            for (int i = 1; i <= c; i++)
            {
                string s = doc.Paragraphs[i].Range.Text;
      
                //int ccc = Convert.ToInt32(s[s.Length - 1]);
                //MessageBox.Show(ccc.ToString());

                if(s.IndexOf("第") == 0 && (s.IndexOf("章") ==  2 || s.IndexOf("章") == 3))
                {
                    isStart = true;
                }
                if (isStart)
                {
                    if (s.IndexOf("第") == 0 && (s.IndexOf("章") == 2 || s.IndexOf("章") == 3))
                    {
                        s = s.Replace("\r", "");
                        chapter = s;
                        dict.Add(s,new List<string>());
                    }
                    else if (regNum.IsMatch(s) && reg.IsMatch(s))
                    {
                        s = s.Replace("\r", "");
                        dict[chapter].Add(s);
                    }
                }
            }
            

            Object saveChanges = false;
            object unknow = Type.Missing;

            doc.Close(ref saveChanges, ref unknow, ref unknow);
            app.Quit(ref saveChanges, ref unknow, ref unknow);

            return dict;
        }
    }
}
