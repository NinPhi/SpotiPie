﻿using SpotiPie.Contracts;

namespace SpotiPie.Services.Interfaces;

public interface IAlbumService
{
    public Task<AlbumGetDto?> GetByIdAsync(int id);
}
