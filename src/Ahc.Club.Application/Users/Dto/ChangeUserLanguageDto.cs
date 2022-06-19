using System.ComponentModel.DataAnnotations;

namespace Ahc.Club.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}