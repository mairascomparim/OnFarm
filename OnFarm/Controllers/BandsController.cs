﻿using AutoMapper;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using OnFarm.Helpers;
using OnFarm.Models;
using OnFarm.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnFarm.Controllers
{
    [ApiController]
    [Route("api/bands")]
    public class BandsController : ControllerBase
    {
        private readonly IBandAlbumRepository _bandAlbumRepository;
        private readonly IMapper _mapper;
        public BandsController(IBandAlbumRepository bandAlbumRepository, IMapper mapper)
        {
            _bandAlbumRepository = bandAlbumRepository ??
                throw new ArgumentNullException(nameof(bandAlbumRepository));
            _mapper = mapper ?? 
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [HttpHead]
        public ActionResult<IEnumerable<BandDto>> GetBands([FromQuery] BandsResourceParameters bandsResourceParameters)
        {
            var bandsFromRepo = _bandAlbumRepository.GetBands(bandsResourceParameters);

            return Ok(_mapper.Map<IEnumerable<BandDto>>(bandsFromRepo));
        }

        [HttpGet("{bandId}", Name ="GetBand")]
        public IActionResult GetBand(Guid bandId)
        {
            var bandFromRepo = _bandAlbumRepository.GetBand(bandId);

            if (bandFromRepo == null)
                return NotFound();

            return Ok(bandFromRepo);
        }

        [HttpPost]
        public ActionResult<BandDto> CreateBand([FromBody] BandForCreatingDto band)
        {
            var bandEntity = _mapper.Map<Entities.Band>(band);
            _bandAlbumRepository.AddBand(bandEntity);
            _bandAlbumRepository.save();

            var bandToReturn = _mapper.Map<BandDto>(bandEntity);

            return CreatedAtRoute("GetBand", new { bandId = bandToReturn.Id },
                bandToReturn);
        }

        [HttpOptions]
        public IActionResult GetBandsOptions()
        {
            Response.Headers.Add("Allow", "GET,POST,DELETE,HEAD,OPTIONS");
            return Ok();
        }

    }
}
