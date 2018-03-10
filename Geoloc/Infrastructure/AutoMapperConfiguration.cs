﻿using AutoMapper;
using Geoloc.Data.Entities;
using Geoloc.Models;
using Geoloc.Models.WebModels;

namespace Geoloc.Infrastructure
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<LocationWebModel, LocationModel>()
                .ForMember(x => x.Timestamp, o => o.Ignore());

            CreateMap<LocationModel, Location>()
                .ForMember(x => x.Id, o => o.Ignore())
                .ForMember(x => x.AppUser, o => o.Ignore())
                .ForMember(x => x.AppUserId, o => o.MapFrom(s => s.User.Id))
                .ForMember(x => x.CreatedOn, o => o.MapFrom(s => s.Timestamp));

            CreateMap<LocationModel, LocationWebModel>();

            CreateMap<Location, LocationModel>()
            
            CreateMap<RegisterWebModel, AppUser>()
                .ForMember(x => x.UserName, o => o.MapFrom(s => s.Email))
                .ForAllOtherMembers(o => o.Ignore());
                .ForMember(x => x.User, o => o.MapFrom(s => s.AppUser))
                .ForMember(x => x.Timestamp, o => o.MapFrom(s => s.CreatedOn));

            CreateMap<UserRelation, UserRelationWebModel>()
                .ForMember(x => x.Id, o => o.MapFrom(s => s.Id))
                .ForMember(x => x.InvitingUserName, o => o.MapFrom(s => s.InvitingUser.UserName))
                .ForMember(x => x.InvitedUserName, o => o.MapFrom(s => s.InvitedUser.UserName))
                .ForMember(x => x.Status, o => o.MapFrom(s => s.UserRelationStatus))
                .ForAllOtherMembers(o => o.Ignore());
        }
    }
}