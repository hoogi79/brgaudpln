//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AnfGefB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Anforderungen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Anforderungen()
        {
            this.Bezug = new ObservableListSource<Bezug>();
            this.Gefährdungsfaktoren = new ObservableListSource<Gefährdungsfaktoren>();
        }
    
        public int ID { get; set; }
        public int GesetzID { get; set; }
        public int Paragraph { get; set; }
        public Nullable<int> UebergeordneteID { get; set; }
        public string AnforderungenText { get; set; }
        public bool Besondere_Fachkunde { get; set; }
        public string Daten { get; set; }
    
        public virtual Gesetze Gesetze { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableListSource<Bezug> Bezug { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableListSource<Gefährdungsfaktoren> Gefährdungsfaktoren { get; set; }
    }
}
