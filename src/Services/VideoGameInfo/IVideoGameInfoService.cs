namespace FusionTech.src.Services.VideoGamesInfo
{
    public interface IVideoGameInfoService
    {
        Task<VideoGameInfoReadDto> CreateOneAsync(VideoGameInfoCreateDto newGameInfo, string email);
        Task<List<VideoGameInfoReadDto>> GetAllAsync(SearchParameters searchParameters);
        Task<VideoGameDetailedDto> GetByIdAsync(Guid id);
        Task<List<VideoGameDetailedDto>> GetVideoGameVersionByIdAsync(Guid id);
        Task<List<VideoGameRatingReadDto>> GetVideoGameRatingsByIdAsync(Guid id);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> UpdateGameNameAsync(Guid id, string newGameName);
        Task<bool> UpdateYearOfReleaseAsync(Guid id, string newYearOfRelease);
        //Task<bool> UpdateOnAsync(VideoGameInfoUpdateDto updatedVideoGameDto);
    }
}
