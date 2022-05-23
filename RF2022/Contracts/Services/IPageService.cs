using System;

namespace RF2022.Contracts.Services
{
    public interface IPageService
    {
        Type GetPageType(string key);
    }
}
