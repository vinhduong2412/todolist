﻿using AutoMapper;
using Todo.Models;
using Todo.DTOs;

namespace Todo.Helper
{
    public class AppMapper : Profile
    {
        public AppMapper()
        {
            CreateMap<TodoTask, TodoTaskRequestDTO>().ReverseMap();
            CreateMap<User, SignUpRequestDTO>();
            CreateMap<User, SignInRequestDTO>();
            CreateMap<Category, CategoryRequestDTO>();
            CreateMap<SignUpRequestDTO, UserResponse>();
            CreateMap<SignInRequestDTO, UserResponse>();
            CreateMap<TodoTask, TodoTaskResponseDTO>().ReverseMap();
            CreateMap<TodoTask, TodoTaskRequestByIdDTO>().ReverseMap();
        }
    }
}
