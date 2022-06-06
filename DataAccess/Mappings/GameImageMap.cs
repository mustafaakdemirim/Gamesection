using System;
using Entity.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Mappings
{
    public class GameImageMap : IEntityTypeConfiguration<GameImage>
    {
        public void Configure(EntityTypeBuilder<GameImage> builder)
        {
            builder
                .HasOne(x => x.Game)
                .WithMany(x => x.GameImages)
                .HasForeignKey(x => x.GameID);
        }
    }
}
