using System.ComponentModel.DataAnnotations;

namespace Chapter.WebApi.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o email")]
        public string email { get; set; }
        [Required(ErrorMessage = "Informe a senha")]
        public string senha { get; set; }
    }
}
