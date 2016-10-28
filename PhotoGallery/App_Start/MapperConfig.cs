using AutoMapper;
using PhotoGallery.Domain;
using PhotoGallery.Models;
using PhotoGallery.Services.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoGallery.App_Start
{
    public static class MapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Photo, PhotoDto>();
                cfg.CreateMap<Album, AlbumDto>().ForMember(ptoperty => ptoperty.Photos, opt => opt.Ignore());
                cfg.CreateMap<CreatePhotoViewModel, Photo>();
            });
        }   
    }
}