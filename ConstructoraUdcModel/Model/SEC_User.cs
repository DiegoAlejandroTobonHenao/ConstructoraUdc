//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConstructoraUdcModel.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class SEC_User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SEC_User()
        {
            this.SEC_Session = new HashSet<SEC_Session>();
            this.SEC_User_Role = new HashSet<SEC_User_Role>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string last_name { get; set; }
        public string document { get; set; }
        public string email { get; set; }
        public string password_user { get; set; }
        public string phone { get; set; }
        public int city_id { get; set; }
        public bool removed { get; set; }
        public Nullable<System.DateTime> removed_date { get; set; }
        public System.DateTime create_date { get; set; }
        public Nullable<System.DateTime> ipdate_date { get; set; }
        public Nullable<int> remove_user_id { get; set; }
        public Nullable<int> create_user_id { get; set; }
        public Nullable<int> update_user_id { get; set; }
    
        public virtual PMT_City PMT_City { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SEC_Session> SEC_Session { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SEC_User_Role> SEC_User_Role { get; set; }
    }
}
