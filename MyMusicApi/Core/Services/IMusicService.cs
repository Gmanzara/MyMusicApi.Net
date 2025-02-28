﻿using MyMusicApi.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyMusicApi.Core.Services
{
    public interface IMusicService
    {
        Task<IEnumerable<Music>> GetAllWithArtist();
        Task<Music> GetMusicById(int id);
        Task<IEnumerable<Music>> GetMusicsByArtistId(int artistId);
        Task<Music> CreateMusic(Music music);
        Task UpdateMusic(Music musicToBeUpdated, Music music);
        Task DeleteMusic(Music music);
    }
}
