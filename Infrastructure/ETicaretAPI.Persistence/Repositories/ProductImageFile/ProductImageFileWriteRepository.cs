﻿using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Persistence.Contexts;

namespace ETicaretAPI.Persistence.Repositories;

public class ProductImageFileWriteRepository:WriteRepository<Domain.Entities.ProductImageFile>,IProductImageFileWriteRepository
{
    public ProductImageFileWriteRepository(ETicaretAPIDbContext context) : base(context)
    {
    }
}