using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Evaluation.Application.ViewModels;
using Evaluation.Domain.Model.Entities;

namespace Evaluation.Application.AutoMapper
{
    public class MappingsWithReverse : Profile
    {
        public MappingsWithReverse()
        {
            CreateMap<Question, QuestionViewModel>().ReverseMap();
        }
    }
}
