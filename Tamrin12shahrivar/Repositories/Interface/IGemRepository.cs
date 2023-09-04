using Tamrin12shahrivar.Model;
using Tamrin12shahrivar.Model.Dto;

namespace Tamrin12shahrivar.Repositories.Interface
{
    public interface IGemRepository
    {
        Task<List<Gem>> GetAllAsync();

        Task<Gem> GetByIdAsync(Guid id);

        Task<Gem> CreateAsync(Gem gem);

        Task<Gem> DeleteByAsync(Guid id);

        Task<Gem> UpdateAsync(Guid Id, Gem gem);

        Task<GemProfitDto?> ReportAsync();

    }
}
