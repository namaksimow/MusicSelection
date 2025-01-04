using Domain.Models;

namespace Domain.Abstractions;

public interface ISongsService
{
    Task<Guid> CreateSong(Song song);
    
    Task<List<Song>> GetAllSongs();
    
    Task<Guid> UpdateSong(Guid newId, string newTitle, int newDuration);
    
    Task<Guid> DeleteSong(Guid id);
}