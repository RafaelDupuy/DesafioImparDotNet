using AutoMapper;
using DesafioImpar.Application.ViewModels.Photo;
using DesafioImpar.Domain.Models;

namespace DesafioImpar.Application.Profiles
{
    public class PhotoProfile : Profile
    {
        public PhotoProfile()
            => CreateMap<Photo, PhotoViewModel>();
    }
}
