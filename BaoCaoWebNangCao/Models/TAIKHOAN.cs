//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BaoCaoWebNangCao.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TAIKHOAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TAIKHOAN()
        {
            this.DANHMUCCONGTHUCs = new HashSet<DANHMUCCONGTHUC>();
            this.GIOHANGs = new HashSet<GIOHANG>();
            this.YEUTHICHes = new HashSet<YEUTHICH>();
        }
    
        public int ID { get; set; }
        public string TENDANGNHAP { get; set; }
        public string MATKHAU { get; set; }
        public Nullable<int> LOAITAIKHOAN { get; set; }
        public string TENNGUOIDUNG { get; set; }
        public Nullable<System.DateTime> NGAYSINH { get; set; }
        public string DIACHI { get; set; }
        public string SODIENTHOAI { get; set; }
        public string EMAIL { get; set; }
        public string GIOITINH { get; set; }
        public string HINHANH { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DANHMUCCONGTHUC> DANHMUCCONGTHUCs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GIOHANG> GIOHANGs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<YEUTHICH> YEUTHICHes { get; set; }
    }
}
