using Domain.Abstractions;
using Domain.Models;

namespace Application.Services;

public class SongsService : ISongsService
{
    private readonly ISongsRepository _songsRepository;
    
    public SongsService(ISongsRepository songsRepository)
    {
        _songsRepository = songsRepository;
    }

    public async Task<List<Song>> GetAllSongs()
    {
        return await _songsRepository.Get();
    }

    public async Task<Guid> CreateSong(Song song)
    {
        return await _songsRepository.Create(song);
    }

    public async Task<Guid> UpdateSong(Guid newId, string newTitle, int newDuration)
    {
        return await _songsRepository.Update(newId, newTitle, newDuration);
    }

    public async Task<Guid> DeleteSong(Guid id)
    {
        return await _songsRepository.Delete(id);
    }
}