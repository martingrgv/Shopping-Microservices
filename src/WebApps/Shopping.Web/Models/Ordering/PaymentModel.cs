namespace Shopping.Web.Models.Ordering;

public record PaymentModel(
    string CardName,
    string CardNumber,
    string Expiration,
    int PaymentType);