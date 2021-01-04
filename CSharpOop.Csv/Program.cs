using System.IO;
using System;

namespace CSharpOop.Csv
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length <= 1)
            {
                Console.WriteLine("Необходимое количество аргументов = 2. Аргумент 1 - файл для чтения, аргумент 2 - файл для записи.");

                return;
            }

            try
            {
                using (StreamReader reader = new StreamReader(args[0]))
                {
                    using (StreamWriter writer = new StreamWriter(args[1]))
                    {
                        writer.WriteLine("<!DOCTYPE HTML>");
                        writer.WriteLine("<html>");
                        writer.WriteLine("<head>");
                        writer.WriteLine("<title>Таблица</title>");
                        writer.WriteLine("<meta charset=\"utf-8\">");
                        writer.WriteLine("</head>");
                        writer.WriteLine("<body>");
                        writer.WriteLine("<table>");

                        bool isLineBreak = false;
                        string currentFileLine;

                        while ((currentFileLine = reader.ReadLine()) != null)
                        {
                            for (int i = 0; i < currentFileLine.Length; i++)
                            {
                                if (i == 0 && currentFileLine[i] != '"')
                                {
                                    if (isLineBreak)
                                    {
                                        writer.Write(GetHtmlFormattedString(currentFileLine[i]));

                                        continue;
                                    }

                                    if (currentFileLine[i] == ',')
                                    {
                                        writer.WriteLine("<tr>");
                                        writer.WriteLine("<td></td>");
                                        writer.Write("<td>");

                                        continue;
                                    }

                                    writer.WriteLine("<tr>");
                                    writer.Write("<td>" + GetHtmlFormattedString(currentFileLine[i]));

                                    continue;
                                }

                                if (i == currentFileLine.Length - 1)
                                {
                                    if (currentFileLine[i] == ',')
                                    {
                                        writer.WriteLine("</td>");
                                        writer.WriteLine("<td></td>");
                                        writer.WriteLine("</tr>");

                                        break;
                                    }

                                    writer.Write(GetHtmlFormattedString(currentFileLine[i]) + "</td>");

                                    writer.WriteLine("</tr>");

                                    break;
                                }

                                if (currentFileLine[i] == ',')
                                {
                                    writer.WriteLine("</td>");
                                    writer.Write("<td>");

                                    continue;
                                }

                                if (currentFileLine[i] == '"')
                                {
                                    if (isLineBreak)
                                    {
                                        isLineBreak = false;

                                        continue;
                                    }

                                    for (int j = i + 1; j < currentFileLine.Length; j++)
                                    {
                                        if (j == 1)
                                        {
                                            writer.WriteLine("<tr>");
                                            writer.Write("<td>");
                                        }

                                        if (j == currentFileLine.Length - 1)
                                        {
                                            if (currentFileLine[j] == '"')
                                            {
                                                writer.WriteLine("</td>");
                                                writer.WriteLine("</tr>");
                                                i = j;

                                                break;
                                            }

                                            isLineBreak = true;

                                            writer.Write(GetHtmlFormattedString(currentFileLine[j]) + "<br/>");

                                            i = j;

                                            break;
                                        }

                                        if (currentFileLine[j] == '"')
                                        {
                                            if (currentFileLine[j + 1] == '"')
                                            {
                                                writer.Write("\"");
                                                j++;

                                                continue;
                                            }

                                            i = j;

                                            break;
                                        }

                                        writer.Write(GetHtmlFormattedString(currentFileLine[j]));
                                    }
                                }
                                else
                                {
                                    writer.Write(GetHtmlFormattedString(currentFileLine[i]));
                                }
                            }
                        }

                        writer.WriteLine("</table>");
                        writer.WriteLine("</body>");
                        writer.WriteLine("</html>");
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static string GetHtmlFormattedString(char c)
        {
            if (c == '<')
            {
                return "&lt;";
            }

            if (c == '>')
            {
                return "&gt;";
            }

            if (c == '&')
            {
                return "&amp;";
            }

            return c.ToString();
        }
    }
}