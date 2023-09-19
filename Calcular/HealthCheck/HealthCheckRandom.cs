using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Calcular.HealthCheck
{
    public class HealthCheckRandom : IHealthCheck
    {
        private HttpClient _httpClient;
        
        public HealthCheckRandom(IHttpClientFactory httpClientFactory)
        {
            this._httpClient = httpClientFactory.CreateClient();
        }

        async Task<HealthCheckResult> IHealthCheck.CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            String _apiUrl = "https://economia.awesomeapi.com.br/json/last/USD-BRL";
            HttpResponseMessage response;

            try
            {
                response = await _httpClient.GetAsync(_apiUrl, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    // A resposta da API foi bem-sucedida, o que indica um estado de saúde "saudável".
                    return HealthCheckResult.Healthy("API de câmbio está respondendo corretamente.");
                    //response = await this._httpClient.GetAsync("http://httpbin.org/status/200", cancellationToken);
                }
                else
                {
                    // A resposta da API não foi bem-sucedida, o que indica um estado de saúde "não saudável".
                    return HealthCheckResult.Unhealthy("API de câmbio retornou um status de erro: " + response.StatusCode);
                    //response = await this._httpClient.GetAsync("http://httpbin.org/status/500", cancellationToken);
                }

                //return response.IsSuccessStatusCode ? HealthCheckResult.Healthy() : HealthCheckResult.Unhealthy(description: "Deu ruim na API");
            }
            catch (Exception ex)
            {
                // Ocorreu uma exceção ao acessar a API, o que indica um estado de saúde "não saudável".
                return HealthCheckResult.Unhealthy("Erro ao acessar a API de câmbio: " + ex.Message);
            }
        }
    }
}