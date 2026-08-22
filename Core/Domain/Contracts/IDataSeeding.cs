namespace Domain.Contracts;

public interface IDataSeeding
{
    /// <summary>
    /// First Check if any pending migration => apply migration , Then Seed Data,
    /// Seed  only if no Data at DbSet
    /// Start seed independent module frominner to outside
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    Task DataSeedAsync();
}
