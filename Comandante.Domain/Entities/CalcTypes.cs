namespace Comandante.Domain.Entities;

public static class CalcTypes
{
    public static List<CalcTypeModels> ValueCalcTypes
    {
        #region Параметры калькуляций

        get
        {
            return new List<CalcTypeModels>
            {
                new CalcTypeModels
                    { Id = "N", Name = "Отсутствует" },
                new CalcTypeModels
                    { Id = "V", Name = "Начальное значение триггера" },
                new CalcTypeModels
                    { Id = "VXP", Name = "Начальное значение триггера умноженное на параметр" },
                new CalcTypeModels
                    { Id = "EVXP", Name = "Итоговое значение триггера умноженное на параметр" }, 
                new CalcTypeModels
                    { Id = "EVXPriceFromParam", Name = "Итоговое значение триггера умноженное на % из прайса (ID прайса в поле Param)" }, 
                new CalcTypeModels
                    { Id = "EVXPriceFromParamKoef", Name = "Итоговое значение триггера умноженное на коэффициент из прайса (ID прайса в поле Param)" },
                new CalcTypeModels
                {
                    Id = "EVXPriceFromParam",
                    Name = "Итоговое значение триггера умноженное на % из прайса (ID прайса в поле Param)"
                },
                new CalcTypeModels
                {
                    Id = "EVXPriceFromParamKoef",
                    Name = "Итоговое значение триггера умноженное на коэффициент из прайса (ID прайса в поле Param)"
                },
                new CalcTypeModels
                    { Id = "C", Name = "Значение из поля Param" },
                new CalcTypeModels()
                    { Id = "BV", Name = "Значение основания Value" },
                new CalcTypeModels()
                    { Id = "BVXP", Name = "Значение основания Value умноженное на Param" },
                new CalcTypeModels()
                    { Id = "CheckTotalXP", Name = "Сумма чека умноженная на Param" },
                new CalcTypeModels
                    { Id = "EVxPaymentPercent", Name = "Наценка по кредиту" },
                new CalcTypeModels
                    { Id = "EVxPaymentPercentOnCash", Name = "Скидка по кредиту на кассе" },
                new CalcTypeModels
                {
                    Id = "MinFromParamOrPoints",
                    Name = "Минимальное из значения параметра или остатка в бальной корзине"
                },
                new CalcTypeModels
                {
                    Id = "PriceForParentByShop",
                    Name = "Цена на товар основание из прайса по коду магазина в поле параметр"
                },
                new CalcTypeModels
                    { Id = "EPVXP", Name = "Итоговое значение основания умноженное на параметр" },
                new CalcTypeModels
                {
                    Id = "PriceForTriggerByShop", Name = "Цена на триггер из прайса по коду магазина в поле параметр"
                },
                new CalcTypeModels
                {
                    Id = "PriceForTriggerByShopXVat",
                    Name = "Цена на триггер из прайса по коду магазина в поле параметр с НДС"
                },
                new CalcTypeModels
                    { Id = "PointsXParam", Name = "Значение корзины умноженое на параметр" },
                new CalcTypeModels
                {
                    Id = "MinFromParamXValueOrPoints",
                    Name = "Минимальное из значения параметра умноженого на цену или остатка в бальной корзине"
                },
                new CalcTypeModels
                    { Id = "CheckTotalXParam", Name = "Текущая сумма чека умноженая на параметр" },
                new CalcTypeModels
                    { Id = "BonusToSeller", Name = "Текущий бонус продавцу" },
                new CalcTypeModels
                    { Id = "BonusForTriggerFromPrice", Name = "Бонус на триггер из прайса по коду ид в поле параметр" },
                new CalcTypeModels
                {
                    Id = "MinFromPriceByShopOrPoints",
                    Name = "Минимальное значение из цены из прайса и остатка в бальной корзине"
                },
                new CalcTypeModels
                {
                    Id = "ParamIfCurPriceMoreParamElseZero",
                    Name = "Параметр, если тек. цена больше чем параметр иначе 0"
                },
                new CalcTypeModels
                {
                    Id = "ValueFromPrice",
                    Name = "Взять значение параметра начисления из прайса указаного в поле параметр"
                },
            };
        }

        #endregion
    }

    public static List<FilterType> FilterTypes
    {
        #region Фильтр

        get
        {
            return new List<FilterType>
            {
                new FilterType() { Id = "I", Name = "Включая" },
                new FilterType() { Id = "X", Name = "Исключая" }
            };
        }

        #endregion
    }

    public static List<CatalogParam> CatalogParams
    {
        #region Параметры для каталога

        get
        {
            return new List<CatalogParam>
            {
                new CatalogParam { Id = "ARTICLE", Name = "Артикул", Priority = "10" },
                new CatalogParam { Id = "BRAND", Name = "Брэнд", Priority = "10" },
                new CatalogParam { Id = "PRICE1", Name = "Основная цена", Priority = "10" },
                new CatalogParam { Id = "PRICE2", Name = "Цена на случай если отстутствует основная", Priority = "20" },
                new CatalogParam { Id = "RATE", Name = "Процентная ставка", Priority = "10" },
                new CatalogParam { Id = "GROUP", Name = "Группа события", Priority = "10" },
                new CatalogParam { Id = "PAYTYPE", Name = "Вид оплаты", Priority = "10" },
                new CatalogParam { Id = "PAYFORM", Name = "Форма оплаты", Priority = "10" },
                new CatalogParam { Id = "PRICESFX", Name = "Суффикс цены", Priority = "10" },
                new CatalogParam { Id = "PRODTYPE", Name = "Тип товара", Priority = "10" },
            };
        }

        #endregion
    }

    public static List<CatalogType> CatalogTypes
    {
        #region Типы события

        get
        {
            return new List<CatalogType>
            {
                new CatalogType { Id = "GOODS", Name = "Товар" },
                new CatalogType { Id = "DISCOUNT", Name = "Скидка" },
                new CatalogType { Id = "SERVICE", Name = "Услуга" },
                new CatalogType { Id = "PAYMENT", Name = "Оплата" },
                new CatalogType { Id = "BUTTON", Name = "Оперативная уценка" },
                new CatalogType { Id = "ACTION", Name = "Action" },
                new CatalogType { Id = "INEVENT", Name = "Входящее событие" },
                new CatalogType { Id = "SHOP", Name = "Магазин" }
            };
        }

        #endregion
    }

    public static List<RemindType> RemindTypetValues
    {
        get
        {
            return new List<RemindType>
            {
                new RemindType
                {
                    Id = "None",
                    Name = "Отстутствует"
                },
                new RemindType
                {
                    Id = "Propose",
                    Name = "Предлагать"
                },
                new RemindType
                {
                    Id = "Require",
                    Name = "Требовать"
                }
            };
        }
    }

    public static List<EventsSortType> EventsSortTypeValues
    {
        get
        {
            return new List<EventsSortType>
            {
                new EventsSortType()
                {
                    Id = "None",
                    Name = "Отсутствует"
                },
                new EventsSortType()
                {
                    Id = "Price",
                    Name = "Сортировать по цене"
                },
                new EventsSortType()
                {
                    Id = "PriceDesc",
                    Name = "Сортировать по убыванию цены"
                },
                new EventsSortType()
                {
                    Id = "Priority",
                    Name = "Сортировать по приоритету"
                },
                new EventsSortType()
                {
                    Id = "Gift",
                    Name = "Сортировать по признаку подарка"
                },
            };
        }
    }

    public static List<PaymentCompatibilityType> PaymentCompabilityTypeValues
    {
        get
        {
            return new List<PaymentCompatibilityType>()
            {
                new PaymentCompatibilityType()
                {
                    Id = 0,
                    Name = "Совместим со всеми"
                },
                new PaymentCompatibilityType()
                {
                    Id = 1,
                    Name = "Не совместим с рассрочкой"
                },
                new PaymentCompatibilityType()
                {
                    Id = 2,
                    Name = "Не совместим с кредитом"
                },
                new PaymentCompatibilityType()
                {
                    Id = 12,
                    Name = "Не совместим с рассрочкой и кредитом"
                },
            };
        }
    }

    public static List<SaleChannel> SaleChannelsValues
    {
        get
        {
            return new List<SaleChannel>()
            {
                new SaleChannel()
                {
                    Id = 0,
                    Name = "Все продажи"
                },
                new SaleChannel()
                {
                    Id = 1,
                    Name = "Розничные продажи"
                },
                new SaleChannel()
                {
                    Id = 2,
                    Name = "Оптовые продажи"
                },
                new SaleChannel()
                {
                    Id = 3,
                    Name = "Интернет продажи"
                },
            };
        }
    }

    public static List<PromoGroupCompatibilityType> PromoGroupCompabilityValues
    {
        get
        {
            return new List<PromoGroupCompatibilityType>()
            {
                new PromoGroupCompatibilityType()
                {
                    Id = 0,
                    Name = "Отсутствует"
                },
                new PromoGroupCompatibilityType()
                {
                    Id = 1,
                    Name = "Совместим"
                },
                new PromoGroupCompatibilityType()
                {
                    Id = 2,
                    Name = "Не совместим"
                },
            };
        }
    }
}
