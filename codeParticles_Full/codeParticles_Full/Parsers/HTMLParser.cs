using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace codeParticles_Full.Parsers
{
    public class HTMLParser
    {

        public static List<List<string>> Parse(string my_html)
        {
            //string my_html = File.ReadAllText("jquery_keydown.html");

            List<string> codeLines = getLines(my_html);

            List<List<string>> htmlTags = new List<List<string>>();
            List<List<string>> attributes = new List<List<string>>();

            string[] html_patterns = { @"<(.*?)>", @"<(.*?)/>" }; //look for src attribute
            //looks for src attributes

            for (int f = 0; f < codeLines.Count; f++)
            {
                for (int c = 0; c < html_patterns.Length; c++)
                {
                    Regex regex = new Regex(html_patterns[c]);

                    var v = regex.Match(codeLines[f]);

                    if (v.Groups.Count > 1)
                    {
                        List<string> inter = new List<string>();

                        inter.Add(f.ToString());
                        inter.Add(v.Groups[1].ToString());

                        htmlTags.Add(inter);
                        attributes.Add(getAttributes(v.Groups[1].ToString()));
                    }
                }
            }

            //return attributes;
            return htmlTags;

        }


        public static List<string> getLines(string text)
        {
            List<string> lines = new List<string>();

            string[] splitter = text.Split('\r');

            for (int f = 0; f < splitter.Length; f++)
            {
                lines.Add(splitter[f]);
            }

            return lines;


        }


        public static List<string> getAttributes(string innerTag)
        {
            List<string> inter = new List<string>();

            string[] splitter = innerTag.Split(' ');

            if (splitter.Length > 1)
            {
                for (int f = 0; f < splitter.Length; f++)
                {
                    if (splitter[f].Contains('='))
                    {
                        string[] sp = splitter[f].Split('=');

                        inter.Add(sp[0]);
                        inter.Add(sp[1]);
                    }
                }
            }

            return inter;
        }



    }
}