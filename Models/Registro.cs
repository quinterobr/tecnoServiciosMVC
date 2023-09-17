using System;
using System.Collections.Generic;

namespace AplicacionProyectoMVC.Models;

public partial class Registro
{
    public int IdRegistro { get; set; }

    public DateTime FechaCreacion { get; set; }

    public int? IdCliente { get; set; }

    public int? IdEmpleado { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Empleado? IdEmpleadoNavigation { get; set; }

    public virtual ICollection<Incidente> Incidentes { get; set; } = new List<Incidente>();

    public virtual ICollection<OrdenDeCambio> OrdenDeCambios { get; set; } = new List<OrdenDeCambio>();

    public virtual ICollection<Solicitud> Solicituds { get; set; } = new List<Solicitud>();
}
