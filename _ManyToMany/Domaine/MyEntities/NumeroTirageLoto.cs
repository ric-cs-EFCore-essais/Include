namespace Domaine.MyEntities
{
    public class NumeroTirageLoto 
    {
        public int Id { get; set; }

        public int NumeroId { get; set; }
        public Numero Numero { get; set; } //ATTENTION : peut poser problème de réf. circulaire lorsque je fais un Include() dessus, ET que je veux jsonify ce résultat TEL QUEL.

        public int TirageLotoId { get; set; }
        public TirageLoto TirageLoto { get; set; } //ATTENTION : peut poser problème de réf. circulaire lorsque je fais un Include() dessus, ET que veux jsonify ce résultat TEL QUEL.
    }
}
