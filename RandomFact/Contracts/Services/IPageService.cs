using System;

namespace RandomFact.Contracts.Services
{
    public interface IPageService
    {
        Type GetPageType(string key);
    }
}
