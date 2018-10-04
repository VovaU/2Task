using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApplication7.Models;
using WebApplication7.ViewModels;

namespace WebApplication7.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<QuestionViewModel, Question>();

            CreateMap<TopicViewModel, Topic>()
                .ForMember(v => v.Id, opt => opt.Ignore());
        }
    }
}
