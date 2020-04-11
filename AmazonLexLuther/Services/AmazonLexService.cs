using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.CognitoIdentity;
using Amazon.Lex;
using Amazon.Lex.Model;
using Amazon.Runtime;
using AmazonLexLuther.Config;
using Microsoft.Extensions.Options;

namespace AmazonLexLuther.Services
{
    public class AmazonLexService : IAmazonLexService
    {
        private readonly AmazonLexLutherConfig _amazonLexConfig;
        private readonly AmazonLexClient _amazonLexClient;

        public AmazonLexService(IOptions<AmazonLexLutherConfig> amazonLexOptions)
        {
            _amazonLexConfig = amazonLexOptions.Value;

            var regionEndpoint = Amazon.RegionEndpoint.GetBySystemName(_amazonLexConfig.BotRegion);

            var awsCredentials = new CognitoAWSCredentials(_amazonLexConfig.CognitoPoolId, regionEndpoint);

            _amazonLexClient = new AmazonLexClient(awsCredentials, regionEndpoint);
        }

        public async Task<PostTextResponse> SendTextMsgToLex(string messageToSend, string sessionId)
        {
            var textRequest = new PostTextRequest
            {
                BotName = _amazonLexConfig.BotName,
                BotAlias = _amazonLexConfig.BotAlias,
                UserId = sessionId,
                InputText = messageToSend
            };
            var response = await _amazonLexClient.PostTextAsync(textRequest);
            return response;
        }
    }
}
