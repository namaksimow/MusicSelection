namespace Domain.Models;

public class Song
{
    public const int MAX_TITLE_LENGTH = 255;
    
    public Guid Id { get; }
    
    public string Title { get; } = string.Empty;
    
    public int Duration { get; }

    private Song(Guid id, string title, int duration)
    {
        Id = id;
        Title = title;
        Duration = duration;
    }

    public static (Song Song, string Error) Create(Guid id, string title, int duration)
    {
        var error = String.Empty;

        if (string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH)
        {
            error = "Invalid title";
        }
        
        var song = new Song(id, title, duration);
        
        return (song, error);
    }
}