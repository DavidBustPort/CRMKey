namespace Domain.Entities.Sianwebcentral;

public record RefreshTokens(
    int Id,
    int UserId,
    string Token,
    DateTime ExpiryDate,
    bool IsActive,
    DateTime CreateAt,
    DateTime? RevokedAt,
    int? SucursalId
);