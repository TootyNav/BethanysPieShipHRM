using System.Collections.Generic;
using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.ApiNet6.Models
{
    public interface IJobCategoryRepository
    {
        IEnumerable<JobCategory> GetAllJobCategories();
        JobCategory GetJobCategoryById(int jobCategoryId);
    }
}
