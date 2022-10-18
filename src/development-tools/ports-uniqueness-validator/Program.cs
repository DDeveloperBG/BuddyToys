using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using System.Text.RegularExpressions;

namespace Clone_whole_Word_document
{
    class Program
    {
        static void Main()
        {
            string filePath = @"../../../../../../architecture/network-ports/busy-ports.docx";

            string portsText = ReadPortsContainingWordFile(filePath);

            List<int> ports = SplitPortsText(portsText);

            Console.WriteLine(PortsAreUnique(ports));
            Console.ReadLine();
        }

        static string ReadPortsContainingWordFile(string filePath)
        {
            using FileStream fileStreamPath = new FileStream(
                Path.GetFullPath(filePath),
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read);

            using WordDocument document = new WordDocument(fileStreamPath, FormatType.Automatic);

            return document.GetText();
        }

        static List<int> SplitPortsText(string text)
        {
            Regex portsRegex = new Regex(@"(\r){0,1}\n\d+(-\d+){0,1}:");
            var portsTexts = portsRegex.Matches(text);

            List<int> ports = new List<int>();
            Regex numbersRegex = new Regex(@"\d+");

            foreach (Match portsText in portsTexts)
            {
                var matches = numbersRegex.Matches(portsText.Value);

                int fromPort = int.Parse(matches[0].Value);

                if (matches.Count == 2)
                {
                    int toPort = int.Parse(matches[1].Value);

                    if (fromPort > toPort)
                    {
                        throw new ArgumentException($"In {portsText.Value} range is incorrect!");
                    }

                    for (int port = fromPort; port <= toPort; port++)
                    {
                        ports.Add(port);
                    }
                }
                else
                {
                    ports.Add(fromPort);
                }
            }

            return ports;
        }

        static bool PortsAreUnique(List<int> ports)
        {
            return ports.Count == ports.ToHashSet().Count;
        }
    }
}