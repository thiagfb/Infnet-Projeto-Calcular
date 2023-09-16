using Calcular.Controllers;

namespace TestApi
{
    public class CalcularControllerTest
    {
        [Fact]
        public void DeveFazerGetComSucesso()
        {
            var controller = new CalcularController();

            var result = controller.Somar(1, 4);

            Assert.True(result != null);
        }
    }
}