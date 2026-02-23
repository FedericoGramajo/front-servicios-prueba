namespace ClientLibrary.Models.Booking.States
{
    public static class BookingStateFactory
    {
        public static IBookingState Create(string? status)
        {
            if (string.IsNullOrEmpty(status)) return new UnknownState();

            return status.ToLower() switch
            {
                "pending" or "pendiente" => new PendingState(),
                "confirmed" or "confirmado" or "confirmada" => new ConfirmedState(),
                "inprogress" or "en curso" or "en-progreso" => new InProgressState(),
                "completed" or "completado" or "completada" or "finalizado" or "finalizada" => new CompletedState(),
                "canceled" or "cancelado" or "cancelada" => new CanceledState(),
                _ => new UnknownState()
            };
        }
    }
}
