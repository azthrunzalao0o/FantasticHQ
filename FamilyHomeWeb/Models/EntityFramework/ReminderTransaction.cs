//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FamilyHomeWeb.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class ReminderTransaction
    {
        public int ReminderTransID { get; set; }
        public int ReminderID { get; set; }
        public bool IsCompleted { get; set; }
        public string CompletedBy { get; set; }
    
        public virtual Reminder Reminder { get; set; }
    }
}
