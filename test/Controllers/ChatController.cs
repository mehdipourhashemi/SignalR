using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using test.Interface;
using test.Utilities;
using test.ViewModels;

namespace test.Controllers
{
    public class ChatController : Controller
    {
        private readonly IChatService db;

        public ChatController(IChatService db)
        {
            this.db = db;
        }
        public async Task<IActionResult> ChatPage()
        {
            var user = new EncryptionUtility().UserInfo(HttpContext);
            if (user != null)
            {
                return View("~/Views/Chat/Chat.cshtml");
            }
            return Redirect("~/authenticate/login");
        }
        public async Task<IActionResult> LoadUsers()
        {
            var userId = new EncryptionUtility().UserInfo(HttpContext).Id;
            var users = await db.LoadUsers();
            users.Data = users.Data.Where(u => u.Id != userId).ToList();
            return Ok(users);
        }
        [HttpPost]
        public async Task<IActionResult> LoadMessages(UserDto Targetuser)
        {
            var UserId = new EncryptionUtility().UserInfo(HttpContext).Id;
            var messages = await db.LoadMessages(UserId, Targetuser.Id, Targetuser.PageNumber, Targetuser.PageCount);
            return Ok(messages);
        }
    }
}
