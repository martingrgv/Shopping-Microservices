using Discount.Grpc.Data;
using Discount.Grpc.Models;
using Grpc.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Services;

public class DiscountService(DiscountDbContext dbContext, ILogger<DiscountService> logger)
    : DiscountProtoService.DiscountProtoServiceBase
{
    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        var coupon = await dbContext
            .Coupons
            .FirstOrDefaultAsync(c => c.ProductName == request.ProductName);

        if (coupon is null)
        {
            coupon = new Coupon
            {
                ProductName = "No Discount",
                Amount = 0
            };
        }
        
        logger.LogInformation("Discount retrieved for ProductName : {productName}, Amount : {amount}", coupon.ProductName, coupon.Amount);

        var couponModel = coupon.Adapt<CouponModel>();
        return couponModel;
    }

    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        var coupon = request.Coupon.Adapt<Coupon>();

        if (coupon is null)
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request coupon!"));
        }

        dbContext.Coupons.Add(coupon);
        await dbContext.SaveChangesAsync();
        
        logger.LogInformation("Discount is successfully created. ProductName : {ProductName}, Amount : {Amount}", coupon.ProductName, coupon.Amount);

        var couponModel = coupon.Adapt<CouponModel>();
        return couponModel;
    }

    public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        var coupon = request.Coupon.Adapt<Coupon>();

        if (coupon is null)
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request coupon!"));
        }

        dbContext.Coupons.Update(coupon);
        await dbContext.SaveChangesAsync();
        
        logger.LogInformation("Discount is successfully updated. Id : {id}, ProductName : {ProductName}, Amount : {Amount}", coupon.Id, coupon.ProductName, coupon.Amount);

        var couponModel = coupon.Adapt<CouponModel>();
        return couponModel;
    }

    public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
    {
        var coupon = await dbContext
            .Coupons
            .FirstOrDefaultAsync(c => c.ProductName == request.ProductName);

        if (coupon is null)
        {
            throw new RpcException(new Status(StatusCode.NotFound, $"Discount with ProductName = {request.ProductName} is not found."));
        }

        dbContext.Coupons.Remove(coupon);
        await dbContext.SaveChangesAsync();
        
        logger.LogInformation("Discount is successfully deleted. ProductName : {ProductName}", coupon.ProductName);

        return new DeleteDiscountResponse
        {
            Success = true
        };
    }
}