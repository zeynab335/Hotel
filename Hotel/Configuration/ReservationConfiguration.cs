using Hotel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Configuration
{
    public class ReservationConfiguration : IEntityTypeConfiguration<reservation>
    {
        public void Configure(EntityTypeBuilder<reservation> builder)
        {
            //builder.HasKey(x => x.Id)
            //      .HasName("PK_Table");

            builder.Property(e => e.card_cvc).IsFixedLength();

            builder.Property(e => e.card_type).IsFixedLength();

            builder.Property(e => e.payment_type).IsFixedLength();

            builder.Property(e => e.room_floor).IsFixedLength();

            builder.Property(e => e.room_number).IsFixedLength();

            builder.Property(e => e.room_type).IsFixedLength();

            builder.Property(e => e.zip_code).IsFixedLength();

        }
    }
}
