//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TourAgency
{
    using System;
    using System.Collections.Generic;
    
    public partial class Review
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public double Rating { get; set; }
        public int GroupTourId { get; set; }
        public int PersonId { get; set; }
    
        public virtual GroupTour GroupTour { get; set; }
        public virtual Person Person { get; set; }
    }
}
