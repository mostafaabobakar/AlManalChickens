using AlManalChickens.Domain.Entities.Chat;
using AlManalChickens.Persistence;
using AlManalChickens.Services.Api.Contract.Chat;
using AlManalChickens.Services.DTO.ChatDTO;
using Microsoft.AspNetCore.SignalR;
using Nancy.Json;
using System.Net;
using System.Text;

namespace AlManalChickens.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IChatService _chatServices;
        private readonly ApplicationDbContext _context;

        public ChatHub(IChatService chatServices, ApplicationDbContext context)
        {
            _chatServices = chatServices;
            _context = context;
        }

        public async Task SendMessage(string SenderId, string ReceiverId, string Text, string OrderId, int Type = 0, int Duration = 0)
        {
            if (!string.IsNullOrEmpty(SenderId) && !string.IsNullOrEmpty(ReceiverId) && !string.IsNullOrEmpty(Text))
            {
                _ = await _chatServices.AddNewMessage(SenderId, ReceiverId, int.Parse(OrderId), Text, Type, Duration);

                List<string> ListContext = _context.HubConnections.Where(x => x.UserId == ReceiverId).Select(x => x.ContextId).ToList();

                if (ListContext.Count > 0)
                {
                    var data = new NewMessageDto
                    {
                        message = Text,
                        SenderId = SenderId,
                        ReceiverId = ReceiverId,
                        Date = DateTime.Now.ToString("hh:mm tt"),
                        Type = Type,
                        Duration = Duration
                    };


                    foreach (var ContextId in ListContext)
                    {
                        await Clients.Client(ContextId).SendAsync("receiveMessage", data);
                    }
                }
                else
                {
                    List<string> Devices = await _chatServices.GetDevicesId(ReceiverId);
                    string GetReceiverName = await _chatServices.GetReceiverName(ReceiverId);
                    SendPushNotification(Devices, ReceiverId, GetReceiverName, 10, int.Parse(OrderId));
                }
            }
        }

        //To Connect in Mobile
        public async Task Connect(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                HubConnection connect = new HubConnection
                {
                    UserId = userId,
                    ContextId = Context.ConnectionId,
                    DateTime= DateTime.Now
                };
                _context.HubConnections.Add(connect);
                _context.SaveChanges();
                await Clients.All.SendAsync("connected", true);
            }
        }

        //To DisConnect in Mobile
        public async Task DisConnect(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                var ListContext = _context.HubConnections.Where(x => x.UserId == userId).ToList();
                if (ListContext.Count > 0)
                {
                    _context.HubConnections.RemoveRange(ListContext);
                    _context.SaveChanges();
                }
                await Clients.All.SendAsync("disconnected", false);
            }
        }

        public void SendPushNotification(List<string> Devices, string receiverId, string receiverName, int? type = 0, int? orderId = 0)
        {
            try
            {
                foreach (var item in Devices)
                {
                    string applicationID = "AAAAu_gEWkA:APA91bHC0z4RkS8facAbYTfeoqI7I_J4ZDagHF9Pk73kQE3cQaWR_GdR_q-0aP1DJeDBNsqzDw1dNcIjBeDF5sl7mZBAEbvF3QjJAPw1kFf5f6CNA59_ShgJN74vl4WQX0rO4FFCqOCN";
                    string senderId = "807319919168";
                    string deviceId = item;
                    WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                    tRequest.Method = "post";
                    tRequest.ContentType = "application/json";
                    if (true)
                    {
                        var data = new
                        {
                            to = deviceId,

                            notification = new
                            {
                                body = "لديك رسالة جديدة",
                                userType = 1,
                                title = "رسالة جديدة",
                                sound = "Enabled",
                                priority = "high",
                                type = type,
                                receiverId = receiverId,
                                receiverName = receiverName,
                                orderId = orderId
                                ,
                                click_action = "FLUTTER_NOTIFICATION_CLICK"
                            },
                            data = new
                            {
                                body = "لديك رسالة جديدة",
                                userType = 1,
                                title = "رسالة جديدة",
                                sound = "Enabled",
                                priority = "high",
                                type = type,
                                receiverId = receiverId,
                                receiverName = receiverName,
                                orderId = orderId
                                ,
                                click_action = "FLUTTER_NOTIFICATION_CLICK"
                            }
                        };
                        var serializer = new JavaScriptSerializer();
                        var json = serializer.Serialize(data);
                        Byte[] byteArray = Encoding.UTF8.GetBytes(json);
                        tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
                        tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                        tRequest.ContentLength = byteArray.Length;
                        using (Stream dataStream = tRequest.GetRequestStream())
                        {
                            dataStream.Write(byteArray, 0, byteArray.Length);
                            using (WebResponse tResponse = tRequest.GetResponse())
                            {
                                using (Stream dataStreamResponse = tResponse.GetResponseStream())
                                {
                                    using (StreamReader tReader = new StreamReader(dataStreamResponse))
                                    {
                                        String sResponseFromServer = tReader.ReadToEnd();
                                        string str = sResponseFromServer;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;

            }
        }

    }
}
