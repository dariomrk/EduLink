﻿namespace Data.Models
{
    public class LoginTimestamp : BaseModel
    {
        public long UserId { get; set; }
        public DateTimeOffset AttemptedAt { get; set; }
        public TimeSpan LockoutDuration { get; set; }
        public bool IsValidLogin { get; set; }
    }
}