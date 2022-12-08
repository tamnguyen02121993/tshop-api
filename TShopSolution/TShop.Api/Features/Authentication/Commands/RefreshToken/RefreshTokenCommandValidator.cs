﻿using FluentValidation;

namespace TShop.Api.Features.Authentication.Commands.RefreshToken;

public class RefreshTokenCommandValidator: AbstractValidator<RefreshTokenCommand>
{
	public RefreshTokenCommandValidator()
	{
		RuleFor(x => x.AccessToken).NotEmpty();
		 RuleFor(x => x.RefreshToken).NotEmpty();
    }
}
