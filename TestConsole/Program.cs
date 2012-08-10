using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dem0n13.Replacer.Library;
using System.Diagnostics;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var rep = new Replacement("\\3\\*m\r\n.*?12\\3");
            
            /*var sw = new Stopwatch();

            sw.Restart();
            var txt = new TextFile(@"C:\index.html");
            var str = txt.ReadText();
            Console.WriteLine("new txt, read"+sw.ElapsedTicks);

            sw.Restart();
            var s = new LazyStringBuilder(str);
            Console.WriteLine("lsb" + sw.ElapsedTicks);

            sw.Restart();
            var pat = "<span(.+?)</span>";
            var regex = new ReplacerLazyLib.RegexProcessor(pat);
            var rep = new ReplacerLazyLib.Replacement(@"12345\1=234567");
            Console.WriteLine("regex/repl" + sw.ElapsedTicks);

            sw.Restart();
            var matches = regex.Matches(s);
            Console.WriteLine("matches" + sw.ElapsedTicks);

            sw.Reset();
            var sw1 = new Stopwatch();
            foreach (var match in matches)
            {
                sw.Start();
                var repstr = rep.BuildToLazyString(match);
                sw.Stop();

                sw1.Start();
                s.Replace(match, repstr);
                sw1.Stop();
            }
            Console.WriteLine("replacement build " + sw.ElapsedTicks);
            Console.WriteLine("text replace" + sw1.ElapsedTicks);

            sw.Restart();
            var res = s.BuildToString();
            sw.Stop();
            Console.WriteLine("сборка"+sw.ElapsedTicks);
            Console.ReadLine();*/
            var s = rep;
        }
    }
}
