﻿using MyMusicApi.Core;
using MyMusicApi.Core.Models;
using MyMusicApi.Core.Services;
using MyMusicApi.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyMusicApi.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ArtistService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Artist> CreateArtist(Artist newArtist)
        {
            await _unitOfWork.Artists.AddAsync(newArtist);
            await _unitOfWork.CommitAsync();
            return newArtist;
        }

        public Task DeleteArtist(Artist artist)
        {
            _unitOfWork.Artists.Remove(artist);
            return _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Artist>> GetAllArtists()
        {
           return  await _unitOfWork.Artists.GetAllAsync();
        }

        public async Task<Artist> GetArtistById(int id)
        {
            return  await _unitOfWork.Artists.GetByIdAsync(id);
        }

        public async Task UpdateArtist(Artist artistToBeUpdated, Artist artist)
        {
            artistToBeUpdated.Name = artist.Name;
            await _unitOfWork.CommitAsync();
        }
    }
}
