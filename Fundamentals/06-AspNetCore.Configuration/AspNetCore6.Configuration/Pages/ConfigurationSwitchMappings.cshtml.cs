using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCore6.Configuration.Pages
{
    public class ConfigurationSwitchMappingsModel : PageModel
    {
        private readonly IConfiguration Config;
        public ConfigurationSwitchMappingsModel(IConfiguration configuration)
        {
            Config = configuration;
        }
        public ContentResult OnGet()
        {
            return Content(
                    $"Key1: '{Config["Key1"]}'\n" +
                    $"Key2: '{Config["Key2"]}'\n" +
                    $"Key3: '{Config["Key3"]}'\n" +
                    $"Key4: '{Config["Key4"]}'\n" +
                    $"Key5: '{Config["Key5"]}'\n" +
                    $"Key6: '{Config["Key6"]}'");
        }
    }
}
