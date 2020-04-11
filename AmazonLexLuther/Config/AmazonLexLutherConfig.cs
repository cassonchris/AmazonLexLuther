using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonLexLuther.Config
{
    public class AmazonLexLutherConfig
    {
        public string CognitoPoolId { get; set; }
        public string BotName { get; set; }
        public string Role { get; set; }
        public string BotAlias { get; set; }
        public string BotRegion { get; set; }
    }
}
