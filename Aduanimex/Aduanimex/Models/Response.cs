namespace Aduanimex.Models
{
    public class Response
    {
        #region Atributos
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
        public LoginModel Usuario { get; set; }
        #endregion
    }
}
