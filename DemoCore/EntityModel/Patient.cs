
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Demo.Core.EntityModel
{

using System;
    using System.Collections.Generic;
    
public partial class Patient
{

    public long Id { get; set; }

    public Nullable<System.DateTime> DateOfBirth { get; set; }

    public Nullable<int> Gender { get; set; }

    public string Address { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public Nullable<long> CreatedBy { get; set; }

    public System.DateTime CreatedOn { get; set; }

    public Nullable<long> ModifiedBy { get; set; }

    public Nullable<System.DateTime> ModifiedOn { get; set; }

    public bool IsActive { get; set; }

    public string Name { get; set; }

}

}