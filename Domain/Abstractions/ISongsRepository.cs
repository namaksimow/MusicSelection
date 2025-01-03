using Domain.Models;

namespace Domain.Abstractions;

public interface ISongsRepository
{
    Task<Guid> Create(Song song);
    
    Task<List<Song>> Get();
    
    Task<Guid> Update(Guid newId, string newTitle, int newDuration);
    
    Task<Guid> Delete(Guid id);
}