using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using DotLiquid;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sample
{
    class Program
    {

        public static readonly string pathRoot = Path.GetFullPath(@"../data");
        public static readonly string templateFile = pathRoot+"/template.html";
        public static readonly string requestFile = pathRoot+"/request.json";

        static void Main(string[] args) {

            IDictionary<string, object> expandoDict = new Dictionary<string, object>(JsonExpandoObject());


            Hash hashes = Hash.FromDictionary(expandoDict);
            
            Template template = Template.Parse( TemplateText() );
            string template_rendered = template.Render(hashes);

            Console.Write( template_rendered );
        }

        public static ExpandoObject JsonExpandoObject() 
            => JsonConvert.DeserializeObject<ExpandoObject>(
                File.ReadAllText(requestFile), new ExpandoObjectConverter()
            );
        

        public static string TemplateText() 
            => File.ReadAllText(templateFile);
        


    }
}
