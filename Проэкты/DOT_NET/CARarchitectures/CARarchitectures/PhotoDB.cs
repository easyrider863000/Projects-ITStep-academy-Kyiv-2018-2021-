//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CARarchitectures
{
    using System;
    using System.Collections.Generic;
    
    public partial class PhotoDB
    {
        public int Id { get; set; }
        public string PhotoPath { get; set; }
        public Nullable<int> CarId { get; set; }
    
        public virtual CarDB CarDB { get; set; }
    }
}
