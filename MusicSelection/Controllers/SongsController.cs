using Domain.Abstractions;
using Microsoft.AspNetCore.Mvc;
using MusicSelection.Contracts;

namespace MusicSelection.Controllers;

[ApiController]
[Route("[controller]")]
public class SongsController : ControllerBase
{
    private readonly ISongsService _songsService;

    public SongsController(ISongsService songsService)
    {
        _songsService = songsService;
    }

    [HttpGet]
    public async Task<ActionResult<List<SongsResponse>>> GetSongs()
    {
        var songs = await _songsService.GetAllSongs();

        var responce = songs.Select(song => new SongsResponse(song.Id, song.Title, song.Duration));
        
        return Ok(responce);
    }
}