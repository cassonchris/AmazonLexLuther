using System.Threading.Tasks;
using Amazon.Lex.Model;

namespace AmazonLexLuther.Services
{
    public interface IAmazonLexService
    {
        Task<PostTextResponse> SendTextMsgToLex(string messageToSend, string sessionId);
    }
}