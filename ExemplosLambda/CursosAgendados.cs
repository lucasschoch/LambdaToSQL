//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExemplosLambda
{
    using System;
    using System.Collections.Generic;
    
    public partial class CursosAgendados
    {
        public CursosAgendados()
        {
            this.Alunos_CursosAgendados = new HashSet<Alunos_CursosAgendados>();
        }
    
        public int ID { get; set; }
        public int IdCurso { get; set; }
        public int IdProfessor { get; set; }
        public string Periodo { get; set; }
        public System.DateTime DtInicial { get; set; }
        public System.DateTime DtFinal { get; set; }
    
        public virtual ICollection<Alunos_CursosAgendados> Alunos_CursosAgendados { get; set; }
        public virtual CursosClarify CursosClarify { get; set; }
        public virtual Professores Professores { get; set; }
    }
}
