using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FenBaoApiTest.Dtos;
using FenBaoApiTest.Models;

namespace FenBaoApiTest.ProFiles
{
    public class CommentProfile:Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentDto>();
            CreateMap<CommentCreateDto, Comment>();
            CreateMap<Comment, CommentCreateDto>();
        }
    }
}
