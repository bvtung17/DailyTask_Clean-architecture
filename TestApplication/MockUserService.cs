using DailyTask.Application.Contracts.Interfaces.IServices;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication
{
    public static class MockUserService
    {
        public static Mock<IUserService> GetUserService()
        {
            var mockUserService = new Mock<IUserService>();           
            //mockUserService.Setup(x => x.GetAll(0)).Returns(mockUserRepo.Object);
            return new Mock<IUserService>();
        }
    }
}
