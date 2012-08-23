using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dem0n13.Replacer.Library;
using System.Diagnostics;
using Dem0n13.Replacer.Library.Utils;

namespace TestConsole
{
    class Program
    {
        static void Main()
        {
            var sw = new Stopwatch();

            sw.Restart();
            var txt = new TextFile(@"C:\Temp\B1.html");
            var str = txt.ReadText();
            Console.WriteLine("new txt, read"+sw.ElapsedTicks);

            sw.Restart();
            var s = new TextReplacer(str);
            Console.WriteLine("new TextReplacer" + sw.ElapsedTicks);

            sw.Restart();
            var pat = "<span(.+?)</span>";//"#bookmark(\\d+?\")(.+?)bookmark\\1";//"<span(.+?)</span>";
            var regex = new RegexProcessor(pat);
            var rep = new Replacement(@"\1");//(@"#b\1\2b\1");//(@"12345\1=234567");
            Console.WriteLine("new regex/repl" + sw.ElapsedTicks);

            sw.Restart();
            var matches = regex.RelatedMatches(s);
            Console.WriteLine("matches" + sw.ElapsedTicks+" in ms:"+sw.Elapsed);

            sw.Reset();
            var sw1 = new Stopwatch();
            foreach (var match in matches)
            {
                sw.Start();
                var repls = rep.CreateCopyWithGroups(match);
                sw.Stop();

                sw1.Start();
                s.Replace(match, repls);
                sw1.Stop();
            }
            Console.WriteLine("replacement build " + sw.ElapsedTicks);
            Console.WriteLine("text replace" + sw1.ElapsedTicks);

            sw.Restart();
            var res = s.BuildResult();
            sw.Stop();
            Console.WriteLine("сборка"+sw.ElapsedTicks);
            Console.ReadLine();
        }
    }
}
