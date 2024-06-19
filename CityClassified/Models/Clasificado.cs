using System;
using System.Collections.Generic;

namespace CityClassified.Models;

public partial class Clasificado
{
    public int IdClasificado { get; set; }

    public string Titulo { get; set; } = null!;

    public string Categoria { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Ubicacion { get; set; } = null!;

    public int? NumeroC { get; set; }

    public string? CorreoC { get; set; }

    public int IdCiudad { get; set; }

    public int IdUsuario { get; set; }

    public virtual Ciudade IdCiudadNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
