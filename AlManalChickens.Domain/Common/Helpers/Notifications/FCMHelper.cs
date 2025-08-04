using AAITHelper.ModelHelper;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;

namespace AlManalChickens.Domain.Common.Helpers.Notifications;

public class FCMHelper
{
    public static async Task<bool> SendPushNotificationAsync(List<DeviceIdModel> device_Ids, Dictionary<string, string> data, string msg = "")
    {
        foreach (var device in device_Ids)
        {
            if (device is null) continue;

            string deviceId = device.DeviceId;
            var message = new Message
            {
                Notification = new Notification
                {
                    Title = device.ProjectName,
                    Body = msg
                },

                Token = deviceId,
                Data = data,
            };

            try
            {
                var messaging = FirebaseMessaging.DefaultInstance;
                string response = await messaging.SendAsync(message);
            }
            catch (FirebaseException)
            {
                continue;
            }
        }
        return true;
    }
}