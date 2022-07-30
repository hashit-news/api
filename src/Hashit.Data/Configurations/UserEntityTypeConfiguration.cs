using Microsoft.EntityFrameworkCore.Metadata.Builders;

public sealed class UserEntityTypeConfiguration : EntityTypeConfigurationBase<User>
{
    public override void ConfigureEntity(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(x => x.Username).IsUnique();

        builder.HasIndex(x => x.Email).IsUnique();
    }
}
