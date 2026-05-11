namespace Application.Common.DTOs
{
    public record TokenResponse(
        string Token,
        string RefreshToken,
        DateTime ExpiresAt,
        string TokenType = "Bearer");
}
