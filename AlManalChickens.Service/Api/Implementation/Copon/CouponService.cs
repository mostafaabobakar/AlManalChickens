using AlManalChickens.Persistence;
using AlManalChickens.Services.DTO.CouponDto;
using Microsoft.EntityFrameworkCore;

namespace AlManalChickens.Services.Api.Implementation.Copon
{
    public class CouponService //: ICouponService
    {
        private readonly ApplicationDbContext _db;

        public CouponService(ApplicationDbContext db)
        {
            _db = db;
        }/*

        public async Task<Result<CouponDto>> UseCouponByUser(UseCouponDto useCouponDto, string userId, string lang = "ar")
        {
            var data = await ValidateCopoun(useCouponDto.couponCode, userId, lang);
            if (!data.Result.IsSuccess)
            {
                return new BaseResponse<CouponDto>
                {
                    IsSuccess = false,
                    key = ResponseStatus.failed.ToString(),
                    Message = data.Result.Message
                };
            }

            var coponDto = await GetLastTotalForUsingCoupon(data.Copoun.CoponCode, useCouponDto.total);

            return new BaseResponse<CouponDto>
            {
                IsSuccess = true,
                key = ResponseStatus.success.ToString(),
                Data = coponDto,
                Message = HelperMsg.creatMessage(lang, "تم استخدام الكوبون بنجاح", "The copon has been used successfully")
            };
        }

        public async Task<CopounValidationDto> ValidateCopoun(string copounCode, string userId, string lang = "ar")
        {
            DateTime Currentdate = HelperDate.GetCurrentDate();
            var Copoun = await _db.Copon
                    .Include(x => x.CountUsed)
                    .SingleOrDefaultAsync(c => c.CoponCode == copounCode && c.IsActive);

            if (Copoun is null)
            {
                return new CopounValidationDto
                {
                    Result = new BaseResponse<string>
                    {
                        IsSuccess = false,
                        key = ResponseStatus.failed.ToString(),
                        Message = HelperMsg.creatMessage(lang, "الكوبون غير موجود", "Coupon not found")
                    },
                    Copoun = Copoun
                };
            }

            bool IsUsedBefore = Copoun.CoponUseds.Any(x => x.UserId == userId);
            if (IsUsedBefore)
            {
                return new CopounValidationDto
                {
                    Result = new BaseResponse<string>
                    {
                        IsSuccess = false,
                        key = ResponseStatus.failed.ToString(),
                        Message = HelperMsg.creatMessage(lang, "تم استخدام الكوبون من قبل", "The copon has already been used")
                    },
                    Copoun = Copoun
                };
            }

            bool IsExpired = Copoun.Expirdate.Date < Currentdate.Date;
            if (IsExpired)
            {
                return new CopounValidationDto
                {
                    Result = new BaseResponse<string>
                    {
                        IsSuccess = false,
                        key = ResponseStatus.failed.ToString(),
                        Message = HelperMsg.creatMessage(lang, "عذرا لقد انتهت مده صلاحيه الكوبون", "Sorry, the validity of the coupon has expired")
                    },
                    Copoun = Copoun
                };
            }

            bool isMaxUsage = Copoun.Count <= Copoun.CountUsed;
            if (isMaxUsage)
            {
                return new CopounValidationDto
                {
                    Result = new BaseResponse<string>
                    {
                        IsSuccess = false,
                        key = ResponseStatus.failed.ToString(),
                        Message = HelperMsg.creatMessage(lang, "عذرا تم تجاوز الحد الاقصى لاستخدام الكوبون", "Sorry, the maximum use of the coupon has been exceeded")
                    },
                    Copoun = Copoun
                };
            }

            return new CopounValidationDto
            {
                Result = new BaseResponse<string>
                {
                    IsSuccess = true,
                    key = ResponseStatus.success.ToString(),
                },
                Copoun = Copoun
            };
        }*/

        public async Task<CouponDto> GetLastTotalForUsingCoupon(string couponCode, double total)
        {
            var couponDto = new CouponDto();
            Domain.Entities.Copon.Copon foundedCoupon = await _db.Copon.SingleOrDefaultAsync(x => x.CoponCode == couponCode && x.IsActive);
            double value = foundedCoupon.Discount / 100 * total;
            double lastTotal;
            if (value > foundedCoupon.limtDiscount)
            {
                value = foundedCoupon.limtDiscount;
                lastTotal = total - value;
            }
            else
            {
                lastTotal = total - value;
            }
            couponDto.CoponDiscountValue = value;
            couponDto.LasTotal = lastTotal;

            return couponDto;
        }
    }
}
