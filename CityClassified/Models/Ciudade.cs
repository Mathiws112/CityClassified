using System;
using System.Collections.Generic;

namespace CityClassified.Models;

public partial class Ciudade
{
    public int IdCiudad { get; set; }

    public string Nombre { get; set; } = null!;

    public string Detalles { get; set; } = null!;

    public virtual ICollection<Clasificado> Clasificados { get; set; } = new List<Clasificado>();

    public virtual ICollection<Detalle> DetallesNavigation { get; set; } = new List<Detalle>();
}
