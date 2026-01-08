using MongoDB_AkademiQ.DTOs.CategoryDTOs;
using MongoDB_AkademiQ.Entities;
using MongoDB_AkademiQ.Services.Generic;
using MongoDB_AkademiQ.Settings;

namespace MongoDB_AkademiQ.Services.Categories;

public class CategoryService : GenericService<Category, CreateCategoryDTO, UpdateCategoryDTO, ResultCategoryDTO>, ICategoryService
{
    public CategoryService(IDatabaseSettings databaseSettings) 
        : base(databaseSettings, databaseSettings.CategoryCollection)
    {
    }

    protected override Category MapToEntity(CreateCategoryDTO createDTO)
    {
        return new Category
        {
            Name = createDTO.Name,
            ImageUrl = createDTO.ImageUrl,
            Description = createDTO.Description
        };
    }

    protected override Category MapToEntity(UpdateCategoryDTO updateDTO)
    {
        return new Category
        {
            Id = updateDTO.Id,
            Name = updateDTO.Name,
            ImageUrl = updateDTO.ImageUrl,
            Description = updateDTO.Description
        };
    }

    protected override ResultCategoryDTO MapToResultDTO(Category entity)
    {
        return new ResultCategoryDTO
        {
            Id = entity.Id,
            Name = entity.Name,
            ImageUrl = entity.ImageUrl,
            Description = entity.Description
        };
    }

    protected override UpdateCategoryDTO MapToUpdateDTO(Category entity)
    {
        return new UpdateCategoryDTO
        {
            Id = entity.Id,
            Name = entity.Name,
            ImageUrl = entity.ImageUrl,
            Description = entity.Description
        };
    }

    protected override string GetIdFromUpdateDTO(UpdateCategoryDTO updateDTO)
    {
        return updateDTO.Id;
    }
}