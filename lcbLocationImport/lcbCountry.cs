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
    
    public partial class lcbCountry
    {
        public lcbCountry()
        {
            this.lcbRegions = new HashSet<lcbRegion>();
        }
    
        public int Id { get; set; }
        public int lcbcountry_id { get; set; }
        public string lcbcountry_description { get; set; }
        public System.DateTime last_updated { get; set; }
    
        public virtual ICollection<lcbRegion> lcbRegions { get; set; }
    }
}
