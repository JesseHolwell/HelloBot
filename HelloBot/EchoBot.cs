using System.Threading.Tasks;
using Microsoft.Bot;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Core.Extensions;
using Microsoft.Bot.Schema;

namespace HelloBot
{
    public class EchoBot : IBot
    {
        /// <summary>
        /// Every Conversation turn for our EchoBot will call this method. In here
        /// the bot checks the Activty type to verify it's a message, bumps the 
        /// turn conversation 'Turn' count, and then echoes the users typing
        /// back to them. 
        /// </summary>
        /// <param name="context">Turn scoped context containing all the data needed
        /// for processing this conversation turn. </param>        
        public async Task OnTurn(ITurnContext context)
        {
            // This bot is only handling Messages
            if (context.Activity.Type == ActivityTypes.Message)
            {
                // Get the conversation state from the turn context
                var state = context.GetConversationState<EchoState>();

                // Bump the turn count. 
                state.TurnCount++;

                var input = context.Activity.Text.ToLower();
                var output = "";

                if (input.Contains("help"))
                    output += $"TODO: write help definitions\n";
                else
                {
                    if (input.Contains("hi") || input.Contains("hello"))
                        output += $"Hello beautiful\n";

                    if (input.Contains("suraj"))
                        output += $"Suraj is pretty standard\n";

                    if (input.Contains("galo"))
                        output += $"Ehhh.. that dudes okay\n";

                    if (input.Contains("jesse"))
                        output += $"Jesse is one of the best programmers I've ever spoken with\n";

                    if (input.Contains("love you"))
                        output += $"I love you too\n";

                    if (output == "")
                        // Echo back to the user whatever they typed.
                        output += $"Turn {state.TurnCount}: You sent '{context.Activity.Text}'\n";
                }

                await context.SendActivity(output);
            }
        }
    }    
}
