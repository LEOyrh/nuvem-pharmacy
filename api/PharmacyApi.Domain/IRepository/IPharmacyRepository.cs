namespace PharmacyApi.Domain.IRepository;

public interface IPharmacyRepository<TEntity>
{
    IEnumerable<TEntity> GetAll();
    TEntity Get(long id);
    void Add(TEntity entity);
    void Update(TEntity dbEntity, TEntity entity);
    void Delete(TEntity entity);
}