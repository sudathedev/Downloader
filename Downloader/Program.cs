using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;

namespace Downloader
{
    class Program
    {
        
      readonly static Uri SomeBaseUri = new Uri("http://sudaox");

        static string GetFileNameFromUrl(string url)
        {
            Uri uri;
            if (!Uri.TryCreate(url, UriKind.Absolute, out uri))
                uri = new Uri(SomeBaseUri, url);

            return Path.GetFileName(uri.LocalPath);
        }
        static void Main(string[] args)
        {
                            foreach (String arg in Environment.GetCommandLineArgs())
                {
                    try
                    {
                        if (arg.Substring(0, 5) == "--url")
                        {
                            string url = arg.Substring(6);
                            string filename = GetFileNameFromUrl(url);
                            Console.WriteLine("Downloading " + url + " as " + filename + "...");
                            try
                            {
                                using (var client = new WebClient())
                                {
                                    client.DownloadFile(url, filename);
                                }
                                Console.WriteLine("Downloaded file " + filename + " successfully.");
                            }
                            catch(WebException err)
                            {
                                Console.Write("An error occcurred while downloading: " + err.Message);
                            }
                        }
                    }
                    catch
                    {
                    }
                }  

            }
        }
    }