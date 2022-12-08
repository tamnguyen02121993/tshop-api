using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TShop.Api.Features.Authentication.Commands.Login;
using TShop.Api.Features.Authentication.Commands.RefreshToken;
using TShop.Api.Features.Authentication.Commands.Register;
using TShop.Api.Features.Authentication.Commands.RevokeToken;
using TShop.Api.Features.Authentication.Queries.GetUserByEmail;
using TShop.Api.Features.Authentication.Queries.GetUserById;
using TShop.Api.Services.Authentication;
using TShop.Contracts.Authentication;

namespace TShop.Api.Controllers;

[Authorize]
public class AccountsController : ApiController
{
    private readonly ISender _sender;
    public AccountsController(ISender sender)
    {
        _sender = sender;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        ErrorOr<LoginResponse> loginResult = await _sender.Send(new LoginCommand
        {
            UserName = request.UserName,
            Password = request.Password,
            RememberMe = request.RememberMe
        });

        return loginResult.Match(loginResponse => Ok(loginResponse),
            errors => Problem(errors));
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        ErrorOr<UserResponse> registerResult = await _sender.Send(new RegisterCommand
        {
            UserName = request.UserName,
            Password = request.Password,
            ConfirmPassword = request.ConfirmPassword,
            PhoneNumber = request.PhoneNumber,
            Gender = request.Gender,
            Birthday = request.Birthday,
            Email = request.Email
        });

        return registerResult.Match(user => CreatedAtAction(nameof(GetUserByEmail), new { email = request.Email}, user),
            errors => Problem(errors));
    }

    [HttpPost("users/{id:int}")]
    public async Task<IActionResult> GetUserById([FromRoute]int id)
    {
        ErrorOr<UserResponse> userResult = await _sender.Send(new GetUserByIdQuery
        {
            Id = id
        });

        return userResult.Match(user => Ok(user),
            errors => Problem(errors));
    }

    [HttpPost("users")]
    public async Task<IActionResult> GetUserByEmail([FromQuery] string email)
    {
        ErrorOr<UserResponse> userResult = await _sender.Send(new GetUserByEmailQuery
        {
            Email = email
        });

        return userResult.Match(user => Ok(user),
            errors => Problem(errors));
    }

    [HttpPost("revoke-token")]
    public async Task<IActionResult> RevokeToken([FromQuery]string name)
    {
        ErrorOr<Updated> revokeTokenResult = await _sender.Send(new RevokeTokenCommand
        {
            Name = name
        });

        return revokeTokenResult.Match(_ => Ok(), errors => Problem(errors));
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
    {
        ErrorOr<TokenResponse> refreshTokenResult = await _sender.Send(new RefreshTokenCommand
        {
            AccessToken = request.AccessToken,
            RefreshToken = request.RefreshToken
        });

        return refreshTokenResult.Match(tokenResponse => Ok(tokenResponse), errors => Problem(errors));
    }
}
