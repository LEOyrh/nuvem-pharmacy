using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyApi.Domain.Entities;

public class Pharmacy
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long PharmacyId { get; set; }

    [Required(ErrorMessage = "The name of the pharmacy is required.")]
    [MaxLength]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "The address of the pharmacy is required.")]
    [MaxLength]
    public string Address { get; set; } = null!;

    [Required(ErrorMessage = "The city of the pharmacy is required.")]
    [StringLength(50, ErrorMessage = "The city of the pharmacy cannot be longer than 50 characters.")]
    public string City { get; set; } = null!;

    [Required(ErrorMessage = "The state of the pharmacy is required.")]
    [StringLength(2, ErrorMessage = "The state of the pharmacy cannot be longer than 2 characters.")]
    public string State { get; set; } = null!;

    [Required(ErrorMessage = "The zip of the pharmacy is required.")]
    [StringLength(10, ErrorMessage = "The zip of the pharmacy cannot be longer than 10 characters.")]
    public string Zip { get; set; } = null!;

    public int NumberOfFilledPrescriptions { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime CreatedDate { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime UpdatedDate { get; set; }
}