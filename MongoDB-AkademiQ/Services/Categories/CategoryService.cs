using MongoDB_AkademiQ.DTOs.CategoryDTOs;
using MongoDB_AkademiQ.Entities;
using MongoDB_AkademiQ.Services.Generic;
using MongoDB_AkademiQ.Settings;

namespace MongoDB_AkademiQ.Services.Categories;

public class CategoryService : GenericService<Category, CreateCategoryDTO, UpdateCategoryDTO, ResultCategoryDTO>, ICategoryService
{
    public CategoryService(IDatabaseSettings settings) : base(settings, settings.CategoryCollection)
    {
    }

    protected override Category MapToEntity(CreateCategoryDTO dto)
    {
        return new Category
        {
            Name = dto.Name,
            Description = dto.Description,
            ImageUrl = dto.ImageUrl
        };
    }

    protected override Category MapToEntity(UpdateCategoryDTO dto)
    {
        return new Category
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description,
            ImageUrl = dto.ImageUrl
        };
    }

    protected override ResultCategoryDTO MapToResultDTO(Category entity)
    {
        return new ResultCategoryDTO
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            ImageUrl = entity.ImageUrl
        };
    }

    protected override UpdateCategoryDTO MapToUpdateDTO(Category entity)
    {
        return new UpdateCategoryDTO
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            ImageUrl = entity.ImageUrl
        };
    }

    protected override string GetIdFromUpdateDTO(UpdateCategoryDTO dto)
    {
        return dto.Id;
    }
}
