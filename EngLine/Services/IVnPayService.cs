﻿namespace EngLine.Models.Services
{
    public interface IVnPayService
    {
        string CreatePaymentUrl(HttpContext context, VnPayRequestModel model);
        VnPayResponseModel PaymentExcute(IQueryCollection collections);
    }
}
