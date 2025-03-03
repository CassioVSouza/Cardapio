namespace Cardapio.ApiService.Exceptions
{
    public class ErroUsuarioJaExiste : Exception
    {
        public ErroUsuarioJaExiste(string message) : base(message)
        {
        }
    }
}
