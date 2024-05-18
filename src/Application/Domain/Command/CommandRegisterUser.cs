﻿using api_cadastro.Application.Domain.Enums;
using api_cadastro.Application.Domain.ValueObjects;

namespace api_cadastro.Application.Domain.Command
{
    public record CommandRegisterUser
    {
        public User? User { get; set; }
        public ConfigUserLibrary? ConfigUserLibrary { get; set; }

    }
}
