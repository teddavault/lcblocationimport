//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace lcbLocationImport
{
    using System;
    using System.Collections.Generic;
    
    public partial class lcbRegion
    {
        public lcbRegion()
        {
            this.lcbSubRegions = new HashSet<lcbSubRegion>();
        }
    
        public int Id { get; set; }
        public int lcbregion_id { get; set; }
        public string lcbregion_description { get; set; }
        public System.DateTime last_updated { get; set; }
        public int CountryId { get; set; }
    
        public virtual lcbCountry lcbCountry { get; set; }
        public virtual ICollection<lcbSubRegion> lcbSubRegions { get; set; }
    }
}
