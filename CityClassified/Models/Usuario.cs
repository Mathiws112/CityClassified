using System;
using System.Collections.Generic;

namespace CityClassified.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Apellido { get; set; }

    public string Correo { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public virtual ICollection<Clasificado> Clasificados { get; set; } = new List<Clasificado>();
}
