using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using test.Interface;
using test.Models.MessageModel;
using test.Models.UserModel;
using test.Services;
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
            var users = await db.LoadUsers(userId);
            users.Data = users.Data;//.Where(u => u.Id != userId).ToList();
            return Ok(users);
        }
        [HttpPost]
        public async Task<IActionResult> LoadMessages(UserDto Targetuser)
        {
            var a = db.GetAllUserWithFollowing();

            var UserId = new EncryptionUtility().UserInfo(HttpContext).Id;
            var messages = await db.LoadMessages(UserId, Targetuser.Id, Targetuser.PageNumber, Targetuser.PageCount);
            return Ok(messages);
        }
        [HttpPost]
        public async Task<IActionResult> LoadMessage_LastMessageTime(UserDto model)
        {
            var UserId = new EncryptionUtility().UserInfo(HttpContext).Id;
            var messages = await db.LoadMessage_LastMessageTime(UserId, model.Id, model.PageNumber, model.PageCount, model.FirstMessageTime);
            return Ok(messages);
        }
        public async Task<IActionResult> Mod_Contacts()
        {
            return View("~/Views/Chat/Mod_Contacts.cshtml");
        }
        [HttpPost]
        public async Task<IActionResult> SearchUsers(UserDto model)
        {
            model.FollowerUserId = new EncryptionUtility().UserInfo(HttpContext).Id;
            var user = await db.SearchUser(model);
            return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> AddContact(Contact model)
        {
            model.FollowerUserId = new EncryptionUtility().UserInfo(HttpContext).Id;
            var result = await db.AddContact(model);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteContact(Contact model)
        {
            model.FollowerUserId = new EncryptionUtility().UserInfo(HttpContext).Id;
            var result = await db.DeleteContact(model);
            return Ok(result);
        }
    }
}
