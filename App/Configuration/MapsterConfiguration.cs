using Comandante.Domain.Entities;
using Comandante.Persistance.Models.PromotionModelsEf;
using Mapster;

namespace Comandante.App.Configuration
{
    public class MappingProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Promotion, PromotionEf>()
                .Map(dest => dest.IsActive, src => src.IsActive ? 1 : 0)
                .Map(dest => dest.IsDeleted, src => src.IsDeleted ? 1 : 0)
                .Map(dest => dest.IsLinked, src => src.IsLinked ? 1 : 0)
                .Map(dest => dest.IsOnCash, src => src.IsOnCash ? 1 : 0)
                .Map(dest => dest.IsRepeated, src => src.IsRepeated ? 1 : 0)
                .Map(dest => dest.IsTest, src => src.IsTest ? 1 : 0)
                .Map(dest => dest.SeparateBySeller, src => src.SeparateBySeller ? 1 : 0);
                

            config.NewConfig<PromotionEf, Promotion>()
                .Map(dest => dest.IsActive, src => src.IsActive != null && src.IsActive > 0)
                .Map(dest => dest.IsDeleted, src => src.IsDeleted != null && src.IsDeleted > 0)
                .Map(dest => dest.IsLinked, src => src.IsLinked != null && src.IsLinked > 0)
                .Map(dest => dest.IsOnCash, src => src.IsOnCash != null && src.IsOnCash > 0)
                .Map(dest => dest.IsRepeated, src => src.IsRepeated != null && src.IsRepeated > 0)
                .Map(dest => dest.IsTest, src => src.IsTest != null && src.IsTest > 0)
                .Map(dest => dest.SeparateBySeller, src => src.SeparateBySeller != null && src.SeparateBySeller > 0)
                .Map(dest => dest.PromotionExecutions, src => src.PromotionExecutions.Adapt<List<PromotionExecution>>())
                .PreserveReference(true);


            config.NewConfig<PromotionExecution, PromotionExecutionEf>()
                .Map(dest => dest.IsActive, src => src.IsActive ? 1 : 0)
                .Map(dest => dest.IsDeleted, src => src.IsDeleted ? 1 : 0);


            config.NewConfig<PromotionExecutionEf, PromotionExecution>()
                .Map(dest => dest.IsActive, src => src.IsActive != null && src.IsActive > 0)
                .Map(dest => dest.IsDeleted, src => src.IsDeleted != null && src.IsDeleted > 0);


            config.NewConfig<PromotionCondition, PromotionConditionEf>()
                .Map(dest => dest.IsActive, src => src.IsActive ? 1 : 0)
                .Map(dest => dest.IsDeleted, src => src.IsDeleted ? 1 : 0)
                .Map(dest => dest.IsAccumulation, src => src.IsAccumulation ? 1 : 0);

            config.NewConfig<PromotionConditionEf, PromotionCondition>()
                .Map(dest => dest.IsActive, src => src.IsActive != null && src.IsActive > 0)
                .Map(dest => dest.IsDeleted, src => src.IsDeleted != null && src.IsDeleted > 0)
                .Map(dest => dest.IsAccumulation, src => src.IsDeleted > 0);

            config.NewConfig<PromotionGroup, PromotionGroupEf>()
                .Map(dest => dest.IsActive, src => src.IsActive ? 1 : 0)
                .Map(dest => dest.IsDeleted, src => src.IsDeleted ? 1 : 0);

            config.NewConfig<PromotionGroupEf, PromotionGroup>()
                .Map(dest => dest.IsActive, src => src.IsActive != null && src.IsActive > 0)
                .Map(dest => dest.IsDeleted, src => src.IsDeleted != null && src.IsDeleted > 0);

            config.NewConfig<PromotionGroupsCompatibility, PromotionGroupsCompatibilityEf>()
                .Map(dest => dest.IsActive, src => src.IsActive ? 1 : 0)
                .Map(dest => dest.IsDeleted, src => src.IsDeleted ? 1 : 0);

            config.NewConfig<PromotionGroupsCompatibilityEf, PromotionGroupsCompatibility>()
                .Map(dest => dest.IsActive, src => src.IsActive != null && src.IsActive > 0)
                .Map(dest => dest.IsDeleted, src => src.IsDeleted != null && src.IsDeleted > 0);

            config.NewConfig<EventGroup, EventGroupEf>()
                .Map(dest => dest.IsActive, src => src.IsActive ? 1 : 0)
                .Map(dest => dest.IsDeleted, src => src.IsDeleted ? 1 : 0);

            config.NewConfig<EventGroupEf, EventGroup>()
                .Map(dest => dest.IsActive, src => src.IsActive != null && src.IsActive > 0)
                .Map(dest => dest.IsDeleted, src => src.IsDeleted != null && src.IsDeleted > 0);

            config.NewConfig<EventGroupDetail, EventGroupDetailEf>()
                .Map(dest => dest.IsActive, src => src.IsActive ? 1 : 0)
                .Map(dest => dest.IsDeleted, src => src.IsDeleted ? 1 : 0);

            config.NewConfig<EventGroupDetailEf, EventGroupDetail>()
                .Map(dest => dest.IsActive, src => src.IsActive != null && src.IsActive > 0)
                .Map(dest => dest.IsDeleted, src => src.IsDeleted != null && src.IsDeleted > 0);

        }
    }
}
