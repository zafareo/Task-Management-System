﻿using LazyCache;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Todo.Api.Services;

public class LazyCacheAttribute : ActionFilterAttribute
{
    private static IAppCache _cache;
    private string _Key;
    private readonly int _slidingTime;
    private readonly int _absoluteExpirationRelativeToNow;

    public LazyCacheAttribute(int slidingTime, int absoluteExpirationRelativeToNow)
    {
        _slidingTime = slidingTime;
        _absoluteExpirationRelativeToNow = absoluteExpirationRelativeToNow;
    }

    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        _cache = context.HttpContext.RequestServices.GetRequiredService<IAppCache>();
        _Key = context.HttpContext.Request.Path;

        //var res = await _cache.GetOrAddAsync(_Key, () => next(), TimeSpan.FromSeconds(90));
        var res = await _cache.GetOrAddAsync(_Key, c =>
        {
            c.SlidingExpiration = TimeSpan.FromSeconds(_slidingTime);
            c.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_absoluteExpirationRelativeToNow);
            return next();
        });

        if (res != null)
        {
            context.Result = res.Result;
        }

    }
}
