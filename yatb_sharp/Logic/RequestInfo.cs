using yatb_sharp.Database;
using yatb_sharp.Database.Models;

namespace yatb_sharp.Logic;

public class RequestInfo
{
    private readonly IServiceScope _scope;
    private readonly IConfiguration _configuration;
    private readonly HttpContext _httpContext;
    public User? User;
    public string RemoteIp;
    private static ApplicationContext _db;

    public RequestInfo(IHttpContextAccessor contextAccessor, IServiceScopeFactory scopeFactory)
    {
        _scope = scopeFactory.CreateScope();
        _httpContext = contextAccessor.HttpContext!;
        _configuration = _scope.ServiceProvider.GetRequiredService<IConfiguration>();
        _db = _scope.ServiceProvider.GetRequiredService<ApplicationContext>();
        Init();
    }
    
    private void Init()
    {
        Guid userUid = Guid.Empty;
        Guid.TryParse(_httpContext?.Items["userUid"]?.ToString(), out userUid);
        RemoteIp = _httpContext!.Connection.RemoteIpAddress!.ToString();
        _httpContext.Items.Remove("userUid");

        if (userUid == Guid.Empty)
            return;

        User = _db.Users.FirstOrDefault(x => x.Uid == userUid);
    }
}