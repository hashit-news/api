public class RoleRepository : Repository<Role>, IRoleRepository
{
    public RoleRepository(HashitDbContext db) : base(db) { }

    public ValueTask<Role?> FindByIdAsync(
        RoleType id,
        CancellationToken cancellationToken = default
    )
    {
        return Db.Roles.FindAsync(id, cancellationToken);
    }
}
