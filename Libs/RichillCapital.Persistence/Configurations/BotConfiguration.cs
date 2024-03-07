using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RichillCapital.Domain;

namespace RichillCapital.Persistence.Configurations;

internal sealed class BotConfiguration : IEntityTypeConfiguration<Bot>
{
    public void Configure(EntityTypeBuilder<Bot> builder)
    {
        builder
            .ToTable("bots")
            .HasKey(bot => bot.Id);

        builder
            .Property(bot => bot.Id)
            .HasColumnName("id")
            .HasMaxLength(BotId.MaxLength)
            .HasConversion(
                id => id.Value,
                value => BotId.From(value).Value)
            .IsRequired();

        builder
            .Property(bot => bot.Name)
            .HasColumnName("name")
            .HasMaxLength(BotName.MaxLength)
            .HasConversion(
                name => name.Value,
                value => BotName.From(value).Value)
            .IsRequired();

        builder
            .Property(bot => bot.Description)
            .HasColumnName("description")
            .HasMaxLength(BotDescription.MaxLength)
            .HasConversion(
                description => description.Value,
                value => BotDescription.From(value).Value)
            .IsRequired();

        builder
            .Property(bot => bot.Side)
            .HasColumnName("side")
            .HasEnumerationValueConversion()
            .IsRequired();

        builder
            .Property(bot => bot.Platform)
            .HasColumnName("platform")
            .HasEnumerationValueConversion()
            .IsRequired();

        builder
            .Property(bot => bot.CreatedAt)
            .HasColumnName("created_at")
            .HasColumnType(PersistenceConstants.DefaultDateTimeType)
            .IsRequired();

        builder
            .Property(bot => bot.UpdatedAt)
            .HasColumnName("updated_at")
            .HasColumnType(PersistenceConstants.DefaultDateTimeType)
            .IsRequired();
    }
}