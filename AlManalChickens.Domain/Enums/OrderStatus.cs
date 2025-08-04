namespace AlManalChickens.Domain.Enums
{

    public enum OrderStatus
    {
        NewOrder = 1,
        ClientAccept = 2,
        ProviderSendOffer = 3,
        ClientPay = 4,
        Finished = 5,
        ClientCancel = 6,
    }
}
