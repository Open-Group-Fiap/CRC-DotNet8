using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CRC.Domain.Entities;

[Table("T_OP_CRC_MORADOR")]
[Index(nameof(Cpf), nameof(IdAuth), IsUnique = true)]
public class Morador
{
    [Key]
    [Column("ID_MORADOR")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Column("ID_CONDOMINIO")]
    public int IdCondominio { get; set; }
    public Condominio? Condominio { get; set; }
    
    [Column("ID_AUTH")]
    public int IdAuth { get; set; }
    public Auth? Auth { get; set; }
    
    [Column("CPF")]
    public string Cpf { get; set; }
    
    [Column("NOME")]
    public string Nome { get; set; }
    
    [Column("PONTOS")]
    public int? Pontos { get; set; }
    
    [Column("QTD_MORADORES")]
    public int QtdMoradores { get; set; }
    
    [Column("IDENTIFICADOR_RES")]
    public string IdentificadorRes { get; set; }
    
    public List<MoradorBonus> MoradorBonus { get; set; } = new();
    
}