﻿using OnFarm.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnFarm.Services
{
    public interface IBandAlbumRepository
    {
        IEnumerable<Album> GetAlbums(Guid bandId);
        Album GetAlbum(Guid bandaId, Guid albumId);
        void AddAlbum(Guid bandId, Album album);
        void UpdateAlbum(Album album);
        void DeleteAlbum(Album album);

        IEnumerable<Band> GetBands();
        Band GetBand(Guid bandId);
        IEnumerable<Band> GetBands(IEnumerable<Guid> bandIds);
        IEnumerable<Band> GetBands(BandsResourceParameters bandsResourceParameters);
        void AddBand(Band band);
        void UpdateBand(Band band);
        void DeleteBand(Band band);

        bool BandExists(Guid bandId);
        bool AlbumExists(Guid albumId);
        bool save();
    }
}
