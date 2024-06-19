using System;
using System.Collections.Generic;

namespace CityClassified.Models;

public partial class Detalle
{
    public int IdDetalle { get; set; }

    public string Nombre { get; set; } = null!;

    public string Ubicacion { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public int IdCiudad { get; set; }

    public virtual Ciudade IdCiudadNavigation { get; set; } = null!;
}
