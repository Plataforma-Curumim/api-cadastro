﻿using api_cadastro.Adapters.Inbound.HTTP.DTO.Requests;
using api_cadastro.Application.Domain.Command;

namespace api_cadastro.Adapters.Inbound.HTTP.Mapping
{
    public static class MapRegisterUser
    {
        public static CommandRegisterUser ToCommand(RequestRegisterUser request)
        {
            return new CommandRegisterUser
            {
                User = request.User,
                ConfigUserLibrary = request.ConfigUserLibrary,
            };
        }
    }
}
