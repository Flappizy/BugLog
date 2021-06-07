using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Buglog.Model;
using Buglog.Dto;
using System.Threading.Tasks;

namespace Buglog
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Project, ProjectDto>();
            CreateMap<Member, MemberDto>();
        }
    }
}
