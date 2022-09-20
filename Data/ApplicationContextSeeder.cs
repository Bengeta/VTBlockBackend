using VecoBackend.Data;

namespace VTBlockBackend.Data;

public class ApplicationContextSeeder
{
    private readonly ApplicationContext _applicationContext;

    public ApplicationContextSeeder(ApplicationContext _applicationContext)
    {
        this._applicationContext = _applicationContext;
    }

    public void Seed(string SecretKey, string Issuer, string Audience)
    {
        _applicationContext.SaveChanges();
    }
}