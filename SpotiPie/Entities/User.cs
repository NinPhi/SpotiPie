﻿namespace SpotiPie.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public required string Roles { get; set; } = "User";
    }
}
