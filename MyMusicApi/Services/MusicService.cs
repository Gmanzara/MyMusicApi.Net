﻿using MyMusicApi.Core;
using MyMusicApi.Core.Models;
using MyMusicApi.Core.Services;
using MyMusicApi.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyMusicApi.Services
{
    public class MusicService : IMusicService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MusicService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<Music> CreateMusic(Music music)
        {
            await _unitOfWork.Musics.AddAsync(music);
            await _unitOfWork.CommitAsync();
            return music;
        }

        public async Task DeleteMusic(Music music)
        {
             _unitOfWork.Musics.Remove(music);
            await _unitOfWork.CommitAsync();
            
        }

        public async Task<IEnumerable<Music>> GetAllWithArtist()
        {
            return await _unitOfWork.Musics.GetAllWithArtistAsync();
        }

        public async Task<Music> GetMusicById(int id)
        {
            return await _unitOfWork.Musics.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Music>> GetMusicsByArtistId(int artistId)
        {
            return await _unitOfWork.Musics.GetAllWithArtistByArtistIdAsync(artistId);
        }

        public async Task UpdateMusic(Music musicToBeUpdated, Music music)
        {
            musicToBeUpdated.Name = music.Name;
            musicToBeUpdated.ArtistId = music.ArtistId;

            await _unitOfWork.CommitAsync();
        }
    }
}
