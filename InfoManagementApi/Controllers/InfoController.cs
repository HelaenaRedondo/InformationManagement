using InformationManagaemenrServices;
using InformationManagement;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InfoManagementApi.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        InfoManageGetServ _userGetServices;
        InfoT _userTransactionServices;

        public UserController()
        {
            _userGetServices = new InfoManageGetServ();
            _userTransactionServices = new InfoT();
        }

        [HttpGet]
        public IEnumerable<InfoManagementApi.Information> GetUsers()
        {
            var activeusers = _userGetServices.GetAllInfo();

            List<InfoManagementApi.Information> information = new List<Information>();

            foreach (var item in activeusers)
            {
                information.Add(new InfoManagementApi.Information { firstname = item.firstname, middlename = item.middlename, lastname = item.lastname, email = item.email, contactnumber = item.contactnumber, address = item.address, password = item.password });
            }

            return information;
        }

        [HttpPost]
        public JsonResult AddUser(Information request)
        {
            var result = _userTransactionServices.CreateUser(request.firstname, request.password);

            return new JsonResult(result);
        }

        [HttpPatch]
        public JsonResult UpdateUser(Information request)
        {
            var result = _userTransactionServices.UpdateInfoT(request.firstname, request.password);

            return new JsonResult(result);
        }

        [HttpDelete]
        public JsonResult DeleteUser(Information request)
        {
            var result = _userTransactionServices.UpdateInfoT(request.firstname, request.password);

            return new JsonResult(result);
        }

    }
}
