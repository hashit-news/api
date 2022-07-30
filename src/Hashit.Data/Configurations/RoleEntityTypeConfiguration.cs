public sealed class RoleEntityTypeConfiguration : EntityTypeConfigurationBase<Role>
{
    public override void ConfigureEntity(EntityTypeBuilder<Role> builder)
    {
        builder
            .Property(x => x.Id)
            .HasConversion(v => v.ToString(), v => (RoleId)Enum.Parse(typeof(RoleId), v))
            .HasMaxLength(Enum.GetNames<RoleId>().Max(x => x.Length));
    }
}
