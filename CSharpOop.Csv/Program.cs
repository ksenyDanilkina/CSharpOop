using System.IO;

namespace CSharpOop.Csv
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("CSV.txt"))
            {
                using (StreamWriter writer = new StreamWriter("HTML.txt"))
                {
                    string currentFileLine;

                    writer.WriteLine("<table>");

                    bool isLineBreak = false;

                    while ((currentFileLine = reader.ReadLine()) != null)
                    {
                        for (int i = 0; i < currentFileLine.Length; i++)
                        {
                            if (i == 0 && currentFileLine[i] != '"')
                            {
                                if (isLineBreak)
                                {
                                    writer.Write(currentFileLine[i]);

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
                                writer.Write("<td>" + currentFileLine[i]);

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

                                writer.WriteLine(currentFileLine[i] + "</td>");
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
                                        writer.Write(currentFileLine[j] + "<br/>");
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

                                    writer.Write(currentFileLine[j]);                                                                   
                                }
                            }
                            else
                            {
                                writer.Write(currentFileLine[i]);
                            }
                        }
                    }

                    writer.Write("</table>");
                }
            }
        }
    }
}