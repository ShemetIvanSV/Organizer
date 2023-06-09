﻿using AutoMapper;
using Organizer.Domain.Entities.Lists;
using Organizer.Domain.Entities.Notes;
using Organizer.Services.Models;
using System;

namespace Organizer.Services.Mapper
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.CreateMap<Note, NoteModel>().ReverseMap();
                cfg.CreateMap<ToDoListItem, ToDoListItemModel>().ReverseMap();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;
    }
}
