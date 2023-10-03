﻿using ShopCore.Domain;
using ShopCore.Dto;


namespace ShopCore.ServiceInterface
{
    public interface IFileServices
    {
        void FilesToApi(SpaceshipDto dto, Spaceship spaceship);

         Task<List<FileToApi>> RemoveImagesFromApi(FileToApiDto[] dtos);

        Task<FileToApi> RemoveImageFromApi(FileToApiDto dto);

        void UploadFilesToDatabase(RealEstateDto dto, RealEstate domain);


    }
}
