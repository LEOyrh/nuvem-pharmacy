using PharmacyApi.Domain.Entities;
using PharmacyApi.Domain.IRepository;

namespace PharmacyApi.Infrastructure.Repositories.PharmacyRepository;

public class PharmacyRepository : IPharmacyRepository<Pharmacy>
{
    readonly PharmacyContext _pharmacyContext;

    public PharmacyRepository(PharmacyContext context)
    {
        _pharmacyContext = context;
    }

    public void Add(Pharmacy pharmacy)
    {
        _pharmacyContext.Pharmacies.Add(pharmacy);
        _pharmacyContext.SaveChanges();
    }

    public void Delete(Pharmacy pharmacy)
    {
        _pharmacyContext.Pharmacies.Remove(pharmacy);
        _pharmacyContext.SaveChanges();
    }

    public Pharmacy Get(long id)
    {
        return _pharmacyContext.Pharmacies.FirstOrDefault(e => e.PharmacyId == id)!;
    }

    public IEnumerable<Pharmacy> GetAll()
    {
        return _pharmacyContext.Pharmacies.ToList();
    }

    public void Update(Pharmacy currPharmacy, Pharmacy updPharmacy)
    {
        currPharmacy.Name = updPharmacy.Name;
        currPharmacy.Address = updPharmacy.Address;
        currPharmacy.City = updPharmacy.City;
        currPharmacy.State = updPharmacy.State;
        currPharmacy.Zip = updPharmacy.Zip;
        currPharmacy.UpdatedDate = DateTime.Now;

        _pharmacyContext.SaveChanges();
    }
}