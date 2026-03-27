using System;
using System.Collections.Generic;

namespace HakariAPI.Models;

public partial class Receta
{
    public int Idreceta { get; set; }

    public int PlatilloId { get; set; }

    public int IngredienteId { get; set; }

    public decimal CantidadNecesaria { get; set; }

    public virtual Ingrediente Ingrediente { get; set; } = null!;

    public virtual Platillo Platillo { get; set; } = null!;
}
