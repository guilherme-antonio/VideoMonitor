﻿using VideoMonitor.Domain;

namespace VideoMonitor.Services
{
    public interface IVideoService
    {
        Task AddAsync(Video video);
    }
}
