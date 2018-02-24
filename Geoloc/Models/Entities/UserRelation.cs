﻿using System;

namespace Geoloc.Models.Entities
{
    public class UserRelation
    {
        public int Id { get; set; }
        public Guid FirstAppUserId { get; set; }
        public Guid SecondAppUserId { get; set; }
        public UserRelationStatus UserRelationStatus { get; set; }
            
        public AppUser FirstAppUser { get; set; }
        public AppUser SecondAppUser { get; set; }
    }
}