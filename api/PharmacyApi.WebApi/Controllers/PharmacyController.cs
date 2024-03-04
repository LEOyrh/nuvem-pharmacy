using Microsoft.AspNetCore.Mvc;
using PharmacyApi.Domain.Entities;
using PharmacyApi.Domain.IRepository;

namespace PharmacyApi.WebApi;

[Route("api/[controller]")]
[ApiController]
public class PharmacyController : ControllerBase
{
    private readonly IPharmacyRepository<Pharmacy> _pharmacyRepository;

    public PharmacyController(IPharmacyRepository<Pharmacy> pharmacyRepository)
    {
        _pharmacyRepository = pharmacyRepository;
    }

    /// <summary>
    /// Get list of all pharmacies
    /// </summary>
    /// <returns>A list of pharmacy objects</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        IEnumerable<Pharmacy> pharmacies = _pharmacyRepository.GetAll();
        return Ok(pharmacies);
    }

    /// <summary>
    /// Get a specific pharmacy by ID
    /// </summary>
    /// <param name="id">The ID of the pharmacy to retrieve</param>
    /// <returns>The pharmacy object if found; otherwise, a NotFound result</returns>
    [HttpGet("{id}", Name = "Get")]
    public IActionResult Get(long id)
    {
        Pharmacy pharmacy = _pharmacyRepository.Get(id);

        return pharmacy == null ? NotFound("The Pharmacy record couldn't be found. ") : Ok(pharmacy);
    }

    /// <summary>
    /// Creates a new pharmacy record.
    /// </summary>
    /// <param name="pharmacy">The pharmacy object to create.</param>
    /// <returns>A created action result with the newly created pharmacy object.</returns>
    [HttpPost]
    public IActionResult Post([FromBody] Pharmacy pharmacy)
    {
        if (pharmacy == null)
        {
            return BadRequest("Pharmacy is null.");
        }

        _pharmacyRepository.Add(pharmacy);
        return CreatedAtRoute("Get", new { Id = pharmacy.PharmacyId }, pharmacy); // https://ochzhen.com/blog/created-createdataction-createdatroute-methods-explained-aspnet-core
    }

    /// <summary>
    /// Updates an existing pharmacy record.
    /// </summary>
    /// <param name="id">The ID of the pharmacy to update.</param>
    /// <param name="pharmacy">The updated pharmacy object.</param>
    /// <returns>No content action result if update is successful, NotFound if the pharmacy does not exist.</returns>
    [HttpPut("{id}")]
    public IActionResult Put(long id, [FromBody] Pharmacy pharmacy)
    {
        if (pharmacy == null)
        {
            return BadRequest("Pharmacy is null.");
        }

        Pharmacy pharmacyToUpdate = _pharmacyRepository.Get(id);
        if (pharmacyToUpdate == null)
        {
            return NotFound("The Pharmacy record couldn't be found.");
        }

        _pharmacyRepository.Update(pharmacyToUpdate, pharmacy);
        return NoContent();
    }

    /// <summary>
    /// Deletes a pharmacy record.
    /// </summary>
    /// <param name="id">The ID of the pharmacy to delete.</param>
    /// <returns>No content action result if deletion is successful, NotFound if the pharmacy does not exist.</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        Pharmacy pharmacy = _pharmacyRepository.Get(id);
        if (pharmacy == null)
        {
            return NotFound("The Pharmacy record couldn't be found.");
        }
        _pharmacyRepository.Delete(pharmacy);
        return NoContent();
    }
}