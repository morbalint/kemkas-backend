using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kemkas.Web.Db.Models;

public class V2Felszereles
{
    [Key]
    public Guid Id { get; set; }
    public Guid KarakterId { get; set; }
    
    public string TargyId { get; set; }

    [DefaultValue(1)]
    public int Count { get; set; } = 1;

    public bool IsFegyver { get; set; } = false;

    public bool IsViselt { get; set; } = false;

    public bool IsCipelt { get; set; } = false;

    public bool IsAprosag { get; set; } = false;

    [ForeignKey(nameof(KarakterId))]
    public virtual V2Karakter Karakter { get; set; }
}