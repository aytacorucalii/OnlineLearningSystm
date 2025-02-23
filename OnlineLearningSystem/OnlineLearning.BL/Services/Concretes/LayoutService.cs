using OnlineLearning.BL.Services.Abstractions;
using OnlineLearning.DAL.Contexts;

namespace OnlineLearning.BL.Services.Concretes;

public class LayoutService: ILayoutService
{
    AppDbContext _dbContext;

    public LayoutService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Dictionary<string, string> GetSettings()
    {
        return _dbContext.Settings.ToDictionary(s => s.Key, s => s.Value);
    }
}