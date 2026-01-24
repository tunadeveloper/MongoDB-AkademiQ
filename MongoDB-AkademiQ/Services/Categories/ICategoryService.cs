using MongoDB_AkademiQ.DTOs.CategoryDTOs;
using MongoDB_AkademiQ.Entities;
using MongoDB_AkademiQ.Services.Generic;

namespace MongoDB_AkademiQ.Services.Categories;

public interface ICategoryService : IGenericService<Category, CreateCategoryDTO, UpdateCategoryDTO, ResultCategoryDTO>
{
}
