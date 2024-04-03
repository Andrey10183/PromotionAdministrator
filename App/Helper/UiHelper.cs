using Comandante.Domain.Entities;

namespace Comandante.App.Helper
{
    public static class UiHelper
    {
        public static string GetDate(DateTime? date)
        {
            return date?.ToString("dd.MM.yyyy HH:mm:ss") ?? "";
        }

        public static IEnumerable<string> GetPromoGroupNames(List<PromotionGroup> promoGroup)
        {
            return promoGroup.Select(x => x.Code);
        }

        

    }
}
