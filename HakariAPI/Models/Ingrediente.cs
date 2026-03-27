using System;
using System.Collections.Generic;

namespace HakariAPI.Models;

public partial class Ingrediente
{
    public int Idingrediente { get; set; }

    public string NombreIngrediente { get; set; } = null!;

    public decimal StockActual { get; set; }

    public string UnidadMedida { get; set; } = null!;

    public virtual ICollection<Receta> Receta { get; set; } = new List<Receta>();
}
