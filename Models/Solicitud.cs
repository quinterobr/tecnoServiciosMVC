using System;
using System.Collections.Generic;

namespace AplicacionProyectoMVC.Models;

public partial class Solicitud
{
    public int IdSolicitud { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public int? IdRegistro { get; set; }

    public virtual Registro? IdRegistroNavigation { get; set; }
}
