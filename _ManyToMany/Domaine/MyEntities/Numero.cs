using System;
using System.Collections.Generic;

namespace Domaine.MyEntities
{
    public class Numero
    {
        //Rappel : sur une entité, un membre de type long ou int(et non uint), ayant pour Nom "Id" ou bien "[NomDeLaClasse][Id]" sera automatiquement considéré par EF,
        //         comme étant la PK auto-incr. (Identity) de cette classe.
        public int Id { get; set; }

        public uint Valeur { get; set; }

        public IList<TirageLoto> Tirages { get; init; }

    }
}
