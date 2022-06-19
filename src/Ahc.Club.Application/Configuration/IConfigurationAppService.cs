using System.Threading.Tasks;
using Ahc.Club.Configuration.Dto;

namespace Ahc.Club.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
