using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RichillCapital.Domain;

namespace RichillCapital.Persistence.Configurations;

internal sealed class SignalConfiguration : IEntityTypeConfiguration<Signal>
{
    public void Configure(EntityTypeBuilder<Signal> builder)
    {
        builder
            .ToTable("signals")
            .HasKey(signal => new
            {
                signal.Time,
                signal.TradeType,
                signal.Symbol,
                signal.Quantity,
                signal.Price,
                signal.BotId,
            });

        builder
            .Property(signal => signal.Time)
            .HasColumnName("time")
            .HasColumnType(PersistenceConstants.DefaultDateTimeType)
            .IsRequired();

        builder
            .Property(signal => signal.TradeType)
            .HasColumnName("trade_type")
            .HasEnumerationValueConversion()
            .IsRequired();

        builder
            .Property(signal => signal.Symbol)
            .HasColumnName("symbol")
            .HasMaxLength(Symbol.MaxLength)
            .HasConversion(
                symbol => symbol.Value,
                value => Symbol.From(value).Value)
            .IsRequired();

        builder
            .Property(signal => signal.Quantity)
            .HasColumnName("quantity")
            .HasColumnType("decimal(18, 8)")
            .IsRequired();

        builder
            .Property(signal => signal.Price)
            .HasColumnName("price")
            .HasColumnType("decimal(18, 8)")
            .IsRequired();
    }
}