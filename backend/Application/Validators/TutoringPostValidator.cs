using Application.Dtos.TutoringPost;
using Application.Extensions;
using Application.Interfaces;
using Data.Enums;
using Data.Interfaces;
using FluentValidation;

namespace Application.Validators
{
    internal class TutoringPostValidator : AbstractValidator<RequestDto>
    {
        private readonly IRepository<Data.Models.TutoringPost, long> _tutoringPostRepository;
        private readonly IUserService _userService;
        private readonly IFieldService _fieldService;

        public TutoringPostValidator(
            IRepository<Data.Models.TutoringPost, long> tutoringPostRepository,
            IUserService userService,
            IFieldService fieldService)
        {
            _tutoringPostRepository = tutoringPostRepository;
            _userService = userService;
            _fieldService = fieldService;

            RuleFor(tutoringPost => tutoringPost.TutorUsername)
                .NotEmpty()
                .MustAsync(async (username, cancellationToken) =>
                    await _userService.IsEligibleAsTutor(username, cancellationToken))
                .WithMessage($"The user is not eligible to be a tutor.");

            RuleFor(tutoringPost => tutoringPost.PricePerHour)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage($"Price per hour must be greater than 0.");

            RuleFor(tutoringPost => tutoringPost.Currency)
                .NotEmpty()
                .Length(3)
                .IsEnumName(typeof(Currency), caseSensitive: false)
                .WithMessage($"Currency is not supported.");

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

            RuleFor(tutoringPost => tutoringPost.SubjectName)
                .NotEmpty()
                .MustAsync(_fieldService.SubjectExists);

            RuleFor(tutoringPost => tutoringPost.Fields)
                .NotEmpty()
                .CustomAsync(async (fields, context, cancellationToken) =>
                {
                    var fieldsList = fields.ToList();

                    var tasks = fieldsList.Select(field =>
                        _fieldService.SubjectContainsField(
                            context.InstanceToValidate.SubjectName,
                            field,
                            cancellationToken));

                    var taskResults = await Task.WhenAll(tasks);

                    taskResults
                        .ToList()
                        .ForEach((taskResult, i) =>
                        {
                            if (!taskResult) context.AddFailure(
                                $"Field `{fieldsList[i]}` " +
                                $"is not contained in subject `{context.InstanceToValidate.SubjectName}`.");
                        });
                });

            throw new NotImplementedException();
        }
    }
}
