using System;
using System.IO;

namespace Sample
{
    public class Config
    {
        public static readonly string pathRoot = Path.GetFullPath(@"../data");
        public static readonly string templateFile = pathRoot+"/template.html";
        public static readonly string requestFile = pathRoot+"/request.json";
    }
}
