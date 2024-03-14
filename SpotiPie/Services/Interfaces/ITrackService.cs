﻿using SpotiPie.Entities.Contracts;

namespace SpotiPie.Services.Interfaces;

public interface ITrackService
{
    public Task<TrackGetDto?> GetByIdAsync(int id);
    public Task<List<TrackGetDto>> GetAllAsync();
    public Task<TrackGetDto> CreateAsync(TrackCreateDto trackDto);
    public Task<TrackGetDto?> UpdateAsync(int id, TrackCreateDto trackDto);
    public Task DeleteAsync(int id);
}