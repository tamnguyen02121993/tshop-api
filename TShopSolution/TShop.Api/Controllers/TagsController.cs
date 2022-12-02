using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TShop.Api.Features.Tags.Commands.CreateTag;
using TShop.Api.Features.Tags.Commands.DeleteTag;
using TShop.Api.Features.Tags.Commands.UpdateTag;
using TShop.Api.Features.Tags.Queries.GetAllTags;
using TShop.Api.Features.Tags.Queries.GetAvailableTags;
using TShop.Api.Features.Tags.Queries.GetTagById;
using TShop.Contracts.Tag;

namespace TShop.Api.Controllers;

public class TagsController : ApiController
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;
    public TagsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTag(CreateTagRequest request)
    {
        ErrorOr<TagResponse> createTagResult = await _sender.Send(_mapper.Map<CreateTagCommand>(request));

        return createTagResult.Match(
            tag => CreatedAtAction(nameof(GetTagById), new {id = tag.Id}, tag),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetTagById([FromRoute]int id)
    {
        ErrorOr<TagResponse> getTagResult = await _sender.Send(new GetTagByIdQuery
        {
            Id = id,
        });

        return getTagResult.Match(
            tag => Ok(tag),
            errors => Problem(errors)
        );
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllTags()
    {
        List<TagResponse> tags = await _sender.Send(new GetAllTagsQuery());

        return Ok(tags);
    }

    [HttpGet("available")]
    public async Task<IActionResult> GetAvailableTags()
    {
        List<TagResponse> tags = await _sender.Send(new GetAvailableTagsQuery());

        return Ok(tags);
    }

    [HttpPut()]
    public async Task<IActionResult> UpdateTag([FromBody] UpdateTagRequest request)
    {
        ErrorOr<TagResponse> updateTagResult = await _sender.Send(_mapper.Map<UpdateTagCommand>(request));

        return updateTagResult.Match(
            tag => Ok(tag),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteTag([FromRoute] int id)
    {
        ErrorOr<Deleted> deleteTagResult = await _sender.Send(new DeleteTagCommand()
        {
            Id = id
        });
        return deleteTagResult.Match(
            deleted => NoContent(),
            errors => Problem(errors)
        );
    }
}