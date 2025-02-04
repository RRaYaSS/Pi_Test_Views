using System;
using System.Collections.Generic;

namespace Pi_Projeto_Integrador.Models;

public partial class cadUsuario
{
    public int cdUsuario { get; set; }

    public string? usuarioLogin { get; set; }

    public string? senha { get; set; }

    public DateTime? dtCriacao { get; set; }

    public int? usuarioC { get; set; }
}
