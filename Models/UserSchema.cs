﻿namespace authapp_react_net.Models
{
    public class UserSchema
    {
        public long Id { get; set; }
        public string? FullName { get; set; }

        public string? Email { get; set; }
        public string? Password { get; set; }

    }
}
