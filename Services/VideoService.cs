using AluraFlixAPI.Data;
using AluraFlixAPI.Data.Dtos;
using AluraFlixAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

namespace AluraFlixAPI.Services
{
    public class VideoService
    {
        private AluraFlixContext _context;
        private IMapper _mapper;

        public VideoService(AluraFlixContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<ReadVideoDto> GetVideos()
        {
            return _mapper.Map<List<ReadVideoDto>>(_context.Videos);
        }

        public Video CreateVideo(CreateVideoDto dto)
        {
            if(dto == null) { throw new ApplicationException("Não foi possivel registrar o vídeo."); }
            var video = _mapper.Map<Video>(dto);
            _context.Videos.Add(video);
            _context.SaveChanges();
            return video;
        }

        public ReadVideoDto GetVideo(int id)
        {
            var video= _mapper.Map<ReadVideoDto>(_context.Videos.FirstOrDefault(p=>p.Id==id));
            if(video == null) { throw new ApplicationException("Não encontrado"); }
            return video;
        }

        public void PutVideo(UpdateVideoDto dto, int id)
        {
            var video=_context.Videos.FirstOrDefault(i=>i.Id==id);
            if(video == null) { throw new ApplicationException("Vídeo não existente!"); }
            _mapper.Map(dto, video);
            _context.SaveChanges();

        }

        public void DeleteVideo(int id)
        {
            var video = _context.Videos.FirstOrDefault(i=>i.Id==id);
            if(video == null) { throw new ApplicationException($"Vídeo não existente!"); }

            _context.Videos.Remove(video);
            _context.SaveChanges();
        }
    }
}
