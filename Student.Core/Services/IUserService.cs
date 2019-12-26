using System.Threading.Tasks;
using Student.Core.Models.User;

namespace Student.Core.Services
{
    public interface IUserService
    {
        Task<UserInfoModel> AuthenticateAsync(string username, string password);
        Task<object> CreateTestUser();
    }
}