using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public class Calificacion
{
    public int Id { get; set; }
    public string Descripcion { get; set; }

    public byte Nota { get; set; }        // antes decimal
    public byte Porcentaje { get; set; }  // antes decimal

    public int MatriculaId { get; set; }
    // public Matricula Matricula { get; set; }
    public virtual Matricula? Matricula { get; set; } = null!;
}