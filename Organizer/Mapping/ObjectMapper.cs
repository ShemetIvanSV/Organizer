using AutoMapper;
using Organizer.Models.Lists;
using Organizer.Models.Notes;
using Organizer.Services.Models;
using System;

namespace Organizer.Mapping
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.CreateMap<NoteModel, NoteVm>().ReverseMap();
                cfg.CreateMap<ToDoListItemModel, ToDoListItemVm>().ReverseMap();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;
    }
}
