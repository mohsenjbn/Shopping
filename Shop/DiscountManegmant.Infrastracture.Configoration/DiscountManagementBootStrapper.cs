using DiscontManagement.Infrastracture.EfCore;
using DiscontManagement.Infrastracture.EfCore.Repository;
using DiscountManagement.Apolication;
using DiscountManagement.Application.Contracts.CustomerDiscount;
using DiscountManagment.Domain.CustomerDiscountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DiscountManegmant.Infrastracture.Configoration
{
    public class DiscountManagementBootStrapper
    {
        public static void configore(IServiceCollection services,string connectionstring)
        {
            services.AddTransient<ICustomerDiscountApplication, CustomerDiscountApplication>();
            services.AddTransient<ICustomerDiscountRepositpry, CustomerDiscountRepository>();


            services.AddDbContext<DiscountContext>(p=>p.UseSqlServer(connectionstring));

        }
    }
}