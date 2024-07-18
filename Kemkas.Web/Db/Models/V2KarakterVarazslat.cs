using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kemkas.Web.Db.Models;

public class V2KarakterVarazslat
{
    [Key]
    public Guid Id { get; set; }
    
    public Guid KarakterId { get; set; }
    
    public string VarazslatId { get; set; }
    
    public bool Bekeszitve { get; set; }
    
    [ForeignKey(nameof(KarakterId))]
    public V2Karakter Karakter { get; set; }
}