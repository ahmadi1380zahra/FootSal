using Clean.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Persistance.EF.Teams
{
    public class TeamEntityMap : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).ValueGeneratedOnAdd();
            builder.Property(_ => _.Name).HasMaxLength(50).IsRequired();
            builder.Property(_ => _.MainColor).IsRequired();
            builder.Property(_ => _.SubColor).IsRequired(); 
        }
    }
}
