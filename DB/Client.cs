//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PenStore.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Client
    {
        public Client()
        {
            this.Order = new HashSet<Order>();
        }
    
        public int Id_client { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Nullable<int> Id_type { get; set; }
    
        public virtual Types Types { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
