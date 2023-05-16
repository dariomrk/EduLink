using Riok.Mapperly.Abstractions;

namespace Application.Dtos.Appointment
{
    [Mapper]
    internal static partial class Mappings
    {
        internal static partial Data.Models.Appointment ToModel(this CreateAppointmentRequestDto dto);
        internal static partial AppointmentResponseDto ToDto(this Data.Models.Appointment model);
        internal static partial IQueryable<AppointmentResponseDto> ProjectToDto(this IQueryable<Data.Models.Appointment> appointments);
    }
}
