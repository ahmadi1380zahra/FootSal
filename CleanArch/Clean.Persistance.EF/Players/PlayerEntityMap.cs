using Clean.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Persistance.EF.Players
{
    public class PlayerEntityMap : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).ValueGeneratedOnAdd();
            builder.Property(_ => _.FullName).HasMaxLength(50).IsRequired();
            builder.Property(_ => _.BirthDate).IsRequired();
            builder.HasOne(_ => _.Team)
              .WithMany(_ => _.Players)
              .HasForeignKey(_ => _.TeamId)
              .IsRequired();
        }
    }
}
