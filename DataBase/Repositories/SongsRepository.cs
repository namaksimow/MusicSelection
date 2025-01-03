using DataBase.Entities;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Domain.Abstractions;

namespace DataBase.Repositories;

public class SongsRepository : ISongsRepository
{
    private readonly MusicSelectionDbContext _context;
    
    public SongsRepository(MusicSelectionDbContext context)
    {
        _context = context; 
    }

    public async Task<List<Song>> Get()
    {
        var songEntities = await _context.Songs.AsNoTracking().ToListAsync();
        
        var songs = songEntities.Select(song => Song
            .Create(song.Id, song.Title, song.Duration).Song)
            .ToList();

        return songs;
    }

    public async Task<Guid> Create(Song song)
    {
        var songEntity = new SongEntity
        {
            Id = song.Id,
            Title = song.Title,
            Duration = song.Duration
        };
        
        await _context.Songs.AddAsync(songEntity);
        await _context.SaveChangesAsync();
        
        return songEntity.Id;
    }

    public async Task<Guid> Update(Guid newId, string newTitle, int newDuration)
    {
        await _context.Songs
            .Where(song => song.Id == newId)
            .ExecuteUpdateAsync(s => s
                .SetProperty(song => song.Title, song => newTitle)
                .SetProperty(song => song.Duration, song => newDuration));

        return newId;
    }

    public async Task<Guid> Delete(Guid idDelete)
    {
        await _context.Songs
            .Where(song => song.Id == idDelete)
            .ExecuteDeleteAsync();
        
        return idDelete;
    }
}