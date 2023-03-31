using System.ComponentModel.DataAnnotations;

namespace ChapterAPI.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Senha Obrigatória")]
        public string Senha { get; set; }
    }
}
