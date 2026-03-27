using System;
using System.Collections.Generic;

namespace HakariAPI.Models;

public partial class Platillo
{
    public int Idplatillo { get; set; }

    public string NombrePlatillo { get; set; } = null!;

    public decimal PrecioPlatillo { get; set; }

    public virtual ICollection<Receta> Receta { get; set; } = new List<Receta>();
}
