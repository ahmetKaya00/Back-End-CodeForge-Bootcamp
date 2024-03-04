using System.ComponentModel.DataAnnotations;

namespace EFCore.Data
{
    public class BootcampKayit{
        [Key]
        public int KayitId {get;set;}
        public int OgrenciId {get;set;}
        public int KursId { get; set; }
        public DateTime KayitTarihi {get;set;}
    }
}