using Grpc.Core;

namespace Discount.Grpc.Services;

public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
{
    public override Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        // TODO: GetDiscount from Database
        return base.GetDiscount(request, context);
    }

    public override Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        // TODO: CreateDiscount in Database
        return base.CreateDiscount(request, context);
    }

    public override Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        // TODO: UpdateDiscount in Database
        return base.UpdateDiscount(request, context);
    }

    public override Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
    {
        // TODO: DeleteDiscount in Database
        return base.DeleteDiscount(request, context);
    }
}