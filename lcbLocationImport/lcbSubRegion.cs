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
    
    public partial class lcbSubRegion
    {
        public int Id { get; set; }
        public int lcbsubregion_id { get; set; }
        public string lcbsubregion_description { get; set; }
        public System.DateTime last_updated { get; set; }
        public int lcbRegionId { get; set; }
    
        public virtual lcbRegion lcbRegion { get; set; }
    }
}
