using DataBase.Entities;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.Configuration;

public class SongConfiguration : IEntityTypeConfiguration<SongEntity>
{
    public void Configure(EntityTypeBuilder<SongEntity> builder)
    {
        builder.HasKey(song => song.Id);

        builder.Property(song => song.Title).HasMaxLength(Song.MAX_TITLE_LENGTH).IsRequired();

        builder.Property(song => song.Duration).IsRequired();
    }
}