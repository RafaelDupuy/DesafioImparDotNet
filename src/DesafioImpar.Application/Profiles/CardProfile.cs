using AutoMapper;
using DesafioImpar.Application.ViewModels.Card;
using DesafioImpar.Domain.Models;

namespace DesafioImpar.Application.Profiles
{
    internal class CardProfile: Profile
    {
        public CardProfile()
        {
            CreateMap<Card, CardWithPhotoViewModel>();
        }
    }
}
