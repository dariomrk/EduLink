﻿namespace Application.Dtos.Indentity
{
    public class LoginRequestDto
    {
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string Password { get; set; } = null!;
    }
}
