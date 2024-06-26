﻿using System.Security.Claims;

namespace SpotiPie.Application.Services.Interfaces;

public interface IAuthService
{
    public ClaimsIdentity CreateClaimsIdentity(UserGetDto user);
    public string GenerateJwt(ClaimsIdentity claimsIdentity);
}
