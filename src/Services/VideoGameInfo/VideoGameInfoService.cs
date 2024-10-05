
using AutoMapper;
using FusionTech.src.Entity;
using FusionTech.src.Repository;
using static FusionTech.src.DTO.VideoGameInfoDTO;

namespace FusionTech.src.Services.VideoGamesInfo
{
    public class VideoGameInfoService : IVideoGameInfoService
    {
        protected readonly VideoGameInfoRepository _videoGameInfoRepo;
        protected readonly SystemAdminRepository _systemAdminRepository;
        protected readonly PersonRepository _personRepo;

        protected readonly IMapper _mapper;

        public VideoGameInfoService(VideoGameInfoRepository videoGameInfoRepository, PersonRepository personRepo,
            SystemAdminRepository systemAdminRepository, IMapper mapper)
        {
            _videoGameInfoRepo = videoGameInfoRepository;
            _mapper = mapper;
            _personRepo = personRepo;
            _systemAdminRepository = systemAdminRepository;
        }

        
        public async Task<VideoGameInfoReadDto> CreateOneAsync(VideoGameInfoCreateDto createGameInfo, string email)
        {
          
            var originalPerson = await _personRepo.FindPersonByEmail(email);
            var originalSystemAdmin = await _systemAdminRepository.GetByIdAsync(originalPerson!.PersonId);

            if (originalSystemAdmin!.ManageGames)
            {
                throw new UnauthorizedAccessException("Unauthorized");
            }

            var videoGame = _mapper.Map<VideoGameInfoCreateDto, VideoGameInfo>(createGameInfo);
            var createdGameInfo = await _videoGameInfoRepo.CreateOneAsync(videoGame);

            if (createdGameInfo == null)
            {
                throw new InvalidOperationException("Failed to create the video game.");
            }

            return _mapper.Map<VideoGameInfo, VideoGameInfoReadDto>(createdGameInfo);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var foundGameInfo = await _videoGameInfoRepo.GetByIdAsync(id);
            if (foundGameInfo == null)
            {
                return false;
            }

            return await _videoGameInfoRepo.DeleteOnAsync(foundGameInfo);
        }

        public async Task<List<VideoGameInfoReadDto>> GetAllAsync()
        {
            var videoGameList = await _videoGameInfoRepo.GetAllAsync();
            return _mapper.Map<List<VideoGameInfo>, List<VideoGameInfoReadDto>>(videoGameList);
        }

        public async Task<VideoGameInfoReadDto> GetByIdAsync(Guid id)
        {
            var foundGameInfo = await _videoGameInfoRepo.GetByIdAsync(id);
            return _mapper.Map<VideoGameInfo, VideoGameInfoReadDto>(foundGameInfo);
        }

        /* public async Task<bool> UpdateOnAsync(Guid id, VideoGameInfoUpdateDto updateGameInfo)
        {
            var foundGameInfo = await _videoGameInfoRepo.GetByIdAsync(id);
            if (foundGameInfo == null)
            {
                return false;
            }

            _mapper.Map(updateGameInfo, foundGameInfo);
            return await _videoGameInfoRepo.UpdateOnAsync(foundGameInfo);
        } */

        public async Task<bool> UpdateGameNameAsync(Guid id, string newGameName)
        {
            var videoGame = await _videoGameInfoRepo.GetByIdAsync(id);
            if (videoGame == null)
            {
                return false;
            }

            videoGame.GameName = newGameName;

            return await _videoGameInfoRepo.UpdateOnAsync(videoGame);
        }

        public async Task<bool> UpdateYearOfReleaseAsync(Guid id, string newYearOfRelease)
        {
            var videoGame = await _videoGameInfoRepo.GetByIdAsync(id);
            if (videoGame == null)
            {
                return false;
            }

            videoGame.YearOfRelease = newYearOfRelease;

            return await _videoGameInfoRepo.UpdateOnAsync(videoGame);
        }
    }
}