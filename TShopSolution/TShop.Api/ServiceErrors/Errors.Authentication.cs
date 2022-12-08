using ErrorOr;

namespace TShop.Api.ServiceErrors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error UserNotFound => Error.NotFound(
            code: "User.NotFound",
            description: "User not found"
        );

        public static Error UserExisted => Error.NotFound(
            code: "User.UserExisted",
            description: "User existed"
        );

        public static Error CredentialInvalid => Error.Validation(
            code: "User.CredentialInvalid",
            description: "Username or password is invalid"
        );

        public static Error PasswordInvalid => Error.Validation(
           code: "User.PasswordInvalid",
           description: "Password invalid"
       );

        public static Error CreateUserFailure => Error.Failure(
           code: "User.CreateUserFailure",
           description: "Create user failure"
       );

        public static Error RoleNotFound => Error.NotFound(
           code: "Role.RoleNotFound",
           description: "Role not found"
       );

        public static Error AddToRoleFailure => Error.Failure(
           code: "Role.AddToRoleFailure",
           description: "Add user to role failure"
       );

        public static Error InvalidToken => Error.Validation(
           code: "Token.InvalidToken",
           description: "Invalid token"
       );
    }
}