using Comandante.Domain.Entities;

namespace Comandante.App.ModelsVm
{
    public class PromotionVm
    {
        public int PromotionId { get; set; }

        public string? SortType { get; set; }

        public int? Priority { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public bool IsLinked { get; set; }
        
        public string? PromotionGroup { get; set; }

        public bool IsRepeated { get; set; }

        public string? RemindTypeId { get; set; }

        public bool IsOnCash { get; set; }
        
        public string? OrderNumber { get; set; }

        public int? NextPromotion { get; set; }

        public bool IsTest { get; set; }

        public DateTime? CreateDateTime { get; set; }

        public DateTime? ChangeDateTime { get; set; }

        public Guid? UniqueKey { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public int? LastUserId { get; set; }

        public string? TrCode { get; set; }

        public string? SpeCode { get; set; }

        public bool SeparateBySeller { get; set; }

        public int PaymentCompatibility{ get; set; }
    
        public List<PromotionExecution> PromotionExecutions { get; set; }
    }
}
