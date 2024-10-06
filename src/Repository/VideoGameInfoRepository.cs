using FusionTech.src.Database;
using FusionTech.src.Entity;
using Microsoft.EntityFrameworkCore;

namespace FusionTech.src.Repository
{
    public class VideoGameInfoRepository
    {
        protected DbSet<VideoGameInfo> _videoGameInfos;
        protected DatabaseContext _databaseContext;

        public VideoGameInfoRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _videoGameInfos = databaseContext.Set<VideoGameInfo>();
        }

        // Get a video game by ID
        public async Task<VideoGameInfo> GetByIdAsync(Guid id)
        {
            return await _videoGameInfos.FindAsync(id);
        }

        public async Task<List<VideoGameInfo>> GetVideoGameVersionByIdAsync(Guid id)
        {
            return await _videoGameInfos
                .Include(vi => vi.VideoGameVersions)
                .Where(vi => vi.VideoGameInfoId == id)
                .ToListAsync();
        }

        // Create a new video game
        public async Task<VideoGameInfo> CreateOneAsync(VideoGameInfo newGameInfo)
        {
            await _videoGameInfos.AddAsync(newGameInfo);
            await _databaseContext.SaveChangesAsync();
            return newGameInfo;
        }

        // Get all video games
        public async Task<List<VideoGameInfo>> GetAllAsync()
        {
            return await _videoGameInfos.ToListAsync();
        }

        // Update an existing video game
        public async Task<bool> UpdateOnAsync(VideoGameInfo updateGameInfo)
        {
            _videoGameInfos.Update(updateGameInfo);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        // Delete a video game
        public async Task<bool> DeleteOnAsync(VideoGameInfo gameInfo)
        {
            try
            {
                _videoGameInfos.Remove(gameInfo);
                await _databaseContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return true;
        }
    }
}
