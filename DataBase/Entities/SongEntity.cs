﻿namespace DataBase.Entities;

public class SongEntity
{
    public Guid Id { get; set; }
    
    public string Title { get; set; } = string.Empty;
    
    public int Duration { get; set; }
}