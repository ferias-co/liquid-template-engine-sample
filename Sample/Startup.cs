using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using DotLiquid;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sample
{
    public sealed class Startup
    {
        private readonly IDictionary<string, object> expandoDict;
        private readonly Hash hashes;
        private readonly Template template;

        public Startup() 
        {
            expandoDict = new Dictionary<string, object>( JsonExpandoObject() );
            template = Template.Parse( TemplateText() );
            hashes = Hash.FromDictionary(expandoDict);
        }

        public void Run() 
        {
            Console.Write(  template.Render(hashes) );
        }

        private ExpandoObject JsonExpandoObject() 
            => JsonConvert.DeserializeObject<ExpandoObject>(
                File.ReadAllText(Config.requestFile), new ExpandoObjectConverter()
            );
        

        private string TemplateText() 
            => File.ReadAllText(Config.templateFile);

    }
}
