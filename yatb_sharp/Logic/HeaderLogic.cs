using yatb_sharp.Resources;
using yatb_sharp.View.Models.Header;

namespace yatb_sharp.Logic;

public class HeaderLogic
{
    private readonly IConfiguration _configuration;

    public HeaderLogic(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string CtfName => _configuration["CTF:Name"] ?? "yatb";
    public Page LogoTarget => new Page { Title = CtfName, Href = "/" };

    public List<Page> Pages => new()
    {
        new Page
        {
            Title = Yatb.Header_challenges,
            Href = "/challenges"
        },
        new Page
        {
            Title = Yatb.Header_scoreboard,
            Href = "/scoreboard"
        },
        new Page
        {
            Title = Yatb.Header_about,
            Href = "/about"
        }
    };
}