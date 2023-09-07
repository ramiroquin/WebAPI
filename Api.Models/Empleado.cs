using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Models;

public partial class Empleado
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public int? Edad { get; set; }

    public int? Dni { get; set; }

    [EmailAddress(ErrorMessage = "Por favor, ingresa un e-mail valido.")]
    public string? Email { get; set; }
}
