﻿namespace Application.Dtos.Message
{
    public class CreateMessageRequestDto
    {
        public string SenderUsername { get; set; } = null!;
        public string RecipientUsername { get; set; } = null!;
        public string Message { get; set; } = null!;
    }
}
