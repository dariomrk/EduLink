using Application.Dtos.TutoringPost;
using Application.Interfaces;
using Data.Enums;
using Data.Interfaces;
using Data.Models;
using FluentValidation;

namespace Application.Validators.TutoringPostValidators
{
    internal class CreateTutoringPostDtoValidator : AbstractValidator<CreateTutoringPostDto>
    {
        private readonly IRepository<TutoringPost, long> _tutoringPostRepository;
        private readonly IUserService _userService;

        public CreateTutoringPostDtoValidator(
            IRepository<TutoringPost, long> tutoringPostRepository,
            IUserService userService)
        {
            _tutoringPostRepository = tutoringPostRepository;
            _userService = userService;

            RuleFor(tutoringPost => tutoringPost.TutorUsername)
                .NotEmpty()
                .MustAsync(async (username, cancellationToken) =>
                    await _userService.IsEligibleAsTutor(username, cancellationToken));

            RuleFor(tutoringPost => tutoringPost.PricePerHour)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(tutoringPost => tutoringPost.Currency)
                .NotEmpty()
                .Length(3)
                .IsEnumName(typeof(Currency), caseSensitive: false);

            RuleFor(tutoringPost => tutoringPost.AvailableTimeSpans)
                .NotEmpty()
                .ForEach(timeSpan => timeSpan
                    .Must(timeSpan =>
                        timeSpan.Start < timeSpan.End)
                    .WithMessage("The appointment time frame start must precede the time frame end.")
                    .Must(timeSpan =>
                        timeSpan.Start > DateTime.Now.Add(timeSpan.Start.Offset))
                    .WithMessage("An appointment time frame must start in the future.")
                    .Must(timeSpan =>
                        timeSpan.Start.AddHours(8) < timeSpan.End)
                    .WithMessage("A single appointment time frame must be less then 8 hours."));

            //RuleFor(tutoringPost => tutoringPost.Fields)
            //    .NotEmpty()
            //    .ForEach(field => field
            //        .Must(field => )) // TODO check whether the field exists for the given subject

            throw new NotImplementedException();
        }
    }
}
