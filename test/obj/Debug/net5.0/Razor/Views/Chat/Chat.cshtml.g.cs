#pragma checksum "C:\Users\PS-IAU\Desktop\signalR\test\test\Views\Chat\Chat.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "998be3fdfe9fc67cd7760d8e6fed3a93aeb51515"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Chat_Chat), @"mvc.1.0.view", @"/Views/Chat/Chat.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\PS-IAU\Desktop\signalR\test\test\Views\_ViewImports.cshtml"
using test;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\PS-IAU\Desktop\signalR\test\test\Views\_ViewImports.cshtml"
using test.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"998be3fdfe9fc67cd7760d8e6fed3a93aeb51515", @"/Views/Chat/Chat.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"04aae2d41d7a1f2a1b7badf4f453e10febdd2915", @"/Views/_ViewImports.cshtml")]
    public class Views_Chat_Chat : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/swal-v2.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/SignalR.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/site.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/balloon.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onresize", new global::Microsoft.AspNetCore.Html.HtmlString("changeScreenSize()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\PS-IAU\Desktop\signalR\test\test\Views\Chat\Chat.cshtml"
   var user = new test.Utilities.EncryptionUtility().UserInfo(Context);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "998be3fdfe9fc67cd7760d8e6fed3a93aeb515155618", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "998be3fdfe9fc67cd7760d8e6fed3a93aeb515155880", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "998be3fdfe9fc67cd7760d8e6fed3a93aeb515156979", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "998be3fdfe9fc67cd7760d8e6fed3a93aeb515158078", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "998be3fdfe9fc67cd7760d8e6fed3a93aeb515159177", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <style>

        .LoadMore {
            width: 40px;
            height: 40px;
            border-radius: 50%;
            padding: 7px;
            margin: auto;
            position: absolute;
            top: 10px;
            left: 50%;
        }

        body {
            font-family: ""Lato"", sans-serif;
        }

        p.RecevedMessage {
            background-color: #487add;
            color: white;
            display: inline-block;
            float: left;
            padding: 10px;
            margin-bottom: 5px;
            max-width: 100%;
        }

        p.SentMessage {
            background-color: #28ab8f;
            color: white;
            display: inline-block;
            float: right;
            padding: 10px;
            margin-bottom: 5px;
            max-width: 100%;
        }

        .time {
            text-align: center;
            font-size: 12px;
            background-color: #f6f8f1;
        }

        .message-contain");
                WriteLiteral(@"er {
            width: 100%;
            padding: 10px;
            margin: 5px;
        }

        .sidenav {
            height: 100%;
            width: 250px;
            position: fixed;
            z-index: 1;
            top: 0;
            left: 0;
            background-color: #111;
            overflow-x: hidden;
            transition: 0.5s;
            padding-top: 60px;
        }

            .sidenav a {
                padding: 8px 8px 8px 32px;
                text-decoration: none;
                font-size: 25px;
                color: #818181;
                display: block;
                transition: 0.3s;
            }

                .sidenav a:hover {
                    color: #f1f1f1;
                }

            .sidenav .closebtn {
                position: absolute;
                top: 0;
                right: 25px;
                font-size: 36px;
                margin-left: 50px;
            }

        #main {
            transitio");
                WriteLiteral("n: margin-left .5s;\r\n            padding: 16px;\r\n        }\r\n\r\n        ");
                WriteLiteral("@media screen and (max-height: 450px) {\r\n            .sidenav {\r\n                padding-top: 15px;\r\n            }\r\n\r\n                .sidenav a {\r\n                    font-size: 18px;\r\n                }\r\n        }\r\n    </style>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "998be3fdfe9fc67cd7760d8e6fed3a93aeb5151513540", async() => {
                WriteLiteral(@"
    <div class=""modal fade"" id=""Contact_Modal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""modalLabel"" aria-hidden=""true"">
        <div class=""modal-dialog"" style=""width:90%"">
            <div class=""modal-content"">
                <div class=""modal-header "">
                    <h5 class=""alert alert-info"">Contact</h5>
                </div>
                <div id=""modalbody"" class=""modal-body"">
                    
                </div>
            </div>
        </div>
    </div>
    <div id=""users"" class=""sidenav"">
        <h5 style="" color: white; text-align: right;margin-right: 15px;"">لیست کاربران</h5>
        <hr style=""border: 1px solid #949494;"">
        <i id=""spiner"" class=""fa fa-spinner fa-spin"" style=""position: absolute; top: 20%; left: 50%; display: none; color: #007823; font-size: 55px; transform: translate(-50%, -50%);""></i>
        <div id=""users_Container""");
                BeginWriteAttribute("class", " class=\"", 3569, "\"", 3577, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n\r\n        </div>\r\n    </div>\r\n    <div");
                BeginWriteAttribute("class", " class=\"", 3619, "\"", 3627, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n        <h5> ");
#nullable restore
#line 128 "C:\Users\PS-IAU\Desktop\signalR\test\test\Views\Chat\Chat.cshtml"
        Write(user.FirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 128 "C:\Users\PS-IAU\Desktop\signalR\test\test\Views\Chat\Chat.cshtml"
                        Write(user.LastName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" - ");
#nullable restore
#line 128 "C:\Users\PS-IAU\Desktop\signalR\test\test\Views\Chat\Chat.cshtml"
                                         Write(user.UserName);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</h5>
    </div>
    <div id=""main"" style=""position:relative;"">
        <span   data-balloon-pos=""up"" data-balloon="" کاربران""  class=""btn"" style=""font-size:30px;cursor:pointer"" onclick=""OpenUser_Nav()""><i class=""fa fa-users""></i></span>
        <button  data-balloon-pos=""up"" data-balloon=""مدیریت کاربران"" style=""font-size:30px;cursor:pointer"" class=""btn"" onclick=""OpenModal_Contacts()""><i class=""fa fa-user-plus"" aria-hidden=""true""></i></button>
        <div id=""message_container"" style=""height:90%!important;"" class=""message-container row"">

        </div>
        <div class=""row fixed-bottom"" style=""position:fixed;bottom:20px;height:10%!important;"">
            <div class=""col-md-11"">
                <input id=""MessageText"" type=""text"" style=""float:right;width:50%;"" class=""form-control"" />
            </div>
            <div class=""col-md-1"">
                <button class=""btn"" style=""background-color:#28ab8f"" onclick=""SendMessage()""><i class=""	glyphicon glyphicon-plus""></i>send</button>
         ");
                WriteLiteral(@"   </div>
        </div>
    </div>
    
    <script>
        var UserId;
        var PageNumber = 0;
        var clock = `<i style = 'float:right;' class = ""fa fa-clock""></i>`;
        var tick = `<i  style = 'float:right;' class = ""fa fa-check""></i>`;

        $(document).ready(function () {

            changeScreenSize();
            $('#MessageText').on('keyup', function (el) {
                if (el.originalEvent.keyCode == 13) {
                    SendMessage();
                }
            });
        });
        function changeScreenSize() {
            if (window.innerWidth > 1000) {
                openNav();
            }
            else {
                closeNav();
            }
        }
        function openNav() {
            //document.getElementById(""users"").style.width = ""250px"";
            document.getElementById(""users"").style.left = ""0px"";
            //document.getElementById(""main"").style.marginLeft = ""250px"";
        }

        function closeNav()");
                WriteLiteral(@" {
            //document.getElementById(""users"").style.width = ""0"";
            document.getElementById(""users"").style.left = ""-250px"";
            //document.getElementById(""main"").style.marginLeft = ""0"";
        }

        const connection = new signalR.HubConnectionBuilder()
            .withUrl(""/chat"")
            .configureLogging(signalR.LogLevel.Information)
            .build();

        function start() {
            if (connection.state != 'Connected') {
                connection.start().then(() => {
                    swal.fire('', ""شما متصل شدید"", 'success');
                    LoadUsers().then(() => {
                        addEvent();
                    });
                }).catch(() => {
                    swal.fire('', ""در حال اتصال مجدد..."", 'error');
                    setTimeout(start, 5000);
                });
            }
        }
        connection.on(""ReceiveMessage"", function (userid, message, messageId) {
            if (userid == UserId) {
     ");
                WriteLiteral(@"           let tr = `<div data-id = ${messageId} class='col-md-12'><p class = 'RecevedMessage rounded' style = ''>${message}</p></div>`;
                $('#message_container').append(tr);
            }
            connection.invoke('DeliveryMessageInClient', messageId);
        });

        function LoadUsers() {
            return new Promise((resolve) => {
                $('#spiner').show();
                var url = '/chat/LoadUsers';
                $.post(url, function (result) {

                    if (result.isSuccess) {
                        let user = '<a href=""javascript:void(0)"" class=""closebtn"" onclick=""closeNav()"">&times;</a>';
                        for (let i = 0; i < result.data.length; i++) {
                            user += `<a style = 'color:${result.data[i].isOnline ? 'green' : 'white'}'
                                                            data-userid='${result.data[i].id}' href=""#"" class = 'user'>${result.data[i].fullName} - ${result.data[i].messageCount}</");
                WriteLiteral(@"a>`;
                        }
                        $('#users_Container').html(user);
                        $('#spiner').hide();
                    }
                    else {

                    }
                    resolve();
                });
            });
        }
        start();
        function addEvent() {
            $('#users_Container a.user').on('click', function (el) {
                $('#users_Container a').css('border', '');
                $('#users_Container a').css('background-color', '');
                el.currentTarget.style.border = ""1px solid white"";
                el.currentTarget.style.backgroundColor = ""#e2b200"";
                UserId = el.currentTarget.dataset[""userid""];
                PageNumber = 0;
                $('#message_container').html(`<button class = 'LoadMore btn btn-success' onclick = 'LoadMore()'><i class='fa fa-angle-double-up'></i></button>`);
                loadMessages(UserId);
            });
        }

        function");
                WriteLiteral(@" loadMessages(userid) {
            var url = '/chat/LoadMessages';
            var inpuModel = {
                Id: userid,
                PageCount: 4,
                PageNumber: 1
            }
            $.post(url, { Targetuser: inpuModel }, function (result) {
                if (result.isSuccess) {
                    if (result.data.length > 0) {
                        //PageNumber++;
                        PickMessages(result.data);
                        DeliveryReceivedMessages();
                    }
                    else {
                        swal.fire('!', 'پیامی وجود ندارد', 'warning');
                    }
                }
                else {

                }
            });
        }
        function PickMessages(data) {

            let messages = ``;
            for (let i = 0; i < data.length; i++) {
                let stateIcon = '';
                messages += `<p class = 'col-md-12 time' style = 'text-align:center;'>${data[i].time}</p>`");
                WriteLiteral(@";
                if (data[i].isReceivedMessage) {
                    messages += `<div data-time = ${data[i].time} class='col-md-12 RecevedMessage' data-id = '${data[i].uniqId}'><p class = 'RecevedMessage rounded'  style = ''>${data[i].text}</p></div>`;
                }
                else {
                    if (data[i].isReceived) {
                        stateIcon = tick;
                    }
                    messages += `<div data-time = ${data[i].time} class='col-md-12 SentMessage' data-id = '${data[i].uniqId}'>${stateIcon}<p class = 'SentMessage rounded' style = ''>${data[i].text}</p></div>`;
                }
            }
            $('#message_container').prepend(messages);
        }

        function SendMessage() {
            var id = generateUUID();

            var message = $('#MessageText').val();
            if ($('#MessageText').val().replaceAll(' ', '') == '' || $('#MessageText').val() == null) {
                return
            }
            if (UserId ==");
                WriteLiteral(@" null) {
                swal.fire('خطا', 'یک کاربر را انتخاب کنید', 'error')
                return
            }
            connection.invoke('SendMessageToOne', message, id, UserId);
            $('#message_container').append(`<div data-id = ${id} class='col-md-12 clock'><div class = 'stateIcon'>${clock}</div><p class = 'SentMessage rounded'>${message}</p></div>`);
            $('#MessageText').val('');
        }
        connection.on(""DeliveryMessageInServer"", function (messageId) {

            $(`#message_container div[data-id=${messageId}] div.stateIcon`).html(``);
        });
        connection.on(""SentMessageToClient"", function (messageId) {
            $(`#message_container div[data-id=${messageId}] div.stateIcon`).html(tick);
        });
        function LoadMore() {
            var first_time = $('#message_container div').first().data('time') == undefined ? null : $('#message_container div').first().data('time');
            var url = '/chat/LoadMessage_LastMessageTime';
       ");
                WriteLiteral(@"     debugger
            var inputModel = {
                FirstMessageTime: first_time,
                Id: UserId,
                PageCount: 4, };
            $.post(url, { model: inputModel }, function (result) {
                if (result.isSuccess) {
                    if (result.data.length > 0) {
                        //PageNumber++;
                        PickMessages(result.data);
                        DeliveryReceivedMessages();
                    }
                    else {
                        swal.fire('!', 'پیامی وجود ندارد', 'warning');
                    }
                }
            })
        }
        function DeliveryReceivedMessages() {
            var messageIds = [];
            for (let i = 0; i < $(`#message_container div.RecevedMessage`).length; i++) {
                var id = $(`#message_container div.RecevedMessage`)[i].dataset['id'];
                messageIds.push(id);
            }
            if (messageIds.length > 0) {

             ");
                WriteLiteral(@"   connection.invoke('DeliveryMessageInClientList', messageIds);
            }
        }
        function OpenModal_Contacts() {
            var url = '/chat/Mod_Contacts';
            $.get(url, function (result) {
                $('#modalbody').html(result);
                $('#Contact_Modal').modal();
            });
        }
        function OpenUser_Nav() {
            debugger
            if (document.getElementById(""users"").style.left == '0px') {
                closeNav();
            }
            else {
                
                openNav();
            }
        }
    </script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
