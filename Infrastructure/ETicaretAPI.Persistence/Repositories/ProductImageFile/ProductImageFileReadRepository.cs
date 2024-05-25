using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Persistence.Contexts;

namespace ETicaretAPI.Persistence.Repositories;

public class ProductImageFileReadRepository:ReadRepository<Domain.Entities.ProductImageFile>,IProductImageFileReadRepository
{
    public ProductImageFileReadRepository(ETicaretAPIDbContext context) : base(context)
    {
    }
}