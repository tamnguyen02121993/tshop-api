using Mapster;
using TShop.Api.Features.Tags.Commands.CreateTag;
using TShop.Api.Features.Tags.Commands.UpdateTag;
using TShop.Api.Models;
using TShop.Contracts.Tag;

namespace TShop.Api.Mappings;

public class TagMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateTagRequest, CreateTagCommand>();
        config.NewConfig<UpdateTagRequest, UpdateTagCommand>().IgnoreNullValues(true);
        config.NewConfig<UpdateTagCommand, Tag>().IgnoreNullValues(true);
        config.NewConfig<Tag, TagResponse>();
    }
}
