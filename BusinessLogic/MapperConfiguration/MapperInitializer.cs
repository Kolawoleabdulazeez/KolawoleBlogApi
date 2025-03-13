using AutoMapper;
using Domain.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.MapperConfiguration
{
    public class MapperInitializer : Profile
    {

        public MapperInitializer()
        {
            CreateMap<Post, CreatePostDto>().ReverseMap();
            CreateMap<Post, UpdatePost>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, LoginRequestDto>().ReverseMap();
            CreateMap<User, GetUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
            CreateMap<Like, LikesDto>().ReverseMap();
            CreateMap<Comment, MakeCommentsDto>().ReverseMap();
            CreateMap<Comment, UpdateComment>().ReverseMap();
            CreateMap<User, JwtUser>().ReverseMap();
            CreateMap<Post, GetListOfPosts>().ReverseMap();
             
            CreateMap<Post, GetPostDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Author.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Author.LastName))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments)) // Map Comments
                .ForMember(dest => dest.LikeCount, opt => opt.MapFrom(src => src.Likes.Count));


            CreateMap<Like, GetLikes>()
                .ForMember(dest => dest.PostTitle, opt => opt.MapFrom(src => src.Post.Title));

            CreateMap<Comment, GetCommentsDto>()
            .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content));


        }
    }
}
