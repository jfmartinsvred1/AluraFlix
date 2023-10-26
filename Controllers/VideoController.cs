using AluraFlixAPI.Data;
using AluraFlixAPI.Data.Dtos;
using AluraFlixAPI.Services;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AluraFlixAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideoController : ControllerBase
    {
        private VideoService _videoService;
        private IMapper _mapper;
        private AluraFlixContext _context;

        public VideoController(VideoService videoService, IMapper mapper, AluraFlixContext context)
        {
            _videoService = videoService;
            _mapper = mapper;
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateVideo(CreateVideoDto dto)
        {
            _videoService.CreateVideo(dto);
            return Ok();
        }

        [HttpGet]
        public IEnumerable<ReadVideoDto> GetVideos()
        {
            return _videoService.GetVideos();
        }
        [HttpGet("{id}")]
        public IActionResult GetVideo(int id)
        {
            return Ok(_videoService.GetVideo(id));
        }
        [HttpPut("{id}")]
        public IActionResult PutVideo(UpdateVideoDto dto,int id)
        {
            _videoService.PutVideo(dto, id);
            return NoContent();
        }
        [HttpPatch("{id}")]

        public IActionResult PatchVideo(int id,JsonPatchDocument<UpdateVideoDto> patch)
        {
            var video = _context.Videos.FirstOrDefault(i => i.Id == id);
            if (video is null) { throw new ApplicationException("Vídeo não registrado!"); }

            var videoParaAtualizar = _mapper.Map<UpdateVideoDto>(video);

            patch.ApplyTo(videoParaAtualizar, ModelState);
            if(!TryValidateModel(videoParaAtualizar))
            {
                return ValidationProblem(ModelState); ;
            }

            _mapper.Map(videoParaAtualizar, video);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteVideo(int id)
        {
            _videoService.DeleteVideo(id);
            return NoContent();
        }
    }
}
