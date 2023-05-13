using Riok.Mapperly.Abstractions;

namespace Application.Dtos.Appointment
{
    [Mapper]
    internal static partial class Mappings
    {
        internal static partial Data.Models.Appointment ToModel(this CreateAppointmentRequestDto dto);
        internal static partial ResponseAppointmentDto ToDto(this Data.Models.Appointment model);
    }
}
