using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnFarm.Models;
using OnFarm.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnFarm.Controllers
{
    [ApiController]
    [Route("api/bandcollections")]
    public class BandCollectionsController : ControllerBase
    {
        private readonly IBandAlbumRepository _bandAlbumRepository;
        private readonly IMapper _mapper;
        public BandCollectionsController(IBandAlbumRepository bandAlbumRepository, IMapper 
            mapper)
        {
            _bandAlbumRepository = bandAlbumRepository ??
                throw new ArgumentNullException(nameof(bandAlbumRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        public ActionResult<IEnumerable<BandDto>> CreateBandCollection([FromBody]
            IEnumerable<BandForCreatingDto> bandCollection)
        {
            var bandEntities = _mapper.Map<IEnumerable<Entities.Band>>(bandCollection);

            foreach(var band in bandEntities)
            {
                _bandAlbumRepository.AddBand(band);
            }

            _bandAlbumRepository.save();

            return Ok();
        }

    }
}
