//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRM_system.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class AppealTechnicalSupport
    {
        public int IdAppealTechnicalSupport { get; set; }
        public string BriefDescription { get; set; }
        public string Description { get; set; }
        public int IdEmployee { get; set; }
        public byte[] Image { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}
