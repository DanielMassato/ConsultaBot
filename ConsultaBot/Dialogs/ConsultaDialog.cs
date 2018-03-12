using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System.Net.Http;

namespace ConsultaBot.Dialogs
{
    [Serializable]
    [LuisModel("a6311072-3684-465c-bc90-dd305ebca08f", "2b348655d3c44d1794a88c6e8fbf207c")]
    public class ConsultaDialog : LuisDialog<object>
    {
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"Desculpe, não consegui entender a frase");
        }


        [LuisIntent("Sobre")]
        public async Task Sobre(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"Eu sou um bote e estou sempre aprendendo");
        }

        [LuisIntent("Cumprimento")]
        public async Task Cumprimento(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"Eu sou um bote e estou sempre aprendendo");
        }

        [LuisIntent("Preparo")]
        public async Task Preparo(IDialogContext context, LuisResult result)
        {
            var endpoint = $"https://consultarexames20180227092808.azurewebsites.net/{result.Query}";

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(endpoint);
                if (!response.IsSuccessStatusCode)
                {
                    await context.PostAsync("Ocorreu algum erro... tente mais tarde");
                    return;
                }
                else
                {
                    var resposta = await response.Content.ReadAsStringAsync();
                }
            }

                await context.PostAsync($"Bom dia qual o exame pretendido");
        }

        [LuisIntent("Agendamento")]
        public async Task Agendamento(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"Qual a data para o agendamento");
        }
    }
}