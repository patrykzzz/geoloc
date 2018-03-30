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
            #region User

            CreateMap<RegisterWebModel, AppUser>()
                .ForMember(x => x.UserName, o => o.MapFrom(s => s.Email))
                .ForMember(x => x.Email, o => o.MapFrom(s => s.Email))
                .ForAllOtherMembers(o => o.Ignore());

            #endregion

            #region Location

            CreateMap<LocationModel, Location>()
                .ForMember(x => x.Id, o => o.Ignore())
                .ForMember(x => x.AppUser, o => o.Ignore())
                .ForMember(x => x.AppUserId, o => o.MapFrom(s => s.User.Id))
                .ForMember(x => x.CreatedOn, o => o.MapFrom(s => s.Timestamp));

            CreateMap<Location, LocationModel>()
                .ForMember(x => x.Id, o => o.MapFrom(s => s.Id))
                .ForMember(x => x.User, o => o.MapFrom(s => s.AppUser))
                .ForMember(x => x.Timestamp, o => o.MapFrom(s => s.CreatedOn));

            CreateMap<LocationModel, LocationWebModel>()
                .ForMember(x => x.Latitude, o => o.MapFrom(s => s.Latitude))
                .ForMember(x => x.Longitude, o => o.MapFrom(s => s.Longitude))
                .ForMember(x => x.UserId, o => o.MapFrom(s => s.User.Id))
                .ForMember(x => x.Username, o => o.MapFrom(s => s.User.UserName));

            #endregion

            #region UserRelation

            CreateMap<UserRelation, UserRelationModel>()
                .ForMember(x => x.Id, o => o.MapFrom(s => s.Id))
                .ForMember(x => x.InvitingUser, o => o.MapFrom(s => s.InvitingUser))
                .ForMember(x => x.InvitedUser, o => o.MapFrom(s => s.InvitedUser))
                .ForMember(x => x.UserRelationStatus, o => o.MapFrom(s => s.UserRelationStatus))
                .ForAllOtherMembers(o => o.Ignore());

            CreateMap<UserRelationModel, UserRelationWebModel>()
                .ForMember(x => x.Id, o => o.MapFrom(s => s.Id))
                .ForMember(x => x.InvitingUserId, o => o.MapFrom(s => s.InvitingUser.Id))
                .ForMember(x => x.InvitedUserId, o => o.MapFrom(s => s.InvitedUser.Id))
                .ForMember(x => x.UserRelationStatus, o => o.MapFrom(s => s.UserRelationStatus))
                .ForMember(x => x.InvitingUserName, o => o.MapFrom(s => s.InvitingUser.UserName))
                .ForMember(x => x.InvitedUserName, o => o.MapFrom(s => s.InvitedUser.UserName));

            #endregion

            #region Meeting

            CreateMap<MeetingModel, Meeting>()
                .ForMember(x => x.HostId, o => o.MapFrom(s => s.Host.Id))
                .ForMember(x => x.AppUsers, o => o.MapFrom(s => s.Participants))
                .ForMember(x => x.Host, o => o.Ignore());


            CreateMap<Meeting, MeetingModel>()
                .ForMember(x => x.Participants, o => o.MapFrom(s => s.AppUsers));

            CreateMap<MeetingModel, MeetingWebModel>()
                .ForMember(x => x.Time, o => o.MapFrom(s => s.StartTime.TimeOfDay))
                .ForMember(x => x.Date, o => o.MapFrom(s => s.StartTime.Date));

            CreateMap<MeetingWebModel, MeetingModel>()
                .ForMember(x => x.StartTime, o => o.MapFrom(s => s.Date.Date.Add(s.Time.TimeOfDay)));

            #endregion

            #region UserModel

            CreateMap<UserModel, AppUser>()
                .ForMember(x => x.Id, o => o.MapFrom(s => s.Id))
                .ForMember(x => x.UserName, o => o.MapFrom(s => s.UserName))
                .ForMember(x => x.LastName, o => o.MapFrom(s => s.LastName))
                .ForMember(x => x.FirstName, o => o.MapFrom(s => s.FirstName))
                .ForAllOtherMembers(x => x.Ignore());

            CreateMap<AppUser, UserModel>()
                .ForMember(x => x.Id, o => o.MapFrom(s => s.Id))
                .ForMember(x => x.UserName, o => o.MapFrom(s => s.UserName))
                .ForMember(x => x.LastName, o => o.MapFrom(s => s.LastName))
                .ForMember(x => x.FirstName, o => o.MapFrom(s => s.FirstName))
                .ForAllOtherMembers(o => o.Ignore());

            #endregion

            #region UserWebModel

            CreateMap<UserWebModel, UserModel>()
                .ForMember(x => x.Id, o => o.MapFrom(s => s.Id))
                .ForAllOtherMembers(x => x.Ignore());
            CreateMap<UserModel, UserWebModel>()
                .ForMember(x => x.Email, o => o.MapFrom(s => s.UserName));

            #endregion
        }
    }
}
